using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class KeyTutorial : MonoBehaviour
{
	[Header("Inventory Key Tutorial")]
	[SerializeField]
	private GameObject inventoryKeyObject;

	[SerializeField]
	private RectTransform inventoryKeyRect;

	[SerializeField]
	private CanvasGroup inventoryKeyCG;

	[SerializeField]
	private TMP_Text inventoryKeyText;

	[SerializeField]
	private LocalizedString openInventoryLocalization;

	[Header("Build Key Tutorial")]
	[SerializeField]
	private GameObject buildKeyObject;

	[SerializeField]
	private RectTransform buildKeyRect;

	[SerializeField]
	private CanvasGroup buildKeyCG;

	[SerializeField]
	private TMP_Text buildKeyText;

	[SerializeField]
	private LocalizedString openBuildLocalization;

	[Header("Missions Key Tutorial")]
	[SerializeField]
	private GameObject missionsKeyObject;

	[SerializeField]
	private RectTransform missionsKeyRect;

	[SerializeField]
	private CanvasGroup missionsKeyCG;

	[SerializeField]
	private TMP_Text missionsKeyText;

	[SerializeField]
	private LocalizedString openMissionsLocalization;

	[Header("Animation Settings")]
	[SerializeField]
	private float slideDistance = 200f;

	[SerializeField]
	private float slideDuration = 0.5f;

	[SerializeField]
	private float fadeDuration = 0.4f;

	[SerializeField]
	private Ease slideEase = Ease.InQuart;

	private const string PREF_INVENTORY = "KeyTutorial_Inventory";

	private const string PREF_BUILD = "KeyTutorial_Build";

	private const string PREF_MISSIONS = "KeyTutorial_Missions";

	private bool inventoryDismissed;

	private bool buildDismissed;

	private bool missionsDismissed;

	private void Start()
	{
		inventoryDismissed = PlayerPrefs.GetInt("KeyTutorial_Inventory", 0) == 1;
		buildDismissed = PlayerPrefs.GetInt("KeyTutorial_Build", 0) == 1;
		missionsDismissed = PlayerPrefs.GetInt("KeyTutorial_Missions", 0) == 1;
		if (inventoryDismissed && buildDismissed && missionsDismissed)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (inventoryDismissed && inventoryKeyObject != null)
		{
			inventoryKeyObject.SetActive(value: false);
		}
		if (buildDismissed && buildKeyObject != null)
		{
			buildKeyObject.SetActive(value: false);
		}
		if (missionsDismissed && missionsKeyObject != null)
		{
			missionsKeyObject.SetActive(value: false);
		}
		UpdateAllTexts();
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.AddListener(OnPanelOpened);
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
	}

	private void OnDestroy()
	{
		if (Singleton<MainUIManager>.Instance != null)
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.RemoveListener(OnPanelOpened);
		}
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
	}

	private void OnLocaleChanged(Locale newLocale)
	{
		UpdateAllTexts();
	}

	private void UpdateAllTexts()
	{
		KeyData keyData = Singleton<UserPrefencesManager>.Instance.keyData;
		if (!inventoryDismissed)
		{
			SetTutorialText(inventoryKeyText, openInventoryLocalization, "Open Inventory", keyData.InventoryKey);
		}
		if (!buildDismissed)
		{
			SetTutorialText(buildKeyText, openBuildLocalization, "Open Build", keyData.BuildKey);
		}
		if (!missionsDismissed)
		{
			SetTutorialText(missionsKeyText, openMissionsLocalization, "Open Missions", keyData.StoryPanelKey);
		}
	}

	private void SetTutorialText(TMP_Text text, LocalizedString localized, string fallback, KeyCode key)
	{
		if (text == null)
		{
			return;
		}
		string text2 = fallback;
		if (localized != null && !localized.IsEmpty)
		{
			string localizedString = localized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString))
			{
				text2 = localizedString;
			}
		}
		text.text = text2 + " (" + KeyCodeToDisplayString(key) + ")";
	}

	private void OnPanelOpened(UIPanelBase panel)
	{
		if (!inventoryDismissed && panel is CraftPanelUIManager)
		{
			inventoryDismissed = true;
			PlayerPrefs.SetInt("KeyTutorial_Inventory", 1);
			DismissSlideLeft(inventoryKeyRect, inventoryKeyCG, inventoryKeyObject);
		}
		if (!buildDismissed && panel is ObjectBuilderUIManager)
		{
			buildDismissed = true;
			PlayerPrefs.SetInt("KeyTutorial_Build", 1);
			DismissSlideLeft(buildKeyRect, buildKeyCG, buildKeyObject);
		}
		if (!missionsDismissed && panel is StoryBoardPanel)
		{
			missionsDismissed = true;
			PlayerPrefs.SetInt("KeyTutorial_Missions", 1);
			DismissSlideUp(missionsKeyRect, missionsKeyCG, missionsKeyObject);
		}
	}

	private void DismissSlideLeft(RectTransform rect, CanvasGroup cg, GameObject obj)
	{
		if (!(rect == null) && !(cg == null) && !(obj == null))
		{
			Vector2 endValue = rect.anchoredPosition + new Vector2(0f - slideDistance, 0f);
			DOTween.Sequence().Append(rect.DOAnchorPos(endValue, slideDuration).SetEase(slideEase)).Join(cg.DOFade(0f, fadeDuration))
				.OnComplete(delegate
				{
					obj.SetActive(value: false);
					CheckAllDismissed();
				});
		}
	}

	private void DismissSlideUp(RectTransform rect, CanvasGroup cg, GameObject obj)
	{
		if (!(rect == null) && !(cg == null) && !(obj == null))
		{
			Vector2 endValue = rect.anchoredPosition + new Vector2(0f, slideDistance);
			DOTween.Sequence().Append(rect.DOAnchorPos(endValue, slideDuration).SetEase(slideEase)).Join(cg.DOFade(0f, fadeDuration))
				.OnComplete(delegate
				{
					obj.SetActive(value: false);
					CheckAllDismissed();
				});
		}
	}

	private void CheckAllDismissed()
	{
		if (inventoryDismissed && buildDismissed && missionsDismissed)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private string KeyCodeToDisplayString(KeyCode key)
	{
		return key switch
		{
			KeyCode.Mouse0 => "LMB", 
			KeyCode.Mouse1 => "RMB", 
			KeyCode.Mouse2 => "MMB", 
			KeyCode.Return => "Enter", 
			KeyCode.Escape => "ESC", 
			KeyCode.BackQuote => "~", 
			KeyCode.Tab => "Tab", 
			KeyCode.Space => "Space", 
			KeyCode.LeftShift => "L-Shift", 
			KeyCode.RightShift => "R-Shift", 
			KeyCode.LeftControl => "L-Ctrl", 
			KeyCode.RightControl => "R-Ctrl", 
			KeyCode.LeftAlt => "L-Alt", 
			KeyCode.RightAlt => "R-Alt", 
			KeyCode.CapsLock => "CapsLock", 
			_ => key.ToString().ToUpper(), 
		};
	}
}
