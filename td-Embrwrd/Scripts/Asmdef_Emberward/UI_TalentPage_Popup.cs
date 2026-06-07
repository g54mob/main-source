using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TalentPage_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_LearnAllTalents_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TalentPage_Popup _003C_003E4__this;

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
		public _003CCR_LearnAllTalents_003Ed__36(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_StartEffect_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TalentPage_Popup _003C_003E4__this;

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
		public _003CCR_StartEffect_003Ed__52(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CTriggerSmallBounceAnimRecursive_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TalentPage_Popup _003C_003E4__this;

		public Vector2Int fromCoord;

		public float delay;

		public Vector3 origin;

		private List<UI_Obj_TalentButton> _003CneighborButtons_003E5__2;

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
		public _003CTriggerSmallBounceAnimRecursive_003Ed__48(int _003C_003E1__state)
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
	private TalentSettingData data;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private Button button_Reset;

	[SerializeField]
	private Button button_LearnAll;

	[SerializeField]
	private Transform node_SelectionFrame;

	[SerializeField]
	private ParticleSystem particle_ChargeEffect;

	[SerializeField]
	private ParticleSystem particle_ChargeFullEffect;

	[SerializeField]
	private ParticleSystem particle_LearnAllEffect;

	[SerializeField]
	private List<UI_Obj_TalentButton> list_TalentButton;

	[SerializeField]
	private Dictionary<Vector2Int, UI_Obj_TalentButton> dic_TalentButton;

	[SerializeField]
	private GameObject node_UnlockTip;

	[SerializeField]
	private ParticleSystem particle_AllTalentUnlocked_1;

	[SerializeField]
	private ParticleSystem particle_AllTalentUnlocked_2;

	[Header("搖桿功能")]
	[SerializeField]
	private float joystickSelectDistanceThreshold;

	private bool isPressingTalentButton;

	private int currentButtonIndex;

	private int curExpValue;

	private bool canLearnAllTalent;

	private bool isInAnimation;

	private int clickCountWithoutUnlock;

	private float joystickMoveCooldown;

	private List<Vector2Int> list_playedButtons;

	private UI_Obj_TalentButton curSelectedTalentButton;

	public bool IsPressingTalentButton => false;

	public bool IsInAnimation => false;

	protected override void ShowWindowProc()
	{
	}

	private void CheckDemoVersionTalentUpdate()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	protected override void OnEnableProc()
	{
	}

	private void Update()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnClickLeave()
	{
	}

	private void OnClickReset()
	{
	}

	private void OnClickLearnAll()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LearnAllTalents_003Ed__36))]
	private IEnumerator CR_LearnAllTalents()
	{
		return null;
	}

	private void ResetConfirmCallback(bool doReset)
	{
	}

	private void ShowLearnAllButtonIfPossible()
	{
	}

	private bool DoShowLearnAllButton()
	{
		return false;
	}

	private void ResetAllTalents()
	{
	}

	private void OnTalentButtonMouseIn(UI_Obj_TalentButton button, TalentSetting talentData)
	{
	}

	private void UpdateText(TalentSetting talentData)
	{
	}

	private void OnTalentButtonMouseOut(UI_Obj_TalentButton button)
	{
	}

	private void OnTalentButtonDown(UI_Obj_TalentButton button)
	{
	}

	private void OnTalentButtonUp(UI_Obj_TalentButton button)
	{
	}

	private void OnTalentButtonFillFull(UI_Obj_TalentButton button, int index, TalentSetting talentData, bool decreaseAnimation)
	{
	}

	[IteratorStateMachine(typeof(_003CTriggerSmallBounceAnimRecursive_003Ed__48))]
	private IEnumerator TriggerSmallBounceAnimRecursive(Vector3 origin, Vector2Int fromCoord, float delay)
	{
		return null;
	}

	private void Initialize()
	{
	}

	private void ResetAllButtonState()
	{
	}

	private void UpdateAllButtonState()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_StartEffect_003Ed__52))]
	private IEnumerator CR_StartEffect()
	{
		return null;
	}

	private void SetButtonStateByData()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void SetSelectedTalentButton(UI_Obj_TalentButton talentButton)
	{
	}

	private bool SelectNodeByInputAxisDirection()
	{
		return false;
	}

	private UI_Obj_TalentButton GetNodeByInputAxisDirection(List<UI_Obj_TalentButton> list_Candidates)
	{
		return null;
	}

	private List<UI_Obj_TalentButton> GetNeighborButtons(Vector2Int coord)
	{
		return null;
	}

	private UI_Obj_TalentButton GetButtonByCoord(Vector2Int vector2Int)
	{
		return null;
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
