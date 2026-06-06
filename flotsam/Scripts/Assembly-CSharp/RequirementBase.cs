using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public abstract class RequirementBase : ScriptableObject, IIconProvider, ITooltipProvider
{
	[SerializeField]
	private LocalizedString _tooltip;

	public virtual string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return _tooltip;
	}

	public virtual void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
	}

	public virtual void ShowTooltip(Vector3 position, bool delayed = true)
	{
	}

	public virtual void HideTooltip()
	{
	}

	public abstract Sprite GetIcon();

	public abstract bool TryGetAmount(out int amount);

	public abstract bool IsMet();
}
