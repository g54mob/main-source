using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelDetailSlot : MonoBehaviour
{
	private TextMeshProUGUI levelNameText;

	private TextMeshProUGUI completedText;

	private TextMeshProUGUI bestTimeText;

	private TextMeshProUGUI descriptionText;

	private TextMeshProUGUI noImageText;

	private Image levelImage;

	private Button uploadButton;

	private Button subscriptionButton;

	private Button playLevelButton;

	private Button loadLevelButton;

	private Button openLevelButton;

	public LevelModel SelectedLevelModel { get; private set; }

	public event Action<LevelModel> OnUploadButtonEvent;

	public event Action<LevelModel> OnPlayButtonEvent;

	public event Action<LevelModel> OnLoadButtonEvent;

	public event Action<LevelModel> OnOpenButtonEvent;

	private void Awake()
	{
		levelNameText = base.transform.FindComponent<TextMeshProUGUI>("LevelNameText", isRecursively: true);
		completedText = base.transform.FindComponent<TextMeshProUGUI>("CompletedText", isRecursively: true);
		bestTimeText = base.transform.FindComponent<TextMeshProUGUI>("BestTimeText", isRecursively: true);
		descriptionText = base.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		noImageText = base.transform.FindComponent<TextMeshProUGUI>("NoImageText", isRecursively: true);
		levelImage = base.transform.FindComponent<Image>("LevelImage", isRecursively: true);
		uploadButton = base.transform.FindComponent<Button>("UploadButton", isRecursively: true);
		subscriptionButton = base.transform.FindComponent<Button>("SubscriptionButton", isRecursively: true);
		playLevelButton = base.transform.FindComponent<Button>("PlayLevelButton", isRecursively: true);
		loadLevelButton = base.transform.FindComponent<Button>("LoadLevelButton", isRecursively: true);
		openLevelButton = base.transform.FindComponent<Button>("OpenLevelButton", isRecursively: true);
		uploadButton.onClick.AddListener(delegate
		{
			this.OnUploadButtonEvent?.Invoke(SelectedLevelModel);
		});
		subscriptionButton.onClick.AddListener(delegate
		{
			this.OnUploadButtonEvent?.Invoke(SelectedLevelModel);
		});
		playLevelButton.onClick.AddListener(delegate
		{
			this.OnPlayButtonEvent?.Invoke(SelectedLevelModel);
		});
		loadLevelButton.onClick.AddListener(delegate
		{
			this.OnLoadButtonEvent?.Invoke(SelectedLevelModel);
		});
		openLevelButton.onClick.AddListener(delegate
		{
			this.OnOpenButtonEvent?.Invoke(SelectedLevelModel);
		});
	}

	public void SetConfiguration(LevelModel levelModel)
	{
		if (levelModel == null)
		{
			levelNameText.SetText("-");
			descriptionText.SetText("");
			SetLevelCompleteness(float.PositiveInfinity);
			levelImage.enabled = false;
			noImageText.gameObject.SetActive(value: false);
			uploadButton.interactable = false;
			subscriptionButton.interactable = false;
			playLevelButton.interactable = false;
			loadLevelButton.interactable = false;
			openLevelButton.interactable = false;
			return;
		}
		levelNameText.SetText(levelModel.Name);
		descriptionText.SetText(levelModel.Description);
		float levelCompleteness = ((levelModel.LevelStatus != null) ? levelModel.LevelStatus.LowestTimeRecords.NoneStarValue : float.PositiveInfinity);
		SetLevelCompleteness(levelCompleteness);
		Sprite sprite = GameManager.Instance.UserAndWorkshopLevelThumbnailCollection.GetSprite("lvl_" + levelModel.Id);
		if (sprite != null)
		{
			levelImage.enabled = true;
			levelImage.sprite = sprite;
			noImageText.gameObject.SetActive(value: false);
		}
		else
		{
			levelImage.enabled = false;
			noImageText.gameObject.SetActive(value: true);
		}
		uploadButton.interactable = true;
		subscriptionButton.interactable = true;
		playLevelButton.interactable = true;
		loadLevelButton.interactable = true;
		openLevelButton.interactable = true;
		if (!SteamManager.Initialized || levelModel.Place == LevelModel.LevelPlace.New)
		{
			uploadButton.interactable = false;
			subscriptionButton.interactable = false;
		}
		if (levelModel.Place == LevelModel.LevelPlace.New)
		{
			string id = "leveleditor.template.name." + levelModel.Id;
			string text = LanguagesManager.Instance.GetText(id);
			string id2 = "leveleditor.template.description." + levelModel.Id;
			string text2 = LanguagesManager.Instance.GetText(id2);
			levelNameText.SetText(text);
			descriptionText.SetText(text2);
		}
		SelectedLevelModel = levelModel;
	}

	private void SetLevelCompleteness(float bestTime)
	{
		bool flag = bestTime < float.PositiveInfinity;
		completedText.text = (flag ? "<#F7EC3DFF>\uf046" : "<#787878FF>\uf096");
		bestTimeText.text = (flag ? Util.TimeParser(bestTime) : "--:--:---");
	}

	public void SetPanelType(LoadLevelView.PanelType panelType)
	{
		playLevelButton.gameObject.SetActive(value: false);
		loadLevelButton.gameObject.SetActive(value: false);
		openLevelButton.gameObject.SetActive(value: false);
		switch (panelType)
		{
		case LoadLevelView.PanelType.Play:
			playLevelButton.gameObject.SetActive(value: true);
			break;
		case LoadLevelView.PanelType.Load:
			loadLevelButton.gameObject.SetActive(value: true);
			break;
		case LoadLevelView.PanelType.New:
			openLevelButton.gameObject.SetActive(value: true);
			break;
		}
	}

	public void SetBestTimeTextVisibility(bool isVisible)
	{
		if (bestTimeText.gameObject.activeSelf != isVisible)
		{
			bestTimeText.gameObject.SetActive(isVisible);
		}
	}

	public void SetUploadButtonVisibility(bool isVisible)
	{
		if (uploadButton.gameObject.activeSelf != isVisible)
		{
			uploadButton.gameObject.SetActive(isVisible);
		}
	}

	public void SetSubscriptionButtonVisibility(bool isVisible)
	{
		if (subscriptionButton.gameObject.activeSelf != isVisible)
		{
			subscriptionButton.gameObject.SetActive(isVisible);
		}
	}
}
