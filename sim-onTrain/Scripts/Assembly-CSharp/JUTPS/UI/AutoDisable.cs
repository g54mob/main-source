using UnityEngine;

namespace JUTPS.UI
{
	[AddComponentMenu("JU TPS/Utilities/Auto Disable")]
	public class AutoDisable : MonoBehaviour
	{
		public float SecondsToDisable;

		private void Start()
		{
			Invoke("Disable", SecondsToDisable);
		}

		private void Disable()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
