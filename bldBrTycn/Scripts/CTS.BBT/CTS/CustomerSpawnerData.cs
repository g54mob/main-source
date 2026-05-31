using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Customer Spawner Data", menuName = "BBT/Data/Customer Spawner Data")]
	public class CustomerSpawnerData : ScriptableObject
	{
		[field: SerializeField]
		[field: Range(1f, 6f)]
		public int MaxGroupSize { get; private set; } = 4;

		[field: SerializeField]
		[field: CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		public AnimationCurve GroupSizeRandomCurve { get; private set; } = AnimationCurve.Linear(0f, 0f, 1f, 1f);
	}
}
