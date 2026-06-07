using I2.Loc;
using PajamaLlama.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildableActionUpgrade", menuName = "Flotsam/Actions/Buildable/Upgrade")]
public class BuildableActionUpgrade : ISelectableActionBase<Buildable>
{
	private enum State
	{
		Locked = 0,
		Upgrade = 1,
		Cancel = 2
	}

	[SerializeField]
	private Sprite _lockedSprite;

	[SerializeField]
	private LocalizedString _lockedLabel;

	[SerializeField]
	private LocalizedString _lockedDescription;

	[SerializeField]
	private Sprite _upgradeIcon;

	[SerializeField]
	private LocalizedString _upgradeLabel;

	[SerializeField]
	private LocalizedString _upgradeDescription;

	[SerializeField]
	private Sprite _cancelIcon;

	[SerializeField]
	private LocalizedString _cancelLabel;

	[SerializeField]
	private LocalizedString _cancelDescription;

	public override bool IsEnabled
	{
		get
		{
			if ((bool)base.Selectable)
			{
				return base.Selectable.Properties.Upgrade;
			}
			return false;
		}
	}

	public override bool IsInteractable
	{
		get
		{
			if ((bool)base.Selectable)
			{
				if (!base.Selectable.CanUpgrade() && base.Selectable.BuildPhase != BuildPhase.UpgradeShutdown)
				{
					return base.Selectable.BuildPhase == BuildPhase.UpgradeHaulTo;
				}
				return true;
			}
			return false;
		}
	}

	public override void Trigger()
	{
		if (IsInteractable)
		{
			switch (GetState())
			{
			case State.Upgrade:
				base.Selectable.Upgrade();
				break;
			case State.Cancel:
				base.Selectable.CancelUpgrade();
				break;
			default:
				Debug.Log("Open Research Panel?");
				break;
			}
		}
	}

	public override void RadialMenuSelect(RadialMenu radialMenu)
	{
		if (GetState() == State.Upgrade)
		{
			radialMenu.SetUpgradeInfo(base.Selectable, upgradeResources: true);
		}
	}

	public override void RadialMenuDeselect(RadialMenu radialMenu)
	{
		radialMenu.ClearBuildable();
	}

	public override Sprite GetIcon()
	{
		return GetState() switch
		{
			State.Upgrade => _upgradeIcon, 
			State.Cancel => _cancelIcon, 
			_ => _lockedSprite, 
		};
	}

	public override LocalizedString GetLabel()
	{
		return GetState() switch
		{
			State.Upgrade => _upgradeLabel, 
			State.Cancel => _cancelLabel, 
			_ => _lockedLabel, 
		};
	}

	public override LocalizedString GetDescription()
	{
		return GetState() switch
		{
			State.Upgrade => _upgradeDescription, 
			State.Cancel => _cancelDescription, 
			_ => _lockedDescription, 
		};
	}

	private State GetState()
	{
		if (base.Selectable.Properties.Upgrade.IsUnlocked())
		{
			if (base.Selectable.BuildPhase == BuildPhase.UpgradeShutdown || base.Selectable.BuildPhase == BuildPhase.UpgradeHaulTo)
			{
				return State.Cancel;
			}
			return State.Upgrade;
		}
		return State.Locked;
	}
}
