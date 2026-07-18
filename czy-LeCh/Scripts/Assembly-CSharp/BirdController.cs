using UnityEngine;

public class BirdController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem pSystem;

	private void Start()
	{
		ParticleSystem.EmissionModule emission = pSystem.emission;
		emission.enabled = true;
		emission.SetBurst(0, new ParticleSystem.Burst(0f, 3, 16, 1, 0.01f));
		pSystem.Play();
		int startPointMultiplier = GetStartPointMultiplier();
		base.transform.position = new Vector3(125 * startPointMultiplier, Random.Range(25, 45), 125 * -startPointMultiplier);
		Quaternion rotation = Quaternion.LookRotation(-(new Vector3(0f, base.transform.position.y, 0f) - base.transform.position).normalized);
		base.transform.rotation = rotation;
	}

	private int GetStartPointMultiplier()
	{
		if (Random.Range(0, 2) != 0)
		{
			return 1;
		}
		return -1;
	}
}
