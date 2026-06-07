using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StaffrollDialog : BaseDialog
{
	[CompilerGenerated]
	private sealed class _003CCorAnimation_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StaffrollDialog _003C_003E4__this;

		private List<StaffrollItem>.Enumerator _003C_003E7__wrap1;

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
		public _003CCorAnimation_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CWaitWithSkip_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float _time;

		public StaffrollDialog _003C_003E4__this;

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
		public _003CWaitWithSkip_003Ed__19(int _003C_003E1__state)
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
	private StaffrollItem m_OrgItem;

	[SerializeField]
	private GameObject m_Contents;

	[SerializeField]
	private CategoryPageController categoryPageController;

	[SerializeField]
	private Scrollbar licenseScrollBar;

	private bool m_IsEnd;

	private bool m_IsSkip;

	private Coroutine m_Coroutine;

	private List<StaffrollItem> m_List;

	public void Awake()
	{
	}

	public override void Init()
	{
	}

	public override void Open()
	{
	}

	public void OnSelectCategory(int categoryNum)
	{
	}

	public override void Back()
	{
	}

	public void StartAnimation()
	{
	}

	private void InitItems()
	{
	}

	public void StopAnimation()
	{
	}

	private void CreateDataList()
	{
	}

	[IteratorStateMachine(typeof(_003CCorAnimation_003Ed__17))]
	private IEnumerator CorAnimation()
	{
		return null;
	}

	public bool IsAnimationEnd()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CWaitWithSkip_003Ed__19))]
	private IEnumerator WaitWithSkip(float _time)
	{
		return null;
	}

	private void StopItemAnimations()
	{
	}

	public void OnTapSkip(BaseEventData _data)
	{
	}

	public void OnTapClose()
	{
	}

	public override void PlayOpenSound()
	{
	}

	public override void PlayCloseSound()
	{
	}
}
