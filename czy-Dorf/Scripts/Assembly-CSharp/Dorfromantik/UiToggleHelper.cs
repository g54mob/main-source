using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	[RequireComponent(typeof(Toggle))]
	public class UiToggleHelper : MonoBehaviour
	{
		private Toggle targetToggle;

		private void Awake()
		{
			targetToggle = GetComponent<Toggle>();
		}

		public void Toggle()
		{
			targetToggle.isOn = !targetToggle.isOn;
		}
	}
}
