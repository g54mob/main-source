using System.Collections.Generic;
using TMPro;

public class TutorialLogMenu : MenuTransition
{
	public TextMeshProUGUI textArea;

	public override void OnGotFocus()
	{
		base.OnGotFocus();
		int levelNumber;
		int checkpoint;
		GameSave.GetProgress(out levelNumber, out checkpoint);
		List<string> list = TutorialRepository.instance.ListShownItems(levelNumber, checkpoint);
		textArea.text = string.Join("\r\n-----\r\n", list.ToArray());
	}

	public override void ApplyMenuEffects()
	{
		MenuCameraEffects.FadeInPauseMenu();
	}

	public void BackClick()
	{
		if (MenuSystem.CanInvoke)
		{
			TransitionBack<ExtrasMenu>();
		}
	}

	public override void OnBack()
	{
		BackClick();
	}
}
