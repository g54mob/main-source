using System;
using I2.Loc;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TFUITextButton : ThronefallUIElement
{
	[Serializable]
	public class Style
	{
		public Color color = Color.white;

		public float fontSize = 30f;

		public string prefix;

		public string suffix;

		public TMP_FontAsset font;

		public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public float animationDuration = 0.5f;

		public Style(Color color, float fontSize, TMP_FontAsset font, AnimationCurve animationCurve, float animationDuration)
		{
			this.color = color;
			this.fontSize = fontSize;
			this.font = font;
			this.animationCurve = animationCurve;
			this.animationDuration = animationDuration;
		}
	}

	public class Animation
	{
		public TFUITextButton target;

		public Style startStyle;

		public Style endStyle;

		public float clock;

		public Animation(Style startStyle, Style endStyle, TFUITextButton target)
		{
			this.startStyle = startStyle;
			this.endStyle = endStyle;
			this.target = target;
			target.ApplyStyle(startStyle);
			target.targetText.font = endStyle.font;
			if (!target.ignorePreAndSuffix)
			{
				target.targetText.text = endStyle.prefix + target.originalString + endStyle.suffix;
			}
			target.currentAnimation = this;
		}

		public void Tick()
		{
			clock += Time.unscaledDeltaTime;
			float num = Mathf.InverseLerp(0f, endStyle.animationDuration, clock);
			float t = endStyle.animationCurve.Evaluate(num);
			target.targetText.color = Color.Lerp(startStyle.color, endStyle.color, t);
			target.targetText.fontSize = Mathf.LerpUnclamped(startStyle.fontSize, endStyle.fontSize, t);
			if (num >= 1f)
			{
				target.ApplyStyle(endStyle);
				target.currentAnimation = null;
			}
		}
	}

	private Style defaultStyle;

	private bool defaultStyleInitialized;

	public AnimationCurve defaultAnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public float defaultAnimationTime = 0.3f;

	public Style focussedStyle;

	public Style selectedStyle;

	public Style focussedAndSelectedStyle;

	public Style overrideStyle;

	public bool ignorePreAndSuffix;

	public bool applyOverrideStyle;

	private TextMeshProUGUI targetText;

	private string originalString;

	private Animation currentAnimation;

	private Localize locComponent;

	private void Start()
	{
		locComponent = GetComponent<Localize>();
		if (locComponent != null)
		{
			locComponent.LocalizeEvent.AddListener(UpdateOriginalStringLocalized);
		}
	}

	private void Update()
	{
		if (currentAnimation != null)
		{
			currentAnimation.Tick();
		}
	}

	protected Style GetStyle(SelectionState state)
	{
		if (!defaultStyleInitialized)
		{
			InitializeDefaultStyle();
		}
		return state switch
		{
			SelectionState.Default => defaultStyle, 
			SelectionState.Focussed => focussedStyle, 
			SelectionState.Selected => selectedStyle, 
			SelectionState.FocussedAndSelected => focussedAndSelectedStyle, 
			_ => defaultStyle, 
		};
	}

	protected override void OnApply()
	{
	}

	protected override void OnClear()
	{
		new Animation(GetStyle(previousState), applyOverrideStyle ? overrideStyle : defaultStyle, this);
	}

	protected override void OnFocus()
	{
		new Animation(GetStyle(previousState), applyOverrideStyle ? overrideStyle : focussedStyle, this);
	}

	protected override void OnSelect()
	{
		new Animation(GetStyle(previousState), applyOverrideStyle ? overrideStyle : selectedStyle, this);
	}

	protected override void OnFocusAndSelect()
	{
		new Animation(GetStyle(previousState), applyOverrideStyle ? overrideStyle : focussedAndSelectedStyle, this);
	}

	protected override void OnHardStateSet(SelectionState selectionState)
	{
		currentAnimation = null;
		ApplyStyle(GetStyle(selectionState));
	}

	private void ApplyStyle(Style style)
	{
		targetText.color = style.color;
		targetText.fontSize = style.fontSize;
		targetText.font = style.font;
		if (!ignorePreAndSuffix)
		{
			targetText.text = style.prefix + originalString + style.suffix;
		}
	}

	private void InitializeDefaultStyle()
	{
		if (!defaultStyleInitialized)
		{
			targetText = GetComponent<TextMeshProUGUI>();
			UpdateOriginalStringLocalized();
			defaultStyle = new Style(targetText.color, targetText.fontSize, targetText.font, defaultAnimationCurve, defaultAnimationTime);
			defaultStyleInitialized = true;
		}
	}

	private void UpdateOriginalStringLocalized()
	{
		if (locComponent == null)
		{
			locComponent = GetComponent<Localize>();
		}
		if (locComponent == null)
		{
			originalString = targetText.text;
		}
		else
		{
			originalString = TextTranslator.Translate(locComponent.Term);
		}
	}

	public void SetOriginalString(string original)
	{
		if (!defaultStyleInitialized)
		{
			InitializeDefaultStyle();
		}
		originalString = original;
		targetText.text = original;
		OnHardStateSet(currentState);
	}
}
