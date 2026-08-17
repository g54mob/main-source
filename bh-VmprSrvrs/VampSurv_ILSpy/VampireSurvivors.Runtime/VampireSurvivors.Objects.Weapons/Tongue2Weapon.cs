using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class Tongue2Weapon : TongueWeapon
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public Tongue2Weapon _003C_003E4__this;

		public EnemyController chosenTarget;

		public float previousScale;

		internal void _003CDoSpecialAttack_003Eb__0()
		{
			//IL_0097: Expected I, but got O
			//IL_00a5: Expected I, but got O
			//IL_00b5: Expected O, but got I
			//IL_0135: Expected O, but got I4
			//IL_00f1: Expected O, but got I
			//IL_0127: Expected O, but got I4
			Tongue2Weapon tongue2Weapon = _003C_003E4__this;
			tongue2Weapon._assassinationSprite.enabled = false;
			Tongue2Weapon tongue2Weapon2 = _003C_003E4__this;
			float2 position = ((Equipment)tongue2Weapon2)._003COwner_003Ek__BackingField.position;
			Transform transform = chosenTarget.transform;
			Vector2 pos = default(Vector2);
			Projectile projectile = tongue2Weapon2.FireOneProjectile(pos, 0, transform);
			bool flag = (object)projectile == null;
			Projectile projectile2 = null;
			object obj3;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(Tongue2Projectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Tongue2Projectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Tongue2Projectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v33+FFFFFFF8+v264 @ rax_v29*8]");
					if (0 == (nint)typeof(Tongue2Projectile))
					{
						obj3 = 1;
						goto IL_01c0;
					}
				}
				obj3 = 0;
				goto IL_01c0;
			}
			goto IL_01e7;
			IL_01e7:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				_ = chosenTarget;
				_ = 1;
				_003C_003E4__this.Assassinate(chosenTarget, previousScale);
			}
			return;
			IL_01c0:
			bool flag2 = obj3 == null;
			projectile2 = null;
			if (!flag2)
			{
				projectile2 = projectile;
			}
			goto IL_01e7;
		}
	}

	private SpriteRenderer _assassinationSprite;

	private SpriteAnimation _assassinationAnim;

	private Timer _specialAttackTimer;

	private float _lastSpecialDelay = 10000f;

	private float _specialDelay = 10000f;

	protected SfxType[] s_sounds;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ReportSlash0000", "vfx");
		_assassinationSprite.sprite = sprite;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_038f: Expected O, but got I4
		//IL_045d->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_01be->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_02f8->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_0340->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_037d->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_039e->IL03a3: Incompatible stack heights: 1 vs 0
		((Weapon)this).InitWeapon(characterController, weaponType);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							float num = renderer2.height * 0.25f;
							float num2 = renderer.width * 0.25f;
							if (num2 > num)
							{
								num2 = num;
							}
							base._baseRange = num2;
							if ((object)_assassinationSprite != null)
							{
								_assassinationSprite.enabled = false;
								if ((object)_assassinationSprite != null)
								{
									Transform transform = _assassinationSprite.transform;
									if ((object)transform != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v21 (UnityEngine.Transform)+10]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v21 (UnityEngine.Transform)+10]");
										Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
										if ((object)_assassinationSprite != null)
										{
											((UnityEngine.Object)_assassinationSprite).SetName("_assassinationSprite");
											List<Sprite> list = new List<Sprite>();
											Sprite sprite = SpriteManager.GetSprite("ReportSlash0000", "vfx");
											if (list != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite2 = SpriteManager.GetSprite("ReportSlash0001", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite3 = SpriteManager.GetSprite("ReportSlash0002", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite4 = SpriteManager.GetSprite("ReportSlash0003", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite5 = SpriteManager.GetSprite("ReportSlash0004", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite6 = SpriteManager.GetSprite("ReportSlash0005", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite7 = SpriteManager.GetSprite("ReportSlash0006", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												Sprite sprite8 = SpriteManager.GetSprite("ReportSlash0007", "vfx");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
												if ((object)_assassinationAnim != null)
												{
													bool shouldLoop = default(bool);
													bool startRandomFrame = default(bool);
													Action onComplete = default(Action);
													bool autoSetAnimation = default(bool);
													_assassinationAnim.AddAnimation("Slash", list, 16, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
													if ((object)_assassinationAnim != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1873EDE70");
														Action callback = OnSlashAnimComplete;
														WeaponType weaponType2 = default(WeaponType);
														if (weaponType2 != WeaponType.VOID)
														{
															((FrameAnimationData)weaponType2).AddCompletionCallback(callback);
															Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 541 Invalid \"Jump target not found in method: 0x1873D9320\"");
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
		}
		throw new NullReferenceException();
	}

	private void OnSlashAnimComplete()
	{
		_assassinationSprite.enabled = false;
	}

	private float GetSpecialDelay()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal(0.35f);
		object obj = default(object);
		return (float)obj * _specialDelay;
	}

	private void ResetSpecialAttackTimer()
	{
		if (_specialAttackTimer != null)
		{
			_specialAttackTimer.Cancel();
		}
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal(0.35f);
		object obj = default(object);
		float num2 = (_lastSpecialDelay = (float)obj * _specialDelay);
		Action onComplete = DoSpecialAttack;
		float duration = num2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer specialAttackTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_specialAttackTimer = specialAttackTimer;
	}

	private EnemyController GetMostDistantStrongestEnemy()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0239: Expected O, but got I4
		//IL_0242: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (UnityEngine.Bounds)+10]");
		object obj2 = default(object);
		object obj = obj2 - 0;
		object obj3 = (object)bounds.m_Center - obj2;
		float num = (float)obj + 1f;
		float num2 = (float)obj3 + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (UnityEngine.Bounds)+10]");
		object obj4 = obj2 + 0;
		object obj5 = (object)bounds.m_Center + obj2;
		float num3 = (float)obj4 - num;
		float num4 = (float)obj5 - num2;
		float num5 = num3 * 0.5f;
		float num6 = num4 * 0.5f;
		float num7 = num + num5;
		float num8 = num2 + num6;
		float num9 = num7 + num5;
		float num10 = num8 + num6;
		float num11 = num9 - 1f;
		float num12 = num10 - 1f;
		float num13 = num7 - num5;
		float num14 = num8 - num6;
		float num15 = num11 - num13;
		float num16 = num12 - num14;
		float num17 = num15 * 0.5f;
		float num18 = num16 * 0.5f;
		float num19 = num17 + num13;
		float num20 = num14 + num18;
		float x = num20 - num18;
		float y = num19 - num17;
		float width = num18 + num18;
		if ((object)GM.Core != null && (object)ArcadePhysics.s_instance != null)
		{
			float height = default(float);
			bool includeDynamic = default(bool);
			bool includeStatic = default(bool);
			Group specificGroup = default(Group);
			List<BaseBody> list = ArcadePhysics.s_instance.OverlapRect(x, y, width, height, includeDynamic, includeStatic, specificGroup);
			if (list != null)
			{
				EnemyController result = null;
				List<BaseBody> list2 = list;
				object obj6 = 0;
				object obj7 = 0;
				List<BaseBody>.Enumerator enumerator = default(List<BaseBody>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj8 = 0;
				}
				return result;
			}
		}
		throw new NullReferenceException();
	}

	private void DoSpecialAttack()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0060: Invalid comparison between O and F4
		//IL_027a: Expected F4, but got I4
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_0409: Expected I, but got O
		//IL_048e: Expected O, but got I4
		//IL_0820: Expected O, but got I
		//IL_087a: Expected O, but got I
		//IL_05ea: Expected O, but got I
		//IL_0609: Expected O, but got I4
		//IL_0611: Expected I4, but got O
		//IL_06f1: Expected O, but got I
		//IL_071a: Expected O, but got I4
		//IL_0722: Expected I4, but got O
		//IL_079e: Expected I4, but got F4
		//IL_079e: Expected O, but got F4
		//IL_072b->IL0841: Incompatible stack heights: 1 vs 2
		//IL_0865->IL07a8: Incompatible stack heights: 2 vs 0
		//IL_07a7->IL07a7: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals28 = new _003C_003Ec__DisplayClass12_0();
		float? num2 = default(float?);
		float num3 = default(float);
		float num4 = default(float);
		bool flag2 = default(bool);
		if (CS_0024_003C_003E8__locals28 != null)
		{
			CS_0024_003C_003E8__locals28._003C_003E4__this = this;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal(0.35f);
				object obj2 = default(object);
				object obj = obj2 * _specialDelay;
				bool flag = obj == (object)_lastSpecialDelay;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873D9B3Eh\"");
				if (!flag)
				{
					ResetSpecialAttackTimer();
				}
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					if (characterController._isDead || ((Equipment)this)._003COwner_003Ek__BackingField.IsDisconnectedFromOnlinePlay)
					{
						return;
					}
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
						if ((object)characterController2._weaponsManager != null)
						{
							if (weaponsManager._maxActiveCount == 0)
							{
								return;
							}
							GameManager core = GM.Core;
							if ((object)GM.Core != null && (object)core._stage != null)
							{
								if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
								{
									return;
								}
								EnemyController mostDistantStrongestEnemy = GetMostDistantStrongestEnemy();
								CS_0024_003C_003E8__locals28.chosenTarget = mostDistantStrongestEnemy;
								TweenConfig chosenTarget = (TweenConfig)(object)CS_0024_003C_003E8__locals28.chosenTarget;
								if ((object)CS_0024_003C_003E8__locals28.chosenTarget == null || chosenTarget.targets == null)
								{
									return;
								}
								PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_ImpostorDiscovered, 100f, 10, 0f, num2, num3, num4, flag2, 1f);
								if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
								{
									bool flag3 = CS_0024_003C_003E8__locals28.chosenTarget.Freeze_WithoutTint(1000f, 100f);
									if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
									{
										float scale = CS_0024_003C_003E8__locals28.chosenTarget.scale;
										EnemyController chosenTarget2 = CS_0024_003C_003E8__locals28.chosenTarget;
										CS_0024_003C_003E8__locals28.previousScale = scale;
										if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
										{
											bool flag4 = 0 < 1065353216;
											bool flag5 = !flag4;
											object obj3 = (_003F?)chosenTarget2._003CResRosary_003Ek__BackingField & flag5;
											if (obj3 == null)
											{
												goto IL_04aa;
											}
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[1];
											if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
											{
												Transform transform = CS_0024_003C_003E8__locals28.chosenTarget.transform;
												if (array != null)
												{
													if ((object)transform != null)
													{
														nint num5 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj4 = default(object);
														if (obj4 == null)
														{
															ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
															throw ex;
														}
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														tweenConfig.targets = array;
														tweenConfig.duration = 350f;
														tweenConfig.ease = Ease.InBounce;
														tweenConfig.scale = (float?)(object)1;
														MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
														goto IL_04aa;
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
		goto IL_07a8;
		IL_07a8:
		throw new NullReferenceException();
		IL_0841:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1424 @ rax_v49 (should have been resolved before IL gen)");
		if ((object)_assassinationAnim != null)
		{
			goto IL_0742;
		}
		goto IL_07a8;
		IL_04aa:
		bool useRealTime;
		if ((object)_assassinationSprite != null)
		{
			_assassinationSprite.enabled = true;
			EnemyController chosenTarget3 = CS_0024_003C_003E8__locals28.chosenTarget;
			if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
			{
				bool num6;
				bool num7;
				if (chosenTarget3.body == null)
				{
					if ((object)_assassinationSprite != null)
					{
						Transform transform2 = _assassinationSprite.transform;
						if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
						{
							Transform transform3 = CS_0024_003C_003E8__locals28.chosenTarget.transform;
							if ((object)transform3 != null)
							{
								Vector3 position = transform3.position;
								bool flag6 = (object)transform2 == null;
								num6 = flag6;
								float x = position.x;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v64 (UnityEngine.Transform)+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v64 (UnityEngine.Transform)+10]");
								bool flag7 = (nint)0 == 0;
								num7 = flag7;
								object obj6 = 0;
								float x2 = position.x;
								float num8 = 1000f;
								object obj7 = 0;
								useRealTime = (byte)(int)num2 != 0;
								goto IL_0841;
							}
						}
					}
				}
				else if ((object)_assassinationSprite != null)
				{
					Transform transform4 = _assassinationSprite.transform;
					Component chosenTarget4 = CS_0024_003C_003E8__locals28.chosenTarget;
					if ((object)CS_0024_003C_003E8__locals28.chosenTarget != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v57 (UnityEngine.Component)+28]");
						if ((nint)0 != 0)
						{
							Transform transform5 = CS_0024_003C_003E8__locals28.chosenTarget.transform;
							if ((object)transform5 != null)
							{
								float num8 = transform5.position.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1340 @ rax_v56 (UnityEngine.Transform)+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1340 @ rax_v56 (UnityEngine.Transform)+10]");
								bool flag8 = (nint)0 == 0;
								num6 = flag8;
								object obj6 = 0;
								bool flag9 = (nint)0 != 0;
								float num9 = default(float);
								float x2 = num9;
								float x = num9;
								object obj7 = 0;
								useRealTime = (byte)(int)num2 != 0;
								if (!flag9)
								{
									bool flag10 = (nint)0 == 0;
									num7 = flag10;
									goto IL_0742;
								}
								goto IL_0841;
							}
						}
					}
				}
			}
		}
		goto IL_07a8;
		IL_0742:
		_assassinationAnim.Play("Slash", 16);
		Action onComplete = delegate
		{
			//IL_0097: Expected I, but got O
			//IL_00a5: Expected I, but got O
			//IL_00b5: Expected O, but got I
			//IL_0135: Expected O, but got I4
			//IL_00f1: Expected O, but got I
			//IL_0127: Expected O, but got I4
			Tongue2Weapon tongue2Weapon = CS_0024_003C_003E8__locals28._003C_003E4__this;
			tongue2Weapon._assassinationSprite.enabled = false;
			Tongue2Weapon tongue2Weapon2 = CS_0024_003C_003E8__locals28._003C_003E4__this;
			float2 position2 = ((Equipment)tongue2Weapon2)._003COwner_003Ek__BackingField.position;
			Transform target = CS_0024_003C_003E8__locals28.chosenTarget.transform;
			Vector2 pos = default(Vector2);
			Projectile projectile = tongue2Weapon2.FireOneProjectile(pos, 0, target);
			bool flag11 = (object)projectile == null;
			Projectile projectile2 = null;
			object obj10;
			if (!flag11)
			{
				nint num10 = (nint)projectile;
				nint num11 = (nint)typeof(Tongue2Projectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Tongue2Projectile>)+130]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Tongue2Projectile>)+130]");
				if (num12 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v33+FFFFFFF8+v264 @ rax_v29*8]");
					if (0 == (nint)typeof(Tongue2Projectile))
					{
						obj10 = 1;
						goto IL_01c0;
					}
				}
				obj10 = 0;
				goto IL_01c0;
			}
			goto IL_01e7;
			IL_01e7:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				_ = CS_0024_003C_003E8__locals28.chosenTarget;
				_ = 1;
				CS_0024_003C_003E8__locals28._003C_003E4__this.Assassinate(CS_0024_003C_003E8__locals28.chosenTarget, CS_0024_003C_003E8__locals28.previousScale);
			}
			return;
			IL_01c0:
			bool flag12 = obj10 == null;
			projectile2 = null;
			if (!flag12)
			{
				projectile2 = projectile;
			}
			goto IL_01e7;
		};
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, (MonoBehaviour)num3, (int)num4, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
	}

	protected unsafe void Assassinate(EnemyController target, float previousTargetScale)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00c3: Expected O, but got I4
		//IL_00f7: Expected I, but got O
		//IL_0114: Expected O, but got I
		//IL_0240: Expected F4, but got I4
		//IL_0389: Expected I, but got O
		//IL_03a8: Expected O, but got I
		//IL_0345: Expected O, but got I4
		//IL_028e: Expected F4, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_0180: Expected I, but got O
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0 || target.body == null || target._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		object obj = default(object);
		bool flag = 0 < (nint)obj;
		bool flag2 = !flag;
		object obj2 = (_003F?)target._003CResRosary_003Ek__BackingField & flag2;
		bool flag3 = obj2 == null;
		object obj3 = !flag3;
		if (obj3 == null)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float num = currentWeaponData._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
			bool flag4 = !(10f < num);
			float num2 = 10f;
			if (!flag4)
			{
				num2 = num;
			}
			float num3 = PPower();
			nint num4 = (nint)this;
			float num5 = num5 * num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v53 (Il2CppClass<VampireSurvivors.Objects.Weapons.Tongue2Weapon>)+520]");
			object obj4 = 0;
			base.DealDamage(target, num5);
			float num6 = num5;
		}
		else
		{
			nint num7 = (nint)this;
			float num6 = target._maxHp;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.Tongue2Weapon>)+520]");
			object obj4 = 0;
			base.DealDamage(target, target._maxHp);
		}
		if (!target._003CIsDead_003Ek__BackingField)
		{
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = target.transform;
			if ((object)transform != null)
			{
				nint num8 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 350f;
			tweenConfig.ease = Ease.OutBounce;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
		target.ResumeFromTimeStop();
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_ImpostorKill, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		SfxType[] array2 = s_sounds;
		object obj6 = UnityEngine.Random.RandomRangeInt(0, array2.Length);
		float num9 = UnityEngine.Random.Range(0.75f, 1f);
		float num10 = UnityEngine.Random.Range(0.9f, 1.1f);
		SfxType[] array3 = s_sounds;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array3[obj6]), 10f, 5, 0f, volume, rate, detune, loop, 1f);
	}

	protected override bool CanLickBackwards()
	{
		return true;
	}

	protected override bool SupportCounterWeapon()
	{
		return true;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_00e8: Expected O, but got I
		//IL_0149: Invalid comparison between F4 and I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if (!component2.HasAlreadyHitObject(component))
			{
				List<float> critChancesArray = _critChancesArray;
				int critIndex = _critIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
				int num = (int)((nint)critIndex % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)num < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rcx_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					int critIndex2 = _critIndex + 1;
					_critIndex = critIndex2;
					WeaponData currentWeaponData = _currentWeaponData;
					float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					object obj2 = default(object);
					float num3 = (float)obj2 * currentWeaponData._003CcritChance_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v14+20+v79 @ rdx_v12 (System.Int32)*4]");
					float num4;
					if (num3 > 0f)
					{
						WeaponData currentWeaponData2 = _currentWeaponData;
						num4 = currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
					}
					else
					{
						num4 = 1f;
					}
					float num5 = PPower();
					float damage = num3 * num4;
					base.DealDamage(component, damage);
					return true;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			}
		}
		return false;
	}

	public override void CheckArcanas()
	{
		//IL_0161: Expected I, but got O
		//IL_016f: Expected I, but got O
		//IL_017f: Expected O, but got I
		//IL_01ff: Expected O, but got I4
		//IL_01bb: Expected O, but got I
		//IL_01f1: Expected O, but got I4
		//IL_027d: Expected I, but got O
		Weapon weapon;
		UnityEngine.Object obj2;
		object obj5;
		if (SupportCounterWeapon())
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj > -1 && base._counterWeaponType != WeaponType.VOID)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				WeaponType counterWeaponType = base._counterWeaponType;
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(counterWeaponType, searchHidden: true);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					return;
				}
				GameManager core2 = GM.Core;
				WeaponType counterWeaponType2 = base._counterWeaponType;
				bool allowDuplicates = default(bool);
				weapon = core2._weaponsFacade.AddHiddenWeapon(counterWeaponType2, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
				bool flag = (object)weapon == null;
				obj2 = null;
				if (!flag)
				{
					nint num = (nint)weapon;
					nint num2 = (nint)typeof(TongueWeapon_Counter);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon_Counter>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon_Counter>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v42+FFFFFFF8+v479 @ rax_v38*8]");
						if (0 == (nint)typeof(TongueWeapon_Counter))
						{
							obj5 = 1;
							goto IL_02f1;
						}
					}
					obj5 = 0;
					goto IL_02f1;
				}
				goto IL_0211;
			}
		}
		goto IL_029b;
		IL_02f1:
		bool flag2 = obj5 == null;
		obj2 = null;
		if (!flag2)
		{
			obj2 = weapon;
		}
		goto IL_0211;
		IL_029b:
		base.CheckArcanas();
		return;
		IL_0211:
		if ((bool)obj2)
		{
			_counterWeapon = (Weapon)obj2;
			Weapon counterWeapon = _counterWeapon;
			while (((Equipment)counterWeapon)._003CLevel_003Ek__BackingField < 8)
			{
				nint num4 = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v582 @ rax_v35 (Il2CppClass<UnityEngine.Object>)+3C8] (should have been resolved before IL gen)");
				counterWeapon = _counterWeapon;
			}
		}
		goto IL_029b;
	}

	public Tongue2Weapon()
	{
		SfxType[] array = new SfxType[2];
		_ = 163;
		_ = 164;
		s_sounds = array;
		base._002Ector();
	}
}
