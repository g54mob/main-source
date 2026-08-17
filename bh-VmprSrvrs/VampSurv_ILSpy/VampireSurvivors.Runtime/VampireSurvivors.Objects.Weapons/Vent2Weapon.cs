using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Vent2Weapon : Weapon
{
	private bool _firingQueued;

	public TextMeshPro _ejectionText;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_ejectionText.enabled = false;
	}

	public override void Fire(bool skipTriggers = false)
	{
		_firingQueued = true;
	}

	public override void InternalUpdate()
	{
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_055a: Invalid comparison between O and F4
		//IL_0127: Expected I, but got O
		//IL_012f: Expected I, but got O
		//IL_013f: Expected O, but got I
		//IL_039e: Expected F4, but got O
		//IL_01bf: Expected O, but got I4
		//IL_042c: Expected I, but got O
		//IL_017b: Expected O, but got I
		//IL_01d2: Expected I, but got O
		//IL_01b1: Expected O, but got I4
		//IL_02c2: Expected O, but got I
		//IL_02a8: Expected O, but got I
		//IL_0477: Expected O, but got I
		//IL_04b2: Expected O, but got I
		//IL_04c4: Expected O, but got I4
		//IL_04d2: Expected O, but got I4
		//IL_056c->IL03d6: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		if (!_firingQueued || PauseSystem._paused)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		Projectile[] items;
		Projectile projectile3;
		object obj3;
		Projectile projectile2;
		if (_spawnedProjectiles != null)
		{
			if (spawnedProjectiles._size > 0)
			{
				if (spawnedProjectiles._size > 0)
				{
					items = spawnedProjectiles._items;
					if (spawnedProjectiles._items == null)
					{
						goto IL_03a5;
					}
					if (items.Length > 0)
					{
						Projectile projectile = items[0];
						if ((object)items[0] == null)
						{
							projectile2 = null;
							projectile3 = null;
							goto IL_0449;
						}
						nint num = (nint)typeof(Vent2Projectile);
						nint num2 = (nint)projectile;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Vent2Projectile>)+130]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Vent2Projectile>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rax_v68+FFFFFFF8+v494 @ rax_v64*8]");
							if (0 == (nint)typeof(Vent2Projectile))
							{
								obj3 = 1;
								goto IL_040f;
							}
						}
						obj3 = 0;
						goto IL_040f;
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				throw new IndexOutOfRangeException();
			}
			_firingQueued = false;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector2 vector = default(Vector2);
					Projectile projectile4 = base.FireOneProjectile(vector, 0, _targetTransform);
					float num4 = base.PInterval();
					float num5 = _lastFiringInterval - (float)vector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj4 = num5 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
					{
						float num6 = base.PInterval();
						_lastFiringInterval = (float)vector;
						base.ResetFiringTimer();
					}
					return;
				}
			}
		}
		goto IL_03a5;
		IL_03a5:
		throw new NullReferenceException();
		IL_040f:
		bool flag2 = obj3 == null;
		nint num7 = (nint)typeof(Vent2Projectile);
		projectile2 = null;
		projectile3 = null;
		if (!flag2)
		{
			num7 = (nint)typeof(Vent2Projectile);
			projectile2 = null;
			projectile3 = items[0];
		}
		goto IL_0449;
		IL_0449:
		if ((object)projectile3 == null || ((UnityEngine.Object)projectile3).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+17D]");
		if ((nint)0 != 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+188]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+180]");
		bool flag3 = (nint)0 == 0;
		_ = 1;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+180]");
			((Timer)0).Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+188]");
		Timer timer = (Timer)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+188]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+188]");
			if (!((Timer)0).IsDone)
			{
				if (timer._onComplete != null)
				{
					Action onComplete = timer._onComplete;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v872.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				timer._003CIsCompleted_003Ek__BackingField = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.Projectile)+188]");
				float timeElapsed = ((Timer)0).GetTimeElapsed();
				timer._timeElapsedBeforeCancel = (float?)(object)1;
				timer._timeElapsedBeforePause = (float?)(object)0;
			}
			return;
		}
		goto IL_03a5;
	}
}
