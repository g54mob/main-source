using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Elec2_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_DarkElec_01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_DarkElec_", 1, 17, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0251: Expected O, but got I4
		//IL_0261: Expected O, but got I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_003d: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_00c2: Expected I, but got O
		//IL_0126: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		setVelocity(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float radius = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = radius ^ 0;
		BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Action onComplete2 = delegate
				{
					//IL_0008: Expected O, but got Ref
					//IL_027c: Expected O, but got Ref
					//IL_0034: Expected O, but got Ref
					//IL_01ef: Expected O, but got Ref
					//IL_02c1: Expected O, but got F4
					//IL_02de: Expected O, but got I
					//IL_041a: Expected O, but got F4
					//IL_0437: Expected O, but got I
					//IL_0311: Expected I, but got O
					//IL_00c9: Expected O, but got Ref
					//IL_00eb: Expected O, but got I
					//IL_0117: Expected O, but got I
					//IL_0149: Invalid comparison between O and F4
					//IL_0363: Expected I, but got O
					//IL_037c: Expected F4, but got O
					//IL_038c: Expected F4, but got I
					//IL_01a6: Expected O, but got F4
					//IL_039f: Expected I, but got O
					//IL_04ad: Expected O, but got Ref
					//IL_04bb: Expected O, but got Ref
					//IL_04c9: Expected F4, but got O
					//IL_03f9: Expected O, but got Ref
					//IL_0410->IL0410: Incompatible stack heights: 1 vs 0
					object obj4 = default(object);
					object obj3 = (object)(&obj4);
					_isCullable = true;
					GameManager core = GM.Core;
					object cachedTransform = _cachedTransform;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj4, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
						Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj4, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
						_ = 0;
						EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
						if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
						{
							object obj6 = UnityEngine.Random.value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							object obj7 = num3 + 0;
							float num4 = (float)obj7 + 1f;
							float num5 = num4 - 2f;
							object obj8 = UnityEngine.Random.value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							object obj9 = num6 + 0;
							float num7 = (float)obj9 + 1f;
							float num8 = num7 - 2f;
							nint num9 = (nint)typeof(Vector2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v49 (Il2CppClass<UnityEngine.Vector2>)+B8]");
							nint num10 = 0;
							_ = Vector2.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
							_ = 0;
							float2 float5 = enemyController.position;
							Weapon weapon2 = _weapon;
							float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
							object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj4, 103));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
							object obj11 = num11 - 0;
							float num12 = (float)obj11 + num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
							nint num13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+83]");
							object obj12 = num13 - 0;
							float num14 = (float)obj12 + num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
							float num15;
							float num16;
							if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
							{
								num15 = num12 / (float)Vector2.zeroVector;
								num16 = num14 / (float)Vector2.zeroVector;
							}
							else
							{
								nint num17 = (nint)typeof(Vector2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v78 (Il2CppClass<UnityEngine.Vector2>)+B8]");
								nint num18 = 0;
								num15 = (float)Vector2.zeroVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ rcx_v57 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
								num16 = 0f;
							}
							float projectileSpeed = base.ProjectileSpeed;
							float num19 = (float)Vector2.zeroVector * num15;
							float projectileSpeed2 = base.ProjectileSpeed;
							ArcadeSprite sprite = _sprite;
							float num20 = (float)Vector2.zeroVector * num16;
							BaseBody baseBody2 = sprite.body;
							baseBody2._velocity = (float2)num19;
							Transform transform = base.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
							nint num21 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ rax_v63 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v64 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
							_ = 0;
							_ = Vector3.forwardVector;
							_ = 0;
							object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj4, 41));
							object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj4, 25));
							Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj14, out *(Quaternion*)obj13);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							_ = 0;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj4, 9));
							Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj15);
						}
						else
						{
							Vector3 playerDirection = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj4, 25));
							_ = 0;
							ApplyPlayerFacingVelocity(playerDirection, rotate: false);
						}
						return;
					}
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
					throw new NullReferenceException();
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			PhaserSprite phaserSprite = _animatedSprite.setBlendMode(BlendMode.Normal);
			PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.85f);
			PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.9f;
			float detune = (float)_indexInWeapon * 100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Fulgur, soundConfig, 200f, 1, time);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void StartMoving()
	{
		Action onComplete = delegate
		{
			//IL_0008: Expected O, but got Ref
			//IL_027c: Expected O, but got Ref
			//IL_0034: Expected O, but got Ref
			//IL_01ef: Expected O, but got Ref
			//IL_02c1: Expected O, but got F4
			//IL_02de: Expected O, but got I
			//IL_041a: Expected O, but got F4
			//IL_0437: Expected O, but got I
			//IL_0311: Expected I, but got O
			//IL_00c9: Expected O, but got Ref
			//IL_00eb: Expected O, but got I
			//IL_0117: Expected O, but got I
			//IL_0149: Invalid comparison between O and F4
			//IL_0363: Expected I, but got O
			//IL_037c: Expected F4, but got O
			//IL_038c: Expected F4, but got I
			//IL_01a6: Expected O, but got F4
			//IL_039f: Expected I, but got O
			//IL_04ad: Expected O, but got Ref
			//IL_04bb: Expected O, but got Ref
			//IL_04c9: Expected F4, but got O
			//IL_03f9: Expected O, but got Ref
			//IL_0410->IL0410: Incompatible stack heights: 1 vs 0
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_isCullable = true;
			GameManager core = GM.Core;
			object cachedTransform = _cachedTransform;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
				Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
				_ = 0;
				EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
				if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
				{
					object obj4 = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					object obj5 = num + 0;
					float num2 = (float)obj5 + 1f;
					float num3 = num2 - 2f;
					object obj6 = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					object obj7 = num4 + 0;
					float num5 = (float)obj7 + 1f;
					float num6 = num5 - 2f;
					nint num7 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v49 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num8 = 0;
					_ = Vector2.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
					_ = 0;
					float2 float5 = enemyController.position;
					Weapon weapon = _weapon;
					float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
					object obj9 = num9 - 0;
					float num10 = (float)obj9 + num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+83]");
					object obj10 = num11 - 0;
					float num12 = (float)obj10 + num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
					float num13;
					float num14;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
					{
						num13 = num10 / (float)Vector2.zeroVector;
						num14 = num12 / (float)Vector2.zeroVector;
					}
					else
					{
						nint num15 = (nint)typeof(Vector2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v78 (Il2CppClass<UnityEngine.Vector2>)+B8]");
						nint num16 = 0;
						num13 = (float)Vector2.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ rcx_v57 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
						num14 = 0f;
					}
					float projectileSpeed = base.ProjectileSpeed;
					float num17 = (float)Vector2.zeroVector * num13;
					float projectileSpeed2 = base.ProjectileSpeed;
					ArcadeSprite sprite = _sprite;
					float num18 = (float)Vector2.zeroVector * num14;
					BaseBody baseBody = sprite.body;
					baseBody._velocity = (float2)num17;
					Transform transform = base.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					nint num19 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ rax_v63 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v64 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
					_ = 0;
					_ = Vector3.forwardVector;
					_ = 0;
					object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj12, out *(Quaternion*)obj11);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj13);
				}
				else
				{
					Vector3 playerDirection = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = 0;
					ApplyPlayerFacingVelocity(playerDirection, rotate: false);
				}
				return;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void StartDespawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		Despawn();
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0078: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			BaseBody baseBody = body;
			float num = (float)baseBody._velocity * 1.1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v6 (BaseBody)+74]");
			float num2 = 0f * 1.1f;
			baseBody._velocity = (float2)num;
		}
	}

	private unsafe void _003CInitProjectile_003Eb__5_0()
	{
		Action onComplete = delegate
		{
			//IL_0008: Expected O, but got Ref
			//IL_027c: Expected O, but got Ref
			//IL_0034: Expected O, but got Ref
			//IL_01ef: Expected O, but got Ref
			//IL_02c1: Expected O, but got F4
			//IL_02de: Expected O, but got I
			//IL_041a: Expected O, but got F4
			//IL_0437: Expected O, but got I
			//IL_0311: Expected I, but got O
			//IL_00c9: Expected O, but got Ref
			//IL_00eb: Expected O, but got I
			//IL_0117: Expected O, but got I
			//IL_0149: Invalid comparison between O and F4
			//IL_0363: Expected I, but got O
			//IL_037c: Expected F4, but got O
			//IL_038c: Expected F4, but got I
			//IL_01a6: Expected O, but got F4
			//IL_039f: Expected I, but got O
			//IL_04ad: Expected O, but got Ref
			//IL_04bb: Expected O, but got Ref
			//IL_04c9: Expected F4, but got O
			//IL_03f9: Expected O, but got Ref
			//IL_0410->IL0410: Incompatible stack heights: 1 vs 0
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_isCullable = true;
			GameManager core = GM.Core;
			object cachedTransform = _cachedTransform;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
				Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
				_ = 0;
				EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
				if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
				{
					object obj4 = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					object obj5 = num + 0;
					float num2 = (float)obj5 + 1f;
					float num3 = num2 - 2f;
					object obj6 = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					object obj7 = num4 + 0;
					float num5 = (float)obj7 + 1f;
					float num6 = num5 - 2f;
					nint num7 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v49 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num8 = 0;
					_ = Vector2.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
					_ = 0;
					float2 float5 = enemyController.position;
					Weapon weapon = _weapon;
					float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
					object obj9 = num9 - 0;
					float num10 = (float)obj9 + num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+83]");
					object obj10 = num11 - 0;
					float num12 = (float)obj10 + num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
					float num13;
					float num14;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
					{
						num13 = num10 / (float)Vector2.zeroVector;
						num14 = num12 / (float)Vector2.zeroVector;
					}
					else
					{
						nint num15 = (nint)typeof(Vector2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v78 (Il2CppClass<UnityEngine.Vector2>)+B8]");
						nint num16 = 0;
						num13 = (float)Vector2.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ rcx_v57 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
						num14 = 0f;
					}
					float projectileSpeed = base.ProjectileSpeed;
					float num17 = (float)Vector2.zeroVector * num13;
					float projectileSpeed2 = base.ProjectileSpeed;
					ArcadeSprite sprite = _sprite;
					float num18 = (float)Vector2.zeroVector * num14;
					BaseBody baseBody = sprite.body;
					baseBody._velocity = (float2)num17;
					Transform transform = base.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					nint num19 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ rax_v63 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v64 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
					_ = 0;
					_ = Vector3.forwardVector;
					_ = 0;
					object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj12, out *(Quaternion*)obj11);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj13);
				}
				else
				{
					Vector3 playerDirection = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = 0;
					ApplyPlayerFacingVelocity(playerDirection, rotate: false);
				}
				return;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void _003CStartMoving_003Eb__6_0()
	{
		//IL_0008: Expected O, but got Ref
		//IL_027c: Expected O, but got Ref
		//IL_0034: Expected O, but got Ref
		//IL_01ef: Expected O, but got Ref
		//IL_02c1: Expected O, but got F4
		//IL_02de: Expected O, but got I
		//IL_041a: Expected O, but got F4
		//IL_0437: Expected O, but got I
		//IL_0311: Expected I, but got O
		//IL_00c9: Expected O, but got Ref
		//IL_00eb: Expected O, but got I
		//IL_0117: Expected O, but got I
		//IL_0149: Invalid comparison between O and F4
		//IL_0363: Expected I, but got O
		//IL_037c: Expected F4, but got O
		//IL_038c: Expected F4, but got I
		//IL_01a6: Expected O, but got F4
		//IL_039f: Expected I, but got O
		//IL_04ad: Expected O, but got Ref
		//IL_04bb: Expected O, but got Ref
		//IL_04c9: Expected F4, but got O
		//IL_03f9: Expected O, but got Ref
		//IL_0410->IL0410: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_isCullable = true;
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v9 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
			Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
			_ = 0;
			EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				object obj4 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				object obj5 = num + 0;
				float num2 = (float)obj5 + 1f;
				float num3 = num2 - 2f;
				object obj6 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				object obj7 = num4 + 0;
				float num5 = (float)obj7 + 1f;
				float num6 = num5 - 2f;
				nint num7 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v49 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num8 = 0;
				_ = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				float2 float5 = enemyController.position;
				Weapon weapon = _weapon;
				float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
				object obj9 = num9 - 0;
				float num10 = (float)obj9 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+83]");
				object obj10 = num11 - 0;
				float num12 = (float)obj10 + num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
				float num13;
				float num14;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
				{
					num13 = num10 / (float)Vector2.zeroVector;
					num14 = num12 / (float)Vector2.zeroVector;
				}
				else
				{
					nint num15 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v78 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num16 = 0;
					num13 = (float)Vector2.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ rcx_v57 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
					num14 = 0f;
				}
				float projectileSpeed = base.ProjectileSpeed;
				float num17 = (float)Vector2.zeroVector * num13;
				float projectileSpeed2 = base.ProjectileSpeed;
				ArcadeSprite sprite = _sprite;
				float num18 = (float)Vector2.zeroVector * num14;
				BaseBody baseBody = sprite.body;
				baseBody._velocity = (float2)num17;
				Transform transform = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				nint num19 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ rax_v63 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v64 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				_ = 0;
				_ = Vector3.forwardVector;
				_ = 0;
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj12, out *(Quaternion*)obj11);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj13);
			}
			else
			{
				Vector3 playerDirection = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = 0;
				ApplyPlayerFacingVelocity(playerDirection, rotate: false);
			}
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}
}
