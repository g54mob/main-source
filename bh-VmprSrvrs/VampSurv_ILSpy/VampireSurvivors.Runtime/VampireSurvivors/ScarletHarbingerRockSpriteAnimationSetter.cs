using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class ScarletHarbingerRockSpriteAnimationSetter : MonoBehaviour
{
	private unsafe void Awake()
	{
		//IL_008a: Expected O, but got Ref
		//IL_00a6: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_02ca: Expected I, but got O
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected I, but got Unknown
		//IL_02e5: Expected O, but got I
		//IL_0181: Expected O, but got I4
		//IL_0123: Expected O, but got I
		//IL_0161: Expected O, but got I4
		SpriteAnimation component = GetComponent<SpriteAnimation>();
		int num = 0;
		object obj = default(object);
		while (true)
		{
			List<FrameAnimationData> defaultAnimations = component._defaultAnimations;
			if (defaultAnimations._size <= 0)
			{
				break;
			}
			FrameAnimationData[] items = defaultAnimations._items;
			FrameAnimationData frameAnimationData = items[0];
			List<object> frames = (List<object>)(object)frameAnimationData._frames;
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
			object obj2 = 2 - text._stringLength;
			string text3;
			if ((nint)obj2 > 0)
			{
				string text2 = string.FastAllocateString(2);
				object obj3 = text2 + 20;
				if ((nint)obj2 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"rep stosw\"");
				}
				int num2 = text._stringLength + text._stringLength;
				object obj4 = obj2 * 2;
				byte* ptr = (byte*)(nint)(obj3 + obj4);
				byte* ptr2 = (byte*)(nint)(text + 20);
				object obj5 = (object)(ptr - (nuint)ptr2);
				object obj7;
				if ((nint)obj5 >= num2)
				{
					object obj6 = (object)(ptr2 - (nuint)ptr);
					if ((nint)obj6 >= num2)
					{
						Buffer.Memcpy(ptr, ptr2, num2);
						text3 = text2;
						obj7 = 0;
						goto IL_0301;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				text3 = text2;
				obj7 = 0;
			}
			else
			{
				text3 = text;
				object obj7 = 0;
			}
			goto IL_0301;
			IL_0301:
			string spriteName = "rockBreak_" + text3;
			Sprite sprite = SpriteManager.GetSprite(spriteName);
			int version = frames._version + 1;
			frames._version = version;
			object[] items2 = frames._items;
			if (frames._size >= items2.Length)
			{
				frames.AddWithResize((object)sprite);
			}
			else
			{
				int size = frames._size + 1;
				frames._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
			if (num >= 23)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public ScarletHarbingerRockSpriteAnimationSetter()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
