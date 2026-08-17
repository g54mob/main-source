using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class Silf2CounterProjectile : SilfProjectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("HitBlack1", "vfx");
		_renderer.sprite = sprite;
	}

	protected override string GetTrailTextureName()
	{
		//IL_004b: Invalid comparison between O and F4
		//IL_0099: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CEC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f))
			{
				return "Gradient4_8pxReverse";
			}
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f);
				string result = "Gradient4_6pxReverse";
				if (!flag)
				{
					result = "Gradient4_4pxReverse";
				}
				return result;
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
