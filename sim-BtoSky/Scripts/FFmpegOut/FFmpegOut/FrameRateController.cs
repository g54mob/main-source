using UnityEngine;

namespace FFmpegOut
{
	[AddComponentMenu("FFmpegOut/Frame Rate Controller")]
	public sealed class FrameRateController : MonoBehaviour
	{
		[SerializeField]
		private float _frameRate = 60f;

		[SerializeField]
		private bool _offlineMode = true;

		private int _originalFrameRate;

		private int _originalVSyncCount;

		internal int CalculateVSyncCount()
		{
			int refreshRate = Screen.currentResolution.refreshRate;
			float num = refreshRate;
			switch (refreshRate)
			{
			case 23:
				num = 23.976f;
				break;
			case 29:
				num = 29.97f;
				break;
			case 47:
				num = 47.952f;
				break;
			case 59:
				num = 59.94f;
				break;
			case 71:
				num = 71.928f;
				break;
			case 119:
				num = 119.88f;
				break;
			}
			if (Mathf.Approximately(num % _frameRate, 0f))
			{
				return Mathf.RoundToInt(num / _frameRate);
			}
			return 0;
		}

		private void OnEnable()
		{
			int num = Mathf.RoundToInt(_frameRate);
			if (_offlineMode)
			{
				_originalFrameRate = Time.captureFramerate;
				Time.captureFramerate = num;
				return;
			}
			_originalFrameRate = Application.targetFrameRate;
			_originalVSyncCount = QualitySettings.vSyncCount;
			Application.targetFrameRate = num;
			QualitySettings.vSyncCount = CalculateVSyncCount();
		}

		private void OnDisable()
		{
			if (_offlineMode)
			{
				Time.captureFramerate = _originalFrameRate;
				return;
			}
			Application.targetFrameRate = _originalFrameRate;
			QualitySettings.vSyncCount = _originalVSyncCount;
		}
	}
}
