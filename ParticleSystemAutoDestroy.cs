using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemAutoDestroy : MonoBehaviour {
    
    private ParticleSystem ps;

    public void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    public void FixedUpdate() {
        if (!ps.IsAlive()) {
            Destroy(gameObject);
        }
    }
}