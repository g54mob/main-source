using System.Collections;

public class LearnAtSchool : TaskBase
{
	public override TaskType Type => TaskType.LearnAtSchool;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (TryReturnTargetBuildableExtendable<School>(project, out var school) && school.StartStudying(agent))
		{
			while (TimeManager.ReturnIsDayTime() && school.Study(agent))
			{
				yield return null;
			}
			school.StopStudying(agent);
		}
	}

	public override void Stop()
	{
		if (TryReturnTargetBuildableExtendable<School>(_project, out var buildableExtendable))
		{
			buildableExtendable.StopStudying(_agent);
		}
	}

	public override ProjectBlocker ReturnBlockers(Agent agent)
	{
		if (agent.Community.Research.HasStudyTime())
		{
			return ProjectBlocker.None;
		}
		return ProjectBlocker.NoResearch;
	}

	protected override void OnGUI()
	{
		Header("Learn At School", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Learning at a school building.");
	}
}
