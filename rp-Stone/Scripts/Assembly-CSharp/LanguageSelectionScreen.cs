using System;
using UnityEngine;

public class LanguageSelectionScreen : PopUpModalScreen
{
	[Serializable]
	public class Language
	{
		public string name;

		public string id;

		public string title;

		public string playLabel;
	}

	public int columnCount = 2;

	public AsciiString title;

	public Language[] languages;

	public DialogButton buttonPrototype;

	public DialogButton confirmationButton;

	private DialogButton[] buttons;

	private int selectedIndex = -1;

	public static LanguageSelectionScreen singleton { get; private set; }

	public override void Show()
	{
		base.Show();
		AnalyticsMacros.LanguageScreenSeen();
		selectedIndex = -1;
		if (buttons != null)
		{
			return;
		}
		buttons = new DialogButton[languages.Length];
		for (int i = 0; i < languages.Length; i++)
		{
			Language language = languages[i];
			DialogButton dialogButton = UnityEngine.Object.Instantiate(buttonPrototype);
			buttons[i] = dialogButton;
			dialogButton.label.SetValue(language.name);
			if (Localization.singleton.HasLanguage(language.id))
			{
				dialogButton.label.color = ColorConstants.white;
				dialogButton.OnPressed += HandleButtonPressed;
				dialogButton.enabled = true;
			}
			else
			{
				dialogButton.label.color = ColorConstants.grey;
				dialogButton.enabled = false;
			}
		}
	}

	private void HandleButtonPressed(DialogButton btn)
	{
		Language language = null;
		for (int i = 0; i < buttons.Length; i++)
		{
			if (btn == buttons[i])
			{
				selectedIndex = i;
				language = languages[i];
				_ = language.id;
				break;
			}
		}
		if (language != null)
		{
			title.SetValue(language.title);
			if (selectedIndex < languages.Length)
			{
				confirmationButton.label.SetValue(language.playLabel);
			}
		}
	}

	public bool IsDone()
	{
		return base.currentState == State.Disabled;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		int num = 0;
		while (buttons != null && num < buttons.Length)
		{
			if (buttons[num].enabled)
			{
				buttons[num].UpdateTic();
			}
			num++;
		}
		if (selectedIndex >= 0)
		{
			confirmationButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (buttons == null || buttons.Length == 0)
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionY + (r.height >> 1) + (int)transitionOffsetY;
		int num = 1;
		int num2 = Mathf.CeilToInt((float)buttons.Length / (float)columnCount);
		int width = buttons[0].Width;
		int height = buttons[0].Height;
		int num3 = -(width * columnCount + num * (columnCount - 1)) / 2;
		int num4 = -height * num2 / 2;
		int num5 = num3;
		int num6 = 0;
		for (int i = 0; i < buttons.Length; i++)
		{
			DialogButton dialogButton = buttons[i];
			if (selectedIndex == i)
			{
				dialogButton.edgeSymbols.color = ColorConstants.white;
			}
			else
			{
				dialogButton.edgeSymbols.color = ColorConstants.thirdGrey;
			}
			dialogButton.Draw(r, offsetX + num5, offsetY + num4);
			SetSizeOverrideLanguage(dialogButton.label, languages[i].id, dialogButton.lastDrawnX, dialogButton.lastDrawnY);
			num6++;
			if (num6 == columnCount)
			{
				num6 = 0;
				num5 = num3;
				num4 += height;
			}
			else
			{
				num5 += width + num;
			}
		}
		num4 = buttons[0].lastDrawnY - 3;
		title.Draw(r, offsetX, num4);
		if (selectedIndex >= 0)
		{
			int offsetY2 = buttons[buttons.Length - 1].lastDrawnY + height;
			confirmationButton.Draw(r, offsetX, offsetY2);
		}
		if (selectedIndex >= 0)
		{
			string id = languages[selectedIndex].id;
			SetSizeOverrideLanguage(title, id, offsetX, num4);
			SetSizeOverrideLanguage(confirmationButton.label, id, confirmationButton.lastDrawnX, confirmationButton.lastDrawnY);
		}
		else
		{
			SetSizeOverrideLanguage(title, Te.id, offsetX, num4);
			SetSizeOverrideLanguage(confirmationButton.label, Te.id, confirmationButton.lastDrawnX, confirmationButton.lastDrawnY);
		}
	}

	private void SetSizeOverrideLanguage(AsciiString label, string langId, int offsetX, int offsetY)
	{
		offsetX += label.PositionX - label.Length / 2;
		offsetY += label.PositionY;
		for (int i = 0; i < label.Length; i++)
		{
			ForeignLanguageCell cellAt = ForeignLanguageRenderer.singleton.GetCellAt(offsetX + i, offsetY);
			if (cellAt != null)
			{
				cellAt.SetSizeOverrideLanguage(langId);
			}
		}
	}

	private void HandleConfirmationPressed(DialogButton btn)
	{
		if (selectedIndex >= 0 && selectedIndex < languages.Length)
		{
			string id = languages[selectedIndex].id;
			if (Localization.singleton.HasLanguage(id))
			{
				Localization.singleton.SetLanguage(id);
				AdditionalSettings.selectedLanguage = id;
				Hide();
				AnalyticsMacros.LanguageSelected();
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		confirmationButton.OnPressed += HandleConfirmationPressed;
	}

	protected override void OnDestroy()
	{
		confirmationButton.OnPressed -= HandleConfirmationPressed;
		int num = 0;
		while (buttons != null && num < buttons.Length)
		{
			buttons[num].OnPressed -= HandleButtonPressed;
			num++;
		}
		base.OnDestroy();
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
	}
}
