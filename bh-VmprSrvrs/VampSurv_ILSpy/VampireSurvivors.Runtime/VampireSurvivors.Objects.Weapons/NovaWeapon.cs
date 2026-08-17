using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class NovaWeapon : Weapon
{
	private Color _projectileColor;

	private WeaponType _novaExplosionType;

	private uint _convertedColor;

	protected unsafe override void OnStart()
	{
		//IL_0043: Expected O, but got Ref
		_explosionType = _novaExplosionType;
		Color color = default(Color);
		string value = ColorUtility.ToHtmlStringRGB((Color)(&color));
		uint convertedColor = Convert.ToUInt32(value, 16);
		_convertedColor = convertedColor;
		base.OnStart();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_000d: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_010a: Expected O, but got I
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		bool flag = (object)projectile == null;
		Projectile projectile2 = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(NovaProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.NovaProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.NovaProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v26+FFFFFFF8+v68 @ rax_v22*8]");
				if (0 == (nint)typeof(NovaProjectile))
				{
					obj3 = 1;
					goto IL_0159;
				}
			}
			obj3 = 0;
			goto IL_0159;
		}
		goto IL_0180;
		IL_0180:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v2 (VampireSurvivors.Objects.Projectiles.Projectile)+D0]");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint((SpriteRenderer)0, _convertedColor);
		}
		return projectile2;
		IL_0159:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0180;
	}

	public unsafe uint ConvertColorToUint(Color color)
	{
		//IL_0025: Expected O, but got Ref
		object obj = default(object);
		string value = ColorUtility.ToHtmlStringRGB((Color)(&obj));
		return Convert.ToUInt32(value, 16);
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0185: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0171;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float2 position = component.position;
									Projectile projectile = base.SpawnExplosionAt(position, 0, 1, 0f);
									if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
									{
										return true;
									}
								}
								goto IL_0171;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0171:
		return false;
	}
}
