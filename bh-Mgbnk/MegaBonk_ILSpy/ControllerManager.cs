using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
	public ControllerGlyphs controllerGlyphs;

	public static ControllerManager Instance;

	private void Awake()
	{
		if (!(Instance != null))
		{
			Instance = this;
			controllerGlyphs.Init();
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	public unsafe bool GetGlyph(KeyCode keycode, out Texture glyph)
	{
		//IL_0133: Expected I4, but got O
		//IL_00d8: Expected O, but got Ref
		object obj;
		ref Texture reference;
		if ((object)this.controllerGlyphs != null)
		{
			Texture glyph2 = this.controllerGlyphs.GetGlyph(EControllerType.Xbox, keycode);
			reference = ref *(Texture*)glyph2;
			if (!(glyph == null))
			{
				goto IL_0111;
			}
			ControllerGlyphs controllerGlyphs = this.controllerGlyphs;
			if ((object)this.controllerGlyphs != null)
			{
				if (controllerGlyphs.pcGlyphsDict != null)
				{
					if (((Dictionary<System.Int32Enum, object>)(object)controllerGlyphs.pcGlyphsDict).ContainsKey((System.Int32Enum)keycode))
					{
						obj = ((Dictionary<System.Int32Enum, object>)(object)controllerGlyphs.pcGlyphsDict).get_Item((System.Int32Enum)keycode);
						goto IL_0174;
					}
				}
				else
				{
					object obj2 = default(object);
					string text = ((Enum)(&obj2)).ToString();
					string text2 = "No controller glyph mapping found for " + text;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				}
				obj = null;
				goto IL_0174;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0111:
		return glyph != null;
		IL_0174:
		reference = ref *(Texture*)obj;
		goto IL_0111;
	}
}
