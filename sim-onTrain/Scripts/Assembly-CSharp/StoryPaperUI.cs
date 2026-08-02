using UnityEngine;

public class StoryPaperUI : MonoBehaviour
{
	public CollectableItemData storyData;

	public CanvasGroup canvasGroup;

	[Header("Network Sync")]
	[SerializeField]
	private Vector2 normalizedPosition;

	private void Start()
	{
		CheckAndUpdateVisibility();
	}

	private void OnEnable()
	{
		CheckAndUpdateVisibility();
	}

	private void CheckAndUpdateVisibility()
	{
		if (!(storyData == null) && !(canvasGroup == null))
		{
			if (storyData.isLearned)
			{
				ShowPaper();
			}
			else
			{
				HidePaper();
			}
		}
	}

	public void HidePaper()
	{
		if (!(canvasGroup == null))
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
	}

	public void ShowPaper()
	{
		if (!(canvasGroup == null))
		{
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
	}
}
