using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildableActionSurvivalGuide", menuName = "Flotsam/Actions/Buildable/SurvivalGuide")]
public class BuildableActionSurvivalGuide : ISelectableActionBase<Buildable>
{
	[SerializeField]
	private ActionData _data;

	public override void Trigger()
	{
		StringEvent.Dispatch(GameEventType.OpenSurvivalGuidePage, base.Selectable.Properties.SurvivalGuideIdentifier);
	}

	public override Sprite GetIcon()
	{
		return _data.Icon;
	}

	public override LocalizedString GetLabel()
	{
		return _data.Label;
	}

	public override LocalizedString GetDescription()
	{
		return _data.Description;
	}
}
