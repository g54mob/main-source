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
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SpriteWhip_WaterDragon_Projectile : Projectile
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
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_WaterWhip01");
				_animatedSprite = animatedSprite;
				if ((object)_animatedSprite != null)
				{
					PhaserSprite phaserSprite = _animatedSprite.setTint(8978431u);
					if ((object)_animatedSprite != null)
					{
						Transform transform = _animatedSprite.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							SetupAnimations();
							float extensionDuration = 13f / (float)AnimFPS;
							_extensionDuration = extensionDuration;
							return;
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
		//IL_0100: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_025c: Expected O, but got I4
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected I4, but got Unknown
		//IL_02fd: Expected O, but got I4
		//IL_01d6: Expected O, but got I4
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected I4, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_03a0: Expected F4, but got I4
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_04a2: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
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
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
		PhaserSprite phaserSprite3 = _animatedSprite.setScale(xScale, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		List<string> list = animNames;
		int num2 = _indexInWeapon % list._size;
		PhaserSprite animatedSprite = _animatedSprite;
		List<string> list2 = animNames;
		if (num2 < list2._size)
		{
			string[] items = list2._items;
			animatedSprite._spriteAnimation.SetAnimation(items[num2]);
			bool flag5;
			if (_cachedFlipX)
			{
				object obj = num2 - 2;
				int num3 = num2 ^ 2;
				int num4 = num2 ^ obj;
				int num5 = num3 & num4;
				bool flag = num5 < 0;
				bool flag2 = (nint)obj < 0;
				bool flag3 = obj == null;
				bool flag4 = flag2 != flag;
				flag5 = flag4 | flag3;
			}
			else
			{
				object obj2 = num2 - 2;
				int num6 = num2 ^ 2;
				int num7 = num2 ^ obj2;
				int num8 = num6 & num7;
				bool flag6 = num8 < 0;
				bool flag7 = (nint)obj2 < 0;
				bool flag8 = obj2 == null;
				bool flag9 = flag7 == flag6;
				bool flag10 = !flag8;
				flag5 = flag10 & flag9;
			}
			PhaserSprite phaserSprite4 = _animatedSprite.setFlipX(flag5);
			object obj3 = num2 - 1;
			bool flag11 = num2 == 1;
			if (!flag11)
			{
				obj3--;
				if (!flag11)
				{
					obj3--;
					if (!flag11)
					{
						bool flag12 = (nint)obj3 != 1;
						float num9 = (float)Math.PI / 2f;
						if (!flag12)
						{
							num9 = -(float)Math.PI / 2f;
						}
					}
					else
					{
						float num9 = -(float)Math.PI / 4f;
					}
				}
				else
				{
					float num9 = 0f;
				}
			}
			else
			{
				float num9 = (float)Math.PI / 4f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			if (_cachedFlipX)
			{
				float num10 = -1f;
			}
			else
			{
				float num10 = 1f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if (!_cachedFlipX)
			{
			}
			Vector3 directionalOffset = default(Vector3);
			_directionalOffset = directionalOffset;
			_ = 0;
			DOGetter<Vector3> dOGetter = null;
			Vector3 vector = _003CInitProjectile_003Eb__12_0();
			DOSetter<Vector3> dOSetter = null;
			((TP_SpriteWhip_WaterDragon_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__12_1((Vector3)this);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D900");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			UpdatePosition();
			Weapon weapon4 = _weapon;
			int num11 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.Depth;
			int num12 = num11 - 1;
			PhaserSprite phaserSprite5 = _animatedSprite.setDepth(num12);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * 100f;
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
		//IL_0168: Expected I, but got O
		//IL_023a: Expected I, but got O
		//IL_030c: Expected I, but got O
		//IL_03de: Expected I, but got O
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_WaterWhip", 1, 13, "ThosePeople", num);
		PhaserSprite animatedSprite = _animatedSprite;
		List<string> list = animNames;
		if (list._size > 2)
		{
			string[] items = list._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpriteWhip_WaterDragon_Projectile>)+440]");
			Action action = new Action(this, (IntPtr)0);
			nint num2 = (nint)this;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			animatedSprite._spriteAnimation.AddAnimation(items[2], animationFrames, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Whip", 14, 26, "ThosePeople", num);
			PhaserSprite animatedSprite2 = _animatedSprite;
			List<string> list2 = animNames;
			if (list2._size > 1)
			{
				string[] items2 = list2._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpriteWhip_WaterDragon_Projectile>)+440]");
				Action action2 = new Action(this, (IntPtr)0);
				nint num3 = (nint)this;
				animatedSprite2._spriteAnimation.AddAnimation(items2[1], animationFrames2, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
				List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_Whip", 1, 13, "ThosePeople", num);
				PhaserSprite animatedSprite3 = _animatedSprite;
				List<string> list3 = animNames;
				if (list3._size > 0)
				{
					string[] items3 = list3._items;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpriteWhip_WaterDragon_Projectile>)+440]");
					Action action3 = new Action(this, (IntPtr)0);
					nint num4 = (nint)this;
					animatedSprite3._spriteAnimation.AddAnimation(items3[0], animationFrames3, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_Whip", 14, 26, "ThosePeople", num);
					PhaserSprite animatedSprite4 = _animatedSprite;
					List<string> list4 = animNames;
					if (list4._size > 3)
					{
						string[] items4 = list4._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpriteWhip_WaterDragon_Projectile>)+440]");
						Action action4 = new Action(this, (IntPtr)0);
						nint num5 = (nint)this;
						animatedSprite4._spriteAnimation.AddAnimation(items4[3], animationFrames4, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("TP_VFX_Whip", 1, 13, "ThosePeople", num);
						PhaserSprite animatedSprite5 = _animatedSprite;
						List<string> list5 = animNames;
						if (list5._size > 4)
						{
							string[] items5 = list5._items;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpriteWhip_WaterDragon_Projectile>)+440]");
							Action action5 = new Action(this, (IntPtr)0);
							nint num6 = (nint)this;
							animatedSprite5._spriteAnimation.AddAnimation(items5[4], animationFrames5, AnimFPS, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
							return;
						}
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				bool flag = TryFreeze(other);
			}
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
		PhaserSprite animatedSprite = _animatedSprite;
		if ((object)_animatedSprite != null && ((UnityEngine.Object)animatedSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		}
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	public TP_SpriteWhip_WaterDragon_Projectile()
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
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"attack_diag_up");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"attack_up");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"attack_diag_back");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"attack_back");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.Projectiles.TP_SpriteWhip_WaterDragon_Projectile)+100]");
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
