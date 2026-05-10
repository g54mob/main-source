using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "WorkerPassivesData", menuName = "Worker/WorkerPassivesData")]
	public class WorkerPassivesData : ScriptableObject
	{
		[field: SerializeField]
		[field: MinMaxSlider(0f, 5f)]
		public Vector2Int PassivesAmountRange { get; private set; } = new Vector2Int(1, 2);

		[field: SerializeField]
		public SerializableDictionary<GroupedStatisticBonusFactory, float> PassivesGroupsWeight { get; private set; } = new SerializableDictionary<GroupedStatisticBonusFactory, float>();
	}
}
