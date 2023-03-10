using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 10;
    [SerializeField] float stopDistance = 2;
    [SerializeField] string animatorSpeedName;
    private Animator anim;
    private float animWalkFloat = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 a, b;
        a = target.transform.position;
        b = transform.position;
        a.y = b.y = 0;

        if (Vector3.Distance(a, b) > stopDistance)
        {
            Vector3 direction = a - b;
            animWalkFloat = 1;
            anim?.SetFloat(animatorSpeedName, animWalkFloat);
            direction = direction.normalized;
            direction.y = 0;
            transform.position += direction * Time.deltaTime * speed;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            animWalkFloat = Mathf.Lerp(animWalkFloat, 0, 0.02f);
            anim?.SetFloat(animatorSpeedName, animWalkFloat);
        }



    }
    public float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
