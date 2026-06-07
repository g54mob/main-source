using System.Text;

namespace Gh.Tk
{
	public class ServerSkill : StaffSkill
	{
		protected ServerSkill()
		{
		}

		public ServerSkill(Staff owner)
		{
		}

		public void ApplyServeBonus(Ingredient itemToServe)
		{
		}

		public bool CanTakeMultipleOrders()
		{
			return false;
		}

		private int GetServeBonusInPercent()
		{
			return 0;
		}

		private (float, float) GetSatisfactionRangeForTier(int tier)
		{
			return default((float, float));
		}

		public int GetPatronServiceSatisfaction()
		{
			return 0;
		}

		protected override void AppendEffectDetailsForTooltip(StringBuilder sb)
		{
		}

		protected override void AppendUniformBonusDetails(StringBuilder sb, bool isWearingUniform)
		{
		}
	}
}
