using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private GameObject playerGo;
    private CircleCollider2D eyeballCircleCollider;
    private Rigidbody2D playerRB;
    private CircleCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerGo = this.transform.parent.gameObject;
        eyeballCircleCollider = GetComponent<CircleCollider2D>();
        playerRB = playerGo.GetComponent<Rigidbody2D>();
        playerCollider = playerGo.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //mousePosition = Input.mousePosition;
        mousePosition = Camera.main.WorldToScreenPoint(playerGo.transform.position);

        transform.position = Vector2.Lerp(
            transform.position, playerGo.transform.position + (Input.mousePosition - mousePosition).normalized
            * (playerCollider.radius - eyeballCircleCollider.radius), moveSpeed);
    }
}