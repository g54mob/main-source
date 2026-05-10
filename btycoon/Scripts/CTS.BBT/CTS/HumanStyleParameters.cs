using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "HumanStyle", menuName = "BBT/Influence/Human Style")]
	public class HumanStyleParameters : ScriptableObject
	{
		public enum ELockState
		{
			Locked = 0,
			EditorNDebugBuild = 1,
			EditorNBuild = 2
		}

		[field: SerializeField]
		public bool IncludeInBuildDemo { get; private set; } = true;

		[field: SerializeField]
		public ELockState LockState { get; private set; }

		[field: SerializeField]
		[field: UniqueFlag(true)]
		public ESubSpecies HumanType { get; private set; }

		[field: SerializeField]
		public SerializableDictionary<ESubSpecies, float> VampireRepartition { get; private set; } = new SerializableDictionary<ESubSpecies, float>();

		public bool IsUnlocked
		{
			get
			{
				if (LockState == ELockState.EditorNBuild)
				{
					return true;
				}
				return false;
			}
		}

		public ESubSpecies SelectCustomerType()
		{
			return VampireRepartition.DrawWeightedRandom();
		}
	}
}
