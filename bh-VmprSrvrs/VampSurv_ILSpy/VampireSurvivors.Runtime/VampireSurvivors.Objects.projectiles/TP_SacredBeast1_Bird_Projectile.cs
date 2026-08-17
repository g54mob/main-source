using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SacredBeast1_Bird_Projectile : Projectile
{
	private Vector3 _movement;

	private float _flipSwitch;

	[NonSerialized]
	public float orbitRadius;

	[NonSerialized]
	public float orbitAngle;

	private MultiTargetTween _speedTween;

	private MultiTargetTween _scaleTween;

	private float _spinDuration;

	private bool _rotatingState;

	private Vector3 _offset;

	private SpriteAnimation _anim;

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Owl", 1, 13, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("flapping", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("ProjectileBird", 3, 3, "vfx", num);
		_anim.AddAnimation("gliding", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0381: Expected O, but got F4
		//IL_0021: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_00a6: Expected O, but got F4
		//IL_010d: Expected O, but got I4
		//IL_03b8: Expected O, but got F4
		//IL_051b: Expected O, but got F4
		//IL_0189: Expected I, but got O
		//IL_046c: Expected I4, but got O
		//IL_04ee: Expected O, but got I4
		//IL_01ce->IL035e: Incompatible stack heights: 1 vs 0
		//IL_020e->IL035e: Incompatible stack heights: 1 vs 0
		//IL_029a->IL035e: Incompatible stack heights: 1 vs 0
		//IL_02d3->IL035e: Incompatible stack heights: 1 vs 0
		//IL_02f5->IL035e: Incompatible stack heights: 1 vs 0
		//IL_0324->IL035e: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		float num = default(float);
		_offset = (Vector3)num;
		_ = 0;
		_isCullable = true;
		if ((object)weapon != null)
		{
			float num2 = weapon.PArea();
			ArcadeSprite arcadeSprite = setScale(num, (float?)(object)0);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					Weapon weapon2 = _weapon;
					_movement = (Vector3)num;
					_ = 0;
					if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						bool flag = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
						object obj = (flag ? 1 : 0) * 2;
						float num3 = (_flipSwitch = (float)obj - 1f);
						orbitAngle = -(float)Math.PI / 2f;
						object obj2 = UnityEngine.Random.value;
						float num4 = num3 - 0.5f;
						float num5 = num4 * 0.25f;
						float num6 = (orbitRadius = num5 + 0.75f);
						float projectileSpeed = base.ProjectileSpeed;
						float spinDuration = num6 * 300f;
						_spinDuration = spinDuration;
						object obj3 = UnityEngine.Random.value;
						if (_speedTween != null)
						{
							_speedTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							nint num7 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj4 = default(object);
							bool flag2 = obj4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								Dictionary<string, object> dictionary = new Dictionary<string, object>();
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								if (dictionary != null)
								{
									object value = default(object);
									bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"orbitAngle", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									_ = _spinDuration;
									TweenCallback tweenCallback = shootDiscus;
									MultiTargetTween speedTween = Tweens.Add(tweenConfig);
									_speedTween = speedTween;
									if ((object)_anim != null)
									{
										_anim.SetAnimation("flapping");
										Weapon weapon3 = _weapon;
										if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
										{
											Transform transform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
											if ((object)transform != null)
											{
												bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												int num8 = (int)_cachedTransform;
												bool flag5 = (object)_cachedTransform == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rbp_v13 (System.Int32)+10]");
												bool flag6 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rbp_v13 (System.Int32)+10]");
												float value2 = default(float);
												Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
												_rotatingState = true;
												SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
												{
													Rate = 1f,
													Volume = (float?)(object)1
												};
												float detune = (float)_indexInWeapon * -100f;
												soundConfig.Detune = detune;
												float time = default(float);
												PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Candle, soundConfig, 50f, 3, time);
												return;
											}
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
	}

	public void shootDiscus()
	{
		_rotatingState = false;
		float projectileSpeed = base.ProjectileSpeed;
		float num = _flipSwitch * 1.2217305f;
		object obj = default(object);
		float speed = (float)obj * 4f;
		float rotation = num + orbitAngle;
		Vector2 vector = SetVelocityFromRotation(rotation, speed);
		Transform transform = base.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void InternalUpdate()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_01ec->IL0136: Incompatible stack heights: 1 vs 0
		//IL_01c8->IL01c8: Incompatible stack heights: 3 vs 1
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (_rotatingState)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					object cachedTransform = _cachedTransform;
					bool flag2 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rsi_v10 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rsi_v10 (System.Object)+10]");
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)0, ref value);
				}
				BaseBody baseBody = body;
				if (body != null)
				{
					bool flag4 = 0 < (nint)baseBody._velocity;
					object obj = 0 - baseBody._velocity;
					bool flag5 = obj == null;
					bool flag6 = !flag4;
					bool flag7 = !flag5;
					bool flag8 = flag7 & flag6;
					ArcadeSprite arcadeSprite = setFlipX(flag8);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		bool flag = _speedTween == null;
		_rotatingState = false;
		if (!flag)
		{
			_speedTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	public TP_SacredBeast1_Bird_Projectile()
	{
		Vector3 offset = default(Vector3);
		_offset = offset;
		_ = 0;
		base._002Ector();
	}
}
