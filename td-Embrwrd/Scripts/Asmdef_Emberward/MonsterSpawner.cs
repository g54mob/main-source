using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_LerpPathLineAlpha_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterSpawner _003C_003E4__this;

		public float duration;

		public float targetAlpha;

		private float _003CstartAlpha_003E5__2;

		private float _003Ctimer_003E5__3;

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
		public _003CCR_LerpPathLineAlpha_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003CCR_WaitFloodPathPipelineState_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterSpawner _003C_003E4__this;

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
		public _003CCR_WaitFloodPathPipelineState_003Ed__51(int _003C_003E1__state)
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
	private sealed class _003CCR_WaitPlacementFloodPathPipelineState_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterSpawner _003C_003E4__this;

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
		public _003CCR_WaitPlacementFloodPathPipelineState_003Ed__48(int _003C_003E1__state)
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
	private int spawnNodeIndex;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private LineRenderer lineRenderer_Placement;

	[SerializeField]
	private GameObject node_SpawnPosition;

	[SerializeField]
	private Material mat_PathLine_Incoming;

	[SerializeField]
	private Gradient gradient_PathLine_Incoming_Normal;

	[SerializeField]
	private Gradient gradient_PathLine_Incoming_Placement;

	[SerializeField]
	private Material mat_PathLine_Unused;

	[SerializeField]
	private ParticleSystem particle_Portal;

	[SerializeField]
	private float spawnInterval;

	private FloodPath floodPath;

	private FloodPath placementFloodPath;

	private FloodPathTracer path;

	private FloodPathTracer placementPath;

	private float timer;

	private Vector3 endPosition;

	private bool isSpawnInThisWave;

	private bool isInitialized;

	private bool forceTerminateBattle;

	private int errorCount;

	private Coroutine coroutine_SetupPlacementLine;

	public int SpawnNodeIndex => 0;

	public Vector3 SpawnPosition => default(Vector3);

	public Vector3 EndPosition => default(Vector3);

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnRequestChangePathLineAlpha(float targetAlpha, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpPathLineAlpha_003Ed__28))]
	private IEnumerator CR_LerpPathLineAlpha(float targetAlpha, float duration)
	{
		return null;
	}

	private void OnBattleStart()
	{
	}

	private void OnRequestTerminateBattle()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void CopyLineRenderer(LineRenderer source, LineRenderer target)
	{
	}

	private void OnRequestUpdatePlacementPath()
	{
	}

	private void OnSetNextWaveSpawnIndex(int round, List<int> list)
	{
	}

	private void OnRequestSpawnMonster(MonsterSpawnRequest data)
	{
	}

	private void Start()
	{
	}

	private void OnFloodPathUpdated(int spawnIndex)
	{
	}

	public void RecalculatePath()
	{
	}

	public void SetSpawnPoint(Vector3 newPosition)
	{
	}

	private void OnPathComplete(Path path)
	{
	}

	private void SetupPathLine(Path p)
	{
	}

	private void SetupPlacementLine(Path p)
	{
	}

	private void OnGraphUpdated()
	{
	}

	private void CalculatePlacementFloodPath(Vector3 targetPos)
	{
	}

	private void OnPlacementFloodPathReady(Path path)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WaitPlacementFloodPathPipelineState_003Ed__48))]
	private IEnumerator CR_WaitPlacementFloodPathPipelineState()
	{
		return null;
	}

	private void CalculateFloodPath(Vector3 targetPos)
	{
	}

	private void OnFloodPathReady(Path path)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WaitFloodPathPipelineState_003Ed__51))]
	private IEnumerator CR_WaitFloodPathPipelineState()
	{
		return null;
	}

	public bool IsFloodPathReady()
	{
		return false;
	}

	public bool IsPlacementFloodPathReady()
	{
		return false;
	}

	public FloodPathTracer GetFloodPathTracer(Vector3 startPos, OnPathDelegate callback)
	{
		return null;
	}

	public bool CheckPathBlockedByObject(List<Collider> list_Colliders, bool alwaysRevert = false, bool updatePlacementPath = true)
	{
		return false;
	}

	public bool CheckPathBlockedByObject(List<Collider> list_Colliders, Vector3 startPos, Vector3 endPos, bool alwaysRevert = false, bool updatePlacementPath = true)
	{
		return false;
	}

	public void CalculatePlacementFloodPathTracer(Vector3 startPos, Vector3 endPos, FloodPath floodPath)
	{
	}

	private void OnPlacementFloodPathTracerReady(Path path)
	{
	}

	public AMonsterBase Spawn(eMonsterType type, bool isHaveTreasure, bool isCorrupted)
	{
		return null;
	}

	public List<Vector3> GetAllPathPoints()
	{
		return null;
	}

	public int GetPathPointsCount()
	{
		return 0;
	}

	public bool IsPathReady()
	{
		return false;
	}

	public bool isPointOnPathPoint(Vector3 pos)
	{
		return false;
	}

	public (bool, Vector3) GetPathPointAfterXBlock(Vector3 pos, int i)
	{
		return default((bool, Vector3));
	}

	public (bool, Vector3) GetPathPointBeforeXBlock(Vector3 pos, int i)
	{
		return default((bool, Vector3));
	}

	public Vector3 GetNearestPathPoint(Vector3 pos)
	{
		return default(Vector3);
	}

	public void TogglePortalParticle(bool isOn)
	{
	}
}
