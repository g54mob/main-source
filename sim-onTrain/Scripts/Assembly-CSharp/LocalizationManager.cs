using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
	[SerializeField]
	private bool showInGameView = true;

	[SerializeField]
	private Vector2 size = new Vector2(100f, 25f);

	[SerializeField]
	private float spacing = 3f;

	[SerializeField]
	private Color backgroundColor = new Color(0f, 0f, 0f, 0.7f);

	[SerializeField]
	private Color textColor = Color.white;

	[SerializeField]
	private Color selectedColor = Color.green;

	[SerializeField]
	private int fontSize = 12;

	private GUIStyle normalStyle;

	private GUIStyle selectedStyle;

	private List<Locale> availableLocales = new List<Locale>();

	private Locale currentLocale;

	private bool initialized;

	public static LocalizationManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		StartCoroutine(InitializeLocales());
	}

	private IEnumerator InitializeLocales()
	{
		yield return LocalizationSettings.InitializationOperation;
		availableLocales = LocalizationSettings.AvailableLocales.Locales;
		currentLocale = LocalizationSettings.SelectedLocale;
		if (SettingsManager.Instance != null)
		{
			string savedLanguage = SettingsManager.Instance.GetSettingsData().languageCode;
			if (!string.IsNullOrEmpty(savedLanguage))
			{
				Locale locale = availableLocales.FirstOrDefault((Locale l) => l.Identifier.Code.ToLower() == savedLanguage.ToLower());
				if (locale != null)
				{
					LocalizationSettings.SelectedLocale = locale;
				}
			}
		}
		initialized = true;
	}

	public string GetCurrentLanguageCode()
	{
		if (currentLocale != null)
		{
			return currentLocale.Identifier.Code;
		}
		return "en";
	}

	public string[] GetAvailableLanguageCodes()
	{
		if (!initialized || availableLocales == null)
		{
			return new string[1] { "en" };
		}
		return availableLocales.Select((Locale l) => l.Identifier.Code).ToArray();
	}

	public string[] GetAvailableLanguageNames()
	{
		if (!initialized || availableLocales == null)
		{
			return new string[1] { "English" };
		}
		return availableLocales.Select((Locale l) => l.name).ToArray();
	}

	public int GetCurrentLanguageIndex()
	{
		if (!initialized || currentLocale == null)
		{
			return 0;
		}
		return availableLocales.IndexOf(currentLocale);
	}

	private void OnGUI()
	{
		if (!showInGameView)
		{
			return;
		}
		try
		{
			if (normalStyle == null || selectedStyle == null)
			{
				normalStyle = new GUIStyle(GUI.skin.button);
				normalStyle.normal.textColor = textColor;
				normalStyle.fontSize = fontSize;
				normalStyle.alignment = TextAnchor.MiddleCenter;
				selectedStyle = new GUIStyle(normalStyle);
				selectedStyle.normal.textColor = selectedColor;
				selectedStyle.fontStyle = FontStyle.Bold;
			}
			if (!initialized || availableLocales == null || availableLocales.Count == 0 || currentLocale == null)
			{
				return;
			}
			List<Locale> list = new List<Locale>(availableLocales);
			float num = 10f;
			float y = 10f;
			Vector2 vector = new Vector2((float)Screen.width - size.x - num, y);
			float height = (size.y + spacing) * (float)list.Count;
			GUI.color = backgroundColor;
			GUI.Box(new Rect(vector.x, vector.y, size.x, height), "");
			GUI.color = Color.white;
			float num2 = vector.y;
			for (int i = 0; i < list.Count; i++)
			{
				Locale locale = list[i];
				if (!(locale == null))
				{
					GUIStyle style = ((locale == currentLocale) ? selectedStyle : normalStyle);
					if (GUI.Button(new Rect(vector.x, num2, size.x, size.y), locale.name, style))
					{
						LocalizationSettings.SelectedLocale = locale;
					}
					num2 += size.y + spacing;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Error in OnGUI of LocalizationManager: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void OnEnable()
	{
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
	}

	private void OnDisable()
	{
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
	}

	private void OnValidate()
	{
		if (Application.isPlaying && initialized)
		{
			normalStyle = null;
			selectedStyle = null;
		}
	}

	private void OnLocaleChanged(Locale locale)
	{
		currentLocale = locale;
		if (SettingsManager.Instance != null && initialized)
		{
			SettingsManager.Instance.SetLanguageCode(locale.Identifier.Code);
		}
	}
}
