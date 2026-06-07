using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Hunter Raid Data")]
	public class HunterRaidData : ScriptableObject
	{
		[field: SerializeField]
		[field: MinMaxSlider(5f, 500f)]
		public Vector2 DurationRange { get; private set; } = new Vector2(60f, 60f);

		[field: SerializeField]
		[field: MinMaxSlider(1f, 20f)]
		public Vector2Int HunterCount { get; private set; } = new Vector2Int(3, 6);

		[field: SerializeField]
		[field: Range(0f, 100f)]
		public int VigilanceLossWhenRaidFinished { get; private set; } = 25;
	}
}
