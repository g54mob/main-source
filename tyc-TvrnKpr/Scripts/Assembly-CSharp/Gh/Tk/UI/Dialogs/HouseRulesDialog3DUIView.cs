using System;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class HouseRulesDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Slider3DUIView _repairingThresholdSlider;

		[SerializeField]
		private TextMeshProI18n _repairingThresholdText;

		protected override void Awake()
		{
		}

		private void OnRepairingSliderValueChanged(object sender, EventArgs e)
		{
		}

		private void UpdateRepairingSliderText(int value)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void SetThresholds()
		{
		}
	}
}
