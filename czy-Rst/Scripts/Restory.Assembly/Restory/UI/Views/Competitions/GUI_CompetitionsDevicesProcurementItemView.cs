using System;
using Helpers.Extensions;
using Restory.UserInterface;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.Competitions
{
	public sealed class GUI_CompetitionsDevicesProcurementItemView : UIBehaviour
	{
		public enum ItemState
		{
			Normal = 0,
			Requested = 1,
			InsufficientFunds = 2,
			LicenseRequired = 3
		}

		[SerializeField]
		private Image deviceIcon;

		[SerializeField]
		private GUI_LocalisedText deviceName;

		[SerializeField]
		private TextMeshProUGUI reward;

		[SerializeField]
		private TextMeshProUGUI bestTime;

		[SerializeField]
		private TextMeshProUGUI participationPrice;

		[SerializeField]
		private Image requestProgressFillImage;

		[SerializeField]
		private GUI_PresetSwitcher statePresetSwitcher;

		public event Action OnSubmitRequestButtonDowned;

		public event Action OnSubmitRequestButtonUpped;

		public void Init(Sprite deviceIcon, string deviceNameLocID, int participationPrice, int rewardAmount, TimeSpan bestTime)
		{
			this.deviceIcon.sprite = deviceIcon;
			deviceName.LocalizationID = deviceNameLocID;
			this.participationPrice.text = participationPrice.ToReadableString();
			reward.text = rewardAmount.ToReadableString();
			this.bestTime.text = ((bestTime != TimeSpan.Zero) ? bestTime.ToString("mm\\:ss") : "-");
		}

		public void SetState(ItemState state)
		{
			string presetCustomName = state.ToString();
			statePresetSwitcher.ActivatePreset(presetCustomName);
		}

		public void SetRequestProgress(float progressNormalized)
		{
			requestProgressFillImage.fillAmount = progressNormalized;
		}

		public void SendSubmitRequestButtonPointerDown()
		{
			this.OnSubmitRequestButtonDowned?.Invoke();
		}

		public void SendSubmitRequestButtonPointerUp()
		{
			this.OnSubmitRequestButtonUpped?.Invoke();
		}
	}
}
