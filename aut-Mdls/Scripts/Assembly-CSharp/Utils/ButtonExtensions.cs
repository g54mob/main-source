using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
	public static class ButtonExtensions
	{
		public static void PressButton(this Button button)
		{
			if (button.IsActive() && button.IsInteractable())
			{
				UISystemProfilerApi.AddMarker("Button.onClick", button);
				button.onClick.Invoke();
			}
		}
	}
}
