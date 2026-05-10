using System;
using CTS.Core;

public abstract class SimpleAction : CTSBehaviour
{
	public event Action<SimpleAction> Started;

	public event Action<SimpleAction> Stopped;

	public void StartAction()
	{
		if (!base.enabled)
		{
			this.Started?.Invoke(this);
			base.enabled = true;
		}
	}

	public void EndAction()
	{
		if (base.enabled)
		{
			base.enabled = false;
			this.Stopped?.Invoke(this);
		}
	}
}
