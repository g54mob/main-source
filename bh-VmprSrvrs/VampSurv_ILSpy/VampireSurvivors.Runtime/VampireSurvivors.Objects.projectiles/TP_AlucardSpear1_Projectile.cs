using System;
using System.Collections.Generic;
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
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AlucardSpear1_Projectile : Projectile
{
	private MultiTargetTween _alphaTween;

	private MultiTargetTween _angleTween;

	private bool _flipToCheck;

	private float _flipSwitch;

	private Timer _attackDelay;

	private int _turnCount;

	private TP_AlucardSpear1_Weapon _trueWeapon;

	private float horizontalOffset = 0.39999998f;

	private Vector2 _attackOffset;

	private List<Projectile> _tips;

	private float _ownerOffsetX;

	private float _ownerOffsetY;

	private float offsetPx;

	private List<float> _randomSpearOffsets;

	private float2 _startingPosition;

	private Tween _positionTween;

	protected virtual string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A41A1]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_Spear01";
		}
	}

	protected virtual int AutoFlip => 0;

	protected virtual Vector2 ImageHalfSize
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		string frameName = FrameName;
		Sprite sprite = SpriteManager.GetSprite(frameName, "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0552: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		//IL_028b: Expected O, but got I
		//IL_076d: Expected O, but got F4
		//IL_079b: Expected O, but got I4
		//IL_07f2: Expected O, but got F4
		//IL_04cf: Expected O, but got I4
		//IL_071d: Expected O, but got F4
		//IL_0368: Expected O, but got I4
		//IL_0368: Expected O, but got I4
		//IL_039d: Expected O, but got I4
		//IL_05d5->IL0560: Incompatible stack heights: 1 vs 0
		//IL_01b8->IL0560: Incompatible stack heights: 1 vs 0
		//IL_01e8->IL0560: Incompatible stack heights: 1 vs 0
		//IL_0217->IL0560: Incompatible stack heights: 1 vs 0
		//IL_084a->IL0560: Incompatible stack heights: 2 vs 0
		//IL_075f->IL0560: Incompatible stack heights: 2 vs 0
		//IL_067f->IL0560: Incompatible stack heights: 2 vs 0
		//IL_080f->IL0560: Incompatible stack heights: 2 vs 0
		//IL_0304->IL0560: Incompatible stack heights: 2 vs 0
		//IL_0421->IL0560: Incompatible stack heights: 2 vs 0
		//IL_0443->IL0560: Incompatible stack heights: 2 vs 0
		//IL_04a3->IL0560: Incompatible stack heights: 2 vs 0
		//IL_04ed->IL0560: Incompatible stack heights: 2 vs 0
		//IL_03ac->IL03ac: Incompatible stack heights: 6 vs 2
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_052b;
		}
		nint num = (nint)typeof(TP_AlucardSpear1_Weapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSpear1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v3 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSpear1_Weapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v3 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v102+FFFFFFF8+v70 @ rax_v97*8]");
			if (0 == (nint)typeof(TP_AlucardSpear1_Weapon))
			{
				obj3 = 1;
				goto IL_053a;
			}
		}
		obj3 = 0;
		goto IL_053a;
		IL_053a:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_052b;
		IL_052b:
		_trueWeapon = (TP_AlucardSpear1_Weapon)trueWeapon;
		Weapon weapon3 = _weapon;
		if ((object)_weapon != null)
		{
			ArcadeSprite arcadeSprite = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
			{
				((ArcadeSprite)((Equipment)weapon3)._003COwner_003Ek__BackingField).CheckRenderer();
				if ((object)arcadeSprite._spriteRenderer != null)
				{
					Sprite sprite = arcadeSprite._spriteRenderer.sprite;
					if ((object)sprite != null)
					{
						bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						float2 ret;
						Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)(&ret));
						object obj4 = default(object);
						float ownerOffsetX = (float)obj4 * 0.0025f;
						Weapon weapon4 = _weapon;
						_ownerOffsetX = ownerOffsetX;
						if ((object)_weapon != null)
						{
							ArcadeSprite arcadeSprite2 = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
							{
								((ArcadeSprite)((Equipment)weapon4)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite2._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag3 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Rect*)(&ret));
										object obj5 = default(object);
										float ownerOffsetY = (float)obj5 * 0.005f;
										_ownerOffsetY = ownerOffsetY;
										float num3 = (float)_indexInWeapon * 0.1f;
										bool flag4 = num3 > 0.8f;
										float num4 = 0.8f;
										if (!flag4)
										{
											num4 = num3;
										}
										float alpha = 1f - num4;
										ArcadeSprite arcadeSprite3 = setAlpha(alpha);
										if ((object)weapon != null)
										{
											float num5 = weapon.PArea();
											float num6 = num4 * 14f;
											ret = (float2)0;
											int num7 = 0;
											float2 float5 = default(float2);
											object obj7 = default(object);
											while (true)
											{
												Weapon trueWeapon2 = _trueWeapon;
												if ((object)_trueWeapon == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rsi_v18 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
												if ((nint)0 == 0)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rsi_v18 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
												Projectile projectile = ((BulletPool)0).SpawnAt(float5, _trueWeapon, num7);
												bool flag5 = (object)projectile == null;
												float2 float6 = float5;
												if (!flag5)
												{
													bool flag6 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
													float6 = float5;
													if (!flag6)
													{
														Transform parent = base.transform;
														Transform transform = projectile.transform;
														if ((object)transform == null)
														{
															break;
														}
														transform.SetParent(parent, worldPositionStays: true);
														if (num7 != 0)
														{
														}
														Transform transform2 = projectile.transform;
														bool flag7 = (object)transform2 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1180 @ rax_v72 (UnityEngine.Transform)+10]");
														bool flag8 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1180 @ rax_v72 (UnityEngine.Transform)+10]");
														Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&ret));
														float6 = (float2)(num6 ^ -0f);
														bool flag9 = projectile.body == null;
														BaseBody baseBody = projectile.body.setCircle(num6, (float?)(object)1, (float?)(object)1);
														bool flag10 = _tips == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A10");
														obj4 = 0;
														ret = float5;
													}
												}
												num7++;
												if (num7 < 2)
												{
													continue;
												}
												object obj6 = UnityEngine.Random.value;
												float num8 = (float)float6 - 0.5f;
												float num9 = _ownerOffsetX * _flipSwitch;
												_startingPosition = (float2)0;
												float num10 = num8 * (float)_indexInWeapon;
												float num11 = num10 * 0.1f;
												float num12 = _ownerOffsetY + num11;
												float num13 = num9 + (float)_startingPosition;
												_startingPosition = (float2)num13;
												if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
												{
													break;
												}
												float2 float7 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
												base.position = float5;
												Weapon weapon5 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
												{
													bool flipToCheck = ((Equipment)weapon5)._003COwner_003Ek__BackingField.flipX;
													_flipToCheck = flipToCheck;
													Vector2 imageHalfSize = ImageHalfSize;
													Vector2 imageHalfSize2 = ImageHalfSize;
													float xScale = (float)obj7 - 14f;
													if (body != null)
													{
														((Weapon)(object)body).CheckArcanas();
														float num14 = weapon.PArea();
														ArcadeSprite arcadeSprite4 = setScale(xScale, (float?)(object)0);
														_turnCount = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 950 Invalid \"Jump target not found in method: 0x18707C730\"");
													}
												}
												break;
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

	private void Forward()
	{
		//IL_0205: Expected F4, but got I8
		//IL_000e: Expected F4, but got I4
		//IL_0241: Expected O, but got F4
		//IL_026f: Expected O, but got I4
		bool flag = _flipToCheck;
		float num = 4.2949673E+09f;
		if (!flag)
		{
			num = 1f;
		}
		_flipSwitch = num;
		_renderer.flipX = _flipToCheck;
		base.angle = 0f;
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		float num2 = _weapon.PArea();
		float num3 = _ownerOffsetX * _flipSwitch;
		if (_positionTween != null)
		{
			TweenExtensions.Kill(_positionTween);
		}
		DOGetter<Vector2> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DFF0");
		DOSetter<Vector2> dOSetter = null;
		((TP_AlucardSpear1_Projectile)(object)dOSetter)._003CForward_003Eb__24_1((Vector2)this);
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> positionTween = DOTween.To(getter, dOSetter, endValue, 0.3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
			_ = 18;
			_ = 0;
		}
		TweenCallback tweenCallback = CheckForFlip;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		_positionTween = positionTween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.9f;
		object obj = UnityEngine.Random.value;
		float num4 = num - 0.5f;
		float detune = num4 * 300f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, soundConfig, 200f, 3, time);
	}

	private unsafe void CheckForFlip()
	{
		//IL_0168: Expected O, but got I4
		//IL_0170: Expected O, but got Ref
		//IL_0293: Expected F4, but got I8
		//IL_02aa: Expected F4, but got I4
		//IL_0302: Expected I, but got O
		//IL_0382: Expected O, but got I4
		//IL_0664: Expected I, but got O
		//IL_067a: Expected O, but got I
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_04df: Expected I, but got O
		//IL_06ae: Expected O, but got I4
		//IL_06c5: Expected I, but got I8
		//IL_06f4: Expected O, but got F4
		//IL_072f: Expected O, but got I4
		//IL_04bb: Expected I, but got I8
		Weapon weapon = _weapon;
		Vector2 vector = default(Vector2);
		TweenCallback tweenCallback;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
			if (_flipToCheck == flag)
			{
				int autoFlip = AutoFlip;
				if (_turnCount >= autoFlip)
				{
					FadeOut();
					return;
				}
			}
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				bool flipToCheck = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
				_flipToCheck = flipToCheck;
				if (_objectsHit != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					List<Projectile> tips = _tips;
					if (_tips != null)
					{
						List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj = 0;
							Array array = (Array)(&enumerator);
							throw new NullReferenceException();
						}
						int turnCount = _turnCount + 1;
						_turnCount = turnCount;
						if ((object)this != null)
						{
							bool flag2 = _flipToCheck;
							float flipSwitch = 4.2949673E+09f;
							if (!flag2)
							{
								flipSwitch = 1f;
							}
							_flipSwitch = flipSwitch;
							if (_angleTween != null)
							{
								_angleTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array2 = new object[1];
							if (array2 != null)
							{
								nint num = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj2 = default(object);
								if (obj2 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array2;
									float num2 = _flipSwitch * 180f;
									tweenConfig.localAngle = (float?)(object)1;
									tweenConfig.duration = 200f;
									MultiTargetTween angleTween = Tweens.Add(tweenConfig);
									_angleTween = angleTween;
									DOGetter<Vector2> getter = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DFF0");
									DOSetter<Vector2> dOSetter = null;
									((TP_AlucardSpear1_Projectile)(object)dOSetter)._003CCheckForFlip_003Eb__25_1((Vector2)this);
									TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, dOSetter, vector, 0.2f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1131 @ rax_v46 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 18;
											_ = 0;
										}
										tweenCallback = null;
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ r10_v2 (Il2CppMethodInfo)+8]");
										((Delegate)tweenCallback).method_ptr = (IntPtr)0;
										((Delegate)tweenCallback).method = (nint)__ldftn(TP_AlucardSpear1_Projectile.Forward);
										((Delegate)tweenCallback).m_target = this;
										((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ r10_v2 (Il2CppMethodInfo)+4C]");
										object obj3 = (nint)0 >> 4;
										object obj4 = 1 & obj3;
										nint num4;
										if (obj4 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ r10_v2 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num4 = unchecked((nint)6447293664L);
												goto IL_06a5;
											}
										}
										num4 = ((Delegate)tweenCallback).method_ptr;
										((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
										goto IL_06a5;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_06a5:
		object obj5 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1131 @ rax_v46 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj6 = UnityEngine.Random.value;
		float num5 = (float)vector - 0.5f;
		float detune = num5 * 200f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Spinning, soundConfig, 200f, 3, time);
	}

	private void FadeOut()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
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
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_AlucardSpear1_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		float2 float6 = base.position;
		float2 float7 = default(float2);
		base.position = float7;
	}

	public override void Despawn()
	{
		if (_positionTween != null)
		{
			TweenExtensions.Kill(_positionTween);
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
		if (enumerator.MoveNext())
		{
			MultiTargetTween multiTargetTween = null;
			MultiTargetTween multiTargetTween2 = null;
			throw new NullReferenceException();
		}
		base.Despawn();
	}

	public TP_AlucardSpear1_Projectile()
	{
		List<Projectile> tips = new List<Projectile>();
		_tips = tips;
		offsetPx = 0.3f;
		base._002Ector();
	}

	private Vector2 _003CForward_003Eb__24_0()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CForward_003Eb__24_1(Vector2 x)
	{
		_attackOffset = x;
	}

	private Vector2 _003CCheckForFlip_003Eb__25_0()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CCheckForFlip_003Eb__25_1(Vector2 x)
	{
		_attackOffset = x;
	}
}
