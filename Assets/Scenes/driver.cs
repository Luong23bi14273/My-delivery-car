using UnityEngine;

public class driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float steerSpeed = 240f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float boostDuration = 2f;
    float boostEndTime = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > boostEndTime){
        moveSpeed = normalSpeed;
    }
        float changeSteer = Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float changeMove = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Translate(0, changeMove, 0);
        transform.Rotate(0, 0,-changeSteer);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = normalSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "flash")
        {
            moveSpeed = boostSpeed;
            boostEndTime = Time.time + boostDuration;
        }
    }
}
