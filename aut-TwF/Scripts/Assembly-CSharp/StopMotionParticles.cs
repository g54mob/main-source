using System.Collections;
using UnityEngine;

public class StopMotionParticles : MonoBehaviour
{
	[SerializeField]
	private float stepTime = 0.1f;

	private ParticleSystem ps;

	private Coroutine stopMotionCoroutine;

	private void Awake()
	{
		ps = GetComponent<ParticleSystem>();
	}

	private void Start()
	{
		this.StartCoroutineCheckingVar(StopMotionCoroutine(), ref stopMotionCoroutine);
	}

	private IEnumerator StopMotionCoroutine()
	{
		WaitForSeconds wfs = new WaitForSeconds(stepTime);
		while (true)
		{
			ps.Simulate(stepTime, withChildren: false, restart: false, fixedTimeStep: false);
			yield return wfs;
		}
	}
}
