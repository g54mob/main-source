using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class Backup_PrototypeCWeapon : FB_QuantisedAngleWeapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Backup_PlaneData planeData;

		public Backup_PrototypeCWeapon _003C_003E4__this;

		public Action _003C_003E9__1;

		internal void _003CstartPlanes_003Eb__0()
		{
			//IL_0013: Expected O, but got I4
			//IL_007c: Expected O, but got I4
			//IL_01fa: Expected O, but got F4
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_017c: Expected I, but got O
			//IL_019f->IL019f: Incompatible stack heights: 1 vs 0
			Backup_PlaneData backup_PlaneData = planeData;
			backup_PlaneData.positionOffset = (float2)0;
			Backup_PlaneData backup_PlaneData2 = planeData;
			PhaserSprite phaserSprite = backup_PlaneData2.planeSprite.setVisible(visible: true);
			Backup_PlaneData backup_PlaneData3 = planeData;
			backup_PlaneData3.curveTime = 0f;
			backup_PlaneData3.moving = true;
			Backup_PlaneData backup_PlaneData4 = planeData;
			object obj = 1550;
			bool flag = false;
			bool flag2 = false;
			float num2 = default(float);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			object obj3 = default(object);
			while (true)
			{
				Timer[] explosionTimers = backup_PlaneData4.explosionTimers;
				if ((flag2 ? 1 : 0) >= explosionTimers.Length)
				{
					break;
				}
				Backup_PlaneData backup_PlaneData5 = planeData;
				Timer[] explosionTimers2 = backup_PlaneData5.explosionTimers;
				object obj2 = UnityEngine.Random.value;
				Action onComplete = _003C_003E9__1;
				float num = num2 * 2000f;
				if (_003C_003E9__1 == null)
				{
					onComplete = (_003C_003E9__1 = delegate
					{
						//IL_01ce: Expected O, but got I4
						//IL_0079->IL0197: Incompatible stack heights: 1 vs 0
						//IL_009b->IL0197: Incompatible stack heights: 1 vs 0
						//IL_00d6->IL0197: Incompatible stack heights: 1 vs 0
						//IL_00ff->IL0197: Incompatible stack heights: 1 vs 0
						//IL_0121->IL0197: Incompatible stack heights: 1 vs 0
						if ((object)_003C_003E4__this != null)
						{
							GameObject gameObject = _003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 == null)
								{
									return;
								}
								Backup_PlaneData backup_PlaneData6 = planeData;
								if (planeData != null && (object)backup_PlaneData6.planeSprite != null)
								{
									float2 position = backup_PlaneData6.planeSprite.position;
									Backup_PrototypeCWeapon backup_PrototypeCWeapon = _003C_003E4__this;
									if ((object)_003C_003E4__this != null)
									{
										Backup_PlaneData backup_PlaneData7 = planeData;
										if (planeData != null && backup_PrototypeCWeapon._explosionPool != null)
										{
											bool flag5 = (nint)backup_PlaneData7.direction < 0;
											bool flag6 = (object)backup_PlaneData7.direction == null;
											bool flag7 = !flag5;
											bool flag8 = !flag6;
											int index = ((flag8 & flag7) ? 1 : 0);
											float2 pos = default(float2);
											Projectile projectile = backup_PrototypeCWeapon._explosionPool.SpawnAt(pos, _003C_003E4__this, index);
											return;
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					});
				}
				float num3 = (float)obj + num;
				num2 = num3 * 0.001f;
				Timer timer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				if (timer != null)
				{
					nint num4 = (nint)explosionTimers2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag3 = obj3 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				backup_PlaneData4 = planeData;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				obj += 1550;
				flag2 = flag;
			}
		}

		internal void _003CstartPlanes_003Eb__1()
		{
			//IL_01ce: Expected O, but got I4
			//IL_0079->IL0197: Incompatible stack heights: 1 vs 0
			//IL_009b->IL0197: Incompatible stack heights: 1 vs 0
			//IL_00d6->IL0197: Incompatible stack heights: 1 vs 0
			//IL_00ff->IL0197: Incompatible stack heights: 1 vs 0
			//IL_0121->IL0197: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					Backup_PlaneData backup_PlaneData = planeData;
					if (planeData != null && (object)backup_PlaneData.planeSprite != null)
					{
						float2 position = backup_PlaneData.planeSprite.position;
						Backup_PrototypeCWeapon backup_PrototypeCWeapon = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							Backup_PlaneData backup_PlaneData2 = planeData;
							if (planeData != null && backup_PrototypeCWeapon._explosionPool != null)
							{
								bool flag2 = (nint)backup_PlaneData2.direction < 0;
								bool flag3 = (object)backup_PlaneData2.direction == null;
								bool flag4 = !flag2;
								bool flag5 = !flag3;
								int index = ((flag5 & flag4) ? 1 : 0);
								float2 pos = default(float2);
								Projectile projectile = backup_PrototypeCWeapon._explosionPool.SpawnAt(pos, _003C_003E4__this, index);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private int PlanePoolAmount;

	private int ExplosionPerPlaneAmount;

	private List<Backup_PlaneData> _planeDatas;

	private Timer _planeStartingTimer;

	private PhaserSpline _spline;

	private float _maxPathWidth;

	private float _maxPathHeight;

	private BulletPool _explosionPool;

	private readonly List<float> CurveData;

	public override void Fire()
	{
		//IL_0041: Invalid comparison between O and F4
		//IL_011e: Expected F4, but got I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
		float num = PAmount();
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			float num2 = PAmount();
			bool flag = (nint)vector <= 0;
			int num3 = 0;
			if (!flag)
			{
				do
				{
					float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					Projectile projectile2 = FireOneProjectile(vector, num3, _targetTransform);
					num3++;
					float num4 = PAmount();
				}
				while ((nint)vector > num3);
			}
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_SpreadShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	public override float PAmount()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_008b: Expected O, but got I4
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = !(10f > num2);
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj = currentWeaponData & 1;
		bool flag2 = obj == null;
		object obj2 = !flag2;
		if (obj2 == null)
		{
			num4 += -1f;
		}
		return num4;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0156: Expected O, but got F4
		//IL_0173: Expected O, but got F4
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0050: Expected I, but got O
		//IL_0102: Expected O, but got F4
		float num = PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num2 = num - 3f;
		object obj = num2 >> 31;
		float num3 = num2 - (float)obj;
		object obj2 = num3 >> 1;
		object obj3 = obj2 * 4;
		object obj4 = obj2 + obj3;
		float num4 = (float)obj4 + 45f;
		bool flag = !(85f > num4);
		float num5 = 85f;
		if (!flag)
		{
			num5 = num4;
		}
		object obj5 = default(object);
		float num6 = num5 / (float)obj5;
		float num7 = (float)obj5 - 1f;
		float num8 = (float)index * num6;
		float num9 = num6 * 0.5f;
		float num10 = num8 + _firingAngleDegrees;
		float num11 = num9 * num7;
		float num12 = num10 - num11;
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
		{
			projectile = null;
			goto IL_0210;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			nint num13 = (nint)projectile;
			float projectileSpeed = projectile.ProjectileSpeed;
			BaseBody body = projectile.body;
			if (projectile.body != null && (object)s_scene.physics != null)
			{
				float num14 = num12 * ((float)Math.PI / 180f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
				float num15 = num14 * num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				float num16 = num14 * num7;
				body._velocity = (float2)num15;
				goto IL_0210;
			}
		}
		return (Projectile)(object)new NullReferenceException();
		IL_0210:
		return projectile;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_049f: Expected I, but got O
		//IL_04b5: Expected O, but got I
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected O, but got Unknown
		//IL_0539: Expected I, but got O
		//IL_05f3: Expected O, but got I4
		//IL_060a: Expected I, but got I8
		//IL_0515: Expected I, but got I8
		//IL_0371: Expected I, but got O
		//IL_03a0: Expected O, but got I4
		//IL_0414: Expected I, but got O
		//IL_0443: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		PhaserSpline spline = new PhaserSpline(CurveData);
		_spline = spline;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float maxPathWidth = (float)renderer.pixelWidth * 0.01f;
		_maxPathWidth = maxPathWidth;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float maxPathHeight = (float)renderer2.pixelHeight * 0.01f;
		_maxPathHeight = maxPathHeight;
		if (PlanePoolAmount <= 0)
		{
			goto IL_02b6;
		}
		bool flag = false;
		Vector2 pos = default(Vector2);
		while ((object)GM.Core != null && (object)GM.Core != null)
		{
			GameObject gameObject = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "flame000");
			PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			int depth = renderer3.pixelHeight - 1;
			PhaserSprite phaserSprite3 = phaserSprite.setDepth(depth);
			Backup_PlaneData backup_PlaneData = new Backup_PlaneData();
			backup_PlaneData.available = true;
			backup_PlaneData.planeSprite = phaserSprite;
			backup_PlaneData.positionOffset = (float2)0;
			backup_PlaneData.curveTime = 0f;
			Timer[] explosionTimers = new Timer[ExplosionPerPlaneAmount];
			backup_PlaneData.explosionTimers = explosionTimers;
			List<object> planeDatas = (List<object>)(object)_planeDatas;
			int version = planeDatas._version + 1;
			planeDatas._version = version;
			object[] items = planeDatas._items;
			if (planeDatas._size >= items.Length)
			{
				planeDatas.AddWithResize((object)backup_PlaneData);
			}
			else
			{
				int size = planeDatas._size + 1;
				planeDatas._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			if ((flag ? 1 : 0) < PlanePoolAmount)
			{
				continue;
			}
			goto IL_02b6;
		}
		goto IL_0570;
		IL_02b6:
		if (_explosionPool != null)
		{
			goto IL_0454;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FB_PROTOTYPE_C_EXPLOSION);
		BulletPool explosionPool = new BulletPool(projectilePrefab);
		_explosionPool = explosionPool;
		bool flag2 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene4.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1197 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeCWeapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_explosionPool, core.Enemies, collideCallback, (ArcadePhysicsCallback)flag2, (CallbackContext)(object)monoBehaviour);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene5 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene5.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1262 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Backup_PrototypeCWeapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_explosionPool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)flag2, (CallbackContext)(object)monoBehaviour);
				flag2 = flag2;
				goto IL_0454;
			}
		}
		goto IL_0570;
		IL_0454:
		Action action = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(Backup_PrototypeCWeapon._003CInitWeapon_003Eb__12_0);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		nint num4;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num4 = unchecked((nint)6447293664L);
				goto IL_05ea;
			}
		}
		num4 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_05ea;
		IL_0570:
		throw new NullReferenceException();
		IL_05ea:
		object obj3 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer planeStartingTimer = Timers.Register(10f, action, null, isLooped: true, flag2, monoBehaviour, repeat, type, isOnlineTimer: false, canPause: false);
		_planeStartingTimer = planeStartingTimer;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1138 Invalid \"Jump target not found in method: 0x18738B830\"");
		goto IL_0570;
	}

	private Backup_PlaneData nextPlane()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		List<Backup_PlaneData> planeDatas = _planeDatas;
		object obj = 0;
		object obj2 = 0;
		Backup_PlaneData result = default(Backup_PlaneData);
		while (true)
		{
			if ((nint)obj2 < planeDatas._size)
			{
				if ((nint)obj >= planeDatas._size)
				{
					break;
				}
				Backup_PlaneData[] items = planeDatas._items;
				Backup_PlaneData backup_PlaneData = items[obj];
				if (!backup_PlaneData.available)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				return result;
			}
			return null;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Backup_PlaneData result2 = default(Backup_PlaneData);
		return result2;
	}

	private void startPlanes(int planeAmount)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		if (planeAmount <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		Backup_PlaneData planeData = default(Backup_PlaneData);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals22._003C_003E4__this = this;
			List<Backup_PlaneData> planeDatas = _planeDatas;
			object obj3 = 0;
			while (true)
			{
				if ((nint)obj3 < planeDatas._size)
				{
					if ((nint)obj3 < planeDatas._size)
					{
						Backup_PlaneData[] items = planeDatas._items;
						Backup_PlaneData backup_PlaneData = items[obj3];
						if (!backup_PlaneData.available)
						{
							obj3++;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						break;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				planeData = null;
				break;
			}
			CS_0024_003C_003E8__locals22.planeData = planeData;
			if (CS_0024_003C_003E8__locals22.planeData == null)
			{
				break;
			}
			Backup_PlaneData planeData2 = CS_0024_003C_003E8__locals22.planeData;
			Action onComplete = delegate
			{
				//IL_0013: Expected O, but got I4
				//IL_007c: Expected O, but got I4
				//IL_01fa: Expected O, but got F4
				//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cf: Expected O, but got Unknown
				//IL_017c: Expected I, but got O
				//IL_019f->IL019f: Incompatible stack heights: 1 vs 0
				Backup_PlaneData planeData3 = CS_0024_003C_003E8__locals22.planeData;
				planeData3.positionOffset = (float2)0;
				Backup_PlaneData planeData4 = CS_0024_003C_003E8__locals22.planeData;
				PhaserSprite phaserSprite = planeData4.planeSprite.setVisible(visible: true);
				Backup_PlaneData planeData5 = CS_0024_003C_003E8__locals22.planeData;
				planeData5.curveTime = 0f;
				planeData5.moving = true;
				Backup_PlaneData planeData6 = CS_0024_003C_003E8__locals22.planeData;
				object obj4 = 1550;
				bool flag = false;
				bool flag2 = false;
				float num2 = default(float);
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				object obj6 = default(object);
				while (true)
				{
					Timer[] explosionTimers = planeData6.explosionTimers;
					if ((flag2 ? 1 : 0) >= explosionTimers.Length)
					{
						break;
					}
					Backup_PlaneData planeData7 = CS_0024_003C_003E8__locals22.planeData;
					Timer[] explosionTimers2 = planeData7.explosionTimers;
					object obj5 = UnityEngine.Random.value;
					Action onComplete2 = CS_0024_003C_003E8__locals22._003C_003E9__1;
					float num = num2 * 2000f;
					if (CS_0024_003C_003E8__locals22._003C_003E9__1 == null)
					{
						onComplete2 = (CS_0024_003C_003E8__locals22._003C_003E9__1 = delegate
						{
							//IL_01ce: Expected O, but got I4
							//IL_0079->IL0197: Incompatible stack heights: 1 vs 0
							//IL_009b->IL0197: Incompatible stack heights: 1 vs 0
							//IL_00d6->IL0197: Incompatible stack heights: 1 vs 0
							//IL_00ff->IL0197: Incompatible stack heights: 1 vs 0
							//IL_0121->IL0197: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals22._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals22._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj7 == null)
									{
										return;
									}
									Backup_PlaneData planeData8 = CS_0024_003C_003E8__locals22.planeData;
									if (CS_0024_003C_003E8__locals22.planeData != null && (object)planeData8.planeSprite != null)
									{
										float2 position = planeData8.planeSprite.position;
										Backup_PrototypeCWeapon backup_PrototypeCWeapon = CS_0024_003C_003E8__locals22._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals22._003C_003E4__this != null)
										{
											Backup_PlaneData planeData9 = CS_0024_003C_003E8__locals22.planeData;
											if (CS_0024_003C_003E8__locals22.planeData != null && backup_PrototypeCWeapon._explosionPool != null)
											{
												bool flag5 = (nint)planeData9.direction < 0;
												bool flag6 = (object)planeData9.direction == null;
												bool flag7 = !flag5;
												bool flag8 = !flag6;
												int index = ((flag8 & flag7) ? 1 : 0);
												float2 pos = default(float2);
												Projectile projectile = backup_PrototypeCWeapon._explosionPool.SpawnAt(pos, CS_0024_003C_003E8__locals22._003C_003E4__this, index);
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						});
					}
					float num3 = (float)obj4 + num;
					num2 = num3 * 0.001f;
					Timer timer = Timers.Register(num2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					if (timer != null)
					{
						nint num4 = (nint)explosionTimers2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						bool flag3 = obj6 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					planeData6 = CS_0024_003C_003E8__locals22.planeData;
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
					obj4 += 1550;
					flag2 = flag;
				}
			};
			float duration = (float)obj2 * 0.001f;
			Timer delay = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			planeData2.delay = delay;
			obj++;
			obj2 += 300;
		}
		while ((nint)obj < planeAmount);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_008c: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_023b: Expected O, but got F4
		//IL_0275: Expected O, but got Ref
		//IL_0294: Expected I4, but got F4
		base.InternalUpdate();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = _maxPathHeight * 0.5f;
		float num2 = _maxPathWidth * 0.5f;
		float num3 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v13 (PhaserScene+Renderer)+38]");
		float num4 = num3 + 0f;
		List<Backup_PlaneData> planeDatas = _planeDatas;
		float num5 = (float)renderer.screenCenter - num2;
		bool flag = false;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		float num10 = default(float);
		float num11 = default(float);
		while (true)
		{
			if ((nint)obj2 >= planeDatas._size)
			{
				return;
			}
			List<Backup_PlaneData> planeDatas2 = _planeDatas;
			if ((nint)obj >= planeDatas2._size)
			{
				break;
			}
			Backup_PlaneData[] items = planeDatas2._items;
			Backup_PlaneData backup_PlaneData = items[obj];
			if (backup_PlaneData.moving)
			{
				float curveTime = backup_PlaneData.curveTime;
				float deltaTime = PauseSystem.DeltaTime;
				float num6 = deltaTime * 5f;
				num2 = (backup_PlaneData.curveTime = num6 + backup_PlaneData.curveTime);
				if (num2 < 100f)
				{
					float t = num2 / 100f;
					Vector2 point = _spline.GetPoint(t);
					float2 positionOffset = (float2)(point * _maxPathWidth);
					backup_PlaneData.positionOffset = positionOffset;
					object obj3 = obj4 * _maxPathHeight;
					float num7 = num4 - (float)obj3;
					curveTime = num5 + (float)backup_PlaneData.positionOffset;
					float2 position = backup_PlaneData.planeSprite.position;
					float num8 = num7 - (float)obj4;
					float num9 = curveTime - (float)position;
					backup_PlaneData.direction = (float2)num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					Transform transform = backup_PlaneData.planeSprite.transform;
					transform.localEulerAngles = (Vector3)(&num10);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					num10 = num11;
					flag = (byte)(int)num11 != 0;
					num2 = num11;
				}
				else
				{
					PhaserSprite phaserSprite = backup_PlaneData.planeSprite.setVisible(visible: false);
					backup_PlaneData.available = true;
					flag = false;
				}
			}
			planeDatas = _planeDatas;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		//IL_0028: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_00fd: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_012e: Expected O, but got I4
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_016b: Expected O, but got I
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		base.Cleanup();
		if (_planeStartingTimer != null)
		{
			_planeStartingTimer.Cancel();
		}
		List<Backup_PlaneData> planeDatas = _planeDatas;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < planeDatas._size)
			{
				List<Backup_PlaneData> planeDatas2 = _planeDatas;
				if ((nint)obj >= planeDatas2._size)
				{
					break;
				}
				Backup_PlaneData[] items = planeDatas2._items;
				Backup_PlaneData backup_PlaneData = items[obj];
				if (backup_PlaneData.delay != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v17+28]");
					((Timer)0).Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v10+10]");
				PhaserSprite phaserSprite = ((PhaserSprite)0).setVisible(visible: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v12+38]");
				object obj3 = 0;
				object obj4 = 0;
				while (true)
				{
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdi_v3+18]");
					if ((nint)obj5 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdi_v3+20+v74 @ rbx_v4*8]");
					((Timer)0).Cancel();
					obj4++;
				}
				planeDatas = _planeDatas;
				obj++;
				obj2 = obj;
				continue;
			}
			_explosionPool.Cleanup();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public Backup_PrototypeCWeapon()
	{
		//IL_0037: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_1ae8: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_1b10: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_1b38: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_1b60: Expected O, but got I
		//IL_0239: Expected O, but got I
		//IL_1b88: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_1bb0: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_1bd8: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_1c00: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_1c28: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_1c50: Expected O, but got I
		//IL_04b5: Expected O, but got I
		//IL_1c78: Expected O, but got I
		//IL_051f: Expected O, but got I
		//IL_1ca0: Expected O, but got I
		//IL_0589: Expected O, but got I
		//IL_1cc8: Expected O, but got I
		//IL_05f3: Expected O, but got I
		//IL_1cf0: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_1d18: Expected O, but got I
		//IL_06c7: Expected O, but got I
		//IL_1d40: Expected O, but got I
		//IL_0731: Expected O, but got I
		//IL_1d68: Expected O, but got I
		//IL_079b: Expected O, but got I
		//IL_1d90: Expected O, but got I
		//IL_0805: Expected O, but got I
		//IL_1db8: Expected O, but got I
		//IL_086f: Expected O, but got I
		//IL_1de0: Expected O, but got I
		//IL_08d9: Expected O, but got I
		//IL_1e08: Expected O, but got I
		//IL_0943: Expected O, but got I
		//IL_1e30: Expected O, but got I
		//IL_09ad: Expected O, but got I
		//IL_1e58: Expected O, but got I
		//IL_0a17: Expected O, but got I
		//IL_1e80: Expected O, but got I
		//IL_0a81: Expected O, but got I
		//IL_1ea8: Expected O, but got I
		//IL_0aeb: Expected O, but got I
		//IL_1ed0: Expected O, but got I
		//IL_0b55: Expected O, but got I
		//IL_1ef8: Expected O, but got I
		//IL_0bbf: Expected O, but got I
		//IL_1f20: Expected O, but got I
		//IL_0c29: Expected O, but got I
		//IL_1f48: Expected O, but got I
		//IL_0c93: Expected O, but got I
		//IL_1f70: Expected O, but got I
		//IL_0cfd: Expected O, but got I
		//IL_19b6: Expected O, but got I
		//IL_1a10: Expected O, but got I
		//IL_1fc7: Expected O, but got I
		//IL_1a7a: Expected O, but got I
		PlanePoolAmount = 100;
		ExplosionPerPlaneAmount = 10;
		List<Backup_PlaneData> planeDatas = new List<Backup_PlaneData>();
		_planeDatas = planeDatas;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v9+18]");
		if (num >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rcx_v15+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(0.0333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1023960469;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v10+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v19+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(0.0667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1032362498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v12+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rcx_v23+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v14+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(0.0333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1023960469;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v15+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v16+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(0.0667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1032362498;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v17+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v18+18]");
		if (num13 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v19+18]");
		if (num14 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdx_v20+18]");
		if (num15 >= 0)
		{
			list.AddWithResize(0.1333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1040744396;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v21+18]");
		if (num16 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v22+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(0.1667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 1042985832;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v23+18]");
		if (num18 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v24+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(0.2f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 1045220557;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v25+18]");
		if (num20 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v26+18]");
		if (num21 >= 0)
		{
			list.AddWithResize(0.2333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 1047455282;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdx_v27+18]");
		if (num22 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdx_v28+18]");
		if (num23 >= 0)
		{
			list.AddWithResize(0.2667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 1049136359;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v29+18]");
		if (num24 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rcx_v57+18]");
		if (num25 >= 0)
		{
			list.AddWithResize(0.3f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 1050253722;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v31+18]");
		if (num26 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v32+18]");
		if (num27 >= 0)
		{
			list.AddWithResize(0.3333f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 1051371084;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v33+18]");
		if (num28 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v34+18]");
		if (num29 >= 0)
		{
			list.AddWithResize(0.3667f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 1052491802;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v35+18]");
		if (num30 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v36+18]");
		if (num31 >= 0)
		{
			list.AddWithResize(0.4f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 1053609165;
		}
		list.Add(0.1f);
		list.Add(0.4333f);
		list.Add(0.1f);
		list.Add(0.4667f);
		list.Add(0.1f);
		list.Add(0.5f);
		list.Add(0.1f);
		list.Add(0.5333f);
		list.Add(0.1f);
		list.Add(0.5667f);
		list.Add(0.1f);
		list.Add(0.6f);
		list.Add(0.1f);
		list.Add(0.6333f);
		list.Add(0.1f);
		list.Add(0.6667f);
		list.Add(0.1f);
		list.Add(0.7f);
		list.Add(0.1f);
		list.Add(0.7333f);
		list.Add(0.1f);
		list.Add(0.7667f);
		list.Add(0.1f);
		list.Add(0.8f);
		list.Add(0.1f);
		list.Add(0.8333f);
		list.Add(0.1f);
		list.Add(0.8667f);
		list.Add(0.1f);
		list.Add(0.9f);
		list.Add(0.1f);
		list.Add(0.9333f);
		list.Add(0.1f);
		list.Add(0.9667f);
		list.Add(0.1f);
		list.Add(1f);
		list.Add(0.1f);
		list.Add(1f);
		list.Add(0.1333f);
		list.Add(1f);
		list.Add(0.1667f);
		list.Add(1f);
		list.Add(0.2f);
		list.Add(0.9667f);
		list.Add(0.2f);
		list.Add(0.9333f);
		list.Add(0.2f);
		list.Add(0.9f);
		list.Add(0.2f);
		list.Add(0.8667f);
		list.Add(0.2f);
		list.Add(0.8333f);
		list.Add(0.2f);
		list.Add(0.8f);
		list.Add(0.2f);
		list.Add(0.7667f);
		list.Add(0.2f);
		list.Add(0.7333f);
		list.Add(0.2f);
		list.Add(0.7f);
		list.Add(0.2f);
		list.Add(0.6667f);
		list.Add(0.2f);
		list.Add(0.6333f);
		list.Add(0.2f);
		list.Add(0.6f);
		list.Add(0.2f);
		list.Add(0.5667f);
		list.Add(0.2f);
		list.Add(0.5333f);
		list.Add(0.2f);
		list.Add(0.5f);
		list.Add(0.2f);
		list.Add(0.4667f);
		list.Add(0.2f);
		list.Add(0.4333f);
		list.Add(0.2f);
		list.Add(0.4f);
		list.Add(0.2f);
		list.Add(0.3667f);
		list.Add(0.2f);
		list.Add(0.3333f);
		list.Add(0.2f);
		list.Add(0.3f);
		list.Add(0.2f);
		list.Add(0.2667f);
		list.Add(0.2f);
		list.Add(0.2333f);
		list.Add(0.2f);
		list.Add(0.2f);
		list.Add(0.2f);
		list.Add(0.1667f);
		list.Add(0.2f);
		list.Add(0.1333f);
		list.Add(0.2f);
		list.Add(0.1f);
		list.Add(0.2f);
		list.Add(0.0667f);
		list.Add(0.2f);
		list.Add(0.0333f);
		list.Add(0.2f);
		list.Add(0f);
		list.Add(0.2f);
		list.Add(0f);
		list.Add(0.2333f);
		list.Add(0f);
		list.Add(0.2667f);
		list.Add(0f);
		list.Add(0.3f);
		list.Add(0.0333f);
		list.Add(0.3f);
		list.Add(0.0667f);
		list.Add(0.3f);
		list.Add(0.1f);
		list.Add(0.3f);
		list.Add(0.1333f);
		list.Add(0.3f);
		list.Add(0.1667f);
		list.Add(0.3f);
		list.Add(0.2f);
		list.Add(0.3f);
		list.Add(0.2333f);
		list.Add(0.3f);
		list.Add(0.2667f);
		list.Add(0.3f);
		list.Add(0.3f);
		list.Add(0.3f);
		list.Add(0.3333f);
		list.Add(0.3f);
		list.Add(0.3667f);
		list.Add(0.3f);
		list.Add(0.4f);
		list.Add(0.3f);
		list.Add(0.4333f);
		list.Add(0.3f);
		list.Add(0.4667f);
		list.Add(0.3f);
		list.Add(0.5f);
		list.Add(0.3f);
		list.Add(0.5333f);
		list.Add(0.3f);
		list.Add(0.5667f);
		list.Add(0.3f);
		list.Add(0.6f);
		list.Add(0.3f);
		list.Add(0.6333f);
		list.Add(0.3f);
		list.Add(0.6667f);
		list.Add(0.3f);
		list.Add(0.7f);
		list.Add(0.3f);
		list.Add(0.7333f);
		list.Add(0.3f);
		list.Add(0.7667f);
		list.Add(0.3f);
		list.Add(0.8f);
		list.Add(0.3f);
		list.Add(0.8333f);
		list.Add(0.3f);
		list.Add(0.8667f);
		list.Add(0.3f);
		list.Add(0.9f);
		list.Add(0.3f);
		list.Add(0.9333f);
		list.Add(0.3f);
		list.Add(0.9667f);
		list.Add(0.3f);
		list.Add(1f);
		list.Add(0.3f);
		list.Add(1.0333f);
		list.Add(0.3f);
		list.Add(1.0667f);
		list.Add(0.3f);
		list.Add(1.1f);
		list.Add(0.3f);
		list.Add(1.1333f);
		list.Add(0.3f);
		list.Add(1.1667f);
		list.Add(0.3f);
		list.Add(1.2f);
		list.Add(0.3f);
		list.Add(1.2333f);
		list.Add(0.3f);
		list.Add(1.2667f);
		list.Add(0.3f);
		list.Add(1.3f);
		list.Add(0.3f);
		list.Add(1.3333f);
		list.Add(0.3f);
		list.Add(1.3667f);
		list.Add(0.3f);
		list.Add(1.4f);
		list.Add(0.3f);
		list.Add(1.4333f);
		list.Add(0.3f);
		list.Add(1.4667f);
		list.Add(0.3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v37+18]");
		if (num32 >= 0)
		{
			list.AddWithResize(1.5f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 1069547520;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v38+18]");
		if (num33 >= 0)
		{
			list.AddWithResize(0.3f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj66 = (nint)0 + (nint)1;
			_ = 1050253722;
		}
		CurveData = list;
		base._002Ector();
	}

	private void _003CInitWeapon_003Eb__12_0()
	{
		startPlanes(7);
	}
}
