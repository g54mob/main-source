using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(ApplianceProcessReactionGroup), OrderLast = true)]
	public class ClearProcessComplete : GameSystemBase
	{
		private EntityQuery ClearQuery;

		protected override void Initialise()
		{
			base.Initialise();
			ClearQuery = GetEntityQuery(typeof(CCompletedProcess));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CCompletedProcess>(ClearQuery);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
