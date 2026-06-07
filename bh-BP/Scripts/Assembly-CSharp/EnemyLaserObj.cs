using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class EnemyLaserObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__13 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public EnemyLaserObj _003C_003E4__this;

		public int dmg;

		public float previewLen;

		public Transform startXfm;

		private float _003ChitTime_003E5__2;

		private TurnBasedState _003CstartingState_003E5__3;

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
		public _003C_Run_003Ed__13(int _003C_003E1__state)
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

	public LaserWarnFX DangerViz;

	public PartSys LoadParticles;

	public LineFXType LaserType;

	public float Length;

	public float Width;

	public Vector3 AimDir;

	private GridPieceObj _shooter;

	private Transform _shootXfm;

	public int Dmg;

	private CoroutineHandle _curAnim;

	public void RefreshPlacement()
	{
	}

	public void SetAimDir(Vector3 aimDir)
	{
	}

	public void Init(LineFXType laserType, GridPieceObj shooter, Transform startXfm, Vector3 aimDir, float previewLen, float width, int dmg)
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__13))]
	private IEnumerator<float> _Run(float previewLen, Transform startXfm, int dmg)
	{
		return null;
	}

	public void CancelAndRemove()
	{
	}

	public Transform GetShootXfm()
	{
		return null;
	}
}
