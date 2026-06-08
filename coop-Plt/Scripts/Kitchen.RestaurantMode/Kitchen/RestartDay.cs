using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(TimeManagementGroup))]
	[UpdateAfter(typeof(AdvanceTime))]
	public class RestartDay : RestaurantSystem
	{
		private EntityQuery RestartEvents;

		protected override void Initialise()
		{
			base.Initialise();
			RestartEvents = GetEntityQuery(typeof(CRestartDayEvent));
			RequireForUpdate(RestartEvents);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(RestartEvents);
			base.TransitionUtilities.StartTransition(SceneType.LoadFullAutosave);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
