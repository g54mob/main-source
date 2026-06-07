using I2.Loc;
using UnityEngine;

public abstract class TechTreeRequirement : ScriptableObject, IIconProvider, ITooltipProvider
{
	[SerializeField]
	private TechTreeRequirementProvider _provider;

	[SerializeField]
	private TechTreeRequirementFlags _flags;

	public string Label
	{
		get
		{
			if (_provider == null)
			{
				return string.Empty;
			}
			return _provider.Label;
		}
	}

	public LocalizedString Description
	{
		get
		{
			if (_provider == null)
			{
				return default(LocalizedString);
			}
			return _provider.Description;
		}
	}

	public TechTreeRequirementFlags Flags => _flags;

	public virtual GameEventType UpdateGUIEvent => GameEventType.None;

	public void SetProvider(TechTreeRequirementProvider provider)
	{
		_provider = provider;
	}

	public abstract bool IsMet();

	public abstract bool TryGetAmount(out int amount);

	public Sprite GetIcon()
	{
		if (_provider == null)
		{
			return null;
		}
		return _provider.GetIcon(this);
	}

	public abstract string GetTooltip(TooltipBuilder tooltipBuilder);

	public void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
	}

	public void ShowTooltip(Vector3 position, bool delayed = true)
	{
	}

	public void HideTooltip()
	{
	}
}
