using System;

[Serializable]
public class ProjectRequirementList : PolymorphicPropertyDrawerList<ProjectRequirementBase>
{
	public bool ReturnCanRun(Project project, Agent agent)
	{
		foreach (ProjectRequirementBase item in List)
		{
			if (!item.EvaluateCanRun(project, agent))
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnCanFinish(Project project)
	{
		foreach (ProjectRequirementBase item in List)
		{
			if (!item.EvaluateCanFinish(project))
			{
				return false;
			}
		}
		return true;
	}
}
