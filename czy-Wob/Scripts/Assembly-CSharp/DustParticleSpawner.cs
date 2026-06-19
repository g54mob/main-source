using UnityEngine;

public class DustParticleSpawner : MonoBehaviour
{
	public GameObject dustParticles;

	private float dustVelocityMin = 10f;

	private Rigidbody selfRigidbody;

	private void Awake()
	{
		selfRigidbody = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision c)
	{
		if (!(c.transform.root == base.transform.root) && !(selfRigidbody.velocity.magnitude < dustVelocityMin))
		{
			CreateParticles();
		}
	}

	private void CreateParticles()
	{
		Object.Instantiate(dustParticles, base.transform.position, Quaternion.identity);
	}
}
