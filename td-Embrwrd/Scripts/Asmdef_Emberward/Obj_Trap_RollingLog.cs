using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_Trap_RollingLog : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CCR_Trigger_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_Trap_RollingLog _003C_003E4__this;

		private float _003CrollTime_003E5__2;

		private float _003Ctimer_003E5__3;

		private float _003CgravityForce_003E5__4;

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
		public _003CCR_Trigger_003Ed__31(int _003C_003E1__state)
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
	private Collider collider;

	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private Obj_AreaMonsterDetector detector;

	[SerializeField]
	private Transform node_Button;

	[SerializeField]
	private Transform node_ButtonTop;

	[SerializeField]
	private float range;

	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject node_RollingLog;

	[SerializeField]
	private List<Transform> list_MonsterDetectNodes;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float damage_Percentage;

	[SerializeField]
	private float buttonDetectInterval;

	private float buttonDetectTimer;

	private bool isTriggered;

	private Vector3 logDefaultPos;

	private float rollingRoundInterval;

	private float rollingRoundTimer;

	private int monsterHitCount;

	private Vector3Int lastFrameGridPos;

	private List<AMonsterBase> list_MonstersDetected;

	private List<AMonsterBase> list_MonstersAttacked;

	private bool isRollingOnGround;

	private bool isTooltipOn;

	private bool isOutlineOn;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private void OnRoundStart(int currentRound, int totalRound)
	{
	}

	private void Update()
	{
	}

	public void ResetToStart()
	{
	}

	public void Trigger()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Trigger_003Ed__31))]
	private IEnumerator CR_Trigger()
	{
		return null;
	}

	private void OnMouseOver()
	{
	}

	private void OnMouseExit()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayExit()
	{
	}
}
