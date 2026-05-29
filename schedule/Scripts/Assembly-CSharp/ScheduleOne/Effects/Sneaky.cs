using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.Effects
{
	[CreateAssetMenu(fileName = "Sneaky", menuName = "Properties/Sneaky Property")]
	public class Sneaky : Effect
	{
		public const float SPEED_MULTIPLIER = 0.85f;

		public const float FOOTSTEP_VOL_MULTIPLIER = 0.4f;

		private VisibilityAttribute visibilityAttribute;

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
