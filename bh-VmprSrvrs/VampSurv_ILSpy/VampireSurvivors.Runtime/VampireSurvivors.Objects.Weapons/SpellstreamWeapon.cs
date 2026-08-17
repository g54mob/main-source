using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SpellstreamWeapon : Weapon
{
	private int _sourceIndex;

	private List<Vector3> _sources;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_007d: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_00db: Expected O, but got Ref
		//IL_01ce->IL0162: Incompatible stack heights: 1 vs 0
		//IL_009d->IL0162: Incompatible stack heights: 1 vs 0
		//IL_00e0->IL01d3: Incompatible stack heights: 1 vs 2
		base.InitWeapon(characterController, weaponType);
		List<Vector3> list = new List<Vector3>();
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v11+18]");
						if (num >= 0)
						{
							object obj2 = default(object);
							list.AddWithResize((Vector3)(&obj2));
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj3 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v11+18]");
							bool flag2 = num2 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj4 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj5 = 0 + obj4;
							_ = 0;
						}
						_sources = list;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetSources(List<Vector3> array)
	{
		_sources = array;
	}

	private unsafe Vector3 GetSource()
	{
		//IL_0072: Expected O, but got I
		//IL_0087: Expected O, but got I4
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ab: Expected F4, but got I
		//IL_00a6: Expected native int or pointer, but got O
		//IL_00c0: Expected F4, but got I
		//IL_00bb: Expected native int or pointer, but got O
		List<Vector3> sources = _sources;
		int num = ++_sourceIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)num >= (nint)0)
		{
			_sourceIndex = 0;
		}
		int sourceIndex = _sourceIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)sourceIndex < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj = 0;
			object obj2 = _sourceIndex * 2;
			object obj3 = _sourceIndex + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+20+v154 @ rcx_v8*4]");
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+28+v154 @ rcx_v8*4]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Vector3 result = default(Vector3);
		return result;
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			float num = base.PArea();
			float num3 = default(float);
			float num2 = num3 * 1.25f;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num3;
					return num3 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0141: Invalid comparison between F4 and O
		//IL_00ef: Expected F4, but got O
		Transform transform = GM.Core.FindClosestEnemyToPlayer(((Equipment)this)._003COwner_003Ek__BackingField);
		Vector2 vector = default(Vector2);
		if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			List<Vector3> sources = _sources;
			int num = ++_sourceIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v21 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			if ((nint)num >= (nint)0)
			{
				_sourceIndex = 0;
			}
			int sourceIndex = _sourceIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v21 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			if ((nint)sourceIndex >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Transform target = transform.transform;
			Projectile projectile = base.FireOneProjectile(vector, 0, target);
		}
		float num2 = base.PInterval();
		bool flag = (object)_lastFiringInterval == (object)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873B2CA5h\"");
		if (!flag)
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}
}
