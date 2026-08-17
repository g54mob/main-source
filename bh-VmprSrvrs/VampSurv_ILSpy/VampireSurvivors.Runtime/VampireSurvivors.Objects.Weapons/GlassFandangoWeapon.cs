using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GlassFandangoWeapon : Weapon
{
	private float _walked;

	private Timer _walkedTimer;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private const float MUL = 500f;

	public float ProjectilePixelSize = 40f;

	public override float PArea()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		GameManager core = GM.Core;
		bool flag = !core._003CIsTimeStopped_003Ek__BackingField;
		float num = 1f;
		if (!flag)
		{
			num = 2.5f;
		}
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj2 = default(object);
		object obj = obj2 * currentWeaponData._003Carea_003Ek__BackingField;
		return (float)obj * num;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b2: Expected O, but got I
		//IL_053c: Expected O, but got Ref
		//IL_0556: Expected native int or pointer, but got O
		//IL_0570: Expected O, but got I
		//IL_0590: Expected O, but got Ref
		//IL_05aa: Expected native int or pointer, but got O
		//IL_080c: Expected O, but got I4
		//IL_05c2: Expected O, but got Ref
		//IL_05e9: Expected O, but got I
		//IL_0603: Expected native int or pointer, but got O
		//IL_061d: Expected O, but got I
		//IL_063d: Expected O, but got Ref
		//IL_0657: Expected native int or pointer, but got O
		//IL_0829: Expected O, but got I4
		//IL_066f: Expected O, but got Ref
		//IL_0689: Expected native int or pointer, but got O
		//IL_0853: Expected O, but got I
		//IL_06c1: Expected O, but got Ref
		//IL_06e8: Expected O, but got I
		//IL_06fd: Expected native int or pointer, but got O
		//IL_0717: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		base._003CTotalTime_003Ek__BackingField = 0f;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
			GameObject gameObject = base.gameObject;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v4 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			_ = 0;
			ParticleEmitterManager pfxEmitterManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
				pfxEmitterManager = (ParticleEmitterManager)0;
			}
			else
			{
				pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_pfxEmitterManager = pfxEmitterManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0000");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0001");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0006");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0002");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0003");
			}
			else
			{
				int size5 = list._size + 1;
				list._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list._version + 1;
			list._version = version6;
			string[] items6 = list._items;
			if (list._size >= items6.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0004");
			}
			else
			{
				int size6 = list._size + 1;
				list._size = size6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version7 = list._version + 1;
			list._version = version7;
			string[] items7 = list._items;
			if (list._size >= items7.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"snowb0005");
			}
			else
			{
				int size7 = list._size + 1;
				list._size = size7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(50f, 100f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(300f, 600f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 1.5f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-500f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
			_ = 0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
			_pfxEmitter = pfxEmitter;
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int depth = -renderer.pixelHeight;
			ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(depth);
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0055: Expected O, but got I4
		base.Fire(skipTriggers);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 0f, 10, time);
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0163: Expected I4, but got O
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
						goto IL_0180;
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
								bool flag = component2.HasAlreadyHitObject(component);
								if (!flag)
								{
									bool flag2 = component._003CIsTimeStopped_003Ek__BackingField != flag;
									HitVfxType hitVfxType = HitVfxType.Fire;
									if (!flag2)
									{
										hitVfxType = HitVfxType.Default;
									}
									float num = base.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									object obj = default(object);
									float num2 = (float)obj * (float)hitVfxType;
									bool flag3 = _currentWeaponData == null;
									HitVfxType showHitVfx = HitVfxType.Default;
									if (!flag3)
									{
										showHitVfx = currentWeaponData._003ChitVFX_003Ek__BackingField;
									}
									float knockback = base.Knockback;
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_0180;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0180:
		return false;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_walkedTimer != null)
		{
			_walkedTimer.Cancel();
		}
	}

	public override void InternalUpdate()
	{
		//IL_01e2->IL0191: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL00c4: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		Component component = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = deltaTime * 1000f;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2 (UnityEngine.Component)+230]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_00c4;
			}
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)_pfxEmitterManager != null)
				{
					Vector2 pos = default(Vector2);
					_pfxEmitterManager.EmitParticleAt(pos);
					goto IL_00c4;
				}
			}
		}
		goto IL_0191;
		IL_00c4:
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float num3 = num / 500f;
			float num4 = frameWalk * 100f;
			float num5 = num4 * num3;
			float num6 = (base._003CTotalTime_003Ek__BackingField = num5 + num2);
			float num7 = base.PInterval();
			if (!(num6 < frameWalk))
			{
				base._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
			return;
		}
		goto IL_0191;
		IL_0191:
		throw new NullReferenceException();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
