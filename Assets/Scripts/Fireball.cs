using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    private float timer;

    void Start()
    {
        timer = lifetime;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
         Destroy(gameObject);
    }
}
