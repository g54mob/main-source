using System;
using UnityEngine;

public class TypedMessageFormatter
{
	protected class FormattedText
	{
		public string color { get; set; }

		public string text { get; set; }

		public override string ToString()
		{
			if (text != null)
			{
				if (text.Length < 30)
				{
					return text;
				}
				return text.Substring(0, 30);
			}
			return string.Empty;
		}
	}

	private const float THINKING_DOT_DELAY = 0.4f;

	private const int THINKING_DOT_COUNT = 4;

	protected FormattedText[] logTextArray;

	private bool isTextFullyDisplayed;

	private bool isShowingThinkingDots;

	private float timerThinkingDotDelay;

	private int countThinkingDotsShown;

	private bool hasYNConditionalShown;

	private string conditionalResult = string.Empty;

	private bool isCursorShowing;

	private float timerPromptCursor;

	private string conditionalVariable = string.Empty;

	private int _currentTextPosition;

	private int currentTextIndex;

	private string previousCharacterColor = string.Empty;

	public bool isYNConditionalShowing { get; private set; }

	public void Initalize()
	{
		isTextFullyDisplayed = false;
		_currentTextPosition = 0;
		currentTextIndex = 0;
	}

	public void SetRawText(string text)
	{
		SetFullText(text);
	}

	public bool Update(bool onlyAllowSkip, bool disableTypingSound, ref string logText)
	{
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && !isYNConditionalShowing)
		{
			Input.ResetInputAxes();
			isShowingThinkingDots = false;
			if (isTextFullyDisplayed)
			{
				return true;
			}
			GameAudio.Stop2DSFX(GameAudio.SoundEnum.BIOSText1);
			isTextFullyDisplayed = true;
			previousCharacterColor = string.Empty;
			int num = logTextArray.Length;
			logText = string.Empty;
			string text = string.Empty;
			for (int i = 0; i < num; i++)
			{
				int length = logTextArray[i].text.Length;
				for (int j = 0; j < length; j++)
				{
					bool flag = false;
					char c = logTextArray[i].text[j];
					if (c == 'Ç')
					{
						logText += string.Empty.PadLeft(3, '.');
						flag = true;
					}
					else if (c == 'È')
					{
						int num2 = logTextArray[i].text.IndexOf('É', j);
						if (!hasYNConditionalShown)
						{
							isYNConditionalShowing = true;
							conditionalVariable = logTextArray[i].text.Substring(j + 1, num2 - j - 1);
							timerPromptCursor = 0.5f;
							logText += "_";
							isCursorShowing = true;
							isTextFullyDisplayed = false;
							currentTextIndex = logTextArray.Length - 1;
							break;
						}
						flag = true;
						logText = logText + conditionalResult + "\r\n";
						j = num2;
					}
					else if (c == 'Ê' || c == 'Ë')
					{
						flag = true;
					}
					if (flag)
					{
						continue;
					}
					if (!string.IsNullOrEmpty(logTextArray[i].color))
					{
						if (logTextArray[i].color == text && logText.EndsWith("</color>"))
						{
							logText = logText.Substring(0, logText.Length - "</color>".Length);
							logText = logText + c + "</color>";
						}
						else
						{
							string text2 = logText;
							logText = text2 + logTextArray[i].color + c + "</color>";
						}
						text = logTextArray[i].color;
					}
					else
					{
						logText += c;
					}
				}
				if (isYNConditionalShowing)
				{
					break;
				}
			}
			if (onlyAllowSkip && !isYNConditionalShowing)
			{
				return true;
			}
		}
		if (!onlyAllowSkip)
		{
			if (isShowingThinkingDots)
			{
				timerThinkingDotDelay -= Time.deltaTime;
				if (timerThinkingDotDelay <= 0f)
				{
					countThinkingDotsShown++;
					if (countThinkingDotsShown < 4)
					{
						logText += ".";
						timerThinkingDotDelay = 0.4f;
						GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSTextSingle, true);
					}
					else
					{
						isShowingThinkingDots = false;
						timerThinkingDotDelay = 0f;
						countThinkingDotsShown = 0;
					}
				}
			}
			else if (isYNConditionalShowing)
			{
				timerPromptCursor -= Time.deltaTime;
				if (timerPromptCursor <= 0f)
				{
					if (isCursorShowing)
					{
						if (logText.Length > 0)
						{
							logText = logText.Substring(0, logText.Length - 1);
						}
					}
					else
					{
						logText += "_";
					}
					isCursorShowing = !isCursorShowing;
					timerPromptCursor = 0.5f;
				}
				if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					string[] array = conditionalVariable.Split(':');
					int num3 = array.Length;
					for (int k = 0; k < num3; k++)
					{
						string[] array2 = array[k].Split('=');
						if (array2[0].ToLower() == "y")
						{
							AddFullText(LogManager.GetLogFromResource("Data/ShipsLogs/" + array2[1], false));
						}
					}
					if (isCursorShowing && logText.Length > 0)
					{
						logText = logText.Substring(0, logText.Length - 1);
					}
					conditionalResult = "y";
					logText += "y\r\n";
					isYNConditionalShowing = false;
					hasYNConditionalShown = true;
					currentTextIndex++;
					_currentTextPosition = 0;
				}
				else if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.Escape))
				{
					string[] array3 = conditionalVariable.Split(':');
					int num4 = array3.Length;
					for (int l = 0; l < num4; l++)
					{
						string[] array4 = array3[l].Split('=');
						if (array4[0].ToLower() == "n")
						{
							AddFullText(LogManager.GetLogFromResource("Data/ShipsLogs/" + array4[1], false));
						}
					}
					if (isCursorShowing)
					{
						logText = logText.Substring(0, logText.Length - 1);
					}
					conditionalResult = "n";
					logText += "n\r\n";
					isYNConditionalShowing = false;
					hasYNConditionalShown = true;
					currentTextIndex++;
					_currentTextPosition = 0;
				}
			}
			else if (!isTextFullyDisplayed)
			{
				bool flag2 = false;
				if (logTextArray[currentTextIndex] != null && logTextArray[currentTextIndex].text != null && _currentTextPosition >= logTextArray[currentTextIndex].text.Length)
				{
					if (currentTextIndex == logTextArray.Length - 1)
					{
						GameAudio.Stop2DSFX(GameAudio.SoundEnum.BIOSText1);
						isTextFullyDisplayed = true;
						previousCharacterColor = string.Empty;
					}
					else
					{
						currentTextIndex++;
						_currentTextPosition = 0;
					}
				}
				if (!isTextFullyDisplayed && logTextArray[currentTextIndex].text != null)
				{
					int num5 = Mathf.Min(_currentTextPosition + 10, logTextArray[currentTextIndex].text.Length);
					while (_currentTextPosition < num5)
					{
						string empty = string.Empty;
						if (!string.IsNullOrEmpty(logTextArray[currentTextIndex].color) && logTextArray[currentTextIndex].color == previousCharacterColor && logText.EndsWith("</color>"))
						{
							logText = logText.Substring(0, logText.Length - "</color>".Length);
							empty = logTextArray[currentTextIndex].text[_currentTextPosition].ToString();
						}
						else
						{
							if (!string.IsNullOrEmpty(previousCharacterColor))
							{
								int num6 = 0;
								num6++;
							}
							empty = logTextArray[currentTextIndex].color + logTextArray[currentTextIndex].text[_currentTextPosition];
						}
						previousCharacterColor = logTextArray[currentTextIndex].color;
						if (empty[0] == 'Ç')
						{
							logText += ".";
							_currentTextPosition++;
							isShowingThinkingDots = true;
							timerThinkingDotDelay = 0.4f;
							countThinkingDotsShown = 1;
							GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSTextSingle, true);
							flag2 = true;
							break;
						}
						if (empty[0] == 'È')
						{
							isYNConditionalShowing = true;
							int num7 = logTextArray[currentTextIndex].text.IndexOf('É', _currentTextPosition);
							conditionalVariable = logTextArray[currentTextIndex].text.Substring(_currentTextPosition + 1, num7 - _currentTextPosition - 1);
							timerPromptCursor = 0.5f;
							logText += "_";
							isCursorShowing = true;
							break;
						}
						if (empty[0] == 'Ê' || empty[0] == 'Ë')
						{
							empty = "\0";
						}
						if (!string.IsNullOrEmpty(logTextArray[currentTextIndex].color))
						{
							logText = logText + empty + "</color>";
						}
						else
						{
							logText += empty;
						}
						_currentTextPosition++;
					}
				}
				if (!disableTypingSound && !isTextFullyDisplayed && !flag2)
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.BIOSText1, true);
				}
			}
		}
		return isTextFullyDisplayed;
	}

	protected void SetFullText(string text)
	{
		logTextArray = new FormattedText[0];
		AddFullText(text);
	}

	public void CompleteText(ref string logText)
	{
		isShowingThinkingDots = false;
		if (isTextFullyDisplayed)
		{
			return;
		}
		GameAudio.Stop2DSFX(GameAudio.SoundEnum.BIOSText1);
		isTextFullyDisplayed = true;
		previousCharacterColor = string.Empty;
		int num = logTextArray.Length;
		logText = string.Empty;
		for (int i = 0; i < num; i++)
		{
			int length = logTextArray[i].text.Length;
			for (int j = 0; j < length; j++)
			{
				bool flag = false;
				char c = logTextArray[i].text[j];
				if (c == 'Ç')
				{
					logText += string.Empty.PadLeft(3, '.');
					flag = true;
				}
				else if (c == 'È')
				{
					int num2 = logTextArray[i].text.IndexOf('É', j);
					if (!hasYNConditionalShown)
					{
						isYNConditionalShowing = true;
						conditionalVariable = logTextArray[i].text.Substring(j + 1, num2 - j - 1);
						timerPromptCursor = 0.5f;
						logText += "_";
						isCursorShowing = true;
						isTextFullyDisplayed = false;
						currentTextIndex = logTextArray.Length - 1;
						break;
					}
					flag = true;
					logText = logText + conditionalResult + "\r\n";
					j = num2;
				}
				else if (c == 'Ê' || c == 'Ë')
				{
					flag = true;
				}
				if (!flag)
				{
					if (!string.IsNullOrEmpty(logTextArray[i].color))
					{
						string text = logText;
						logText = text + logTextArray[i].color + c + "</color>";
					}
					else
					{
						logText += c;
					}
				}
			}
			if (isYNConditionalShowing)
			{
				break;
			}
		}
	}

	public void AddFullText(string text)
	{
		bool flag = false;
		text = text.Replace("\t", "     ");
		int num = logTextArray.Length - 1;
		flag = true;
		Array.Resize(ref logTextArray, logTextArray.Length + 1);
		num = logTextArray.Length - 1;
		logTextArray[num] = new FormattedText();
		if (text.ToLower().Contains("<color") && text.Contains(">"))
		{
			string text2 = text;
			string text3 = text2;
			string empty = string.Empty;
			do
			{
				bool flag2 = false;
				int num2 = text3.IndexOf("<color");
				if (num == 0 && num2 == 0)
				{
					flag2 = true;
				}
				empty = text3.Substring(0, num2);
				text3 = text3.Substring(num2);
				num2 = 0;
				int num3 = text3.IndexOf('>');
				if (num3 > num2)
				{
					Color cONSOLE_GREEN = GlobalSettings.Constants.CONSOLE_GREEN;
					if (empty.Length > 0)
					{
						logTextArray[num].text = empty;
						empty = text3.Substring(num3 + 1, text3.Length - num3 - 1);
					}
					if (logTextArray[num].text != null)
					{
						Array.Resize(ref logTextArray, logTextArray.Length + 1);
						num = logTextArray.Length - 1;
						logTextArray[num] = new FormattedText();
					}
					int num4 = text3.IndexOf('=');
					if (num4 < num3 - 1)
					{
						int num5 = num3 - num4;
						string color = text3.Substring(num2, num3 + 1);
						logTextArray[num].color = color;
						text3 = text3.Substring(num3 + 1);
					}
					else
					{
						Debug.LogError(string.Format("Issue in log file while trying to parse the {0} color variable - using default", text2.Substring(num2, num3)));
					}
					num3 = text3.IndexOf("</color>");
					if (num3 > num2)
					{
						logTextArray[num].text = text3.Substring(num2, num3);
						text3 = text3.Substring(num3 + "</color>".Length);
						Array.Resize(ref logTextArray, logTextArray.Length + 1);
						num = logTextArray.Length - 1;
						logTextArray[num] = new FormattedText();
					}
					else
					{
						logTextArray[num].text = text3;
						text3 = string.Empty;
					}
				}
				else
				{
					text3 = string.Empty;
				}
			}
			while (text3.Contains("<color"));
			if (text3.Length > 0)
			{
				logTextArray[num].text = text3;
			}
		}
		else
		{
			if (!flag)
			{
				Array.Resize(ref logTextArray, logTextArray.Length + 1);
				num = logTextArray.Length - 1;
				logTextArray[num] = new FormattedText();
			}
			logTextArray[num].text = text;
		}
		int num6 = 0;
		num6++;
	}
}
