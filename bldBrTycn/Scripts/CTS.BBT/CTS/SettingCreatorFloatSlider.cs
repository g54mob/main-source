using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/Float Slider")]
	public class SettingCreatorFloatSlider : SettingCreator<float>
	{
		[field: SerializeField]
		public UISettingFloatSlider FloatSliderPrefab { get; private set; }

		[field: SerializeField]
		public Vector2 SliderRange { get; private set; }

		[field: SerializeField]
		public Vector2 SettingRange { get; private set; }

		public override UISetting Spawn(Transform parent)
		{
			UISettingFloatSlider uISettingFloatSlider = CTSFactory.Instantiate(FloatSliderPrefab, parent, instantiateInWorldSpace: false, false);
			uISettingFloatSlider.Initialize(base.Setting, base.SettingName);
			uISettingFloatSlider.SetRange(SliderRange);
			uISettingFloatSlider.SetSettingRange(SettingRange);
			uISettingFloatSlider.gameObject.SetActive(value: true);
			return uISettingFloatSlider;
		}
	}
}
