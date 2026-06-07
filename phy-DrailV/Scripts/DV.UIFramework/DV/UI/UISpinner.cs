using UnityEngine;

namespace DV.UI
{
	public class UISpinner : MonoBehaviour
	{
		[Tooltip("Degrees per second, in unscaled time")]
		public float speed = -360f;

		private void Update()
		{
			base.transform.Rotate(0f, 0f, speed * Time.unscaledDeltaTime);
		}
	}
}
