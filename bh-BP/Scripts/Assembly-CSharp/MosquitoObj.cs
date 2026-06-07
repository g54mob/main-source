using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class MosquitoObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__10 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MosquitoObj _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CtgtPos_003E5__4;

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
		public _003C_Run_003Ed__10(int _003C_003E1__state)
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

	public MosquitoType Type;

	[NamedArray(typeof(MosquitoType))]
	public GameObject[] WrapperViz;

	private Vector2 _moveDir;

	private HeroInst _parent;

	private GridPieceObj _tgt;

	private int _dmg;

	private CoroutineHandle _curAnim;

	private const float kSpeed = 5f;

	public void Init(MosquitoType t, HeroInst p, Vector3 pos)
	{
	}

	public void FindTarget()
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__10))]
	private IEnumerator<float> _Run()
	{
		return null;
	}

	public void Cancel()
	{
	}
}
