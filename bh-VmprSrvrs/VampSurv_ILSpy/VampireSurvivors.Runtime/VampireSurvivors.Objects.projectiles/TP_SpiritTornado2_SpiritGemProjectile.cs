using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SpiritTornado2_SpiritGemProjectile : Projectile
{
	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxEmitter;

	private Pickup _objectToFollow;

	private bool _003CSpawnExplosion_003Ek__BackingField;

	public bool SpawnExplosion
	{
		get
		{
			return _003CSpawnExplosion_003Ek__BackingField;
		}
		set
		{
			_003CSpawnExplosion_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_009d: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00bf: Expected I4, but got O
		//IL_0278: Expected O, but got F4
		//IL_01e6: Expected O, but got F4
		//IL_01f1: Expected I4, but got O
		//IL_025c: Expected O, but got I4
		//IL_016f: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		Sprite sprite = SpriteManager.GetSprite("GemBlue", "items");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		GenerateParticleSystem();
		_objectToFollow = null;
		_isCullable = false;
		_speed = 1f;
		_003CSpawnExplosion_003Ek__BackingField = true;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			int num = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v10 (System.Int32)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v10 (System.Int32)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				object obj = UnityEngine.Random.value;
				object obj2 = UnityEngine.Random.value;
				int num2 = (int)_cachedTransform;
				bool flag2 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rsi_v11 (System.Int32)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rsi_v11 (System.Int32)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Gem, new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 1f
				}, 1f, 1, time);
				bool flag4 = (object)_renderer == null;
				Transform transform = _renderer.transform;
				bool flag5 = (object)transform == null;
				Vector3 localEulerAngles = transform.localEulerAngles;
				transform.localEulerAngles = (Vector3)(&ret);
				ArcadeSprite arcadeSprite3 = setVisible(visible: true);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void Follow(Pickup objectToFollow)
	{
		_objectToFollow = objectToFollow;
		((ArcadeSprite)objectToFollow).CheckRenderer();
		Sprite sprite = ((ArcadeSprite)objectToFollow)._spriteRenderer.sprite;
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InternalUpdate()
	{
		//IL_01a6: Expected I, but got O
		//IL_01ae: Expected I, but got O
		//IL_01be: Expected O, but got I
		//IL_01fa: Expected O, but got I
		//IL_0237: Expected O, but got I
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_0317: Expected O, but got I
		//IL_03a1->IL0327: Incompatible stack heights: 1 vs 0
		//IL_0193->IL0327: Incompatible stack heights: 1 vs 0
		//IL_01e5->IL0327: Incompatible stack heights: 1 vs 0
		//IL_007d->IL0327: Incompatible stack heights: 1 vs 0
		//IL_0222->IL0327: Incompatible stack heights: 1 vs 0
		//IL_00a9->IL0327: Incompatible stack heights: 1 vs 0
		//IL_03e7->IL0327: Incompatible stack heights: 1 vs 0
		//IL_00f8->IL0327: Incompatible stack heights: 1 vs 0
		//IL_02bd->IL0327: Incompatible stack heights: 1 vs 0
		//IL_02f4->IL0327: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		Vector2 pos = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_pfxManager != null)
			{
				_pfxManager.EmitParticleAt(pos, 5);
				Weapon objectToFollow = (Weapon)(object)_objectToFollow;
				if ((object)_objectToFollow == null || ((UnityEngine.Object)objectToFollow).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0150;
				}
				if ((object)_objectToFollow != null)
				{
					GameObject gameObject = _objectToFollow.gameObject;
					if ((object)gameObject != null)
					{
						if (!gameObject.activeSelf)
						{
							goto IL_0150;
						}
						ArcadeSprite objectToFollow2 = _objectToFollow;
						if ((object)_objectToFollow != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v32 (ArcadeSprite)+120]");
							if ((nint)0 != 0)
							{
								float2 float5 = _objectToFollow.position;
								base.position = float5;
								ArcadeSprite arcadeSprite = setVisible(visible: false);
								return;
							}
							goto IL_0320;
						}
					}
				}
			}
		}
		goto IL_0327;
		IL_0150:
		if (!_003CSpawnExplosion_003Ek__BackingField)
		{
			goto IL_0320;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			nint num = (nint)typeof(TP_SpiritTornado2_Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v24+FFFFFFF8+v117 @ rax_v23*8]");
				if (0 == (nint)typeof(TP_SpiritTornado2_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v24+FFFFFFF8+v598 @ rcx_v20*8]");
					object obj4 = 0 - typeof(TP_SpiritTornado2_Weapon);
					bool flag2 = obj4 == null;
					bool flag3 = !flag2;
					Weapon weapon2 = null;
					if (!flag3)
					{
						weapon2 = _weapon;
					}
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							float2 float7 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdi_v9 (VampireSurvivors.Objects.Weapons.Weapon)+198]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdi_v9 (VampireSurvivors.Objects.Weapons.Weapon)+198]");
								Projectile projectile = ((BulletPool)0).SpawnAt(pos, weapon2);
								goto IL_0320;
							}
						}
					}
				}
			}
		}
		goto IL_0327;
		IL_0320:
		base.Despawn();
		return;
		IL_0327:
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		//IL_01f7: Expected native int or pointer, but got O
		//IL_0373: Expected O, but got I
		//IL_022f: Expected O, but got Ref
		//IL_0256: Expected O, but got I
		//IL_026b: Expected native int or pointer, but got O
		//IL_0285: Expected O, but got I
		//IL_02a5: Expected O, but got Ref
		//IL_02bf: Expected native int or pointer, but got O
		//IL_03ad: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter == null || ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPink");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxYellow");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+27]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+37]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
			_ = 0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter2 = _pfxManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
			_pfxEmitter = pfxEmitter2;
		}
	}
}
