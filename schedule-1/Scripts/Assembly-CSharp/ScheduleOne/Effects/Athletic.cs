using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects
{
	[CreateAssetMenu(fileName = "Athletic", menuName = "Properties/Athletic Property")]
	public class Athletic : Effect
	{
		public const float SPEED_MULTIPLIER = 1.3f;

		public const float NPC_SPEED_MULTIPLIER = 1.8f;

		[SerializeField]
		[ColorUsage(true, true)]
		public Color TintColor;

		public override void ApplyToNPC(NPC npc)
		{
		}

		public override void ApplyToPlayer(Player player)
		{
		}

		public override void ClearFromNPC(NPC npc)
		{
		}

		public override void ClearFromPlayer(Player player)
		{
		}
	}
}
