using UnityEngine;

namespace UIScripts.SettingHandles.References
{
	public class SettingSliderSizeUpdater : MonoBehaviour
	{
		public SettingSliderReference slider;

		private void OnRectTransformDimensionsChange()
		{
			slider.OnSizeChange.Invoke();
		}
	}
}
