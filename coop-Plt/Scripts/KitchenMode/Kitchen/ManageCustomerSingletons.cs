using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCreateGroup))]
	public class ManageCustomerSingletons : GameSystemBase
	{
		protected override void OnUpdate()
		{
			if (!HasSingleton<SQueueMarker>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SQueueMarker), typeof(CPatience));
				base.EntityManager.AddBuffer<CQueue>(entity);
				base.EntityManager.AddBuffer<CAffectedBy>(entity);
			}
			if (!HasSingleton<SLargestTableSize>())
			{
				base.EntityManager.CreateEntity(typeof(SLargestTableSize));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
