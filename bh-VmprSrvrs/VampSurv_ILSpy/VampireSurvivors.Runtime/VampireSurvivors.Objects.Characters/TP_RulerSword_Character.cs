using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_RulerSword_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public SpriteRenderer s;

		internal void _003CAuraVFX_003Eb__0()
		{
			s.enabled = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(s, 0.95f);
		}

		internal void _003CAuraVFX_003Eb__1()
		{
			s.enabled = false;
		}

		internal void _003CAuraVFX_003Eb__2()
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(s, 1f);
		}
	}

	public Transform displayContainer;

	private SpriteRenderer _faceSprite;

	private SpriteRenderer _aura1Sprite;

	private SpriteRenderer _aura2Sprite;

	private List<SpriteRenderer> _aura3Sprites;

	private List<float> overhealTresholds;

	private float OverhealAttackTreshold;

	private Timer _overHealTimer;

	private bool _canOverheal;

	private float OverhealDelay;

	private float carryOverOverheal;

	private TP_RulerSword_Weapon RulerSwordWeapon;

	private MultiTargetTween _tweenAlpha1;

	private MultiTargetTween _tweenAlpha2;

	private MultiTargetTween _auraTween;

	private int SwordCount;

	public override bool NeedsCart => false;

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007f: Expected O, but got I4
		//IL_0c0c: Expected O, but got Ref
		//IL_0cfc: Expected O, but got Ref
		//IL_0d55: Expected O, but got Ref
		//IL_0db5: Expected O, but got Ref
		//IL_0e26: Expected O, but got Ref
		//IL_0f3b: Expected O, but got Ref
		//IL_0625: Expected I, but got O
		//IL_0633: Expected I, but got O
		//IL_0643: Expected O, but got I
		//IL_06c3: Expected O, but got I4
		//IL_060f: Expected I, but got O
		//IL_067f: Expected O, but got I
		//IL_0f9e: Expected O, but got I4
		//IL_06d0: Expected I4, but got O
		//IL_06b5: Expected O, but got I4
		//IL_07bc: Expected I, but got O
		//IL_0fd6: Expected I, but got O
		//IL_0fec: Expected O, but got I
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffa: Expected O, but got Unknown
		//IL_0888: Expected I, but got O
		//IL_1020: Expected O, but got I4
		//IL_1037: Expected I, but got I8
		//IL_1044: Expected I, but got O
		//IL_0871: Expected I, but got I8
		//IL_09a2: Expected I, but got O
		//IL_1056: Expected I, but got O
		//IL_106c: Expected O, but got I
		//IL_1075: Unknown result type (might be due to invalid IL or missing references)
		//IL_107a: Expected O, but got Unknown
		//IL_0a73: Expected I, but got O
		//IL_10ae: Expected I, but got I8
		//IL_10bb: Expected I, but got O
		//IL_0a46: Expected I, but got I8
		//IL_0206->IL0b64: Incompatible stack heights: 2 vs 0
		//IL_040c->IL0b64: Incompatible stack heights: 15 vs 0
		//IL_03cf->IL0b64: Incompatible stack heights: 15 vs 0
		//IL_042e->IL0b64: Incompatible stack heights: 15 vs 0
		//IL_0de9->IL0b64: Incompatible stack heights: 16 vs 0
		//IL_0e42->IL10c1: Incompatible stack heights: 17 vs 15
		//IL_05ad->IL0f72: Incompatible stack heights: 24 vs 15
		//IL_05cc->IL0b64: Incompatible stack heights: 24 vs 0
		//IL_0739->IL0b64: Incompatible stack heights: 24 vs 0
		//IL_07aa->IL0b64: Incompatible stack heights: 24 vs 0
		//IL_0788->IL0788: Incompatible stack heights: 25 vs 24
		//IL_091f->IL0b64: Incompatible stack heights: 24 vs 0
		//IL_0990->IL0b64: Incompatible stack heights: 24 vs 0
		//IL_096e->IL096e: Incompatible stack heights: 25 vs 24
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.AfterFullInitialization();
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj3 = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		int num = default(int);
		if ((object)obj3 == null)
		{
			num = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if (num == 0)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)num;
		if ((object)((CharacterController)this)._spriteTrail != null)
		{
			((CharacterController)this)._spriteTrail.Reset();
			SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
			if ((object)((CharacterController)this)._spriteTrail != null)
			{
				spriteTrail._MaxHistory = 0;
				((CharacterController)this)._spriteTrail.InitialiseGhosts(expandExisting: true);
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					((ArcadeSprite)this)._spriteRenderer.enabled = false;
					float2 float5 = base.cachedPosition;
					GameObject gameObject = base.gameObject;
					Vector2 vector = default(Vector2);
					string spriteName = default(string);
					SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "character_tp_swordruler", spriteName);
					bool flag = ((Delegate)(object)spriteRenderer).method_ptr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((Delegate)(object)spriteRenderer).method_ptr, 0);
					_faceSprite = spriteRenderer;
					Transform transform = _faceSprite.transform;
					transform.SetParent(displayContainer, worldPositionStays: true);
					Transform transform2 = _faceSprite.transform;
					_ = 0;
					bool flag2 = ((Delegate)(object)transform2).method_ptr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Transform.set_localPosition_Injected(((Delegate)(object)transform2).method_ptr, ref *(Vector3*)obj4);
					float2 float6 = base.cachedPosition;
					GameObject gameObject2 = base.gameObject;
					SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject2, vector, vector, "character_tp_swordruler", spriteName);
					if ((object)spriteRenderer2 != null)
					{
						bool flag3 = ((Delegate)(object)spriteRenderer2).method_ptr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((Delegate)(object)spriteRenderer2).method_ptr, 1);
						_aura1Sprite = spriteRenderer2;
						float2 float7 = base.cachedPosition;
						GameObject gameObject3 = base.gameObject;
						SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject3, vector, vector, "character_tp_swordruler", spriteName);
						bool flag4 = (object)spriteRenderer3 == null;
						bool flag5 = ((Delegate)(object)spriteRenderer3).method_ptr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((Delegate)(object)spriteRenderer3).method_ptr, 1);
						_aura2Sprite = spriteRenderer3;
						bool flag6 = (object)_aura1Sprite == null;
						Transform transform3 = _aura1Sprite.transform;
						bool flag7 = (object)transform3 == null;
						transform3.SetParent(displayContainer, worldPositionStays: true);
						bool flag8 = (object)_aura1Sprite == null;
						Transform transform4 = _aura1Sprite.transform;
						bool flag9 = (object)transform4 == null;
						_ = 0;
						bool flag10 = ((Delegate)(object)transform4).method_ptr == (IntPtr)0;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Transform.set_localPosition_Injected(((Delegate)(object)transform4).method_ptr, ref *(Vector3*)obj5);
						bool flag11 = (object)_aura2Sprite == null;
						Transform transform5 = _aura2Sprite.transform;
						bool flag12 = (object)transform5 == null;
						transform5.SetParent(displayContainer, worldPositionStays: true);
						bool flag13 = (object)_aura2Sprite == null;
						Transform transform6 = _aura2Sprite.transform;
						bool flag14 = (object)transform6 == null;
						_ = 0;
						bool flag15 = ((Delegate)(object)transform6).method_ptr == (IntPtr)0;
						object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
						Transform.set_localPosition_Injected(((Delegate)(object)transform6).method_ptr, ref *(Vector3*)obj6);
						int num2 = 0;
						object[] array = null;
						object obj14 = default(object);
						object obj19 = default(object);
						while (true)
						{
							if (body == null)
							{
								Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
								if ((object)cachedTrans == null)
								{
									break;
								}
								_ = 0;
								_ = 0;
								bool flag16 = ((Delegate)(object)cachedTrans).method_ptr == (IntPtr)0;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								Transform.get_position_Injected(((Delegate)(object)cachedTrans).method_ptr, out *(Vector3*)obj7);
								Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
								if ((object)cachedTrans2 == null)
								{
									break;
								}
								_ = 0;
								_ = 0;
								bool flag17 = ((Delegate)(object)cachedTrans2).method_ptr == (IntPtr)0;
								object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
								Transform.get_position_Injected(((Delegate)(object)cachedTrans2).method_ptr, out *(Vector3*)obj8);
							}
							else
							{
								BaseBody baseBody = body;
								if (body == null || baseBody._transform == null)
								{
									break;
								}
							}
							GameObject gameObject4 = base.gameObject;
							SpriteRenderer spriteRenderer4 = RenderingExtensions.AddSprite(gameObject4, vector, vector, "character_tp_swordruler", spriteName);
							bool flag18 = (object)spriteRenderer4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2963 @ rax_v141 (UnityEngine.SpriteRenderer)+10]");
							bool flag19 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2963 @ rax_v141 (UnityEngine.SpriteRenderer)+10]");
							Renderer.set_sortingOrder_Injected((IntPtr)0, 2);
							SpriteRenderer spriteRenderer5 = RenderingExtensions.SetAlpha(spriteRenderer4, 0f);
							bool flag20 = (object)spriteRenderer5 == null;
							Transform transform7 = spriteRenderer5.transform;
							bool flag21 = (object)transform7 == null;
							transform7.SetParent(displayContainer, worldPositionStays: true);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2964 @ rax_v146 (UnityEngine.SpriteRenderer)+10]");
							bool flag22 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2964 @ rax_v146 (UnityEngine.SpriteRenderer)+10]");
							IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
							Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							bool flag23 = (object)transform8 == null;
							_ = 0;
							bool flag24 = ((string)(object)transform8)._stringLength == 0;
							object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Transform.set_localPosition_Injected((IntPtr)((string)(object)transform8)._stringLength, ref *(Vector3*)obj9);
							List<object> aura3Sprites = (List<object>)(object)_aura3Sprites;
							bool flag25 = _aura3Sprites == null;
							int version = aura3Sprites._version + 1;
							aura3Sprites._version = version;
							array = aura3Sprites._items;
							bool flag26 = aura3Sprites._items == null;
							if (aura3Sprites._size >= array.Length)
							{
								((List<object>)(object)_aura3Sprites).AddWithResize((object)spriteRenderer5);
							}
							else
							{
								int num3 = aura3Sprites._size + 1;
								aura3Sprites._size = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							num2++;
							if (num2 < 5)
							{
								continue;
							}
							if ((object)((CharacterController)this)._weaponsManager == null)
							{
								break;
							}
							Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_RULERSWORD_BODY, searchHidden: true);
							int num5;
							nint num4;
							if ((object)weaponByType == null)
							{
								num4 = unchecked((nint)null);
								num5 = 0;
								goto IL_0f94;
							}
							num4 = (nint)weaponByType;
							nint num6 = (nint)typeof(TP_RulerSword_Weapon);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3569 @ rdx_v140 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RulerSword_Weapon>)+130]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r9_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3569 @ rdx_v140 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RulerSword_Weapon>)+130]");
							object obj12;
							if (num7 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r9_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
								object obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3622 @ rax_v251+FFFFFFF8+v3570 @ rax_v246*8]");
								if (0 == (nint)typeof(TP_RulerSword_Weapon))
								{
									obj12 = 1;
									goto IL_0fa3;
								}
							}
							obj12 = 0;
							goto IL_0fa3;
							IL_0f94:
							RulerSwordWeapon = (TP_RulerSword_Weapon)num5;
							if (_tweenAlpha1 != null)
							{
								_tweenAlpha1.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array2 = new object[1];
							if (array2 == null)
							{
								break;
							}
							if ((object)_aura1Sprite != null)
							{
								object obj13 = array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag27 = obj14 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig == null)
							{
								break;
							}
							((Delegate)(object)tweenConfig).method_ptr = (IntPtr)array2;
							_ = 0;
							((Delegate)(object)tweenConfig).invoke_impl = (IntPtr)1148796928;
							_ = 1;
							_ = 4294967295L;
							_ = 1064514355;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
							_ = 0;
							TweenCallback tweenCallback = null;
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r10_v30 (Il2CppMethodInfo)+8]");
							((Delegate)tweenCallback).method_ptr = (IntPtr)0;
							((Delegate)tweenCallback).method = (nint)__ldftn(TP_RulerSword_Character._003CAfterFullInitialization_003Eb__19_0);
							((Delegate)tweenCallback).m_target = this;
							((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r10_v30 (Il2CppMethodInfo)+4C]");
							object obj15 = (nint)0 >> 4;
							object obj16 = obj15 & 1;
							nint num9;
							if (obj16 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r10_v30 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num9 = unchecked((nint)6447293664L);
									goto IL_1017;
								}
							}
							((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
							num9 = ((Delegate)tweenCallback).method_ptr;
							goto IL_1017;
							IL_0fa3:
							bool flag28 = obj12 == null;
							num5 = 0;
							if (!flag28)
							{
								num5 = (int)weaponByType;
							}
							goto IL_0f94;
							IL_1017:
							object obj17 = 24;
							((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
							((Delegate)(object)tweenConfig).delegate_trampoline = (IntPtr)tweenCallback;
							MultiTargetTween tweenAlpha = Tweens.Add(tweenConfig);
							_tweenAlpha1 = tweenAlpha;
							if (_tweenAlpha2 != null)
							{
								_tweenAlpha2.Kill();
							}
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array3 = new object[1];
							if (array3 == null)
							{
								break;
							}
							if ((object)_aura2Sprite != null)
							{
								object obj18 = array3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag29 = obj19 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 == null)
							{
								break;
							}
							((Delegate)(object)tweenConfig2).method_ptr = (IntPtr)array3;
							((Delegate)(object)tweenConfig2).invoke_impl = (IntPtr)1154473984;
							_ = 0;
							_ = 1;
							_ = 4294967295L;
							_ = 1064514355;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
							_ = 0;
							TweenCallback tweenCallback2 = null;
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1257 @ r10_v31 (Il2CppMethodInfo)+8]");
							((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
							((Delegate)tweenCallback2).method = (nint)__ldftn(TP_RulerSword_Character._003CAfterFullInitialization_003Eb__19_1);
							((Delegate)tweenCallback2).m_target = this;
							((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1257 @ r10_v31 (Il2CppMethodInfo)+4C]");
							object obj20 = (nint)0 >> 4;
							object obj21 = obj20 & 1;
							nint num11;
							if (obj21 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1257 @ r10_v31 (Il2CppMethodInfo)+52]");
								bool flag30 = (nint)0 == 0;
								num11 = unchecked((nint)6447293664L);
								if (flag30)
								{
									goto IL_1097;
								}
							}
							num11 = ((Delegate)tweenCallback2).method_ptr;
							((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
							goto IL_1097;
							IL_1097:
							((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
							((Delegate)(object)tweenConfig2).delegate_trampoline = (IntPtr)tweenCallback2;
							MultiTargetTween tweenAlpha2 = Tweens.Add(tweenConfig2);
							_tweenAlpha2 = tweenAlpha2;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveY(displayContainer, -0.04f, 1f);
							if (tweenerCore == null)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1306 @ rax_v199 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1306 @ rax_v199 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1306 @ rax_v199 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
								if ((nint)0 == 0)
								{
									_ = 2139095040;
								}
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void AuraVFX()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0171: Expected I, but got O
		//IL_01e2: Expected O, but got I4
		//IL_05b3: Expected I, but got O
		//IL_05c9: Expected O, but got I
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Expected O, but got Unknown
		//IL_028c: Expected I, but got O
		//IL_05fd: Expected O, but got I4
		//IL_0614: Expected I, but got I8
		//IL_0633: Expected I, but got O
		//IL_0649: Expected O, but got I
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_0657: Expected O, but got Unknown
		//IL_0275: Expected I, but got I8
		//IL_032b: Expected I, but got O
		//IL_067d: Expected O, but got I4
		//IL_0694: Expected I, but got I8
		//IL_0314: Expected I, but got I8
		//IL_06d2: Expected I, but got O
		//IL_03cf: Expected I, but got O
		//IL_0437: Expected O, but got I4
		//IL_072a: Expected I, but got O
		//IL_0740: Expected O, but got I
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_074e: Expected O, but got Unknown
		//IL_04e1: Expected I, but got O
		//IL_0774: Expected O, but got I4
		//IL_078b: Expected I, but got I8
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected O, but got Unknown
		//IL_04ca: Expected I, but got I8
		//IL_0098->IL0545: Incompatible stack heights: 1 vs 0
		//IL_00b5->IL0545: Incompatible stack heights: 1 vs 0
		//IL_0142->IL0545: Incompatible stack heights: 1 vs 0
		//IL_05a1->IL0545: Incompatible stack heights: 1 vs 0
		//IL_039b->IL0545: Incompatible stack heights: 1 vs 0
		//IL_06fb->IL0545: Incompatible stack heights: 2 vs 0
		//IL_0718->IL0545: Incompatible stack heights: 2 vs 0
		//IL_03f2->IL03f2: Incompatible stack heights: 3 vs 2
		//IL_0532->IL0545: Incompatible stack heights: 2 vs 0
		//IL_0544->IL079d: Incompatible stack heights: 2 vs 0
		List<SpriteRenderer> aura3Sprites = _aura3Sprites;
		if (_aura3Sprites != null)
		{
			object obj = 0;
			object obj2 = 0;
			object obj4 = default(object);
			object obj12 = default(object);
			while (true)
			{
				if ((nint)obj2 >= aura3Sprites._size)
				{
					return;
				}
				_003C_003Ec__DisplayClass20_0 obj3 = new _003C_003Ec__DisplayClass20_0();
				List<SpriteRenderer> aura3Sprites2 = _aura3Sprites;
				if (_aura3Sprites == null)
				{
					break;
				}
				bool flag = (nint)obj >= aura3Sprites2._size;
				SpriteRenderer[] items = aura3Sprites2._items;
				if (aura3Sprites2._items == null || obj3 == null)
				{
					break;
				}
				obj3.s = items[obj];
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(obj3.s, 1f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(obj3.s, 0.95f);
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if (array == null)
				{
					break;
				}
				if ((object)obj3.s != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = obj3.s;
				if (tweenConfig == null)
				{
					break;
				}
				tweenConfig.targets = array;
				tweenConfig.duration = 300f;
				tweenConfig.alpha = (float?)(object)1;
				float delay = (float)obj * 100f;
				tweenConfig.delay = delay;
				TweenCallback tweenCallback = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v9 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CAuraVFX_003Eb__0);
				((Delegate)tweenCallback).m_target = obj3;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v9 (Il2CppMethodInfo)+4C]");
				object obj5 = (nint)0 >> 4;
				object obj6 = obj5 & 1;
				nint num3;
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v9 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num3 = unchecked((nint)6447293664L);
						goto IL_05f4;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num3 = ((Delegate)tweenCallback).method_ptr;
				goto IL_05f4;
				IL_076b:
				object obj7 = 24;
				TweenCallback tweenCallback2;
				((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
				TweenConfig tweenConfig2;
				tweenConfig2.onStart = tweenCallback2;
				MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
				aura3Sprites = _aura3Sprites;
				obj++;
				if (_aura3Sprites == null)
				{
					break;
				}
				obj2 = obj;
				continue;
				IL_05f4:
				object obj8 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				tweenConfig.onStart = tweenCallback;
				TweenCallback tweenCallback3 = null;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v10 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CAuraVFX_003Eb__1);
				((Delegate)tweenCallback3).m_target = obj3;
				((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v10 (Il2CppMethodInfo)+4C]");
				object obj9 = (nint)0 >> 4;
				object obj10 = obj9 & 1;
				nint num5;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v10 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num5 = unchecked((nint)6447293664L);
						goto IL_0674;
					}
				}
				((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
				num5 = ((Delegate)tweenCallback3).method_ptr;
				goto IL_0674;
				IL_0674:
				object obj11 = 24;
				((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
				tweenConfig.onComplete = tweenCallback3;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig);
				tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				TweenConfig s = (TweenConfig)(object)obj3.s;
				if ((object)obj3.s == null)
				{
					break;
				}
				bool flag2 = s.targets == null;
				IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)s.targets);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if (array2 == null)
				{
					break;
				}
				if ((object)transform != null)
				{
					nint num6 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag3 = obj12 == null;
				}
				array2[0] = transform;
				if (tweenConfig2 == null)
				{
					break;
				}
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 300f;
				tweenConfig2.scale = (float?)(object)1;
				float delay2 = (float)obj * 100f;
				tweenConfig2.delay = delay2;
				tweenCallback2 = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v11 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CAuraVFX_003Eb__2);
				((Delegate)tweenCallback2).m_target = obj3;
				((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v11 (Il2CppMethodInfo)+4C]");
				object obj13 = (nint)0 >> 4;
				object obj14 = obj13 & 1;
				nint num8;
				if (obj14 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r10_v11 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num8 = unchecked((nint)6447293664L);
						goto IL_076b;
					}
				}
				((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
				num8 = ((Delegate)tweenCallback2).method_ptr;
				goto IL_076b;
			}
		}
		throw new NullReferenceException();
	}

	private void CharacterHealed(float value, float rawValue)
	{
		//IL_0019: Expected O, but got I4
		//IL_0377: Invalid comparison between I4 and F4
		//IL_0389: Expected F4, but got I4
		//IL_0057: Expected O, but got I
		//IL_006c: Invalid comparison between F4 and I
		//IL_0446: Expected I, but got O
		//IL_0186: Expected I, but got O
		//IL_01f1: Expected I, but got O
		//IL_02c0: Expected O, but got I4
		//IL_02ef: Expected F4, but got I4
		//IL_032c: Expected O, but got I4
		float num2 = default(float);
		float num = num2 - value;
		float num3 = (carryOverOverheal = num + carryOverOverheal);
		bool flag = SwordCount >= 12;
		TP_RulerSword_Character tP_RulerSword_Character = this;
		if (!flag)
		{
			List<float> list = overhealTresholds;
			tP_RulerSword_Character = (TP_RulerSword_Character)SwordCount;
			int swordCount = SwordCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)swordCount >= (nint)0)
			{
				goto IL_0406;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
			SoundManager.SoundConfig soundConfig = (SoundManager.SoundConfig)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v5 (VampireSurvivors.Framework.SoundManager+SoundConfig)+20+v119 @ rcx_v7 (VampireSurvivors.Objects.Characters.TP_RulerSword_Character)*4]");
			if (!(num3 < 0f))
			{
				if (!_canOverheal)
				{
					return;
				}
				_canOverheal = false;
				if (_overHealTimer != null)
				{
					_overHealTimer.Cancel();
				}
				Action action = delegate
				{
					_canOverheal = true;
				};
				float duration = OverhealDelay * 0.001f;
				bool flag2 = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer overHealTimer = Timers.Register(duration, action, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_overHealTimer = overHealTimer;
				TP_RulerSword_Weapon rulerSwordWeapon = RulerSwordWeapon;
				tP_RulerSword_Character = (TP_RulerSword_Character)(object)typeof(UnityEngine.Object);
				bool flag3 = (object)RulerSwordWeapon == null;
				nint num4 = unchecked((nint)null);
				Action<float> action2 = null;
				soundConfig = (SoundManager.SoundConfig)(object)action;
				if (!flag3)
				{
					bool flag4 = ((UnityEngine.Object)rulerSwordWeapon).m_CachedPtr == (IntPtr)0;
					num4 = unchecked((nint)null);
					action2 = null;
					soundConfig = (SoundManager.SoundConfig)(object)action;
					tP_RulerSword_Character = (TP_RulerSword_Character)(object)typeof(UnityEngine.Object);
					if (!flag4)
					{
						TP_RulerSword_Weapon rulerSwordWeapon2 = RulerSwordWeapon;
						tP_RulerSword_Character = (TP_RulerSword_Character)(object)typeof(UnityEngine.Object);
						List<TP_RulerSword_Weapon_Sprite> swords = rulerSwordWeapon2._swords;
						bool flag5 = rulerSwordWeapon2._activeCount >= swords._size;
						num4 = unchecked((nint)null);
						action2 = null;
						soundConfig = (SoundManager.SoundConfig)(object)action;
						if (!flag5)
						{
							List<TP_RulerSword_Weapon_Sprite> swords2 = rulerSwordWeapon2._swords;
							int activeCount = rulerSwordWeapon2._activeCount;
							if (rulerSwordWeapon2._activeCount >= swords2._size)
							{
								goto IL_0406;
							}
							TP_RulerSword_Weapon_Sprite[] items = swords2._items;
							items[activeCount].Enable();
							int activeCount2 = rulerSwordWeapon2._activeCount + 1;
							rulerSwordWeapon2._activeCount = activeCount2;
							carryOverOverheal = 0f;
							AuraVFX();
							SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
							soundConfig2.Volume = (float?)(object)1;
							soundConfig2.Rate = 1f;
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicRegen, soundConfig2, 200f, 12, flag2 ? 1 : 0);
							int swordCount2 = SwordCount + 1;
							SwordCount = swordCount2;
							num4 = 12;
							action2 = null;
							soundConfig = soundConfig2;
							tP_RulerSword_Character = (TP_RulerSword_Character)278;
						}
					}
				}
			}
			if (SwordCount < 12)
			{
				return;
			}
		}
		TP_RulerSword_Weapon rulerSwordWeapon3 = RulerSwordWeapon;
		WeaponData currentWeaponData = ((Weapon)rulerSwordWeapon3)._currentWeaponData;
		float num5 = carryOverOverheal * 0.03f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
		bool flag6 = !(0f < num5);
		float num6 = 0f;
		if (!flag6)
		{
			num6 = num5;
		}
		float num7 = num6 + 1f;
		currentWeaponData._003Cpower_003Ek__BackingField = num7;
		if (num > OverhealAttackTreshold)
		{
			RulerSwordWeapon.Attack();
		}
		return;
		IL_0406:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TP_RulerSword_Character()
	{
		//IL_0037: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_0598: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_05c0: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_05e8: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_0610: Expected O, but got I
		//IL_0239: Expected O, but got I
		//IL_0638: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_0660: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_0688: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_06b0: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_06d8: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_0700: Expected O, but got I
		//IL_04b5: Expected O, but got I
		//IL_0728: Expected O, but got I
		//IL_051f: Expected O, but got I
		List<SpriteRenderer> aura3Sprites = new List<SpriteRenderer>();
		_aura3Sprites = aura3Sprites;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(40f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1109393408;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(80f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1117782016;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v9+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(160f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1126170624;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v10+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(320f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1134559232;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v11+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(480f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1139802112;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v12+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(640f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1142947840;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v13+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(800f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1145569280;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v14+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(960f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1148190720;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdx_v15+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(1120f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1150025728;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v16+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(1280f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1151336448;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rdx_v17+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(1440f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1152647168;
		}
		overhealTresholds = list;
		OverhealAttackTreshold = 32f;
		_canOverheal = true;
		OverhealDelay = 1000f;
		((CharacterController)this)._002Ector();
	}

	private void _003CAfterFullInitialization_003Eb__19_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_aura1Sprite, 0f);
	}

	private void _003CAfterFullInitialization_003Eb__19_1()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_aura2Sprite, 0f);
	}

	private void _003CCharacterHealed_003Eb__21_0()
	{
		_canOverheal = true;
	}
}
