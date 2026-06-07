using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestTMPExpansion : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TMP_InputField inputField;

	public TMP_Text txt;

	public RectTransform rt;

	public TMP_Text linenum;

	public RectTransform linenum_rt;

	public float default_height;

	public float height_ratio;

	public Scrollbar scroll;

	public int jumpToLine;

	public bool mouseOver;

	public Dictionary<int, int> colored_lines;

	public bool jumpToLast;

	public GetMouse myhit;

	public int linenum_update = 1;

	private int caret = -1;

	public bool wasFocused;

	private bool wasScroll;

	private bool jumpToLast2;

	private void Start()
	{
		if (!Object.FindObjectOfType<GlobalManager>())
		{
			SetUp();
		}
	}

	public void SetUp()
	{
		inputField = GetComponent<TMP_InputField>();
		txt = inputField.textComponent;
		rt = GetComponent<RectTransform>();
		if (linenum != null)
		{
			linenum_rt = linenum.gameObject.GetComponent<RectTransform>();
		}
		default_height = (float)Screen.height * height_ratio;
		colored_lines = new Dictionary<int, int>();
		if (txt.textInfo.lineCount > 0)
		{
			float num = txt.textInfo.lineInfo[0].ascender - txt.textInfo.lineInfo[txt.textInfo.lineCount - 1].descender + 10f;
			if (num < default_height)
			{
				num = default_height;
			}
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, num);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseOver = false;
	}

	private void LateUpdate()
	{
		if (inputField == null)
		{
			SetUp();
		}
		if (caret != inputField.caretPosition)
		{
			caret = inputField.caretPosition;
			wasScroll = false;
		}
		if (txt.textInfo.lineCount > 0)
		{
			float num = txt.textInfo.lineInfo[0].ascender - txt.textInfo.lineInfo[txt.textInfo.lineCount - 1].descender + 10f;
			if (num < default_height)
			{
				num = default_height;
			}
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, num);
		}
		bool flag = true;
		int num2 = 0;
		string text = "";
		for (int i = 0; i < txt.textInfo.lineCount; i++)
		{
			if (inputField.isFocused && inputField.caretPosition >= txt.textInfo.lineInfo[i].firstCharacterIndex && inputField.caretPosition <= txt.textInfo.lineInfo[i].lastCharacterIndex)
			{
				jumpToLine = i;
			}
		}
		if (linenum_update > 0)
		{
			for (int j = 0; j < txt.textInfo.lineCount; j++)
			{
				if (flag && txt.textInfo.lineInfo[j].visibleCharacterCount > 0 && txt.text[txt.textInfo.lineInfo[j].firstVisibleCharacterIndex] != '#')
				{
					num2++;
					string text2 = "";
					if (num2 < 10)
					{
						text2 += " ";
					}
					if (num2 < 100)
					{
						text2 += " ";
					}
					text2 += num2;
					if (colored_lines.ContainsKey(j))
					{
						if (colored_lines.TryGetValue(j, out var value))
						{
							if (value == 1)
							{
								text = text + "<mark=#0000bf3f padding=0,10000,0,0>" + text2 + "</mark>";
							}
							if (value == 2)
							{
								text = text + "<mark=#00bf003f padding=0,10000,0,0>" + text2 + "</mark>";
							}
							if (value == 3)
							{
								text = text + "<mark=#bf00003f padding=0,10000,0,0>" + text2 + "</mark>";
							}
							if (value == 4)
							{
								text = text + "<mark=#7f7f7f3f padding=0,10000,0,0>" + text2 + "</mark>";
							}
						}
						else
						{
							text += text2;
						}
					}
					else
					{
						text += text2;
					}
				}
				flag = txt.text[txt.textInfo.lineInfo[j].lastCharacterIndex] == '\n';
				if (j != txt.textInfo.lineCount - 1)
				{
					text += "\n";
				}
			}
			if (linenum != null)
			{
				linenum.text = text;
			}
			linenum_update -= 2;
			wasScroll = false;
		}
		if (linenum != null)
		{
			linenum.fontSize = txt.fontSize;
			txt.gameObject.GetComponent<RectTransform>().ForceUpdateRectTransforms();
			txt.gameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
			txt.gameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		}
		if (jumpToLast2)
		{
			if (scroll.size == 1f)
			{
				scroll.value = 1f;
				jumpToLast2 = false;
			}
			if (scroll.size != 1f)
			{
				scroll.value = 0f;
				jumpToLast2 = false;
			}
		}
		if (jumpToLast)
		{
			inputField.caretPosition = inputField.textComponent.textInfo.lineInfo[txt.textInfo.lineCount - 1].lastVisibleCharacterIndex;
			jumpToLast = false;
			if (scroll.size == 1f)
			{
				scroll.value = 1f;
			}
			else
			{
				scroll.value = 0f;
			}
			jumpToLine = -1;
			jumpToLast2 = true;
			inputField.ForceLabelUpdate();
		}
		else if (jumpToLine != -1 && !wasScroll)
		{
			if (scroll.size == 1f)
			{
				scroll.value = 0f;
			}
			else
			{
				if (txt.textInfo.lineInfo[0].ascender - txt.textInfo.lineInfo[jumpToLine].ascender < (rt.sizeDelta.y - default_height) * (1f - scroll.value))
				{
					if (Input.mouseScrollDelta.y != 0f)
					{
						wasScroll = true;
					}
					else
					{
						scroll.value = 1f - (txt.textInfo.lineInfo[0].ascender - txt.textInfo.lineInfo[jumpToLine].ascender) / (rt.sizeDelta.y - default_height);
					}
				}
				if (txt.textInfo.lineInfo[jumpToLine].descender - txt.textInfo.lineInfo[txt.textInfo.lineCount - 1].descender < (rt.sizeDelta.y - default_height) * scroll.value)
				{
					if (Input.mouseScrollDelta.y != 0f)
					{
						wasScroll = true;
					}
					else
					{
						scroll.value = (txt.textInfo.lineInfo[jumpToLine].descender - txt.textInfo.lineInfo[txt.textInfo.lineCount - 1].descender) / (rt.sizeDelta.y - default_height);
					}
				}
			}
			inputField.ForceLabelUpdate();
			jumpToLine = -1;
		}
		if (inputField.isFocused)
		{
			if (Object.FindObjectOfType<GlobalManager>() != null && Object.FindObjectOfType<GlobalManager>().setting.theme)
			{
				inputField.caretColor = new Color(1f, 1f, 1f);
			}
			else
			{
				inputField.caretColor = new Color(0f, 0f, 0f);
			}
		}
		if (!inputField.isFocused && wasFocused)
		{
			inputField.DeactivateInputField();
			inputField.caretColor = new Color(0f, 0f, 0f, 0f);
		}
		wasFocused = inputField.isFocused;
		_ = base.gameObject.name == "InputField_Quest";
		if (mouseOver && scroll.size < 1f && Input.mouseScrollDelta.y != 0f)
		{
			scroll.value += Input.mouseScrollDelta.y / (1f / scroll.size - 1f) * Time.deltaTime / height_ratio;
			wasScroll = true;
			if (scroll.value > 1f)
			{
				scroll.value = 1f;
			}
			if (scroll.value < 0f)
			{
				scroll.value = 0f;
			}
		}
	}

	public void DisplayChange()
	{
		linenum_update = 2;
	}
}
