using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.DevConsole
{
	public class DeveloperToggleHelper : MonoBehaviour
	{
		[SerializeField]
		private Image toggleImage;

		[SerializeField]
		private bool toggle;

		public bool Toggle => toggle;

		public void ToggleImage(bool value)
		{
			toggle = value;
			toggleImage.enabled = value;
		}
	}
}
