using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerAssignmentGroup), OrderFirst = true)]
	public class ClearAssignments : GameSystemBase
	{
		private EntityQuery Assignments;

		protected override void Initialise()
		{
			base.Initialise();
			Assignments = GetEntityQuery(new QueryHelper().Any(typeof(CAvailableAssignment), typeof(CWaitingGroup)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Assignments);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
