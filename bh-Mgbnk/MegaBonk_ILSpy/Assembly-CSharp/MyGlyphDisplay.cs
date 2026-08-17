using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyGlyphDisplay : MonoBehaviour
{
	public Image i_glyph;

	public TextMeshProUGUI t_text;

	private RectTransform rectTransform;

	public GameObject hoverOverlay;

	public bool autoHeight = true;

	public bool autoWidth;

	private ActionElementMap elementMap;

	public void Hover(bool isHovering)
	{
		hoverOverlay.SetActive(isHovering);
	}

	public void SetAction(string action)
	{
		Player player = MyInputManager.GetPlayer();
		Controller lastActiveController = MyInputManager.GetLastActiveController();
		Player.ControllerHelper controllers = player.controllers;
		ControllerMap map = controllers.maps.GetMap(lastActiveController, "Default", "Default");
		if (map != null)
		{
			ActionElementMap[] elementMapsWithAction = map.GetElementMapsWithAction(action);
			if (elementMapsWithAction != null)
			{
				object obj = Enumerable.FirstOrDefault((IEnumerable<object>)elementMapsWithAction);
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 124 Invalid \"Jump target not found in method: 0x180370DD0\"");
		throw new NullReferenceException();
	}

	public void Set(ActionElementMap elementMap)
	{
		if (rectTransform == null)
		{
			RectTransform component = GetComponent<RectTransform>();
			rectTransform = component;
		}
		this.elementMap = elementMap;
		if (elementMap != null)
		{
			RefreshGlyphSize();
			return;
		}
		i_glyph.enabled = false;
		t_text.enabled = false;
	}

	private void RefreshGlyphSize()
	{
		//IL_0161: Invalid comparison between O and F4
		//IL_017c: Invalid comparison between O and F4
		if (elementMap == null)
		{
			return;
		}
		object elementIdentifierGlyph = elementMap.elementIdentifierGlyph;
		bool flag = elementIdentifierGlyph == null;
		UnityEngine.Object obj = null;
		if (!flag)
		{
			bool flag2 = (object)elementIdentifierGlyph.GetType() != typeof(Sprite);
			object obj2 = null;
			if (!flag2)
			{
				obj2 = elementIdentifierGlyph;
			}
			bool flag3 = obj2 == null;
			obj = (UnityEngine.Object)obj2;
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				throw new NullReferenceException();
			}
		}
		bool flag4 = obj == null;
		t_text.enabled = flag4;
		bool flag5 = obj != null;
		i_glyph.enabled = flag5;
		if (!(obj != null))
		{
			string elementIdentifierName = elementMap.elementIdentifierName;
			t_text.text = elementIdentifierName;
			return;
		}
		i_glyph.sprite = (Sprite)obj;
		RectTransform rectTransform = i_glyph.rectTransform;
		Vector2 sizeDelta = rectTransform.sizeDelta;
		object obj3 = default(object);
		if (((!autoHeight || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)60f)) && !autoWidth) || System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref sizeDelta) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)245f))
		{
		}
		RectTransform rectTransform2 = i_glyph.rectTransform;
		Vector2 sizeDelta2 = default(Vector2);
		rectTransform2.sizeDelta = sizeDelta2;
	}
}
