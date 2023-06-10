using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCtrl : MonoBehaviour
{
    public float moveSpeed = 8;
    public List<string> mAction;
    bool sideMoving = true;
    int actionIndex = 0;
    bool isMoving = false;

    void Start()
    {
        mAction = new List<string>() {"GO", "GO", "GO", "GO", "TR", "GO", "GO", "TR", "GO", "GO", "GO", "GO"};
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (isMoving == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.instance.GameStart();  // GameManager의 GameStart() 호출
                    StartCoroutine(PerformActions());
                }
            }
        }
    }

    void Stop()
    {
        moveSpeed = 0;
    }

    void Go()
    {
        moveSpeed = 8;
    }

    IEnumerator PerformActions()
    {
        foreach (string action in mAction)
        {
            if (action == "GO")
            {
                Go();
                StartCoroutine(MoveForDistance(4f));  // 2미터까지 이동하는 코루틴 실행
            }
            else if (action == "TL")
            {
                Stop();
                transform.Rotate(0, -90, 0);
            }
            else if (action == "TR")
            {
                Stop();
                transform.Rotate(0, 90, 0);
            }
            else if (action == "ER")
            {
                Stop();
            }

            yield return new WaitForSeconds(2f);  // 1초 대기
        }

        isMoving = false;
    }

    IEnumerator MoveForDistance(float distance)
    {
        float movedDistance = 0f;  // 이동한 거리 초기화
        isMoving = true;

        while (movedDistance < distance)
        {
            float moveAmount = moveSpeed * Time.deltaTime;  // 현재 프레임에서 이동할 거리 계산
            movedDistance += moveAmount;  // 이동한 거리 누적

            transform.Translate(Vector3.forward * moveAmount);  // 이동

            yield return null;  // 다음 프레임까지 대기
        }

        Stop();  // 목표 거리에 도달하면 정지
    }
}