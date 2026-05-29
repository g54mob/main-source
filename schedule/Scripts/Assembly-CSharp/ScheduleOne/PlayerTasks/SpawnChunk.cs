using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Clickable))]
	public class SpawnChunk : Clickable
	{
		private MeshRenderer _meshRenderer;

		private Rigidbody _rb;

		private Collider _collider;

		private bool _isBroken;

		private List<SpawnChunk> _childChunks;

		public UnityEvent OnBreak;

		private bool hasChildChunks => false;

		private void Awake()
		{
		}

		public void EnableChunk(Vector3 force, Vector3 torque)
		{
		}

		public void DisableChunk(bool recursive)
		{
		}

		public void Break()
		{
		}

		public bool GetIsBroken(bool recursive = true)
		{
			return false;
		}

		public override void StartClick(RaycastHit hit)
		{
		}

		public void SetChunkOrder(int i)
		{
		}
	}
}
