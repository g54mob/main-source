using UnityEngine;

namespace Effects
{
	public class FishingLineEffect : MonoBehaviour
	{
		private LineRenderer lineRenderer;

		private Transform startTransform;

		private Transform endTransform;

		private const int SegmentCount = 20;

		public void SetStart(Transform start)
		{
			startTransform = start;
		}

		public void SetTarget(Transform target)
		{
			endTransform = target;
		}

		private void Start()
		{
			lineRenderer = GetComponentInChildren<LineRenderer>() ?? GetComponent<LineRenderer>();
			lineRenderer.positionCount = 20;
		}

		private void Update()
		{
			if (!(startTransform == null) && !(endTransform == null))
			{
				Vector3 position = startTransform.position;
				Vector3 position2 = endTransform.position;
				Vector3 controlPoint = new Vector3(position.x, position2.y, position.z);
				for (int i = 0; i < 20; i++)
				{
					float t = (float)i / 20f;
					lineRenderer.SetPosition(i, CalculateBezierPoint(t, startTransform.position, controlPoint, endTransform.position));
				}
			}
		}

		private Vector3 CalculateBezierPoint(float t, Vector3 start, Vector3 controlPoint, Vector3 end)
		{
			return Mathf.Pow(1f - t, 2f) * start + 2f * (1f - t) * t * controlPoint + Mathf.Pow(t, 2f) * end;
		}
	}
}
