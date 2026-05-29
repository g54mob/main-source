using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects
{
	[CreateAssetMenu(fileName = "Glowie", menuName = "Properties/Glowie Property")]
	public class Glowie : Effect
	{
		[SerializeField]
		[ColorUsage(true, true)]
		public Color GlowColor;

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
