using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_GrabEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_GrabMonster_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_GrabEffect _003C_003E4__this;

		public AMonsterBase target;

		public LineRenderer line;

		public float height;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private Vector3 _003CstartPos_003E5__4;

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
		public _003CCR_GrabMonster_003Ed__8(int _003C_003E1__state)
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
	private sealed class _003CCR_GrabMonsters_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_GrabEffect _003C_003E4__this;

		public List<AMonsterBase> list_Monsters;

		public float maxDist;

		private int _003Ci_003E5__2;

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
		public _003CCR_GrabMonsters_003Ed__7(int _003C_003E1__state)
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
	private List<LineRenderer> list_LineRenderers;

	[SerializeField]
	private ParticleSystem particle_GrabEffect;

	[SerializeField]
	private float grabDuration;

	[SerializeField]
	private float grabHeight;

	[SerializeField]
	private int lineSegmentCount;

	private bool isGrabbing;

	private Vector3 linePos;

	public void GrabMonsters(List<AMonsterBase> list_Monsters, float maxDist)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_GrabMonsters_003Ed__7))]
	private IEnumerator CR_GrabMonsters(List<AMonsterBase> list_Monsters, float maxDist)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GrabMonster_003Ed__8))]
	private IEnumerator CR_GrabMonster(AMonsterBase target, LineRenderer line, float height)
	{
		return null;
	}

	private void UpdateLine(LineRenderer line, Vector3 start, Vector3 end)
	{
	}

	private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
	{
		return default(Vector3);
	}
}
