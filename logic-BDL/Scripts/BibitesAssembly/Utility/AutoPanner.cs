using System.Collections;
using SimulationScripts;
using UnityEngine;

namespace Utility
{
	public class AutoPanner : MonoBehaviour
	{
		public float force = 10f;

		public float maxSpeed = 1f;

		public float minWait = 30f;

		public float maxWait = 90f;

		private Vector3 destination;

		private Rigidbody2D rb;

		private bool started;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void StartAutoPanner()
		{
			started = true;
			StartCoroutine("ChangeDirection");
		}

		private void FixedUpdate()
		{
			if (started)
			{
				Vector3 vector = destination - base.transform.position;
				if (vector.magnitude < 10f)
				{
					NewDir();
				}
				rb.AddForce(force * vector.normalized * (maxSpeed - rb.linearVelocity.magnitude));
			}
		}

		private IEnumerator ChangeDirection()
		{
			float seconds = Random.Range(minWait, maxWait);
			while (true)
			{
				yield return new WaitForSeconds(seconds);
				NewDir();
				seconds = Random.Range(minWait, maxWait);
			}
		}

		private void NewDir()
		{
			destination = ZoneManager.instance.GetRandomPositionInZone();
		}
	}
}
