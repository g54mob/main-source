using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class FlexibleGridLayoutGroup : CoolSelectable
{
	[CompilerGenerated]
	private sealed class _003C_ReserveSpaces_003Ed__24 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FlexibleGridLayoutGroup _003C_003E4__this;

		public int newCapacity;

		public bool force;

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
		public _003C_ReserveSpaces_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003C_WaitToRefreshDimensions_003Ed__15 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public FlexibleGridLayoutGroup _003C_003E4__this;

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
		public _003C_WaitToRefreshDimensions_003Ed__15(int _003C_003E1__state)
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

	private FlexibleGridLayoutGroup _parentGrp;

	public GridLayoutGroup TgtGrp;

	public ScrollRect ScrollOwner;

	public RectTransform RectXfm;

	public FlexibleFitMode FitMode;

	public float FitWidthPct;

	public float FitHeightPct;

	public int FitNumRows;

	public int FitNumCols;

	public FlexibleExpandMode ExpandMode;

	private bool _isInitialized;

	private int _lastSelectedChildIdx;

	private int _reservedSpaces;

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitToRefreshDimensions_003Ed__15))]
	private IEnumerator<float> _WaitToRefreshDimensions()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	public GridLayoutGroup GetGridLayoutGroup()
	{
		return null;
	}

	public float GetColWidth(int numCols)
	{
		return 0f;
	}

	public Vector2 GetRectSize()
	{
		return default(Vector2);
	}

	public void SetFitRowsCols(int rows, int cols)
	{
	}

	public void RefreshDimensions()
	{
	}

	public int GetCapacity()
	{
		return 0;
	}

	public void ReserveSpaces(int newCapacity, bool force = false)
	{
	}

	[IteratorStateMachine(typeof(_003C_ReserveSpaces_003Ed__24))]
	private IEnumerator<float> _ReserveSpaces(int newCapacity, bool force = false)
	{
		return null;
	}

	public bool IsInitialized()
	{
		return false;
	}

	public void AddChild(Transform xfm)
	{
	}

	public override bool IsInteractable()
	{
		return false;
	}

	public override void Select(MoveDirection entryDir = MoveDirection.None)
	{
	}

	private int GetGridIdx(int col, int row)
	{
		return 0;
	}

	private void GetGridPos(int idx, out int col, out int row)
	{
		col = default(int);
		row = default(int);
	}

	public void DetermineGridNav()
	{
	}

	public override void OnChildMove(AxisEventData evData, CoolSelectable child)
	{
	}
}
