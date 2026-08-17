using System;
using System.Collections.Generic;
using Assets.Scripts.Utility.Controllers;
using Cpp2ILInjected;
using UnityEngine;

public class ControllerGlyphs : MonoBehaviour
{
	public List<InputGlyph> xboxGlyphs;

	public List<InputGlyph> playstationGlyphs;

	public List<InputGlyph> pcGlyphs;

	public Dictionary<KeyCode, Texture> xboxGlyphsDict;

	public Dictionary<KeyCode, Texture> playstationGlyphsDict;

	public Dictionary<KeyCode, Texture> pcGlyphsDict;

	public unsafe void Init()
	{
		//IL_002c: Expected O, but got Ref
		//IL_005d: Expected O, but got I
		//IL_0099: Expected O, but got Ref
		//IL_012f: Expected O, but got Ref
		//IL_00f3: Expected O, but got I
		//IL_017f: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				Dictionary<KeyCode, Texture> dictionary = xboxGlyphsDict;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+18]");
				((Dictionary<System.Int32Enum, object>)(object)dictionary).set_Item((System.Int32Enum)num, (object)0);
				continue;
			}
			((List<InputGlyph>.Enumerator*)(&enumerator))->Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			while (true)
			{
				if (enumerator.MoveNext())
				{
					bool flag2 = obj == null;
					Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator);
					if (!flag2)
					{
						dictionary2 = (Dictionary<System.Int32Enum, object>)(object)playstationGlyphsDict;
						if (playstationGlyphsDict == null)
						{
							break;
						}
						Dictionary<KeyCode, Texture> dictionary3 = playstationGlyphsDict;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+10]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+18]");
						((Dictionary<System.Int32Enum, object>)(object)dictionary3).set_Item((System.Int32Enum)num2, (object)0);
						continue;
					}
					throw new NullReferenceException();
				}
				((List<InputGlyph>.Enumerator*)(&enumerator))->Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				while (true)
				{
					if (enumerator.MoveNext())
					{
						bool flag3 = obj == null;
						Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator);
						if (!flag3)
						{
							if (pcGlyphsDict == null)
							{
								break;
							}
							Dictionary<KeyCode, Texture> dictionary4 = pcGlyphsDict;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+10]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ stack_-30+18]");
							((Dictionary<System.Int32Enum, object>)(object)dictionary4).set_Item((System.Int32Enum)num3, (object)0);
							continue;
						}
						throw new NullReferenceException();
					}
					((List<InputGlyph>.Enumerator*)(&enumerator))->Dispose();
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe Texture GetGlyph(EControllerType controller, KeyCode keycode)
	{
		//IL_0013: Expected O, but got I4
		//IL_00d3: Expected O, but got Ref
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		bool flag = controller == EControllerType.Xbox;
		Dictionary<System.Int32Enum, object> dictionary;
		if (!flag)
		{
			object obj = controller - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						goto IL_00ca;
					}
					dictionary = (Dictionary<System.Int32Enum, object>)(object)pcGlyphsDict;
				}
				else
				{
					dictionary = (Dictionary<System.Int32Enum, object>)(object)playstationGlyphsDict;
				}
				goto IL_011c;
			}
		}
		dictionary = (Dictionary<System.Int32Enum, object>)(object)xboxGlyphsDict;
		goto IL_011c;
		IL_011c:
		if (dictionary == null)
		{
			goto IL_00ca;
		}
		if (dictionary.ContainsKey((System.Int32Enum)keycode))
		{
			return (Texture)dictionary.get_Item((System.Int32Enum)keycode);
		}
		goto IL_00fd;
		IL_00ca:
		object obj3 = default(object);
		string text = ((Enum)(&obj3)).ToString();
		string text2 = "No controller glyph mapping found for " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		goto IL_00fd;
		IL_00fd:
		return null;
	}

	public ControllerGlyphs()
	{
		Dictionary<KeyCode, Texture> dictionary = new Dictionary<KeyCode, Texture>();
		xboxGlyphsDict = dictionary;
		playstationGlyphsDict = new Dictionary<KeyCode, Texture>();
		pcGlyphsDict = new Dictionary<KeyCode, Texture>();
		base._002Ector();
	}
}
