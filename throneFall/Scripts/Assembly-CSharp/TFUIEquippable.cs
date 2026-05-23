using System;
using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class TFUIEquippable : ThronefallUIElement
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
		public TFUIEquippable target;

		public Style startStyle;

		public Style endStyle;

		public float clock;

		public Animation(Style startStyle, Style endStyle, TFUIEquippable target)
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
			target.backgroundImg.transform.localScale = Vector3.one * Mathf.LerpUnclamped(startStyle.scale, endStyle.scale, t);
			if (num >= 1f)
			{
				target.ApplyStyle(endStyle);
				target.currentAnimation = null;
			}
		}
	}

	[SerializeField]
	private Color weaponBgColor;

	[SerializeField]
	private Color perkBgColor;

	[SerializeField]
	private Color mutatorBgColor;

	[SerializeField]
	private Color lockedBgColor;

	[SerializeField]
	private Color lockedOutlineColor;

	[SerializeField]
	private Color weaponHighlightColor;

	[SerializeField]
	private Color perkHightlightColor;

	[SerializeField]
	private Color mutatorHighlightColor;

	[SerializeField]
	private Color etDefaultMid;

	[SerializeField]
	private Color etDefaultHigh;

	[SerializeField]
	private Color highlightIconColor;

	public MPImage backgroundImg;

	public Image iconImg;

	[SerializeField]
	private Sprite lockIcon;

	[SerializeField]
	private bool additionalColorsForOutlineAndIcon;

	[SerializeField]
	private Color unpickedIconAndOutlineColor;

	public AnimationCurve defaultAnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public float defaultAnimationTime = 0.3f;

	public Style focussedStyle;

	public Style selectedStyle;

	public Style focussedAndSelectedStyle;

	private Style defaultStyle;

	private bool defaultStyleInitialized;

	private bool selectedForLoadout;

	private Animation currentAnimation;

	private Equippable equippableData;

	private Color highlightBGColor;

	private Color defaultBGColor;

	private Color defaultIconColor;

	private bool locked;

	public Equippable Data => equippableData;

	private bool isWeapon => equippableData is EquippableWeapon;

	private bool isPerk => equippableData is EquippablePerk;

	private bool isMutator => equippableData is EquippableMutation;

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
		if (backgroundImg == null)
		{
			Debug.LogError("backround is null", base.gameObject);
		}
		backgroundImg.OutlineColor = style.outlineColor;
		backgroundImg.transform.localScale = Vector3.one * style.scale;
	}

	private void InitializeDefaultStyle()
	{
		defaultStyle = new Style(backgroundImg.OutlineColor, defaultAnimationCurve, defaultAnimationTime, 1f);
		defaultStyleInitialized = true;
	}

	public void SetData(Equippable e, bool loadoutIsFixed, bool overrideShow = false, LevelInfo levelInfo = null)
	{
		equippableData = e;
		bool flag = e.IsUnlocked || (loadoutIsFixed && levelInfo.fixedLoadout.Contains(e));
		bool flag2 = loadoutIsFixed && !levelInfo.fixedLoadout.Contains(e);
		if ((flag && !flag2) || overrideShow)
		{
			iconImg.sprite = e.icon;
			if (isWeapon)
			{
				backgroundImg.color = weaponBgColor;
				highlightBGColor = weaponHighlightColor;
			}
			if (isPerk)
			{
				backgroundImg.color = perkBgColor;
				highlightBGColor = perkHightlightColor;
			}
			if (isMutator)
			{
				backgroundImg.color = mutatorBgColor;
				highlightBGColor = mutatorHighlightColor;
			}
		}
		else if (flag && flag2)
		{
			iconImg.sprite = e.icon;
			iconImg.color = lockedOutlineColor;
			backgroundImg.color = lockedBgColor;
			backgroundImg.OutlineColor = lockedOutlineColor;
		}
		else
		{
			iconImg.sprite = lockIcon;
			iconImg.color = lockedOutlineColor;
			backgroundImg.color = lockedBgColor;
			backgroundImg.OutlineColor = lockedOutlineColor;
			locked = true;
		}
		defaultBGColor = backgroundImg.color;
		defaultIconColor = iconImg.color;
	}

	public void SetDataEternalTrials(Equippable e)
	{
		equippableData = e;
		bool flag = false;
		EquippablePerk equippablePerk = e as EquippablePerk;
		if (equippablePerk != null && EternalTrialsRunManager.CurrentRun.disabledPerks.Contains(equippablePerk))
		{
			flag = true;
		}
		if (!flag)
		{
			iconImg.sprite = e.icon;
			if (isWeapon)
			{
				backgroundImg.color = weaponBgColor;
				highlightBGColor = weaponHighlightColor;
			}
			if (isPerk)
			{
				backgroundImg.color = perkBgColor;
				highlightBGColor = perkHightlightColor;
			}
			if (isMutator)
			{
				backgroundImg.color = mutatorBgColor;
				highlightBGColor = mutatorHighlightColor;
			}
			iconImg.color = etDefaultMid;
			highlightIconColor = etDefaultHigh;
			backgroundImg.OutlineColor = etDefaultMid;
		}
		else
		{
			iconImg.sprite = e.icon;
			iconImg.color = lockedOutlineColor;
			highlightIconColor = lockedOutlineColor;
			backgroundImg.OutlineColor = lockedOutlineColor;
			backgroundImg.color = lockedBgColor;
			highlightBGColor = lockedBgColor;
		}
		defaultBGColor = backgroundImg.color;
		defaultIconColor = iconImg.color;
		InitializeDefaultStyle();
	}

	public void SetDataSimple(Equippable e)
	{
		equippableData = e;
		iconImg.sprite = e.icon;
		if (isWeapon)
		{
			backgroundImg.color = weaponBgColor;
			highlightBGColor = weaponHighlightColor;
		}
		if (isPerk)
		{
			backgroundImg.color = perkBgColor;
			highlightBGColor = perkHightlightColor;
		}
		if (isMutator)
		{
			backgroundImg.color = mutatorBgColor;
			highlightBGColor = mutatorHighlightColor;
		}
		defaultBGColor = backgroundImg.color;
		defaultIconColor = iconImg.color;
	}

	public void Pick()
	{
		backgroundImg.color = highlightBGColor;
		iconImg.color = highlightIconColor;
		selectedForLoadout = true;
	}

	public void UnPick()
	{
		backgroundImg.color = defaultBGColor;
		iconImg.color = defaultIconColor;
		selectedForLoadout = false;
	}
}
