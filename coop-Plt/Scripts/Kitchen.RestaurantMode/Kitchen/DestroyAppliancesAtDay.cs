using Unity.Entities;

namespace Kitchen
{
	public class DestroyAppliancesAtDay : StartOfDaySystem
	{
		private EntityQuery Appliances;

		protected override void Initialise()
		{
			base.Initialise();
			Appliances = GetEntityQuery(typeof(CDestroyApplianceAtDay));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Appliances);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
