using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/TargetFrameRate", fileName = "TargetFrameRate", order = 0)]
	public class TargetFrameRateSO : VariableSO<int>
	{
		[SerializeField]
		private BoolVariableSO _limitFrameRateSO;

		public override void SetValue(int value)
		{
			UpdateTargetFrameRate();
			base.SetValue(value);
		}

		protected override void OnEnable()
		{
			SetValue(Value);
			_limitFrameRateSO.ValueChanged += OnLimitFrameRateChanged;
		}

		protected override void OnDisable()
		{
			_limitFrameRateSO.ValueChanged -= OnLimitFrameRateChanged;
		}

		private void OnLimitFrameRateChanged(bool _)
		{
			UpdateTargetFrameRate();
		}

		private void UpdateTargetFrameRate()
		{
			Application.targetFrameRate = (_limitFrameRateSO.Value ? Value : (-1));
		}
	}
}
