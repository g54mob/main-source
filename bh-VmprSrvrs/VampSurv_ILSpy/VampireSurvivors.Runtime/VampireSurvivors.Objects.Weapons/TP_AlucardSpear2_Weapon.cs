using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_AlucardSpear2_Weapon : TP_AlucardSpear1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Vector2 _offset;

		public float _charSizeX;

		public TP_AlucardSpear2_Weapon _003C_003E4__this;

		public float _angleUnit;

		public int _amount;

		public Action _003C_003E9__0;

		internal void _003COnSpecialCounter_003Eb__0()
		{
			//IL_034b: Expected O, but got F4
			//IL_038d: Expected O, but got F4
			//IL_0092: Expected I, but got O
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_0118: Expected O, but got I4
			//IL_0220: Expected I, but got O
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Expected O, but got Unknown
			//IL_02a6: Expected O, but got I4
			bool flag = _amount <= 0;
			int num = 0;
			float num3 = default(float);
			float num2 = num3;
			object obj2 = default(object);
			object obj = obj2;
			float2 float5 = default(float2);
			if (!flag)
			{
				bool flag2;
				do
				{
					_offset = (Vector2)_charSizeX;
					TP_AlucardSpear2_Weapon tP_AlucardSpear2_Weapon = _003C_003E4__this;
					float2 position = ((Equipment)tP_AlucardSpear2_Weapon)._003COwner_003Ek__BackingField.position;
					float num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_AlucardSpear2_Weapon+<>c__DisplayClass7_0)+14]");
					float num5 = num4 + 0f;
					Projectile projectile = tP_AlucardSpear2_Weapon._aeroSlicePool.SpawnAt(float5, _003C_003E4__this, num);
					if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
					{
						nint num6 = (nint)projectile;
						float projectileSpeed = projectile.ProjectileSpeed;
						obj = num * _angleUnit;
						float num7 = (float)obj - (float)Math.PI * 11f / 60f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						float num8 = (float)float5 * 0.65f;
						float num9 = num7 * num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						float xVel = (float)obj * (float)float5;
						projectile.setVelocity(xVel, (float?)(object)1);
						num2 = num9;
					}
					num++;
					flag2 = num < _amount;
					num3 = num2;
					obj2 = obj;
				}
				while (flag2);
			}
			if (_amount <= 0)
			{
				return;
			}
			int num10 = 0;
			do
			{
				Vector2 offset = (Vector2)(_charSizeX ^ -0f);
				_offset = offset;
				TP_AlucardSpear2_Weapon tP_AlucardSpear2_Weapon2 = _003C_003E4__this;
				float2 position2 = ((Equipment)tP_AlucardSpear2_Weapon2)._003COwner_003Ek__BackingField.position;
				float num11 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_AlucardSpear2_Weapon+<>c__DisplayClass7_0)+14]");
				float num12 = num11 + 0f;
				Projectile projectile2 = tP_AlucardSpear2_Weapon2._aeroSlicePool.SpawnAt(float5, _003C_003E4__this, num10);
				if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
				{
					nint num13 = (nint)projectile2;
					float projectileSpeed2 = projectile2.ProjectileSpeed;
					obj2 = num10 * _angleUnit;
					float num14 = (float)obj2 - (float)Math.PI * 11f / 60f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num15 = (float)float5 * 0.65f;
					float num16 = num14 * num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float xVel2 = (float)obj2 * (float)float5;
					projectile2.setVelocity(xVel2, (float?)(object)1);
					num3 = num16;
				}
				num10++;
			}
			while (num10 < _amount);
		}
	}

	private Projectile _aeroSlicePrefab;

	private BulletPool _aeroSlicePool;

	protected int _fireCounter;

	protected int _specialCounter = 2;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected override void OnStart()
	{
		//IL_0076: Expected I, but got O
		//IL_0119: Expected I, but got O
		base.OnStart();
		BulletPool aeroSlicePool = new BulletPool(_aeroSlicePrefab);
		_aeroSlicePool = aeroSlicePool;
		BulletPool aeroSlicePool2 = _aeroSlicePool;
		aeroSlicePool2.UpperLimit = 1000;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSpear2_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_aeroSlicePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSpear2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_aeroSlicePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		_specialCounter = 7;
		base.Fire(skipTriggers);
		if (++_fireCounter % _specialCounter == 0)
		{
			OnSpecialCounter(skipTriggers);
		}
	}

	public virtual void OnSpecialCounter(bool skipTriggers = false)
	{
		//IL_0052: Expected F4, but got O
		//IL_00a1: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals22._003C_003E4__this = this;
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 size = arcadeSprite._spriteRenderer.size;
		CS_0024_003C_003E8__locals22._charSizeX = (float)size;
		ArcadeSprite arcadeSprite2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 size2 = arcadeSprite2._spriteRenderer.size;
		object obj = default(object);
		float num = (float)obj * 0.5f;
		CS_0024_003C_003E8__locals22._offset = (Vector2)0;
		CS_0024_003C_003E8__locals22._amount = 12;
		CS_0024_003C_003E8__locals22._angleUnit = (float)Math.PI / 6f;
		object obj2 = 1;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals22._003C_003E9__0;
			if (CS_0024_003C_003E8__locals22._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals22._003C_003E9__0 = delegate
				{
					//IL_034b: Expected O, but got F4
					//IL_038d: Expected O, but got F4
					//IL_0092: Expected I, but got O
					//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
					//IL_00af: Expected O, but got Unknown
					//IL_0118: Expected O, but got I4
					//IL_0220: Expected I, but got O
					//IL_0238: Unknown result type (might be due to invalid IL or missing references)
					//IL_023d: Expected O, but got Unknown
					//IL_02a6: Expected O, but got I4
					bool flag = CS_0024_003C_003E8__locals22._amount <= 0;
					int num2 = 0;
					float num4 = default(float);
					float num3 = num4;
					object obj4 = default(object);
					object obj3 = obj4;
					float2 float5 = default(float2);
					if (!flag)
					{
						bool flag2;
						do
						{
							CS_0024_003C_003E8__locals22._offset = (Vector2)CS_0024_003C_003E8__locals22._charSizeX;
							TP_AlucardSpear2_Weapon tP_AlucardSpear2_Weapon = CS_0024_003C_003E8__locals22._003C_003E4__this;
							float2 position = ((Equipment)tP_AlucardSpear2_Weapon)._003COwner_003Ek__BackingField.position;
							float num5 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_AlucardSpear2_Weapon+<>c__DisplayClass7_0)+14]");
							float num6 = num5 + 0f;
							Projectile projectile = tP_AlucardSpear2_Weapon._aeroSlicePool.SpawnAt(float5, CS_0024_003C_003E8__locals22._003C_003E4__this, num2);
							if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
							{
								nint num7 = (nint)projectile;
								float projectileSpeed = projectile.ProjectileSpeed;
								obj3 = num2 * CS_0024_003C_003E8__locals22._angleUnit;
								float num8 = (float)obj3 - (float)Math.PI * 11f / 60f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								float num9 = (float)float5 * 0.65f;
								float num10 = num8 * num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
								float xVel = (float)obj3 * (float)float5;
								projectile.setVelocity(xVel, (float?)(object)1);
								num3 = num10;
							}
							num2++;
							flag2 = num2 < CS_0024_003C_003E8__locals22._amount;
							num4 = num3;
							obj4 = obj3;
						}
						while (flag2);
					}
					if (CS_0024_003C_003E8__locals22._amount > 0)
					{
						int num11 = 0;
						do
						{
							Vector2 offset = (Vector2)(CS_0024_003C_003E8__locals22._charSizeX ^ -0f);
							CS_0024_003C_003E8__locals22._offset = offset;
							TP_AlucardSpear2_Weapon tP_AlucardSpear2_Weapon2 = CS_0024_003C_003E8__locals22._003C_003E4__this;
							float2 position2 = ((Equipment)tP_AlucardSpear2_Weapon2)._003COwner_003Ek__BackingField.position;
							float num12 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_AlucardSpear2_Weapon+<>c__DisplayClass7_0)+14]");
							float num13 = num12 + 0f;
							Projectile projectile2 = tP_AlucardSpear2_Weapon2._aeroSlicePool.SpawnAt(float5, CS_0024_003C_003E8__locals22._003C_003E4__this, num11);
							if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
							{
								nint num14 = (nint)projectile2;
								float projectileSpeed2 = projectile2.ProjectileSpeed;
								obj4 = num11 * CS_0024_003C_003E8__locals22._angleUnit;
								float num15 = (float)obj4 - (float)Math.PI * 11f / 60f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								float num16 = (float)float5 * 0.65f;
								float num17 = num15 * num16;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
								float xVel2 = (float)obj4 * (float)float5;
								projectile2.setVelocity(xVel2, (float?)(object)1);
								num4 = num17;
							}
							num11++;
						}
						while (num11 < CS_0024_003C_003E8__locals22._amount);
					}
				});
			}
			float duration = (float)obj2 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			obj2 += 500;
		}
		while ((nint)obj2 < 1501);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
	}

	protected override void OnDestroy()
	{
		if (base._pommelPool != null)
		{
			base._pommelPool.Destroy();
		}
		base._pommelPool = null;
		OnDestroy();
	}

	public override void Cleanup()
	{
		if (base._pommelPool != null)
		{
			base._pommelPool.Cleanup();
		}
		((Weapon)this).Cleanup();
		if (_aeroSlicePool != null)
		{
			_aeroSlicePool.Cleanup();
		}
	}
}
