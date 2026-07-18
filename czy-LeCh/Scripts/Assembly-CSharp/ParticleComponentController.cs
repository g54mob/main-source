using System.Collections;
using UnityEngine;

public class ParticleComponentController : MonoBehaviour
{
	private ParticleSystem _ps;

	[SerializeField]
	private bool startOnAwake;

	[SerializeField]
	private float minStartDelay;

	[SerializeField]
	private float maxStartDelay;

	private IEnumerator Start()
	{
		_ps = GetComponent<ParticleSystem>();
		if (startOnAwake)
		{
			yield return new WaitForSeconds(Random.Range(minStartDelay, maxStartDelay));
			_ps.Play();
		}
	}
}
