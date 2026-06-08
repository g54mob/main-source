namespace Kitchen
{
	public interface IAssignmentSystem
	{
		void Accept(CAvailableAssignment assignment, CWaitingGroup group, EntityContext ctx);
	}
}
