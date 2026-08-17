using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Sample1ExplosionProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public Sample1ExplosionProjectile _003C_003E4__this;

		public int index;

		internal void _003CInitProjectile_003Eb__0()
		{
			Sample1ExplosionProjectile sample1ExplosionProjectile = _003C_003E4__this;
			BaseBody body = sample1ExplosionProjectile.body;
			body._enable = true;
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			//IL_0015: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(0f, (float?)(object)0);
			Sample1ExplosionProjectile sample1ExplosionProjectile = _003C_003E4__this;
			BaseBody body = sample1ExplosionProjectile.body;
			body._enable = false;
			if (index != 0)
			{
				_003C_003E4__this.Despawn();
			}
		}
	}

	private SpriteRenderer _ringRenderer;

	private SpriteRenderer _rainbowRenderer;

	private SpriteRenderer _raysRenderer;

	private Transform _spritesContainer;

	private MultiTargetTween _ttween4;

	private MultiTargetTween _ttween3;

	private MultiTargetTween _ttween2;

	private MultiTargetTween _ttween1;

	private Weapon _trueWeapon;

	private MultiTargetTween scaleTween;

	private float SelfRadius = 64f;

	private Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Sprite sprite2 = SpriteManager.GetSprite("sPFX_ring_64", "vfx");
		if ((object)_ringRenderer != null)
		{
			_ringRenderer.sprite = sprite2;
			Sprite sprite3 = SpriteManager.GetSprite("s_pfx_rainbow_64u", "vfx");
			if ((object)_rainbowRenderer != null)
			{
				_rainbowRenderer.sprite = sprite3;
				Sprite sprite4 = SpriteManager.GetSprite("HitStar2", "vfx");
				if ((object)_raysRenderer != null)
				{
					_raysRenderer.sprite = sprite4;
					if ((object)_spritesContainer != null)
					{
						Transform transform = _spritesContainer.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 181 ConditionalJump @-1, v228 @ ZF_v12 (System.Boolean) --- -1 Nop");
							/*Error: End of method reached without returning.*/;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0052: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_01af: Expected O, but got I4
		//IL_01cd: Expected O, but got I4
		//IL_0148: Expected I, but got O
		//IL_017c: Expected I4, but got F4
		//IL_0193: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_02db: Expected O, but got I4
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.index = index;
		base.InitProjectile(pool, weapon, index);
		_trueWeapon = weapon;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		_isCullable = false;
		bool flag = CS_0024_003C_003E8__locals8.index != 0;
		float? num = (float?)(object)0;
		float num3 = default(float);
		if (!flag)
		{
			Detonate();
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample1ExplosionProjectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num2 = (nint)this;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(0.3f, onComplete, null, isLooped: false, (byte)(int)num3 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			num = (float?)(object)0;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = _indexInWeapon - 10;
		float detune = (float)obj * 100f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion2, soundConfig, 150f, 6, num3);
		if (scaleTween != null)
		{
			scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num5 = _trueWeapon.PArea();
			tweenConfig.duration = 220f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				Sample1ExplosionProjectile sample1ExplosionProjectile = CS_0024_003C_003E8__locals8._003C_003E4__this;
				BaseBody baseBody3 = sample1ExplosionProjectile.body;
				baseBody3._enable = true;
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete2 = delegate
			{
				//IL_0015: Expected O, but got I4
				ArcadeSprite arcadeSprite4 = CS_0024_003C_003E8__locals8._003C_003E4__this.setScale(0f, (float?)(object)0);
				Sample1ExplosionProjectile sample1ExplosionProjectile = CS_0024_003C_003E8__locals8._003C_003E4__this;
				BaseBody baseBody3 = sample1ExplosionProjectile.body;
				baseBody3._enable = false;
				if (CS_0024_003C_003E8__locals8.index != 0)
				{
					CS_0024_003C_003E8__locals8._003C_003E4__this.Despawn();
				}
			};
			tweenConfig.onComplete = onComplete2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			scaleTween = multiTargetTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void Detonate()
	{
		//IL_0adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae1: Expected O, but got Unknown
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7d: Expected O, but got Unknown
		//IL_0202: Expected O, but got I4
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_057b: Expected I, but got O
		//IL_05d2: Expected I, but got O
		//IL_0bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c02: Expected O, but got Unknown
		//IL_069c: Expected I, but got O
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_06f0: Expected I, but got O
		//IL_0744: Expected I, but got O
		//IL_07c7: Expected O, but got I
		//IL_04a1: Expected F4, but got I
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c60: Expected O, but got Unknown
		//IL_0c7b: Expected O, but got I4
		//IL_088c: Expected I, but got O
		//IL_08e3: Expected I, but got O
		//IL_09b5: Expected I, but got O
		//IL_0a0c: Expected I, but got O
		//IL_022e->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0bcc->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0286->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_02b0->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0525->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0551->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_031a->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_05c0->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_059e->IL059e: Incompatible stack heights: 13 vs 12
		//IL_0670->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_06bf->IL06bf: Incompatible stack heights: 13 vs 12
		//IL_0789->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0713->IL0713: Incompatible stack heights: 13 vs 12
		//IL_0767->IL0767: Incompatible stack heights: 13 vs 12
		//IL_0836->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0862->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_0c88->IL0bb2: Incompatible stack heights: 20 vs 12
		//IL_08d1->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_08af->IL08af: Incompatible stack heights: 13 vs 12
		//IL_095f->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_098b->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_09fa->IL0a71: Incompatible stack heights: 12 vs 0
		//IL_09d8->IL09d8: Incompatible stack heights: 13 vs 12
		Transform spritesContainer = _spritesContainer;
		Transform transform = base.transform;
		object obj6;
		if ((object)transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 72;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
			bool flag2 = (object)_spritesContainer == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
			_ = 0;
			bool flag3 = ((UnityEngine.Object)spritesContainer).m_CachedPtr == (IntPtr)0;
			object obj3 = obj2 - 56;
			Transform.set_position_Injected(((UnityEngine.Object)spritesContainer).m_CachedPtr, ref *(Vector3*)obj3);
			bool flag4 = (object)_ringRenderer == null;
			_ringRenderer.enabled = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringRenderer, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0.65f);
			bool flag5 = (object)spriteRenderer2 == null;
			Transform transform2 = spriteRenderer2.transform;
			bool flag6 = (object)transform2 == null;
			_ = -0f;
			Vector3 localEulerAngles = (Vector3)(obj2 - 72);
			transform2.localEulerAngles = localEulerAngles;
			bool flag7 = (object)_ringRenderer == null;
			Transform transform3 = _ringRenderer.transform;
			float2 float5 = base.position;
			float2 float6 = base.position;
			bool flag8 = (object)transform3 == null;
			_ = 0;
			bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			object obj4 = obj2 - 72;
			Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj4);
			GameManager core = GM.Core;
			bool flag10 = (object)GM.Core == null;
			bool flag11 = core._playerOptions == null;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag12 = config == null;
			object obj7 = default(object);
			if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_raysRenderer, 0.35f);
				float num = 0.35f;
				object obj5 = 0;
				obj6 = obj7;
				goto IL_0bb2;
			}
			if ((object)_rainbowRenderer != null)
			{
				_rainbowRenderer.enabled = true;
				SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(_rainbowRenderer, 0f);
				SpriteRenderer spriteRenderer5 = RenderingExtensions.SetAlpha(spriteRenderer4, 0.65f);
				if ((object)spriteRenderer5 != null)
				{
					Transform transform4 = spriteRenderer5.transform;
					if ((object)transform4 != null)
					{
						_ = -0f;
						Vector3 localEulerAngles2 = (Vector3)(obj2 - 56);
						transform4.localEulerAngles = localEulerAngles2;
						Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
						((Renderer)spriteRenderer5).SetMaterial(material);
						if ((object)_rainbowRenderer != null)
						{
							Transform transform5 = _rainbowRenderer.transform;
							float2 float7 = base.position;
							float2 float8 = base.position;
							bool flag13 = (object)transform5 == null;
							_ = 0;
							bool flag14 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
							object obj8 = obj2 - 56;
							Transform.set_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)obj8);
							bool flag15 = (object)_raysRenderer == null;
							_raysRenderer.enabled = true;
							SpriteRenderer spriteRenderer6 = RenderingExtensions.SetScale(_raysRenderer, 0f);
							SpriteRenderer spriteRenderer7 = RenderingExtensions.SetAlpha(spriteRenderer6, 0.35f);
							bool flag16 = (object)spriteRenderer7 == null;
							Transform transform6 = spriteRenderer7.transform;
							bool flag17 = (object)transform6 == null;
							_ = -0f;
							Vector3 localEulerAngles3 = (Vector3)(obj2 - 72);
							transform6.localEulerAngles = localEulerAngles3;
							Material material2 = MaterialManager.GetMaterial(MaterialType.VfxScreen);
							((Renderer)spriteRenderer7).SetMaterial(material2);
							bool flag18 = (object)_raysRenderer == null;
							Transform transform7 = _raysRenderer.transform;
							float2 float9 = base.position;
							float2 float10 = base.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+2C]");
							float num = 0f;
							bool flag19 = (object)transform7 == null;
							_ = 0;
							bool flag20 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
							object obj9 = obj2 - 72;
							Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj9);
							object obj5 = 0;
							obj6 = obj7;
							goto IL_0bb2;
						}
					}
				}
			}
		}
		goto IL_0a71;
		IL_0a71:
		throw new NullReferenceException();
		IL_0bb2:
		if ((object)_trueWeapon != null)
		{
			float num2 = _trueWeapon.PArea();
			float num3 = (float)obj6 * 4f;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_ringRenderer != null)
			{
				Transform transform8 = _ringRenderer.transform;
				if (array != null)
				{
					if ((object)transform8 != null)
					{
						nint num4 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj10 = default(object);
						bool flag21 = obj10 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
						_ = 1130102784;
						_ = 0;
						_ = 1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
						_ = 0;
						_ = 1135869952;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
						_ = 0;
						MultiTargetTween ttween = Tweens.Add(tweenConfig);
						_ttween1 = ttween;
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[3];
						if (array2 != null)
						{
							if ((object)_ringRenderer != null)
							{
								nint num5 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj11 = default(object);
								bool flag22 = obj11 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if ((object)_raysRenderer != null)
							{
								nint num6 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj12 = default(object);
								bool flag23 = obj12 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if ((object)_rainbowRenderer != null)
							{
								nint num7 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj13 = default(object);
								bool flag24 = obj13 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								tweenConfig2.targets = array2;
								_ = 0;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
								tweenConfig2.alpha = (float?)(object)0;
								tweenConfig2.delay = 60f;
								tweenConfig2.duration = 60f;
								MultiTargetTween ttween2 = Tweens.Add(tweenConfig2);
								_ttween2 = ttween2;
								TweenConfig tweenConfig3 = new TweenConfig();
								object[] array3 = new object[1];
								if ((object)_raysRenderer != null)
								{
									Transform transform9 = _raysRenderer.transform;
									if (array3 != null)
									{
										if ((object)transform9 != null)
										{
											nint num8 = (nint)array3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj14 = default(object);
											bool flag25 = obj14 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig3 != null)
										{
											((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
											_ = 0;
											_ = 1130102784;
											MultiTargetTween ttween3 = Tweens.Add(tweenConfig3);
											_ttween3 = ttween3;
											TweenConfig tweenConfig4 = new TweenConfig();
											object[] array4 = new object[1];
											if ((object)_rainbowRenderer != null)
											{
												Transform transform10 = _rainbowRenderer.transform;
												if (array4 != null)
												{
													if ((object)transform10 != null)
													{
														nint num9 = (nint)array4;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj15 = default(object);
														bool flag26 = obj15 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig4 != null)
													{
														((UnityEngine.Object)(object)tweenConfig4).m_CachedPtr = (IntPtr)array4;
														_ = 0;
														_ = 1;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
														_ = 0;
														_ = 1135869952;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
														_ = 0;
														_ = 1130102784;
														MultiTargetTween ttween4 = Tweens.Add(tweenConfig4);
														_ttween4 = ttween4;
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
			}
		}
		goto IL_0a71;
	}

	public override void Despawn()
	{
		if (_ttween1 != null)
		{
			_ttween1.Kill();
		}
		if (_ttween2 != null)
		{
			_ttween2.Kill();
		}
		if (_ttween3 != null)
		{
			_ttween3.Kill();
		}
		if (_ttween4 != null)
		{
			_ttween4.Kill();
		}
		_ringRenderer.enabled = false;
		_raysRenderer.enabled = false;
		_rainbowRenderer.enabled = false;
		_isCullable = true;
		base.Despawn();
	}
}
