using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class Silf3Projectile : SilfProjectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		_trailAlpha = 0.4f;
		_startingAlpha = 1f;
		base.InitProjectile(pool, weapon, index);
	}

	protected override string GetTrailTextureName()
	{
		//IL_007e: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CEF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		nint num = default(nint);
		object obj = num >> 1;
		object obj2 = obj >> 31;
		object obj3 = obj + obj2;
		object obj4 = obj3 * 8;
		object obj5 = obj3 + obj4;
		object obj6 = _indexInWeapon - obj5;
		float value = (float)obj6 + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(value, null, currentInfo);
		return "Prism" + text + "_8px.png";
	}

	protected override PhaserSpline GetSpline()
	{
		//IL_0122: Expected O, but got F4
		//IL_0154: Expected O, but got F4
		//IL_0114->IL009a: Incompatible stack heights: 1 vs 0
		//IL_0146->IL009a: Incompatible stack heights: 1 vs 0
		//IL_0031->IL009a: Incompatible stack heights: 1 vs 0
		//IL_0176->IL009a: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_trueWeapon != null)
			{
				object obj = UnityEngine.Random.value;
				Weapon weapon = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					object obj2 = UnityEngine.Random.value;
					List<Vector2> list = new List<Vector2>();
					if (list != null)
					{
						Vector2 item = default(Vector2);
						list.Add(item);
						list.Add(item);
						list.Add(item);
						PhaserSpline phaserSpline = null;
						phaserSpline._points = list;
						return phaserSpline;
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
