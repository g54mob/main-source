using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "WorkerCharacteristicsData", menuName = "Worker/WorkerCharacteristicsData")]
	public class WorkerCharacteristicsData : ScriptableObject
	{
		[field: SerializeField]
		public List<EAgentStatistics> CharacteristicsStatistics { get; private set; } = new List<EAgentStatistics>();

		[field: SerializeField]
		public SerializableDictionary<EWorkerType, float> WorkerTypesWeights { get; private set; } = new SerializableDictionary<EWorkerType, float>();

		[field: SerializeField]
		public SerializableDictionary<EAgentStatistics, float> SpecializedStatWeights { get; private set; } = new SerializableDictionary<EAgentStatistics, float>();

		[field: SerializeField]
		public int BaseCharacteristicsValue { get; private set; } = 100;

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Specialist")]
		public Vector2Int SpecialistLevel1PointsToDistribute { get; private set; } = new Vector2Int(10, 10);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Specialist")]
		public Vector2Int SpecialistLevel1GainRange { get; private set; } = new Vector2Int(0, 10);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Specialist")]
		public Vector2Int SpecialistLevelUpPointsToDistribute { get; private set; } = new Vector2Int(3, 5);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Specialist")]
		public Vector2Int SpecialistLevelUpGainRange { get; private set; } = new Vector2Int(0, 4);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Generalist")]
		public Vector2Int GeneralistLevel1PointsToDistribute { get; private set; } = new Vector2Int(7, 9);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Generalist")]
		public Vector2Int GeneralistLevel1GainRange { get; private set; } = new Vector2Int(1, 4);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Generalist")]
		public Vector2Int GeneralistLevelUpPointsToDistribute { get; private set; } = new Vector2Int(7, 9);

		[field: SerializeField]
		[field: MinMaxSlider(0f, 100f)]
		[field: BoxGroup("Generalist")]
		public Vector2Int GeneralistLevelUpGainRange { get; private set; } = new Vector2Int(1, 4);
	}
}
