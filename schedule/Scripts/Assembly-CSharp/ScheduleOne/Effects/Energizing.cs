using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects
{
	[CreateAssetMenu(fileName = "Energizing", menuName = "Properties/Energizing Property")]
	public class Energizing : Effect
	{
		public const float SPEED_MULTIPLIER = 1.15f;

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
