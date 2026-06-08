using UnityEngine;

namespace Huey.Game
{
	public class HideOnNonDemo : MonoBehaviour
	{
		private void Awake()
		{
			CheckIfShouldDisplay();
		}

		private void OnEnable()
		{
			CheckIfShouldDisplay();
		}

		private void CheckIfShouldDisplay()
		{
			base.transform.gameObject.SetActive(value: false);
		}
	}
}
