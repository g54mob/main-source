using I2.Loc;
using M4.Session;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildableActionChangeName", menuName = "Flotsam/Actions/Buildable/ChangeName")]
public class BuildableActionChangeName : ISelectableActionBase<Buildable>
{
	[SerializeField]
	private ActionData _data;

	public override void Trigger()
	{
		if (base.Selectable.Community.IsPlayerCommunity())
		{
			_ = GameManager.Settings.UISettings.InputNameChange;
			if (PopUpDialog.Instance.TryPopUpInput(GameManager.Settings.UISettings.InputNameChange))
			{
				PopUpDialog.Instance.InputEvent += SetBuildableName;
			}
		}
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

	private void OnTextInputCompleted(TextInputRequest input)
	{
		if (input.Succes)
		{
			base.Selectable.Name = input.Text;
		}
	}

	private void SetBuildableName(string name, bool feedback)
	{
		PopUpDialog.Instance.InputEvent -= SetBuildableName;
		if (feedback)
		{
			base.Selectable.Name = name;
		}
	}
}
