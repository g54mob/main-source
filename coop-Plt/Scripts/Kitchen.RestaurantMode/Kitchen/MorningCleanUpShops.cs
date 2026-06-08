using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(DestructionGroup))]
	public class MorningCleanUpShops : DaySystem
	{
		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(CShopEntity)));
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(CForSale)));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
