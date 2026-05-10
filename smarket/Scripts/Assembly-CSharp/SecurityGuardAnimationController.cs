using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using __Project__.Scripts.Multiplayer;

public class SecurityGuardAnimationController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMove_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SecurityGuardAnimationController _003C_003E4__this;

		public int speedLevel;

		public Vector3 target;

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
		public _003CMove_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CMoveTo_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SecurityGuardAnimationController _003C_003E4__this;

		public Vector3 target;

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
		public _003CMoveTo_003Ed__18(int _003C_003E1__state)
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
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Animator m_Animator;

	private float m_AnimationWalkingSpeed;

	private float m_RotationSmoothness;

	private NetworkSecurityGuardAnimationController m_NetworkSecurityGuardAnimationController;

	private OffMeshLinkNavigator m_OffMeshNavigator;

	private readonly List<float> m_RunnigSpeeds;

	public NetworkSecurityGuardAnimationController NetworkSecurityGuardAnimationController => null;

	public bool Carrying
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Teleport(Vector3 target)
	{
	}

	public void SwingBat()
	{
	}

	public void SetSpeed(int _speedLevel)
	{
	}

	[IteratorStateMachine(typeof(_003CMove_003Ed__17))]
	public IEnumerator Move(Vector3 target, int speedLevel)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveTo_003Ed__18))]
	private IEnumerator MoveTo(Vector3 target)
	{
		return null;
	}
}
