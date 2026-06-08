using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(AddNewViews))]
	[UpdateInGroup(typeof(ViewSystemsGroup))]
	public class CleanEvents : GenericSystemBase
	{
		private EntityQuery ViewedEvents;

		protected override void Initialise()
		{
			ViewedEvents = GetEntityQuery(new QueryHelper().Any(typeof(CSoundEvent), typeof(CAchievementUnlockEvent)).All(typeof(CLinkedView)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(ViewedEvents);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
