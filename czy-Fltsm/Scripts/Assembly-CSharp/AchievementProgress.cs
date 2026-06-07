using UnityEngine;

public class AchievementProgress
{
	public enum Type
	{
		None = 0,
		xOffY = 1,
		Percentage = 2
	}

	public Type type;

	public int target;

	public int current;

	public bool IsCompleted => current == target;

	public AchievementProgress(Type type, int target)
	{
		this.type = type;
		this.target = target;
		current = 0;
	}

	public void SetCurrent(int current)
	{
		this.current = Mathf.Max(0, Mathf.Min(target, current));
	}

	public override string ToString()
	{
		return type switch
		{
			Type.xOffY => current + " / " + target, 
			Type.Percentage => Mathf.Floor((float)current / (float)target * 100f).ToString(), 
			_ => "", 
		};
	}
}
