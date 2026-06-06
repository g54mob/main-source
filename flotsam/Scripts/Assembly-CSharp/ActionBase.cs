using System;
using I2.Loc;
using PajamaLlama.UI;
using UnityEngine;

public abstract class ActionBase : ScriptableObject, ITooltipProvider
{
	public virtual bool IsEnabled => true;

	public abstract bool IsInteractable { get; }

	public virtual bool IsSelected => false;

	public abstract void Trigger();

	public virtual void RadialMenuSelect(RadialMenu radialMenu)
	{
	}

	public virtual void RadialMenuDeselect(RadialMenu radialMenu)
	{
	}

	public abstract Sprite GetIcon();

	public virtual string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		throw new NotImplementedException();
	}

	public virtual LocalizedString GetLabel()
	{
		throw new NotImplementedException();
	}

	public virtual LocalizedString GetDescription()
	{
		throw new NotImplementedException();
	}
}
