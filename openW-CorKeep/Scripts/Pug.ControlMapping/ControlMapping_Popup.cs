using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlMapping_Popup : RadicalMenu
{
	public struct DisplayConfig
	{
		public bool Localize;

		public TextManager.FontFace TitleFontFace;

		public TextManager.FontFace MessageFontFace;

		public TextManager.FontFace OptionsFontFace;

		public float TextMaxWidth;

		public Color HighlightColor;
	}

	[Flags]
	public enum TargetElement
	{
		None = 0,
		Title = 2,
		Message = 4,
		Option1 = 8,
		Option2 = 0x10,
		Option3 = 0x20
	}

	[Header("References")]
	[SerializeField]
	private PugText _title;

	[SerializeField]
	private PugText _message;

	[SerializeField]
	private List<PopUpOption> _options;

	[SerializeField]
	private PugText _timeoutText;

	[SerializeField]
	private GameObject _timeoutContainer;

	private Action<PopupResponse> _resultCallback;

	private int _timeoutValue;

	protected override void Awake()
	{
		_timeoutText.localize = true;
		foreach (PopUpOption option in _options)
		{
			option.PopupOptionActivated += OnPopupOptionActivated;
		}
	}

	public void Show(string title, string message, DisplayConfig displayConfig, List<string> options, Action<PopupResponse> resultCallback, Dictionary<TargetElement, List<string>> formatFields = null, bool localizeFormatFields = false)
	{
		_resultCallback = resultCallback;
		ApplyDisplayConfig(displayConfig);
		SetupTexts(title, message, formatFields, localizeFormatFields);
		SetupOptions(options, formatFields, localizeFormatFields);
		if (menuOptions.Count > 0)
		{
			SelectOptionIndex(0);
		}
		base.gameObject.SetActive(value: true);
		Manager.menu.PushMenu(this);
	}

	public void Hide()
	{
		Cleanup();
		if (base.gameObject.activeInHierarchy && Manager.menu.GetTopMenu().Equals(this))
		{
			Manager.menu.PopMenu();
		}
	}

	public void ShowTimeout(bool show)
	{
		_timeoutContainer.SetActive(show);
	}

	public void UpdateTimeout(int secondsUntilTimeout)
	{
		if (secondsUntilTimeout != _timeoutValue)
		{
			_timeoutText.SetText("ControlMapper/Timeout");
			_timeoutText.textSuffix = ": " + secondsUntilTimeout;
			_timeoutText.Render();
		}
	}

	public override void Deactivate(bool pop)
	{
		base.gameObject.SetActive(value: false);
		OnPopupOptionActivated(null, new PopupResponse(confirm: false));
		base.Deactivate(pop);
	}

	private void OnPopupOptionActivated(PopUpOption source, PopupResponse response)
	{
		_resultCallback?.Invoke(response);
	}

	private void Cleanup()
	{
		ShowTimeout(show: false);
		base.selectedIndex = -1;
		_resultCallback = null;
		_timeoutValue = 0;
		menuOptions.Clear();
	}

	private void SetupTexts(string title, string message, Dictionary<TargetElement, List<string>> formatFields, bool localizeFormatFields)
	{
		_title.gameObject.SetActive(value: true);
		_message.gameObject.SetActive(value: true);
		_title.localize = true;
		_title.localizePlaceholders = localizeFormatFields;
		if (formatFields != null && formatFields.TryGetValue(TargetElement.Title, out var value))
		{
			_title.formatFields = value.ToArray();
		}
		_title.Render(title, rewindEffectAnims: false, force: true);
		_message.localize = true;
		_message.localizePlaceholders = localizeFormatFields;
		if (formatFields != null && formatFields.TryGetValue(TargetElement.Message, out var value2))
		{
			_message.formatFields = value2.ToArray();
		}
		_message.Render(message, rewindEffectAnims: false, force: true);
	}

	private void SetupOptions(List<string> options, Dictionary<TargetElement, List<string>> formatFields, bool localizeFormatFields)
	{
		if (options == null)
		{
			base.selectedIndex = -1;
		}
		if (options != null && options.Count > _options.Count)
		{
			Debug.LogWarning(string.Format("{0}.{1}: there are more requested option texts ({2}) than supported ({3}). Some of the options will not work!", "ControlMapping_Popup", "SetupOptions", options.Count, _options.Count));
		}
		for (int i = 0; i < _options.Count; i++)
		{
			bool flag = options != null && i < options.Count;
			_options[i].forceDeactive = !flag;
			_options[i].labelText.gameObject.SetActive(flag);
			_options[i].labelText.localizePlaceholders = localizeFormatFields;
			_options[i].labelText.localize = true;
			if (flag)
			{
				if (formatFields != null && formatFields.TryGetValue((TargetElement)(i + 2), out var value))
				{
					_options[i].labelText.formatFields = value.ToArray();
				}
				_options[i].labelText.Render(options[i], rewindEffectAnims: false, force: true);
				menuOptions.Add(_options[i]);
			}
		}
		UpdatePosition();
	}

	private void ApplyDisplayConfig(DisplayConfig displayConfig)
	{
		_title.maxWidth = (_message.maxWidth = displayConfig.TextMaxWidth);
		_title.localize = (_message.localize = displayConfig.Localize);
		_options.ForEach(delegate(PopUpOption option)
		{
			option.labelText.localize = displayConfig.Localize;
		});
		_title.SetFont(displayConfig.TitleFontFace);
		_message.SetFont(displayConfig.MessageFontFace);
		foreach (PopUpOption option in _options)
		{
			option.labelText.SetFont(displayConfig.OptionsFontFace);
		}
	}
}
