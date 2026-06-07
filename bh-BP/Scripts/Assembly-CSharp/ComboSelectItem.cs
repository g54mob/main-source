using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboSelectItem : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateBar_003Ed__25 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float tgtFill;

		public ComboSelectItem _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartFill_003E5__4;

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
		public _003C_AnimateBar_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003C_MoveToPos_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ComboSelectItem _003C_003E4__this;

		public Vector2 pos;

		private float _003Clen_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_MoveToPos_003Ed__27(int _003C_003E1__state)
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

	public RectTransform Xfm;

	public int Idx;

	public bool IsSelected;

	public Image ImgIcon;

	public CoolButton Btn;

	public Image ImgSelected;

	public Vector2 DefaultPos;

	public SlidingPanel Panel;

	public Localize LocName;

	public TextMeshProUGUI TxtName;

	private CoroutineHandle _curAnim;

	private CoroutineHandle _curMoveAnim;

	private float _curFill;

	public Image ImgBacking;

	public Sprite SprUnselected;

	public Sprite SprSelected;

	public GameObject WrapperTwitchVotes;

	public Localize LocNumVotes;

	public LocalizationParamsManager ParamsNumVotes;

	public TextMeshProUGUI TxtNumVotes;

	private void Awake()
	{
	}

	public void InitComboComponent(int heroIdx)
	{
	}

	private void OnClicked()
	{
	}

	private void OnStateChanged()
	{
	}

	private void SetFill(float fill)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateBar_003Ed__25))]
	private IEnumerator<float> _AnimateBar(float tgtFill)
	{
		return null;
	}

	public void SetSelected(bool isSelected, bool animate)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToPos_003Ed__27))]
	private IEnumerator<float> _MoveToPos(Vector2 pos)
	{
		return null;
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}

	public void SetNumVotes(int votes, int totalVotes)
	{
	}
}
