using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles;

public class SilfCounterProjectile : SilfProjectile
{
	protected override string GetTrailTextureName()
	{
		//IL_004b: Invalid comparison between O and F4
		//IL_0099: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CF1]");
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
				return "Gradient3_8pxReverse";
			}
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f);
				string result = "Gradient3_6pxReverse";
				if (!flag)
				{
					result = "Gradient3_4pxReverse";
				}
				return result;
			}
		}
		return (string)(object)new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 > -1)
			{
				bool flag = TryFreeze(other);
			}
		}
	}
}
