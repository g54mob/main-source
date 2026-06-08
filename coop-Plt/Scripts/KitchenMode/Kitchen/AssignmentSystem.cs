using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerAssignmentGroup))]
	public abstract class AssignmentSystem : GenericSystemBase, IAssignmentSystem
	{
		protected void NewAssignment(CAvailableAssignment assignment)
		{
			assignment.System = this;
			Entity entity = base.EntityManager.CreateEntity(typeof(CAvailableAssignment));
			base.EntityManager.SetComponentData(entity, assignment);
		}

		public abstract void Accept(CAvailableAssignment assignment, CWaitingGroup group, EntityContext ctx);

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
