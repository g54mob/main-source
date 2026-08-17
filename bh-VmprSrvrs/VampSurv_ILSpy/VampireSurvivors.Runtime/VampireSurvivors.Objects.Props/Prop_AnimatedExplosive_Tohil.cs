using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Props;

public class Prop_AnimatedExplosive_Tohil : Destructible
{
	private float TreasureChance;

	private float GraceTimes;

	private float MaxGrace;

	public int BreakAnimationFramesNumber;

	private Stage _stage;

	private bool _hasFired;

	private bool hasAnimations;

	public virtual WeaponType MyWeaponType => WeaponType.EX_TOHILSTATUE;

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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3F62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Init(destructibleType);
		_hasFired = false;
		_spriteAnimation.SetAnimation("Idle");
		base._003CIgnoreForcedMovement_003Ek__BackingField = false;
	}

	public override void RemoteDestroy()
	{
		_hp = 0f;
		_isDead = true;
		OnDestroyed();
	}

	protected override void SetupAnimations()
	{
		//IL_00eb: Expected I, but got O
		if (!hasAnimations)
		{
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Props.Prop_AnimatedExplosive_Tohil>)+330]");
			Action action = new Action(this, (IntPtr)0);
			nint num2 = (nint)this;
			_spriteAnimation.AddAnimation("Break", animationFrames2, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			hasAnimations = true;
		}
	}

	protected override void OnDestroyed()
	{
		//IL_0379->IL0306: Incompatible stack heights: 1 vs 0
		//IL_00b3->IL0306: Incompatible stack heights: 1 vs 0
		//IL_00e2->IL0306: Incompatible stack heights: 1 vs 0
		//IL_011a->IL0306: Incompatible stack heights: 1 vs 0
		//IL_0198->IL0306: Incompatible stack heights: 1 vs 0
		//IL_01c7->IL0306: Incompatible stack heights: 1 vs 0
		//IL_03d2->IL03f4: Incompatible stack heights: 1 vs 0
		//IL_0231->IL0306: Incompatible stack heights: 1 vs 0
		//IL_025d->IL0306: Incompatible stack heights: 1 vs 0
		//IL_03ef->IL0306: Incompatible stack heights: 1 vs 0
		if (_hasFired)
		{
			return;
		}
		base._003CIgnoreForcedMovement_003Ek__BackingField = true;
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
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage = core._stage;
						if ((object)core._stage != null)
						{
							Predicate<Weapon> match = delegate(Weapon x)
							{
								//IL_005b: Expected I4, but got O
								//IL_0039: Expected O, but got I4
								if ((object)x == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								WeaponType myWeaponType2 = MyWeaponType;
								object obj = ((Equipment)x)._equipmentType - myWeaponType2;
								return obj == null;
							};
							if (stage._003CStageHazardWeapons_003Ek__BackingField != null)
							{
								Weapon weapon = stage._003CStageHazardWeapons_003Ek__BackingField.Find(match);
								if ((object)weapon != null)
								{
									bool flag2 = ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0;
									weapon2 = weapon;
									if (flag2)
									{
										goto IL_02b9;
									}
								}
								GameManager core2 = GM.Core;
								if ((object)GM.Core != null)
								{
									Stage stage2 = core2._stage;
									if ((object)core2._stage != null)
									{
										Transform fancyBg = (Transform)(object)stage2._fancyBg;
										if ((object)stage2._fancyBg == null || ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0)
										{
											goto IL_03c7;
										}
										GameManager core3 = GM.Core;
										if ((object)GM.Core != null)
										{
											WeaponType myWeaponType = MyWeaponType;
											if ((object)core3._stage != null)
											{
												Weapon weapon3 = core3._stage.AddStageHazardWeapon(myWeaponType);
												if ((object)weapon3 != null)
												{
													bool flag3 = ((UnityEngine.Object)weapon3).m_CachedPtr != (IntPtr)0;
													weapon2 = weapon3;
													if (!flag3)
													{
														goto IL_02b9;
													}
													goto IL_03c7;
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
		throw new NullReferenceException();
		IL_03c7:
		AfterDestroyed();
		return;
		IL_02b9:
		Vector2 pos = default(Vector2);
		Projectile projectile = weapon2.FireOneProjectile(pos, 0);
		Projectile projectile2 = weapon2.FireOneProjectile(pos, 1);
		Projectile projectile3 = weapon2.FireOneProjectile(pos, 2);
		goto IL_03c7;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_016e: Invalid comparison between F4 and O
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01d7: Invalid comparison between F4 and O
		//IL_01f5: Invalid comparison between F4 and I4
		//IL_021e: Expected O, but got I4
		//IL_007f->IL024f: Incompatible stack heights: 1 vs 0
		//IL_00c8->IL024f: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL024f: Incompatible stack heights: 1 vs 0
		//IL_02db->IL024f: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			if (core._mainCharacters != null)
			{
				bool flag = mainCharacters._size <= 0;
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				if (mainCharacters._items != null)
				{
					if (items.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if ((object)items[0] != null)
					{
						Transform transform = items[0].transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							Transform transform2 = base.transform;
							if ((object)transform2 != null)
							{
								bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
								Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
								object obj = default(object);
								float num = (float)obj * 2f;
								object obj2 = ret2 - ret;
								float num2 = num * 0.5f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj3 = obj2 & 0;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ rax_v34 (UnityEngine.Bounds)+10]");
									float num3 = 0f * 2f;
									object obj5 = default(object);
									object obj6 = default(object);
									object obj4 = obj5 - obj6;
									float num4 = num3 * 0.5f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
									object obj7 = obj4 & 0;
									bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
									float num5 = num4 - (float)obj7;
									bool flag5 = num5 == 0f;
									bool flag6 = !flag4;
									bool flag7 = !flag5;
									object obj8 = flag7 & flag6;
									if (obj8 != null)
									{
										ReceiveDamage(value, showHitVfx);
									}
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ReceiveDamage(float value, HitVfxType showHitVfx = HitVfxType.Default)
	{
		//IL_0029: Invalid comparison between I4 and F4
		if (_isDead)
		{
			return;
		}
		if (0f < (_hp -= value))
		{
			OnGetDamaged(showHitVfx);
			return;
		}
		_isDead = true;
		if (!_coherenceSync.HasStateAuthority)
		{
			Action action = DestroyTohil;
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.AuthorityOnly);
		}
		else
		{
			OnDestroyed();
		}
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			OnGetDamaged(showHitVfx);
		}
	}

	public void DestroyTohil()
	{
		_hp = 0f;
		ReceiveDamage(0f);
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

	public virtual void AfterDestroyed()
	{
		//IL_0095: Expected O, but got F4
		//IL_0040: Invalid comparison between F4 and O
		object obj = UnityEngine.Random.value;
		float num = GraceTimes + TreasureChance;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float num2 = gameSessionData._activeCharacter.PLuck();
		object obj2 = default(object);
		float num3 = (float)obj2 * num;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float graceTimes = GraceTimes + 0.015f;
			GraceTimes = graceTimes;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 126 Invalid \"Jump target not found in method: 0x186FEAAC0\"");
		throw new NullReferenceException();
	}

	private void SpawnTreasure()
	{
		//IL_0098: Expected I, but got O
		//IL_07cb: Expected O, but got F4
		//IL_0a3f: Expected O, but got F4
		//IL_07ec: Expected O, but got F4
		//IL_0a70: Expected O, but got F4
		//IL_0a80: Expected O, but got I
		//IL_0aeb: Expected O, but got I
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Expected O, but got Unknown
		//IL_085c: Expected O, but got I4
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Expected O, but got Unknown
		//IL_0204: Expected F4, but got I4
		//IL_020d: Expected F4, but got I4
		//IL_0149: Expected O, but got I4
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0117: Expected O, but got I8
		//IL_021f: Invalid comparison between F4 and I4
		//IL_01a0: Expected O, but got I
		//IL_0406: Expected O, but got I
		//IL_0263: Invalid comparison between F4 and I4
		//IL_08b2: Expected O, but got I
		//IL_046e: Expected O, but got I
		//IL_02d1: Expected I, but got O
		//IL_02d9: Expected I, but got O
		//IL_02e9: Expected O, but got I
		//IL_097f: Expected O, but got I
		//IL_0369: Expected O, but got I4
		//IL_090c: Expected F4, but got I4
		//IL_0325: Expected O, but got I
		//IL_04d7: Expected O, but got I
		//IL_0376: Expected F4, but got O
		//IL_035b: Expected O, but got I4
		//IL_053e: Expected O, but got I
		//IL_0928: Invalid comparison between F4 and I4
		//IL_093c: Expected I, but got O
		//IL_0598: Expected O, but got I
		//IL_057d: Expected O, but got I4
		//IL_03af: Expected I, but got O
		//IL_09a7: Expected O, but got I
		//IL_03de: Expected I, but got O
		//IL_0602: Expected O, but got I
		//IL_05e7: Expected O, but got I4
		//IL_09cf: Expected O, but got I
		//IL_066c: Expected O, but got I
		//IL_0651: Expected O, but got I4
		//IL_09f7: Expected O, but got I
		//IL_06d6: Expected O, but got I
		//IL_06bb: Expected O, but got I4
		//IL_0a1f: Expected O, but got I
		//IL_0740: Expected O, but got I
		//IL_0725: Expected O, but got I4
		//IL_011c->IL0825: Incompatible stack heights: 1 vs 0
		//IL_03f0->IL094a: Incompatible stack heights: 1 vs 0
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num = GraceTimes + GraceTimes;
		if (!(MaxGrace > num))
		{
			num = MaxGrace;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		nint num2 = (nint)activeCharacter;
		float num3 = activeCharacter.PLuck();
		object obj = UnityEngine.Random.value;
		float num4 = MaxGrace * MaxGrace;
		object obj2 = UnityEngine.Random.value;
		float num5 = MaxGrace * 7f;
		float num6 = num5 * MaxGrace;
		object obj3 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,qword ptr [188A106E0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,qword ptr [188A108F0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,qword ptr [188A10818h]\"");
		object obj4 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj5 = 0;
		float num7 = 1f / MaxGrace;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm8,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm8,qword ptr [188A106E0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm8,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [188A10818h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm8,qword ptr [188A108F0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm8,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj6 = num8 ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj7 = 0 & obj6;
		bool flag = (nint)obj7 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag2 = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			object obj8 = obj5 ^ obj5;
			object obj9 = obj5 & obj8;
			flag = (nint)obj9 < 0;
			flag2 = (nint)obj5 < 0;
			flag3 = obj5 == null;
			activeCharacter = (VampireSurvivors.Objects.Characters.CharacterController)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1046 @ rax_v40 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm1\"");
		bool flag4 = flag2 == flag;
		object obj10 = !flag3;
		object obj11 = flag4 & obj10;
		if (obj11 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm8,xmm0\"");
			bool flag5 = flag2 == flag;
			object obj12 = !flag5;
			object obj13 = obj12 | flag3;
			if (obj13 == null)
			{
				goto IL_015f;
			}
		}
		else
		{
			GameManager core2 = GM.Core;
			float num9 = 0f;
			float num10 = 0f;
			while (true)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters = core2._characters;
				if (!(num10 < (float)characters._size))
				{
					break;
				}
				GameManager core3 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core3._characters;
				bool flag6 = !(num9 < (float)characters2._size);
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[num9];
				if (characterController._characterType != CharacterType.EX_ZIAPPUNTA)
				{
					goto IL_08d6;
				}
				nint num11 = (nint)typeof(CharacterController_EX_Ziappunta);
				nint num12 = (nint)characterController;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1317 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController_EX_Ziappunta>)+130]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1317 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController_EX_Ziappunta>)+130]");
				object obj16;
				if (num13 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1386 @ rax_v130+FFFFFFF8+v1319 @ rax_v116*8]");
					if (0 == (nint)typeof(CharacterController_EX_Ziappunta))
					{
						obj16 = 1;
						goto IL_08f4;
					}
				}
				obj16 = 0;
				goto IL_08f4;
				IL_08f4:
				bool flag7 = obj16 == null;
				float num14 = 0f;
				if (!flag7)
				{
					num14 = (float)characterController;
				}
				bool flag8 = num14 == 0f;
				nint num15 = (nint)typeof(CharacterController_EX_Ziappunta);
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v16 (System.Single)+10]");
					bool flag9 = (nint)0 == 0;
					num15 = (nint)typeof(CharacterController_EX_Ziappunta);
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v16 (System.Single)+42C]");
						_ = (nint)0 + (nint)1;
						num15 = (nint)typeof(CharacterController_EX_Ziappunta);
					}
				}
				goto IL_08d6;
				IL_08d6:
				num9++;
				core2 = GM.Core;
				num10 = num9;
			}
		}
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		goto IL_015f;
		IL_015f:
		list._002Ector();
		float num16 = num * 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		float item = num16 + num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v20+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(item);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		float num18 = num * 100f;
		float item2 = num18 + num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v21+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(item2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v22+18]");
		if (num20 >= 0)
		{
			list.AddWithResize(100f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v45 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1120403456;
		}
		treasure._003Cchances_003Ek__BackingField = list;
		treasure._003Clevel_003Ek__BackingField = 1;
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v25+18]");
		if (num21 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v27+18]");
		if (num22 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v29+18]");
		if (num23 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v31+18]");
		if (num24 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v33+18]");
		if (num25 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ rax_v52 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1;
		}
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		GameManager core4 = GM.Core;
		int num26 = core4._stage.SetTreasureLevelFromChance(treasure);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
		GraceTimes = 0f;
	}

	public Prop_AnimatedExplosive_Tohil()
	{
		//IL_0057: Expected I, but got O
		TreasureChance = 0.01f;
		MaxGrace = 0.66f;
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

	private bool _003COnDestroyed_003Eb__15_0(Weapon x)
	{
		//IL_005b: Expected I4, but got O
		//IL_0039: Expected O, but got I4
		if ((object)x != null)
		{
			WeaponType myWeaponType = MyWeaponType;
			object obj = ((Equipment)x)._equipmentType - myWeaponType;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
