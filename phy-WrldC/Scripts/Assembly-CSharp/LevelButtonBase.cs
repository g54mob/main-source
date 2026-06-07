using System;

public abstract class LevelButtonBase : DynamicObjectBase
{
	public bool IsOn { get; protected set; }

	public event Action<bool> OnChangedState;

	protected void InvokeOnChangedState(bool isOn)
	{
		if (this.OnChangedState != null)
		{
			this.OnChangedState(isOn);
		}
	}
}
