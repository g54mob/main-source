using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_BarrelExplosionProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public PhaserSprite exp;

		internal void _003CAwake_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private SpriteRenderer _GroundFx;

	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	private Tween _timer;

	private Tween _alphaTween;

	private Tween _radiusTween;

	private VampireSurvivors.Framework.TimerSystem.Timer _despawnTimer;

	private float _radius = 32f;

	private float _exploRadius = 16f;

	private EmitZone _explosionCircle;

	private Tween _despawnTween;

	public int ExplosionsSpritesNumber = 1;

	private List<PhaserSprite> explosionSprites;

	protected unsafe override void Awake()
	{
		//IL_0171: Expected O, but got I4
		//IL_01cb: Expected O, but got I4
		//IL_027b: Expected I, but got O
		//IL_0291: Expected O, but got I
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_0308: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_057a: Expected I, but got I8
		//IL_02f1: Expected I, but got I8
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Expected O, but got Unknown
		//IL_05ef->IL053e: Incompatible stack heights: 1 vs 0
		//IL_0452->IL053e: Incompatible stack heights: 1 vs 0
		//IL_04a1->IL053e: Incompatible stack heights: 1 vs 0
		//IL_0538->IL017f: Incompatible stack heights: 1 vs 0
		//IL_053d->IL053d: Incompatible stack heights: 1 vs 0
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
				SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, null, "UnityCircle");
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0.4f);
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				if ((object)spriteRenderer2 != null)
				{
					((Renderer)spriteRenderer2).SetMaterial(material);
					SpriteRenderer groundFx = RenderingExtensions.SetTint(spriteRenderer2, 16711680u);
					_GroundFx = groundFx;
					int num = default(int);
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", num);
					List<PhaserSprite> list = new List<PhaserSprite>();
					explosionSprites = list;
					bool flag = ExplosionsSpritesNumber <= 0;
					object obj = 0;
					if (flag)
					{
						return;
					}
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					while (true)
					{
						_003C_003Ec__DisplayClass16_0 obj2 = new _003C_003Ec__DisplayClass16_0();
						PhaserWorld instance = PhaserWorld.Instance;
						if ((object)instance == null)
						{
							break;
						}
						PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "firstBlood", "Crush Bomb-Explosion-F1");
						if (obj2 == null)
						{
							break;
						}
						obj2.exp = exp;
						PhaserSprite exp2 = obj2.exp;
						if ((object)obj2.exp == null)
						{
							break;
						}
						Action action = null;
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r10_v6 (Il2CppMethodInfo)+8]");
						((Delegate)action).method_ptr = (IntPtr)0;
						((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_0._003CAwake_003Eb__0);
						((Delegate)action).m_target = obj2;
						((Delegate)action).method_code = (IntPtr)action;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r10_v6 (Il2CppMethodInfo)+4C]");
						object obj3 = (nint)0 >> 4;
						object obj4 = obj3 & 1;
						nint num3;
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r10_v6 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num3 = unchecked((nint)6447293664L);
								goto IL_055a;
							}
						}
						((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
						num3 = ((Delegate)action).method_ptr;
						goto IL_055a;
						IL_055a:
						object obj5 = 24;
						((Delegate)action).extra_arg = unchecked((nint)6447293568L);
						if ((object)exp2._spriteAnimation == null)
						{
							break;
						}
						exp2._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						if ((object)obj2.exp == null)
						{
							break;
						}
						PhaserSprite phaserSprite = obj2.exp.setVisible(visible: false);
						if ((object)obj2.exp == null)
						{
							break;
						}
						Transform transform = obj2.exp.transform;
						if ((object)transform == null)
						{
							break;
						}
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rcx_v46 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
						Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
						if ((object)obj2.exp == null)
						{
							break;
						}
						PhaserSprite phaserSprite2 = obj2.exp.setDepth(3000);
						List<object> list2 = (List<object>)(object)explosionSprites;
						if (explosionSprites == null)
						{
							break;
						}
						int version = list2._version + 1;
						list2._version = version;
						object[] items = list2._items;
						if (list2._items == null)
						{
							break;
						}
						if (list2._size >= items.Length)
						{
							((List<object>)(object)explosionSprites).AddWithResize((object)obj2.exp);
						}
						else
						{
							int num5 = list2._size + 1;
							list2._size = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						obj++;
						if ((nint)obj >= ExplosionsSpritesNumber)
						{
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
		//IL_002b: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		if (!_particlesGenerated)
		{
			GenerateParticleSystems();
		}
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		Weapon weapon2 = _weapon;
		PlayerOptionsData config = weapon2._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 128 Invalid \"Jump target not found in method: 0x187057010\"");
		throw new NullReferenceException();
	}

	private unsafe void Explode(bool flashingVFX)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00f0: Expected O, but got Ref
		//IL_0156: Expected O, but got Ref
		//IL_019c: Expected F4, but got I
		//IL_01f2: Expected O, but got I4
		//IL_01fb: Expected F4, but got I4
		//IL_0205: Expected F4, but got I4
		//IL_0ae0: Invalid comparison between F4 and I4
		//IL_023c: Invalid comparison between F4 and I4
		//IL_0287: Invalid comparison between F4 and O
		//IL_02aa: Expected O, but got I
		//IL_02bd: Invalid comparison between F4 and I4
		//IL_0394: Expected O, but got F4
		//IL_0ab1: Expected O, but got I
		//IL_06cd: Expected I, but got O
		//IL_06e3: Expected O, but got I
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Expected O, but got Unknown
		//IL_075a: Expected I, but got O
		//IL_03ea: Expected O, but got I4
		//IL_0ccb: Expected O, but got I4
		//IL_0ce2: Expected I, but got I8
		//IL_0779: Expected I, but got O
		//IL_078f: Expected O, but got I
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Expected O, but got Unknown
		//IL_080b: Expected I, but got O
		//IL_0743: Expected I, but got I8
		//IL_0d4e: Expected I, but got I8
		//IL_07de: Expected I, but got I8
		//IL_04b0: Expected O, but got I4
		//IL_09ee: Expected O, but got I
		//IL_0db5: Expected O, but got F4
		//IL_03f8->IL0ad3: Incompatible stack heights: 9 vs 2
		//IL_0c9a->IL056b: Incompatible stack heights: 12 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		TweenCallback tweenCallback;
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			EmitZone explosionCircle = _explosionCircle;
			object obj3 = default(object);
			float num2 = (float)obj3 * _exploRadius;
			Circle circle = new Circle();
			circle._radius = num2;
			circle._x = 0f;
			if (_explosionCircle != null)
			{
				explosionCircle._source = circle;
				if ((object)_weapon != null)
				{
					float num3 = _weapon.PArea();
					float min = (float)obj3 * 0.5f;
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
					float value = default(float);
					RenderingExtensions.SetScale(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&value));
					if ((object)_weapon != null)
					{
						float num4 = _weapon.PArea();
						float min2 = 0f * 0.5f;
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(min2, 0f);
						RenderingExtensions.SetScale(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&value));
						RenderingExtensions.SetEmitZone(_pfxEmitter, _explosionCircle);
						RenderingExtensions.SetEmitZone(_pfxEmitter2, _explosionCircle);
						PhaserSprite groundFx = (PhaserSprite)(object)_GroundFx;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
						float num5 = 0f;
						bool flag = ((UnityEngine.Object)groundFx).m_CachedPtr == (IntPtr)0;
						SpriteRenderer.set_color_Injected(((UnityEngine.Object)groundFx).m_CachedPtr, ref *(Color*)(&value));
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.8f);
						_GroundFx.enabled = false;
						List<PhaserSprite> list = explosionSprites;
						bool flag2 = explosionSprites == null;
						float num6 = 0.8f;
						object obj4 = 0;
						float num7 = 0f;
						float num14 = default(float);
						for (float num8 = 0f; num8 < (float)list._size; num8 = num7)
						{
							List<PhaserSprite> list2 = explosionSprites;
							bool flag3 = explosionSprites == null;
							bool flag4 = !(num7 < (float)list2._size);
							PhaserSprite items = (PhaserSprite)(object)list2._items;
							bool flag5 = list2._items == null;
							float num9 = num7;
							CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)items).m_CancellationTokenSource;
							bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9) >= System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rsi_v27 (VampireSurvivors.Framework.Phaser.PhaserSprite)+20+v427 @ rdi_v23 (System.Single)*8]");
							PhaserSprite phaserSprite = (PhaserSprite)0;
							float2 float5 = base.position;
							bool num10;
							if (!(num7 > 0f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rsi_v27 (VampireSurvivors.Framework.Phaser.PhaserSprite)+20+v427 @ rdi_v23 (System.Single)*8]");
								bool flag7 = (nint)0 == 0;
								num10 = flag7;
								float2 float6 = float5;
							}
							else
							{
								float value2 = UnityEngine.Random.value;
								float2 float7 = base.position;
								float value3 = UnityEngine.Random.value;
								float num11 = num2 * 0.01f;
								float num12 = value3 * num11;
								float num13 = num12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+4C]");
								num5 = num13 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rsi_v27 (VampireSurvivors.Framework.Phaser.PhaserSprite)+20+v427 @ rdi_v23 (System.Single)*8]");
								bool flag8 = (nint)0 == 0;
								num10 = flag8;
								num6 = num14;
								float2 float6 = (float2)num14;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rsi_v27 (VampireSurvivors.Framework.Phaser.PhaserSprite)+20+v427 @ rdi_v23 (System.Single)*8]");
							PhaserSprite phaserSprite2 = ((PhaserSprite)0).setVisible(visible: true);
							bool flag9 = (object)phaserSprite._spriteAnimation == null;
							phaserSprite._spriteAnimation.SetAnimation("bang");
							list = explosionSprites;
							num7++;
							bool flag10 = explosionSprites == null;
							obj4 = 0;
						}
						RenderingExtensions.Start(_pfxEmitter);
						RenderingExtensions.Start(_pfxEmitter2);
						if (flashingVFX)
						{
							object groundFx2 = _GroundFx;
							bool flag11 = (object)_GroundFx == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rdi_v31 (System.Object)+10]");
							bool flag12 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rdi_v31 (System.Object)+10]");
							Renderer.set_enabled_Injected((IntPtr)0, true);
							object groundFx3 = _GroundFx;
							bool flag13 = (object)_GroundFx == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rdi_v32 (System.Object)+10]");
							bool flag14 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rdi_v32 (System.Object)+10]");
							IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							bool flag15 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2239 @ rax_v172 (UnityEngine.Transform)+10]");
							bool flag16 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2239 @ rax_v172 (UnityEngine.Transform)+10]");
							Vector3 value4 = default(Vector3);
							Transform.set_localScale_Injected((IntPtr)0, ref value4);
							Tween despawnTween = _despawnTween;
							if (_despawnTween != null && despawnTween._003Cactive_003Ek__BackingField)
							{
								TweenExtensions.Kill(_despawnTween);
								obj4 = 0;
							}
							object groundFx4 = _GroundFx;
							bool flag17 = (object)_GroundFx == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ rdi_v34 (System.Object)+10]");
							bool flag18 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ rdi_v34 (System.Object)+10]");
							IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
							Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
							bool flag19 = (object)_weapon == null;
							float num15 = _weapon.PArea();
							float num16 = _radius + _radius;
							float endValue = (float)Vector3.oneVector * num16;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, endValue, 0.120000005f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							bool flag20 = tweenerCore == null;
							_despawnTween = tweenerCore;
						}
						Tween alphaTween = _alphaTween;
						if (_alphaTween != null && alphaTween._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(_alphaTween);
						}
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_GroundFx, 0f, 0.120000005f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag21 = tweenerCore2 == null;
						_alphaTween = tweenerCore2;
						Tween timer = _timer;
						if (_timer != null && timer._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(_timer);
						}
						tweenCallback = null;
						nint num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2252 @ r10_v16 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(FB_BarrelExplosionProjectile.TriggerDespawnTimer);
						((Delegate)tweenCallback).m_target = this;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2252 @ r10_v16 (Il2CppMethodInfo)+4C]");
						object obj5 = (nint)0 >> 4;
						object obj6 = obj5 & 1;
						nint num18;
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2252 @ r10_v16 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num18 = unchecked((nint)6447293664L);
								goto IL_0cc2;
							}
						}
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						num18 = ((Delegate)tweenCallback).method_ptr;
						goto IL_0cc2;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0cc2:
		PhaserSprite phaserSprite3 = (PhaserSprite)24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Tween tween = DOVirtual.DelayedCall(0.120000005f, tweenCallback, ignoreTimeScale: false);
		TweenCallback tweenCallback2 = null;
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r10_v17 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = (nint)__ldftn(FB_BarrelExplosionProjectile._003CExplode_003Eb__18_0);
		((Delegate)tweenCallback2).m_target = this;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r10_v17 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num20;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r10_v17 (Il2CppMethodInfo)+52]");
			bool flag22 = (nint)0 == 0;
			num20 = unchecked((nint)6447293664L);
			if (flag22)
			{
				goto IL_0d37;
			}
		}
		num20 = ((Delegate)tweenCallback2).method_ptr;
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		goto IL_0d37;
		IL_0d37:
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		if (tween != null && tween._003Cactive_003Ek__BackingField)
		{
			((ABSSequentiable)tween).onStart = tweenCallback2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag23 = tween == null;
		tween.stringId = "DefaultGameTweenId";
		_timer = tween;
		bool flag24 = (object)_weapon == null;
		float num21 = _weapon.PArea();
		Tween radiusTween = _radiusTween;
		float endValue2 = 0.120000005f * _radius;
		if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((FB_BarrelExplosionProjectile)(object)dOSetter)._003CExplode_003Eb__18_2(0f);
		TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter, dOSetter, endValue2, 0.120000005f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag25 = tweenerCore3 == null;
		_radiusTween = tweenerCore3;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1056964608;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
		soundConfig.Volume = (float?)(object)0;
		soundConfig.Rate = 1f;
		object obj9 = UnityEngine.Random.value;
		float num22 = 0.120000005f - 0.5f;
		float detune = num22 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 150f, 3, time);
	}

	private void TriggerDespawnTimer()
	{
		//IL_01f3: Expected I, but got O
		//IL_02c4->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0161->IL023a: Incompatible stack heights: 2 vs 0
		//IL_01bf->IL023a: Incompatible stack heights: 2 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = false;
			ParticleSystem pfxEmitter = _pfxEmitter;
			if ((object)_pfxEmitter != null)
			{
				bool flag = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
				ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
				ParticleSystem pfxEmitter2 = _pfxEmitter2;
				if ((object)_pfxEmitter2 != null)
				{
					bool flag2 = ((UnityEngine.Object)pfxEmitter2).m_CachedPtr == (IntPtr)0;
					ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
					Tween alphaTween = _alphaTween;
					if (_alphaTween != null && alphaTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_alphaTween);
					}
					Tween radiusTween = _radiusTween;
					if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_radiusTween);
					}
					Tween timer = _timer;
					if (_timer != null && timer._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_timer);
					}
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = false;
						if (_despawnTimer != null)
						{
							_despawnTimer.Cancel();
						}
						if ((object)_particlesManager != null)
						{
							float remainingLifetime = _particlesManager.GetRemainingLifetime();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_BarrelExplosionProjectile>)+370]");
							Action onComplete = new Action(this, (IntPtr)0);
							nint num = (nint)this;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							VampireSurvivors.Framework.TimerSystem.Timer despawnTimer = Timers.Register(remainingLifetime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_despawnTimer = despawnTimer;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0277: Expected O, but got I4
		//IL_0290: Expected O, but got Ref
		//IL_02aa: Expected native int or pointer, but got O
		//IL_02c4: Expected O, but got I
		//IL_02e4: Expected O, but got Ref
		//IL_02fe: Expected native int or pointer, but got O
		//IL_0318: Expected O, but got I
		//IL_0338: Expected O, but got Ref
		//IL_0352: Expected native int or pointer, but got O
		//IL_0934: Expected O, but got I4
		//IL_0390: Expected O, but got I
		//IL_03ca: Expected O, but got Ref
		//IL_03e3: Expected native int or pointer, but got O
		//IL_096e: Expected O, but got I
		//IL_041b: Expected O, but got Ref
		//IL_0442: Expected O, but got I
		//IL_045c: Expected native int or pointer, but got O
		//IL_09a8: Expected O, but got I
		//IL_0649: Expected O, but got I4
		//IL_0662: Expected O, but got Ref
		//IL_067c: Expected native int or pointer, but got O
		//IL_0696: Expected O, but got I
		//IL_06b6: Expected O, but got Ref
		//IL_06d0: Expected native int or pointer, but got O
		//IL_06ea: Expected O, but got I
		//IL_070a: Expected O, but got Ref
		//IL_0724: Expected native int or pointer, but got O
		//IL_074c: Expected O, but got I
		//IL_0a2f: Expected O, but got I
		//IL_0778: Expected O, but got I
		//IL_07b2: Expected O, but got Ref
		//IL_07cb: Expected native int or pointer, but got O
		//IL_0a69: Expected O, but got I
		//IL_0b7d: Expected O, but got I
		//IL_0b9e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		float num = _weapon.PArea();
		Circle circle = new Circle();
		object obj3 = default(object);
		float radius = (float)obj3 * _exploRadius;
		circle._x = 0f;
		circle._radius = radius;
		emitZone._source = circle;
		emitZone._type = EmitZoneType.Random;
		emitZone._yoyo = false;
		_explosionCircle = emitZone;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Smoke1");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Smoke2");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		float num4 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		float min = 0f * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		particleSystemConfig._emitZone = _explosionCircle;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		Transform transform = _pfxEmitter2.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"HitSmoke1");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"HitSmoke2");
		}
		else
		{
			int num6 = list2._size + 1;
			list2._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		float num7 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		float min2 = 0f * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(min2, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._emitZone = _explosionCircle;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		Transform transform2 = _pfxEmitter.transform;
		bool flag2 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2953 @ rax_v106 (UnityEngine.Transform)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2953 @ rax_v106 (UnityEngine.Transform)+10]");
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		bool flag4 = gravityWellConfig == null;
		_ = 1065353216;
		_ = 1112014848;
		_ = 1101004800;
		bool flag5 = (object)_particlesManager == null;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
		_well = well;
		bool flag6 = (object)_well == null;
		Transform transform3 = _well.transform;
		bool flag7 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v118 (UnityEngine.Transform)+10]");
		bool flag8 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v118 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
		_particlesGenerated = true;
	}

	public FB_BarrelExplosionProjectile()
	{
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		base._002Ector();
	}

	private void _003CExplode_003Eb__18_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private float _003CExplode_003Eb__18_1()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CExplode_003Eb__18_2(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
