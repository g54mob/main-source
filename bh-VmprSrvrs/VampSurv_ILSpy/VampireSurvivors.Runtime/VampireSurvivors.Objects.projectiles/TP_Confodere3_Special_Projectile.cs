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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Confodere3_Special_Projectile : Projectile
{
	private Timer expireTimer;

	private bool _isDespawning;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	private SpriteMask _posterMask;

	private Tween posterTween;

	private Material material;

	private static readonly int _matColor;

	private static readonly int _matAlpha;

	private List<Vector3> colors;

	private TP_Confodere1_Weapon trueWeapon;

	private Tween angleTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("CirclePoster01", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, (string)null);
				if ((object)gameObject != null)
				{
					SpriteMask posterMask = gameObject.AddComponent<SpriteMask>();
					_posterMask = posterMask;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
					if ((object)_posterMask != null)
					{
						Sprite sprite2 = default(Sprite);
						_posterMask.sprite = sprite2;
						Transform transform = gameObject.transform;
						Transform parent = base.transform;
						if ((object)transform != null)
						{
							transform.SetParent(parent, worldPositionStays: true);
							if ((object)_posterMask != null)
							{
								Transform transform2 = _posterMask.transform;
								bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
								Transform transform3 = _posterMask.transform;
								bool flag2 = (object)transform3 == null;
								bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
								SpriteRenderer renderer = _renderer;
								bool flag4 = (object)_renderer == null;
								bool flag5 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
								SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)renderer).m_CachedPtr, SpriteMaskInteraction.VisibleOutsideMask);
								bool flag6 = (object)_renderer == null;
								Material material = ((Renderer)_renderer).GetMaterial();
								this.material = material;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0996: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_096f: Expected O, but got I8
		//IL_00ab: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_09d5: Expected I, but got O
		//IL_0a3d: Expected I, but got O
		//IL_0376: Expected O, but got I
		//IL_03f1: Expected O, but got Ref
		//IL_05d6: Invalid comparison between F4 and I4
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Expected O, but got Unknown
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Expected O, but got Unknown
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Expected O, but got Unknown
		//IL_0b82: Expected O, but got I4
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b97: Expected O, but got Unknown
		//IL_06f9: Expected O, but got Ref
		//IL_071a: Expected O, but got I4
		//IL_0748: Expected O, but got I4
		//IL_076b: Expected O, but got I4
		//IL_07dc: Expected O, but got I4
		//IL_0874: Expected F4, but got O
		//IL_08a8: Expected O, but got I
		//IL_09ef->IL0929: Incompatible stack heights: 1 vs 0
		//IL_0396->IL0929: Incompatible stack heights: 10 vs 0
		//IL_03d8->IL0929: Incompatible stack heights: 11 vs 0
		//IL_040b->IL0929: Incompatible stack heights: 11 vs 0
		//IL_0473->IL0929: Incompatible stack heights: 11 vs 0
		//IL_0aeb->IL0929: Incompatible stack heights: 11 vs 0
		//IL_06d0->IL0929: Incompatible stack heights: 11 vs 0
		//IL_0b27->IL0929: Incompatible stack heights: 11 vs 0
		//IL_0833->IL0929: Incompatible stack heights: 11 vs 0
		//IL_0862->IL0929: Incompatible stack heights: 11 vs 0
		base.InitProjectile(pool, weapon, index);
		float? num;
		if ((object)weapon == null)
		{
			num = (float?)(object)0;
			goto IL_0962;
		}
		nint num2 = (nint)typeof(TP_Confodere1_Weapon);
		nint num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v76 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v76 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Confodere1_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v159+FFFFFFF8+v71 @ rax_v154*8]");
			if (0 == (nint)typeof(TP_Confodere1_Weapon))
			{
				obj3 = 1;
				goto IL_097e;
			}
		}
		obj3 = 0;
		goto IL_097e;
		IL_05c8:
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		TweenCallback gameSessionData;
		if (((Weapon)(object)tweenerCore)._lastFiringInterval != 0f)
		{
			((Weapon)(object)tweenerCore)._gameSessionData = (GameSessionData)(object)gameSessionData;
		}
		goto IL_05fc;
		IL_05fc:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag;
		float2 value = default(float2);
		if (tweenerCore != null)
		{
			((Equipment)(object)tweenerCore)._signalBus = (SignalBus)(object)"DefaultGameTweenId";
			posterTween = tweenerCore;
			if (flag)
			{
				base.angle = 0f;
			}
			else
			{
				base.angle = 180f;
			}
			if (angleTween != null)
			{
				TweenExtensions.Kill(angleTween);
			}
			Transform target = base.transform;
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			if ((object)cachedTrans != null)
			{
				Vector3 localEulerAngles = cachedTrans.localEulerAngles;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target, (Vector3)(&value), 0.3f);
				bool flag2 = tweenerCore2 == null;
				object obj4 = 0;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2002 @ rax_v79 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					bool flag3 = (nint)0 == 0;
					obj4 = 0;
					if (!flag3)
					{
						_ = 1;
						_ = 0;
						obj4 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore2 != null)
				{
					((Equipment)(object)tweenerCore2)._signalBus = (SignalBus)(object)"DefaultGameTweenId";
					angleTween = tweenerCore2;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MoonFinisher, new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Rate = 4f
					}, 200f, 5, time);
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							float num5 = (float)characterController._lastMovementDirection;
							Weapon weapon3 = _weapon;
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2256 @ rcx_v72 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							object obj5 = num6 ^ 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870BE502h\"");
							if ((object)characterController._lastMovementDirection == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870BE502h\"");
								if (obj5 == null)
								{
									num5 = 1f;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							float2 float5 = base.position;
							float2 float6 = default(float2);
							base.position = float6;
							return;
						}
					}
				}
			}
		}
		goto IL_0929;
		IL_0962:
		object obj6 = 6603577472L;
		trueWeapon = (TP_Confodere1_Weapon)num;
		TP_Confodere1_Weapon tP_Confodere1_Weapon = trueWeapon;
		if ((object)trueWeapon != null)
		{
			float num7 = trueWeapon.PArea();
			object obj7 = default(object);
			float num8 = (float)obj7 * tP_Confodere1_Weapon._defaultRange;
			float num9 = num8 * 1.5f;
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(64f, (float?)(object)0, (float?)(object)0);
				ArcadeSprite arcadeSprite = setScale(num9, (float?)(object)0);
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null)
					{
						if (config._003CFlashingVFXEnabled_003Ek__BackingField)
						{
							if ((object)_renderer == null)
							{
								goto IL_0929;
							}
							_renderer.enabled = true;
						}
						BulletPool renderer = (BulletPool)(object)_renderer;
						if ((object)_renderer != null)
						{
							bool flag4 = ((EventEmitter)renderer).callbacks == null;
							Renderer.set_sortingOrder_Injected((IntPtr)((EventEmitter)renderer).callbacks, 4000);
							if ((object)_posterMask != null)
							{
								Transform transform = _posterMask.transform;
								bool flag5 = (object)transform == null;
								bool flag6 = ((EventEmitter)(object)transform).callbacks == null;
								Vector3 value2 = default(Vector3);
								Transform.set_localScale_Injected((IntPtr)((EventEmitter)(object)transform).callbacks, ref value2);
								bool flag7 = (object)weapon == null;
								bool flag8 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
								flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
								bool flag9 = (object)_posterMask == null;
								Transform transform2 = _posterMask.transform;
								if (flag)
								{
								}
								bool flag10 = (object)transform2 == null;
								bool flag11 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
								List<Vector3> list = colors;
								bool flag12 = colors == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ r8_v18 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								int num10 = (int)((nint)index % (nint)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ r8_v18 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								bool flag13 = (nint)num10 >= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ r8_v18 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ r8_v18 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ r8_v19+18]");
									bool flag14 = (nint)num10 >= (nint)0;
									if ((object)material != null)
									{
										object obj9 = default(object);
										material.SetVector(_matColor, (Vector4)(&obj9));
										if ((object)material != null)
										{
											material.SetFloatImpl(_matAlpha, 0.8f);
											if (posterTween != null)
											{
												TweenExtensions.Kill(posterTween);
											}
											if ((object)_posterMask != null)
											{
												Transform target2 = _posterMask.transform;
												tweenerCore = ShortcutExtensions.DOScale(target2, num9, 0.5f);
												if (tweenerCore != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1618 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
													if ((nint)0 != 0)
													{
														_ = 6;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
														bool flag15 = (nint)0 == 0;
														_ = 0;
														if (!flag15)
														{
															object obj10 = tweenerCore + 184;
															object obj11 = obj10 >> 12;
															object obj12 = obj11 & 0x1FFFFF;
															object obj13 = obj12 >> 6;
															object obj14 = obj12 & 0x3F;
															nint num12;
															do
															{
																object obj15 = 1 << (int)obj14;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r12_v1+462E0+v1670 @ rdx_v69*8]");
																object obj16 = 0 | obj15;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r12_v1+462E0+v1670 @ rdx_v69*8]");
																nint num11 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r12_v1+462E0+v1670 @ rdx_v69*8]");
																if (num11 == 0)
																{
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r12_v1+462E0+v1670 @ rdx_v69*8]");
																num12 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r12_v1+462E0+v1670 @ rdx_v69*8]");
															}
															while (num12 != 0);
															TweenCallback tweenCallback = delegate
															{
																Despawn();
															};
															gameSessionData = tweenCallback;
															goto IL_05c8;
														}
													}
												}
												TweenCallback tweenCallback2 = delegate
												{
													Despawn();
												};
												bool flag16 = tweenerCore == null;
												gameSessionData = tweenCallback2;
												if (!flag16)
												{
													goto IL_05c8;
												}
												goto IL_05fc;
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
		goto IL_0929;
		IL_0929:
		throw new NullReferenceException();
		IL_097e:
		bool flag17 = obj3 == null;
		num = (float?)(object)0;
		if (!flag17)
		{
			num = (float?)weapon;
		}
		goto IL_0962;
	}

	public void StartDespawn()
	{
		//IL_005a: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (expireTimer != null)
			{
				expireTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Confodere3_Special_Projectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			expireTimer = timer;
		}
	}

	public override void Despawn()
	{
		if (angleTween != null)
		{
			TweenExtensions.Kill(angleTween);
		}
		if (posterTween != null)
		{
			TweenExtensions.Kill(posterTween);
		}
		_renderer.enabled = false;
		if (expireTimer != null)
		{
			expireTimer.Cancel();
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

	public unsafe TP_Confodere3_Special_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0089: Expected O, but got I
		//IL_00a9: Expected O, but got I
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0066: Expected O, but got Ref
		//IL_01a5: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_0142: Expected O, but got I
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0107: Expected O, but got Ref
		List<Vector3> list = new List<Vector3>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v4+18]");
		object obj2 = default(object);
		if (num >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
			object obj3 = default(object);
			obj2 = obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj5 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj6 = 0 + obj5;
			_ = 1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj9 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj10 = 0 + obj9;
			_ = 0.52f;
		}
		colors = list;
		base._002Ector();
	}

	static TP_Confodere3_Special_Projectile()
	{
		int matColor = Shader.PropertyToID("_Color");
		_matColor = matColor;
		int matAlpha = Shader.PropertyToID("_Alpha");
		_matAlpha = matAlpha;
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		Despawn();
	}
}
