public class DefaultControllerButtonToSymbolService : IControllerButtonToSymbolService
{
	public bool HasMappings => false;

	public virtual string GetTextMeshProSymbolTextForControllerButton(ControllerButton buttonType)
	{
		string text = "";
		switch (buttonType)
		{
		case ControllerButton.FaceButtonBottom:
			text = "SPR_Switch_LetterButtons-Down";
			break;
		case ControllerButton.FaceButtonRight:
			text = "SPR_Switch_LetterButtons-Right";
			break;
		case ControllerButton.FaceButtonLeft:
			text = "SPR_Switch_LetterButtons-Left";
			break;
		case ControllerButton.FaceButtonTop:
			text = "SPR_Switch_LetterButtons-Up";
			break;
		case ControllerButton.ButtonLeft:
			text = "SPR_PC_DPad-Left";
			break;
		case ControllerButton.ButtonRight:
			text = "SPR_PC_DPad-Right";
			break;
		case ControllerButton.ButtonUp:
			text = "SPR_PC_DPad-Up";
			break;
		case ControllerButton.ButtonDown:
			text = "SPR_PC_DPad-Down";
			break;
		}
		if (text.Length <= 0)
		{
			return null;
		}
		return "<sprite name=\"" + text + "\" tint=1>";
	}
}
