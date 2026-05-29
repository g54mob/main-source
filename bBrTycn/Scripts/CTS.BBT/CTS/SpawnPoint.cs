using System;
using CTS.AI;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class SpawnPoint : MonoBehaviour
	{
		[SerializeField]
		private MoveTarget[] _potentialTargets = Array.Empty<MoveTarget>();

		private MoveTarget _self;

		[field: SerializeField]
		[field: Min(0f)]
		public float SpawnRadius { get; private set; } = 3f;

		public static implicit operator MoveTarget(SpawnPoint point)
		{
			return point._self;
		}

		private void Awake()
		{
			_self = GetComponent<MoveTarget>();
		}

		public MoveTarget GetGroupDestination()
		{
			if (_potentialTargets.Length == 0)
			{
				return CTSSingleton<CustomerSpawner>.Instance.GetLeaveTarget();
			}
			return _potentialTargets.GetRandom();
		}
	}
}
