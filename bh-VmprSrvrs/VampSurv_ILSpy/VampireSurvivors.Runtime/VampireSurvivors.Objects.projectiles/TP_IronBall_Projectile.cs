using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_IronBall_Projectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__19_0;

		public static TweenCallback _003C_003E9__19_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__19_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__19_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	protected const float Radius = 12f;

	protected const float Grav = 6.25f;

	protected Vector2 _velocity;

	protected float _startingAngle;

	protected float _saveVelX;

	protected float _saveVelY;

	protected bool _hasHitScreenBottom;

	protected Tween _angleTween;

	protected MultiTargetTween _scaleTween;

	public override float ProjectileSpeed
	{
		get
		{
			//IL_000d: Expected I, but got O
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected F4, but got Unknown
			//IL_0058: Invalid comparison between F4 and I4
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				nint num = (nint)weapon;
				float num2 = _weapon.PSpeed();
				float num4 = default(float);
				float num3 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				num4 = num3 & 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				if ((object)_weapon != null)
				{
					float num5 = _weapon.PSpeed();
					float num6 = ((num4 < 0f) ? (-1f) : 1f);
					float num7 = GameManager.ProjectileSpeed * num4;
					float num8 = num7 * _speed;
					return num8 * num6;
				}
			}
			throw new NullReferenceException();
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_005c: Expected I, but got O
		//IL_0110: Expected O, but got Ref
		//IL_02af: Expected O, but got I4
		//IL_0320: Expected I, but got O
		//IL_0384: Expected O, but got I4
		//IL_03ae: Invalid comparison between F4 and O
		//IL_03d7: Invalid comparison between O and F4
		//IL_072d: Expected O, but got I4
		//IL_0683: Expected I, but got O
		//IL_06c3: Expected O, but got I
		//IL_04a3: Expected I, but got O
		//IL_04b3: Expected O, but got I4
		//IL_0524: Expected I, but got O
		//IL_048a: Expected I4, but got I8
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		_speed = 1.65f;
		_isCullable = false;
		_hasHitScreenBottom = false;
		nint num = (nint)weapon2;
		float num2 = weapon2.PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float num3 = (float)obj / 10f;
		float duration = 1f - num3;
		if (_angleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		object obj2 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&obj2), duration, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		float num4 = _weapon.PArea();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 250f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			Vector2 vector = default(Vector2);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
			float alpha = 1f;
			if (!flag)
			{
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
				{
					float num6 = (float)vector - 1f;
					float num7 = num6 * 0.39999998f;
					float num8 = num7 * 0.5f;
					alpha = 1f - num8;
				}
				else
				{
					alpha = 0.6f;
				}
			}
			ArcadeSprite arcadeSprite2 = setAlpha(alpha);
			Weapon weapon3 = _weapon;
			if (!weapon3.IsHoming)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
				nint num9 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v44 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num10 = 0;
				object obj4 = characterController._lastFacingDirection * Vector2.rightVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v33 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ rcx_v35 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
				object obj5 = num11 * 0;
				object obj6 = obj4 + obj5;
				bool flag2 = 0 <= (nint)obj6;
				RotateMode rotateMode = RotateMode.FastBeyond360;
				if (!flag2)
				{
					rotateMode = (RotateMode)(-1);
				}
				float num12 = _weapon.PAmount();
				nint num13 = (nint)this;
				object obj7 = _indexInWeapon + 1;
				float num14 = (float)rotateMode * 12.5f;
				float num15 = num14 / (float)vector;
				float num16 = num15 * (float)obj7;
				float num17 = num16 - 90f;
				float num18 = (_startingAngle = num17 * ((float)Math.PI / 180f));
				float projectileSpeed = ProjectileSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				nint num19 = (nint)this;
				float projectileSpeed2 = ProjectileSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num20 = num18 * num18;
				float num21 = num20 * -1f;
				if (num21 > 6f)
				{
					_velocity = vector;
					goto IL_0708;
				}
			}
			Transform transform = base.AimForNearestEnemy();
			BaseBody baseBody2 = body;
			_velocity = baseBody2._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v42 (BaseBody)+74]");
			_ = 0;
			goto IL_0708;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
		IL_0708:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.6f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordThrow, soundConfig, 200f, 10, time);
	}

	public override void InternalUpdate()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_007b: Invalid comparison between F4 and O
		//IL_00db: Expected F4, but got O
		//IL_0129: Expected F4, but got I
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 6.25f;
		float num2 = num * -1f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_IronBall_Projectile)+D4]");
		float num4 = num3 + 0f;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v7 (UnityEngine.Bounds)+10]");
		object obj2 = default(object);
		object obj = obj2 - 0;
		float2 float5 = base.position;
		float num5 = (float)obj - 1f;
		object obj3 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			float2 float6 = base.position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				OnHittingScreenBottom();
			}
		}
		else
		{
			Despawn();
		}
		BaseBody baseBody2 = body;
		float saveVelX = (float)baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187124F97h\"");
		if ((object)baseBody2._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v10 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187124FB8h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v10 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	public virtual void OnHittingScreenBottom()
	{
		//IL_0032: Expected O, but got I
		//IL_00a3: Expected O, but got I8
		if (_hasHitScreenBottom)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		_hasHitScreenBottom = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TP_IronBall_Projectile tP_IronBall_Projectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tP_IronBall_Projectile = (TP_IronBall_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v38 @ rax_v2 (should have been resolved before IL gen)");
		_ = 2.5f;
		PlayHitSFX();
		ScreenShake();
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_010b: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_0122;
			}
		}
		obj5 = 4294967295L;
		goto IL_0122;
		IL_0122:
		float num3 = (_saveVelX = (float)obj5 * _saveVelX);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num3;
		_ = _saveVelY;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x187125140\"");
	}

	private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00ae: Expected I, but got O
		//IL_010c: Expected O, but got F4
		//IL_012e: Expected F4, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				Despawn();
			}
			return;
		}
		nint num = (nint)this;
		int bounces = _bounces - 1;
		_bounces = bounces;
		float projectileSpeed = ProjectileSpeed;
		float speed = default(float);
		Vector2 vector = SetVelocityFromRotation(_startingAngle, speed);
		float num2 = (float)_velocity * -1f;
		BaseBody baseBody = body;
		_velocity = (Vector2)num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v9 (BaseBody)+74]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num4 = num3 ^ 0;
		bool flag = !(-6f < num4);
		float num5 = -6f;
		if (!flag)
		{
			num5 = num4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		PlayHitSFX();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 176 Invalid \"Jump target not found in method: 0x1871252B0\"");
		throw new NullReferenceException();
	}

	protected void ScreenShake()
	{
		//IL_00b3: Expected I, but got O
		//IL_0133: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
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
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__19_0;
		if (_003C_003Ec._003C_003E9__19_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__19_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__19_1;
		if (_003C_003Ec._003C_003E9__19_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__19_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	protected void PlayHitSFX()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.3f;
		soundConfig.Detune = -500f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack1, soundConfig, 50f, 1, time);
	}
}
