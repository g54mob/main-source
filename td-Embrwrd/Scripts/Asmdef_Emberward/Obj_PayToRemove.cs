using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_PayToRemove : MonoBehaviour, IPlaceable, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CCR_RemoveProc_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_PayToRemove _003C_003E4__this;

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
		public _003CCR_RemoveProc_003Ed__30(int _003C_003E1__state)
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
	private List<Collider> list_ObjectPartColliders;

	[Header("移除花費")]
	[SerializeField]
	private int cost;

	private List<Renderer> list_Renderers;

	private List<Vector3> list_OriginalLocalPos;

	private List<Quaternion> list_OriginalLocalRot;

	private bool isActivated;

	private bool isMouseDown;

	private float mouseDownTimer;

	private Collider rightMostCollider;

	private const int COST_EACH_BLOCK = 2;

	private bool isRemoved;

	private int boneSoundLoopIndex;

	private Vector3 cameraPosOnBoneRemove;

	private bool isOutlineOn;

	private bool isTooltipOn;

	private bool isShowingGridTooltip;

	private bool isShowingObjectTooltip;

	private int holdingDownMouseIndex;

	public List<Collider> List_ObjectPartColliders => null;

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

	[IteratorStateMachine(typeof(_003CCR_RemoveProc_003Ed__30))]
	private IEnumerator CR_RemoveProc()
	{
		return null;
	}

	public List<Collider> GetCollisionColliders()
	{
		return null;
	}

	public ePlaceableType GetPlaceableType()
	{
		return default(ePlaceableType);
	}

	public List<Collider> GetPlacementColliders()
	{
		return null;
	}

	public Vector3 GetPlacementOffset()
	{
		return default(Vector3);
	}

	public void OnPlacementProc()
	{
	}

	public void SwitchToPlacementMode(object data)
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayClickDown()
	{
	}

	public void OnRayClickHold()
	{
	}

	public void OnRayClickUp()
	{
	}
}
