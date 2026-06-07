using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPCTrafficManager : NoktaSingleton<NPCTrafficManager>
{
	[CompilerGenerated]
	private sealed class _003CNPCGeneration_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NPCTrafficManager _003C_003E4__this;

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
		public _003CNPCGeneration_003Ed__18(int _003C_003E1__state)
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

	[Header("Components")]
	[SerializeField]
	private WaypointNavigator[] m_NPCPrefabs;

	[SerializeField]
	private GameObject m_BuildingEnterencesRoot;

	[Header("Settings")]
	[SerializeField]
	private Vector2 m_SpeedRange;

	[SerializeField]
	private AnimationCurve m_DailySpawnRate;

	[SerializeField]
	private Vector2Int m_TripLengthRange;

	[SerializeField]
	private Transform m_PlayerTransform;

	[SerializeField]
	private float m_MaxSpawnDistance;

	[SerializeField]
	private float m_MaxVisibilityDistance;

	[SerializeField]
	private int m_MaxNPCCount;

	private BuildingEnterence[] m_BuildingEnterences;

	private List<WaypointNavigator> m_ActiveNPCs;

	private float m_WaitBeforeSpawningNextNPC => 0f;

	public List<WaypointNavigator> ActiveNPCs => null;

	private void Start()
	{
	}

	public void RemoveNpc(WaypointNavigator npc)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CNPCGeneration_003Ed__18))]
	private IEnumerator NPCGeneration()
	{
		return null;
	}

	private void SpawnNpc()
	{
	}
}
