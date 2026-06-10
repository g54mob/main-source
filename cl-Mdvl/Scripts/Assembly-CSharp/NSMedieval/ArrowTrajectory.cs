using System;
using System.Collections;
using UnityEngine;

namespace NSMedieval
{
	public class ArrowTrajectory : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private GameObject wiggleHelper;

		[SerializeField]
		private float height = 1f;

		private CubicBezierPath path;

		private Vector3[] knots;

		private float t;

		private float amplitude = 60f;

		private float frequency = 4f;

		private float offset = 0.01f;

		private void Start()
		{
			knots = new Vector3[4];
			Vector3 position = base.transform.position;
			Vector3 position2 = target.position;
			knots[0] = position;
			knots[1] = new Vector3((position2.x - position.x) / 3f, (position2.y - position.y) / 3f + height, (position2.z - position.z) / 3f);
			knots[2] = new Vector3((position2.x - position.x) * 2f / 3f, (position2.y - position.y) * 2f / 3f + height, (position2.z - position.z) * 2f / 3f);
			knots[3] = position2;
			path = new CubicBezierPath(knots);
		}

		private void Update()
		{
			t += Time.deltaTime;
			if (path != null)
			{
				Vector3 pointNorm = path.GetPointNorm(t + offset);
				if (t >= 1f)
				{
					StartCoroutine(Hit());
					wiggleHelper.transform.rotation = Quaternion.Euler(Wiggle(t * 2f), 0f, 0f);
				}
				else
				{
					base.transform.position = path.GetPointNorm(t);
					base.transform.LookAt(pointNorm);
				}
			}
		}

		private IEnumerator Hit()
		{
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private float Wiggle(float t)
		{
			return amplitude * Mathf.Exp(0f - t) * Mathf.Cos(MathF.PI * 2f * t * frequency);
		}
	}
}
