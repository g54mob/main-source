using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using UnityEngine;

public class BaseCharObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseCharObj _003C_003E4__this;

		public BuildingObj home;

		private Vector3 _003CtgtPos_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private float _003Clen_003E5__4;

		private float _003CstartTime_003E5__5;

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
		public _003C_AnimateEntry_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_RunWander_003Ed__25 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseCharObj _003C_003E4__this;

		private bool _003CisBase_003E5__2;

		private float _003CstartTime_003E5__3;

		private Vector3 _003CstartPos_003E5__4;

		private Vector3 _003CtgtPos_003E5__5;

		private float _003Clen_003E5__6;

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
		public _003C_RunWander_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003C_WalkToPos_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseCharObj _003C_003E4__this;

		public Vector3 pos;

		public float speed;

		public BaseCharState endState;

		private Vector3 _003CstartPos_003E5__2;

		private float _003Clen_003E5__3;

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
		public _003C_WalkToPos_003Ed__28(int _003C_003E1__state)
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

	public GridSpriteObj SpriteObj;

	public BaseCharState CurState;

	public CharMetaInst Inst;

	private CharInfo _tgtInf;

	public MeshRenderer RendAura;

	public TrailRenderer TrailAura;

	public PrincipleDir PrincipleFaceDir;

	public bool IsWalking;

	private float _walkSpeed;

	private Vector3 _tgtPos;

	private int _curAura;

	private CoroutineHandle _curRoutine;

	private EventInstance _footstepInst;

	public void Init(CharType ct)
	{
	}

	public void Init(CharMetaInst c)
	{
	}

	public void Reset()
	{
	}

	public void SetState(BaseCharState st, bool force = false)
	{
	}

	public void SetFaceDir(CardinalDir dir)
	{
	}

	public void SetFaceDir(PrincipleDir dir)
	{
	}

	public void SetAimDir(float angle)
	{
	}

	public void SetAimDir(Vector2 aimDir)
	{
	}

	public void SetWalking(bool isWalking, float walkSpeed = 1f)
	{
	}

	public void RefreshSprite()
	{
	}

	public void SetPos(Vector3 pos)
	{
	}

	public void ResetRot()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunWander_003Ed__25))]
	private IEnumerator<float> _RunWander()
	{
		return null;
	}

	public void SnapToTgtPos(BaseCharState endState)
	{
	}

	public void WalkToPos(Vector3 pos, BaseCharState endState, float speed = 0.8f)
	{
	}

	[IteratorStateMachine(typeof(_003C_WalkToPos_003Ed__28))]
	public IEnumerator<float> _WalkToPos(Vector3 pos, BaseCharState endState, float speed = 0.8f)
	{
		return null;
	}

	private void OnLookRotChanged()
	{
	}

	public void AnimateEntry(BuildingObj home)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__31))]
	private IEnumerator<float> _AnimateEntry(BuildingObj home)
	{
		return null;
	}

	public void ActivateAura(int idx)
	{
	}

	public void ClearAura()
	{
	}
}
