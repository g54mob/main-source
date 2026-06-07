public class UIInteractableResourceLimitRequirement : UIInteractableRequirementBase
{
	private void LateUpdate()
	{
		if (ReturnIsMet())
		{
			base.IsMet = true;
			base.enabled = false;
		}
	}

	public override bool ReturnIsMet()
	{
		return GameManager.ResourceManager.HasResourceLimit();
	}
}
