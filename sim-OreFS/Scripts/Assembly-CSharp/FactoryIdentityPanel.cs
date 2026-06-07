using System;
using System.Collections;
using I2.Loc;
using Kamgam.UGUIComponentsForSettings;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FactoryIdentityPanel : MonoBehaviour
{
	[Header("Name Input")]
	[SerializeField]
	private TMP_InputField companyNameInput;

	[SerializeField]
	private Button randomNameButton;

	[SerializeField]
	private int maxNameLength = 24;

	[Header("Logo Selection")]
	[SerializeField]
	private Image logoPreviewImage;

	[SerializeField]
	private Button previousLogoButton;

	[SerializeField]
	private Button nextLogoButton;

	[Header("Color Selection")]
	[SerializeField]
	private OptionsButtonUGUI backgroundColorSelector;

	[SerializeField]
	private OptionsButtonUGUI frontColorSelector;

	[Header("Preview")]
	[Tooltip("Üstteki preview - arka plan rengi için Image")]
	[SerializeField]
	private Image previewBackground;

	[Tooltip("Üstteki preview - ikon (front rengiyle tintlenir)")]
	[SerializeField]
	private Image previewIcon;

	[Tooltip("Üstteki preview - şirket ismi metni (front rengiyle tintlenir)")]
	[SerializeField]
	private TextMeshProUGUI previewText;

	[Header("Actions")]
	[SerializeField]
	private Button completeButton;

	[Header("Events")]
	public UnityEvent onPanelOpened;

	public UnityEvent onPanelClosed;

	public UnityEvent<string, int, int, int> onIdentityConfirmed;

	private FactoryIdentityConfigSO _config;

	private int _currentLogoIndex;

	private int _currentBackgroundColorIndex = 1;

	private int _currentFrontColorIndex;

	private bool _isOpen;

	public bool IsOpen => _isOpen;

	private void Start()
	{
		SetupButtonListeners();
		LoadConfig();
	}

	private void OnEnable()
	{
		if (!NetworkServer.active)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			}
			base.gameObject.SetActive(value: false);
			_isOpen = false;
		}
		else if (FactoryManager.Instance != null && FactoryManager.Instance.HasCompanyIdentity)
		{
			OpenWithValues(FactoryManager.Instance.CompanyName, FactoryManager.Instance.CompanyLogoIndex, FactoryManager.Instance.BackgroundColorIndex, FactoryManager.Instance.FrontColorIndex);
		}
		else
		{
			Open();
		}
	}

	private void OnDestroy()
	{
		RemoveButtonListeners();
	}

	private void LoadConfig()
	{
		if (ScriptableListManager.Instance != null)
		{
			_config = ScriptableListManager.Instance.FactoryIdentityConfig;
		}
		if (_config == null)
		{
			Debug.LogWarning("[FactoryIdentityPanel] FactoryIdentityConfigSO bulunamadı!");
		}
	}

	private void SetupButtonListeners()
	{
		if (randomNameButton != null)
		{
			randomNameButton.onClick.AddListener(OnRandomNameClicked);
		}
		if (previousLogoButton != null)
		{
			previousLogoButton.onClick.AddListener(OnPreviousLogoClicked);
		}
		if (nextLogoButton != null)
		{
			nextLogoButton.onClick.AddListener(OnNextLogoClicked);
		}
		if (completeButton != null)
		{
			completeButton.onClick.AddListener(OnCompleteClicked);
		}
		if (companyNameInput != null)
		{
			companyNameInput.characterLimit = maxNameLength;
			companyNameInput.onValueChanged.AddListener(OnNameInputChanged);
		}
		if (backgroundColorSelector != null)
		{
			OptionsButtonUGUI optionsButtonUGUI = backgroundColorSelector;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(optionsButtonUGUI.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(OnBackgroundColorChanged));
		}
		if (frontColorSelector != null)
		{
			OptionsButtonUGUI optionsButtonUGUI2 = frontColorSelector;
			optionsButtonUGUI2.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(optionsButtonUGUI2.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(OnFrontColorChanged));
		}
	}

	private void RemoveButtonListeners()
	{
		if (randomNameButton != null)
		{
			randomNameButton.onClick.RemoveListener(OnRandomNameClicked);
		}
		if (previousLogoButton != null)
		{
			previousLogoButton.onClick.RemoveListener(OnPreviousLogoClicked);
		}
		if (nextLogoButton != null)
		{
			nextLogoButton.onClick.RemoveListener(OnNextLogoClicked);
		}
		if (completeButton != null)
		{
			completeButton.onClick.RemoveListener(OnCompleteClicked);
		}
		if (companyNameInput != null)
		{
			companyNameInput.onValueChanged.RemoveListener(OnNameInputChanged);
		}
		if (backgroundColorSelector != null)
		{
			OptionsButtonUGUI optionsButtonUGUI = backgroundColorSelector;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Remove(optionsButtonUGUI.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(OnBackgroundColorChanged));
		}
		if (frontColorSelector != null)
		{
			OptionsButtonUGUI optionsButtonUGUI2 = frontColorSelector;
			optionsButtonUGUI2.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Remove(optionsButtonUGUI2.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(OnFrontColorChanged));
		}
	}

	public void Open()
	{
		if (_isOpen)
		{
			return;
		}
		if (!NetworkServer.active)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			}
			return;
		}
		LoadConfig();
		string text = null;
		int value = -1;
		if (FactoryManager.Instance != null && FactoryManager.Instance.HasCompanyIdentity)
		{
			text = FactoryManager.Instance.CompanyName;
			value = FactoryManager.Instance.CompanyLogoIndex;
			_currentBackgroundColorIndex = FactoryManager.Instance.BackgroundColorIndex;
			_currentFrontColorIndex = FactoryManager.Instance.FrontColorIndex;
		}
		string nameToSet;
		if (!string.IsNullOrEmpty(text))
		{
			_currentLogoIndex = Mathf.Clamp(value, 0, GetMaxLogoIndex());
			nameToSet = text;
		}
		else
		{
			_currentLogoIndex = UnityEngine.Random.Range(0, Mathf.Max(1, GetMaxLogoIndex() + 1));
			_currentBackgroundColorIndex = 1;
			_currentFrontColorIndex = 0;
			nameToSet = ((_config != null) ? _config.GetRandomName() : $"Company #{UnityEngine.Random.Range(1000, 9999)}");
		}
		base.gameObject.SetActive(value: true);
		StartCoroutine(ApplyUIValuesNextFrame(nameToSet));
		_isOpen = true;
		onPanelOpened?.Invoke();
		Debug.Log("[FactoryIdentityPanel] Panel açıldı");
	}

	public void Close()
	{
		if (_isOpen)
		{
			base.gameObject.SetActive(value: false);
			_isOpen = false;
			onPanelClosed?.Invoke();
			Debug.Log("[FactoryIdentityPanel] Panel kapatıldı");
		}
	}

	public void OpenWithValues(string currentName, int currentLogoIndex, int bgColorIndex = 0, int frontColorIndex = 0)
	{
		if (!_isOpen)
		{
			LoadConfig();
			_currentLogoIndex = Mathf.Clamp(currentLogoIndex, 0, GetMaxLogoIndex());
			_currentBackgroundColorIndex = bgColorIndex;
			_currentFrontColorIndex = frontColorIndex;
			base.gameObject.SetActive(value: true);
			StartCoroutine(ApplyUIValuesNextFrame(currentName));
			_isOpen = true;
			onPanelOpened?.Invoke();
			Debug.Log("[FactoryIdentityPanel] Panel değerlerle açıldı");
		}
	}

	public void OnRandomNameClicked()
	{
		LoadConfig();
		if (!(_config == null))
		{
			string randomName = _config.GetRandomName();
			if (companyNameInput != null)
			{
				companyNameInput.text = randomName;
			}
			Debug.Log("[FactoryIdentityPanel] Rastgele isim: " + randomName);
		}
	}

	public void OnRandomLogoClicked()
	{
		LoadConfig();
		if (!(_config == null) && _config.LogoCount > 1)
		{
			int num;
			do
			{
				num = UnityEngine.Random.Range(0, _config.LogoCount);
			}
			while (num == _currentLogoIndex && _config.LogoCount > 1);
			_currentLogoIndex = num;
			UpdateLogoDisplay();
			Debug.Log($"[FactoryIdentityPanel] Rastgele logo: {_currentLogoIndex}");
		}
	}

	private void OnPreviousLogoClicked()
	{
		int maxLogoIndex = GetMaxLogoIndex();
		_currentLogoIndex--;
		if (_currentLogoIndex < 0)
		{
			_currentLogoIndex = maxLogoIndex;
		}
		UpdateLogoDisplay();
	}

	private void OnNextLogoClicked()
	{
		int maxLogoIndex = GetMaxLogoIndex();
		_currentLogoIndex++;
		if (_currentLogoIndex > maxLogoIndex)
		{
			_currentLogoIndex = 0;
		}
		UpdateLogoDisplay();
	}

	private void OnCompleteClicked()
	{
		string text = ((companyNameInput != null) ? companyNameInput.text.Trim() : "");
		if (string.IsNullOrWhiteSpace(text))
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_FactoryNameCannotBeEmpty"), isComputer: true);
			}
			return;
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.SetCompanyIdentity(text, _currentLogoIndex, _currentBackgroundColorIndex, _currentFrontColorIndex);
		}
		onIdentityConfirmed?.Invoke(text, _currentLogoIndex, _currentBackgroundColorIndex, _currentFrontColorIndex);
		Close();
		Debug.Log($"[FactoryIdentityPanel] Kimlik onaylandı: {text} (Logo: {_currentLogoIndex}, BgColor: {_currentBackgroundColorIndex}, FrontColor: {_currentFrontColorIndex})");
	}

	private void OnNameInputChanged(string newValue)
	{
		if (previewText != null)
		{
			previewText.text = newValue;
		}
	}

	private IEnumerator ApplyUIValuesNextFrame(string nameToSet)
	{
		yield return null;
		if (companyNameInput != null)
		{
			companyNameInput.text = nameToSet;
		}
		if (previewText != null)
		{
			previewText.text = nameToSet;
		}
		if (backgroundColorSelector != null)
		{
			backgroundColorSelector.SelectedIndex = _currentBackgroundColorIndex;
		}
		if (frontColorSelector != null)
		{
			frontColorSelector.SelectedIndex = _currentFrontColorIndex;
		}
		UpdateLogoDisplay();
		UpdatePreviewColors();
	}

	private void UpdateLogoDisplay()
	{
		if (!(_config == null))
		{
			Sprite logoByIndex = _config.GetLogoByIndex(_currentLogoIndex);
			if (logoPreviewImage != null)
			{
				logoPreviewImage.sprite = logoByIndex;
				logoPreviewImage.enabled = logoByIndex != null;
			}
			if (previewIcon != null)
			{
				previewIcon.sprite = logoByIndex;
				previewIcon.enabled = logoByIndex != null;
			}
			bool interactable = _config.LogoCount > 1;
			if (previousLogoButton != null)
			{
				previousLogoButton.interactable = interactable;
			}
			if (nextLogoButton != null)
			{
				nextLogoButton.interactable = interactable;
			}
			UpdatePreviewColors();
		}
	}

	private void OnBackgroundColorChanged(int index)
	{
		_currentBackgroundColorIndex = index;
		UpdatePreviewColors();
	}

	private void OnFrontColorChanged(int index)
	{
		_currentFrontColorIndex = index;
		UpdatePreviewColors();
	}

	private void UpdatePreviewColors()
	{
		if (!(_config == null))
		{
			if (previewBackground != null)
			{
				previewBackground.color = _config.GetColorByIndex(_currentBackgroundColorIndex);
			}
			Color colorByIndex = _config.GetColorByIndex(_currentFrontColorIndex);
			if (previewIcon != null)
			{
				previewIcon.color = colorByIndex;
			}
			if (previewText != null)
			{
				previewText.color = colorByIndex;
			}
		}
	}

	private void UpdateCompleteButtonState()
	{
		if (!(completeButton == null))
		{
			bool interactable = !string.IsNullOrWhiteSpace((companyNameInput != null) ? companyNameInput.text.Trim() : "");
			completeButton.interactable = interactable;
		}
	}

	private int GetMaxLogoIndex()
	{
		if (_config == null || _config.LogoCount == 0)
		{
			return 0;
		}
		return _config.LogoCount - 1;
	}
}
