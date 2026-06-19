using UnityEngine;

namespace Gauges
{
	public class CompassGauge : MonoBehaviour
	{
		[SerializeField]
		private Transform _compassTransform;

		private void Update()
		{
			if (!(_compassTransform == null))
			{
				float y = base.transform.eulerAngles.y;
				_compassTransform.localRotation = Quaternion.Euler(0f, 0f - y, 0f);
			}
		}
	}
}
