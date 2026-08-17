using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class MirageRobeWeapon : Weapon
{
	protected bool collides = true;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _ringTween2;

	private Collider ProjectileOnProjectileCollider;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_007e: Expected O, but got Ref
		//IL_007e: Expected O, but got Ref
		//IL_007e: Expected O, but got Ref
		//IL_0139: Expected I4, but got I8
		//IL_0148->IL00a8: Incompatible stack heights: 1 vs 0
		base.InitWeapon(characterController, weaponType);
		SpriteRenderer ringSprite = _ringSprite;
		_explosionType = WeaponType.COLDEXPLOSION;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			Vector2 vector = default(Vector2);
			string text = default(string);
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "vfx", text);
			object obj = default(object);
			object obj2 = default(object);
			object obj3 = default(object);
			BlendMode blendMode = default(BlendMode);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(spriteRenderer, (Color)(&obj), (Color)(&obj2), (Color)(&obj3), (Color)text, blendMode);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0f);
			bool flag = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer3).m_CachedPtr, -1);
			_ringSprite = spriteRenderer3;
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_025f: Expected O, but got I4
		//IL_027b: Expected O, but got F4
		//IL_0039: Invalid comparison between F4 and I4
		//IL_00d0: Expected I, but got O
		//IL_0136: Expected I, but got O
		//IL_0188: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_00f3->IL00f3: Incompatible stack heights: 1 vs 0
		//IL_0159->IL0159: Incompatible stack heights: 1 vs 0
		base.Fire(skipTriggers);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.25f;
		float detune = num * 1000f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Clones, soundConfig, 100f, 8, time);
		float num2 = base.PArea();
		if (!(1f > 0f) || _ringTween2 != null)
		{
			_ringTween2.Kill();
		}
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_ringSprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 150f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			if ((object)_ringSprite != null)
			{
				Transform transform2 = _ringSprite.transform;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Transform transform3 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					if ((object)transform3 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
						bool flag4 = (object)transform2 == null;
						bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
						return;
					}
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_005e: Expected I, but got O
			//IL_00c2: Expected O, but got I4
			if (_ringTween2 != null)
			{
				_ringTween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_ringSprite != null)
			{
				nint num5 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 100f;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0.5f);
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete2 = delegate
			{
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween ringTween2 = Tweens.Add(tweenConfig2);
			_ringTween2 = ringTween2;
		};
		tweenConfig.onComplete = onComplete;
		TweenCallback onUpdate = delegate
		{
			if ((object)_ringSprite != null)
			{
				Transform transform2 = _ringSprite.transform;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Transform transform3 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					if ((object)transform3 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
						bool flag4 = (object)transform2 == null;
						bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						return;
					}
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onUpdate = onUpdate;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
	}

	protected override void OnStart()
	{
		base.OnStart();
		if (collides)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider projectileOnProjectileCollider = physics.add.collider(_projectilePool, _projectilePool, null, processCallback, callbackContext);
			ProjectileOnProjectileCollider = projectileOnProjectileCollider;
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_00ec: Invalid comparison between F4 and I4
		//IL_0160: Expected O, but got I
		//IL_01a5: Expected I, but got O
		//IL_01d7: Invalid comparison between F4 and I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				float num = base.PPower();
				WeaponData currentWeaponData = _currentWeaponData;
				HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
				float knockback = base.Knockback;
				float value = default(float);
				component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
				float num2 = base.PPower();
				WeaponData currentWeaponData2 = _currentWeaponData;
				float num3 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
				base._003CStatsInflictedDamage_003Ek__BackingField = num3;
				if (currentWeaponData2._003Cchance_003Ek__BackingField > 0f)
				{
					List<float> critChancesArray = _critChancesArray;
					int critIndex = _critIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
					int num4 = (int)((nint)critIndex % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)num4 >= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					int critIndex2 = _critIndex + 1;
					_critIndex = critIndex2;
					WeaponData currentWeaponData3 = _currentWeaponData;
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
					nint num5 = (nint)characterController;
					float num6 = characterController.PLuck();
					float num7 = 0f * currentWeaponData3._003Cchance_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v17+20+v103 @ rdx_v17 (System.Int32)*4]");
					if (num7 > 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
						float2 pos = default(float2);
						Projectile projectile = base.SpawnExplosionAt(pos, 0, 1, 0f);
					}
				}
			}
		}
		return false;
	}

	public override float SecondaryPPower()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.MirageRobeWeapon>)+428]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.MirageRobeWeapon>)+430]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				World world = ArcadePhysics.s_world.removeCollider(ProjectileOnProjectileCollider);
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	private void _003CFire_003Eb__6_0()
	{
		if ((object)_ringSprite != null)
		{
			Transform transform = _ringSprite.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CFire_003Eb__6_1()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_ringTween2 != null)
		{
			_ringTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0.5f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween2 = ringTween;
	}

	private void _003CFire_003Eb__6_3()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0.5f);
	}

	private void _003CFire_003Eb__6_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
	}

	private void _003CFire_003Eb__6_2()
	{
		if ((object)_ringSprite != null)
		{
			Transform transform = _ringSprite.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
