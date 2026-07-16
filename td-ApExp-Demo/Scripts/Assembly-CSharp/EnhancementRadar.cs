using UnityEngine;

public abstract class EnhancementRadar : Enhancement
{
	[field: SerializeField]
	public int ID { get; private set; }

	[field: SerializeField]
	public bool IsToggleable { get; private set; }

	[field: SerializeField]
	public int CoresCost { get; private set; }

	public abstract void OnApplied();

	public abstract void OnRemoved();

	public override bool Equals(object obj)
	{
		if (obj is EnhancementRadar enhancementRadar)
		{
			return ID == enhancementRadar.ID;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
