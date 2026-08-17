using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_BladeCrossbowWeapon : FB_QuantisedAngleWeapon
{
	public override float SecondsToRotateAim360
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0055: Expected F4, but got I
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected F4, but got Unknown
		//IL_0275: Expected O, but got F4
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v12 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v12 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			float current = 0f * 57.29578f;
			GameManager core = GM.Core;
			List<EnemyController> allEnemiesInScreenBounds = core._stage.GetAllEnemiesInScreenBounds(0.125f);
			Extensions.Shuffle((IList<object>)allEnemiesInScreenBounds);
			ArcadeSprite arcadeSprite = null;
			float num2 = 0.125f;
			ArcadeSprite arcadeSprite2 = null;
			float num3 = 3.4028235E+38f;
			ArcadeSprite arcadeSprite3 = null;
			ArcadeSprite arcadeSprite4;
			object obj2 = default(object);
			object obj3 = default(object);
			Projectile result = default(Projectile);
			while (true)
			{
				if ((nint)arcadeSprite2 < allEnemiesInScreenBounds._size)
				{
					if ((nint)arcadeSprite3 < allEnemiesInScreenBounds._size)
					{
						EnemyController[] items = allEnemiesInScreenBounds._items;
						arcadeSprite4 = items[(object)arcadeSprite3];
						float2 position = items[(object)arcadeSprite3].position;
						object obj = obj2 - obj3;
						Extensions.Shuffle((IList<EnemyController>)items[(object)arcadeSprite3]);
						float num4 = (float)obj * 57.29578f;
						float num5 = Mathf.DeltaAngle(current, num4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						num = num5 & 0;
						bool flag = 90f > num;
						num2 = num4;
						if (!flag)
						{
							if (num3 > num)
							{
								arcadeSprite = items[(object)arcadeSprite3];
								num3 = num;
							}
							arcadeSprite3 = (ArcadeSprite)(arcadeSprite3 + 1);
							num2 = num4;
							arcadeSprite2 = arcadeSprite3;
							continue;
						}
						break;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result;
				}
				arcadeSprite4 = arcadeSprite;
				break;
			}
			if ((object)arcadeSprite4 != null && ((UnityEngine.Object)arcadeSprite4).m_CachedPtr != (IntPtr)0)
			{
				arcadeSprite4.CheckRenderer();
				Transform transform = arcadeSprite4._spriteRenderer.transform;
				Transform transform2 = (Transform)(object)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v753 @ r9_v7 (UnityEngine.Transform)+318] (should have been resolved before IL gen)");
			}
			else
			{
				projectile.SetNullTarget();
			}
			float2 firingVector = GetFiringVector();
			float projectileSpeed = projectile.ProjectileSpeed;
			BaseBody body = projectile.body;
			float num6 = (float)firingVector * num;
			float num7 = (float)obj2 * num;
			body._velocity = (float2)num6;
		}
		return projectile;
	}

	public EnemyController findEnemyInPlayerDirection(Vector2 pos, float angle, float acceptableAngle = 3.4028235E+38f)
	{
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected F4, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		GameManager core = GM.Core;
		List<EnemyController> allEnemiesInScreenBounds = core._stage.GetAllEnemiesInScreenBounds(0.125f);
		Extensions.Shuffle((IList<object>)allEnemiesInScreenBounds);
		ArcadeSprite arcadeSprite = null;
		ArcadeSprite arcadeSprite2 = null;
		float num = 3.4028235E+38f;
		ArcadeSprite arcadeSprite3 = null;
		object obj2 = default(object);
		object obj3 = default(object);
		while (true)
		{
			if ((nint)arcadeSprite3 < allEnemiesInScreenBounds._size)
			{
				if ((nint)arcadeSprite < allEnemiesInScreenBounds._size)
				{
					EnemyController[] items = allEnemiesInScreenBounds._items;
					if ((nint)arcadeSprite >= items.Length)
					{
						break;
					}
					ArcadeSprite arcadeSprite4 = items[(object)arcadeSprite];
					float2 position = items[(object)arcadeSprite].position;
					object obj = obj2 - obj3;
					Extensions.Shuffle((IList<EnemyController>)items[(object)arcadeSprite]);
					float target = (float)obj * 57.29578f;
					float num2 = Mathf.DeltaAngle(angle, target);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					float num3 = num2 & 0;
					if (!(acceptableAngle > num3))
					{
						bool flag = !(num > num3);
						float num4 = num;
						if (!flag)
						{
							num4 = num3;
						}
						arcadeSprite = (ArcadeSprite)(arcadeSprite + 1);
						if (!(num > num3))
						{
							arcadeSprite4 = arcadeSprite2;
						}
						arcadeSprite2 = arcadeSprite4;
						num = num4;
						arcadeSprite3 = arcadeSprite;
						continue;
					}
					return items[(object)arcadeSprite];
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			return (EnemyController)arcadeSprite2;
		}
		return (EnemyController)(object)new IndexOutOfRangeException();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
