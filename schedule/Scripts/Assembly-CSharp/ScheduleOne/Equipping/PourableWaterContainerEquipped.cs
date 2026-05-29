using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.Equipping
{
	public class PourableWaterContainerEquipped : Equippable_Pourable
	{
		[SerializeField]
		private WaterContainerVisualizer _visuals;

		[SerializeField]
		private WaterContainerPourable _pourablePrefab;

		private WaterContainerInstance _waterContainerInstance;

		public override void Equip(ItemInstance item)
		{
		}

		public override void Unequip()
		{
		}

		protected override bool CanPour(GrowContainer growContainer, out string reason)
		{
			reason = null;
			return false;
		}

		protected override void StartPourTask(GrowContainer growContainer)
		{
		}
	}
}
