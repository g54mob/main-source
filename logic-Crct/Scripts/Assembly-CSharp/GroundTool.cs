using UnityEngine;
using UnityEngine.UI;

public class GroundTool : ToolBase
{
	[Header("Base Creator Box")]
	public Button cre_addButton;

	public Button cre_okButton;

	public Button cre_cancelButton;

	public InputField cre_xPosInput;

	public InputField cre_yPosInput;

	public InputField cre_rotInput;

	[Header(" Base Editor Box")]
	public InputField edit_xPosInput;

	public InputField edit_yPosInput;

	public InputField edit_rotInput;

	public void UpdateEditorTransformValues()
	{
	}

	public void UpdateCreatorTransformValues()
	{
	}

	public void RefreshCreator()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public override void RefreshEdit()
	{
	}

	public override void BeginCreate()
	{
	}

	public override void UpdateCreateParams()
	{
	}

	public override void UpdateEditParams()
	{
	}
}
