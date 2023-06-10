using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    Vector3 distance;
    public float smoothValue;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow() {
        //현재 카메라 포지션
        Vector3 currentPos = transform.position;

        //현재 타겟 자동차
        Vector3 targetPos = target.position - distance;

        //currentPos(카메라)가 targetPos(자동차)을 smoothValue만큼 time 프레임에 맞춰 뒤따라감
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}
