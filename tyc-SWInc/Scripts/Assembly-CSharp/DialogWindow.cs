using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialogWindow : MonoBehaviour
{
	public struct DialogParams
	{
		public DialogType Icon;

		public DialogType Audio;

		public DialogType Color;

		public Color? AColor;

		public string AIcon;

		public DialogParams(DialogType icon)
		{
			Icon = icon;
			Audio = icon;
			Color = icon;
			AColor = null;
			AIcon = null;
		}

		public DialogParams(DialogType icon, DialogType audio, DialogType color)
		{
			Icon = icon;
			Audio = icon;
			Color = icon;
			AColor = null;
			AIcon = null;
		}

		public DialogParams(DialogType audio, DialogType color, string aIcon)
		{
			Icon = audio;
			Audio = audio;
			Color = color;
			AColor = null;
			AIcon = aIcon;
		}

		public DialogParams(DialogType audio, Color aColor, string aIcon)
		{
			Icon = audio;
			Audio = audio;
			Color = audio;
			AColor = aColor;
			AIcon = aIcon;
		}
	}

	public enum DialogType
	{
		Information = 0,
		Warning = 1,
		Error = 2,
		Question = 3
	}

	private bool _waitForReturn;

	public static float ForceWidth = 340f;

	public GUIWindow Window;

	public Text DialogText;

	public GameObject ButtonPanel;

	public GameObject ButtonPrefab;

	public Action OKAction;

	public Action CancelAction;

	public Sprite[] Icons;

	public Color[] Colors;

	public Image TopPanel;

	public Image IconPanel;

	public Image Icon;

	public Sprite Left;

	public Sprite Middle;

	public Sprite Right;

	public Sprite Bottom;

	public void Show(string msg, bool nonModal, DialogType type, params KeyValuePair<string, Action>[] buttons)
	{
		Show(msg, nonModal, new DialogParams(type), buttons);
	}

	public void Show(string msg, bool nonModal, string icon, Color color, DialogType soundFX, params KeyValuePair<string, Action>[] buttons)
	{
		Show(msg, nonModal, new DialogParams(soundFX, color, icon), buttons);
	}

	public void Show(string msg, bool nonModal, string icon, DialogType color, DialogType soundFX, params KeyValuePair<string, Action>[] buttons)
	{
		Show(msg, nonModal, new DialogParams(soundFX, color, icon), buttons);
	}

	public void Show(string msg, bool nonModal, DialogParams param, params KeyValuePair<string, Action>[] buttons)
	{
		if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter) || (Window.Modal && Input.GetKey(KeyCode.Escape)))
		{
			_waitForReturn = true;
		}
		if (msg == null)
		{
			msg = "";
		}
		switch (param.Audio)
		{
		case DialogType.Information:
			UISoundFX.PlaySFX("MessageNeutral");
			break;
		case DialogType.Warning:
			UISoundFX.PlaySFX("MessageIssue");
			break;
		case DialogType.Error:
			UISoundFX.PlaySFX("MessageWarning");
			break;
		case DialogType.Question:
			UISoundFX.PlaySFX("MessageGood");
			break;
		}
		Icon.sprite = ((param.AIcon != null) ? ObjectDatabase.GetIcon(param.AIcon) : Icons[(int)param.Icon]);
		IconPanel.color = param.AColor ?? Colors[(int)param.Color];
		Window.Modal = !nonModal;
		Window.StartHidden = false;
		Window.Show();
		DialogText.text = msg;
		RectTransform component = Window.GetComponent<RectTransform>();
		float num = ForceWidth;
		int lines;
		float maxWidth;
		int num2 = CountMsgLen(msg, out lines, out maxWidth);
		do
		{
			component.sizeDelta = new Vector2(num, Mathf.Min(Screen.height, Mathf.Max(Mathf.Ceil((float)(num2 * 8 + 20) / num) * 18f, lines * 14) + 80f));
			if (num > maxWidth + 68f)
			{
				break;
			}
			num += 128f;
		}
		while (component.sizeDelta.y > (float)(Screen.height - 128) && num < (float)(Screen.width - 128));
		component.sizeDelta = new Vector2(Mathf.Clamp(component.sizeDelta.x, 32f, Screen.width - 128), Mathf.Clamp(component.sizeDelta.y, 32f, Screen.height - 128));
		Window.MinSize = component.sizeDelta;
		component.anchoredPosition = new Vector2((float)Screen.width / Options.UISize / 2f - component.rect.width / 2f, (float)(-Screen.height) / Options.UISize / 2f + component.rect.height / 2f);
		if (buttons == null || buttons.Length == 0)
		{
			GameObject obj = UnityEngine.Object.Instantiate(ButtonPrefab);
			Button component2 = obj.GetComponent<Button>();
			component2.GetComponent<Image>().sprite = Bottom;
			component2.GetComponentInChildren<Text>().text = "OK".Loc();
			CancelAction = (OKAction = delegate
			{
				Window.Close();
			});
			component2.onClick.AddListener(delegate
			{
				Window.Close();
			});
			obj.transform.SetParent(ButtonPanel.transform, false);
		}
		else
		{
			OKAction = buttons[0].Value;
			CancelAction = ((buttons.Length > 1) ? buttons[buttons.Length - 1].Value : OKAction);
			for (int num3 = 0; num3 < buttons.Length; num3++)
			{
				KeyValuePair<string, Action> keyValuePair = buttons[num3];
				GameObject obj2 = UnityEngine.Object.Instantiate(ButtonPrefab);
				Button component3 = obj2.GetComponent<Button>();
				Image component4 = component3.GetComponent<Image>();
				if (buttons.Length == 1)
				{
					component4.sprite = Bottom;
				}
				else
				{
					component4.sprite = ((num3 == 0) ? Left : ((num3 == buttons.Length - 1) ? Right : Middle));
				}
				component3.GetComponentInChildren<Text>().text = keyValuePair.Key.LocTry();
				Action action = keyValuePair.Value;
				component3.onClick.AddListener(delegate
				{
					action();
				});
				obj2.transform.SetParent(ButtonPanel.transform, false);
			}
		}
		ButtonPanel.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputHorizontal();
		ButtonPanel.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputVertical();
		ButtonPanel.GetComponent<HorizontalLayoutGroup>().SetLayoutHorizontal();
		ButtonPanel.GetComponent<HorizontalLayoutGroup>().SetLayoutVertical();
	}

	private int CountMsgLen(string msg, out int lines, out float maxWidth)
	{
		StringBuilder stringBuilder = new StringBuilder();
		maxWidth = 0f;
		lines = 1;
		int num = 0;
		bool flag = true;
		foreach (char c in msg)
		{
			if (c == '\n')
			{
				maxWidth = Mathf.Max(maxWidth, DialogText.GetLineWidth(stringBuilder.ToString()));
				stringBuilder.Clear();
				lines++;
			}
			else
			{
				stringBuilder.Append(c);
			}
			if (flag)
			{
				if (c == '<')
				{
					flag = false;
				}
				else
				{
					num++;
				}
			}
			else if (c == '>')
			{
				flag = true;
			}
		}
		maxWidth = Mathf.Max(maxWidth, DialogText.GetLineWidth(stringBuilder.ToString()));
		return num;
	}

	private void Update()
	{
		if (OKAction == null || !Window.IsActiveWindow)
		{
			return;
		}
		if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Joystick1Button0))
		{
			if (_waitForReturn)
			{
				_waitForReturn = false;
				return;
			}
			OKAction();
		}
		if ((Window.Modal && Input.GetKeyUp(KeyCode.Escape)) || Input.GetKeyUp(KeyCode.Joystick1Button1))
		{
			if (_waitForReturn)
			{
				_waitForReturn = false;
			}
			else
			{
				CancelAction();
			}
		}
	}

	public void Demo(string msg)
	{
		Show(msg, false, DialogType.Information, null);
	}
}
