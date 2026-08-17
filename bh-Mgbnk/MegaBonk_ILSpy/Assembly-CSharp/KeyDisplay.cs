using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
	public RawImage background;

	public TextMeshProUGUI text;

	public TextSizer textSizer;

	public RawImage glyph;

	private static Dictionary<KeyCode, string> buttonMappings = new Dictionary<KeyCode, string>
	{
		{
			(System.Int32Enum)330,
			(object)"A"
		},
		{
			(System.Int32Enum)331,
			(object)"B"
		},
		{
			(System.Int32Enum)332,
			(object)"X"
		},
		{
			(System.Int32Enum)333,
			(object)"Y"
		},
		{
			(System.Int32Enum)334,
			(object)"LB"
		},
		{
			(System.Int32Enum)335,
			(object)"RB"
		},
		{
			(System.Int32Enum)336,
			(object)"Back"
		},
		{
			(System.Int32Enum)337,
			(object)"Start"
		},
		{
			(System.Int32Enum)338,
			(object)"L3"
		},
		{
			(System.Int32Enum)339,
			(object)"R3"
		},
		{
			(System.Int32Enum)340,
			(object)"LT"
		},
		{
			(System.Int32Enum)341,
			(object)"RT"
		}
	};

	public void SetKey(KeyCode key)
	{
		if (!ControllerManager.Instance.GetGlyph(key, out var texture))
		{
			SetNonGlyph(key);
			return;
		}
		GameObject gameObject = background.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = glyph.gameObject;
		gameObject2.SetActive(value: true);
		glyph.texture = texture;
		GameObject gameObject3 = glyph.gameObject;
		gameObject3.SetActive(value: true);
	}

	private void SetGlyph(Texture glyphTexture)
	{
		GameObject gameObject = background.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = glyph.gameObject;
		gameObject2.SetActive(value: true);
		glyph.texture = glyphTexture;
		GameObject gameObject3 = glyph.gameObject;
		gameObject3.SetActive(value: true);
	}

	private unsafe void SetNonGlyph(KeyCode keycode)
	{
		//IL_0205: Expected O, but got Ref
		GameObject gameObject = background.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = glyph.gameObject;
		gameObject2.SetActive(value: false);
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string text2;
		if (text == "-1")
		{
			text2 = "MWheel Down";
		}
		else if (text == "-2")
		{
			text2 = "MWheel Up";
		}
		else
		{
			bool flag = text.StartsWith("Mouse");
			bool flag2 = !flag;
			string text3 = text;
			if (!flag2)
			{
				object obj2 = "Mouse";
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v21+10]");
				string s = text.Substring(0);
				bool flag3 = int.TryParse(s, out var _);
				bool flag4 = !flag3;
				text3 = text;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string text4 = $"Mouse{arg}";
					text3 = text4;
				}
			}
			text2 = text3.Replace("Alpha", "");
		}
		this.text.text = text2;
		float deltaTime = Time.deltaTime;
		Invoke("Refresh", deltaTime);
		textSizer.Recalculate();
		textSizer.Refresh();
		this.text.ForceMeshUpdate();
		textSizer.Recalculate();
		textSizer.Refresh();
	}

	private void Refresh()
	{
		RectTransform rectTransform = background.rectTransform;
		RectTransform rectTransform2 = text.rectTransform;
		Vector2 sizeDelta = rectTransform2.sizeDelta;
		rectTransform.sizeDelta = sizeDelta;
	}

	public unsafe static string GetKeyName(KeyCode key)
	{
		//IL_017c: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		if (text == "-1")
		{
			return "MWheel Down";
		}
		if (text == "-2")
		{
			return "MWheel Up";
		}
		if (text != null)
		{
			bool flag = text.StartsWith("Mouse");
			bool flag2 = !flag;
			string text2 = text;
			if (!flag2)
			{
				object obj2 = "Mouse";
				if ("Mouse" == null)
				{
					goto IL_0165;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v8+10]");
				string s = text.Substring(0);
				bool flag3 = int.TryParse(s, out var _);
				bool flag4 = !flag3;
				text2 = text;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string text3 = $"Mouse{arg}";
					bool flag5 = text3 == null;
					text2 = text3;
					if (flag5)
					{
						goto IL_0165;
					}
				}
			}
			return text2.Replace("Alpha", "");
		}
		goto IL_0165;
		IL_0165:
		return (string)(object)new NullReferenceException();
	}

	public unsafe static string GetControllerButtonName(KeyCode keycode)
	{
		//IL_0077: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		if (text.StartsWith("Joystick"))
		{
			if (buttonMappings == null)
			{
				return (string)(object)new NullReferenceException();
			}
			if (((Dictionary<System.Int32Enum, object>)(object)buttonMappings).TryGetValue((System.Int32Enum)keycode, out object value))
			{
				return (string)value;
			}
		}
		return text;
	}
}
