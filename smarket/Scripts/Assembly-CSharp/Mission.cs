using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract class Mission
{
	private List<MissionTask> m_Tasks;

	public event Action Completed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public Mission()
	{
	}

	protected void AddTask(MissionTask task)
	{
	}

	protected abstract void SetupTasks();

	public void Begin()
	{
	}

	public void End()
	{
	}

	private void CheckCompletion()
	{
	}

	protected abstract void OnBegan();

	protected abstract void OnEnded();

	public void Update()
	{
	}
}
