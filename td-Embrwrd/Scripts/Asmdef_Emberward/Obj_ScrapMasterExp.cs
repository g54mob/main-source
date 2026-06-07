using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_ScrapMasterExp : MonoBehaviour
{
	private enum eState
	{
		SPAWN = 0,
		IDLE = 1,
		COLLECTING = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_JumpToTarget_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_ScrapMasterExp _003C_003E4__this;

		public float duration;

		public float jumpHeight;

		public Transform target;

		public Action OnComplete;

		private Vector3 _003CstartPosition_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CCR_JumpToTarget_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003CCR_RoundEndAutoCollect_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public Obj_ScrapMasterExp _003C_003E4__this;

		public bool isInstant;

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
		public _003CCR_RoundEndAutoCollect_003Ed__20(int _003C_003E1__state)
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
	private Transform node_Model;

	[SerializeField]
	private GameObject model_Lv1;

	[SerializeField]
	private GameObject model_Lv2;

	private Obj_ScrapMasterMachine parentMachine;

	private float detectInterval;

	private float detectTimer;

	private eState currentState;

	private int level;

	private bool isPlayerVictory;

	public static Obj_ScrapMasterExp Create(Vector3 position)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(int level, Obj_ScrapMasterMachine parentMachine)
	{
	}

	public void TriggerStartJumpAndMove(float jumpHeight, float duration, Vector3 jumpTarget)
	{
	}

	public void TriggerStartJump(float jumpHeight, float duration)
	{
	}

	private void Update()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnPlayerVictory()
	{
	}

	private void OnRequestCollectAllScrapMasterExp()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RoundEndAutoCollect_003Ed__20))]
	private IEnumerator CR_RoundEndAutoCollect(float delay, bool isInstant = false)
	{
		return null;
	}

	private void DetectAndCollectScrap()
	{
	}

	public void Collect(bool isInstant = false)
	{
	}

	private void OnJumpComplete()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_JumpToTarget_003Ed__24))]
	private IEnumerator CR_JumpToTarget(Transform target, float jumpHeight, float duration, Action OnComplete = null)
	{
		return null;
	}

	private void AddExperience()
	{
	}
}
