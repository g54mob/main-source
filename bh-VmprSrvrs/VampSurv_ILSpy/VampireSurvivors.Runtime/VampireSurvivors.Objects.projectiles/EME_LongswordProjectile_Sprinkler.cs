using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_LongswordProjectile_Sprinkler : Projectile
{
	private ParticleSystem _particlesVFX;

	protected float Radius = 38f;

	private PhaserSprite _animatedSprite;

	private Timer _hitboxTimer;

	private MultiTargetTween _fadeOutTween;

	private Projectile _parentProjectile;

	private int[] _tints = new int[7] { 15658513, 15654161, 14544401, 14540049, 14540253, 16760438, 16761033 };

	private BlendMode[] _blends;

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
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "Emeralds_VFX", "EME_LONGSWORD_vfx_1");
				_animatedSprite = animatedSprite;
				int num = default(int);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("EME_LONGSWORD_vfx_", 1, 4, "Emeralds_VFX", num);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation("slash", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					if ((object)_animatedSprite != null)
					{
						PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
						if ((object)_animatedSprite != null)
						{
							Transform transform = _animatedSprite.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							Transform transform2 = _animatedSprite.transform;
							bool flag2 = (object)transform2 == null;
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value2 = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void setParentProjectile(Projectile parent)
	{
		_parentProjectile = parent;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02dd: Expected O, but got I4
		//IL_02f6: Expected O, but got I4
		//IL_0158: Expected I, but got O
		//IL_01b8: Expected O, but got I4
		//IL_01d3: Expected I, but got O
		//IL_0304: Expected O, but got F4
		//IL_0332: Expected O, but got I4
		//IL_017b->IL017b: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = true;
		_tints = new int[5] { 15658598, 14540100, 13421670, 14540100, 14737629 };
		BlendMode[] blends = new BlendMode[3];
		_ = 1;
		_blends = blends;
		int[] tints = _tints;
		object obj = UnityEngine.Random.RandomRangeInt(0, tints.Length);
		PhaserSprite phaserSprite = _animatedSprite.setTint((uint)tints[obj]);
		BlendMode[] blends2 = _blends;
		object obj2 = UnityEngine.Random.RandomRangeInt(0, blends2.Length);
		PhaserSprite phaserSprite2 = _animatedSprite.setBlendMode((BlendMode)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref blends2[obj2]));
		_particlesVFX.Play(withChildren: true);
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Sprinkler>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
		UpdatePositionAndScale();
		PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite4 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("slash");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj4 = UnityEngine.Random.value;
		object obj5 = default(object);
		float num3 = (float)obj5 - 0.5f;
		float detune = num3 * 500f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_sprink, soundConfig, 100f, 5, time);
	}

	public override void InternalUpdate()
	{
		UpdatePositionAndScale();
	}

	private void UpdatePositionAndScale()
	{
		//IL_0380: Expected O, but got F4
		//IL_02a4: Expected O, but got F4
		//IL_011d: Expected O, but got F4
		//IL_013a: Expected O, but got F4
		//IL_02b2: Expected O, but got F4
		//IL_02c8: Expected F4, but got O
		//IL_0215: Expected O, but got I4
		//IL_0215: Expected O, but got I4
		//IL_0172->IL021a: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL021a: Incompatible stack heights: 1 vs 0
		Projectile parentProjectile = _parentProjectile;
		if ((object)_parentProjectile != null && ((UnityEngine.Object)parentProjectile).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_parentProjectile == null)
			{
				goto IL_021a;
			}
			float2 float5 = _parentProjectile.position;
			base.position = float5;
		}
		if ((object)_animatedSprite != null)
		{
			Transform transform = _animatedSprite.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			float num = Radius * 1.25f;
			object obj = UnityEngine.Random.value;
			object obj2 = UnityEngine.Random.value;
			Transform transform2 = _animatedSprite.transform;
			Vector3 localEulerAngles = transform2.localEulerAngles;
			float num2 = num * 0.005f;
			float num3 = localEulerAngles.z * ((float)Math.PI / 180f);
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			object obj3 = num2 ^ -0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			object obj4 = num2 ^ -0f;
			float num4 = num3 * (float)obj4;
			object obj5 = default(object);
			float num5 = (float)obj5 + num4;
			if ((object)_animatedSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				Transform transform3 = base.transform;
				if ((object)transform3 != null)
				{
					Transform transform4 = transform3.transform;
					object obj6 = UnityEngine.Random.value;
					Quaternion.AngleAxis_Injected((float)transform3, ref value, out Quaternion _);
					bool flag2 = (object)transform4 == null;
					bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Quaternion value2 = default(Quaternion);
					Transform.set_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
					bool flag4 = (object)_animatedSprite == null;
					Transform transform5 = _animatedSprite.transform;
					bool flag5 = (object)transform5 == null;
					bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value);
					bool flag7 = body == null;
					BaseBody baseBody = body.setCircle(num, (float?)(object)1, (float?)(object)1);
					return;
				}
			}
		}
		goto IL_021a;
		IL_021a:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		_renderer.enabled = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		base.Despawn();
	}

	public EME_LongswordProjectile_Sprinkler()
	{
		BlendMode[] blends = new BlendMode[5];
		_ = 1;
		_blends = blends;
		base._002Ector();
	}
}
