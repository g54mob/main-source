using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_AltarEffectReward_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_AltarEffectReward_Popup _003C_003E4__this;

		private List<Obj_UI_AltarChoice_V2>.Enumerator _003C_003E7__wrap1;

		private int _003Ci_003E5__3;

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
		public _003CCR_ShowWindowProc_003Ed__12(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowRewardCard_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_UI_AltarChoice_V2 altarChoise;

		public UI_Obj_ShopCard cardFace;

		public int i;

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
		public _003CShowRewardCard_003Ed__11(int _003C_003E1__state)
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
	private List<Obj_UI_AltarChoice_V2> list_AltarChoices;

	[SerializeField]
	private Transform anchor_CardFaces;

	[SerializeField]
	private GameObject prefab_CardFace;

	private List<AltarPactData> list_ActivatedPacts;

	private List<Obj_UI_AltarChoice_V2> list_ActiveChoices;

	private List<UI_Obj_ShopCard> list_CardFaces;

	private float waitTime;

	public void Setup(List<AltarPactData> list_ActivatedPacts)
	{
	}

	private bool IsEffectInList(eAltarEffectTypeV2 effectType)
	{
		return false;
	}

	public AltarPactData GetPactDataByEffectType(eAltarEffectTypeV2 effectType)
	{
		return null;
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CShowRewardCard_003Ed__11))]
	private IEnumerator ShowRewardCard(Obj_UI_AltarChoice_V2 altarChoise, UI_Obj_ShopCard cardFace, int i)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__12))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
