using I2.Loc;
using PajamaLlama.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildableActionDeconstruct", menuName = "Flotsam/Actions/Buildable/Deconstruct")]
public class BuildableActionDeconstruct : ISelectableActionBase<Buildable>
{
	[SerializeField]
	private Sprite _salvageIcon;

	[SerializeField]
	private LocalizedString _salvageLabel;

	[SerializeField]
	private LocalizedString _salvageDescription;

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
				return base.Selectable.Properties.ShowDurabilityElements;
			}
			return false;
		}
	}

	public override void Trigger()
	{
		LocalizedString error;
		if (base.Selectable.BuildPhase == BuildPhase.SalvageShutdown || base.Selectable.BuildPhase == BuildPhase.Deconstructing)
		{
			base.Selectable.CancelDeconstruction();
		}
		else if (base.Selectable.CanBeDeconstructed(out error))
		{
			base.Selectable.Salvage();
		}
	}

	public override Sprite GetIcon()
	{
		if (base.Selectable.BuildPhase == BuildPhase.SalvageShutdown || base.Selectable.BuildPhase == BuildPhase.Deconstructing)
		{
			return _cancelIcon;
		}
		return _salvageIcon;
	}

	public override LocalizedString GetDescription()
	{
		if (base.Selectable.BuildPhase == BuildPhase.SalvageShutdown || base.Selectable.BuildPhase == BuildPhase.Deconstructing)
		{
			return _cancelDescription;
		}
		if (!base.Selectable.CanBeDeconstructed(out var error))
		{
			return error;
		}
		return _salvageDescription;
	}

	public override LocalizedString GetLabel()
	{
		if (base.Selectable.BuildPhase == BuildPhase.SalvageShutdown || base.Selectable.BuildPhase == BuildPhase.Deconstructing)
		{
			return _cancelLabel;
		}
		return _salvageLabel;
	}

	public override void RadialMenuSelect(RadialMenu radialMenu)
	{
		if (base.Selectable.BuildPhase != BuildPhase.SalvageShutdown && base.Selectable.BuildPhase != BuildPhase.Deconstructing && base.Selectable.CanBeDeconstructed(out var _))
		{
			radialMenu.SetDeconstructInfo(base.Selectable);
		}
	}

	public override void RadialMenuDeselect(RadialMenu radialMenu)
	{
		radialMenu.ClearBuildable();
	}
}
