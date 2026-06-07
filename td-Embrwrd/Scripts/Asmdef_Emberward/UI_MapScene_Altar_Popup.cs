using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapScene_Altar_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CCR_CardClickedProc_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Altar_Popup _003C_003E4__this;

		public eAltarEffectType altarEffectType;

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
		public _003CCR_CardClickedProc_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowWindowProc_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Altar_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003CShowContentProc_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Altar_Popup _003C_003E4__this;

		private List<Obj_UI_AltarChoice>.Enumerator _003C_003E7__wrap1;

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
		public _003CShowContentProc_003Ed__26(int _003C_003E1__state)
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

	[Header("標題文字")]
	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private Button button_Exit;

	[SerializeField]
	private List<Obj_UI_AltarChoice> list_AltarChoices;

	[SerializeField]
	private UI_RelicList ui_relicList;

	private int startCost_Recover;

	private int costIncrease_Recover;

	private int useCount_Recover;

	private int startCost_Sacrifice;

	private int cost_Purify_Per_HP;

	private int cost_Enhance;

	private int sacrificeUseCount;

	private int costIncrease_Sacrifice;

	private eAltarEffectType selectedAltarEffectType;

	private eItemType sacrificeRelicType;

	private bool isCardClickProcessFinished;

	private MapNodeData curMapNodeData;

	private int cost_Recover => 0;

	private int Cost_Sacrifice => 0;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	public void SetupContent(MapNodeData mapNodeData)
	{
	}

	private void UpdateUI()
	{
	}

	private void UpdateNewRelic(bool isInitialize)
	{
	}

	[IteratorStateMachine(typeof(_003CShowContentProc_003Ed__26))]
	private IEnumerator ShowContentProc()
	{
		return null;
	}

	private void OnCardClickedCallback(eAltarEffectType altarEffectType)
	{
	}

	private void Effect_Recover()
	{
	}

	private void Effect_Sacrifice()
	{
	}

	private void Effect_Purify()
	{
	}

	private void Effect_Enhance()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CardClickedProc_003Ed__32))]
	private IEnumerator CR_CardClickedProc(eAltarEffectType altarEffectType)
	{
		return null;
	}

	private void OnCardMouseEnterCallback(UI_Obj_ShopCard card)
	{
	}

	private void OnCardMouseExitCallback(UI_Obj_ShopCard card)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__35))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	private void Toggle(bool isOn)
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
}
