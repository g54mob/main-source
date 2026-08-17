using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI.Bestiary;

public class UICosmicEgg : MonoBehaviour
{
	private Image _EggImage;

	private Image _EyeImage;

	private void Start()
	{
		//IL_0368: Expected O, but got F4
		//IL_0371: Invalid comparison between O and F4
		object obj2 = default(object);
		int zeroPad = default(int);
		while (true)
		{
			object obj = UnityEngine.Random.value;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			string animName = "CEggRed_i";
			if (!flag3)
			{
				animName = "CEgg_i";
			}
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 0, 5, "enemiesM", zeroPad);
			if (animationFrames != null && animationFrames._size > 0)
			{
				if (animationFrames._size <= 0)
				{
					goto IL_034a;
				}
				Sprite[] items = animationFrames._items;
				_EggImage.sprite = items[0];
				UISpriteAnimation component = _EggImage.GetComponent<UISpriteAnimation>();
				List<Sprite> sprites = component.sprites;
				int version = sprites._version + 1;
				sprites._version = version;
				sprites._size = 0;
				if (sprites._size > 0)
				{
					Array.Clear(sprites._items, 0, sprites._size);
				}
				List<object> sprites2 = (List<object>)(object)component.sprites;
				((List<object>)(object)component.sprites).InsertRange(sprites2._size, (IEnumerable<object>)animationFrames);
			}
			bool flag4 = !flag2;
			string animName2 = "CEyeRed_i";
			if (!flag4)
			{
				animName2 = "CEye_i";
			}
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName2, 0, 5, "enemiesM", zeroPad);
			if (animationFrames2 == null || animationFrames2._size <= 0)
			{
				break;
			}
			if (animationFrames2._size > 0)
			{
				Sprite[] items2 = animationFrames2._items;
				_EyeImage.sprite = items2[0];
				UISpriteAnimation component2 = _EyeImage.GetComponent<UISpriteAnimation>();
				List<Sprite> sprites3 = component2.sprites;
				int version2 = sprites3._version + 1;
				sprites3._version = version2;
				sprites3._size = 0;
				if (sprites3._size > 0)
				{
					Array.Clear(sprites3._items, 0, sprites3._size);
				}
				List<object> sprites4 = (List<object>)(object)component2.sprites;
				((List<object>)(object)component2.sprites).InsertRange(sprites4._size, (IEnumerable<object>)animationFrames2);
				break;
			}
			goto IL_034a;
			IL_034a:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public UICosmicEgg()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
