using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapScene_Altar_V2_Popup : APopupWindow
{
	public class ElementToPerkSetting
	{
		public eAltarEffectTypeV2 altarEffectType;

		public eItemType perkType;
	}

	[CompilerGenerated]
	private sealed class _003CCR_CardClickedProc_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Altar_V2_Popup _003C_003E4__this;

		public eAltarEffectTypeV2 altarEffectType;

		private UI_AltarPactSigned_Popup _003CaltarPackSignedPopup_003E5__2;

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
		public _003CCR_CardClickedProc_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowWindowProc_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Altar_V2_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CShowContentProc_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_MapScene_Altar_V2_Popup _003C_003E4__this;

		private List<Obj_UI_AltarChoice_V2>.Enumerator _003C_003E7__wrap1;

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
		public _003CShowContentProc_003Ed__18(int _003C_003E1__state)
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

	[SerializeField]
	[Header("標題文字")]
	private TMP_Text text_Title;

	[SerializeField]
	private Button button_Exit;

	[SerializeField]
	private List<Obj_UI_AltarChoice_V2> list_AltarChoices;

	[SerializeField]
	private UI_RelicList ui_relicList;

	[SerializeField]
	private List<ElementToPerkSetting> list_ElementToPerkSetting;

	private float timeSinceOpen;

	private bool isCardClickProcessFinished;

	private eAltarEffectTypeV2 selectedAltarEffectType;

	private eItemType sacrificeRelicType;

	private int cost;

	private bool isConfirmed;

	private bool doContinue;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	private void Update()
	{
	}

	public void SetupContent()
	{
	}

	private void UpdateUIContent()
	{
	}

	private eItemType GetRewardTypeByAltarEffect(eAltarEffectTypeV2 altarEffectType)
	{
		return default(eItemType);
	}

	[IteratorStateMachine(typeof(_003CShowContentProc_003Ed__18))]
	private IEnumerator ShowContentProc()
	{
		return null;
	}

	private void OnCardClickedCallback(eAltarEffectTypeV2 altarEffectType)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CardClickedProc_003Ed__22))]
	private IEnumerator CR_CardClickedProc(eAltarEffectTypeV2 altarEffectType)
	{
		return null;
	}

	private eItemType GetPerkTypeByAltarEffect(eAltarEffectTypeV2 altarEffectType)
	{
		return default(eItemType);
	}

	private void ResetConfirmCallback(bool isConfirm)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__25))]
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

	public override void OnWindowRegainFocus()
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
