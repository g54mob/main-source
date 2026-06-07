using System;
using System.Text;

namespace Gh.Tk
{
	public class DogsbodySkill : StaffSkill
	{
		protected DogsbodySkill()
		{
		}

		public DogsbodySkill(Staff owner)
		{
		}

		public override void Init()
		{
		}

		protected override void AppendEffectDetailsForTooltip(StringBuilder sb)
		{
		}

		public float GetMaintainingSpeedFactor()
		{
			return 0f;
		}

		public float GetRepairSpeedFactor()
		{
			return 0f;
		}

		private void Inventory_InventoryChanged(object sender, EventArgs e)
		{
		}

		private void UpdateMovementSpeed()
		{
		}

		public override void OnRemoving()
		{
		}

		protected override void AppendUniformBonusDetails(StringBuilder sb, bool isWearingUniform)
		{
		}
	}
}
