using System;
using NSEipix.Base;
using NSMedieval.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class CaravanWorkerEntry : LayoutGroupItemView
	{
		[SerializeField]
		private WorkerEntryLayoutItemView workerEntry;

		[SerializeField]
		private BasicLayoutItemView weightLabel;

		[SerializeField]
		private Toggle selectWorkerToggle;

		[SerializeField]
		private TMP_Text statusText;

		[SerializeField]
		private GameObject cannotSelectBackground;

		[SerializeField]
		private GameObject greyForeground;

		[SerializeField]
		private LocalizedTextTooltipView toggleTooltip;

		[SerializeField]
		private Button bbtButtonOnToggle;

		private Action<bool, HumanoidInstance> onToggle;

		private string bbtText = string.Empty;

		public bool IsSelectedForCaravan => selectWorkerToggle.isOn;

		public HumanoidInstance Humanoid => workerEntry.HumanoidInstance;

		public void Reset()
		{
			selectWorkerToggle.SetIsOnWithoutNotify(value: false);
		}

		public void SetToggle(bool value)
		{
			selectWorkerToggle.isOn = value;
		}

		public void SetData(HumanoidInstance humanoid, Action<bool, HumanoidInstance> onToggle)
		{
			this.onToggle = onToggle;
			weightLabel?.SetText(string.Format("+{0}{1}", humanoid.GetCaravanCarryWeight(), base.Localize.GetText("general_kg")));
			bool flag = true;
			if (humanoid.WorkerBehaviour != null)
			{
				flag = !humanoid.HasFainted && !humanoid.WorkerBehaviour.IsBanished && !humanoid.WorkerBehaviour.IsCrazy && !humanoid.IsBeingCarried;
			}
			workerEntry.SetHumanoidInstance(humanoid, selectable: false);
			statusText.gameObject.SetActive(!flag);
			cannotSelectBackground.SetActive(!flag);
			selectWorkerToggle.interactable = flag;
			selectWorkerToggle.onValueChanged.RemoveAllListeners();
			selectWorkerToggle.isOn = false;
			selectWorkerToggle.onValueChanged.AddListener(OnSelectToggle);
			bbtButtonOnToggle.enabled = !flag;
			toggleTooltip.SetEnabled(!flag);
		}

		public void SetDataNonInteractable(HumanoidInstance humanoid, bool toggleState)
		{
			onToggle = null;
			weightLabel?.SetText(string.Format("+{0}{1}", humanoid.GetCaravanCarryWeight(), base.Localize.GetText("general_kg")));
			workerEntry.SetHumanoidInstance(humanoid, selectable: false);
			statusText.gameObject.SetActive(value: false);
			cannotSelectBackground.SetActive(value: true);
			selectWorkerToggle.interactable = false;
			selectWorkerToggle.onValueChanged.RemoveAllListeners();
			selectWorkerToggle.isOn = toggleState;
			bbtButtonOnToggle.enabled = false;
			toggleTooltip.SetEnabled(isEnabled: false);
		}

		public void SetClickable(bool clickable, bool showCheckBox, string tooltipKey, string bbtText)
		{
			selectWorkerToggle.interactable = clickable;
			selectWorkerToggle.gameObject.SetActive(showCheckBox);
			greyForeground.SetActive(!clickable);
			this.bbtText = bbtText;
			toggleTooltip.SetTooltipKey(tooltipKey);
			toggleTooltip.SetEnabled(!clickable);
			bbtButtonOnToggle.enabled = !clickable;
		}

		public void SetClickable(bool clickable, string tooltipKey, string bbtText)
		{
			if (!selectWorkerToggle.gameObject.activeSelf)
			{
				selectWorkerToggle.gameObject.SetActive(value: true);
			}
			selectWorkerToggle.interactable = clickable;
			greyForeground.SetActive(!clickable);
			this.bbtText = bbtText;
			toggleTooltip.SetTooltipKey(tooltipKey);
			toggleTooltip.SetEnabled(!clickable);
			bbtButtonOnToggle.enabled = !clickable;
		}

		private void OnSelectToggle(bool selected)
		{
			HumanoidInstance humanoidInstance = workerEntry.HumanoidInstance;
			onToggle?.Invoke(selected, humanoidInstance);
		}

		private void Start()
		{
			bbtButtonOnToggle.onClick.RemoveAllListeners();
			bbtButtonOnToggle.onClick.AddListener(ShowUnavailableWorkerBbt);
		}

		private void ShowUnavailableWorkerBbt()
		{
			if (!string.IsNullOrEmpty(bbtText))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(bbtText);
			}
		}
	}
}
