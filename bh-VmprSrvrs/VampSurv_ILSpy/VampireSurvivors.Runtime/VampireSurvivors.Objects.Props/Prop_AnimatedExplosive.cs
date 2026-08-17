using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Props;

public class Prop_AnimatedExplosive : Destructible
{
	public WeaponType MyWeaponType;

	public int BreakAnimationFramesNumber;

	private Stage _stage;

	private bool _hasFired;

	private bool hasAnimations;

	private void Construct(Stage stage)
	{
		_stage = stage;
	}

	public void InternalUpdate()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	public void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	public override void Init(PropType destructibleType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3F5D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Init(destructibleType);
		_hasFired = false;
		float2 float5 = base.position;
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				base.angle = 180f;
			}
		}
		float2 float6 = default(float2);
		base.position = float6;
		_spriteAnimation.SetAnimation("Idle");
		base._003CIgnoreForcedMovement_003Ek__BackingField = false;
	}

	protected override bool CanEmitLight()
	{
		//IL_0010: Expected O, but got I4
		object obj = _destructibleType - 102;
		return obj == null;
	}

	protected override void SetupAnimations()
	{
		if (hasAnimations)
		{
			return;
		}
		_spriteAnimation.CleanAnimations();
		PropData propData = _propData;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(propData._003CframeName_003Ek__BackingField, 1, 3, propData._003CtextureName_003Ek__BackingField, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		string animName = propData._003CframeName_003Ek__BackingField + "_break_";
		PropData propData2 = _propData;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName, 1, BreakAnimationFramesNumber, propData2._003CtextureName_003Ek__BackingField, num);
		Action action = delegate
		{
			//IL_0079: Expected O, but got I
			CoherenceSync coherenceSync = _coherenceSync;
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj = -3;
					bool flag2 = obj == null;
					flag = flag2;
				}
				if (!flag)
				{
					return;
				}
			}
			base.Despawn();
		};
		_spriteAnimation.AddAnimation("Break", animationFrames2, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		hasAnimations = true;
	}

	protected override void OnDestroyed()
	{
		//IL_00ca: Expected O, but got I
		//IL_03a9->IL0336: Incompatible stack heights: 1 vs 0
		//IL_00b5->IL0336: Incompatible stack heights: 1 vs 0
		//IL_03d3->IL0440: Incompatible stack heights: 1 vs 0
		//IL_00fb->IL0440: Incompatible stack heights: 1 vs 0
		//IL_0122->IL0336: Incompatible stack heights: 1 vs 0
		//IL_0151->IL0336: Incompatible stack heights: 1 vs 0
		//IL_0189->IL0336: Incompatible stack heights: 1 vs 0
		//IL_021f->IL0336: Incompatible stack heights: 1 vs 0
		//IL_024e->IL0336: Incompatible stack heights: 1 vs 0
		//IL_0440->IL0440: Incompatible stack heights: 1 vs 0
		//IL_041c->IL0440: Incompatible stack heights: 1 vs 0
		//IL_0291->IL0440: Incompatible stack heights: 1 vs 0
		//IL_02b8->IL0336: Incompatible stack heights: 1 vs 0
		//IL_02da->IL0336: Incompatible stack heights: 1 vs 0
		//IL_030e->IL0440: Incompatible stack heights: 1 vs 0
		if (_hasFired)
		{
			return;
		}
		base._003CIgnoreForcedMovement_003Ek__BackingField = true;
		Transform target;
		int index;
		Vector2 pos;
		Weapon weapon2;
		if ((object)_spriteAnimation != null)
		{
			_spriteAnimation.SetAnimation("Break");
			_hasFired = true;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (_playerOptions != null)
				{
					_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
					Transform stage = (Transform)(object)_stage;
					if ((object)_stage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v6 (UnityEngine.Transform)+228]");
						Transform transform2 = (Transform)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v6 (UnityEngine.Transform)+228]");
						if ((nint)0 == 0 || ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core._stage;
							if ((object)core._stage != null)
							{
								Predicate<Weapon> match = delegate(Weapon x)
								{
									//IL_0053: Expected I4, but got O
									//IL_0031: Expected O, but got I4
									if ((object)x == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									object obj = ((Equipment)x)._equipmentType - MyWeaponType;
									return obj == null;
								};
								if (stage2._003CStageHazardWeapons_003Ek__BackingField != null)
								{
									Weapon weapon = stage2._003CStageHazardWeapons_003Ek__BackingField.Find(match);
									Vector2 vector = default(Vector2);
									if ((object)weapon != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
									{
										target = null;
										index = 0;
										pos = vector;
										weapon2 = weapon;
										goto IL_0421;
									}
									GameManager core2 = GM.Core;
									if ((object)GM.Core != null)
									{
										Stage stage3 = core2._stage;
										if ((object)core2._stage != null)
										{
											BackgroundManager fancyBg = stage3._fancyBg;
											if ((object)stage3._fancyBg == null || ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0)
											{
												return;
											}
											GameManager core3 = GM.Core;
											if ((object)GM.Core != null && (object)core3._stage != null)
											{
												Weapon weapon3 = core3._stage.AddStageHazardWeapon(WeaponType.FB_EXPLOBARRELHAZARD);
												if ((object)weapon3 != null)
												{
													target = null;
													index = 0;
													pos = vector;
													weapon2 = weapon3;
													goto IL_0421;
												}
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
		throw new NullReferenceException();
		IL_0421:
		Projectile projectile = weapon2.FireOneProjectile(pos, index, target);
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c3: Invalid comparison between F4 and O
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_012c: Invalid comparison between F4 and O
		//IL_014a: Invalid comparison between F4 and I4
		//IL_0173: Expected O, but got I4
		//IL_01d6: Invalid comparison between I4 and F4
		//IL_029a->IL0218: Incompatible stack heights: 1 vs 0
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					object obj = default(object);
					float num = (float)obj * 2f;
					object obj2 = ret2 - ret;
					float num2 = num * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj3 = obj2 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v28 (UnityEngine.Bounds)+10]");
					float num3 = 0f * 2f;
					object obj5 = default(object);
					object obj6 = default(object);
					object obj4 = obj5 - obj6;
					float num4 = num3 * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj7 = obj4 & 0;
					bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
					float num5 = num4 - (float)obj7;
					bool flag4 = num5 == 0f;
					bool flag5 = !flag3;
					bool flag6 = !flag4;
					object obj8 = flag6 & flag5;
					if (obj8 != null && !_isDead)
					{
						if (0f < (_hp -= value))
						{
							OnGetDamaged(showHitVfx);
							return;
						}
						_isDead = true;
						OnDestroyed();
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void RestoreTint()
	{
		//IL_0019: Expected O, but got Ref
		//IL_0028: Invalid comparison between F4 and I4
		object obj = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(_destructibleRenderer, isEnabled: false, (Color?)(object)(&obj));
		if (!(_hp > 0f))
		{
			_blinkTimer.Cancel();
		}
	}

	public Prop_AnimatedExplosive()
	{
		//IL_004c: Expected I, but got O
		MyWeaponType = WeaponType.FB_EXPLOCARHAZARD;
		BreakAnimationFramesNumber = 11;
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CSetupAnimations_003Eb__10_0()
	{
		//IL_0079: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v6 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		base.Despawn();
	}

	private bool _003COnDestroyed_003Eb__11_0(Weapon x)
	{
		//IL_0053: Expected I4, but got O
		//IL_0031: Expected O, but got I4
		if ((object)x != null)
		{
			object obj = ((Equipment)x)._equipmentType - MyWeaponType;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
