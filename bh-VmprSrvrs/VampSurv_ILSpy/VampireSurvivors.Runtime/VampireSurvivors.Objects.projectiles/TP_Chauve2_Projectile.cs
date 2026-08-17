using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Chauve2_Projectile : TP_Chauve1_Projectile
{
	private Transform _BeamSpawnPoint;

	private Timer _animTimer;

	private float _beamXOffset;

	private TP_Chauve2_Weapon _trueWeapon;

	protected override bool IsEvo => true;

	protected override string SpriteName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4201]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_Chauve0";
		}
	}

	protected override string SpriteObjectName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4202]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_Chauve2_Sprite";
		}
	}

	protected override uint Tint => 4128777u;

	protected unsafe override void Awake()
	{
		base.Awake();
		object beamSpawnPoint = _BeamSpawnPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbx_v1 (System.Object)+10]");
		float ret;
		Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)(&ret));
		_beamXOffset = ret;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0027: Expected I, but got O
		//IL_002f: Expected I4, but got O
		//IL_003f: Expected O, but got I
		//IL_00bf: Expected O, but got I4
		//IL_007b: Expected O, but got I
		//IL_014a: Invalid comparison between F4 and O
		//IL_0168: Invalid comparison between F4 and I4
		//IL_00b1: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag = (object)_weapon == null;
		TP_Chauve2_Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_0201;
		}
		nint num = (nint)typeof(TP_Chauve2_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Chauve2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v5 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Chauve2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v5 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v26+FFFFFFF8+v63 @ rax_v22*8]");
			if (0 == (nint)typeof(TP_Chauve2_Weapon))
			{
				obj3 = 1;
				goto IL_0210;
			}
		}
		obj3 = 0;
		goto IL_0210;
		IL_0201:
		_trueWeapon = trueWeapon;
		float chanceFromArray = _weapon.GetChanceFromArray();
		Weapon weapon3 = _weapon;
		WeaponData currentWeaponData = weapon3._currentWeaponData;
		Weapon weapon4 = _weapon;
		float num4 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.PLuck();
		Weapon weapon5 = _weapon;
		object obj4 = default(object);
		float num5 = (float)obj4 * currentWeaponData._003CcritChance_003Ek__BackingField;
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
		float num6 = num5 - (float)obj4;
		bool flag3 = num6 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		bool isCrit = flag5 & flag4;
		_isCrit = isCrit;
		int critIndex = weapon5._critIndex + 1;
		weapon5._critIndex = critIndex;
		return;
		IL_0210:
		bool flag6 = obj3 == null;
		trueWeapon = null;
		if (!flag6)
		{
			trueWeapon = (TP_Chauve2_Weapon)_weapon;
		}
		goto IL_0201;
	}

	private void CheckForCrit()
	{
		//IL_0077: Invalid comparison between F4 and O
		//IL_0095: Invalid comparison between F4 and I4
		float chanceFromArray = _weapon.GetChanceFromArray();
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		Weapon weapon2 = _weapon;
		float num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PLuck();
		Weapon weapon3 = _weapon;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003CcritChance_003Ek__BackingField;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num3 = num2 - (float)obj;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool isCrit = flag4 & flag3;
		_isCrit = isCrit;
		int critIndex = weapon3._critIndex + 1;
		weapon3._critIndex = critIndex;
	}

	protected unsafe override void MakeCritProjectile()
	{
		//IL_021d: Expected F4, but got I4
		//IL_0260: Expected I, but got O
		//IL_026e: Expected I, but got O
		//IL_027e: Expected O, but got I
		//IL_02fe: Expected O, but got I4
		//IL_02ba: Expected O, but got I
		//IL_030b: Expected I4, but got O
		//IL_02f0: Expected O, but got I4
		//IL_0375: Expected O, but got I4
		//IL_03d1->IL037b: Incompatible stack heights: 1 vs 0
		//IL_017f->IL037b: Incompatible stack heights: 1 vs 0
		//IL_04b4->IL037b: Incompatible stack heights: 7 vs 0
		//IL_01f1->IL037b: Incompatible stack heights: 7 vs 0
		//IL_053b->IL037b: Incompatible stack heights: 8 vs 0
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Chauve4", "ThosePeople");
		Projectile projectile;
		float2 float5 = default(float2);
		bool flag11;
		nint num4;
		object obj3;
		int num3;
		float2 float6;
		if ((object)_displaySprite != null)
		{
			PhaserSprite phaserSprite = _displaySprite.setFrame(sprite);
			if (_animTimer != null)
			{
				_animTimer.Cancel();
			}
			Action onComplete = delegate
			{
				Sprite sprite2 = SpriteManager.GetSprite("TP_VFX_Chauve0", "ThosePeople");
				PhaserSprite phaserSprite2 = _displaySprite.setFrame(sprite2);
			};
			bool flag = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer animTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_animTimer = animTimer;
			if ((object)_BeamSpawnPoint != null)
			{
				Transform transform = _BeamSpawnPoint.transform;
				if ((object)_BeamSpawnPoint != null)
				{
					Transform transform2 = _BeamSpawnPoint.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
						if ((object)_BeamSpawnPoint != null)
						{
							Transform transform3 = _BeamSpawnPoint.transform;
							if ((object)transform3 != null)
							{
								bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret2);
								bool flag4 = (object)transform == null;
								bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								float2 value = default(float2);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
								bool flag6 = (object)_BeamSpawnPoint == null;
								Transform transform4 = _BeamSpawnPoint.transform;
								bool flag7 = (object)transform4 == null;
								bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
								if ((object)_BeamSpawnPoint != null)
								{
									Transform transform5 = _BeamSpawnPoint.transform;
									if ((object)transform5 != null)
									{
										bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret2);
										float num = _cachedAngle * ((float)Math.PI / 180f);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
										float num2 = _cachedAngle * ((float)Math.PI / 180f);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
										if ((object)_trueWeapon != null)
										{
											projectile = _trueWeapon.SpawnBeamAt(float5, 0, 1, flag ? 1 : 0);
											bool flag10 = (object)projectile == null;
											flag11 = false;
											num3 = 1;
											float6 = float5;
											if (!flag10)
											{
												num4 = (nint)projectile;
												nint num5 = (nint)typeof(TP_Chauve2_Beam_Projectile);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1453 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Chauve2_Beam_Projectile>)+130]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1452 @ r9_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
												nint num6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1453 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Chauve2_Beam_Projectile>)+130]");
												if (num6 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1452 @ r9_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
													object obj2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ rax_v90+FFFFFFF8+v1454 @ rax_v86*8]");
													if (0 == (nint)typeof(TP_Chauve2_Beam_Projectile))
													{
														obj3 = 1;
														goto IL_0545;
													}
												}
												obj3 = 0;
												goto IL_0545;
											}
											goto IL_0586;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0586:
		if (flag11)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rsi_v14 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
				((TP_Chauve2_Beam_Projectile)flag11).ManualInitProjectile(float5, float5);
			}
		}
		return;
		IL_0545:
		bool flag12 = obj3 == null;
		flag11 = false;
		num3 = (int)num4;
		float6 = (float2)typeof(TP_Chauve2_Beam_Projectile);
		if (!flag12)
		{
			flag11 = (byte)(int)projectile != 0;
			num3 = (int)num4;
			float6 = (float2)typeof(TP_Chauve2_Beam_Projectile);
		}
		goto IL_0586;
	}

	private void DoCritAnim()
	{
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Chauve4", "ThosePeople");
		PhaserSprite phaserSprite = _displaySprite.setFrame(sprite);
		if (_animTimer != null)
		{
			_animTimer.Cancel();
		}
		Action onComplete = delegate
		{
			Sprite sprite2 = SpriteManager.GetSprite("TP_VFX_Chauve0", "ThosePeople");
			PhaserSprite phaserSprite2 = _displaySprite.setFrame(sprite2);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer animTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_animTimer = animTimer;
	}

	public override void Despawn()
	{
		if (_animTimer != null)
		{
			_animTimer.Cancel();
		}
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		((Projectile)this).Despawn();
	}

	private void _003CDoCritAnim_003Eb__16_0()
	{
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Chauve0", "ThosePeople");
		PhaserSprite phaserSprite = _displaySprite.setFrame(sprite);
	}
}
