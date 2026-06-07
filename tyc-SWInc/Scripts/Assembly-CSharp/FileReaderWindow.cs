using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FileReaderWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Text MainText;

	public Button TogglePrefab;

	public Transform ButtonPanel;

	public RectTransform Content;

	public RectTransform Viewport;

	public Scrollbar VertScroll;

	public Scrollbar HorScroll;

	public string[][] FileContent;

	public string[][] FileContent2;

	public int CurrentFile;

	private int _maxLine = 1;

	private int _lines = 1;

	private Regex _gex;

	public static string[] SyntaxColors = new string[6] { "00CC00", "00CC00", "CC0000", "AA00AA", "AAAA00", "0000FF" };

	public static string[] Highlight = new string[101]
	{
		"abstract", "add", "as", "ascending", "async", "await", "base", "bool", "break", "by",
		"byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default",
		"delegate", "descending", "do", "double", "dynamic", "else", "enum", "equals", "explicit", "extern",
		"false", "finally", "fixed", "float", "for", "foreach", "from", "get", "global", "goto",
		"group", "if", "implicit", "in", "int", "interface", "internal", "into", "is", "join",
		"let", "lock", "long", "namespace", "new", "null", "object", "on", "operator", "orderby",
		"out", "override", "params", "partial", "private", "protected", "public", "readonly", "ref", "remove",
		"return", "sbyte", "sealed", "select", "set", "short", "sizeof", "stackalloc", "static", "string",
		"struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
		"unsafe", "ushort", "using", "value", "var", "virtual", "void", "volatile", "where", "while",
		"yield"
	};

	public void Show(string[] files)
	{
		_gex = new Regex("(/\\*[\\s\\S]*?\\*/)|(//[^\\n]+)|(\\@?\\$?\\\"[^\\\"]*?\\\")|(#.+)|\\b([0-9]+(?:\\.[0-9]+)?f?d?u?)\\b|\\b(" + string.Join("|", Highlight.SelectInPlace(delegate(string x)
		{
			object obj = x ?? "";
			if (obj == null)
			{
				obj = "";
			}
			return (string)obj;
		})) + ")\\b");
		FileContent = new string[files.Length][];
		FileContent2 = new string[files.Length][];
		for (int num = 0; num < files.Length; num++)
		{
			string text = File.ReadAllText(files[num]);
			text = text.Replace("<", "〈").Replace(">", "〉");
			string input = _gex.Replace(text, CodeMatch);
			FileContent[num] = text.SplitByNewLines(StringSplitOptions.None);
			FileContent2[num] = input.SplitByNewLines(StringSplitOptions.None);
		}
		for (int num2 = 0; num2 < FileContent.Length; num2++)
		{
			Button button = UnityEngine.Object.Instantiate(TogglePrefab);
			int i1 = num2;
			button.onClick.AddListener(delegate
			{
				SetContent(i1);
			});
			button.GetComponentInChildren<Text>().text = Path.GetFileName(files[num2]);
			button.transform.SetParent(ButtonPanel, false);
		}
		SetContent(0);
		Window.Show();
	}

	public void WindowSizeChanged()
	{
		_lines = Mathf.FloorToInt(Content.rect.height / (float)GetLineHeight());
		HorScroll.size = Mathf.Clamp01((Viewport.rect.width - 32f) / (float)_maxLine);
		HorScroll.value = 0f;
		UpdateContent();
	}

	private int GetLineHeight()
	{
		return Mathf.CeilToInt((float)MainText.fontSize / (float)MainText.font.fontSize * (float)MainText.font.lineHeight * MainText.lineSpacing);
	}

	public void SetContent(int i)
	{
		CurrentFile = i;
		_maxLine = FileContent[CurrentFile].MaxSafeInt(GetLineWidth, 1);
		Content.sizeDelta = new Vector2(_maxLine, Content.sizeDelta.y);
		_lines = Mathf.FloorToInt(Content.rect.height / (float)GetLineHeight());
		VertScroll.numberOfSteps = Mathf.Max(0, FileContent[i].Length - _lines);
		VertScroll.size = Mathf.Clamp01((float)_lines / (float)FileContent[i].Length);
		VertScroll.value = 0f;
		HorScroll.size = Mathf.Clamp01((Viewport.rect.width - 32f) / (float)_maxLine);
		HorScroll.value = 0f;
		UpdateContent();
		Content.anchoredPosition = new Vector2(4f, Content.anchoredPosition.y);
		Canvas.ForceUpdateCanvases();
	}

	private int GetLineWidth(string t)
	{
		int num = 0;
		for (int i = 0; i < t.Length; i++)
		{
			CharacterInfo info;
			if (MainText.font.GetCharacterInfo(t[i], out info, MainText.fontSize, MainText.fontStyle))
			{
				num += info.advance;
			}
		}
		return num;
	}

	private string GetContent()
	{
		string[] array = FileContent2[CurrentFile];
		int num = Mathf.FloorToInt(VertScroll.value * (float)Mathf.Max(0, array.Length - _lines));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = num; i <= num + _lines && i < array.Length; i++)
		{
			stringBuilder.AppendLine(array[i]);
		}
		return stringBuilder.ToString();
	}

	private string CodeMatch(Match m)
	{
		for (int i = 0; i < SyntaxColors.Length; i++)
		{
			if (m.Groups[i + 1].Success)
			{
				return string.Format("<Color=#{0}>{1}</Color>", SyntaxColors[i], m.Groups[i + 1].Value.Replace("\n", string.Format("</Color>\n<Color=#{0}>", SyntaxColors[i])));
			}
		}
		return m.Value;
	}

	private void UpdateContent()
	{
		MainText.text = GetContent();
	}

	public void VertScrollChanged()
	{
		UpdateContent();
	}

	public void HorScrollChanged()
	{
		Content.anchoredPosition = new Vector2(4 - Mathf.FloorToInt(HorScroll.value * Mathf.Max(0f, (float)_maxLine - (Viewport.rect.width - 32f))), Content.anchoredPosition.y);
	}

	public void OnScroll(BaseEventData eData)
	{
		PointerEventData pointerEventData = (PointerEventData)eData;
		VertScroll.value -= pointerEventData.scrollDelta.y / (float)Mathf.Max(1, FileContent[CurrentFile].Length - _lines);
	}
}
