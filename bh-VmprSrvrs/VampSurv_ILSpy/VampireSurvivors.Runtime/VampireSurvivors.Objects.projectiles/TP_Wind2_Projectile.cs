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
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Wind2_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private float _startingAngle;

	private float _bodyRadius = 8f;

	private float _spriteSize = 30f;

	protected float[] _firingAngles = new float[8] { 0f, 0f, 5f, 5f, 10f, 10f, 15f, 15f };

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeInTrailTween;

	protected float _trailAlpha = 0.3f;

	private bool _mirrored;

	private bool _flip;

	private Sequence _windSequence;

	private bool _isLight = true;

	private float _waveAngle;

	private float _waveIncrement = 0.003f;

	private Vector3 _startingPosition;

	private Vector3 _startingOffset;

	private float _height = 4f;

	private Tween _heightTween;

	private float _spriteRotateAngle;

	private float _spriteRotateSpeed;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			Sprite sprite2 = SpriteManager.GetSprite("TP_VFX_Wind01", "ThosePeople");
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
		//IL_0089: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		_waveAngle = 0f;
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		_startingPosition = ret;
		_ = 0;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_startingOffset = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
	}

	public unsafe void SetFlip(bool __flip, bool __horizontalMirror)
	{
		//IL_0024: Expected O, but got I4
		//IL_0038: Expected O, but got F4
		//IL_0069: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_00d8: Expected O, but got I
		//IL_0150: Expected I, but got O
		//IL_016d: Expected O, but got I
		//IL_0143: Expected O, but got I8
		//IL_020f: Expected O, but got Ref
		//IL_0258: Expected I4, but got I8
		//IL_01e9: Expected O, but got I8
		//IL_0a43: Expected O, but got I4
		//IL_0286: Expected O, but got I4
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected I4, but got Unknown
		//IL_0aae: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		//IL_03a5: Expected I, but got O
		//IL_0409: Expected O, but got I4
		//IL_048e: Expected I4, but got I8
		//IL_0562: Expected I, but got O
		//IL_05c6: Expected O, but got I4
		//IL_0818: Expected O, but got I4
		//IL_0858: Expected O, but got I4
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		object obj = _bodyRadius ^ -0f;
		float num2 = (float)obj * 0.5f;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		CheckRenderer();
		float num3 = _bodyRadius + _bodyRadius;
		float num4 = num3 / _spriteSize;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(((ArcadeSprite)this)._spriteRenderer, num4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		SpriteRenderer spriteRenderer2 = ((ArcadeSprite)this)._spriteRenderer;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			spriteRenderer2 = (SpriteRenderer)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v717 @ rax_v26 (should have been resolved before IL gen)");
		Weapon weapon = _weapon;
		nint num5 = (nint)weapon;
		float num6 = weapon.PSpeed();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj3 = 0;
		float spriteRotateSpeed = 60f * 60f;
		_spriteRotateSpeed = spriteRotateSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			weapon = (Weapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v805 @ rax_v31 (should have been resolved before IL gen)");
		_spriteRotateAngle = 0f;
		CheckRenderer();
		Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
		float? num7 = default(float?);
		transform.localEulerAngles = (Vector3)(&num7);
		CheckRenderer();
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(((ArcadeSprite)this)._spriteRenderer, 0.8f);
		_speed = 1f;
		_isCullable = false;
		int num8 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)transform < 0)
		{
			object obj4 = num8 - 1;
			object obj5 = obj4 | -2;
			num8 = obj5 + 1;
		}
		object obj6 = num8 - 1;
		bool mirrored = obj6 == null;
		_flip = __flip;
		_mirrored = mirrored;
		float waveIncrement = ((!__flip) ? 0.003f : (-0.003f));
		_waveIncrement = waveIncrement;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.9f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Pneuma, soundConfig, 200f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 0.9f;
		soundConfig2.Volume = (float?)(object)1;
		float detune2 = (float)_indexInWeapon * 100f;
		soundConfig2.Detune = detune2;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_GaleForce, soundConfig2, 200f, 10, time);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num9 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj7 = default(object);
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			object obj8 = default(object);
			float startWidth = (float)obj8 * 0.08f;
			_Trail.startWidth = startWidth;
			_Trail.endWidth = 0f;
			int num10 = _weapon.ActiveProjectileCount();
			bool flag2 = num10 > 50;
			int sortingOrder = -1998;
			if (!flag2)
			{
				sortingOrder = 2;
			}
			_Trail.sortingOrder = sortingOrder;
			float num11 = UpdateTrailAlpha();
			_Trail.emitting = true;
			if (_fadeInTrailTween != null)
			{
				_fadeInTrailTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Material material = ((Renderer)_Trail).GetMaterial();
			if ((object)material != null)
			{
				nint num12 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
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
			_height = 0f;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				float num13 = ((!__horizontalMirror) ? 0.65f : (-0.65f));
				float num14 = num13 * renderer.height;
				float num15 = _weapon.PDuration();
				Tween windSequence = _windSequence;
				float duration = num11 * 0.001f;
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
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((TP_Wind2_Projectile)(object)dOSetter)._003CSetFlip_003Eb__22_1(0f);
				TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, num14, duration);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				bool flag3 = TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t, false);
				bool flag4 = !flag3;
				float num16 = num14;
				object obj10 = 0;
				if (!flag4)
				{
					num16 = ((Tween)windSequence2).duration;
					Sequence sequence2 = Sequence.DoInsert(_windSequence, (Tween)t, ((Tween)windSequence2).duration);
					obj10 = 0;
				}
				Sequence windSequence3 = _windSequence;
				DOGetter<float> getter2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter2 = null;
				((TP_Wind2_Projectile)(object)dOSetter2)._003CSetFlip_003Eb__22_3(0f);
				TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter2, dOSetter2, 0f, duration);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				TweenCallback tweenCallback = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1888 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
				}
				TweenCallback tweenCallback2 = StartDespawn;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1888 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t2, false))
				{
					Sequence sequence3 = Sequence.DoInsert(_windSequence, (Tween)t2, ((Tween)windSequence3).duration);
				}
				return;
			}
			throw new NullReferenceException();
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Wind2_Projectile>)+370]");
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

	public unsafe override void InternalUpdate()
	{
		//IL_0147: Expected I, but got O
		//IL_017d: Expected O, but got I4
		//IL_0198: Expected O, but got I8
		//IL_03e4: Expected F4, but got O
		//IL_03a4: Expected O, but got I4
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_0209: Expected O, but got Ref
		//IL_01cb->IL0241: Incompatible stack heights: 3 vs 0
		//IL_01f7->IL0241: Incompatible stack heights: 3 vs 0
		//IL_0218->IL0241: Incompatible stack heights: 3 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Vector3 vector = default(Vector3);
			_startingPosition = vector;
			_ = 0;
			float num = (float)_indexInWeapon * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			float num2 = num + 1f;
			float num3 = num2 * 0.35f;
			float deltaTime = PauseSystem.DeltaTime;
			float projectileSpeed = base.ProjectileSpeed;
			float num4 = deltaTime * _waveIncrement;
			float num5 = num4 * 3000f;
			float num6 = num5 * num3;
			float num7 = num6 * 0.1f;
			float num8 = deltaTime * num7;
			float num9 = (_waveAngle = num8 + _waveAngle);
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null)
			{
				nint num10 = (nint)weapon2;
				float num11 = _weapon.PArea();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				bool flag = _isLight;
				object obj = 1;
				if (!flag)
				{
					obj = 4294967295L;
				}
				float num12 = (float)obj * 0.16f;
				float num13 = num12 * num3;
				float num14 = num13 * num9;
				float num15 = num14 * _height;
				float num16 = _waveAngle * num15;
				_startingOffset = vector;
				_ = 0;
				Transform transform = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Vector3 axis = default(Vector3);
				Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = base.transform;
				bool flag3 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rax_v45 (UnityEngine.Transform)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rax_v45 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref axis);
				float deltaTime2 = PauseSystem.DeltaTime;
				float num17 = deltaTime2 * _spriteRotateSpeed;
				float num18 = num17 + _spriteRotateAngle;
				int num19 = ~_indexInWeapon;
				int num20 = num19 & 1;
				object obj2 = num20 * 2;
				object obj3 = obj2 - 1;
				float spriteRotateAngle = (float)obj3 * num18;
				_spriteRotateAngle = spriteRotateAngle;
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					Transform transform3 = ((ArcadeSprite)this)._spriteRenderer.transform;
					if ((object)transform3 != null)
					{
						transform3.localEulerAngles = (Vector3)(&axis);
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 465 Invalid \"Jump target not found in method: 0x1871AAB70\"");
					}
				}
			}
		}
		throw new NullReferenceException();
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
		Tween heightTween = _heightTween;
		if (_heightTween != null && heightTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_heightTween);
		}
		Tween windSequence = _windSequence;
		if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_windSequence);
		}
		object trail = _Trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v1 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		_Trail.emitting = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_scaleTween = null;
		base.Despawn();
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
						Renderer.set_sortingOrder_Injected((IntPtr)0, 2);
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

	private void _003CSetFlip_003Eb__22_5()
	{
		Material material = ((Renderer)_Trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
	}

	private float _003CSetFlip_003Eb__22_0()
	{
		return _height;
	}

	private void _003CSetFlip_003Eb__22_1(float x)
	{
		_height = x;
	}

	private float _003CSetFlip_003Eb__22_2()
	{
		return _height;
	}

	private void _003CSetFlip_003Eb__22_3(float x)
	{
		_height = x;
	}

	private void _003CSetFlip_003Eb__22_4()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
