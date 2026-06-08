using Unity.Entities;

namespace Kitchen
{
	public class LockScrapper : GenericSystemBase
	{
		private EntityQuery Scrappers;

		protected override void Initialise()
		{
			base.Initialise();
			Scrappers = GetEntityQuery(typeof(CFranchiseScrapper));
		}

		protected override void OnUpdate()
		{
			if (Require<SFranchiseSelector>(out var comp))
			{
				if (Has<CFranchiseItem>(comp.SelectedFranchise))
				{
					base.EntityManager.RemoveComponent<CPreventUse>(Scrappers);
				}
				else
				{
					base.EntityManager.AddComponent<CPreventUse>(Scrappers);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
