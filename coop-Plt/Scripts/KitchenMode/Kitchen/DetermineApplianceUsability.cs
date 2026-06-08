using Unity.Entities;

namespace Kitchen
{
	public class DetermineApplianceUsability : GameSystemBase
	{
		private EntityQuery ShouldBreak;

		private EntityQuery ShouldFix;

		protected override void Initialise()
		{
			base.Initialise();
			ShouldBreak = GetEntityQuery(new QueryHelper().Any(typeof(CIsOnFire), typeof(CIsBroken)).None(typeof(CPreventUse)));
			ShouldFix = GetEntityQuery(new QueryHelper().Any(typeof(CPreventUse)).None(typeof(CIsOnFire), typeof(CIsBroken)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CPreventUse>(ShouldBreak);
			base.EntityManager.RemoveComponent<CPreventUse>(ShouldFix);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
