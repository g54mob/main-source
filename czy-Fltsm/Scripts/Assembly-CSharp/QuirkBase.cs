using UnityEngine;

public abstract class QuirkBase : ScriptableObject
{
	public void ApplyToDrifter(Agent drifter)
	{
		if ((bool)drifter.Quirks)
		{
			ApplyToDrifter(drifter.Quirks);
		}
	}

	public void RemoveFromDrifter(Agent drifter)
	{
		if ((bool)drifter.Quirks)
		{
			RemoveFromDrifter(drifter.Quirks);
		}
	}

	protected abstract void ApplyToDrifter(Quirks quirks);

	protected abstract void RemoveFromDrifter(Quirks quirks);
}
