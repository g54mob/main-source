using System;
using SaintsField.Animate;
using UnityEngine;

namespace SaintsField
{
	[Serializable]
	public class AnimatorStateBase : ILayerIndex, IStateNameHash, IStateName, IStateSpeed, IStateTag, ISubStateMachineNameChain
	{
		[field: SerializeField]
		public int layerIndex { get; private set; }

		[field: SerializeField]
		public int stateNameHash { get; private set; }

		[field: SerializeField]
		public string stateName { get; private set; }

		[field: SerializeField]
		public float stateSpeed { get; private set; }

		[field: SerializeField]
		public string stateTag { get; private set; }

		[field: SerializeField]
		public string[] subStateMachineNameChain { get; private set; }

		public override string ToString()
		{
			return $"[{layerIndex}] {stateName}";
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return Equals((AnimatorState)obj);
		}

		public bool Equals(AnimatorState other)
		{
			if (layerIndex == other.layerIndex)
			{
				return stateNameHash == other.stateNameHash;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (layerIndex * 397) ^ stateNameHash;
		}
	}
}
