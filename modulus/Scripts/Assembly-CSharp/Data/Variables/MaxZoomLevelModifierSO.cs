using Presentation.Locators;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/MaxZoomLevelModifier", fileName = "MaxZoomLevelModifier", order = 0)]
	public class MaxZoomLevelModifierSO : VariableSO<int>
	{
		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		public override void SetValue(int value)
		{
			UpdateMaxZoomLevelModifier();
			base.SetValue(value);
		}

		protected override void OnEnable()
		{
			SetValue(Value);
			base.ValueChanged += OnMaxZoomLevelModifierChanged;
		}

		protected override void OnDisable()
		{
			base.ValueChanged -= OnMaxZoomLevelModifierChanged;
		}

		private void OnMaxZoomLevelModifierChanged(int _)
		{
			UpdateMaxZoomLevelModifier();
		}

		private void UpdateMaxZoomLevelModifier()
		{
			if (_cameraViewLocator.CameraView != null)
			{
				_cameraViewLocator.CameraView.SetMaxZoomLevelModifier(Value);
			}
		}
	}
}
