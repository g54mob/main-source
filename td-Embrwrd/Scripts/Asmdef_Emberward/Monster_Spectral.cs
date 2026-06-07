using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_Spectral : Monster_Basic
{
	protected class PositionRecord
	{
		public Vector3 position;

		public Quaternion rotation;

		public float time;

		public PositionRecord(Transform transform, float time)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_Spectral _003C_003E4__this;

		private PositionRecord _003Crecord_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003Cduration_003E5__4;

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
		public _003CCR_Cast_003Ed__14(int _003C_003E1__state)
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
	private float skillCooldown;

	[SerializeField]
	private ParticleSystem particle_Teleport;

	[SerializeField]
	private LineRenderer lineRenderer;

	private float skillCooldownTimer;

	private float recordPositionInterval;

	private float recordPositionTimer;

	private List<PositionRecord> list_PositionRecords;

	private Coroutine coroutine_Skill;

	private List<Vector3> list_LinePoints;

	private Vector3 linePos;

	private int lineSegmentCount;

	protected override void SpawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	protected override void DespawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__14))]
	private IEnumerator CR_Cast()
	{
		return null;
	}

	private void UpdateLine(LineRenderer line, Vector3 start, Vector3 end)
	{
	}

	private void SetLinePoints(List<Vector3> points, int start, int end)
	{
	}
}
