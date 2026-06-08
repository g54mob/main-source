using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class AcceptExp : InteractionSystem
	{
		private int NewGrantAmount;

		private CExpGrantAppliance Grant;

		private EntityQuery Grants;

		private EntityQuery _SingletonEntityQuery_SEndgameStats_17;

		protected override void Initialise()
		{
			Grants = GetEntityQuery(typeof(CExpGrant));
		}

		protected override bool BeforeRun()
		{
			base.BeforeRun();
			if (HasSingleton<SEndgameStats>())
			{
				return false;
			}
			NewGrantAmount = 0;
			return true;
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			return Require<CExpGrantAppliance>(data.Target, out Grant);
		}

		protected override void Perform(ref InteractionData data)
		{
			NewGrantAmount += Grant.Amount;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			if (NewGrantAmount <= 0)
			{
				return;
			}
			base.EntityManager.CreateEntity(typeof(SEndgameStats), typeof(CSceneChangeData), typeof(CEndgameUnlock));
			_SingletonEntityQuery_SEndgameStats_17.SetSingleton(new SEndgameStats
			{
				ExpGrant = NewGrantAmount,
				IsExpGrant = true
			});
			StartSceneTransition(SceneType.Postgame);
			foreach (Entity item in Grants.ToEntityArray(Allocator.Temp))
			{
				CExpGrant component = GetComponent<CExpGrant>(item);
				component.IsGranted = true;
				base.EntityManager.SetComponentData(item, component);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_17 = GetEntityQuery(ComponentType.ReadWrite<SEndgameStats>());
		}
	}
}
