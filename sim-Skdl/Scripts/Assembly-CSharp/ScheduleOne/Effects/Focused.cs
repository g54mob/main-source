using ScheduleOne.Employees;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects
{
	[CreateAssetMenu(fileName = "Focused", menuName = "Properties/Focused Property")]
	public class Focused : Effect
	{
		public const float WorkSpeedMultiplier = 1.3f;

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

		protected override void ApplyToEmployee(Employee employee)
		{
		}

		protected override void ClearFromEmployee(Employee employee)
		{
		}
	}
}
