using Data.Variables;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Logic.Settings
{
	public class CameraQualityWidget : MonoBehaviour
	{
		[SerializeField]
		private UniversalAdditionalCameraData _cameraData;

		[SerializeField]
		private QualityLevelSO _qualityLevel;

		private void Awake()
		{
			if (_cameraData == null)
			{
				_cameraData = GetComponent<UniversalAdditionalCameraData>();
			}
			_qualityLevel.ValueChanged += SetCameraQuality;
		}

		private void OnDestroy()
		{
			_qualityLevel.ValueChanged -= SetCameraQuality;
		}

		private void SetCameraQuality(int quality)
		{
			switch (quality)
			{
			case 0:
				_cameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
				_cameraData.antialiasingQuality = AntialiasingQuality.High;
				break;
			case 1:
				_cameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
				_cameraData.antialiasingQuality = AntialiasingQuality.Medium;
				break;
			case 2:
				_cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
				break;
			}
		}
	}
}
