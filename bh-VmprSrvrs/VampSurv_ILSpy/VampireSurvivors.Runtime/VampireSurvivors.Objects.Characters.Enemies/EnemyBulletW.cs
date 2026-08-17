using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBulletW : EnemyController
{
	private float _elapsed;

	private float _gravity;

	private float _wave1Alpha = 0.5f;

	private List<Bob> _wave1Group;

	private Blitter _blitter;

	private Tween _waveTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0203: Expected O, but got I4
		//IL_0232: Expected O, but got I4
		//IL_026b: Expected O, but got F4
		//IL_00a1: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_0285->IL01f1: Incompatible stack heights: 1 vs 0
		//IL_01ce->IL01f1: Incompatible stack heights: 1 vs 0
		//IL_0163->IL01f1: Incompatible stack heights: 1 vs 0
		//IL_018f->IL01f1: Incompatible stack heights: 1 vs 0
		_spritePivot = (Vector2)1056964608;
		_ = 1065353216;
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 0.2f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_EnemyRenderer, 15658751u);
		if ((object)_EnemyRenderer != null)
		{
			Sprite sprite = _EnemyRenderer.sprite;
			if ((object)sprite != null)
			{
				bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				object obj = Sprite.get_pixelsPerUnit_Injected(((UnityEngine.Object)sprite).m_CachedPtr);
				if (body != null)
				{
					BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
					Camera main = Camera.main;
					float num = (float)CameraExtensions.OrthographicBoundsIgnoringBorders(main).m_Extents * 2f;
					object obj2 = default(object);
					float xScale = num * (float)obj2;
					ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)1);
					SpriteRenderer blitter = (SpriteRenderer)(object)_blitter;
					_elapsed = 0f;
					if ((object)_blitter == null || ((UnityEngine.Object)blitter).m_CachedPtr == (IntPtr)0)
					{
						MakeBlitter();
						goto IL_01b4;
					}
					if ((object)_blitter != null)
					{
						GameObject gameObject = _blitter.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							goto IL_01b4;
						}
					}
				}
			}
		}
		goto IL_01f1;
		IL_01f1:
		throw new NullReferenceException();
		IL_01b4:
		if ((object)_EnemyRenderer != null)
		{
			Transform transform = _EnemyRenderer.transform;
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			return;
		}
		goto IL_01f1;
	}

	public void Dismiss()
	{
		//IL_0091: Expected I, but got O
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_EnemyRenderer, 0f, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyBulletW>)+3A0]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = onComplete;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
	}

	public override void Despawn()
	{
		GameObject gameObject = _blitter.gameObject;
		gameObject.SetActive(value: false);
		base.Despawn();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_02b6: Invalid comparison between O and F4
		//IL_00fd: Expected I, but got O
		//IL_011e->IL0204: Incompatible stack heights: 3 vs 1
		//IL_00e0->IL0318: Incompatible stack heights: 6 vs 5
		//IL_02c9->IL02ce: Incompatible stack heights: 7 vs 3
		//IL_0119->IL02ce: Incompatible stack heights: 7 vs 3
		base.OnUpdate();
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		float deltaTime = PauseSystem.DeltaTime;
		float elapsed = deltaTime + _elapsed;
		_elapsed = elapsed;
		float num = deltaTime + _elapsed;
		if (num > 1f)
		{
			GameManager core = GM.Core;
			bool flag2 = (object)GM.Core == null;
			bool flag3 = core._characters == null;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
			float num2 = default(float);
			while (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
				bool flag4 = (object)cachedTrans == null;
				bool flag5 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				List<CharacterController>.Enumerator ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody baseBody = arcadeSprite.body;
					ArcadeTransform arcadeTransform = baseBody._transform;
					bool flag6 = baseBody._transform == null;
					arcadeTransform.position = (float2)ret;
				}
				object cachedTransform2 = _cachedTransform;
				bool flag7 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rdi_v18 (System.Object)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rdi_v18 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				if (System.Runtime.CompilerServices.Unsafe.As<List<CharacterController>.Enumerator, UIntPtr>(ref enumerator2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
				{
					float attackPower = base.AttackPower;
					nint num3 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1205 @ r8_v15 (Il2CppClass<ArcadeSprite>)+5F8] (should have been resolved before IL gen)");
					_elapsed = 0.8f;
				}
			}
		}
		if (!base._003CIsTimeStopped_003Ek__BackingField)
		{
			Blitter blitter = _blitter;
			if ((object)_blitter != null && ((UnityEngine.Object)blitter).m_CachedPtr != (IntPtr)0)
			{
				UpdateBlitter();
			}
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	protected override void ProcessWiggle()
	{
	}

	private unsafe void MakeBlitter()
	{
		//IL_09fc: Expected O, but got I4
		//IL_0a8c: Expected O, but got I4
		//IL_0a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9a: Expected O, but got Unknown
		//IL_0a1a: Expected O, but got F4
		//IL_0a45: Expected O, but got F4
		//IL_03be: Expected O, but got F4
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_04c4: Expected I4, but got O
		//IL_052c: Expected O, but got I4
		//IL_0b56: Expected O, but got I4
		//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b64: Expected O, but got Unknown
		//IL_0ae1: Expected O, but got F4
		//IL_0b0c: Expected O, but got F4
		//IL_061e: Expected O, but got F4
		//IL_065e: Expected O, but got I
		//IL_0674: Expected O, but got I
		//IL_068a: Expected O, but got I
		//IL_06a0: Expected O, but got I
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06cb: Expected I4, but got O
		//IL_06ff: Expected O, but got I4
		//IL_0bab: Expected O, but got F4
		//IL_0bd6: Expected O, but got F4
		//IL_079a: Expected O, but got F4
		//IL_07da: Expected O, but got I
		//IL_07f0: Expected O, but got I
		//IL_0806: Expected O, but got I
		//IL_081c: Expected O, but got I
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Expected O, but got Unknown
		//IL_0ad3->IL09a1: Incompatible stack heights: 1 vs 0
		//IL_0258->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0277->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_02b4->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0a37->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0a62->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_034c->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0429->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0478->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0b9d->IL09a1: Incompatible stack heights: 1 vs 0
		//IL_055b->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_057a->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_05b7->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0afe->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0b2c->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0643->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0c15->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0733->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0bc8->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0bf6->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_07bf->IL09b1: Incompatible stack heights: 1 vs 0
		//IL_0c81->IL09b1: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			string text = ((UnityEngine.Object)gameObject).GetName();
			string blitterName = text + " - Blitter";
			if ((object)_gameManager != null)
			{
				Vector2 vector = default(Vector2);
				Blitter blitter = _gameManager.CreateBlitter(vector, blitterName);
				_blitter = blitter;
				List<Sprite> list = new List<Sprite>();
				Sprite sprite = SpriteManager.GetSprite("HitBlue1", "vfx");
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					Sprite sprite2 = SpriteManager.GetSprite("HitBlue2", "vfx");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					Sprite sprite3 = SpriteManager.GetSprite("HitCloud1", "vfx");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					if (list._size <= 0)
					{
						goto IL_09a1;
					}
					Sprite[] items = list._items;
					if (list._items != null && (object)items[0] != null)
					{
						Texture2D texture = items[0].texture;
						if ((object)_blitter != null)
						{
							_blitter.SetAtlasTexture(texture);
							if ((object)_EnemyRenderer != null)
							{
								Transform transform = _EnemyRenderer.transform;
								if ((object)transform != null)
								{
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Vector2 ret;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
									_wave1Alpha = 0.5f;
									object obj = 0;
									Vector2 vector2 = vector;
									int num = (int)(&ret);
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul esi\"");
										int num2 = num >> 31;
										object obj2 = num + num2;
										object obj3 = obj2 * 2;
										object obj4 = obj2 + obj3;
										object obj5 = obj - obj4;
										if ((nint)obj5 >= list._size)
										{
											break;
										}
										Sprite[] items2 = list._items;
										if (list._items != null && (object)_blitter != null)
										{
											Bob bob = _blitter.CreateBob(ret, items2[obj5]);
											if (bob != null)
											{
												BobData bobData = bob._bobData;
												object obj6 = UnityEngine.Random.value;
												if (bob._bobData != null)
												{
													float num3 = (float)vector2 - 0.5f;
													float num4 = (bobData._003CVx_003Ek__BackingField = num3 * 0.15f);
													object obj7 = UnityEngine.Random.value;
													if (bob._bobData != null)
													{
														float num5 = num4 - 0.5f;
														float num6 = num5 * 0.1f;
														BobData bobData2 = bob._bobData;
														if (bob._bobData != null)
														{
															bobData2._003CBounce_003Ek__BackingField = 1f;
															BobVertexData[] vertexData = bob.vertexData;
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
															_ = bob._bobData;
															BobVertexData[] vertexData2 = bob.vertexData;
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
															_ = bob._bobData;
															BobVertexData[] vertexData3 = bob.vertexData;
															vector2 = (Vector2)(_wave1Alpha * 255f);
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
															_ = bob._bobData;
															BobVertexData[] vertexData4 = bob.vertexData;
															float val = _wave1Alpha * 255f;
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
															_ = bob._bobData;
															List<object> wave1Group = (List<object>)(object)_wave1Group;
															if (_wave1Group != null)
															{
																int version = wave1Group._version + 1;
																wave1Group._version = version;
																object[] items3 = wave1Group._items;
																if (wave1Group._items != null)
																{
																	num = wave1Group._size;
																	if (wave1Group._size >= items3.Length)
																	{
																		((List<object>)(object)_wave1Group).AddWithResize((object)bob);
																		num = (int)bob;
																	}
																	else
																	{
																		int num7 = wave1Group._size + 1;
																		wave1Group._size = num7;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	obj++;
																	if ((nint)obj < 500)
																	{
																		continue;
																	}
																	object obj8 = 0;
																	while (true)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul esi\"");
																		int num8 = num >> 31;
																		object obj9 = num + num8;
																		object obj10 = obj9 * 2;
																		object obj11 = obj9 + obj10;
																		object obj12 = obj8 - obj11;
																		if ((nint)obj12 >= list._size)
																		{
																			break;
																		}
																		Sprite[] items4 = list._items;
																		if (list._items != null && (object)_blitter != null)
																		{
																			Bob bob2 = _blitter.CreateBob(ret, items4[obj12]);
																			if (bob2 != null)
																			{
																				BobData bobData3 = bob2._bobData;
																				object obj13 = UnityEngine.Random.value;
																				if (bob2._bobData != null)
																				{
																					float num9 = (float)vector2 - 0.5f;
																					float num10 = (bobData3._003CVx_003Ek__BackingField = num9 * 0.15f);
																					object obj14 = UnityEngine.Random.value;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v78 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																					if ((nint)0 != 0)
																					{
																						float num11 = num10 - 0.5f;
																						vector2 = (Vector2)(num11 * 0.1f);
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v78 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																						if ((nint)0 != 0)
																						{
																							_ = 1065353216;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v78 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																							object obj15 = 0;
																							_ = 127;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v78 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																							object obj16 = 0;
																							_ = 127;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v78 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																							object obj17 = 0;
																							_ = 127;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v78 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																							object obj18 = 0;
																							obj8++;
																							_ = 127;
																							bool flag2 = (nint)obj8 < 500;
																							num = (int)ret;
																							if (flag2)
																							{
																								continue;
																							}
																							Sprite sprite4 = SpriteManager.GetSprite("bubble", "vfx");
																							object obj19 = 0;
																							while ((object)_blitter != null)
																							{
																								Bob bob3 = _blitter.CreateBob(ret, sprite4);
																								if (bob3 == null)
																								{
																									break;
																								}
																								BobData bobData4 = bob3._bobData;
																								object obj20 = UnityEngine.Random.value;
																								if (bob3._bobData == null)
																								{
																									break;
																								}
																								float num12 = (float)vector2 - 0.5f;
																								float num13 = (bobData4._003CVx_003Ek__BackingField = num12 * 0.15f);
																								object obj21 = UnityEngine.Random.value;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v93 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																								if ((nint)0 == 0)
																								{
																									break;
																								}
																								float num14 = num13 - 0.5f;
																								vector2 = (Vector2)(num14 * 0.1f);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v93 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																								if ((nint)0 == 0)
																								{
																									break;
																								}
																								_ = 1065353216;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v93 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																								object obj22 = 0;
																								_ = 127;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v93 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																								object obj23 = 0;
																								_ = 127;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v93 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																								object obj24 = 0;
																								_ = 127;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v93 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																								object obj25 = 0;
																								obj19++;
																								_ = 127;
																								if ((nint)obj19 < 500)
																								{
																									continue;
																								}
																								DOGetter<float> getter = null;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																								DOSetter<float> dOSetter = null;
																								((EnemyBulletW)(object)dOSetter)._003CMakeBlitter_003Eb__12_1(val);
																								TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.1f, 2f);
																								if (tweenerCore != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																									if ((nint)0 != 0)
																									{
																										_ = 4;
																										_ = 0;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																									if ((nint)0 != 0)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
																										if ((nint)0 == 0)
																										{
																											_ = 4294967295L;
																											_ = 1;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
																											if ((nint)0 == 0)
																											{
																												_ = 2139095040;
																											}
																										}
																									}
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								if (tweenerCore == null)
																								{
																									break;
																								}
																								_waveTween = tweenerCore;
																								return;
																							}
																						}
																					}
																				}
																			}
																		}
																		goto IL_09b1;
																	}
																	break;
																}
															}
														}
													}
												}
											}
										}
										goto IL_09b1;
									}
									goto IL_09a1;
								}
							}
						}
					}
				}
			}
		}
		goto IL_09b1;
		IL_09b1:
		throw new NullReferenceException();
		IL_09a1:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_09b1;
	}

	private void UpdateBlitter()
	{
		//IL_008d: Expected I4, but got F4
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected I4, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected I4, but got Unknown
		//IL_03f6: Expected O, but got F4
		//IL_0142->IL03be: Incompatible stack heights: 3 vs 4
		//IL_0209->IL03e9: Incompatible stack heights: 4 vs 5
		//IL_0400->IL0426: Incompatible stack heights: 5 vs 1
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
		Renderer.get_bounds_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, out Bounds ret);
		object obj2 = default(object);
		object obj = obj2 + obj2;
		float num = (float)obj * 0.5f;
		float num2 = 0f * 0.5f;
		List<Bob>.Enumerator enumerator = default(List<Bob>.Enumerator);
		MissingMethodException ex;
		float num4;
		object obj4 = default(object);
		for (; enumerator.MoveNext(); ((Exception)ex)._className = (string)num4)
		{
			ex = null;
			string helpURL = ((Exception)ex)._helpURL;
			bool flag2 = ((Exception)ex)._helpURL == null;
			float num3 = _gravity + (float)(int)helpURL._firstChar;
			helpURL._firstChar = (char)(int)num3;
			string helpURL2 = ((Exception)ex)._helpURL;
			bool flag3 = ((Exception)ex)._helpURL == null;
			num4 = (float)((Exception)ex)._className + (float)helpURL2._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v21 (System.MissingMethodException)+14]");
			float num5 = 0f + (float)(int)helpURL2._firstChar;
			float num6 = (float)ret + num;
			bool num8;
			if (!(num4 > num6))
			{
				float num7 = (float)ret - num;
				if (!(num7 > num4))
				{
					goto IL_03be;
				}
				num4 = (float)ret - num;
				bool flag4 = ((Exception)ex)._helpURL == null;
				num8 = flag4;
			}
			else
			{
				num4 = (float)ret + num;
				bool flag5 = ((Exception)ex)._helpURL == null;
				num8 = flag5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rax_v36 (System.String)+18]");
			object obj3 = 0 ^ -0f;
			int stringLength = obj3 * helpURL2._stringLength;
			helpURL2._stringLength = stringLength;
			goto IL_03be;
			IL_03be:
			float num9 = (float)obj4 + num2;
			string helpURL3;
			bool num11;
			if (!(num5 > num9))
			{
				float num10 = (float)obj4 - num2;
				if (!(num10 > num5))
				{
					continue;
				}
				num5 = (float)obj4 - num2;
				helpURL3 = ((Exception)ex)._helpURL;
				bool flag6 = ((Exception)ex)._helpURL == null;
				num11 = flag6;
			}
			else
			{
				num5 = (float)obj4 + num2;
				helpURL3 = ((Exception)ex)._helpURL;
				bool flag7 = ((Exception)ex)._helpURL == null;
				num11 = flag7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rdx_v21 (System.String)+18]");
			object obj5 = 0 ^ -0f;
			char firstChar = (char)(obj5 * helpURL3._firstChar);
			helpURL3._firstChar = firstChar;
		}
		List<Bob>.Enumerator enumerator2 = default(List<Bob>.Enumerator);
		while (enumerator2.MoveNext())
		{
			MissingMethodException ex2 = null;
			Exception innerException = ((Exception)ex2)._innerException;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			Exception innerException2 = ((Exception)ex2)._innerException;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			Exception innerException3 = ((Exception)ex2)._innerException;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			Exception innerException4 = ((Exception)ex2)._innerException;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
	}

	protected override void UpdateDepth()
	{
		//IL_0043: Expected O, but got I
		//IL_00ce->IL0072: Incompatible stack heights: 1 vs 0
		//IL_0063->IL0072: Incompatible stack heights: 1 vs 0
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		if ((object)_EnemyRenderer != null)
		{
			bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, 3000);
			SpriteRenderer blitter = (SpriteRenderer)(object)_blitter;
			if ((object)_blitter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v7 (UnityEngine.SpriteRenderer)+30]");
				SpriteRenderer spriteRenderer = (SpriteRenderer)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v7 (UnityEngine.SpriteRenderer)+30]");
				if ((nint)0 != 0)
				{
					bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 45 ConditionalJump @-1, v98 @ ZF_v8 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 127 ConditionalJump @-1, v286 @ ZF_v14 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemyBulletW()
	{
		List<Bob> wave1Group = new List<Bob>();
		_wave1Group = wave1Group;
		base._002Ector();
	}

	private float _003CMakeBlitter_003Eb__12_0()
	{
		return _wave1Alpha;
	}

	private void _003CMakeBlitter_003Eb__12_1(float val)
	{
		_wave1Alpha = val;
	}
}
