using UnityEngine;

public class ExitConditionBase
{
	public virtual void ResetCondition()
	{
	}

	public virtual void UpdateCondition()
	{
	}

	public virtual bool ConditionMet(GameObject dog)
	{
		return false;
	}
}
