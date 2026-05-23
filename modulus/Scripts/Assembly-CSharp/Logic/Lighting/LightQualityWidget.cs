using Data.Variables;
using UnityEngine;
using UnityEngine.Rendering;

namespace Logic.Lighting
{
	public class LightQualityWidget : MonoBehaviour
	{
		[SerializeField]
		private QualityLevelSO _qualityLevelSo;

		[SerializeField]
		private Light _light;

		private void Awake()
		{
			_qualityLevelSo.ValueChanged += OnQualityLevelChanged;
		}

		private void OnDestroy()
		{
			_qualityLevelSo.ValueChanged -= OnQualityLevelChanged;
		}

		private void OnQualityLevelChanged(int value)
		{
			switch (value)
			{
			case 0:
				_light.shadowResolution = LightShadowResolution.High;
				break;
			case 1:
				_light.shadowResolution = LightShadowResolution.Medium;
				break;
			case 2:
				_light.shadowResolution = LightShadowResolution.Low;
				break;
			}
		}
	}
}
