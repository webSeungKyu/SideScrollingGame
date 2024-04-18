using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player; // 플레이어 오브젝트의 Transform 컴포넌트를 받아올 변수
    public float moveSpeed = 3f; // 몬스터의 이동 속도
    public float detectionRange = 10f; // 몬스터가 플레이어를 감지할 수 있는 최대 거리
    public GameObject die; // 자식 게임오브젝트



    void Update()
    {
        // 플레이어와 몬스터의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 플레이어와의 거리가 일정 거리 이내라면
        if (distanceToPlayer <= detectionRange)
        {
            // 플레이어 쪽으로 이동
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        if (!die)
        {
            Destroy(gameObject);
        }

    }

    
}
