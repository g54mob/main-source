using UnityEngine;

namespace NSMedieval
{
	public class FlyUpEffect : MonoBehaviour
	{
		[SerializeField]
		private float distance = 200f;

		[SerializeField]
		private float animDuration = 1f;

		private Vector3 startPoint;

		private Vector3 targetPoint;

		private float elapsedTime;

		private void Start()
		{
			startPoint = base.transform.localPosition;
			targetPoint = startPoint;
			targetPoint.y += distance;
		}

		private void Update()
		{
			if (!(Time.deltaTime <= 0.001f))
			{
				float num = elapsedTime / animDuration;
				base.transform.localPosition = Vector3.Lerp(startPoint, targetPoint, num);
				elapsedTime += Time.deltaTime;
				if (num >= 0.95f)
				{
					Object.Destroy(base.gameObject);
				}
			}
		}
	}
}
