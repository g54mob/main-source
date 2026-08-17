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
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_AxeProjectile_ReverseDelta : Projectile
{
	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_RapierWeapon _trueWeapon;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private TrailRenderer _Trail1;

	private TrailRenderer _Trail2;

	private TrailRenderer _Trail3;

	private ParticleSystem punchVFX;

	private MeshRenderer _Quad1;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private Timer _DespawnTimer;

	private PhaserSprite _displayImage;

	private float _offsetX;

	private MultiTargetTween slashTween;

	private MultiTargetTween modelTween1;

	private MultiTargetTween modelTween2;

	private Timer _hitboxTimer;

	private PhaserSprite cloneImage1;

	private PhaserSprite cloneImage2;

	private PhaserSprite cloneImage3;

	private MultiTargetTween clonesAlphaTween;

	private Vector2[] _deltaPoints;

	private List<Vector2> _currentDelta;

	private float _radius;

	private bool _isAttacking;

	private float _attackTime;

	private Timer _attackAnimTimer;

	private Tween _materialFadeTween;

	private MultiTargetTween _blockAlphaTween;

	private int _strikeTimes;

	private void LateUpdate()
	{
		//IL_0623: Expected O, but got I
		//IL_0285: Expected O, but got I
		//IL_06d3: Expected O, but got I
		//IL_0335: Expected O, but got I
		//IL_0783: Expected O, but got I
		//IL_03fe: Expected O, but got I
		//IL_0a63->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_00e4->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_0135->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_0186->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_05a3->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_05ea->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_024c->IL09d5: Incompatible stack heights: 1 vs 0
		//IL_0643->IL09d5: Incompatible stack heights: 2 vs 0
		//IL_02a5->IL09d5: Incompatible stack heights: 2 vs 0
		//IL_069a->IL09d5: Incompatible stack heights: 3 vs 0
		//IL_02fc->IL09d5: Incompatible stack heights: 3 vs 0
		//IL_06f3->IL09d5: Incompatible stack heights: 4 vs 0
		//IL_0355->IL09d5: Incompatible stack heights: 4 vs 0
		//IL_074a->IL09d5: Incompatible stack heights: 5 vs 0
		//IL_03c5->IL09d5: Incompatible stack heights: 5 vs 0
		//IL_07a3->IL09d5: Incompatible stack heights: 6 vs 0
		//IL_041e->IL09d5: Incompatible stack heights: 6 vs 0
		//IL_046b->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_0802->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_04a3->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_084c->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_04db->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_0896->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_0504->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_08c4->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_0537->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_08f7->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_056a->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_092a->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_095d->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_098c->IL09d5: Incompatible stack heights: 7 vs 0
		//IL_09bb->IL09d5: Incompatible stack heights: 7 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Camera main = Camera.main;
			if ((object)main != null)
			{
				Transform transform = main.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					float2 float6 = default(float2);
					base.position = float6;
					List<Vector2> currentDelta = _currentDelta;
					if (_currentDelta != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						if (_currentDelta != null)
						{
							_currentDelta.Add(float6);
							_currentDelta.Add(float6);
							_currentDelta.Add(float6);
							if (_currentDelta != null)
							{
								_currentDelta.Add(float6);
								_currentDelta.Add(float6);
								_currentDelta.Add(float6);
								if (_currentDelta != null)
								{
									_currentDelta.Add(float6);
									bool num3;
									bool num4;
									bool num5;
									bool num6;
									bool num8;
									bool num9;
									if (_isAttacking)
									{
										float deltaTime = PauseSystem.DeltaTime;
										float num = deltaTime * 1000f;
										float attackTime = num + _attackTime;
										_attackTime = attackTime;
										if (_isAttacking)
										{
											float num2 = _attackTime / 200f;
											float2 float7 = base.position;
											List<Vector2> currentDelta2 = _currentDelta;
											if (_currentDelta != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v58 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
												bool flag2 = (nint)0 <= (nint)0;
												num3 = flag2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v58 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v58 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v59+18]");
													bool flag3 = (nint)0 <= (nint)0;
													num4 = flag3;
													float2 float8 = base.position;
													List<Vector2> currentDelta3 = _currentDelta;
													if (_currentDelta != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v61 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
														bool flag4 = (nint)0 <= (nint)1;
														num5 = flag4;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v61 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
														object obj2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v61 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v62+18]");
															bool flag5 = (nint)0 <= (nint)1;
															num6 = flag5;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v62+28]");
															float num7 = 0f * _radius;
															float2 float9 = base.position;
															List<Vector2> currentDelta4 = _currentDelta;
															if (_currentDelta != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v64 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
																bool flag6 = (nint)0 <= (nint)2;
																num8 = flag6;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v64 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
																object obj3 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v64 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v65+18]");
																	bool flag7 = (nint)0 <= (nint)2;
																	num9 = flag7;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
																	if ((object)cloneImage1 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
																		if ((object)cloneImage2 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
																			if ((object)cloneImage3 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																				if ((object)cloneImage1 != null)
																				{
																					PhaserSprite phaserSprite = cloneImage1.setFlipX(flipX: false);
																					if ((object)cloneImage2 != null)
																					{
																						PhaserSprite phaserSprite2 = cloneImage2.setFlipX(flipX: false);
																						if ((object)cloneImage3 != null)
																						{
																							PhaserSprite phaserSprite3 = cloneImage3.setFlipX(flipX: true);
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
											goto IL_09d5;
										}
									}
									if ((object)cloneImage1 != null)
									{
										float alpha = cloneImage1.Alpha;
										float2 float10 = base.position;
										List<Vector2> currentDelta5 = _currentDelta;
										if (_currentDelta != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
											bool flag8 = (nint)0 <= (nint)0;
											num3 = flag8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v34+18]");
												bool flag9 = (nint)0 <= (nint)0;
												num4 = flag9;
												float2 float11 = base.position;
												List<Vector2> currentDelta6 = _currentDelta;
												if (_currentDelta != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
													bool flag10 = (nint)0 <= (nint)1;
													num5 = flag10;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
													object obj5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v37+18]");
														bool flag11 = (nint)0 <= (nint)1;
														num6 = flag11;
														float2 float12 = base.position;
														List<Vector2> currentDelta7 = _currentDelta;
														if (_currentDelta != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
															bool flag12 = (nint)0 <= (nint)2;
															num8 = flag12;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
															object obj6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v40+18]");
																bool flag13 = (nint)0 <= (nint)2;
																num9 = flag13;
																float2 float13 = base.position;
																((List<Vector2>)float6).Add((Vector2)float6);
																if ((object)cloneImage1 != null)
																{
																	((List<Vector2>)(object)cloneImage1).Add((Vector2)float6);
																	float2 float14 = base.position;
																	((List<Vector2>)float6).Add((Vector2)float6);
																	if ((object)cloneImage2 != null)
																	{
																		((List<Vector2>)(object)cloneImage2).Add((Vector2)float6);
																		float2 float15 = base.position;
																		((List<Vector2>)float6).Add((Vector2)float6);
																		if ((object)cloneImage3 != null)
																		{
																			((List<Vector2>)(object)cloneImage3).Add((Vector2)float6);
																			if ((object)cloneImage1 != null)
																			{
																				PhaserSprite phaserSprite4 = cloneImage1.setFlipX(flipX: false);
																				if ((object)cloneImage2 != null)
																				{
																					PhaserSprite phaserSprite5 = cloneImage2.setFlipX(flipX: false);
																					if ((object)cloneImage3 != null)
																					{
																						PhaserSprite phaserSprite6 = cloneImage3.setFlipX(flipX: true);
																						if ((object)_Trail1 != null)
																						{
																							_Trail1.emitting = false;
																							if ((object)_Trail2 != null)
																							{
																								_Trail2.emitting = false;
																								if ((object)_Trail3 != null)
																								{
																									_Trail3.emitting = false;
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
			}
		}
		goto IL_09d5;
		IL_09d5:
		throw new NullReferenceException();
	}

	private void MakeCloneSprites()
	{
		//IL_01bf: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_02fa: Expected O, but got I
		//IL_02e4: Expected I4, but got O
		//IL_01df->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_023c->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0316->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0aee->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_03a7->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_03f7->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0447->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_049a->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_04bc->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0510->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0532->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_056e->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0590->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_05e4->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0606->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0642->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0664->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_06b8->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_06da->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_070c->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0751->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0796->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_07db->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_080e->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0841->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_0874->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_08a2->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_08ce->IL0a83: Incompatible stack heights: 1 vs 0
		//IL_08ff->IL0a83: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._dataManager != null)
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && convertedCharacterData != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
					if (obj != null)
					{
						goto IL_018b;
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._dataManager != null)
					{
						Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
						if (convertedCharacterData2 != null)
						{
							obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)1);
							if (obj != null)
							{
								goto IL_018b;
							}
						}
					}
				}
			}
		}
		goto IL_0a83;
		IL_018b:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v35 (System.Object)+18]");
		bool flag = (nint)0 <= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v35 (System.Object)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v35 (System.Object)+10]");
		string textureName;
		string text;
		int end;
		int fps = default(int);
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v31+18]");
			if ((nint)0 <= (nint)0)
			{
				throw new IndexOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v31+20]");
			CharacterData characterData = (CharacterData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v31+20]");
			if ((nint)0 != 0)
			{
				if (characterData._003Cskins_003Ek__BackingField == null)
				{
					bool flag2 = (object)characterData._003CwalkFrameRate_003Ek__BackingField == null;
					textureName = characterData._003CtextureName_003Ek__BackingField;
					text = characterData._003CspriteName_003Ek__BackingField;
					end = characterData._003CwalkingFrames_003Ek__BackingField;
					if (!flag2)
					{
						if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
						{
							fps = (object?)characterData._003CwalkFrameRate_003Ek__BackingField >> 32;
						}
						else
						{
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
						}
						goto IL_0ad6;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v31+20]");
					Skin currentSkinData = ((CharacterData)0).GetCurrentSkinData();
					if (currentSkinData == null)
					{
						goto IL_0a83;
					}
					textureName = currentSkinData._003CtextureName_003Ek__BackingField;
					text = currentSkinData._003CspriteName_003Ek__BackingField;
					end = currentSkinData._003CwalkingFrames_003Ek__BackingField;
				}
				fps = 8;
				goto IL_0ad6;
			}
		}
		goto IL_0a83;
		IL_0a83:
		throw new NullReferenceException();
		IL_0ad6:
		if (text != null)
		{
			string animName = text.Replace("01.png", "");
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, num);
			PhaserWorld instance = PhaserWorld.Instance;
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "textureName", "spriteName");
				cloneImage1 = phaserSprite;
				PhaserWorld instance2 = PhaserWorld.Instance;
				if ((object)instance2 != null)
				{
					PhaserSprite phaserSprite2 = instance2.AddPhaserSprite(pos, "textureName", "spriteName");
					cloneImage2 = phaserSprite2;
					PhaserWorld instance3 = PhaserWorld.Instance;
					if ((object)instance3 != null)
					{
						PhaserSprite phaserSprite3 = instance3.AddPhaserSprite(pos, "textureName", "spriteName");
						cloneImage3 = phaserSprite3;
						PhaserSprite phaserSprite4 = cloneImage1;
						if ((object)cloneImage1 != null && (object)phaserSprite4._spriteAnimation != null)
						{
							bool flag3 = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							phaserSprite4._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
							PhaserSprite phaserSprite5 = cloneImage1;
							if ((object)cloneImage1 != null && (object)phaserSprite5._spriteAnimation != null)
							{
								phaserSprite5._spriteAnimation.SetAnimation("walk");
								PhaserSprite phaserSprite6 = cloneImage2;
								if ((object)cloneImage2 != null && (object)phaserSprite6._spriteAnimation != null)
								{
									phaserSprite6._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
									PhaserSprite phaserSprite7 = cloneImage2;
									if ((object)cloneImage2 != null && (object)phaserSprite7._spriteAnimation != null)
									{
										phaserSprite7._spriteAnimation.SetAnimation("walk");
										PhaserSprite phaserSprite8 = cloneImage3;
										if ((object)cloneImage3 != null && (object)phaserSprite8._spriteAnimation != null)
										{
											phaserSprite8._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag3, onComplete, autoSetAnimation);
											PhaserSprite phaserSprite9 = cloneImage3;
											if ((object)cloneImage3 != null && (object)phaserSprite9._spriteAnimation != null)
											{
												phaserSprite9._spriteAnimation.SetAnimation("walk");
												if ((object)cloneImage1 != null)
												{
													PhaserSprite phaserSprite10 = cloneImage1.setTint(16711935u, 16746751u, 8947967u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
													if ((object)cloneImage2 != null)
													{
														PhaserSprite phaserSprite11 = cloneImage2.setTint(16711935u, 16746751u, 8947967u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
														if ((object)cloneImage3 != null)
														{
															PhaserSprite phaserSprite12 = cloneImage3.setTint(16711935u, 16746751u, 8947967u, (uint)num, flag3 ? BlendMode.Add : BlendMode.Normal);
															if ((object)cloneImage1 != null)
															{
																PhaserSprite phaserSprite13 = cloneImage1.setAlpha(0f);
																if ((object)cloneImage2 != null)
																{
																	PhaserSprite phaserSprite14 = cloneImage2.setAlpha(0f);
																	if ((object)cloneImage3 != null)
																	{
																		PhaserSprite phaserSprite15 = cloneImage3.setAlpha(0f);
																		if ((object)_Trail1 != null)
																		{
																			Transform transform = _Trail1.transform;
																			if ((object)cloneImage1 != null)
																			{
																				Transform parent = cloneImage1.transform;
																				if ((object)transform != null)
																				{
																					transform.SetParent(parent, worldPositionStays: true);
																					if ((object)_Trail1 != null)
																					{
																						Transform transform2 = _Trail1.transform;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1862 @ rax_v65 (UnityEngine.Transform)+10]");
																						bool flag4 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1862 @ rax_v65 (UnityEngine.Transform)+10]");
																						Vector3 value = default(Vector3);
																						Transform.set_localPosition_Injected((IntPtr)0, ref value);
																						Transform transform3 = _Trail2.transform;
																						Transform parent2 = cloneImage2.transform;
																						transform3.SetParent(parent2, worldPositionStays: true);
																						Transform transform4 = _Trail2.transform;
																						bool flag5 = (object)transform4 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1917 @ rax_v76 (UnityEngine.Transform)+10]");
																						bool flag6 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1917 @ rax_v76 (UnityEngine.Transform)+10]");
																						Vector3 value2 = default(Vector3);
																						Transform.set_localPosition_Injected((IntPtr)0, ref value2);
																						bool flag7 = (object)_Trail3 == null;
																						Transform transform5 = _Trail3.transform;
																						bool flag8 = (object)cloneImage3 == null;
																						Transform parent3 = cloneImage3.transform;
																						bool flag9 = (object)transform5 == null;
																						transform5.SetParent(parent3, worldPositionStays: true);
																						bool flag10 = (object)_Trail3 == null;
																						Transform transform6 = _Trail3.transform;
																						bool flag11 = (object)transform6 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v87 (UnityEngine.Transform)+10]");
																						bool flag12 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v87 (UnityEngine.Transform)+10]");
																						Transform.set_localPosition_Injected((IntPtr)0, ref value);
																						bool flag13 = (object)_Trail1 == null;
																						_Trail1.emitting = false;
																						bool flag14 = (object)_Trail2 == null;
																						_Trail2.emitting = false;
																						bool flag15 = (object)_Trail3 == null;
																						_Trail3.emitting = false;
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
		goto IL_0a83;
	}

	protected override void Awake()
	{
		//IL_0080: Expected O, but got I4
		//IL_00bd: Expected O, but got I
		//IL_02d9->IL025f: Incompatible stack heights: 1 vs 0
		//IL_011a->IL025f: Incompatible stack heights: 1 vs 0
		//IL_0157->IL025f: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL025f: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL025f: Incompatible stack heights: 1 vs 0
		//IL_024a->IL025f: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			Vector2 vector = default(Vector2);
			PhaserSprite displayImage = instance.AddPhaserSprite(vector, "vfx", "add_pierceBack");
			_displayImage = displayImage;
			if ((object)_displayImage != null)
			{
				PhaserSprite phaserSprite = _displayImage.setOrigin(1f, (float?)(object)1);
				List<Vector2> displayImage2 = (List<Vector2>)(object)_displayImage;
				if ((object)_displayImage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+28]");
					List<Vector2> list = (List<Vector2>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+28]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						Color value = default(Color);
						SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
						if ((object)_displayImage != null)
						{
							PhaserSprite phaserSprite2 = _displayImage.setAlpha(0f);
							if ((object)_displayImage != null)
							{
								PhaserSprite phaserSprite3 = _displayImage.setDepth(2000);
								List<Vector2> currentDelta = _currentDelta;
								if (_currentDelta != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
									_ = (nint)0 + (nint)1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									if (_currentDelta != null)
									{
										_currentDelta.Add(vector);
										_currentDelta.Add(vector);
										_currentDelta.Add(vector);
										if (_currentDelta != null)
										{
											_currentDelta.Add(vector);
											_currentDelta.Add(vector);
											_currentDelta.Add(vector);
											if (_currentDelta != null)
											{
												_currentDelta.Add(vector);
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
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_0229: Expected O, but got I8
		//IL_04e8: Expected O, but got Ref
		//IL_0a1d: Expected O, but got I4
		//IL_0731: Expected I, but got O
		//IL_0814: Expected O, but got I4
		//IL_0822: Expected O, but got I4
		//IL_0981->IL086c: Incompatible stack heights: 1 vs 0
		//IL_099e->IL086c: Incompatible stack heights: 1 vs 0
		//IL_03b2->IL086c: Incompatible stack heights: 1 vs 0
		//IL_09bb->IL086c: Incompatible stack heights: 1 vs 0
		//IL_043f->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0472->IL086c: Incompatible stack heights: 1 vs 0
		//IL_04aa->IL086c: Incompatible stack heights: 1 vs 0
		//IL_04d6->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0510->IL086c: Incompatible stack heights: 1 vs 0
		//IL_09e2->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0544->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0588->IL086c: Incompatible stack heights: 1 vs 0
		//IL_05ba->IL086c: Incompatible stack heights: 1 vs 0
		//IL_05ed->IL086c: Incompatible stack heights: 1 vs 0
		//IL_062a->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0a09->IL086c: Incompatible stack heights: 1 vs 0
		//IL_065e->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0705->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0776->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0754->IL0754: Incompatible stack heights: 2 vs 1
		//IL_07b0->IL086c: Incompatible stack heights: 1 vs 0
		//IL_0a8e->IL086c: Incompatible stack heights: 1 vs 0
		//IL_07d7->IL086c: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		EME_RapierWeapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_08b1;
		}
		nint num = (nint)typeof(EME_RapierWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v138+FFFFFFF8+v74 @ rax_v133*8]");
			if (0 == (nint)typeof(EME_RapierWeapon))
			{
				obj3 = 1;
				goto IL_08c0;
			}
		}
		obj3 = 0;
		goto IL_08c0;
		IL_08c0:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (EME_RapierWeapon)_weapon;
		}
		goto IL_08b1;
		IL_08b1:
		_trueWeapon = trueWeapon;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = 1f;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_deltaStart, soundConfig, 100f, 2, time);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		ArcadeSprite arcadeSprite2 = setAlpha(0f);
		ArcadeSprite arcadeSprite3 = setTint(16711935u);
		PhaserSprite phaserSprite = cloneImage1;
		_strikeTimes = 0;
		if ((object)cloneImage1 == null || ((UnityEngine.Object)phaserSprite).m_CachedPtr == (IntPtr)0)
		{
			MakeCloneSprites();
		}
		if (body != null)
		{
			BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._offset = (float2)3212836864L;
				_ = 1082130432;
				BaseBody baseBody3 = body;
				if (body != null)
				{
					baseBody3._enable = false;
					_isCullable = false;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
						{
							_offsetX = 0f;
							if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
							{
								float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
								Camera main = Camera.main;
								if ((object)main != null)
								{
									Transform transform = main.transform;
									if ((object)transform != null)
									{
										bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
										float2 float6 = default(float2);
										base.position = float6;
										if ((object)_Quad1 != null)
										{
											Material material = ((Renderer)_Quad1).GetMaterial();
											if ((object)material != null)
											{
												material.SetFloatImpl(_AlphaMul, 0f);
												if ((object)_Quad1 != null)
												{
													Material material2 = ((Renderer)_Quad1).GetMaterial();
													TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material2, 0.75f, _AlphaMul, 0.5f);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
													if ((nint)0 == 0)
													{
														_ = 1;
													}
													if (tweenerCore != null && (object)_displayImage != null)
													{
														PhaserSprite phaserSprite2 = _displayImage.setVisible(visible: true);
														if ((object)_displayImage != null)
														{
															PhaserSprite phaserSprite3 = _displayImage.setAlpha(0f);
															if ((object)_displayImage != null)
															{
																Transform transform2 = _displayImage.transform;
																if ((object)transform2 != null)
																{
																	transform2.localEulerAngles = (Vector3)(&ret);
																	float2 float7 = base.position;
																	if ((object)GM.Core != null)
																	{
																		PhaserScene s_scene2 = ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null)
																		{
																			PhaserScene.Renderer renderer = s_scene2._renderer;
																			if (s_scene2._renderer != null)
																			{
																				float num4 = renderer.height * 0.5f;
																				float num5 = 1.1455693E+09f + num4;
																				if ((object)_displayImage != null)
																				{
																					PhaserSprite phaserSprite4 = _displayImage.setPosition(float6);
																					if ((object)_displayImage != null)
																					{
																						PhaserSprite phaserSprite5 = _displayImage.setBlendMode(BlendMode.Add);
																						if ((object)_weapon != null)
																						{
																							float num6 = _weapon.PArea();
																							float num7 = num4 * 0.5f;
																							if ((object)GM.Core != null)
																							{
																								PhaserScene s_scene3 = ArcadePhysics.s_scene;
																								if (ArcadePhysics.s_scene != null)
																								{
																									PhaserScene.Renderer renderer2 = s_scene3._renderer;
																									if (s_scene3._renderer != null)
																									{
																										float num8 = renderer2.width * 0.25f;
																										if (!(num8 > num7))
																										{
																											num7 = num8;
																										}
																										ArcadeSprite arcadeSprite4 = setScale(num7, (float?)(object)1);
																										float radius = num7 + 0.15f;
																										_attackTime = 0f;
																										_isAttacking = false;
																										_radius = radius;
																										PlayStrikeAnim(600f);
																										FadeClonesAlphaTo(1f);
																										if (slashTween != null)
																										{
																											slashTween.Kill();
																										}
																										TweenConfig tweenConfig = new TweenConfig();
																										object[] array = new object[1];
																										if (array != null)
																										{
																											if ((object)_displayImage != null)
																											{
																												nint num9 = (nint)array;
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																												object obj4 = default(object);
																												bool flag3 = obj4 == null;
																											}
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																											if (tweenConfig != null)
																											{
																												tweenConfig.targets = array;
																												float2 float8 = base.position;
																												if ((object)GM.Core != null)
																												{
																													PhaserScene s_scene4 = ArcadePhysics.s_scene;
																													if (ArcadePhysics.s_scene != null && s_scene4._renderer != null)
																													{
																														tweenConfig.duration = 100f;
																														tweenConfig.ease = Ease.Linear;
																														tweenConfig.delay = 600f;
																														tweenConfig.y = (float?)(object)1;
																														tweenConfig.scaleY = (float?)(object)1;
																														TweenCallback onComplete = delegate
																														{
																															Activate();
																														};
																														tweenConfig.onComplete = onComplete;
																														MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																														slashTween = multiTargetTween;
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Activate()
	{
		//IL_0155: Expected I, but got O
		//IL_01c6: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			//IL_003f: Expected I, but got O
			//IL_00bf: Expected O, but got I4
			if (_blockAlphaTween != null)
			{
				_blockAlphaTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 50f;
				tweenConfig2.ease = Ease.Linear;
				tweenConfig2.yoyo = true;
				tweenConfig2.alpha = (float?)(object)1;
				TweenCallback onStart = delegate
				{
					ArcadeSprite arcadeSprite = setAlpha(0f);
				};
				tweenConfig2.onStart = onStart;
				MultiTargetTween blockAlphaTween = Tweens.Add(tweenConfig2);
				_blockAlphaTween = blockAlphaTween;
				PlayStrikeAnim(300f);
				_isAttacking = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				return;
			}
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		};
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num = _weapon.PDuration();
		if (modelTween1 != null)
		{
			modelTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _Quad1.transform;
		if ((object)transform != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			StartDespawn();
		};
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		modelTween1 = multiTargetTween;
	}

	public void StartDespawn()
	{
		//IL_006e: Expected I, but got O
		//IL_00e0: Expected O, but got I4
		//IL_0244: Expected I, but got O
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_blockAlphaTween != null)
		{
			_blockAlphaTween.Kill();
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
			tweenConfig.duration = 50f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween blockAlphaTween = Tweens.Add(tweenConfig);
			_blockAlphaTween = blockAlphaTween;
			if (_attackAnimTimer != null)
			{
				_attackAnimTimer.Cancel();
			}
			FadeClonesAlphaTo(0f);
			Material material = ((Renderer)_Quad1).GetMaterial();
			TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 0f, _AlphaMul, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_AxeProjectile_ReverseDelta>)+370]");
			TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (modelTween1 != null)
		{
			modelTween1.Kill();
		}
		if (modelTween2 != null)
		{
			modelTween2.Kill();
		}
		base.Despawn();
	}

	private void FadeClonesAlphaTo(float fadeToValue)
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_0172: Expected O, but got I4
		if (clonesAlphaTween != null)
		{
			clonesAlphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)cloneImage1 != null)
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
		if ((object)cloneImage2 != null)
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
		if ((object)cloneImage3 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		clonesAlphaTween = multiTargetTween;
	}

	private void PlayStrikeAnim(float delay)
	{
		_isAttacking = false;
		_attackTime = 0f;
		if (_attackAnimTimer != null)
		{
			_attackAnimTimer.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_0100: Expected O, but got I4
			//IL_0061: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float detune = (float)_strikeTimes * 100f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_delta, soundConfig, 100f, 3, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			float detune2 = (float)_strikeTimes * -100f;
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Sfx_eme_delta, soundConfig2, 100f, 3, time);
			int strikeTimes = _strikeTimes + 1;
			_strikeTimes = strikeTimes;
			punchVFX.Play(withChildren: true);
			_isAttacking = true;
		};
		float duration = delay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer attackAnimTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_attackAnimTimer = attackAnimTimer;
	}

	public EME_AxeProjectile_ReverseDelta()
	{
		Vector2[] deltaPoints = new Vector2[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		_ = 30f;
		_ = 30f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		_ = 150f;
		_ = 150f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		_ = 270f;
		_ = 270f;
		_deltaPoints = deltaPoints;
		_currentDelta = new List<Vector2>();
		_radius = 2f;
		base._002Ector();
	}

	static EME_AxeProjectile_ReverseDelta()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003CInitProjectile_003Eb__36_0()
	{
		Activate();
	}

	private void _003CActivate_003Eb__37_0()
	{
		//IL_003f: Expected I, but got O
		//IL_00bf: Expected O, but got I4
		if (_blockAlphaTween != null)
		{
			_blockAlphaTween.Kill();
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
			tweenConfig.duration = 50f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.yoyo = true;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				ArcadeSprite arcadeSprite = setAlpha(0f);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween blockAlphaTween = Tweens.Add(tweenConfig);
			_blockAlphaTween = blockAlphaTween;
			PlayStrikeAnim(300f);
			_isAttacking = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void _003CActivate_003Eb__37_1()
	{
		ArcadeSprite arcadeSprite = setAlpha(0f);
	}

	private void _003CActivate_003Eb__37_2()
	{
		StartDespawn();
	}

	private void _003CPlayStrikeAnim_003Eb__41_0()
	{
		//IL_0100: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_strikeTimes * 100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_delta, soundConfig, 100f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		float detune2 = (float)_strikeTimes * -100f;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = detune2;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Sfx_eme_delta, soundConfig2, 100f, 3, time);
		int strikeTimes = _strikeTimes + 1;
		_strikeTimes = strikeTimes;
		punchVFX.Play(withChildren: true);
		_isAttacking = true;
	}
}
