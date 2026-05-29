using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects
{
	[CreateAssetMenu(fileName = "Shrinking", menuName = "Properties/Shrinking Property")]
	public class Shrinking : Effect
	{
		public const float Scale = 0.8f;

		public const float LerpTime = 1f;

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
