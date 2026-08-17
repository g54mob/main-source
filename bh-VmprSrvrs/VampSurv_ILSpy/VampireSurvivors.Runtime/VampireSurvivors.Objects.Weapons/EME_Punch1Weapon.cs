using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Punch1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Vector2 startPos;

		public EME_Punch1Weapon _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public int localIndex;

		public Vector3 targetPos;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			//IL_024f: Expected O, but got I4
			//IL_00fb: Expected I, but got O
			//IL_0109: Expected I, but got O
			//IL_0119: Expected O, but got I
			//IL_0199: Expected O, but got I4
			//IL_0155: Expected O, but got I
			//IL_018b: Expected O, but got I4
			//IL_01e9: Expected O, but got Ref
			//IL_0084->IL01ef: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL01ef: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass14_0 obj = CS_0024_003C_003E8__locals1;
			EME_PunchProjectile_Raksha eME_PunchProjectile_Raksha;
			EME_PunchProjectile_Raksha eME_PunchProjectile_Raksha2;
			object obj6;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass14_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						eME_PunchProjectile_Raksha = (EME_PunchProjectile_Raksha)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex);
						if ((object)eME_PunchProjectile_Raksha == null)
						{
							eME_PunchProjectile_Raksha2 = null;
							goto IL_0298;
						}
						nint num = (nint)eME_PunchProjectile_Raksha;
						nint num2 = (nint)typeof(EME_PunchProjectile_Raksha);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
							if (0 == (nint)typeof(EME_PunchProjectile_Raksha))
							{
								obj6 = 1;
								goto IL_0271;
							}
						}
						obj6 = 0;
						goto IL_0271;
					}
				}
			}
			throw new NullReferenceException();
			IL_0298:
			if ((object)eME_PunchProjectile_Raksha2 != null && ((UnityEngine.Object)eME_PunchProjectile_Raksha2).m_CachedPtr != (IntPtr)0)
			{
				object obj7 = default(object);
				eME_PunchProjectile_Raksha2.SetTargetPosition((Vector3)(&obj7));
			}
			return;
			IL_0271:
			bool flag2 = obj6 == null;
			eME_PunchProjectile_Raksha2 = null;
			if (!flag2)
			{
				eME_PunchProjectile_Raksha2 = eME_PunchProjectile_Raksha;
			}
			goto IL_0298;
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public Vector3 targetPos;

		public int localIndex;

		public EME_Punch1Weapon _003C_003E4__this;

		internal void _003CFire_FireGlimmerProjectile_003Eb__1()
		{
			//IL_00cb: Expected O, but got I4
			//IL_006f->IL0094: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private const float RAKSHA_REPEAT_INTERVAL = 500f;

	private bool _flipVisuals;

	private float _screenPerimeter = 1f;

	private ParticleSystem guayimPunchingVFX;

	private PhaserSprite _guayimPlayerSpriteRenderer;

	private PhaserSprite _guayimBackgroundFader;

	private float _guayimExecutionDelayDefault = 5000f;

	private float _guayimExecutionDelta;

	private float _guayimExecutionDelay = 5000f;

	private bool _isGuayimRunning;

	private bool _playSoundsDuringUpdate = true;

	private float _detuneValue;

	public SfxType HitSound = SfxType.Sfx_eme_Punch1;

	private float _guayimFiringDelta;

	private float _guayimFiringDelay = 50f;

	private bool _updateGuayim;

	private MultiTargetTween _guayimFadeTween;

	protected override int EvolutionLevel => 6;

	protected override int _comboIndex1 => 6;

	protected override int _comboIndex2 => 12;

	protected override int _comboIndex3 => 18;

	protected override int ComboIndexFinal => base.ComboIndex1;

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (_updateGuayim)
		{
			GuayimUpdate();
		}
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		Projectile projectile = base.FireOneProjectile(pos, index, target);
		if ((object)projectile == null)
		{
			goto IL_00da;
		}
		nint num = (nint)typeof(EME_PunchProjectile);
		nint num2 = (nint)projectile;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v10+FFFFFFF8+v64 @ rcx_v4*8]");
			if (0 == (nint)typeof(EME_PunchProjectile))
			{
				obj3 = 1;
				goto IL_012a;
			}
		}
		obj3 = 0;
		goto IL_012a;
		IL_00da:
		bool flipVisuals = !_flipVisuals;
		_flipVisuals = flipVisuals;
		return;
		IL_012a:
		bool flag = obj3 == null;
		EME_PunchProjectile eME_PunchProjectile = null;
		if (!flag)
		{
			eME_PunchProjectile = (EME_PunchProjectile)projectile;
		}
		if ((object)eME_PunchProjectile != null)
		{
			eME_PunchProjectile.flipVerticalVFX = _flipVisuals;
			eME_PunchProjectile.PlayPunch();
		}
		goto IL_00da;
	}

	protected unsafe override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00f8: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0175: Expected I, but got O
		//IL_0185: Expected O, but got I
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_02cd: Invalid comparison between F4 and I4
		//IL_071f: Expected I, but got O
		//IL_072f: Expected O, but got I
		//IL_0dfc: Invalid comparison between F4 and I4
		//IL_07a5: Expected O, but got I4
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected O, but got Unknown
		//IL_0834: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Expected O, but got Unknown
		//IL_08f1: Expected O, but got I
		//IL_097b: Invalid comparison between F4 and I4
		//IL_0bab: Expected I, but got O
		//IL_0bcf: Invalid comparison between F4 and I4
		//IL_0bdd: Expected O, but got I4
		//IL_0bed: Expected F4, but got I4
		//IL_09be: Expected O, but got I4
		//IL_09f9: Expected I, but got O
		//IL_0a09: Expected O, but got I
		//IL_0a89: Expected O, but got I4
		//IL_09d4: Expected I, but got O
		//IL_0a45: Expected O, but got I
		//IL_0a96: Expected O, but got I4
		//IL_0a7b: Expected O, but got I4
		//IL_0af9: Expected O, but got Ref
		//IL_0b13: Expected I, but got O
		//IL_0b1b: Expected O, but got Ref
		//IL_0ccc->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0cf3->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_048f->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_04ac->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_04d7->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0d1a->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_04fe->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_051c->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0d41->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0543->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_056e->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0d68->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0595->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_05b3->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0d8f->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_05db->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0613->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0640->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_066f->IL0c00: Incompatible stack heights: 1 vs 0
		//IL_0dde->IL0c00: Incompatible stack heights: 2 vs 0
		//IL_06a7->IL0c00: Incompatible stack heights: 2 vs 0
		//IL_06d5->IL0c00: Incompatible stack heights: 2 vs 0
		//IL_0e0e->IL00bb: Incompatible stack heights: 2 vs 0
		//IL_0ead->IL0c00: Incompatible stack heights: 2 vs 0
		//IL_0853->IL0c00: Incompatible stack heights: 2 vs 0
		//IL_087f->IL0c00: Incompatible stack heights: 2 vs 0
		//IL_0911->IL0c00: Incompatible stack heights: 4 vs 0
		//IL_08c5->IL0c00: Incompatible stack heights: 3 vs 0
		//IL_09ad->IL0c00: Incompatible stack heights: 5 vs 0
		//IL_0bf6->IL0e8c: Incompatible stack heights: 5 vs 2
		//IL_0c00->IL00bb: Incompatible stack heights: 5 vs 0
		//IL_0ae6->IL0c00: Incompatible stack heights: 5 vs 0
		object obj = default(object);
		float2 float5 = default(float2);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (obj != _glimmer1Pool)
		{
			object obj2 = default(object);
			if (obj != _glimmer2Pool)
			{
				if (obj == _glimmer3Pool)
				{
					_updateGuayim = true;
					_detuneValue = 1100f;
					_guayimFiringDelta = 0f;
					_guayimExecutionDelta = 0f;
					_isGuayimRunning = true;
					float num = base.PDuration();
					float num2 = (float)obj2 * _guayimExecutionDelayDefault;
					float guayimExecutionDelay = num2 * 0.001f;
					_guayimExecutionDelay = guayimExecutionDelay;
					DisplayGuayimVFX();
				}
				return;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
				object obj3 = (flipX ? 1 : 0) ^ 1;
				object obj4 = obj3 * 2;
				object obj5 = obj4 - 1;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						nint num3 = (nint)this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1248 @ rax_v132 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Punch1Weapon>)+410]");
						Action action = (Action)0;
						float num4 = base.PAmount();
						float num5 = (float)obj2 * 50f;
						float num6 = 500f - num5;
						bool flag = num6 > 250f;
						float num7 = 250f;
						if (!flag)
						{
							num7 = num6;
						}
						object obj6 = obj2 + obj2;
						if ((nint)obj6 <= 0)
						{
							return;
						}
						object obj7 = obj2 + obj2;
						bool flag2 = false;
						while (true)
						{
							_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass14_2();
							if (CS_0024_003C_003E8__locals17 == null)
							{
								break;
							}
							CS_0024_003C_003E8__locals17._003C_003E4__this = this;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
							CS_0024_003C_003E8__locals17.localIndex = (flag2 ? 1 : 0);
							object obj8 = (object)action >> 1;
							object obj9 = obj8 >> 31;
							object obj10 = obj8 + obj9;
							object obj11 = obj10 * 4;
							object obj12 = obj10 + obj11;
							object obj13 = flag2 - obj12;
							float num8 = (float)obj13 * 0.64f;
							float num9 = num8 * (float)obj5;
							float num10 = num9 + (float)position;
							CS_0024_003C_003E8__locals17.targetPos = (Vector3)float5;
							_ = 1f;
							float num11 = (float)(flag2 ? 1 : 0) * num7;
							if (!(num11 > 0f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
								action = (Action)(object)this;
							}
							else
							{
								Action action2 = delegate
								{
									//IL_00cb: Expected O, but got I4
									//IL_006f->IL0094: Incompatible stack heights: 1 vs 0
									if ((object)CS_0024_003C_003E8__locals17._003C_003E4__this != null)
									{
										GameObject gameObject = CS_0024_003C_003E8__locals17._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag17 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj27 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj27 == null)
											{
												return;
											}
											if ((object)CS_0024_003C_003E8__locals17._003C_003E4__this != null)
											{
												Vector2 pos2 = default(Vector2);
												Projectile projectile = CS_0024_003C_003E8__locals17._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals17.localIndex);
												return;
											}
										}
									}
									throw new NullReferenceException();
								};
								float num12 = (float)(flag2 ? 1 : 0) * num7;
								float duration = num12 * 0.001f;
								Timer lastShotTimer = Timers.Register(duration, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_lastShotTimer = lastShotTimer;
								action = action2;
							}
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							if ((nint)obj7 <= (flag2 ? 1 : 0))
							{
								return;
							}
						}
					}
				}
			}
		}
		else
		{
			_003C_003Ec__DisplayClass14_0 obj14 = new _003C_003Ec__DisplayClass14_0();
			if (obj14 != null)
			{
				obj14._003C_003E4__this = this;
				ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Vector3 ret;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)(&ret));
							List<float2> list = new List<float2>();
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene._renderer != null && list != null)
								{
									list.Add(float5);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
										{
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
											{
												list.Add(float5);
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene4 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null && s_scene4._renderer != null && (object)GM.Core != null)
													{
														PhaserScene s_scene5 = ArcadePhysics.s_scene;
														if (ArcadePhysics.s_scene != null && s_scene5._renderer != null)
														{
															list.Add(float5);
															ArcadeSprite arcadeSprite2 = ((Equipment)this)._003COwner_003Ek__BackingField;
															if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
															{
																((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
																if ((object)arcadeSprite2._spriteRenderer != null)
																{
																	Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
																	if ((object)sprite2 != null)
																	{
																		bool flag4 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
																		Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Rect*)(&ret));
																		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
																		{
																			bool flipX2 = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
																			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
																			{
																				float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
																				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
																				{
																					float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
																					obj14.startPos = position3;
																					object obj15 = default(object);
																					float num13 = (float)obj15 * 0.0065f;
																					object obj16 = default(object);
																					float num14 = num13 + (float)obj16;
																					nint num15 = (nint)this;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2075 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Punch1Weapon>)+410]");
																					Action action3 = (Action)0;
																					float num16 = base.PAmount();
																					float num17 = (float)position3 * 50f;
																					float num18 = 500f - num17;
																					bool flag5 = num18 > 250f;
																					float num19 = 250f;
																					if (!flag5)
																					{
																						num19 = num18;
																					}
																					float num20 = (float)position3 * 3f;
																					if (!(num20 > 0f))
																					{
																						return;
																					}
																					float num21 = (float)position3 * 3f;
																					ret = (Vector3)0;
																					nint num22 = 0;
																					bool flag6 = false;
																					bool flag7 = false;
																					object obj23 = default(object);
																					bool flag11 = default(bool);
																					while (true)
																					{
																						_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass14_1();
																						if (CS_0024_003C_003E8__locals22 == null)
																						{
																							break;
																						}
																						CS_0024_003C_003E8__locals22.CS_0024_003C_003E8__locals1 = obj14;
																						CS_0024_003C_003E8__locals22.localIndex = (flag7 ? 1 : 0);
																						ArcadeSprite arcadeSprite3 = ((Equipment)this)._003COwner_003Ek__BackingField;
																						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r12d\"");
																						object obj17 = (object)action3 >> 31;
																						object obj18 = (object)action3 + obj17;
																						object obj19 = obj18 * 2;
																						object obj20 = obj18 + obj19;
																						object obj21 = flag7 - obj20;
																						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
																						{
																							break;
																						}
																						Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
																						if ((object)cachedTrans == null)
																						{
																							break;
																						}
																						bool flag8 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
																						float2 ret2;
																						Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret2));
																						if (arcadeSprite3.body != null)
																						{
																							BaseBody body = arcadeSprite3.body;
																							ArcadeTransform arcadeTransform = body._transform;
																							if (body._transform == null)
																							{
																								break;
																							}
																							arcadeTransform.position = ret2;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1552 @ rax_v32 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
																						bool flag9 = (nint)obj21 >= 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1552 @ rax_v32 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																						object obj22 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1552 @ rax_v32 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
																						if ((nint)0 == 0)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ r8_v20+18]");
																						bool flag10 = (nint)obj21 >= 0;
																						float num23 = (float)obj23;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ r8_v20+24+v486 @ rdi_v14*8]");
																						num18 = num23 + 0f;
																						CS_0024_003C_003E8__locals22.targetPos = (Vector3)float5;
																						_ = 1f;
																						float num24 = (float)(flag6 ? 1 : 0) * num19;
																						Sprite sprite3;
																						object obj26;
																						if (!(num24 > 0f))
																						{
																							if (CS_0024_003C_003E8__locals22.CS_0024_003C_003E8__locals1 == null)
																							{
																								break;
																							}
																							((List<float2>)58).Add((float2)this);
																							if (!flag11)
																							{
																								num22 = (nint)float5;
																								sprite3 = null;
																								goto IL_0a9b;
																							}
																							num22 = (((bool*)(flag11 ? 1 : 0))->m_value ? 1 : 0);
																							nint num25 = (nint)typeof(EME_PunchProjectile_Raksha);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
																							object obj24 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v19 (Il2CppMethodInfo)+130]");
																							nint num26 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
																							if (num26 >= 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v19 (Il2CppMethodInfo)+C8]");
																								object obj25 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2357 @ rax_v104+FFFFFFF8+v2301 @ rax_v100*8]");
																								if (0 == (nint)typeof(EME_PunchProjectile_Raksha))
																								{
																									obj26 = 1;
																									goto IL_0e6a;
																								}
																							}
																							obj26 = 0;
																							goto IL_0e6a;
																						}
																						Action action4 = delegate
																						{
																							//IL_024f: Expected O, but got I4
																							//IL_00fb: Expected I, but got O
																							//IL_0109: Expected I, but got O
																							//IL_0119: Expected O, but got I
																							//IL_0199: Expected O, but got I4
																							//IL_0155: Expected O, but got I
																							//IL_018b: Expected O, but got I4
																							//IL_01e9: Expected O, but got Ref
																							//IL_0084->IL01ef: Incompatible stack heights: 1 vs 0
																							//IL_00a6->IL01ef: Incompatible stack heights: 1 vs 0
																							_003C_003Ec__DisplayClass14_0 obj27 = CS_0024_003C_003E8__locals22.CS_0024_003C_003E8__locals1;
																							EME_PunchProjectile_Raksha eME_PunchProjectile_Raksha;
																							object obj32;
																							EME_PunchProjectile_Raksha eME_PunchProjectile_Raksha2;
																							if (CS_0024_003C_003E8__locals22.CS_0024_003C_003E8__locals1 != null && (object)obj27._003C_003E4__this != null)
																							{
																								GameObject gameObject = obj27._003C_003E4__this.gameObject;
																								if ((object)gameObject != null)
																								{
																									bool flag17 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
																									object obj28 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
																									if (obj28 == null)
																									{
																										return;
																									}
																									_003C_003Ec__DisplayClass14_0 obj29 = CS_0024_003C_003E8__locals22.CS_0024_003C_003E8__locals1;
																									if (CS_0024_003C_003E8__locals22.CS_0024_003C_003E8__locals1 != null && (object)obj29._003C_003E4__this != null)
																									{
																										Vector2 pos2 = default(Vector2);
																										eME_PunchProjectile_Raksha = (EME_PunchProjectile_Raksha)obj29._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals22.localIndex);
																										if ((object)eME_PunchProjectile_Raksha != null)
																										{
																											nint num28 = (nint)eME_PunchProjectile_Raksha;
																											nint num29 = (nint)typeof(EME_PunchProjectile_Raksha);
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
																											object obj30 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
																											nint num30 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+130]");
																											if (num30 >= 0)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Raksha>)+C8]");
																												object obj31 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
																												if (0 == (nint)typeof(EME_PunchProjectile_Raksha))
																												{
																													obj32 = 1;
																													goto IL_0271;
																												}
																											}
																											obj32 = 0;
																											goto IL_0271;
																										}
																										eME_PunchProjectile_Raksha2 = null;
																										goto IL_0298;
																									}
																								}
																							}
																							throw new NullReferenceException();
																							IL_0298:
																							if ((object)eME_PunchProjectile_Raksha2 != null && ((UnityEngine.Object)eME_PunchProjectile_Raksha2).m_CachedPtr != (IntPtr)0)
																							{
																								object obj33 = default(object);
																								eME_PunchProjectile_Raksha2.SetTargetPosition((Vector3)(&obj33));
																							}
																							return;
																							IL_0271:
																							bool flag18 = obj32 == null;
																							eME_PunchProjectile_Raksha2 = null;
																							if (!flag18)
																							{
																								eME_PunchProjectile_Raksha2 = eME_PunchProjectile_Raksha;
																							}
																							goto IL_0298;
																						};
																						float num27 = (float)CS_0024_003C_003E8__locals22.localIndex * num19;
																						float duration2 = num27 * 0.001f;
																						Timer lastShotTimer2 = Timers.Register(duration2, action4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																						_lastShotTimer = lastShotTimer2;
																						bool flag12 = false;
																						num22 = unchecked((nint)null);
																						action3 = action4;
																						goto IL_0bb9;
																						IL_0e6a:
																						bool flag13 = obj26 == null;
																						sprite3 = null;
																						if (!flag13)
																						{
																							sprite3 = (Sprite)flag11;
																						}
																						goto IL_0a9b;
																						IL_0a9b:
																						bool flag14 = sprite3;
																						bool flag15 = !flag14;
																						flag12 = flag11;
																						action3 = null;
																						if (!flag15)
																						{
																							if ((object)sprite3 == null)
																							{
																								break;
																							}
																							((EME_PunchProjectile_Raksha)(object)sprite3).SetTargetPosition((Vector3)(&ret));
																							ret = CS_0024_003C_003E8__locals22.targetPos;
																							flag12 = flag11;
																							num22 = unchecked((nint)null);
																							action3 = (Action)(&ret);
																						}
																						goto IL_0bb9;
																						IL_0bb9:
																						flag7 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
																						bool flag16 = num21 > (float)(flag7 ? 1 : 0);
																						s_scene4 = (PhaserScene)flag12;
																						flag6 = flag7;
																						num20 = (flag7 ? 1 : 0);
																						if (!flag16)
																						{
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

	public void FireSpecialProjectiles()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_009e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_029b: Expected O, but got F4
		//IL_02a4: Invalid comparison between I4 and F4
		//IL_0158: Invalid comparison between O and F4
		//IL_0102: Invalid comparison between O and F4
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0271: Expected F4, but got O
		BulletPool glimmer3Pool = _glimmer3Pool;
		float2 float5 = default(float2);
		object obj = float5 + float5;
		float num = (_screenPerimeter = (float)obj + (float)obj);
		ObjectPool pool = glimmer3Pool._pool;
		Projectile aliveObjects = (Projectile)(object)pool._aliveObjects;
		object obj2 = ((GameMonoBehaviour)aliveObjects)._onPauseSent - aliveObjects.body;
		if ((nint)obj2 >= 100)
		{
			return;
		}
		object obj3 = float5 + float5;
		Vector2 vector = (Vector2)0;
		object obj4 = 0;
		float num5 = default(float);
		object obj6 = default(object);
		bool flag3;
		do
		{
			object obj5 = UnityEngine.Random.value;
			float num4;
			if (0f < num && num < 1f)
			{
				float num2 = num * _screenPerimeter;
				if (!(num > 0.5f))
				{
					if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
					{
						goto IL_02bb;
					}
					float num3 = num2 - (float)float5;
					num4 = num3 + num5;
				}
				else
				{
					float num6 = num2 - (float)obj3;
					if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
					{
						float num7 = num5 + (float)float5;
						float num8 = num6 - (float)float5;
						num4 = num7 - num8;
					}
					else
					{
						num4 = num5 + (float)float5;
					}
				}
				goto IL_01b5;
			}
			goto IL_02bb;
			IL_02bb:
			num4 = num5;
			goto IL_01b5;
			IL_01b5:
			Projectile projectile = _glimmer3Pool.SpawnAt(float5, this);
			bool flag = (object)projectile == null;
			float2 float6 = float5;
			aliveObjects = (Projectile)(object)typeof(UnityEngine.Object);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
				float6 = float5;
				aliveObjects = (Projectile)(object)typeof(UnityEngine.Object);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					float num9 = (float)obj6 - num4;
					float num10 = GameManager.ProjectileSpeed * 8f;
					vector.Normalize();
					float num7 = num9 * num10;
					projectile.SetVelocity(float5);
					float6 = float5;
					aliveObjects = projectile;
				}
			}
			obj4++;
			flag3 = (nint)obj4 < 12;
			num = (float)float6;
		}
		while (flag3);
	}

	private float Perimeter(Rect rect)
	{
		float num = rect.m_Height + rect.m_Width;
		return num + num;
	}

	private Vector2 GetPoint(Rect rectangle, float ratio)
	{
		//IL_0009: Invalid comparison between I4 and F4
		Vector2 result = default(Vector2);
		if (0f < ratio && ratio < 1f)
		{
			float num = ratio * _screenPerimeter;
			if (!(ratio > 0.5f))
			{
				if (rectangle.m_Width < num)
				{
					return result;
				}
				return result;
			}
			float num2 = rectangle.m_Height + rectangle.m_Width;
			float num3 = num - num2;
			if (rectangle.m_Width < num3)
			{
				return result;
			}
			return result;
		}
		return result;
	}

	protected override void InitGlimmer1BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer1Prefab = _Glimmer1Prefab;
		if ((object)_Glimmer1Prefab != null && ((UnityEngine.Object)glimmer1Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
			_glimmer1Pool = glimmer1Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Punch1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void InitGlimmer2BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer2Prefab = _Glimmer2Prefab;
		if ((object)_Glimmer2Prefab != null && ((UnityEngine.Object)glimmer2Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer2Pool = new BulletPool(_Glimmer2Prefab, 20);
			_glimmer2Pool = glimmer2Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer2Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Punch1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer2Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void InitGlimmer3BulletPool()
	{
		Projectile glimmer3Prefab = _Glimmer3Prefab;
		if ((object)_Glimmer3Prefab != null && ((UnityEngine.Object)glimmer3Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer3Pool = new BulletPool(_Glimmer3Prefab, 20);
			_glimmer3Pool = glimmer3Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyLowDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer3Pool, core.Enemies, collideCallback, processCallback, callbackContext);
		}
	}

	protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0179;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 5f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	protected bool OnBulletOverlapsEnemyLowDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0179;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 0.1f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		object obj = level - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				if ((nint)obj3 != 1)
				{
					return WeaponType.VOID;
				}
				return WeaponType.EME_PUNCH_TECH_03;
			}
			return WeaponType.EME_PUNCH_TECH_02;
		}
		return WeaponType.EME_PUNCH_TECH_01;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0065: Expected I4, but got I8
		//IL_00d0: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_016e: Expected I4, but got I8
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite component = instance.AddPhaserSprite(pos, "Emeralds_VFX", "Guayim_Background_VFX");
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(component, 1f);
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
		PhaserSprite guayimPlayerSpriteRenderer = phaserSprite2.setDepth(-1997);
		_guayimPlayerSpriteRenderer = guayimPlayerSpriteRenderer;
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite3 = instance2.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
		PhaserSprite phaserSprite5 = phaserSprite4.setOrigin(0f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				float xScale = renderer.width * 100f;
				PhaserSprite phaserSprite6 = phaserSprite5.setScale(xScale, (float?)(object)1);
				PhaserSprite component2 = phaserSprite6.setDepth(-1998);
				PhaserSprite phaserSprite7 = RenderingExtensions.SetScrollFactor(component2, 0f);
				GameObject gameObject = phaserSprite7.gameObject;
				((UnityEngine.Object)gameObject).SetName("darkSprite");
				_guayimBackgroundFader = phaserSprite7;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void StartGuayim()
	{
		_updateGuayim = true;
		_detuneValue = 1100f;
		_guayimFiringDelta = 0f;
		_guayimExecutionDelta = 0f;
		_isGuayimRunning = true;
		float num = base.PDuration();
		object obj = default(object);
		float num2 = (float)obj * _guayimExecutionDelayDefault;
		float guayimExecutionDelay = num2 * 0.001f;
		_guayimExecutionDelay = guayimExecutionDelay;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 25 Invalid \"Jump target not found in method: 0x1874C9D80\"");
	}

	private void DisplayGuayimVFX()
	{
		//IL_0076: Expected I, but got O
		//IL_00ce: Expected I, but got O
		//IL_014a: Expected O, but got I4
		//IL_03b0: Expected I, but got O
		if (_guayimFadeTween != null)
		{
			_guayimFadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if (array != null)
		{
			if ((object)_guayimPlayerSpriteRenderer != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_guayimBackgroundFader != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				tweenConfig.duration = 250f;
				tweenConfig.alpha = (float?)(object)1;
				MultiTargetTween guayimFadeTween = Tweens.Add(tweenConfig);
				_guayimFadeTween = guayimFadeTween;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							float num3 = renderer.width;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									if (s_scene2._renderer != null)
									{
										if (!(renderer.width > renderer2.height))
										{
											num3 = renderer2.height;
										}
										float num4 = num3 * 0.5f;
										float scale = num4 * 0.55f;
										PhaserSprite phaserSprite = RenderingExtensions.SetScale(_guayimPlayerSpriteRenderer, scale);
										if ((object)guayimPunchingVFX != null)
										{
											Transform transform = guayimPunchingVFX.transform;
											bool flag = ((TweenConfig)(object)transform).targets == null;
											Vector3 value = default(Vector3);
											Transform.set_localScale_Injected((IntPtr)((TweenConfig)(object)transform).targets, ref value);
											guayimPunchingVFX.Play(withChildren: true);
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
		throw new NullReferenceException();
	}

	private void HideGuayimVFX()
	{
		//IL_0088: Expected I, but got O
		//IL_00e0: Expected I, but got O
		//IL_0144: Expected O, but got I4
		guayimPunchingVFX.Stop();
		if (_guayimFadeTween != null)
		{
			_guayimFadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_guayimPlayerSpriteRenderer != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_guayimBackgroundFader != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			guayimPunchingVFX.Clear(withChildren: true);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween guayimFadeTween = Tweens.Add(tweenConfig);
		_guayimFadeTween = guayimFadeTween;
	}

	private void StopGuayim()
	{
		HideGuayimVFX();
		_isGuayimRunning = false;
	}

	private void ClearGuayimVFX()
	{
		guayimPunchingVFX.Clear(withChildren: true);
	}

	public void GuayimUpdate()
	{
		//IL_0155: Expected O, but got I4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if ((object)_guayimPlayerSpriteRenderer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				if ((object)guayimPunchingVFX != null)
				{
					Transform transform = guayimPunchingVFX.transform;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						if (!((_guayimExecutionDelta = num + _guayimExecutionDelta) < _guayimExecutionDelay) && _isGuayimRunning)
						{
							HideGuayimVFX();
							_isGuayimRunning = false;
							_updateGuayim = false;
						}
						if (_playSoundsDuringUpdate)
						{
							float num2 = num * 0.1f;
							float detuneValue = num2 + _detuneValue;
							_detuneValue = detuneValue;
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							soundConfig.Rate = 1f;
							soundConfig.Detune = _detuneValue;
							soundConfig.Rate = 2f;
							soundConfig.Volume = (float?)(object)1;
							float time = default(float);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_Punch1, soundConfig, 50f, 2, time);
							if (!((_guayimFiringDelta = num + _guayimFiringDelta) < _guayimFiringDelay))
							{
								_guayimFiringDelta = 0f;
								FireSpecialProjectiles();
							}
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
	}

	private void _003CHideGuayimVFX_003Eb__43_0()
	{
		guayimPunchingVFX.Clear(withChildren: true);
	}
}
