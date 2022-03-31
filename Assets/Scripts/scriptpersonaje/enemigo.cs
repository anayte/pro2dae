using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    [SerializeField] Transform GroundDetection;
    [SerializeField] float dgDistance;
    [SerializeField] LayerMask gdLayer;
    ground groundMover;
    Vector2 moveDirection;

    // Start is called before the first frame update

    void Start()
    {
        groundMover = GetComponent<ground>();
        moveDirection = new Vector2(1f,0f);
    }

    // Update is called once per frame
    void Update()
    {   
            groundMover.FlipTransform(moveDirection.x);
            CheckGroundDetection();
    }

    void FixedUpdate()
    {
        groundMover.move(moveDirection.x);
    }

    void CheckGroundDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundDetection.position, Vector2.down, dgDistance, gdLayer);
        if(hit.collider == null)
        {
            moveDirection.x *= -1;
        }
    }
}
