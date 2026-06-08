using Unity.Entities;

namespace Kitchen
{
	public class DestroyAppliancesAtNight : NightSystem
	{
		private EntityQuery DestroyApplianceAtNight;

		protected override void Initialise()
		{
			base.Initialise();
			DestroyApplianceAtNight = GetEntityQuery(typeof(CDestroyApplianceAtNight));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(DestroyApplianceAtNight);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
