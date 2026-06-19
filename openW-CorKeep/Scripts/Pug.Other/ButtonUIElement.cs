using System.Collections.Generic;
using I2.Loc;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class ButtonUIElement : UIelement
{
	public enum ShortCutBinding
	{
		none = 0,
		sort = 1,
		sortChest = 2,
		itemLock = 3
	}

	public bool canBeClicked = true;

	public Color disabledColor = Color.white;

	public UnityEvent onLeftClick;

	public UnityEvent onRightClick;

	public UnityEvent onSelected;

	public UnityEvent onDeselected;

	public GameObject optionalSelectedMarker;

	private SpriteRenderer _optionalSelectedMarkerSr;

	public UIelement optionToSelectOnHover;

	public List<SpriteRenderer> spritesShownUnpressed;

	public List<SpriteRenderer> spritesShownPressed;

	public bool skipUpdatingSpritesColor;

	public bool showHoverTitle;

	public LocalizedString optionalTitle;

	public bool showHoverDesc;

	public LocalizedString optionalHoverDesc;

	public ShortCutBinding optionalShortCut;

	public bool adjustSpritesToFitTextSize;

	public Vector2 spritesSizePadding;

	public PugText text;

	public bool playClickSoundEffect;

	[ShowIf("playClickSoundEffect")]
	public SfxUnityInspectorFriendlyID clickSoundEffect;

	[ShowIf("playClickSoundEffect")]
	public float clickSoundPitch;

	private BoxCollider _boxCollider;

	private readonly List<Color> _unpressedDefaultColors = new List<Color>();

	private readonly List<Color> _pressedDefaultColors = new List<Color>();

	private const string SHORTCUT_STRING = "ShortCutPC";

	private string[] bindingTerms = new string[4] { "", "Sort", "QuickStack", "ToggleLocking" };

	protected virtual void Awake()
	{
		if (optionalSelectedMarker != null)
		{
			optionalSelectedMarker.SetActive(value: false);
			_optionalSelectedMarkerSr = optionalSelectedMarker.GetComponent<SpriteRenderer>();
		}
		_boxCollider = GetComponent<BoxCollider>();
		for (int i = 0; i < spritesShownUnpressed.Count; i++)
		{
			_unpressedDefaultColors.Add(spritesShownUnpressed[i].color);
		}
		for (int j = 0; j < spritesShownPressed.Count; j++)
		{
			_pressedDefaultColors.Add(spritesShownPressed[j].color);
		}
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		for (int i = 0; i < spritesShownUnpressed.Count; i++)
		{
			SpriteRenderer spriteRenderer = spritesShownUnpressed[i];
			spriteRenderer.gameObject.SetActive(!base.leftClickIsHeldDown || !canBeClicked);
			if (!skipUpdatingSpritesColor)
			{
				spriteRenderer.color = (canBeClicked ? _unpressedDefaultColors[i] : (_unpressedDefaultColors[i] * disabledColor));
			}
		}
		for (int j = 0; j < spritesShownPressed.Count; j++)
		{
			SpriteRenderer spriteRenderer2 = spritesShownPressed[j];
			spriteRenderer2.gameObject.SetActive(base.leftClickIsHeldDown && canBeClicked);
			if (!skipUpdatingSpritesColor)
			{
				spriteRenderer2.color = (canBeClicked ? _pressedDefaultColors[j] : (_pressedDefaultColors[j] * disabledColor));
			}
		}
		if (!adjustSpritesToFitTextSize || !(text != null))
		{
			return;
		}
		float num = text.dimensions.width + spritesSizePadding.x;
		num += num % 0.125f;
		float num2 = text.dimensions.height + spritesSizePadding.y;
		num2 += num2 % 0.0625f * 2f;
		Vector2 size = new Vector2(num, num2);
		foreach (SpriteRenderer item in spritesShownUnpressed)
		{
			item.size = size;
		}
		foreach (SpriteRenderer item2 in spritesShownPressed)
		{
			item2.size = size;
		}
		if (_optionalSelectedMarkerSr != null)
		{
			_optionalSelectedMarkerSr.size = size;
		}
		_boxCollider.size = new Vector3(size.x, size.y, 1f);
	}

	public void SetText(string textString)
	{
		if (!(text == null) && !(text.GetText() == textString))
		{
			text.Render(textString);
			LateUpdate();
		}
	}

	public override void OnSelected()
	{
		if (optionalSelectedMarker != null)
		{
			optionalSelectedMarker.SetActive(value: true);
		}
		if (optionToSelectOnHover != null)
		{
			Manager.menu.SelectOption(optionToSelectOnHover);
		}
		onSelected?.Invoke();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		if (optionalSelectedMarker != null)
		{
			optionalSelectedMarker.SetActive(value: false);
		}
		onDeselected?.Invoke();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (canBeClicked)
		{
			onLeftClick?.Invoke();
			if (playClickSoundEffect)
			{
				AudioManager.SfxUI(Manager.audio.InspectorFriendlySfxIDToSfxID(clickSoundEffect), clickSoundPitch, reuse: false, 1f, 0f);
			}
		}
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
		if (canBeClicked)
		{
			onRightClick?.Invoke();
		}
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (showHoverTitle)
		{
			return new TextAndFormatFields
			{
				text = optionalTitle.mTerm
			};
		}
		return base.GetHoverTitle();
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (showHoverDesc)
		{
			bool prefersJoystick = Manager.input.IsAnyGamepadConnected() && !Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse();
			bool onlyReturnShortCutForActiveController = false;
			string shortCutString = Manager.ui.GetShortCutString(bindingTerms[(int)optionalShortCut], prefersJoystick, onlyReturnShortCutForActiveController);
			if (optionalShortCut != ShortCutBinding.none && !string.IsNullOrEmpty(shortCutString))
			{
				List<TextAndFormatFields> list = new List<TextAndFormatFields>();
				list.Add(new TextAndFormatFields
				{
					text = optionalHoverDesc.mTerm,
					paddingBeneath = 0.125f
				});
				list.Add(new TextAndFormatFields
				{
					text = PugText.ProcessText("ShortCutPC", null, shouldLocalize: false, shouldLocalizeFormatFields: false),
					color = Color.white * 0.95f,
					dontLocalize = false,
					formatFields = new string[1] { shortCutString },
					dontLocalizeFormatFields = true
				});
				return list;
			}
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = optionalHoverDesc.mTerm,
					color = Color.white * 0.99f
				}
			};
		}
		return base.GetHoverDescription();
	}
}
