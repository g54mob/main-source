using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class CannonballObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RunCannonball_003Ed__7 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public CannonballObj _003C_003E4__this;

		public Vector3 tgtPos;

		public float radius;

		public Vector3 srcPos;

		public float previewLen;

		public int dmg;

		private RangeViz _003CrViz_003E5__2;

		private Vector3 _003CrisePos_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003ChitTime_003E5__5;

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
		public _003C_RunCannonball_003Ed__7(int _003C_003E1__state)
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

	public CannonballType Type;

	[NamedArray(typeof(CannonballType))]
	public Transform[] CannonballWrappers;

	public GameObject BallObj;

	private CoroutineHandle _curAnim;

	private const float kRiseTime = 0.75f;

	private const float kFallTime = 0.5f;

	public void Run(CannonballType type, Vector3 srcPos, Vector3 tgtPos, float previewLen, float radius, int dmg)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunCannonball_003Ed__7))]
	private IEnumerator<float> _RunCannonball(Vector3 srcPos, Vector3 tgtPos, float previewLen, float radius, int dmg)
	{
		return null;
	}
}
