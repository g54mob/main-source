using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveLevelView : BaseGUIView
{
	public const string SaveButtonEvent = "SaveLevelView.SaveButtonEvent";

	public const string CloseButtonEvent = "SaveLevelView.CloseButtonEvent";

	private TMP_InputField levelNameInput;

	private TMP_InputField descriptionInput;

	private TextMeshProUGUI characterCounterText;

	private Button saveButton;

	private Button closeButton;

	private Image levelImage;

	public Texture2D LevelTexture { get; private set; }

	public Sprite LevelSprite { get; private set; }

	public override void Initialize()
	{
		levelNameInput = mainPanel.transform.FindComponent<TMP_InputField>("LevelNameInput", isRecursively: true);
		descriptionInput = mainPanel.transform.FindComponent<TMP_InputField>("DescriptionInput", isRecursively: true);
		characterCounterText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CharacterCounterText", isRecursively: true);
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		levelImage = mainPanel.transform.FindComponent<Image>("LevelImage", isRecursively: true);
		descriptionInput.onValueChanged.AddListener(delegate(string text)
		{
			CharacterCounterHandler(text);
		});
		saveButton.onClick.AddListener(delegate
		{
			NotifyChange("SaveLevelView.SaveButtonEvent", levelNameInput.text, descriptionInput.text);
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("SaveLevelView.CloseButtonEvent");
		});
	}

	private void CharacterCounterHandler(string text)
	{
		characterCounterText.SetText(text.Length + "/" + descriptionInput.characterLimit);
	}

	public void SetLevelModelConfigurations(LevelModel levelModel)
	{
		levelNameInput.text = levelModel.Name;
		descriptionInput.text = levelModel.Description;
	}

	public void ClearFields()
	{
		levelNameInput.text = string.Empty;
		descriptionInput.text = string.Empty;
	}

	public void CreateLevelImage()
	{
		RenderTexture targetTexture = LevelEditorManager.Instance.ThumbnailCamera.targetTexture;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = targetTexture;
		Texture2D texture2D = new Texture2D(targetTexture.width, targetTexture.height, TextureFormat.RGB24, mipChain: false);
		texture2D.ReadPixels(new Rect(0f, 0f, targetTexture.width, targetTexture.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		levelImage.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, targetTexture.width, targetTexture.height), new Vector2(0.5f, 0.5f), 100f);
		levelImage.preserveAspect = true;
		LevelTexture = texture2D;
		LevelSprite = levelImage.sprite;
	}
}
