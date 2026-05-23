using System;
using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class TFUIUpgradeChoice : ThronefallUIElement
{
	[Serializable]
	public class Style
	{
		public float scale = 1f;

		public Color outlineColor;

		public Color bgColor;

		public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public float animationDuration = 0.5f;

		public Style(Color outlineColor, Color bgColor, AnimationCurve animationCurve, float animationDuration, float scale)
		{
			this.scale = scale;
			this.bgColor = bgColor;
			this.outlineColor = outlineColor;
			this.animationCurve = animationCurve;
			this.animationDuration = animationDuration;
		}
	}

	public class Animation
	{
		public TFUIUpgradeChoice target;

		public Style startStyle;

		public Style endStyle;

		public float clock;

		public Animation(Style startStyle, Style endStyle, TFUIUpgradeChoice target)
		{
			this.startStyle = startStyle;
			this.endStyle = endStyle;
			this.target = target;
			target.ApplyStyle(startStyle);
			target.currentAnimation = this;
		}

		public void Tick()
		{
			clock += Time.unscaledDeltaTime;
			float num = Mathf.InverseLerp(0f, endStyle.animationDuration, clock);
			float t = endStyle.animationCurve.Evaluate(num);
			target.iconImg.color = Color.Lerp(startStyle.outlineColor, endStyle.outlineColor, t);
			target.backgroundImg.color = Color.Lerp(startStyle.bgColor, endStyle.bgColor, t);
			target.backgroundImg.OutlineColor = Color.Lerp(startStyle.outlineColor, endStyle.outlineColor, t);
			target.backgroundImg.transform.localScale = Vector3.one * Mathf.LerpUnclamped(startStyle.scale, endStyle.scale, t);
			if (num >= 1f)
			{
				target.ApplyStyle(endStyle);
				target.currentAnimation = null;
			}
		}
	}

	[SerializeField]
	private Color lockedBgColor;

	[SerializeField]
	private Color lockedOutlineColor;

	[SerializeField]
	private MPImageBasic backgroundImg;

	[SerializeField]
	private Image iconImg;

	[SerializeField]
	private Sprite lockIcon;

	public AnimationCurve defaultAnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public float defaultAnimationTime = 0.3f;

	public Style focussedStyle;

	public Style selectedStyle;

	public Style focussedAndSelectedStyle;

	private Style defaultStyle;

	private bool defaultStyleInitialized;

	private Animation currentAnimation;

	private Choice choiceData;

	private Color defaultBgColor;

	private Color defaultIconColor;

	private bool locked;

	public Choice Data => choiceData;

	public bool Locked => locked;

	public Image IconImg => iconImg;

	private void Update()
	{
		if (currentAnimation != null)
		{
			currentAnimation.Tick();
		}
	}

	protected override void OnApply()
	{
	}

	protected override void OnClear()
	{
		new Animation(GetStyle(previousState), defaultStyle, this);
	}

	protected override void OnFocus()
	{
		new Animation(GetStyle(previousState), focussedStyle, this);
	}

	protected override void OnSelect()
	{
		new Animation(GetStyle(previousState), selectedStyle, this);
	}

	protected override void OnFocusAndSelect()
	{
		new Animation(GetStyle(previousState), focussedAndSelectedStyle, this);
	}

	protected override void OnHardStateSet(SelectionState selectionState)
	{
		currentAnimation = null;
		ApplyStyle(GetStyle(selectionState));
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

	private void ApplyStyle(Style style)
	{
		iconImg.color = style.outlineColor;
		backgroundImg.color = style.bgColor;
		backgroundImg.OutlineColor = style.outlineColor;
		backgroundImg.transform.localScale = Vector3.one * style.scale;
	}

	private void InitializeDefaultStyle()
	{
		defaultBgColor = backgroundImg.color;
		defaultIconColor = iconImg.color;
		defaultStyle = new Style(backgroundImg.OutlineColor, backgroundImg.color, defaultAnimationCurve, defaultAnimationTime, 1f);
		defaultStyleInitialized = true;
	}

	public void SetData(Choice _choice)
	{
		choiceData = _choice;
		bool flag = true;
		if (!_choice.CanBePicked)
		{
			flag = false;
		}
		if (_choice.disabledInThisMode)
		{
			flag = false;
		}
		if (flag)
		{
			iconImg.sprite = _choice.icon;
			return;
		}
		iconImg.sprite = lockIcon;
		iconImg.color = lockedOutlineColor;
		backgroundImg.color = lockedBgColor;
		backgroundImg.OutlineColor = lockedOutlineColor;
		selectedStyle.bgColor = lockedBgColor;
		selectedStyle.outlineColor = lockedOutlineColor;
		locked = true;
	}
}
