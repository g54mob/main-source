using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public static class EffectExtensions
	{
		public static void Apply(this StartBonusEffect effect, EntityContext ctx)
		{
			if (effect.Appliance != null)
			{
				Entity entity = ctx.CreateEntity();
				ctx.Set(entity, new CGrantsExtraBlueprint
				{
					ID = effect.Appliance.ID,
					IsFree = true
				});
				ctx.Add<CDestroyAfterUsage>(entity);
			}
			if (effect.Money != 0)
			{
				SMoney data = ctx.Get<SMoney>();
				data.Amount += effect.Money;
				ctx.Set(data);
			}
		}
	}
}
