using System;
using MPUIKIT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TFUIEnemy : ThronefallUIElement
{
	[Serializable]
	public class Style
	{
		public float scale = 1f;

		public Color outlineColor;

		public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public float animationDuration = 0.5f;

		public Style(Color outlineColor, AnimationCurve animationCurve, float animationDuration, float scale)
		{
			this.scale = scale;
			this.outlineColor = outlineColor;
			this.animationCurve = animationCurve;
			this.animationDuration = animationDuration;
		}
	}

	public class Animation
	{
		public TFUIEnemy target;

		public Style startStyle;

		public Style endStyle;

		public float clock;

		public Animation(Style startStyle, Style endStyle, TFUIEnemy target)
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
			target.backgroundImg.OutlineColor = Color.Lerp(startStyle.outlineColor, endStyle.outlineColor, t);
			target.backgroundEliteImg.OutlineColor = target.backgroundImg.OutlineColor;
			target.numberBg.color = target.backgroundImg.OutlineColor;
			target.backgroundImg.transform.localScale = Vector3.one * Mathf.LerpUnclamped(startStyle.scale, endStyle.scale, t);
			if (num >= 1f)
			{
				target.ApplyStyle(endStyle);
				target.currentAnimation = null;
			}
		}
	}

	public Color defaultBGColor;

	public Color highlightBGColor;

	public Color defaultIconColor;

	public Color highlightIconColor;

	private Color originalIconColor;

	[SerializeField]
	private MPImageBasic backgroundImg;

	[SerializeField]
	private MPImageBasic backgroundEliteImg;

	[SerializeField]
	private MPImageBasic numberBg;

	private MPImageBasic originalBackground;

	[SerializeField]
	private Image iconImg;

	[SerializeField]
	private Sprite lockIcon;

	public TextMeshProUGUI numberText;

	public AnimationCurve defaultAnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public float defaultAnimationTime = 0.3f;

	public Style focussedStyle;

	public Style selectedStyle;

	public Style focussedAndSelectedStyle;

	private Style defaultStyle;

	private bool defaultStyleInitialized;

	private bool selectedForLoadout;

	private Animation currentAnimation;

	private WaveEnemyInfo enemyInfoData;

	private bool locked;

	public WaveEnemyInfo Data => enemyInfoData;

	public bool Locked => locked;

	public Image IconImg => iconImg;

	public Color GetBackgroundColor
	{
		get
		{
			if (!selectedForLoadout)
			{
				return defaultBGColor;
			}
			return highlightBGColor;
		}
	}

	public Color GetIconColor
	{
		get
		{
			if (!selectedForLoadout)
			{
				return defaultIconColor;
			}
			return highlightIconColor;
		}
	}

	public Color GetDefaultOutlineColor()
	{
		if (defaultStyle == null)
		{
			InitializeDefaultStyle();
		}
		if (defaultStyle != null)
		{
			return defaultStyle.outlineColor;
		}
		return Color.white;
	}

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
		backgroundImg.OutlineColor = style.outlineColor;
		backgroundEliteImg.OutlineColor = style.outlineColor;
		numberBg.color = style.outlineColor;
		backgroundImg.transform.localScale = Vector3.one * style.scale;
	}

	private void InitializeDefaultStyle()
	{
		defaultStyle = new Style(backgroundImg.OutlineColor, defaultAnimationCurve, defaultAnimationTime, 1f);
		defaultStyleInitialized = true;
	}

	public void SetDataSimple(WaveEnemyInfo e)
	{
		if (originalBackground == null)
		{
			originalBackground = backgroundImg;
			originalIconColor = defaultIconColor;
		}
		enemyInfoData = e;
		iconImg.sprite = e.enemyIcon;
		defaultBGColor = backgroundImg.color;
		defaultIconColor = iconImg.color;
		numberText.text = e.enemyCount.ToString();
		backgroundEliteImg.enabled = e.eliteEnemy;
		originalBackground.enabled = !e.eliteEnemy;
		if (e.eliteEnemy)
		{
			backgroundImg = backgroundEliteImg;
			iconImg.color = Color.yellow;
			defaultIconColor = iconImg.color;
		}
		else
		{
			backgroundImg = originalBackground;
			iconImg.color = originalIconColor;
			defaultIconColor = iconImg.color;
		}
	}
}
