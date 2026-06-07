using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/VSync", fileName = "VSync", order = 0)]
	public class VSyncSO : VariableSO<bool>
	{
		[SerializeField]
		private BoolVariableSO _limitFrameRateSO;

		[SerializeField]
		private TargetFrameRateSO _targetFrameRateSO;

		public override void SetValue(bool value)
		{
			base.SetValue(value);
			UpdateVSyncCount();
		}

		protected override void OnEnable()
		{
			SetValue(Value);
			_limitFrameRateSO.ValueChanged += OnLimitFrameRateChanged;
			_targetFrameRateSO.ValueChanged += OnTargetFrameRateChanged;
		}

		protected override void OnDisable()
		{
			QualitySettings.vSyncCount = 0;
			_limitFrameRateSO.ValueChanged -= OnLimitFrameRateChanged;
			_targetFrameRateSO.ValueChanged -= OnTargetFrameRateChanged;
		}

		private void OnTargetFrameRateChanged(int _)
		{
			UpdateVSyncCount();
		}

		private void OnLimitFrameRateChanged(bool _)
		{
			UpdateVSyncCount();
		}

		private void UpdateVSyncCount()
		{
			if (!Value)
			{
				QualitySettings.vSyncCount = 0;
			}
			else if (!_limitFrameRateSO.Value)
			{
				QualitySettings.vSyncCount = 1;
			}
			else
			{
				QualitySettings.vSyncCount = Mathf.Max(Mathf.RoundToInt((float)Screen.currentResolution.refreshRateRatio.value / (float)_targetFrameRateSO.Value), 1);
			}
		}
	}
}
