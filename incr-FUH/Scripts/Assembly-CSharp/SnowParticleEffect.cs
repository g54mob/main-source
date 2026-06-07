using System.Collections;
using UnityEngine;

public class SnowParticleEffect : MonoBehaviour
{
	private ParticleSystem ps;

	private ParticleSystem.ForceOverLifetimeModule forceModule;

	private Coroutine windCoroutine;

	private void Start()
	{
		ps = GetComponent<ParticleSystem>();
		forceModule = ps.forceOverLifetime;
		forceModule.enabled = true;
		StartCoroutine(WindRoutine());
	}

	private IEnumerator WindRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(5f);
			Vector3 vector = new Vector3(Random.Range(-2f, 2f), 0f, 0f);
			forceModule.x = new ParticleSystem.MinMaxCurve(vector.x);
			yield return new WaitForSeconds(1f);
			forceModule.x = new ParticleSystem.MinMaxCurve(0f);
		}
	}
}
