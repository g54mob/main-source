using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerAssignmentGroup))]
	public abstract class WaitingGroupSystem : GenericSystemBase, IWaitingGroupSystem
	{
		protected void NewGroup(CWaitingGroup assignment)
		{
			assignment.System = this;
			Entity entity = base.EntityManager.CreateEntity(typeof(CWaitingGroup));
			base.EntityManager.SetComponentData(entity, assignment);
		}

		public virtual void Accept(CAvailableAssignment assignment, CWaitingGroup group, EntityContext ctx)
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
