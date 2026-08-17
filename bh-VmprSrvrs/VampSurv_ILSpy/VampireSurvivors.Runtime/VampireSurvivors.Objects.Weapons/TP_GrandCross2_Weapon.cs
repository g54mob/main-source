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
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_GrandCross2_Weapon : Weapon
{
	private Projectile _BeamProjectilePrefab;

	private const float BeamDamageMultiplier = 1.3f;

	private bool _hasSprites;

	private PhaserSprite _lightSprite;

	private Rectangle _pfxRect;

	private ParticleSystem _pfx;

	private EmitZone _pfxEmitZone;

	private BulletPool _beamProjectilePool;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _scaleTween;

	public float BeamWidth
	{
		get
		{
			Rectangle pfxRect = _pfxRect;
			return pfxRect._width;
		}
	}

	public float BeamHeight
	{
		get
		{
			Rectangle pfxRect = _pfxRect;
			return pfxRect._height;
		}
	}

	public float2 BeamScale
	{
		get
		{
			//IL_0053: Expected O, but got I4
			float num = PArea();
			Camera main = Camera.main;
			bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			object obj = Camera.get_pixelHeight_Injected(((UnityEngine.Object)main).m_CachedPtr);
			float2 result = default(float2);
			return result;
		}
	}

	public float2 BeamXExtents
	{
		get
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if (_pfxRect != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					float2 result = default(float2);
					if (_pfxRect != null)
					{
						return result;
					}
				}
			}
			return (float2)new NullReferenceException();
		}
	}

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(3f > num2);
		float result = 3f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		base.OnStart();
		if (_beamProjectilePool == null)
		{
			BulletPool beamProjectilePool = new BulletPool(_BeamProjectilePrefab);
			_beamProjectilePool = beamProjectilePool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Beam;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_beamProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_beamProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		InitSpritesAndPfx();
		_pfx.Play(withChildren: true);
	}

	private unsafe void InitSpritesAndPfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03a1: Expected O, but got Ref
		//IL_03bb: Expected native int or pointer, but got O
		//IL_064f: Expected O, but got I4
		//IL_03d3: Expected O, but got Ref
		//IL_03fa: Expected O, but got I
		//IL_0414: Expected native int or pointer, but got O
		//IL_042e: Expected O, but got I
		//IL_044e: Expected O, but got Ref
		//IL_0463: Expected native int or pointer, but got O
		//IL_047d: Expected O, but got I
		//IL_049d: Expected O, but got Ref
		//IL_04b7: Expected native int or pointer, but got O
		//IL_066c: Expected O, but got I4
		//IL_04dc: Expected O, but got Ref
		//IL_04f6: Expected native int or pointer, but got O
		//IL_069e: Expected O, but got I
		//IL_053a->IL05ba: Incompatible stack heights: 1 vs 0
		//IL_0597->IL05ba: Incompatible stack heights: 1 vs 0
		//IL_0717->IL0717: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_hasSprites)
		{
			return;
		}
		_hasSprites = true;
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F82C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite lightSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "HolyBeamGradient");
			_lightSprite = lightSprite;
			if ((object)_lightSprite != null)
			{
				Transform transform = _lightSprite.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rax_v35 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rax_v35 (UnityEngine.Transform)+10]");
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected((IntPtr)0, ref value);
				Transform parent = base.transform;
				Transform transform2 = _lightSprite.transform;
				transform2.SetParent(parent, worldPositionStays: true);
				PhaserSprite phaserSprite = _lightSprite.setVisible(visible: true);
				PhaserSprite phaserSprite2 = _lightSprite.setAlpha(0.15f);
				PhaserSprite phaserSprite3 = _lightSprite.setBlendMode(BlendMode.Add);
				PhaserSprite phaserSprite4 = _lightSprite.setDepth(1);
				GameObject gameObject2 = _lightSprite.gameObject;
				((UnityEngine.Object)gameObject2).SetName("HolyBeamGradient");
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
				List<string> list = new List<string>();
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"PfxYellow");
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
					((List<object>)(object)list).AddWithResize((object)"PfxYellow");
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
					((List<object>)(object)list).AddWithResize((object)"PfxLine");
				}
				else
				{
					int size3 = list._size + 1;
					list._size = size3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				particleSystemConfig._frame = list;
				ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
				particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
				ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
				_ = 0;
				_ = 4;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
				particleSystemConfig._quantity = (int?)(object)0;
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
				particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(250f));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
				particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
				_ = 0;
				particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 1f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
				particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
				_ = 0;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Transform parent2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent2, "GrandCross emitter");
					_pfx = pfx;
					if ((object)_pfx != null)
					{
						Transform transform3 = _pfx.transform;
						bool flag2 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2034 @ rax_v81 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2034 @ rax_v81 (UnityEngine.Transform)+10]");
						Vector3 value2 = default(Vector3);
						Transform.set_localPosition_Injected((IntPtr)0, ref value2);
						UpdatePfxEmitZone();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected F4, but got O
		base.InternalUpdate();
		float2 beamScale = BeamScale;
		float2 beamScale2 = BeamScale;
		PhaserSprite phaserSprite = _lightSprite.setScale((float)beamScale, (float?)(object)1);
		UpdatePfxEmitZone();
	}

	private void UpdateLightSprite()
	{
		//IL_0019: Expected O, but got I4
		//IL_0019: Expected F4, but got O
		float2 beamScale = BeamScale;
		float2 beamScale2 = BeamScale;
		PhaserSprite phaserSprite = _lightSprite.setScale((float)beamScale, (float?)(object)1);
	}

	private void UpdatePfxEmitZone()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		float num = PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.64f;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Rectangle rectangle = new Rectangle();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = num2 ^ 0;
		float x = (float)obj2 * 0.5f;
		rectangle._height = renderer.screenHeight;
		rectangle._width = num2;
		rectangle._x = x;
		float y = renderer.screenHeight * 0.5f;
		rectangle._y = y;
		_pfxRect = rectangle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _pfxRect;
		_pfxEmitZone = emitZone;
		RenderingExtensions.SetEmitZone(_pfx, _pfxEmitZone);
	}

	public void TriggerBeam()
	{
		//IL_0077: Expected O, but got F4
		//IL_0065: Expected F4, but got I4
		//IL_0085: Expected O, but got F4
		//IL_00b3: Expected F4, but got I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		Projectile projectile = _beamProjectilePool.SpawnAt(pos, this);
		object obj = UnityEngine.Random.value;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Hellfire1, 500f, 3, 0f, volume, rate, detune, loop, 1f);
		object obj2 = UnityEngine.Random.value;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_StarFlail, 500f, 3, 0f, volume, rate, detune, loop, 1f);
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 2;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _lightSprite.setVisible(visible);
		if (!visible)
		{
			_pfx.Stop();
		}
		else
		{
			_pfx.Play(withChildren: true);
		}
	}

	public override void Cleanup()
	{
		if ((object)_lightSprite != null)
		{
			PhaserSprite phaserSprite = _lightSprite.setVisible(visible: false);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if ((object)_pfx != null)
		{
			_pfx.Stop();
		}
		base.Cleanup();
	}

	private bool OnBulletOverlapsEnemy_Beam(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015a: Expected I4, but got O
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
						goto IL_0177;
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
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 * obj2;
									float damage = (float)obj * 1.3f;
									base.DealDamage(component, damage);
								}
								goto IL_0177;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0177:
		return false;
	}
}
