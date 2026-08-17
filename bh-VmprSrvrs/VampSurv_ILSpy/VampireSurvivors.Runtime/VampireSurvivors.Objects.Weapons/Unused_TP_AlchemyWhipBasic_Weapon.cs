using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_TP_AlchemyWhipBasic_Weapon : Weapon
{
	public class alchemyWhipData
	{
		public bool active;

		public PhaserSprite sprite;

		public MultiTargetTween spriteTweenIn;

		public MultiTargetTween spriteTweenOut;
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public alchemyWhipData whipData;

		public PhaserSprite whipSprite;

		internal void _003CaddWhipSprite_003Eb__0()
		{
			alchemyWhipData alchemyWhipData2 = whipData;
			alchemyWhipData2.active = false;
			PhaserSprite phaserSprite = whipSprite.setVisible(visible: false);
		}
	}

	public List<float> indexDegreeList;

	public float offsetPhysicsPos;

	public float offsetSpritePos;

	public List<float2> indexPosList;

	public List<alchemyWhipData> _whipData;

	private alchemyWhipData nextWhipSprite()
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_03bd->IL030a: Incompatible stack heights: 1 vs 0
		//IL_01d8->IL030a: Incompatible stack heights: 1 vs 0
		//IL_0215->IL030a: Incompatible stack heights: 1 vs 0
		//IL_0250->IL030a: Incompatible stack heights: 1 vs 0
		//IL_029f->IL030a: Incompatible stack heights: 1 vs 0
		//IL_030a->IL0161: Incompatible stack heights: 1 vs 0
		//IL_02db->IL0161: Incompatible stack heights: 1 vs 0
		List<alchemyWhipData> whipData = _whipData;
		if (_whipData != null)
		{
			List<alchemyWhipData> whipData2 = _whipData;
			Transform transform = null;
			Transform transform2 = null;
			object obj = default(object);
			Vector2 pos = default(Vector2);
			alchemyWhipData alchemyWhipData3 = default(alchemyWhipData);
			while (true)
			{
				if ((nint)transform2 < whipData._size)
				{
					if ((nint)transform < whipData2._size)
					{
						alchemyWhipData[] items = whipData2._items;
						if (whipData2._items == null)
						{
							break;
						}
						if ((nint)transform < items.Length)
						{
							alchemyWhipData alchemyWhipData2 = items[(object)transform];
							if (items[(object)transform] == null)
							{
								break;
							}
							if (alchemyWhipData2.active)
							{
								transform = (Transform)(transform + 1);
								transform2 = transform;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj == null)
							{
								break;
							}
							_ = 1;
							if (_whipData == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							goto IL_0161;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				PhaserWorld instance = PhaserWorld.Instance;
				Transform transform3 = base.transform;
				if ((object)transform3 == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
				if ((object)instance == null)
				{
					break;
				}
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "slash");
				if ((object)phaserSprite == null)
				{
					break;
				}
				PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
				alchemyWhipData3 = new alchemyWhipData();
				if (alchemyWhipData3 == null)
				{
					break;
				}
				alchemyWhipData3.sprite = phaserSprite;
				List<object> whipData3 = (List<object>)(object)_whipData;
				if (_whipData == null)
				{
					break;
				}
				int version = whipData3._version + 1;
				whipData3._version = version;
				object[] items2 = whipData3._items;
				if (whipData3._items == null)
				{
					break;
				}
				if (whipData3._size >= items2.Length)
				{
					((List<object>)(object)_whipData).AddWithResize((object)alchemyWhipData3);
				}
				else
				{
					int size = whipData3._size + 1;
					whipData3._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				goto IL_0161;
				IL_0161:
				return alchemyWhipData3;
			}
		}
		throw new NullReferenceException();
	}

	public void addWhipSprite(float2 pos, int rotationIndex)
	{
		//IL_00f7: Expected O, but got I
		//IL_0276: Expected I, but got O
		//IL_02e0: Expected O, but got I4
		//IL_035f: Expected O, but got I4
		//IL_03bb: Expected O, but got I
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_0412: Expected O, but got I4
		//IL_0438: Expected O, but got I4
		//IL_04ef: Expected I, but got O
		//IL_0567: Expected O, but got I4
		//IL_0583: Expected O, but got I4
		//IL_0117->IL05f0: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL05f0: Incompatible stack heights: 2 vs 0
		//IL_0247->IL05f0: Incompatible stack heights: 2 vs 0
		//IL_02bb->IL05f0: Incompatible stack heights: 2 vs 0
		//IL_0299->IL0299: Incompatible stack heights: 3 vs 2
		//IL_0304->IL05f0: Incompatible stack heights: 2 vs 0
		//IL_034c->IL05f0: Incompatible stack heights: 3 vs 0
		//IL_0383->IL05f0: Incompatible stack heights: 3 vs 0
		//IL_03db->IL05f0: Incompatible stack heights: 4 vs 0
		//IL_0467->IL05f0: Incompatible stack heights: 4 vs 0
		//IL_04c0->IL05f0: Incompatible stack heights: 4 vs 0
		//IL_0534->IL05f0: Incompatible stack heights: 4 vs 0
		//IL_0512->IL0512: Incompatible stack heights: 5 vs 4
		//IL_05d8->IL05f0: Incompatible stack heights: 4 vs 0
		//IL_05ef->IL05ef: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass7_0();
		alchemyWhipData whipData = nextWhipSprite();
		if (CS_0024_003C_003E8__locals20 != null)
		{
			CS_0024_003C_003E8__locals20.whipData = whipData;
			if (CS_0024_003C_003E8__locals20.whipData == null)
			{
				return;
			}
			alchemyWhipData whipData2 = CS_0024_003C_003E8__locals20.whipData;
			CS_0024_003C_003E8__locals20.whipSprite = whipData2.sprite;
			if ((object)CS_0024_003C_003E8__locals20.whipSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				if ((object)CS_0024_003C_003E8__locals20.whipSprite != null)
				{
					Transform transform = CS_0024_003C_003E8__locals20.whipSprite.transform;
					List<float> list = indexDegreeList;
					if (indexDegreeList != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v27 (System.Collections.Generic.List`1<System.Single>)+18]");
						int num = default(int);
						bool flag = (nint)num >= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v27 (System.Collections.Generic.List`1<System.Single>)+10]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v27 (System.Collections.Generic.List`1<System.Single>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v22+20+v381 @ r8_v10 (System.Int32)*4]");
							float num2 = 0f * ((float)Math.PI / 180f);
							Vector3 euler = default(Vector3);
							Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Quaternion value = default(Quaternion);
							Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							PhaserSprite phaserSprite = CS_0024_003C_003E8__locals20.whipSprite.setVisible(visible: true);
							alchemyWhipData whipData3 = CS_0024_003C_003E8__locals20.whipData;
							if (whipData3.spriteTweenIn != null)
							{
								whipData3.spriteTweenIn.Kill();
							}
							alchemyWhipData whipData4 = CS_0024_003C_003E8__locals20.whipData;
							if (CS_0024_003C_003E8__locals20.whipData != null)
							{
								if (whipData4.spriteTweenOut != null)
								{
									whipData4.spriteTweenOut.Kill();
								}
								alchemyWhipData whipData5 = CS_0024_003C_003E8__locals20.whipData;
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								if (array != null)
								{
									if ((object)CS_0024_003C_003E8__locals20.whipSprite != null)
									{
										nint num3 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj2 = default(object);
										bool flag3 = obj2 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										tweenConfig.targets = array;
										tweenConfig.alpha = (float?)(object)1;
										List<float2> list2 = indexPosList;
										if (indexPosList != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v51 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
											bool flag4 = (nint)num >= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v51 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
											if ((nint)0 != 0)
											{
												tweenConfig.x = (float?)(object)1;
												List<float2> list3 = indexPosList;
												if (indexPosList != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v53 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
													bool flag5 = (nint)num >= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v53 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
													object obj3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v53 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rcx_v43+24+v381 @ r8_v10 (System.Int32)*8]");
														object obj4 = 0 * offsetSpritePos;
														object obj6 = default(object);
														object obj5 = obj4 + obj6;
														tweenConfig.y = (float?)(object)1;
														float num4 = base.PArea();
														tweenConfig.duration = 100f;
														tweenConfig.scale = (float?)(object)1;
														MultiTargetTween spriteTweenIn = Tweens.Add(tweenConfig);
														if (CS_0024_003C_003E8__locals20.whipData != null)
														{
															whipData5.spriteTweenIn = spriteTweenIn;
															alchemyWhipData whipData6 = CS_0024_003C_003E8__locals20.whipData;
															TweenConfig tweenConfig2 = new TweenConfig();
															object[] array2 = new object[1];
															if (array2 != null)
															{
																if ((object)CS_0024_003C_003E8__locals20.whipSprite != null)
																{
																	nint num5 = (nint)array2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj7 = default(object);
																	bool flag6 = obj7 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig2 != null)
																{
																	tweenConfig2.targets = array2;
																	tweenConfig2.duration = 100f;
																	tweenConfig2.alpha = (float?)(object)1;
																	tweenConfig2.delay = 200f;
																	tweenConfig2.scale = (float?)(object)1;
																	TweenCallback onComplete = delegate
																	{
																		alchemyWhipData whipData7 = CS_0024_003C_003E8__locals20.whipData;
																		whipData7.active = false;
																		PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals20.whipSprite.setVisible(visible: false);
																	};
																	tweenConfig2.onComplete = onComplete;
																	MultiTargetTween spriteTweenOut = Tweens.Add(tweenConfig2);
																	if (CS_0024_003C_003E8__locals20.whipData != null)
																	{
																		whipData6.spriteTweenOut = spriteTweenOut;
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
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public Unused_TP_AlchemyWhipBasic_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_05f3: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_061b: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0643: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_066b: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0693: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_06bb: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_06e3: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_070b: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_0733: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_075b: Expected O, but got I
		//IL_04a6: Expected O, but got I
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(90f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1119092736;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rcx_v8+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(45f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1110704128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v10+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(135f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1124532224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v12+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v14+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(180f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1127481344;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v9+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(90f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1119092736;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v10+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(45f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1110704128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v11+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(135f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1124532224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v12+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v13+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(180f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1127481344;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v14+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(90f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1119092736;
		}
		indexDegreeList = list;
		offsetPhysicsPos = 1f;
		offsetSpritePos = 0.75f;
		float2 item = default(float2);
		indexPosList = new List<float2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item
		};
		_whipData = new List<alchemyWhipData>();
		base._002Ector();
	}
}
