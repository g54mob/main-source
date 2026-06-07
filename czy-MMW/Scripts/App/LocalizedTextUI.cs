using System;
using Factory;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text), typeof(TextMeshProUGUI))]
public class LocalizedTextUI : MonoBehaviour, ILocalized
{
	[EnumSearch(typeof(StringId), true)]
	[HideInInspector]
	public string startingStringIdString;

	private Material _baseCustomMaterial;

	public bool ignoreLocalization;

	protected StandaloneLocString _locString;

	[SerializeField]
	protected TMP_Text _textField;

	private bool _isAlwaysRightAligned;

	private FontDatabase _fontDatabase;

	public bool isInitialized { get; protected set; }

	public TMP_Text TextField => _textField;

	public StandaloneLocString LocString
	{
		get
		{
			return _locString;
		}
		set
		{
			_locString = value;
			if (ignoreLocalization)
			{
				return;
			}
			if (_locString == null)
			{
				_textField.text = "";
			}
			else if (Diagnostics.Verify(_textField != null, base.gameObject, "{0} doesn't have a textfield!", base.name))
			{
				_textField.text = _locString.ToString();
				if (isInitialized)
				{
					UpdateFont();
				}
			}
		}
	}

	private bool IsLeftAligned
	{
		get
		{
			if (_textField.alignment != TextAlignmentOptions.Left && _textField.alignment != TextAlignmentOptions.TopLeft)
			{
				return _textField.alignment == TextAlignmentOptions.BottomLeft;
			}
			return true;
		}
	}

	private bool IsRightAligned
	{
		get
		{
			if (_textField.alignment != TextAlignmentOptions.Right && _textField.alignment != TextAlignmentOptions.TopRight)
			{
				return _textField.alignment == TextAlignmentOptions.BottomRight;
			}
			return true;
		}
	}

	public bool SetStringId(IScope scope, StringId stringId)
	{
		if (isInitialized)
		{
			StandaloneLocString standaloneLocString = StandaloneLocString.CreateString(scope, stringId);
			if (Diagnostics.Verify(standaloneLocString != null, "Could not find string for {0}.", stringId))
			{
				LocString = standaloneLocString;
				return true;
			}
			return false;
		}
		startingStringIdString = stringId.ToString();
		return true;
	}

	public bool SetStringId(IScope scope, string stringId)
	{
		if (!Enum.TryParse<StringId>(stringId, out var result))
		{
			return false;
		}
		return SetStringId(scope, result);
	}

	public void UpdateFont()
	{
		Locale locale = _locString.Locale;
		if (locale != null)
		{
			FontDefinition font = _fontDatabase.GetFont(locale.Charset);
			if (font != null && font.FontAsset != _textField.font)
			{
				_textField.font = font.FontAsset;
				if (_baseCustomMaterial != null)
				{
					_textField.fontSharedMaterial = font.GetCustomMaterial(_textField.fontStyle, _baseCustomMaterial);
				}
			}
		}
		_textField.isRightToLeftText = _locString.IsRightToLeft();
		if (!_isAlwaysRightAligned && ((_textField.isRightToLeftText && IsLeftAligned) || (!_textField.isRightToLeftText && IsRightAligned)))
		{
			SwapAlignment();
		}
	}

	private void SwapAlignment()
	{
		switch (_textField.alignment)
		{
		case TextAlignmentOptions.TopLeft:
			_textField.alignment = TextAlignmentOptions.TopRight;
			break;
		case TextAlignmentOptions.TopRight:
			_textField.alignment = TextAlignmentOptions.TopLeft;
			break;
		case TextAlignmentOptions.Left:
			_textField.alignment = TextAlignmentOptions.Right;
			break;
		case TextAlignmentOptions.Right:
			_textField.alignment = TextAlignmentOptions.Left;
			break;
		case TextAlignmentOptions.BottomLeft:
			_textField.alignment = TextAlignmentOptions.BottomRight;
			break;
		case TextAlignmentOptions.BottomRight:
			_textField.alignment = TextAlignmentOptions.BottomLeft;
			break;
		}
	}

	public virtual void Awake()
	{
		_textField = _textField ?? GetComponent<TMP_Text>();
		if (_textField.fontSharedMaterial != _textField.font.material)
		{
			_baseCustomMaterial = _textField.fontSharedMaterial;
		}
		isInitialized = false;
		_isAlwaysRightAligned = IsRightAligned;
	}

	public virtual void HandleParentAllocated(IScope parentScope)
	{
		_fontDatabase = parentScope.Get<FontDatabase>();
		isInitialized = true;
		StringId result = StringId.None;
		if (Enum.TryParse<StringId>(startingStringIdString, out result) && result != StringId.None)
		{
			StandaloneLocString locString = StandaloneLocString.CreateString(parentScope, result);
			LocString = locString;
		}
	}

	public void Unregister()
	{
		isInitialized = false;
	}

	public void HandleLocaleChanged(Locale newLocale)
	{
		if (_locString != null)
		{
			_locString.ChangeLocale(newLocale);
			LocString = _locString;
		}
	}
}
