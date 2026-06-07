using CTS.BBT.AI;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public abstract class AgentSpawn<TAgent> : MonoBehaviour, IGive<Agent> where TAgent : Agent
	{
		protected enum EGender
		{
			Woman = 0,
			Man = 1
		}

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		protected bool _autoSpawn = true;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		protected bool _spawnSpecificGender;

		[SerializeField]
		[ShowIf(EConditionOperator.And, new string[] { "IsSpawningAllowed", "_spawnSpecificGender" })]
		protected EGender _gender;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		protected bool _startPaused;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		protected bool _startNeedsPaused;

		protected virtual Color GizmoColor { get; } = Color.blue;

		public TAgent SpawnedAgent { get; set; }

		protected abstract bool IsSpawningAllowed();

		private void Start()
		{
			if (_autoSpawn)
			{
				DoSpawn();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public TAgent Spawn()
		{
			return DoSpawn();
		}

		private TAgent DoSpawn()
		{
			if ((bool)SpawnedAgent)
			{
				return SpawnedAgent;
			}
			if (!IsSpawningAllowed())
			{
				return null;
			}
			SpawnedAgent = SpawnAgent();
			SpawnedAgent.Statistics.Paused = _startNeedsPaused;
			return SpawnedAgent;
		}

		protected abstract TAgent SpawnAgent();

		protected TAgent GetSpawned()
		{
			if ((bool)SpawnedAgent)
			{
				return SpawnedAgent;
			}
			Spawn();
			return SpawnedAgent;
		}

		Agent IGive<Agent>.Get()
		{
			return GetSpawned();
		}

		private void OnDrawGizmos()
		{
			_ = base.transform.position + Vector3.up;
		}
	}
}
