using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_DifficultySelectionBlock : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private GameObject node_StarIcon;

	[SerializeField]
	private TMP_Text text_RetryLimit;

	private eGameDifficultyType gameDifficultyType;

	public void Setup(eGameDifficultyType gameDifficultyType)
	{
	}

	public void ToggleLocked(bool isLocked)
	{
	}
}
