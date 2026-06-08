using KitchenData;

namespace Kitchen
{
	public class AutoGrowGroupSizes : StartOfNightSystem
	{
		protected override void OnUpdate()
		{
			if (Require<SKitchenParameters>(out var comp))
			{
				int day = GetOrDefault<SDay>().Day;
				if (HasStatus(RestaurantStatus.AutumnGroupSizesGroup) && ((day <= 15 && day % 3 == 0) || (day > 15 && (day - 15) % 10 == 0)))
				{
					comp.Parameters.MinimumGroupSize++;
					comp.Parameters.MaximumGroupSize++;
					Set(comp);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
