using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isClick = false;
    private SpringJoint2D sp;
    private Rigidbody2D rb;

    public Transform rightPos;
    public float maxDis = 3;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()//鼠标按下
    {
        isClick = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()//鼠标抬起
    {
        isClick = false;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);
    }
    private void Update()
    {
        if (isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position -= new Vector3(0, 0, -Camera.main.transform.position.z);
            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }
        }
    }
    void Fly()
    {
        sp.enabled = false;
    }
}
