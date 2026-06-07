using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateMove_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BasePlayer _003C_003E4__this;

		public Vector3 pos;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private float _003Clen_003E5__4;

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
		public _003C_AnimateMove_003Ed__16(int _003C_003E1__state)
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

	public static BasePlayer I;

	public GridSpriteObj SpriteObj;

	public CharMetaInst Inst;

	private Vector3 _mousePos;

	private Vector2 _lastAimDir;

	private Vector2 _lastMoveDir;

	private float _aimTheta;

	private CoroutineHandle _moveAnim;

	private bool _isMoving;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetRot(float angle)
	{
	}

	private void MyUpdate()
	{
	}

	private void MoveToAimDir(Vector2 tgtAimDir, float speedMult)
	{
	}

	public Vector3 ClampPlayerPos(Vector3 pos)
	{
		return default(Vector3);
	}

	public void MoveToPos(Vector3 pos)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateMove_003Ed__16))]
	private IEnumerator<float> _AnimateMove(Vector3 pos)
	{
		return null;
	}

	public bool IsMoving()
	{
		return false;
	}

	public void InitChar(CharMetaInst c)
	{
	}

	public void SetPos(Vector3 pos)
	{
	}

	public Vector2 GetAimDir()
	{
		return default(Vector2);
	}

	public void SetLastAimDir(Vector2 dir)
	{
	}
}
