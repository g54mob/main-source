using Data.Variables;
using FronkonGames.Artistic.TiltShift;
using UnityEngine;

namespace Logic.Lighting
{
	public class PostprocessingManager : MonoBehaviour
	{
		[SerializeField]
		private ResolutionSO _resolutionSO;

		[SerializeField]
		private TiltShiftSO _tiltShiftSO;

		private void Awake()
		{
			_resolutionSO.ValueChanged += OnResolutionChanged;
			_tiltShiftSO.ValueChanged += OnTiltshiftActivated;
		}

		private void OnDestroy()
		{
			_resolutionSO.ValueChanged -= OnResolutionChanged;
			_tiltShiftSO.ValueChanged -= OnTiltshiftActivated;
		}

		private void OnTiltshiftActivated(bool _)
		{
			UpdateTiltShiftSettings(_tiltShiftSO.GetCurrentTiltShift());
		}

		private void OnResolutionChanged(Vector2Int _)
		{
			UpdateTiltShiftSettings(_tiltShiftSO.GetCurrentTiltShift());
		}

		private void UpdateTiltShiftSettings(TiltShift tiltShift)
		{
			int x = _resolutionSO.Value.x;
			int y = _resolutionSO.Value.y;
			if (x == 1920 && y == 1080)
			{
				tiltShift.settings.aperture = 0.3f;
				tiltShift.settings.blur = 0.45f;
				return;
			}
			if (x == 2560 && y == 1440)
			{
				tiltShift.settings.aperture = 0.35f;
				tiltShift.settings.blur = 0.5f;
				return;
			}
			if (x == 3840 && y == 2160)
			{
				tiltShift.settings.aperture = 0.4f;
				tiltShift.settings.blur = 0.6f;
				return;
			}
			if (x == 2560 && y == 1080)
			{
				tiltShift.settings.aperture = 0.3f;
				tiltShift.settings.blur = 0.4f;
				return;
			}
			float value = x + y;
			float num = 3000f;
			float num2 = 6000f;
			Mathf.Clamp(value, num, num2);
			float t = Mathf.InverseLerp(num, num2, value);
			tiltShift.settings.aperture = Mathf.Lerp(0.3f, 0.4f, t);
			tiltShift.settings.blur = Mathf.Lerp(0.45f, 0.6f, t);
		}
	}
}
