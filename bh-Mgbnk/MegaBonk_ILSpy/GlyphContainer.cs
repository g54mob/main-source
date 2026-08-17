using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlyphContainer : MonoBehaviour
{
	public RawImage glyph;

	public TextMeshProUGUI manualText;

	public GameObject manualParent;

	public TextSizer textSizer;

	public unsafe void Set(KeyCode keycode)
	{
		//IL_00c0: Expected O, but got Ref
		ControllerManager instance = ControllerManager.Instance;
		Texture texture = instance.controllerGlyphs.GetGlyph(EControllerType.Xbox, keycode);
		UnityEngine.Object obj = default(UnityEngine.Object);
		if (obj == null)
		{
			ControllerGlyphs controllerGlyphs = instance.controllerGlyphs;
			if (controllerGlyphs.pcGlyphsDict != null)
			{
				if (((Dictionary<System.Int32Enum, object>)(object)controllerGlyphs.pcGlyphsDict).ContainsKey((System.Int32Enum)keycode))
				{
					object obj2 = ((Dictionary<System.Int32Enum, object>)(object)controllerGlyphs.pcGlyphsDict).get_Item((System.Int32Enum)keycode);
				}
			}
			else
			{
				object obj3 = default(object);
				string text = ((Enum)(&obj3)).ToString();
				string text2 = "No controller glyph mapping found for " + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			}
		}
		UnityEngine.Object obj4 = default(UnityEngine.Object);
		if (obj4 == null)
		{
			manualParent.SetActive(value: true);
			GameObject gameObject = glyph.gameObject;
			gameObject.SetActive(value: false);
			string keyName = KeyDisplay.GetKeyName(keycode);
			manualText.text = keyName;
		}
		else
		{
			manualParent.SetActive(value: false);
			GameObject gameObject2 = glyph.gameObject;
			gameObject2.SetActive(value: true);
			glyph.texture = (Texture)obj4;
		}
		if (textSizer != null)
		{
			textSizer.Refresh();
			textSizer.Recalculate();
			Transform root = base.transform;
			UiUtility.RebuildUi(root);
		}
	}

	private void SetGlyph(Texture texture)
	{
		manualParent.SetActive(value: false);
		GameObject gameObject = glyph.gameObject;
		gameObject.SetActive(value: true);
		glyph.texture = texture;
	}

	private void SetNonGlyph(KeyCode keycode)
	{
		manualParent.SetActive(value: true);
		GameObject gameObject = glyph.gameObject;
		gameObject.SetActive(value: false);
		string keyName = KeyDisplay.GetKeyName(keycode);
		manualText.text = keyName;
	}
}
