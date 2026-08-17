using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_PlatinumWhip1_Projectile : Projectile
{
	private int AnimFPS = 60;

	private SpriteAnimation _anim;

	private MultiTargetTween _alphaTween;

	private bool _cachedFlipX;

	private PhaserSprite _animatedSprite;

	private Vector3 _directionalOffset;

	private float _bodyRadius = 20f;

	private float _extensionLength = 80f;

	private float _extensionDuration = 13f;

	private float _heightOffset;

	private List<string> animNames;

	protected override void Awake()
	{
		//IL_0259: Expected I, but got O
		//IL_01a2->IL02d4: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL02d4: Incompatible stack heights: 1 vs 0
		//IL_021b->IL02d4: Incompatible stack heights: 2 vs 0
		//IL_027c->IL02d4: Incompatible stack heights: 3 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_PlatinumWhip01");
				if ((object)phaserSprite != null)
				{
					GameObject gameObject2 = phaserSprite.gameObject;
					if ((object)gameObject2 != null)
					{
						((UnityEngine.Object)gameObject2).SetName("TP_PlatinumWhip1_Projectile_Sprite");
						_animatedSprite = phaserSprite;
						if ((object)_animatedSprite != null)
						{
							Transform transform = _animatedSprite.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								int num = default(int);
								List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_PlatinumWhip", 1, 13, "ThosePeople", num);
								PhaserSprite animatedSprite = _animatedSprite;
								if ((object)_animatedSprite != null)
								{
									List<string> list = animNames;
									if (animNames != null)
									{
										bool flag2 = list._size <= 0;
										string[] items = list._items;
										if (list._items != null)
										{
											bool flag3 = items.Length <= 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v779 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_PlatinumWhip1_Projectile>)+440]");
											Action action = new Action(this, (IntPtr)0);
											nint num2 = (nint)this;
											if ((object)animatedSprite._spriteAnimation != null)
											{
												bool startRandomFrame = default(bool);
												Action onComplete = default(Action);
												bool autoSetAnimation = default(bool);
												animatedSprite._spriteAnimation.AddAnimation(items[0], animationFrames, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
												float extensionDuration = 13f / (float)AnimFPS;
												_extensionDuration = extensionDuration;
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

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0061: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected F4, but got Unknown
		//IL_009d: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0354: Expected O, but got I4
		//IL_02c7: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		_isCullable = false;
		_extensionLength = 70f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Weapon weapon3 = _weapon;
		_cachedFlipX = characterController._isFlipped;
		float getSpriteWhipOffset = ((Equipment)weapon3)._003COwner_003Ek__BackingField.GetSpriteWhipOffset;
		float heightOffset = default(float);
		_heightOffset = heightOffset;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float xScale = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		float num = _weapon.PArea();
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite2 = _animatedSprite.setFlipX(_cachedFlipX);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		PhaserSprite phaserSprite4 = _animatedSprite.setScale(xScale, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		List<string> list = animNames;
		PhaserSprite animatedSprite = _animatedSprite;
		int num2 = _indexInWeapon % list._size;
		if (num2 < list._size)
		{
			string[] items = list._items;
			animatedSprite._spriteAnimation.SetAnimation(items[num2]);
			bool flag = !_cachedFlipX;
			if (!flag)
			{
				float num3 = -1f;
			}
			else
			{
				float num3 = 1f;
			}
			object obj = !flag;
			if (obj != null)
			{
				Vector3 directionalOffset = default(Vector3);
				_directionalOffset = directionalOffset;
				_ = 0;
				DOGetter<Vector3> dOGetter = null;
				Vector3 vector = _003CInitProjectile_003Eb__12_0();
				DOSetter<Vector3> dOSetter = null;
				((TP_PlatinumWhip1_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__12_1((Vector3)this);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D900");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			UpdatePosition();
			Weapon weapon4 = _weapon;
			int num4 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.Depth;
			int num5 = num4 - 1;
			PhaserSprite phaserSprite5 = _animatedSprite.setDepth(num5);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * 50f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Whip, soundConfig, 200f, 10, time);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		//IL_0196->IL00e6: Incompatible stack heights: 3 vs 0
		//IL_00d2->IL00e6: Incompatible stack heights: 3 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			Weapon weapon2 = (Weapon)(object)((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Weapon firingAnimEvent = (Weapon)(object)weapon2._firingAnimEvent;
				if (weapon2._firingAnimEvent != null)
				{
					bool flag = ((UnityEngine.Object)firingAnimEvent).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)firingAnimEvent).m_CachedPtr, out Vector3 ret);
					Weapon cachedTransform = (Weapon)(object)_cachedTransform;
					bool flag2 = (object)_cachedTransform == null;
					bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
					float2 float5 = base.position;
					if ((object)_animatedSprite != null)
					{
						PhaserSprite phaserSprite = _animatedSprite.setPosition(float5);
						Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret);
							bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupAnimations()
	{
		//IL_0096: Expected I, but got O
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_PlatinumWhip", 1, 13, "ThosePeople", num);
		PhaserSprite animatedSprite = _animatedSprite;
		List<string> list = animNames;
		if (list._size > 0)
		{
			string[] items = list._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_PlatinumWhip1_Projectile>)+440]");
			Action action = new Action(this, (IntPtr)0);
			nint num2 = (nint)this;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			animatedSprite._spriteAnimation.AddAnimation(items[0], animationFrames, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	protected virtual void OnAnimAttackComplete()
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
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
		tweenConfig.ease = Ease.InSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = AlphaTweenFinished;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void AlphaTweenFinished()
	{
		_alphaTween = null;
		if (body != null)
		{
			Despawn();
		}
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		PhaserSprite animatedSprite = _animatedSprite;
		if ((object)_animatedSprite != null && ((UnityEngine.Object)animatedSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		}
		base.Despawn();
	}

	public TP_PlatinumWhip1_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"attack");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		animNames = list;
		base._002Ector();
	}

	private unsafe Vector3 _003CInitProjectile_003Eb__12_0()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)_directionalOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.Projectiles.TP_PlatinumWhip1_Projectile)+100]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	private void _003CInitProjectile_003Eb__12_1(Vector3 x)
	{
		//IL_000f: Expected O, but got F4
		_directionalOffset = (Vector3)x.x;
		_ = x.z;
	}
}
