using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Valmanway_Projectile : Projectile
{
	private Vector2 _collisionPos;

	private Vector2 _spritePos;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private uint[] _colors;

	private readonly BlendMode[] _blendModes;

	private readonly float[] _angles;

	private SoundManager.SoundConfig _soundConfig;

	private float _life;

	private Transform _cachedSpriteTransform;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private PhaserSprite _lanceSprite;

	private MultiTargetTween _tween2b;

	private List<int> _modifiers;

	private Tween lifeTween;

	public override float ProjectileSpeed
	{
		get
		{
			float num = _weapon.PSpeed();
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			CharacterData currentCharacterData = characterController._currentCharacterData;
			float num2 = GameManager.PlayerPxSpeed * currentCharacterData._003CmoveSpeed_003Ek__BackingField;
			object obj = default(object);
			float num3 = num2 * (float)obj;
			return num3 * _speed;
		}
	}

	protected override void Awake()
	{
		//IL_01a5: Expected O, but got I4
		//IL_0220->IL01aa: Incompatible stack heights: 1 vs 0
		//IL_018b->IL01aa: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Vorpal02");
				if ((object)phaserSprite != null)
				{
					GameObject gameObject2 = phaserSprite.gameObject;
					if ((object)gameObject2 != null)
					{
						((UnityEngine.Object)gameObject2).SetName("TPValmanwayProjectile_LanceSprite");
						_lanceSprite = phaserSprite;
						if ((object)_lanceSprite != null)
						{
							Transform transform = _lanceSprite.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								if ((object)_lanceSprite != null)
								{
									PhaserSprite phaserSprite2 = _lanceSprite.setVisible(visible: false);
									if ((object)_lanceSprite != null)
									{
										PhaserSprite phaserSprite3 = _lanceSprite.setOrigin(1f, (float?)(object)1);
										return;
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
		//IL_0168: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_0181: Expected O, but got F4
		//IL_01bd: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		_isCullable = false;
		PhaserSprite phaserSprite = _lanceSprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _lanceSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _lanceSprite.setAlpha(1f);
		Transform cachedSpriteTransform = _lanceSprite.transform;
		_cachedSpriteTransform = cachedSpriteTransform;
		_collisionPos = (Vector2)0;
		_spritePos = (Vector2)0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		_soundConfig = soundConfig;
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig2.Rate = 1f;
		float detune = num * 200f;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig2, 200f, 3, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 313 Invalid \"Jump target not found in method: 0x18719C890\"");
		throw new NullReferenceException();
	}

	private unsafe void OnRecycle()
	{
		//IL_018a: Expected O, but got I
		//IL_01e6: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_0279: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		//IL_024b: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		//IL_09e9: Expected O, but got I4
		//IL_0262: Expected O, but got I4
		//IL_040a: Expected O, but got I4
		//IL_0425: Expected I, but got O
		//IL_0542: Expected I, but got O
		//IL_05b0: Expected O, but got I4
		//IL_05be: Expected O, but got I4
		//IL_05e8: Expected O, but got I4
		//IL_072e: Expected F4, but got I
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected O, but got Unknown
		//IL_0806: Expected O, but got Ref
		//IL_084e: Expected O, but got F4
		//IL_08b4: Expected O, but got F4
		//IL_01aa->IL0959: Incompatible stack heights: 1 vs 0
		//IL_0376->IL0959: Incompatible stack heights: 1 vs 0
		//IL_03d7->IL0959: Incompatible stack heights: 1 vs 0
		//IL_04ec->IL0959: Incompatible stack heights: 1 vs 0
		//IL_0518->IL0959: Incompatible stack heights: 1 vs 0
		//IL_058b->IL0959: Incompatible stack heights: 1 vs 0
		//IL_0a72->IL0959: Incompatible stack heights: 1 vs 0
		//IL_06ea->IL0959: Incompatible stack heights: 1 vs 0
		//IL_0719->IL0959: Incompatible stack heights: 1 vs 0
		//IL_07c8->IL0959: Incompatible stack heights: 1 vs 0
		//IL_07f4->IL0959: Incompatible stack heights: 1 vs 0
		//IL_0906->IL0959: Incompatible stack heights: 1 vs 0
		//IL_0928->IL0959: Incompatible stack heights: 1 vs 0
		float num = (float)_indexInWeapon * 0.02f;
		bool flag = num > 0.1f;
		float num2 = 0.1f;
		if (!flag)
		{
			num2 = num;
		}
		float num4;
		object obj2;
		object obj4;
		bool flag5;
		if ((object)_lanceSprite != null)
		{
			float alpha = 0.65f - num2;
			PhaserSprite phaserSprite = _lanceSprite.setAlpha(alpha);
			VampireSurvivors.App.Tools.Extensions.Shuffle(_colors);
			if ((object)_lanceSprite != null)
			{
				PhaserSprite phaserSprite2 = _lanceSprite.setTint(16777215u);
				if ((object)_lanceSprite != null)
				{
					PhaserSprite phaserSprite3 = _lanceSprite.setBlendMode(BlendMode.Normal);
					if ((object)_weapon != null)
					{
						float num3 = _weapon.PArea();
						num4 = num * 40f;
						if ((object)_weapon != null)
						{
							float num5 = _weapon.PArea();
							List<int> modifiers = _modifiers;
							if (_modifiers != null)
							{
								int indexInWeapon = _indexInWeapon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32>)+18]");
								int num6 = (int)((nint)indexInWeapon % (nint)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32>)+18]");
								bool flag2 = (nint)num6 >= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v23+18]");
									if ((nint)num6 < (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v23+20+v181 @ rdx_v21 (System.Int32)*4]");
										obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v23+20+v181 @ rdx_v21 (System.Int32)*4]");
										object obj3 = -1;
										bool flag3 = obj3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v23+20+v181 @ rdx_v21 (System.Int32)*4]");
										if ((nint)0 != 2)
										{
											bool flag4 = (nint)obj2 != 4;
											obj4 = 0;
											if (!flag4)
											{
												obj4 = 0;
												flag5 = true;
												goto IL_0287;
											}
										}
										else
										{
											obj4 = 1;
											obj2 = 2;
										}
										bool flag6 = (nint)obj2 == 6;
										flag5 = flag3;
										if (flag6)
										{
											obj4 = 1;
											flag5 = flag3;
											goto IL_09ce;
										}
										goto IL_0287;
									}
									throw new IndexOutOfRangeException();
								}
							}
						}
					}
				}
			}
		}
		goto IL_0959;
		IL_0959:
		throw new NullReferenceException();
		IL_09ce:
		_life = 0f;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		bool flag7 = !flag5;
		float num7 = num;
		if (!flag7)
		{
			num7 = num ^ -0f;
		}
		bool flag8 = obj4 != null;
		float num8 = 0.35f;
		if (!flag8)
		{
			num8 = 1f;
		}
		float num9 = num7 * 1.65f;
		float num10 = 1.65f * num;
		float yScale = num9 * num8;
		PhaserSprite phaserSprite4 = RenderingExtensions.SetScale(_lanceSprite, num10, yScale);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			PhaserSprite phaserSprite5 = RenderingExtensions.SetScale((PhaserSprite)(object)this, num10, yScale);
			if ((object)phaserSprite5 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			PhaserSprite phaserSprite6 = RenderingExtensions.SetScale((PhaserSprite)(object)array, num10, yScale);
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				tweenConfig.duration = 200f;
				tweenConfig.scale = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1232 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Valmanway_Projectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num11 = (nint)this;
				tweenConfig.onComplete = onComplete;
				TweenCallback onStart = delegate
				{
					//IL_0010: Expected O, but got I4
					ArcadeSprite arcadeSprite2 = setScale(40f, (float?)(object)0);
				};
				tweenConfig.onStart = onStart;
				MultiTargetTween tween = Tweens.Add(tweenConfig);
				_tween1 = tween;
				if (_tween2 != null)
				{
					_tween2.Kill();
				}
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)_lanceSprite != null)
				{
					Transform transform = _lanceSprite.transform;
					if (array2 != null)
					{
						if ((object)transform != null)
						{
							nint num12 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							if (obj5 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							tweenConfig2.targets = array2;
							tweenConfig2.scaleX = (float?)(object)1;
							tweenConfig2.scaleY = (float?)(object)1;
							tweenConfig2.duration = 100f;
							tweenConfig2.ease = Ease.Linear;
							tweenConfig2.alpha = (float?)(object)1;
							MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
							_tween2 = tween2;
							if (lifeTween != null)
							{
								TweenExtensions.Kill(lifeTween);
							}
							DOGetter<float> getter = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
							DOSetter<float> dOSetter = null;
							((TP_Valmanway_Projectile)(object)dOSetter)._003COnRecycle_003Eb__21_1(num10);
							TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 0.2f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore != null)
							{
								lifeTween = tweenerCore;
								Weapon weapon = _weapon;
								if ((object)_weapon != null)
								{
									TP_Valmanway_Projectile tP_Valmanway_Projectile = (TP_Valmanway_Projectile)(object)((Equipment)weapon)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v68 (VampireSurvivors.Objects.Projectiles.TP_Valmanway_Projectile)+180]");
										float x = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v68 (VampireSurvivors.Objects.Projectiles.TP_Valmanway_Projectile)+184]");
										object obj6 = 0 ^ -0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018719D1F1h\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v68 (VampireSurvivors.Objects.Projectiles.TP_Valmanway_Projectile)+180]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018719D1F1h\"");
											if (obj6 == null)
											{
												x = 1f;
											}
										}
										((TP_Valmanway_Projectile)(object)((Equipment)weapon)._003COwner_003Ek__BackingField)._003COnRecycle_003Eb__21_1(x);
										if ((object)_lanceSprite != null)
										{
											Transform transform2 = _lanceSprite.transform;
											if ((object)transform2 != null)
											{
												Vector3 value = default(Vector3);
												transform2.localEulerAngles = (Vector3)(&value);
												float num13 = num4 * 0.01f;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
												float num14 = num13 * 2.5f;
												float num15 = (float)obj6 * num14;
												_collisionPos = (Vector2)num15;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												float num16 = num13 * -2.5f;
												float num17 = (float)obj6 * num16;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
												float num18 = num13 * 2.5f;
												float num19 = (float)obj6 * num18;
												_spritePos = (Vector2)num19;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												float num20 = num13 * -2.5f;
												float num21 = (float)obj6 * num20;
												Weapon weapon2 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
												{
													float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
													float? cachedSpriteTransform = (float?)_cachedSpriteTransform;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ rbx_v12 (System.Nullable`1<System.Single>)+10]");
													bool flag9 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ rbx_v12 (System.Nullable`1<System.Single>)+10]");
													Transform.set_position_Injected((IntPtr)0, ref value);
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
		goto IL_0959;
		IL_0287:
		if ((nint)obj2 == 7)
		{
			flag5 = true;
		}
		goto IL_09ce;
	}

	public unsafe override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		Transform cachedSpriteTransform = _cachedSpriteTransform;
		bool flag = ((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr, ref *(Vector3*)(&value));
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _lanceSprite.setVisible(visible: false);
		if (_tween2b != null)
		{
			_tween2b.Kill();
		}
		if (lifeTween != null)
		{
			TweenExtensions.Kill(lifeTween);
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		base.Despawn();
	}

	public TP_Valmanway_Projectile()
	{
		//IL_0097: Expected O, but got I
		//IL_00f1: Expected O, but got I
		//IL_0446: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_046e: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_0496: Expected O, but got I
		//IL_022f: Expected O, but got I
		//IL_04be: Expected O, but got I
		//IL_0299: Expected O, but got I
		//IL_04e6: Expected O, but got I
		//IL_0303: Expected O, but got I
		//IL_050e: Expected O, but got I
		//IL_036d: Expected O, but got I
		//IL_0536: Expected O, but got I
		//IL_03d7: Expected O, but got I
		_colors = new uint[5] { 13434879u, 143654911u, 4508927u, 4474111u, 8947967u };
		_blendModes = new BlendMode[4]
		{
			BlendMode.Normal,
			BlendMode.Screen,
			BlendMode.Screen,
			BlendMode.Screen
		};
		_angles = new float[6] { 0f, 180f, 60f, 240f, 120f, 300f };
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v13+18]");
		if (num >= 0)
		{
			list.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdx_v15+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v17+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v19+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r8_v16+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r8_v18+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ r8_v20+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rdx_v24+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 7;
		}
		_modifiers = list;
		base._002Ector();
	}

	private void _003COnRecycle_003Eb__21_2()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(40f, (float?)(object)0);
	}

	private float _003COnRecycle_003Eb__21_0()
	{
		return _life;
	}

	private void _003COnRecycle_003Eb__21_1(float x)
	{
		_life = x;
	}
}
