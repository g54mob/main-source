using System;
using NSEipix.Base;
using NSMedieval.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TravelWorkerEntry : LayoutGroupItemView
	{
		[SerializeField]
		private WorkerEntryLayoutItemView workerEntry;

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

		public bool IsWorkerAble => CanSelectHuman(workerEntry.HumanoidInstance);

		public HumanoidInstance Humanoid => workerEntry.HumanoidInstance;

		public void Reset()
		{
			selectWorkerToggle.SetIsOnWithoutNotify(value: false);
		}

		public void SetData(HumanoidInstance humanoid, Action<bool, HumanoidInstance> onToggle)
		{
			this.onToggle = onToggle;
			bool flag = true;
			if (humanoid.WorkerBehaviour != null)
			{
				flag = !humanoid.HasFainted && !humanoid.WorkerBehaviour.IsBanished && !humanoid.WorkerBehaviour.IsCrazy && !humanoid.IsBeingCarried;
			}
			workerEntry.SetHumanoidInstance(humanoid);
			statusText.gameObject.SetActive(!flag);
			cannotSelectBackground.SetActive(!flag);
			selectWorkerToggle.interactable = flag;
			selectWorkerToggle.onValueChanged.RemoveAllListeners();
			selectWorkerToggle.isOn = false;
			selectWorkerToggle.onValueChanged.AddListener(OnSelectToggle);
			bbtButtonOnToggle.enabled = !flag;
			toggleTooltip.SetEnabled(!flag);
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

		private static bool CanSelectHuman(HumanoidInstance humanoid)
		{
			if (humanoid.HasFainted || humanoid.IsBeingCarried || humanoid.HasDied || humanoid.HasDisposed)
			{
				return false;
			}
			if (humanoid.WorkerBehaviour != null && (humanoid.WorkerBehaviour.IsBanished || humanoid.WorkerBehaviour.IsCrazy))
			{
				return false;
			}
			return true;
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
