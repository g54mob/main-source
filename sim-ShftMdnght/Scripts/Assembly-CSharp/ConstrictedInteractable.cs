using OutlineFx;

public class ConstrictedInteractable : Interactable
{
	public int[] allowedItems;

	public bool constrictionAllows;

	public override void Start()
	{
		base.Start();
	}

	private void TurnOffInteractable()
	{
		if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: false);
		}
		else
		{
			ChangeInteractableStatusCmd(change: false);
		}
	}

	public virtual void CheckForCurItem(int curIndex)
	{
		for (int i = 0; i < allowedItems.Length; i++)
		{
			if (curIndex == allowedItems[i])
			{
				constrictionAllows = true;
				return;
			}
		}
		constrictionAllows = false;
		StopLookAt();
	}

	public override void LookAt()
	{
		if (interactable && constrictionAllows)
		{
			global::OutlineFx.OutlineFx[] array = outlines;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
