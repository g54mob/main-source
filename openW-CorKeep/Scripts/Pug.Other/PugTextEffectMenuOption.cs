using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class PugTextEffectMenuOption : PugTextEffect
{
	public bool useCustomUnselectedTextColor;

	public Color customUnselectedTextColor;

	public static readonly Color SELECTED_VALUE_COLOR = new Color(0f, 0.5019608f, 1f, 1f);

	public static readonly Color SELECTED_TEXT_COLOR = new Color(0.647f, 0.792f, 0.855f, 1f);

	public static readonly Color UNSELECTABLE_TEXT_COLOR = new Color(45f / 106f, 0.1742168f, 0.18354f, 1f);

	public static readonly Color UNSELECTED_TEXT_COLOR = new Color(0.5f, 0.5f, 0.5f, 0.725f);

	private const float BOUNCE_INTENSITY = 0.1875f;

	private const float BOUNCE_SPEED = -10f;

	[HideInInspector]
	public RadicalMenuOption optionComponent;

	public bool isValueText;

	public bool isDanceWhenSelected = true;

	public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

	private readonly List<float> glyphJumps = new List<float>();

	private TimerSimple jumpCooloff = new TimerSimple(1f / 6f, unscaled: true);

	private TimerSimple colorCooloff = new TimerSimple(1f / 12f, unscaled: true);

	private Color unselectedTextColor
	{
		get
		{
			if (!useCustomUnselectedTextColor)
			{
				return UNSELECTED_TEXT_COLOR;
			}
			return customUnselectedTextColor;
		}
	}

	private float time => Time.unscaledTime;

	protected override void Awake()
	{
		base.Awake();
		optionComponent = GetComponentInParent<RadicalMenuOption>();
	}

	public override void ResetEffect(bool rewind)
	{
		if (base.text == null)
		{
			Debug.LogWarning("PugTextEffectMenuOption.ResetEffect: text component on " + base.gameObject.name + " is null, can't reset.");
			return;
		}
		if (optionComponent == null)
		{
			Debug.LogWarning("PugTextEffectMenuOption.ResetEffect: optionComponent on " + base.gameObject.name + " is null, can't reset.");
			return;
		}
		glyphJumps.Recycle(base.text.glyphs.Count);
		for (int i = 0; i < base.text.glyphs.Count; i++)
		{
			glyphJumps.Add(0f);
		}
		if (optionComponent.IsSelected())
		{
			OnSelected();
		}
		else
		{
			EndEffectImmediate();
		}
		if (!rewind)
		{
			jumpCooloff.Stop();
			colorCooloff.Stop();
		}
	}

	public void OnSelected()
	{
		jumpCooloff.Stop();
		colorCooloff.Stop();
		base.text.SetTempColor(isValueText ? SELECTED_VALUE_COLOR : SELECTED_TEXT_COLOR);
		foreach (SpriteRenderer spriteRenderer in spriteRenderers)
		{
			spriteRenderer.color = (isValueText ? SELECTED_VALUE_COLOR : SELECTED_TEXT_COLOR);
		}
	}

	public void OnDeselected()
	{
		jumpCooloff.Start();
		colorCooloff.Start();
		base.text.SetTempColor(optionComponent.IsSelectionEnabled(visualOnly: true) ? unselectedTextColor : UNSELECTABLE_TEXT_COLOR);
		foreach (SpriteRenderer spriteRenderer in spriteRenderers)
		{
			spriteRenderer.color = (optionComponent.IsSelectionEnabled(visualOnly: true) ? unselectedTextColor : UNSELECTABLE_TEXT_COLOR);
		}
	}

	public void EndEffectImmediate()
	{
		jumpCooloff.Stop();
		UpdateGlyphsJump(0f);
		colorCooloff.Stop();
		base.text.SetTempColor(optionComponent.IsSelectionEnabled(visualOnly: true) ? unselectedTextColor : UNSELECTABLE_TEXT_COLOR);
		foreach (SpriteRenderer spriteRenderer in spriteRenderers)
		{
			spriteRenderer.color = (optionComponent.IsSelectionEnabled(visualOnly: true) ? unselectedTextColor : UNSELECTABLE_TEXT_COLOR);
		}
	}

	public override void PugTextEffectLateUpdate()
	{
		if (optionComponent.IsSelected())
		{
			if (isDanceWhenSelected)
			{
				for (int i = 0; i < base.text.glyphs.Count; i++)
				{
					float num = Mathf.Abs(Mathf.Sin(-10f * time + 0.5f * (float)i));
					base.text.glyphs[i].transform.Translate(0f, 0.1875f * num, 0f);
					glyphJumps[i] = num;
				}
			}
			return;
		}
		if (isDanceWhenSelected)
		{
			if (jumpCooloff.isRunning && !jumpCooloff.isTimerElapsed)
			{
				UpdateGlyphsJump(jumpCooloff.invElapsedRatio);
			}
			else if (jumpCooloff.isRunning)
			{
				jumpCooloff.Stop();
				UpdateGlyphsJump(0f);
			}
		}
		if (colorCooloff.isRunning && !colorCooloff.isTimerElapsed)
		{
			Color obj = (optionComponent.IsSelectionEnabled(visualOnly: true) ? unselectedTextColor : UNSELECTABLE_TEXT_COLOR);
			Color color = (isValueText ? SELECTED_VALUE_COLOR : SELECTED_TEXT_COLOR);
			Color color2 = obj * colorCooloff.elapsedRatio + color * colorCooloff.invElapsedRatio;
			base.text.SetTempColor(color2);
			{
				foreach (SpriteRenderer spriteRenderer in spriteRenderers)
				{
					spriteRenderer.color = color2;
				}
				return;
			}
		}
		if (!colorCooloff.isRunning)
		{
			return;
		}
		Color color3 = (optionComponent.IsSelectionEnabled(visualOnly: true) ? unselectedTextColor : UNSELECTABLE_TEXT_COLOR);
		base.text.SetTempColor(color3);
		foreach (SpriteRenderer spriteRenderer2 in spriteRenderers)
		{
			spriteRenderer2.color = color3;
		}
		colorCooloff.Stop();
	}

	private void UpdateGlyphsJump(float ratio)
	{
		if (base.text.glyphs.Count != glyphJumps.Count)
		{
			Debug.LogWarning(string.Format("{0}: different amount of glyphs ({1}) and glyph jumps ({2}!", "PugTextEffectMenuOption", base.text.glyphs.Count, glyphJumps.Count));
			return;
		}
		for (int i = 0; i < base.text.glyphs.Count; i++)
		{
			float num = glyphJumps[i];
			base.text.glyphs[i].transform.Translate(0f, 0.1875f * num * ratio, 0f);
		}
	}
}
