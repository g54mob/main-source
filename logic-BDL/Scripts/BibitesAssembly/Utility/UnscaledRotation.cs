using UnityEngine;

namespace Utility
{
	public class UnscaledRotation : MonoBehaviour
	{
		public float rate;

		private void Update()
		{
			base.transform.rotation *= Quaternion.Euler(0f, 0f, Time.unscaledDeltaTime * rate * 360f);
		}
	}
}
