using UnityEngine;

public class InstructionManual : MonoBehaviour
{
	[SerializeField]
	private ChapterButton coverButton;

	private void OnEnable()
	{
		if (LevelManager.GetCurrLevel() == 0 && ChapterButton.GetCurrentChapter() > 1)
		{
			coverButton.LaunchChapter();
			coverButton.SetInteractable(interactable: false);
		}
	}
}
