using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UMA;
using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class AICharacterControl : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AICharacterControl _003C_003E4__this;

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
		public _003CStart_003Ed__28(int _003C_003E1__state)
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

	public NavMeshAgent agent;

	private ThirdPersonCharacter character;

	private DynamicCharacterAvatar avatar;

	private bool isCharacterCreated;

	private Vector3 target;

	[SerializeField]
	private GameObject positionToLookAt;

	[SerializeField]
	private Rig rig;

	public float radius;

	public float giveWayRadius;

	public float giveWayRadiusStop;

	public float giveWayTimes;

	private Transform player;

	public bool npcStopped;

	public bool isRotatingTowardsPlayer;

	public Animator anim;

	public bool isSitting;

	public bool isSittingWorking;

	[SerializeField]
	private bool isLying;

	[SerializeField]
	private Vector2 speedRange;

	private float rigWeightTime;

	private int destPoint;

	[SerializeField]
	private bool loopDestinationPoints;

	public Transform[] wayPoints;

	private void OnEnable()
	{
	}

	private void OnCreated(UMAData umadata)
	{
	}

	private void StartingAnimation()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__28))]
	private IEnumerator Start()
	{
		return null;
	}

	private void Update()
	{
	}

	public void SetTarget(Vector3 target)
	{
	}

	public bool AgentReachTarget()
	{
		return false;
	}

	private void moveBack(Vector3 direction)
	{
	}

	private void GotoNextPoint(Transform[] _waypoints)
	{
	}

	public void SetStopLoopingDestinationPoints()
	{
	}

	public void AnimSit(bool active)
	{
	}
}
