public interface IBlockingProjectProvider
{
	bool TryReturnBlockingProject(out Project blockingProject, Agent agent);
}
