using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientFireSpreadBullet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_Fly_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientFireSpreadBullet _003C_003E4__this;

		private float _003Ctime_003E5__2;

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
		public _003CCR_Fly_003Ed__8(int _003C_003E1__state)
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
	private GameObject corruptTilePrefab;

	[SerializeField]
	private ParticleSystem particle_Flame;

	private Vector3 startPosition;

	private Vector3Int targetPosition;

	private float flyTime;

	private float height;

	private Vector3 lastUpdatePosition;

	public void Setup(Vector3 startPosition, Vector3Int targetPosition, float speed, float height)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Fly_003Ed__8))]
	private IEnumerator CR_Fly()
	{
		return null;
	}

	public void CreateCorruptTile()
	{
	}
}
