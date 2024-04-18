using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player; // �÷��̾� ������Ʈ�� Transform ������Ʈ�� �޾ƿ� ����
    public float moveSpeed = 3f; // ������ �̵� �ӵ�
    public float detectionRange = 10f; // ���Ͱ� �÷��̾ ������ �� �ִ� �ִ� �Ÿ�
    public GameObject die; // �ڽ� ���ӿ�����Ʈ



    void Update()
    {
        // �÷��̾�� ������ �Ÿ� ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �÷��̾���� �Ÿ��� ���� �Ÿ� �̳����
        if (distanceToPlayer <= detectionRange)
        {
            // �÷��̾� ������ �̵�
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        if (!die)
        {
            Destroy(gameObject);
        }

    }

    
}
