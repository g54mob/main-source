using Unity.Entities;

namespace Kitchen
{
	public class ClearUncommittedUpdatesAtNight : GenericSystemBase
	{
		private EntityQuery UncommittedEvents;

		protected override void Initialise()
		{
			base.Initialise();
			UncommittedEvents = GetEntityQuery(typeof(CEventDependsOnGroup));
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SIsNightFirstUpdate>())
			{
				base.EntityManager.DestroyEntity(UncommittedEvents);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
