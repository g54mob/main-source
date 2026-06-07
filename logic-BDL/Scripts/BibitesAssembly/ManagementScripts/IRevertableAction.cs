namespace ManagementScripts
{
	public interface IRevertableAction
	{
		void Revert();

		void ReDo();
	}
}
