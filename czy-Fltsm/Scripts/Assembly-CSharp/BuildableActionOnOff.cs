using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildableActionOnOff", menuName = "Flotsam/Actions/Buildable/On Off")]
public class BuildableActionOnOff : ISelectableActionBase<Buildable>
{
	[SerializeField]
	private ActionData _on;

	[SerializeField]
	private ActionData _off;

	public override void Trigger()
	{
		if (base.Selectable.IsActive)
		{
			base.Selectable.Deactivate();
		}
		else
		{
			base.Selectable.Activate();
		}
	}

	public override Sprite GetIcon()
	{
		if (!base.Selectable.IsActive)
		{
			return _off.Icon;
		}
		return _on.Icon;
	}

	public override LocalizedString GetLabel()
	{
		if (!base.Selectable.IsActive)
		{
			return _off.Label;
		}
		return _on.Label;
	}

	public override LocalizedString GetDescription()
	{
		if (!base.Selectable.IsActive)
		{
			return _off.Description;
		}
		return _on.Description;
	}
}
