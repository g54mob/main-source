using UnityEngine;

public abstract class InteractorBase : MonoBehaviour
{
	public virtual bool CanBeInteractedWith => true;

	public virtual string ReturnTooltip()
	{
		return "";
	}

	public virtual void InteractionBegin(PlayerInteraction player)
	{
	}

	public virtual void InteractionHold(PlayerInteraction player)
	{
	}

	public virtual void InteractionEnd(PlayerInteraction player)
	{
	}

	public abstract void Focus(PlayerInteraction player);

	public abstract void Unfocus(PlayerInteraction player);
}
