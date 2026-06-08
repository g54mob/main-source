namespace Kitchen
{
	public interface IWaitingGroupSystem
	{
		void Accept(CAvailableAssignment assignment, CWaitingGroup group, EntityContext ctx);
	}
}
