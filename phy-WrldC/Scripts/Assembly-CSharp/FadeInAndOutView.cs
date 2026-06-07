using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOutView : BaseGUIView
{
	public Action actionToExecute;

	private FadeInAndOut fadeInAndOut;

	private TextMeshProUGUI levelGroupText;

	private TextMeshProUGUI levelNameText;

	private Image levelImage;

	public event Action OnFadeInHalfCompletedEvent;

	public event Action OnFadeInCompletedEvent;

	public event Action OnFadeOutHalfCompletedEvent;

	public event Action OnFadeOutCompletedEvent;

	public override void Initialize()
	{
		fadeInAndOut = mainPanel.transform.FindComponent<FadeInAndOut>("FadeInAndOutPanel", isRecursively: true);
		fadeInAndOut.OnFadeInHalfCompletedEvent += OnFadeInHalfCompletedHandler;
		fadeInAndOut.OnFadeInCompletedEvent += OnFadeInCompletedHandler;
		fadeInAndOut.OnFadeOutHalfCompletedEvent += OnFadeOutHalfCompletedHandler;
		fadeInAndOut.OnFadeOutCompletedEvent += OnFadeOutCompletedHandler;
		levelGroupText = mainPanel.transform.FindComponent<TextMeshProUGUI>("LevelGroupText", isRecursively: true);
		levelNameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("LevelNameText", isRecursively: true);
		levelImage = mainPanel.transform.FindComponent<Image>("LevelImage", isRecursively: true);
	}

	public void SetLevelModel(LevelModel levelModel)
	{
		if (levelModel == null)
		{
			levelGroupText.gameObject.SetActive(value: false);
			levelNameText.gameObject.SetActive(value: false);
			levelImage.gameObject.SetActive(value: false);
			return;
		}
		levelGroupText.gameObject.SetActive(value: true);
		levelNameText.gameObject.SetActive(value: true);
		var (sourceText, sourceText2) = LevelUtil.GetLevelNames(levelModel);
		levelNameText.SetText(sourceText2);
		levelGroupText.SetText(sourceText);
		Sprite sprite = GameManager.Instance.LevelThumbnailCollection.GetSprite(levelModel.Id);
		if (sprite == null)
		{
			sprite = GameManager.Instance.UserAndWorkshopLevelThumbnailCollection.GetSprite("lvl_" + levelModel.Id);
		}
		if (sprite != null)
		{
			levelImage.sprite = sprite;
			levelImage.gameObject.SetActive(value: true);
		}
		else
		{
			levelImage.gameObject.SetActive(value: false);
		}
	}

	public void FadeInToBlack()
	{
		fadeInAndOut.FadeInToBlack();
	}

	public void FadeOutFromBlack()
	{
		fadeInAndOut.FadeOutFromBlack();
	}

	private void OnFadeInHalfCompletedHandler()
	{
		if (this.OnFadeInHalfCompletedEvent != null)
		{
			this.OnFadeInHalfCompletedEvent();
		}
	}

	private void OnFadeInCompletedHandler()
	{
		if (actionToExecute != null)
		{
			actionToExecute();
		}
		actionToExecute = null;
		if (this.OnFadeInCompletedEvent != null)
		{
			this.OnFadeInCompletedEvent();
		}
	}

	private void OnFadeOutHalfCompletedHandler()
	{
		if (this.OnFadeOutHalfCompletedEvent != null)
		{
			this.OnFadeOutHalfCompletedEvent();
		}
	}

	private void OnFadeOutCompletedHandler()
	{
		SetVisibility(isVisible: false);
		if (this.OnFadeOutCompletedEvent != null)
		{
			this.OnFadeOutCompletedEvent();
		}
	}
}
