using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "OpenTutorialPage", menuName = "Flotsam/Actions/Buildable/Open Tutorial Page")]
public class OpenTutorialPageAction : ISelectableActionBase<Buildable>
{
	[SerializeField]
	private ActionData _data;

	public override void Trigger()
	{
		GameManager.UIManager.DisplayPanel(PanelID.TutorialPanel, new TutorialPanel.TutorialIDContext(base.Selectable.Properties.TutorialPageID));
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
