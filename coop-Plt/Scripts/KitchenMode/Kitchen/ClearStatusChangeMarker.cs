using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ApplyStateChangeEffectsGroup), OrderLast = true)]
	public class ClearStatusChangeMarker : GameSystemBase
	{
		private EntityQuery ClearQuery;

		protected override void Initialise()
		{
			base.Initialise();
			ClearQuery = GetEntityQuery(typeof(CGroupStateChanged));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CGroupStateChanged>(ClearQuery);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
