using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_SnowLevelBrazier : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_RemoveProc_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_RemoveProc_003Ed__28(int _003C_003E1__state)
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
	[Header("啟動花費 (金幣)")]
	private int cost;

	[SerializeField]
	private float range;

	[SerializeField]
	private GameObject node_Model;

	[SerializeField]
	private GameObject node_Range;

	[SerializeField]
	private Renderer renderer;

	[SerializeField]
	private ParticleSystem particle_Flame;

	private bool isActivated;

	private bool isMouseDown;

	private float mouseDownTimer;

	private Collider rightMostCollider;

	private const int COST_EACH_BLOCK = 2;

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

	private void StartActivation()
	{
	}

	private void InterruptActivation()
	{
	}

	public void Activate()
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

	[IteratorStateMachine(typeof(_003CCR_RemoveProc_003Ed__28))]
	private IEnumerator CR_RemoveProc()
	{
		return null;
	}
}
