using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionModeView : BaseGUIView
{
	public const string KeyListVisibilityToggleEvent = "ActionModeView.KeyListVisibilityToggleEvent";

	public const string KeyListCompactToggleEvent = "ActionModeView.KeyListCompactToggleEvent";

	public const string CameraResetEvent = "ActionModeView.CameraResetEvent";

	public const string LevelResetEvent = "ActionModeView.LevelResetEvent";

	[SerializeField]
	private GameObject noKeysTextPrefab;

	[SerializeField]
	private GameObject keyGroupPrefab;

	[SerializeField]
	private GameObject blockKeyNamePrefab;

	[SerializeField]
	private GameObject logicKeyGroupPrefab;

	private TextMeshProUGUI currentTimeText;

	private TextMeshProUGUI bestTimeText;

	private TextMeshProUGUI collectablesText;

	private Toggle keyListVisibilityToggle;

	private Button cameraButton;

	private Button levelResetButton;

	private Image thumbnailImage;

	private bool isThumbnailCaptureEnabled;

	private CreationKeyListController creationKeyListController;

	public CreationKeyListView CreationKeyListView { get; private set; }

	public override void Initialize()
	{
		currentTimeText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CurrentTimeText", isRecursively: true);
		bestTimeText = mainPanel.transform.FindComponent<TextMeshProUGUI>("BestTimeText", isRecursively: true);
		collectablesText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CollectablesText", isRecursively: true);
		keyListVisibilityToggle = mainPanel.transform.FindComponent<Toggle>("KeyListVisibilityToggle", isRecursively: true);
		cameraButton = mainPanel.transform.FindComponent<Button>("CameraButton", isRecursively: true);
		levelResetButton = mainPanel.transform.FindComponent<Button>("LevelResetButton", isRecursively: true);
		thumbnailImage = mainPanel.transform.FindComponent<Image>("ThumbnailImage", isRecursively: true);
		keyListVisibilityToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ActionModeView.KeyListVisibilityToggleEvent", isOn);
		});
		cameraButton.onClick.AddListener(delegate
		{
			NotifyChange("ActionModeView.CameraResetEvent");
		});
		levelResetButton.onClick.AddListener(delegate
		{
			NotifyChange("ActionModeView.LevelResetEvent");
		});
		CreationKeyListView = new CreationKeyListView(this, noKeysTextPrefab, keyGroupPrefab, blockKeyNamePrefab, logicKeyGroupPrefab);
		creationKeyListController = new CreationKeyListController(CreationKeyListView, null);
		isThumbnailCaptureEnabled = File.Exists(PathNames.Data + "ThumbnailCapture.txt");
	}

	public void SetBestTime(float bestTime, LevelStatus.StarType starType, bool isStarsVisible)
	{
		string text = LanguagesManager.Instance.GetText("label.text.action.besttime", "Best Time");
		string text2 = string.Empty;
		switch (starType)
		{
		case LevelStatus.StarType.Both:
			text2 = "<color=#F7EC3D>\uf005</color><color=#787878>\uf005</color>";
			break;
		case LevelStatus.StarType.Gold:
			text2 = "<color=#F7EC3D>\uf005</color><color=#7878784D>\uf006</color>";
			break;
		case LevelStatus.StarType.Silver:
			text2 = "<color=#F7EC3D4D>\uf006</color><color=#787878>\uf005</color>";
			break;
		case LevelStatus.StarType.None:
			text2 = "<color=#F7EC3D4D>\uf006</color><color=#7878784D>\uf006</color>";
			break;
		}
		bestTimeText.text = text + ": " + Util.TimeParser(bestTime) + ((bestTime < float.PositiveInfinity && isStarsVisible) ? (" (" + text2 + ")") : "");
	}

	public void SetCurrentTime(float currentTime)
	{
		currentTimeText.text = Util.TimeParser(currentTime, shouldIncludeMilliseconds: false);
	}

	public void SetCollectablesVisibility(bool isVisible)
	{
		collectablesText.gameObject.SetActive(isVisible);
	}

	public void SetCollectablesCount(int goldCounter, int goldTotal, int silverCount, int silverTotal)
	{
		collectablesText.SetText($"<color=#F7EC3D>\uf005</color>  {goldCounter}/{goldTotal}     <color=#7A7583>\uf005</color>  {silverCount}/{silverTotal}");
	}

	public void SetCreationForKeyList(CreationModel creationModel)
	{
		creationKeyListController.SetModel(creationModel);
	}

	public void SetKeyListToggleValue(bool isSelected)
	{
		if (keyListVisibilityToggle.isOn != isSelected)
		{
			keyListVisibilityToggle.SetValue(isSelected);
		}
	}

	public void NotifyKeyListCompactToggleChanged(bool isOn)
	{
		NotifyChange("ActionModeView.KeyListCompactToggleEvent", isOn);
	}

	private void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.F8))
		{
			thumbnailImage.gameObject.SetActive(value: false);
		}
		if (Input.GetKeyDown(KeyCode.F9) && isThumbnailCaptureEnabled)
		{
			SetVisibility(isVisible: false);
			GameManager.Instance.MainCreationController.view.SetVisibility(isVisible: false);
			StartCoroutine(TakeScreenshot());
		}
	}

	private IEnumerator TakeScreenshot()
	{
		yield return new WaitForEndOfFrame();
		string id = GameManager.Instance.LevelController.model.Id;
		string path = PathNames.CampignLevelThumbnails + id + ".png";
		Texture2D texture2D = ScreenCapture.CaptureScreenshotAsTexture();
		TextureScale.Bilinear(texture2D, 1280, 720);
		byte[] buffer = texture2D.EncodeToPNG();
		using (FileStream output = File.Open(path, FileMode.Create))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(output))
			{
				binaryWriter.Write(buffer);
			}
		}
		thumbnailImage.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, 1280f, 720f), new Vector2(0.5f, 0.5f), 100f);
		thumbnailImage.gameObject.SetActive(value: true);
		GameManager.Instance.LevelThumbnailCollection.AddSprite(id, thumbnailImage.sprite);
		SetVisibility(isVisible: true);
		GameManager.Instance.MainCreationController.view.SetVisibility(isVisible: true);
	}
}
