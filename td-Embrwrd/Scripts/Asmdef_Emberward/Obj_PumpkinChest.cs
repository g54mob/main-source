using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_PumpkinChest : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_RemoveProc_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_PumpkinChest _003C_003E4__this;

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
		public _003CCR_RemoveProc_003Ed__26(int _003C_003E1__state)
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

	[Header("移除花費")]
	[SerializeField]
	private int cost;

	[SerializeField]
	private List<Renderer> list_Renderers;

	private List<Vector3> list_OriginalLocalPos;

	private List<Quaternion> list_OriginalLocalRot;

	private bool isActivated;

	private bool isMouseDown;

	private float mouseDownTimer;

	private const int COST_EACH_BLOCK = 2;

	private bool isRemoved;

	private int boneSoundLoopIndex;

	private Vector3 cameraPosOnBoneRemove;

	private bool isOutlineOn;

	private bool isTooltipOn;

	private bool isShowingGridTooltip;

	private bool isShowingObjectTooltip;

	private int holdingDownMouseIndex;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
	}

	private void OnMouseUp()
	{
	}

	private void StartBoneRemove()
	{
	}

	private void InterruptBoneRemove()
	{
	}

	public void PayToRemove()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseOver()
	{
	}

	private void OnMouseExit()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RemoveProc_003Ed__26))]
	private IEnumerator CR_RemoveProc()
	{
		return null;
	}
}
