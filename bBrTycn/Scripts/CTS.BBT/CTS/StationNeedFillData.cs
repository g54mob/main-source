using CTS.BBT;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Furnitures/Station Need Filler Data")]
	public class StationNeedFillData : SimpleStationData
	{
		[field: SerializeField]
		public EAgentStatistics Stat { get; private set; }

		[field: SerializeField]
		[field: MinMaxSlider(0f, 1f)]
		public Vector2 ValueIncrease { get; private set; } = Vector2.up;

		[field: SerializeField]
		public AudioAsset PossibleSounds { get; private set; }

		[field: SerializeField]
		public AnimKey[] PossibleAnimations { get; private set; }
	}
}
