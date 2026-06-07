using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__17 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public DialogUI _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_AnimateEntry_003Ed__17(int _003C_003E1__state)
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

	public static DialogUI I;

	public DialogArgs CurArgs;

	public RectTransform WrapperIcon;

	public Image ImgIcon;

	public TextSizeRectFitter TextFitter;

	public TextMeshProUGUI Txt;

	public Localize TxtLoc;

	public LocalizationParamsManager TxtParams;

	public RectTransform WrapperBtns;

	public CoolButton BtnOk;

	public Localize LocOk;

	public CoolButton BtnCancel;

	public Localize LocCancel;

	private bool _isShowing;

	private List<DialogArgs> _pendingDialogs;

	private CoolButton _prevSelected;

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__17))]
	protected override IEnumerator<float> _AnimateEntry()
	{
		return null;
	}

	public override void OnExitComplete()
	{
	}

	public void Show(DialogArgs args)
	{
	}

	public void ClearPendingDialogs()
	{
	}

	public DialogArgs CreateSimpleArgs(string txt)
	{
		return null;
	}

	public DialogArgs CreateYesNoArgs(string txt)
	{
		return null;
	}

	public void Show(string txt)
	{
	}

	public void ShowCantAffordResource(ResourceType rt)
	{
	}

	public void ShowCantAffordCost(Cost c)
	{
	}

	public void ShowYesNo(string txt, Action onOk)
	{
	}

	private void OnOkClicked()
	{
	}

	private void OnCancelClicked()
	{
	}

	public void ClearPrevSelected()
	{
	}

	public void QueueSelection(CoolButton toSelect)
	{
	}

	protected override void MyUpdate()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	public override void OnUnderlayClicked()
	{
	}

	public bool IsShowing()
	{
		return false;
	}
}
