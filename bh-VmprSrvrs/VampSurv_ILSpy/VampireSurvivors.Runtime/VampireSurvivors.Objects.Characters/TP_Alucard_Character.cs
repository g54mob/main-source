using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Alucard_Character : TP_Character
{
	private Image _HealthBar;

	private Image _HealthBarFill;

	private bool _isCharging;

	private float _chargeTime;

	private float _maxChargeTimeMS;

	private List<WeaponType> spells;

	private PhaserSprite _cursor1;

	private PhaserSprite _cursor2;

	private MultiTargetTween _angle1Tween;

	private MultiTargetTween _angle2Tween;

	private MultiTargetTween _scaleTween;

	private float OverhealDelay;

	private float OverhealTriggerValue;

	private int _currentOverheal;

	private int _maxOverheal;

	private VampireSurvivors.Framework.TimerSystem.Timer _overHealTimer;

	private TP_SoulSteal_Weapon soulStealWeapon;

	private TP_Dominus1_Weapon hellFireWeapon;

	private TP_SummonSpirit_Weapon summonSpiritWeapon;

	private TP_SwordBrothers_Weapon swordBrothersWeapon;

	private bool _fullyInitialized;

	public override bool DrainWeaponsImmunity => true;

	public unsafe override void AfterFullInitialization()
	{
		//IL_00fc: Expected I4, but got I8
		//IL_0143: Expected I4, but got I8
		//IL_0287: Expected I, but got O
		//IL_029a: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_03d2: Expected O, but got I4
		//IL_0550: Expected I, but got O
		//IL_0563: Expected O, but got I4
		//IL_0581: Expected O, but got I4
		//IL_058f: Expected O, but got I4
		//IL_0699: Expected I, but got O
		//IL_06a7: Expected I, but got O
		//IL_06b7: Expected O, but got I
		//IL_0737: Expected O, but got I4
		//IL_068c: Expected F4, but got I4
		//IL_13ae: Expected F4, but got I4
		//IL_06f3: Expected O, but got I
		//IL_1391: Expected O, but got F4
		//IL_0744: Expected F4, but got O
		//IL_0729: Expected O, but got I4
		//IL_098f: Expected I, but got O
		//IL_099d: Expected I, but got O
		//IL_09ad: Expected O, but got I
		//IL_0a2d: Expected O, but got I4
		//IL_0982: Expected F4, but got I4
		//IL_1402: Expected F4, but got I4
		//IL_09e9: Expected O, but got I
		//IL_13e5: Expected O, but got F4
		//IL_0a3a: Expected F4, but got O
		//IL_0a1f: Expected O, but got I4
		//IL_0c85: Expected I, but got O
		//IL_0c93: Expected I, but got O
		//IL_0ca3: Expected O, but got I
		//IL_0d23: Expected O, but got I4
		//IL_0c78: Expected F4, but got I4
		//IL_1456: Expected F4, but got I4
		//IL_0cdf: Expected O, but got I
		//IL_1439: Expected O, but got F4
		//IL_0d30: Expected F4, but got O
		//IL_0d15: Expected O, but got I4
		//IL_0f84: Expected I, but got O
		//IL_0f92: Expected I, but got O
		//IL_0fa2: Expected O, but got I
		//IL_1022: Expected O, but got I4
		//IL_0f77: Expected F4, but got I4
		//IL_14b2: Expected F4, but got I4
		//IL_0fde: Expected O, but got I
		//IL_148d: Expected O, but got F4
		//IL_1037: Expected F4, but got O
		//IL_1014: Expected O, but got I4
		//IL_1254: Expected F4, but got I4
		//IL_1297: Expected O, but got F4
		//IL_1275: Invalid comparison between F4 and I4
		//IL_01ff->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0275->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0253->IL0253: Incompatible stack heights: 3 vs 2
		//IL_0337->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_03ad->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_038b->IL038b: Incompatible stack heights: 3 vs 2
		//IL_046f->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_053e->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_04c3->IL04c3: Incompatible stack heights: 3 vs 2
		//IL_051c->IL051c: Incompatible stack heights: 3 vs 2
		//IL_061b->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_063d->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_13d6->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_080b->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_083a->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_08b0->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_08d2->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0911->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0933->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_142a->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0b01->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0b30->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0ba6->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0bc8->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0c07->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0c29->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_147e->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0df7->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0e26->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0e9c->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0ebe->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0efd->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_0f1f->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_14da->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_10fe->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_112d->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_11c3->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_11e5->IL12d8: Incompatible stack heights: 2 vs 0
		//IL_128d->IL128d: Incompatible stack heights: 3 vs 2
		base.AfterFullInitialization();
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		Weapon weapon;
		bool allowDuplicates = default(bool);
		float num;
		object obj7;
		if ((object)_HealthBarFill != null)
		{
			_HealthBarFill.sprite = unpackedSprite;
			if ((object)_HealthBar != null)
			{
				_HealthBar.sprite = unpackedSprite;
				_chargeTime = 0f;
				_isCharging = false;
				HideCharge();
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Diabologue03");
				_cursor1 = cursor;
				if ((object)_cursor1 != null)
				{
					PhaserSprite phaserSprite = _cursor1.setDepth(-1);
					GameObject gameObject2 = base.gameObject;
					PhaserSprite cursor2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Diabologue04");
					_cursor2 = cursor2;
					PhaserSprite phaserSprite2 = _cursor2.setDepth(-1);
					PhaserSprite phaserSprite3 = _cursor1.setAlpha(0f);
					PhaserSprite phaserSprite4 = _cursor2.setAlpha(0f);
					Transform transform = _cursor1.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector2 value = default(Vector2);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					Transform transform2 = _cursor2.transform;
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector2 value2 = default(Vector2);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
					if (_angle1Tween != null)
					{
						_angle1Tween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						if ((object)_cursor1 != null)
						{
							void* value3 = ((IntPtr*)(&array))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag3 = obj == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1157234688;
							_ = 4294967295L;
							((MaskableGraphic)(object)tweenConfig).m_ShouldRecalculateStencil = true;
							MultiTargetTween angle1Tween = Tweens.Add(tweenConfig);
							_angle1Tween = angle1Tween;
							if (_angle2Tween != null)
							{
								_angle2Tween.Kill();
							}
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							if (array2 != null)
							{
								if ((object)_cursor2 != null)
								{
									void* value4 = ((IntPtr*)(&array2))->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									bool flag4 = obj2 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig2 != null)
								{
									((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
									((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1158660096;
									_ = 4294967295L;
									((MaskableGraphic)(object)tweenConfig2).m_ShouldRecalculateStencil = true;
									MultiTargetTween angle2Tween = Tweens.Add(tweenConfig2);
									_angle2Tween = angle2Tween;
									if (_scaleTween != null)
									{
										_scaleTween.Kill();
									}
									TweenConfig tweenConfig3 = new TweenConfig();
									object[] array3 = new object[2];
									if (array3 != null)
									{
										if ((object)_cursor1 != null)
										{
											void* value5 = ((IntPtr*)(&array3))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj3 = default(object);
											bool flag5 = obj3 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if ((object)_cursor2 != null)
										{
											void* value6 = ((IntPtr*)(&array3))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj4 = default(object);
											bool flag6 = obj4 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig3 != null)
										{
											((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
											((MonoBehaviour)(object)tweenConfig3).m_CancellationTokenSource = (CancellationTokenSource)1133903872;
											_ = 4294967295L;
											_ = 1;
											((Graphic)(object)tweenConfig3).m_Material = (Material)4;
											((Graphic)(object)tweenConfig3).m_OnDirtyMaterialCallback = (UnityAction)1;
											Func<int, float> sprite = Tweens.Stagger(150f, new StaggerConfig
											{
												ease = Ease.Linear,
												start = 0f
											});
											((Image)(object)tweenConfig3).m_Sprite = (Sprite)(object)sprite;
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig3);
											_scaleTween = scaleTween;
											GameManager core = GM.Core;
											if ((object)GM.Core != null && core._weaponsFacade != null)
											{
												weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.TP_SOULSTEAL_WEAPON, this, removeFromStore: true, allowDuplicates);
												if ((object)weapon == null)
												{
													num = 0f;
													goto IL_1387;
												}
												nint num2 = (nint)weapon;
												nint num3 = (nint)typeof(TP_SoulSteal_Weapon);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2474 @ rdx_v149 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SoulSteal_Weapon>)+130]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2473 @ r9_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
												nint num4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2474 @ rdx_v149 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SoulSteal_Weapon>)+130]");
												if (num4 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2473 @ r9_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
													object obj6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2527 @ rax_v250+FFFFFFF8+v2475 @ rax_v245*8]");
													if (0 == (nint)typeof(TP_SoulSteal_Weapon))
													{
														obj7 = 1;
														goto IL_1396;
													}
												}
												obj7 = 0;
												goto IL_1396;
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
		goto IL_12d8;
		IL_143e:
		object obj8;
		bool flag7 = obj8 == null;
		float num5 = 0f;
		Weapon weapon2;
		if (!flag7)
		{
			num5 = (float)weapon2;
		}
		goto IL_142f;
		IL_142f:
		swordBrothersWeapon = (TP_SwordBrothers_Weapon)num5;
		TP_SwordBrothers_Weapon tP_SwordBrothers_Weapon = swordBrothersWeapon;
		if ((object)swordBrothersWeapon != null)
		{
			tP_SwordBrothers_Weapon._isManualFire = true;
			if (((Weapon)tP_SwordBrothers_Weapon)._firingTimer != null)
			{
				((Weapon)tP_SwordBrothers_Weapon)._firingTimer.Cancel();
			}
		}
		if ((object)swordBrothersWeapon != null)
		{
			swordBrothersWeapon.ResetFiringTimer();
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<WeaponType> list = config._003CUnlockedWeapons_003Ek__BackingField;
				if (config._003CUnlockedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v115 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj9 = default(object);
						if ((nint)obj9 != -1)
						{
							goto IL_0edb;
						}
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._levelUpFactory != null)
					{
						core2._levelUpFactory.ForceExclude(WeaponType.TP_SWORD_BROTHERS);
						goto IL_0edb;
					}
				}
			}
		}
		goto IL_12d8;
		IL_1396:
		bool flag8 = obj7 == null;
		num = 0f;
		if (!flag8)
		{
			num = (float)weapon;
		}
		goto IL_1387;
		IL_0edb:
		GameManager core3 = GM.Core;
		if ((object)GM.Core == null || core3._weaponsFacade == null)
		{
			goto IL_12d8;
		}
		Weapon weapon3 = core3._weaponsFacade.AddHiddenWeapon(WeaponType.TP_SUMMON_SPIRIT, this, removeFromStore: true, allowDuplicates);
		bool flag9;
		float num6;
		if ((object)weapon3 == null)
		{
			flag9 = true;
			num6 = 0f;
			goto IL_1483;
		}
		nint num7 = (nint)weapon3;
		nint num8 = (nint)typeof(TP_SummonSpirit_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3299 @ rdx_v116 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SummonSpirit_Weapon>)+130]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3298 @ r9_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3299 @ rdx_v116 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SummonSpirit_Weapon>)+130]");
		object obj12;
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3298 @ r9_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3352 @ rax_v181+FFFFFFF8+v3300 @ rax_v176*8]");
			if (0 == (nint)typeof(TP_SummonSpirit_Weapon))
			{
				obj12 = 1;
				goto IL_1492;
			}
		}
		obj12 = 0;
		goto IL_1492;
		IL_13ea:
		object obj13;
		bool flag10 = obj13 == null;
		float num10 = 0f;
		Weapon weapon4;
		if (!flag10)
		{
			num10 = (float)weapon4;
		}
		goto IL_13db;
		IL_1387:
		soulStealWeapon = (TP_SoulSteal_Weapon)num;
		TP_SoulSteal_Weapon tP_SoulSteal_Weapon = soulStealWeapon;
		if ((object)soulStealWeapon != null)
		{
			tP_SoulSteal_Weapon._isManualFire = true;
			if (((Weapon)tP_SoulSteal_Weapon)._firingTimer != null)
			{
				((Weapon)tP_SoulSteal_Weapon)._firingTimer.Cancel();
			}
		}
		if ((object)soulStealWeapon != null)
		{
			soulStealWeapon.ResetFiringTimer();
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2 != null)
			{
				List<WeaponType> list2 = config2._003CUnlockedWeapons_003Ek__BackingField;
				if (config2._003CUnlockedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v97 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj14 = default(object);
						if ((nint)obj14 != -1)
						{
							goto IL_08ef;
						}
					}
					GameManager core4 = GM.Core;
					if ((object)GM.Core != null && core4._levelUpFactory != null)
					{
						core4._levelUpFactory.ForceExclude(WeaponType.TP_SOULSTEAL_WEAPON);
						goto IL_08ef;
					}
				}
			}
		}
		goto IL_12d8;
		IL_120a:
		_currentOverheal = 0;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj15 = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		bool flag11 = (object)obj15 == null;
		float num11 = 0f;
		if (!flag11)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			float num12 = default(float);
			bool flag12 = num12 == 0f;
			num11 = num12;
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)num11;
		((CharacterController)this)._isCriticalHPEnabled = true;
		Action onCriticalHP = SwordBrothers;
		((CharacterController)this)._onCriticalHP = onCriticalHP;
		_fullyInitialized = true;
		return;
		IL_12d8:
		throw new NullReferenceException();
		IL_08ef:
		GameManager core5 = GM.Core;
		if ((object)GM.Core == null || core5._weaponsFacade == null)
		{
			goto IL_12d8;
		}
		weapon4 = core5._weaponsFacade.AddHiddenWeapon(WeaponType.TP_DOMINUS1, this, removeFromStore: true, allowDuplicates);
		if ((object)weapon4 == null)
		{
			num10 = 0f;
			goto IL_13db;
		}
		nint num13 = (nint)weapon4;
		nint num14 = (nint)typeof(TP_Dominus1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2749 @ rdx_v138 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+130]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2748 @ r9_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2749 @ rdx_v138 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+130]");
		if (num15 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2748 @ r9_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2802 @ rax_v227+FFFFFFF8+v2750 @ rax_v222*8]");
			if (0 == (nint)typeof(TP_Dominus1_Weapon))
			{
				obj13 = 1;
				goto IL_13ea;
			}
		}
		obj13 = 0;
		goto IL_13ea;
		IL_0be5:
		GameManager core6 = GM.Core;
		if ((object)GM.Core == null || core6._weaponsFacade == null)
		{
			goto IL_12d8;
		}
		weapon2 = core6._weaponsFacade.AddHiddenWeapon(WeaponType.TP_SWORD_BROTHERS, this, removeFromStore: true, allowDuplicates);
		if ((object)weapon2 == null)
		{
			num5 = 0f;
			goto IL_142f;
		}
		nint num16 = (nint)weapon2;
		nint num17 = (nint)typeof(TP_SwordBrothers_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3024 @ rdx_v127 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers_Weapon>)+130]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3023 @ r9_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3024 @ rdx_v127 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers_Weapon>)+130]");
		if (num18 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3023 @ r9_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3077 @ rax_v204+FFFFFFF8+v3025 @ rax_v199*8]");
			if (0 == (nint)typeof(TP_SwordBrothers_Weapon))
			{
				obj8 = 1;
				goto IL_143e;
			}
		}
		obj8 = 0;
		goto IL_143e;
		IL_13db:
		hellFireWeapon = (TP_Dominus1_Weapon)num10;
		TP_Dominus1_Weapon tP_Dominus1_Weapon = hellFireWeapon;
		if ((object)hellFireWeapon != null)
		{
			tP_Dominus1_Weapon._isManualFire = true;
			if (((Weapon)tP_Dominus1_Weapon)._firingTimer != null)
			{
				((Weapon)tP_Dominus1_Weapon)._firingTimer.Cancel();
			}
		}
		if ((object)hellFireWeapon != null)
		{
			hellFireWeapon.ResetFiringTimer();
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			if (config3 != null)
			{
				List<WeaponType> list3 = config3._003CUnlockedWeapons_003Ek__BackingField;
				if (config3._003CUnlockedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rcx_v106 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj20 = default(object);
						if ((nint)obj20 != -1)
						{
							goto IL_0be5;
						}
					}
					GameManager core7 = GM.Core;
					if ((object)GM.Core != null && core7._levelUpFactory != null)
					{
						core7._levelUpFactory.ForceExclude(WeaponType.TP_DOMINUS1);
						goto IL_0be5;
					}
				}
			}
		}
		goto IL_12d8;
		IL_1492:
		bool flag13 = obj12 == null;
		flag9 = (byte)num7 != 0;
		num6 = 0f;
		if (!flag13)
		{
			flag9 = (byte)num7 != 0;
			num6 = (float)weapon3;
		}
		goto IL_1483;
		IL_1483:
		summonSpiritWeapon = (TP_SummonSpirit_Weapon)num6;
		TP_SummonSpirit_Weapon tP_SummonSpirit_Weapon = summonSpiritWeapon;
		if ((object)summonSpiritWeapon != null)
		{
			tP_SummonSpirit_Weapon._isManualFire = true;
			if (((Weapon)tP_SummonSpirit_Weapon)._firingTimer != null)
			{
				((Weapon)tP_SummonSpirit_Weapon)._firingTimer.Cancel();
			}
		}
		if ((object)summonSpiritWeapon != null)
		{
			summonSpiritWeapon.ResetFiringTimer();
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			if (config4 != null)
			{
				List<WeaponType> list4 = config4._003CUnlockedWeapons_003Ek__BackingField;
				if (config4._003CUnlockedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						flag9 = false;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj21 = default(object);
						bool flag14 = (nint)obj21 != -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v124 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag15 = false;
						if (flag14)
						{
							goto IL_120a;
						}
					}
					GameManager core8 = GM.Core;
					if ((object)GM.Core != null && core8._levelUpFactory != null)
					{
						core8._levelUpFactory.ForceExclude(WeaponType.TP_SUMMON_SPIRIT);
						bool flag15 = flag9;
						goto IL_120a;
					}
				}
			}
		}
		goto IL_12d8;
	}

	private unsafe void HideCharge()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _HealthBar.color;
		object obj = default(object);
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		_isCharging = false;
	}

	private unsafe void ShowCharge()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _HealthBar.color;
		object obj = default(object);
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_003a: Invalid comparison between F4 and I4
		//IL_0074: Expected O, but got Ref
		//IL_0097: Expected O, but got Ref
		base.OnUpdate();
		if (!_fullyInitialized)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001875F7E60h\"");
		if (((CharacterController)this)._walked == 0f)
		{
			Color color = _HealthBar.color;
			object obj = default(object);
			_HealthBar.color = (Color)(&obj);
			Color color2 = _HealthBarFill.color;
			_HealthBarFill.color = (Color)(&obj);
			if (!_isCharging)
			{
				_isCharging = true;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float num2 = (_chargeTime = num + _chargeTime) / _maxChargeTimeMS;
			float num3 = num2 * 0.75f;
			float alpha = num3 + 0.25f;
			PhaserSprite phaserSprite = _cursor1.setAlpha(alpha);
			PhaserSprite phaserSprite2 = _cursor2.setAlpha(alpha);
			_HealthBarFill.fillAmount = num2;
			if (!(_chargeTime < _maxChargeTimeMS))
			{
				PhaserSprite phaserSprite3 = _cursor1.setAlpha(0f);
				PhaserSprite phaserSprite4 = _cursor2.setAlpha(0f);
				HideCharge();
				_chargeTime = 0f;
				if ((object)soulStealWeapon != null)
				{
					soulStealWeapon.Fire();
				}
			}
		}
		else
		{
			PhaserSprite phaserSprite5 = _cursor1.setAlpha(0f);
			PhaserSprite phaserSprite6 = _cursor2.setAlpha(0f);
			HideCharge();
		}
	}

	private void FireAllSpells()
	{
		if ((object)soulStealWeapon != null)
		{
			soulStealWeapon.Fire();
		}
	}

	private void SummonSpirit(float value, float rawValue)
	{
		float num = rawValue - value;
		if (num < OverhealTriggerValue || _currentOverheal >= _maxOverheal)
		{
			return;
		}
		float num2 = num / OverhealTriggerValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int num3 = default(int);
		bool flag = _maxOverheal >= num3;
		int num4 = num3;
		if (!flag)
		{
			num4 = _maxOverheal;
		}
		int currentOverheal = _currentOverheal + num4;
		_currentOverheal = currentOverheal;
		if (_overHealTimer != null)
		{
			_overHealTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_currentOverheal = 0;
		};
		float duration = OverhealDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer overHealTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_overHealTimer = overHealTimer;
		if (num4 <= 0)
		{
			return;
		}
		do
		{
			if ((object)summonSpiritWeapon != null)
			{
				summonSpiritWeapon.Fire();
			}
		}
		while ((object)summonSpiritWeapon != null);
	}

	public override void LevelUp()
	{
		//IL_0224: Expected O, but got I4
		base.LevelUp();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj = 0 * 4;
		object obj2 = obj + obj;
		if (((CharacterController)this)._level == (nint)obj2)
		{
			TP_SoulSteal_Weapon tP_SoulSteal_Weapon = soulStealWeapon;
			if ((object)soulStealWeapon != null && ((UnityEngine.Object)tP_SoulSteal_Weapon).m_CachedPtr != (IntPtr)0)
			{
				TP_SoulSteal_Weapon tP_SoulSteal_Weapon2 = soulStealWeapon;
				if (((Equipment)tP_SoulSteal_Weapon2)._003CLevel_003Ek__BackingField < 8)
				{
					bool flag = tP_SoulSteal_Weapon2.LevelUp(skipFire: true);
				}
			}
			TP_SummonSpirit_Weapon tP_SummonSpirit_Weapon = summonSpiritWeapon;
			if ((object)summonSpiritWeapon != null && ((UnityEngine.Object)tP_SummonSpirit_Weapon).m_CachedPtr != (IntPtr)0)
			{
				TP_SummonSpirit_Weapon tP_SummonSpirit_Weapon2 = summonSpiritWeapon;
				if (((Equipment)tP_SummonSpirit_Weapon2)._003CLevel_003Ek__BackingField < 8)
				{
					bool flag2 = tP_SummonSpirit_Weapon2.LevelUp(skipFire: true);
				}
			}
			TP_Dominus1_Weapon tP_Dominus1_Weapon = hellFireWeapon;
			if ((object)hellFireWeapon != null && ((UnityEngine.Object)tP_Dominus1_Weapon).m_CachedPtr != (IntPtr)0)
			{
				TP_Dominus1_Weapon tP_Dominus1_Weapon2 = hellFireWeapon;
				if (((Equipment)tP_Dominus1_Weapon2)._003CLevel_003Ek__BackingField < 8)
				{
					bool flag3 = tP_Dominus1_Weapon2.LevelUp(skipFire: true);
				}
			}
			TP_SwordBrothers_Weapon tP_SwordBrothers_Weapon = swordBrothersWeapon;
			if ((object)swordBrothersWeapon != null && ((UnityEngine.Object)tP_SwordBrothers_Weapon).m_CachedPtr != (IntPtr)0)
			{
				TP_SwordBrothers_Weapon tP_SwordBrothers_Weapon2 = swordBrothersWeapon;
				if (((Equipment)tP_SwordBrothers_Weapon2)._003CLevel_003Ek__BackingField < 8)
				{
					bool flag4 = tP_SwordBrothers_Weapon2.LevelUp(skipFire: true);
				}
			}
		}
		Action onComplete = delegate
		{
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = base.gameObject;
				if (gameObject2.activeSelf && !((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay && (object)hellFireWeapon != null)
				{
					hellFireWeapon.Fire();
				}
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SwordBrothers()
	{
		if ((object)swordBrothersWeapon != null)
		{
			swordBrothersWeapon.Fire();
		}
	}

	public override void OnMeleeAttackAnim()
	{
		//IL_0060: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CD4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_meleeAnim != null && !((CharacterController)this)._isAnimForced && !(((CharacterController)this)._walked > 0f))
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((CharacterController)this)._isAnimForced = true;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_spriteAnimation.SetAnimation("meleeA");
			_currentAnimation = CharAnimationType.melee;
		}
	}

	public TP_Alucard_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		_maxChargeTimeMS = 30000f;
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1447);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1447;
		}
		spells = list;
		OverhealDelay = 5000f;
		OverhealTriggerValue = 8f;
		_maxOverheal = 4;
		((CharacterController)this)._002Ector();
	}

	private void _003CSummonSpirit_003Eb__28_0()
	{
		_currentOverheal = 0;
	}

	private void _003CLevelUp_003Eb__29_0()
	{
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject2 = base.gameObject;
			if (gameObject2.activeSelf && !((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay && (object)hellFireWeapon != null)
			{
				hellFireWeapon.Fire();
			}
		}
	}
}
