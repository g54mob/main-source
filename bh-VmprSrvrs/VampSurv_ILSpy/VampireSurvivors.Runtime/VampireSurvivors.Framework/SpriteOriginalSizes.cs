using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;

namespace VampireSurvivors.Framework;

public class SpriteOriginalSizes
{
	private static Dictionary<string, float2> _originalSizesDict;

	public static float2 GetOriginalSize(string spriteName)
	{
		//IL_00b5: Expected O, but got I4
		//IL_004d: Expected O, but got I
		//IL_0087: Expected O, but got I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00af: Expected O, but got I
		Dictionary<string, float2> originalSizesDict = _originalSizesDict;
		int num = _originalSizesDict.FindEntry(spriteName);
		if (num >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v3 (System.Collections.Generic.Dictionary`2<System.String, Unity.Mathematics.float2>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v8+18]");
			if ((nint)num < (nint)0)
			{
				object obj2 = num + 2;
				object obj3 = obj2 * 2;
				object obj4 = obj2 + obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v8+v167 @ rax_v13*8]");
				return (float2)0;
			}
			return (float2)new IndexOutOfRangeException();
		}
		return (float2)0;
	}

	static SpriteOriginalSizes()
	{
		Dictionary<string, float2> originalSizesDict = null;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		_originalSizesDict = originalSizesDict;
	}
}
