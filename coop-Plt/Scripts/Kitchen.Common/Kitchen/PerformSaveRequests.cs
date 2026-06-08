using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
	[UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
	public class PerformSaveRequests : GenericSystemBase
	{
		private EntityQuery SaveRequests;

		private EntityQuery SaveBlockers;

		protected override void Initialise()
		{
			base.Initialise();
			SaveRequests = GetEntityQuery(typeof(CRequestSave));
			SaveBlockers = GetEntityQuery(new QueryHelper().Any(typeof(SPerformSceneTransition), typeof(CSceneFirstFrame)));
			RequireForUpdate(SaveRequests);
		}

		protected override void OnUpdate()
		{
			if (SaveBlockers.IsEmpty)
			{
				base.EntityManager.AddComponent<CDoNotPersist>(SaveRequests);
				Entity entity = SaveRequests.First();
				CRequestSave cRequestSave = SaveRequests.First<CRequestSave>();
				EntityContext entityContext = new EntityContext(base.World.EntityManager);
				switch (cRequestSave.SaveType)
				{
				case SaveType.Auto:
					Persistence.Progress.Save(base.World.EntityManager);
					break;
				case SaveType.AutoFull:
					Persistence.FullWorld.Save(base.World.EntityManager, entityContext.Get<SSelectedLocation>().Selected.Slot);
					break;
				}
				base.EntityManager.DestroyEntity(entity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
