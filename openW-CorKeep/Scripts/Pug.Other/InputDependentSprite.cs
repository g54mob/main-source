using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InputDependentSprite : MonoBehaviour
{
	[Serializable]
	public class SpriteSettings
	{
		public Sprite sprite;

		public Color color = Color.white;

		public string optionalStringKey;

		public string optionalString;

		public Vector2 extraButtonSizePadding;
	}

	[Serializable]
	public class InputDependentSpriteSettings : InputDependentSettings<SpriteSettings>
	{
	}

	public PugText optionalText;

	public Transform transformAffectedByWidth;

	private Vector3 transformAffectedByWidthDefaultPosition;

	public InputDependentSpriteSettings settings;

	private SpriteRenderer spriteRenderer;

	private bool hasInitialized;

	private SpriteSettings currentSettings;

	private string currentLanguage = "";

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (transformAffectedByWidth != null)
		{
			transformAffectedByWidthDefaultPosition = transformAffectedByWidth.localPosition;
		}
		hasInitialized = true;
		UpdateButtonAndText();
	}

	private void Update()
	{
		UpdateButtonAndText();
	}

	public void UpdateButtonAndText()
	{
		if (hasInitialized)
		{
			string language = Manager.prefs.language;
			SpriteSettings bestSettings = settings.GetBestSettings();
			if ((currentSettings != bestSettings && bestSettings != null) || language != currentLanguage)
			{
				currentLanguage = language;
				currentSettings = bestSettings;
				spriteRenderer.sprite = currentSettings.sprite;
				spriteRenderer.color = currentSettings.color;
				UpdateTextInsideButton(currentSettings);
			}
		}
	}

	private void UpdateTextInsideButton(SpriteSettings settings)
	{
		bool flag = !string.IsNullOrWhiteSpace(settings.optionalStringKey);
		bool flag2 = string.IsNullOrWhiteSpace(settings.optionalString) && !flag;
		if (optionalText != null && !flag2)
		{
			if (!PugGlossary.CurrentLanguageUsesLatinFont() || !flag)
			{
				optionalText.localize = false;
				optionalText.localizePlaceholders = false;
				optionalText.Render(settings.optionalString);
			}
			else
			{
				optionalText.localize = true;
				optionalText.localizePlaceholders = true;
				optionalText.Render(settings.optionalStringKey);
			}
			spriteRenderer.drawMode = SpriteDrawMode.Sliced;
			spriteRenderer.size = new Vector2(optionalText.dimensions.width % 16f, optionalText.dimensions.height % 16f) + settings.extraButtonSizePadding;
			if (transformAffectedByWidth != null)
			{
				transformAffectedByWidth.localPosition = new Vector3((spriteRenderer.size.x / 2f + 0.3f) % 16f, 0f, 0f);
			}
		}
		else
		{
			optionalText?.Render("");
			spriteRenderer.size = new Vector2(1f, 1f);
			spriteRenderer.drawMode = SpriteDrawMode.Simple;
			if (transformAffectedByWidth != null)
			{
				transformAffectedByWidth.localPosition = transformAffectedByWidthDefaultPosition;
			}
		}
		spriteRenderer.transform.localScale = Vector3.one;
	}

	public SpriteRenderer GetSpriteRenderer()
	{
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		return spriteRenderer;
	}
}
