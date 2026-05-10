using System;
using System.Runtime.CompilerServices;

public abstract class MissionTask
{
	public bool IsCompleted { get; private set; }

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

	public abstract void Begin();

	public abstract void Update();

	public abstract void End();

	public void Complete()
	{
	}
}
