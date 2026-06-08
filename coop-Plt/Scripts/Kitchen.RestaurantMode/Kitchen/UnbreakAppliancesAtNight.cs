using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ApplianceProcessReactionGroup))]
	public class UnbreakAppliancesAtNight : NightSystem
	{
		private EntityQuery ClearQuery;

		private EntityQuery ClearQueryFire;

		protected override void Initialise()
		{
			base.Initialise();
			ClearQuery = GetEntityQuery(new QueryHelper().All(typeof(CIsBroken), typeof(CAppliance)).None(typeof(CPermanentlyBroken)));
			ClearQueryFire = GetEntityQuery(typeof(CIsOnFire), typeof(CAppliance));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CIsBroken>(ClearQuery);
			base.EntityManager.RemoveComponent<CIsOnFire>(ClearQueryFire);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
