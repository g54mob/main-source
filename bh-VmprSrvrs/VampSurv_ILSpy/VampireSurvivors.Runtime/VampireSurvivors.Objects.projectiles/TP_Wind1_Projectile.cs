using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Wind1_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private Vector2 _initialVel;

	private float _startingAngle;

	private float GravX = 6.25f;

	private float GravY = 6.25f;

	private float _bodyRadius = 8f;

	private float _spriteSize = 30f;

	protected float[] _firingAngles = new float[8] { 0f, 0f, 5f, 5f, 10f, 10f, 15f, 15f };

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeInTrailTween;

	protected float _trailAlpha = 0.3f;

	private bool _mirrored;

	private bool _flip;

	private Sequence _windSequence;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			Sprite sprite2 = SpriteManager.GetSprite("TP_VFX_Wind03", "ThosePeople");
			ArcadeSprite arcadeSprite = setFrame(sprite2);
			TrailRenderer trail = _Trail;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				TrailRenderer.set_textureMode_Injected(((UnityEngine.Object)trail).m_CachedPtr, LineTextureMode.Tile);
				SetupTrail();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
	}

	public void SetFlip(bool __flip)
	{
		//IL_0024: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_008d: Expected I, but got O
		//IL_00f3: Expected I4, but got I8
		//IL_0926: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected I4, but got Unknown
		//IL_0213: Expected O, but got F4
		//IL_0268: Expected O, but got I4
		//IL_030f: Expected F4, but got I
		//IL_036d: Expected O, but got I4
		//IL_03f2: Expected I4, but got I8
		//IL_04c6: Expected I, but got O
		//IL_052a: Expected O, but got I4
		//IL_05d5: Expected I4, but got F4
		//IL_07f1: Expected O, but got I4
		//IL_0831: Expected O, but got I4
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float num2 = _bodyRadius + _bodyRadius;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		CheckRenderer();
		nint num3 = (nint)typeof(RenderingExtensions);
		float num4 = _bodyRadius + _bodyRadius;
		float num5 = num4 / _spriteSize;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(((ArcadeSprite)this)._spriteRenderer, num5);
		_speed = 1f;
		_isCullable = false;
		int num6 = (int)(_indexInWeapon & 0x80000001L);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rcx_v13 (Il2CppClass<VampireSurvivors.App.Tools.RenderingExtensions>)+E4]");
		if ((nint)0 < (nint)0)
		{
			object obj = num6 - 1;
			object obj2 = obj | -2;
			num6 = obj2 + 1;
		}
		object obj3 = num6 - 1;
		bool mirrored = obj3 == null;
		_flip = __flip;
		_mirrored = mirrored;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb esi,esi\"");
		if (num6 == 1)
		{
			float[] firingAngles = _firingAngles;
			int num7 = _indexInWeapon % firingAngles.Length;
			float projectileSpeed = base.ProjectileSpeed;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,edi\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,esi\"");
			float num8 = 0f * firingAngles[num7];
			float num9 = num8 * ((float)Math.PI / 180f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale((SpriteRenderer)(object)this, 0f);
			float num10 = num9 * num2;
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)(object)this, 0f);
			float num11 = num9 * num2;
			baseBody2._velocity = (float2)num10;
			BaseBody baseBody3 = body;
			_initialVel = baseBody3._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v38 (BaseBody)+74]");
			_ = 0;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * 50f;
			soundConfig.Detune = detune;
			float num12 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Pneuma, soundConfig, 200f, 10, num12);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] targets = new object[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v38 (BaseBody)+74]");
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale((SpriteRenderer)(object)this, 0f);
			if ((object)spriteRenderer4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = targets;
				tweenConfig.duration = 200f;
				tweenConfig.scale = (float?)(object)1;
				MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
				_scaleTween = scaleTween;
				object obj4 = default(object);
				float startWidth = (float)obj4 * 0.14f;
				_Trail.startWidth = startWidth;
				_Trail.endWidth = 0f;
				int num13 = _weapon.ActiveProjectileCount();
				bool flag = num13 > 50;
				int sortingOrder = -1998;
				if (!flag)
				{
					sortingOrder = 2;
				}
				_Trail.sortingOrder = sortingOrder;
				float num14 = UpdateTrailAlpha();
				_Trail.emitting = true;
				if (_fadeInTrailTween != null)
				{
					_fadeInTrailTween.Kill();
				}
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array = new object[1];
				Material material = ((Renderer)_Trail).GetMaterial();
				if ((object)material != null)
				{
					nint num15 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array;
				tweenConfig2.duration = 500f;
				tweenConfig2.alpha = (float?)(object)1;
				TweenCallback onStart = delegate
				{
					Material material2 = ((Renderer)_Trail).GetMaterial();
					RenderingExtensions.SetAlpha(material2, 0f);
				};
				tweenConfig2.onStart = onStart;
				MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig2);
				_fadeInTrailTween = fadeInTrailTween;
				float num16 = _weapon.PDuration();
				Action onComplete = StartDespawn;
				float duration = num14 * 0.001f;
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num12 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				GravX = 0f;
				GravY = -6f;
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((TP_Wind1_Projectile)(object)dOSetter)._003CSetFlip_003Eb__16_1(0f);
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 16.25f, 0.2f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Tween windSequence = _windSequence;
				if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
				{
					TweenExtensions.Kill(_windSequence);
				}
				Sequence sequence = DOTween.Sequence();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				sequence.stringId = "DefaultGameTweenId";
				_windSequence = sequence;
				Sequence windSequence2 = _windSequence;
				DOGetter<float> getter2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter2 = null;
				((TP_Wind1_Projectile)(object)dOSetter2)._003CSetFlip_003Eb__16_3(0f);
				TweenerCore<float, float, FloatOptions> t = DOTween.To(getter2, dOSetter2, 6.25f, 1f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				bool flag2 = TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t, false);
				bool flag3 = !flag2;
				float num17 = 6.25f;
				object obj6 = 0;
				if (!flag3)
				{
					num17 = ((Tween)windSequence2).duration;
					Sequence sequence2 = Sequence.DoInsert(_windSequence, (Tween)t, ((Tween)windSequence2).duration);
					obj6 = 0;
				}
				Sequence windSequence3 = _windSequence;
				DOGetter<float> getter3 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter3 = null;
				((TP_Wind1_Projectile)(object)dOSetter3)._003CSetFlip_003Eb__16_5(0f);
				TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter3, dOSetter3, 120.25f, 0.5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t2, false))
				{
					Sequence sequence3 = Sequence.DoInsert(_windSequence, (Tween)t2, ((Tween)windSequence3).duration);
				}
				return;
			}
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		//IL_0181: Expected I, but got O
		//IL_01e5: Expected O, but got I4
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_fadeInTrailTween != null)
			{
				_fadeInTrailTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Material material = ((Renderer)_Trail).GetMaterial();
			if ((object)material != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 200f;
			tweenConfig2.alpha = (float?)(object)1;
			MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig2);
			_fadeInTrailTween = fadeInTrailTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public override void InternalUpdate()
	{
		//IL_0023: Expected O, but got I4
		//IL_00df: Expected O, but got F4
		//IL_0102: Expected O, but got I4
		//IL_0040: Expected O, but got I8
		//IL_0052: Expected O, but got I8
		//IL_019a: Expected F4, but got O
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * GravX;
		object obj = 1;
		if (!_flip)
		{
			obj = 4294967295L;
		}
		float num2 = num * (float)obj;
		float num3 = num2 + (float)_initialVel;
		_initialVel = (Vector2)num3;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num4 = deltaTime2 * GravY;
		object obj2 = 1;
		if (!_mirrored)
		{
			obj2 = 4294967295L;
		}
		float num5 = num4 * (float)obj2;
		float num6 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile)+DC]");
		float num7 = num6 + 0f;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _initialVel;
		BaseBody baseBody2 = body;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		float num8 = UpdateTrailAlpha();
	}

	private float UpdateTrailAlpha()
	{
		//IL_0022: Expected O, but got I4
		//IL_0053: Invalid comparison between F4 and I
		//IL_007a: Expected F4, but got I
		int num = _weapon.ActiveProjectileCount();
		object obj = num - 1;
		float num2 = (float)obj * 0.005f;
		float num3 = _trailAlpha - num2;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A0FF94]");
		if (num4 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A0FF94]");
			num3 = 0f;
		}
		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_Trail, num3);
		return num3;
	}

	public override void Despawn()
	{
		Tween windSequence = _windSequence;
		if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_windSequence);
		}
		object trail = _Trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v1 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		_Trail.emitting = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_scaleTween = null;
		if (_fadeInTrailTween != null)
		{
			_fadeInTrailTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		//IL_00aa: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			float projectileSpeed = base.ProjectileSpeed;
			float speed = default(float);
			Vector2 vector = SetVelocityFromRotation(_startingAngle, speed);
			float num2 = (float)_initialVel * -1f;
			_initialVel = (Vector2)num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Wind1_Projectile)+DC]");
			float num3 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void SetupTrail()
	{
		//IL_0134->IL00b8: Incompatible stack heights: 1 vs 0
		//IL_018a->IL00b8: Incompatible stack heights: 2 vs 0
		if ((object)_Trail != null)
		{
			_Trail.emitting = false;
			if ((object)_Trail != null)
			{
				Material material = ((Renderer)_Trail).GetMaterial();
				RenderingExtensions.SetAlpha(material, 0f);
				object trail = _Trail;
				if ((object)_Trail != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v7 (System.Object)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					object trail2 = _Trail;
					if ((object)_Trail != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v8 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v8 (System.Object)+10]");
						Renderer.set_sortingOrder_Injected((IntPtr)0, 31767);
						if ((object)_Trail != null)
						{
							_Trail.time = 0.4f;
							TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CSetFlip_003Eb__16_6()
	{
		Material material = ((Renderer)_Trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
	}

	private float _003CSetFlip_003Eb__16_0()
	{
		return GravX;
	}

	private void _003CSetFlip_003Eb__16_1(float x)
	{
		GravX = x;
	}

	private float _003CSetFlip_003Eb__16_2()
	{
		return GravY;
	}

	private void _003CSetFlip_003Eb__16_3(float x)
	{
		GravY = x;
	}

	private float _003CSetFlip_003Eb__16_4()
	{
		return GravY;
	}

	private void _003CSetFlip_003Eb__16_5(float x)
	{
		GravY = x;
	}
}
