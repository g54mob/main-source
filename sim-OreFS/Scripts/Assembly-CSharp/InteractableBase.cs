using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
	public virtual bool CanInteractPrimary()
	{
		return true;
	}

	public virtual bool CanInteractSecondary()
	{
		return true;
	}

	public virtual void OnHoldStarted()
	{
	}

	public virtual void OnHoldCanceled()
	{
	}

	public virtual void OnPrimaryInteracted()
	{
	}

	public virtual void OnSecondaryInteracted()
	{
	}
}
