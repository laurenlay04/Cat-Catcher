using UnityEngine;

public class HeartBurstParticles : MonoBehaviour
{
    public int particleCount = 100;
    public float explosionForce = 3f;
    public float fallGravity = 1f;

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        // Emit particles
        var emitParams = new ParticleSystem.EmitParams();
        ps.Emit(particleCount);

        // Fetch particles and set initial velocity
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
        int count = ps.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            float t = (float)i / count * Mathf.PI * 2;
            Vector3 dir = HeartDirection(t);
            particles[i].velocity = dir * explosionForce;
            particles[i].startLifetime = 1.5f;
            particles[i].remainingLifetime = 1.5f;
            particles[i].startSize = 0.1f;
            particles[i].startColor = Color.red;
        }

        ps.SetParticles(particles, count);
        //Memory allocation after longest lifetime
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        //falling effect
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
        int count = ps.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            particles[i].velocity += Vector3.down * fallGravity * Time.deltaTime;
        }

        ps.SetParticles(particles, count);
    }

    // Returns a direction pointing outward along a heart shape
    Vector3 HeartDirection(float t)
    {
    float x = 16 * Mathf.Pow(Mathf.Sin(t), 3);
    float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t)
              - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);
    return new Vector3(x, y, 0) * 0.04f; // Scale it down
}
}
