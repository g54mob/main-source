using System;
using TMPro;
using UnityEngine;

namespace UI
{
	public class RemoveMachineDialog : BaseDialog
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TMP_Text countText;

		[SerializeField]
		private TMP_Text countInfiniteText;

		[SerializeField]
		private GeneralMessageSetter yesMessageSetter;

		[SerializeField]
		private GeneralMessageSetter noMessageSetter;

		[SerializeField]
		private TMP_Text cautionText;

		[SerializeField]
		private TMP_Text bonusText;

		[SerializeField]
		private GameObject breakButtonObj;

		[SerializeField]
		private TMP_Text breakButtonText;

		private Action<bool> pushYesAction;

		private Action pushNoAction;

		private string countTextDefault;

		private string breakTextDefault;

		private bool isEnableCompleteRemoveMachine;

		private MstMachineDataEntities machineData;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void UpdateCountText()
		{
		}

		public void OnBreakButton()
		{
		}

		public void OnYesButton()
		{
		}

		public void OnNoButton()
		{
		}

		private void SetTitle()
		{
		}

		private void SwitchCompleteRemove()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}

		public override void PushEscape()
		{
		}

		public override void SetInFront()
		{
		}
	}
}
