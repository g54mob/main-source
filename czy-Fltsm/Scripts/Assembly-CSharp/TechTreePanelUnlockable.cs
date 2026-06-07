using System;
using PajamaLlama;
using UnityEngine;
using UnityEngine.UI;

public class TechTreePanelUnlockable : Icon, IIconProvider, ITooltipProvider
{
	[Serializable]
	private struct BackgroundIcon
	{
		[TypesDerivedFrom(typeof(Unlockable))]
		public string Type;

		public Sprite Icon;
	}

	[SerializeField]
	private BackgroundIcon[] _backgroundIcons;

	[SerializeField]
	private GameObject _upgradeIcon;

	[SerializeField]
	private Image _backgroundTargetImage;

	[SerializeField]
	private Sprite _unknowIcon;

	public void Initialize(TechTreeNode node, ResearchUnlockable unlockable)
	{
		if (node.IsUnknown())
		{
			Initialize(this, forceActive: true);
		}
		else
		{
			Type type = unlockable.GetType();
			Initialize(unlockable, forceActive: true);
			BackgroundIcon[] backgroundIcons = _backgroundIcons;
			for (int i = 0; i < backgroundIcons.Length; i++)
			{
				BackgroundIcon backgroundIcon = backgroundIcons[i];
				Type type2 = Type.GetType(backgroundIcon.Type);
				if (type == type2 || type.IsSubclassOf(type2))
				{
					_backgroundTargetImage.enabled = true;
					_backgroundTargetImage.overrideSprite = backgroundIcon.Icon;
					_upgradeIcon.gameObject.SetActive(unlockable is BuildableProperties buildableProperties && buildableProperties.ReturnIsUpgarde());
					return;
				}
			}
		}
		_backgroundTargetImage.enabled = false;
	}

	public Sprite GetIcon()
	{
		return _unknowIcon;
	}

	public void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
	}

	public void ShowTooltip(Vector3 position, bool delayed = true)
	{
	}

	public void HideTooltip()
	{
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return string.Empty;
	}
}
