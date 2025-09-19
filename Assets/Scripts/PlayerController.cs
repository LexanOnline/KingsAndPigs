using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private GatherImput m_gatherImput;
    private Transform m_transform;
    [SerializeField] private float speed;
    private int direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gatherImput = GetComponent<GatherImput>();
        m_transform = GetComponent<Transform>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Flip();
        m_rigidbody2D.linearVelocity = new Vector2(speed * m_gatherImput.ValueX, m_rigidbody2D.linearVelocity.y);

    }

    private void Flip()
    {
        if(m_gatherImput.ValueX * direction < 0)
        {
            m_transform.localScale = new Vector3( -m_transform.localScale.x, 1,1 );
            direction *= -1;
        }
    }
}
