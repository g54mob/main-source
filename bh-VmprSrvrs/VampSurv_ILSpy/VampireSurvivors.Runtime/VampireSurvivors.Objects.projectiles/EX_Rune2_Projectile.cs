using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Rune2_Projectile : EX_Rune1_Projectile
{
	public override List<string> ParticleFrames
	{
		get
		{
			List<string> list = new List<string>();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxGray.png");
					}
					else
					{
						int num = list._size + 1;
						list._size = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version2 = list._version + 1;
					list._version = version2;
					string[] items2 = list._items;
					if (list._items != null)
					{
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxGrayInverted.png");
							return list;
						}
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						return list;
					}
				}
			}
			return (List<string>)(object)new NullReferenceException();
		}
	}

	public unsafe override void MakeSpriteAnimation()
	{
		//IL_010f: Expected O, but got I4
		//IL_010f: Expected I4, but got O
		//IL_014b: Expected O, but got Ref
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("_runes_0", 2, 6, pivot, text, num, flag);
		GameObject gameObject = _renderer.gameObject;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		SpriteAnimation spriteAnimation = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
		_spriteAnimation = spriteAnimation;
		_spriteAnimation.CleanAnimations();
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		ArcadeSprite arcadeSprite = setTintFill(isEnabled: true, 16777215u);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
		object obj = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(_renderer, isEnabled: true, (Color?)(object)(&obj));
		ArcadeSprite arcadeSprite2 = setAlpha(0.65f);
	}

	public EX_Rune2_Projectile()
	{
		base._IndexOffsetScaleFactor = 0.1f;
		midYOffset = 0.64f;
		speed = 3f;
		((Projectile)this)._002Ector();
	}
}
