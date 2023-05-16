using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class rock : MonoBehaviour
{
    private Vector3 offset;
    public float power = 10.0f;
    public GameObject camera;
    bool colide = false;
    private int count = 0;
    public TextMeshProUGUI countText;
    Rigidbody rb;
    float mx = 0.0f;
    float mz = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
         offset = camera.transform.position - transform.position;
}

    // Update is called once per frame


    void LateUpdate()
    {
        camera.transform.position = transform.position + offset;
    }

    private void OnMove(InputValue  inputValue)
    {
        Vector2 mv = inputValue.Get<Vector2>();
        mx = mv.x;
        mz = mv.y;
    }

    private void OnFire()
    {
        Vector3 v3 = new Vector3(0.0f, 30.0f, 0.0f);
        if (colide) rb.AddForce(v3*power);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        count++;
        countText.text = "" + count;
    }


    void FixedUpdate()
    {
        Vector3 v3 = new Vector3(mx, 0.0f, mz);
        if (colide) rb.AddForce(v3*power);
    }

    private void OnCollisionStay(Collision collision)
    {
        colide = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colide = false;
    }

}
