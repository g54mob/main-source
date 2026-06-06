using UnityEngine;

public abstract class ResearchUnlockable : Unlockable, IIconProvider, ITooltipProvider
{
	protected virtual bool DefaultToUnlocked => true;

	public virtual void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
		TooltipPanel.ShowTooltip(this);
	}

	public virtual void ShowTooltip(Vector3 position, bool delayed = true)
	{
		TooltipPanel.ShowTooltip(this, delayed);
	}

	public virtual void HideTooltip()
	{
		TooltipPanel.HideTooltip(this);
	}

	public abstract string GetName();

	public abstract string GetDescription();

	public abstract Sprite GetIcon();

	public abstract string GetTooltip(TooltipBuilder tooltipBuilder);

	public override bool IsUnlocked()
	{
		if (DefaultToUnlocked && !GameManager.Settings.TechTree.ContainsUnlockable(this))
		{
			return true;
		}
		if (Community.PlayerCommunity != null && Community.PlayerCommunity.Research.IsResearched(this))
		{
			Unlock();
			return true;
		}
		return base.IsUnlocked();
	}
}
