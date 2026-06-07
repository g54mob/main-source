using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_ModifyBlockCard_Popup : APopupWindow
{
	private enum eState
	{
		NO_CARD = 0,
		HAVE_MAIN_CARD = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_ConfirmModifyProc_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ModifyBlockCard_Popup _003C_003E4__this;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_ConfirmModifyProc_003Ed__26(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Button button_AddMainCard;

	[SerializeField]
	private Button button_Cancel;

	[SerializeField]
	private UI_Obj_ShopCard card_MainCard;

	[SerializeField]
	private List<UI_Obj_ModifyBlockSlot> list_ModifyBlockSlots;

	[SerializeField]
	private ParticleSystem particle_Flare_BG;

	[SerializeField]
	private ParticleSystem particle_Flare_Front;

	[SerializeField]
	private List<ParticleSystem> list_HammerParticles;

	[SerializeField]
	private GameObject node_JoystickStep1Tip;

	[SerializeField]
	private GameObject node_JoystickStep2Tip;

	private bool isButtonClicked;

	private eState state;

	private TetrisCardData mainCardData;

	private TetrisCardData selectedCardData;

	private bool isFinalCardSelected;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	public void SetupContent()
	{
	}

	private void Update()
	{
	}

	private void OnClickButton_AddMainCard()
	{
	}

	private void OnSelectedCardFromBackpack(CardData data)
	{
	}

	private void OnClickButton_Cancel()
	{
	}

	private void SwitchState(eState state)
	{
	}

	private void SwitchState_NoCard()
	{
	}

	private void SwitchState_HaveMainCard()
	{
	}

	private void OnClickModifyBlockSlot(int index, int cost, CardData data)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ConfirmModifyProc_003Ed__26))]
	private IEnumerator CR_ConfirmModifyProc()
	{
		return null;
	}

	public void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect()
	{
	}
}
