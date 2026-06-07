public abstract class ProjectRequirementBase : PolymorphicPropertyDrawerListItem
{
	public abstract ProjectBlocker Blocker { get; }

	public abstract bool EvaluateCanRun(Project project, Agent agent);

	public virtual bool EvaluateCanFinish(Project project)
	{
		return true;
	}

	protected abstract override void OnGUI();
}
