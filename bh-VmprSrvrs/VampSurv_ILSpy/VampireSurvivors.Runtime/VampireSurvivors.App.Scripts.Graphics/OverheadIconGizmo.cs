using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using QFSW.MOP2;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.App.Scripts.Graphics;

public class OverheadIconGizmo : PoolableMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public OverheadIconOffsetY offsetObj;

		public OverheadIconGizmo _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController character;

		public float width;

		public float offset;

		public Vector2 vOffset;

		public float displayTimeMultiplier;

		public TweenCallback _003C_003E9__3;

		internal void _003CPlay_003Eb__0()
		{
			OverheadIconOffsetY overheadIconOffsetY = offsetObj;
			if (offsetObj != null)
			{
				overheadIconOffsetY.IconYOffset = 0f;
				OverheadIconGizmo overheadIconGizmo = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(overheadIconGizmo._Icon, 1f);
					OverheadIconGizmo overheadIconGizmo2 = _003C_003E4__this;
					if ((object)_003C_003E4__this != null && (object)overheadIconGizmo2._Icon != null)
					{
						overheadIconGizmo2._Icon.enabled = true;
						OverheadIconGizmo overheadIconGizmo3 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)overheadIconGizmo3._TextValue != null)
						{
							overheadIconGizmo3._TextValue.SetAlpha(1f);
							OverheadIconGizmo overheadIconGizmo4 = _003C_003E4__this;
							if ((object)_003C_003E4__this != null && (object)overheadIconGizmo4._TextValue != null)
							{
								overheadIconGizmo4._TextValue.enabled = true;
								if ((object)character != null)
								{
									float2 position = character.position;
									if ((object)character != null)
									{
										float2 position2 = character.position;
										OverheadIconGizmo overheadIconGizmo5 = _003C_003E4__this;
										if ((object)_003C_003E4__this != null && (object)overheadIconGizmo5._Icon != null)
										{
											Transform transform = overheadIconGizmo5._Icon.transform;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v27 (UnityEngine.Transform)+10]");
											bool flag = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v27 (UnityEngine.Transform)+10]");
											Vector3 value = default(Vector3);
											Transform.set_position_Injected((IntPtr)0, ref value);
											OverheadIconGizmo overheadIconGizmo6 = _003C_003E4__this;
											Transform transform2 = overheadIconGizmo6._TextValue.transform;
											bool flag2 = (object)transform2 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v32 (UnityEngine.Transform)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v32 (UnityEngine.Transform)+10]");
											Vector3 value2 = default(Vector3);
											Transform.set_position_Injected((IntPtr)0, ref value2);
											return;
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

		internal void _003CPlay_003Eb__1()
		{
			//IL_00fc: Expected I, but got O
			float2 position = character.position;
			float2 position2 = character.position;
			OverheadIconGizmo overheadIconGizmo = _003C_003E4__this;
			Transform transform = overheadIconGizmo._Icon.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			OverheadIconGizmo overheadIconGizmo2 = _003C_003E4__this;
			Transform transform2 = overheadIconGizmo2._TextValue.transform;
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((_003C_003Ec__DisplayClass6_0)(object)transform2).offsetObj == null;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected((IntPtr)((_003C_003Ec__DisplayClass6_0)(object)transform2).offsetObj, ref value2);
		}

		internal void _003CPlay_003Eb__2()
		{
			TweenCallback callback = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				callback = (_003C_003E9__3 = delegate
				{
					//IL_0038: Expected O, but got I
					Component component = _003C_003E4__this;
					GameObject gameObject = _003C_003E4__this.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (UnityEngine.Component)+28]");
					((ObjectPool)0).Release(gameObject);
					offsetObj = null;
				});
			}
			Tween tween = DOVirtual.DelayedCall(0.1f, callback, ignoreTimeScale: false);
		}

		internal void _003CPlay_003Eb__3()
		{
			//IL_0038: Expected O, but got I
			Component component = _003C_003E4__this;
			GameObject gameObject = _003C_003E4__this.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (UnityEngine.Component)+28]");
			((ObjectPool)0).Release(gameObject);
			offsetObj = null;
		}
	}

	private SpriteRenderer _Icon;

	private GenericShadowText _TextValue;

	public SpriteRenderer Icon => _Icon;

	public GenericShadowText TextValue => _TextValue;

	public unsafe void Play(string frameName, string value, Color? color, VampireSurvivors.Objects.Characters.CharacterController character, float displayTimeMultiplier = 1f, Vector2 vOffset = default(Vector2), string textureName = "items")
	{
		//IL_0008: Expected O, but got Ref
		//IL_0c27: Expected O, but got I
		//IL_0031: Expected O, but got I
		//IL_0046: Expected F4, but got I
		//IL_00bf: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Expected O, but got Unknown
		//IL_01c0: Expected O, but got Ref
		//IL_0310: Expected O, but got I
		//IL_0364: Expected O, but got I
		//IL_03f8: Expected O, but got I
		//IL_063e: Expected I, but got O
		//IL_064c: Expected O, but got Ref
		//IL_043e: Expected O, but got I
		//IL_03c3: Expected O, but got Ref
		//IL_0d5b: Expected O, but got I
		//IL_04cc: Expected O, but got I
		//IL_0512: Expected O, but got I
		//IL_0497: Expected O, but got Ref
		//IL_0da3: Expected O, but got I
		//IL_05a1: Expected O, but got I
		//IL_05e7: Expected O, but got I
		//IL_056b: Expected O, but got Ref
		//IL_0dd6: Expected O, but got Ref
		//IL_0e2b: Expected O, but got Ref
		//IL_0ed5: Expected O, but got Ref
		//IL_0f34: Expected O, but got Ref
		//IL_08e8: Expected I, but got O
		//IL_0964: Expected I, but got O
		//IL_09e0: Expected I, but got O
		//IL_0a37: Expected I, but got O
		//IL_0ab6: Expected O, but got I
		//IL_0af5: Expected O, but got Ref
		//IL_0c77->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0179->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0cf6->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_025a->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0289->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_02b2->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_033c->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0d33->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0384->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0631->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0680->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_03e2->IL0d38: Incompatible stack heights: 1 vs 2
		//IL_0d7b->IL0bdf: Incompatible stack heights: 2 vs 0
		//IL_06e5->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0707->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_04b6->IL0d80: Incompatible stack heights: 2 vs 3
		//IL_0742->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0dc3->IL0bdf: Incompatible stack heights: 3 vs 0
		//IL_0764->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_0793->IL0bdf: Incompatible stack heights: 1 vs 0
		//IL_058b->IL0dc8: Incompatible stack heights: 3 vs 4
		//IL_0df0->IL0d19: Incompatible stack heights: 4 vs 1
		//IL_0ea1->IL0bdf: Incompatible stack heights: 2 vs 0
		//IL_07d6->IL0bdf: Incompatible stack heights: 2 vs 0
		//IL_080c->IL0bdf: Incompatible stack heights: 2 vs 0
		//IL_090b->IL090b: Incompatible stack heights: 9 vs 8
		//IL_0987->IL0987: Incompatible stack heights: 10 vs 9
		//IL_0a03->IL0a03: Incompatible stack heights: 11 vs 10
		//IL_0a5a->IL0a5a: Incompatible stack heights: 11 vs 10
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals43 = new _003C_003Ec__DisplayClass6_0();
		GenericShadowText textValue2;
		if (CS_0024_003C_003E8__locals43 != null)
		{
			CS_0024_003C_003E8__locals43._003C_003E4__this = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
			CS_0024_003C_003E8__locals43.character = (VampireSurvivors.Objects.Characters.CharacterController)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
			CS_0024_003C_003E8__locals43.vOffset = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			CS_0024_003C_003E8__locals43.displayTimeMultiplier = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+73]");
			_ = 0;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_Icon, 1f);
			string icon = (string)(object)_Icon;
			if ((object)_Icon != null)
			{
				bool flag = icon._stringLength == 0;
				Renderer.set_sortingOrder_Injected((IntPtr)icon._stringLength, 1);
				if ((object)_Icon != null)
				{
					((UnityEngine.Object)_Icon).SetName("OverheadIcon");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+77]");
					string text = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+77]");
					Sprite sprite;
					if ((nint)0 != 0 && text._stringLength > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+77]");
						sprite = SpriteManager.GetSprite(frameName, (string)0);
						ref int reference = ref *(int*)null;
					}
					else
					{
						sprite = SpriteManager.GetUnpackedSprite(frameName);
						ref int reference = ref *(int*)6603577472L;
					}
					if ((object)_Icon != null)
					{
						_Icon.sprite = sprite;
						bool flag2 = value == null;
						string text2 = value;
						if (!flag2)
						{
							object obj3 = value + 20;
							_ = value._stringLength;
							_ = 0;
							NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
							ref int reference = ref System.Runtime.CompilerServices.Unsafe.As<object, int>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 113));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
							_ = 0;
							ReadOnlySpan<char> value2 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
							bool flag3 = System.Number.TryParseInt32(value2, NumberStyles.Integer, currentInfo, out reference);
							bool flag4 = !flag3;
							text2 = value;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-71]");
								bool flag5 = (nint)0 <= (nint)0;
								string text3 = "";
								if (!flag5)
								{
									text3 = "+";
								}
								string text4 = text3 + value;
								text2 = text4;
							}
						}
						object textValue = _TextValue;
						if ((object)_TextValue != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v21 (System.Object)+20]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rbx_v21 (System.Object)+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
									if ((object)_TextValue != null)
									{
										_TextValue.SetDepth(3100);
										textValue2 = _TextValue;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [color @ r9 (System.Nullable`1<UnityEngine.Color>)+10]");
										_ = 0;
										if ((object)color != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-4D]");
											object obj4 = 0;
											goto IL_0d19;
										}
										List<Color> list = new List<Color>();
										if (list != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
											object obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
												nint num = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v92+18]");
												if (num >= 0)
												{
													Color item = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FD0]");
													_ = 0;
													list.AddWithResize(item);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
													object obj6 = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
													nint num2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v92+18]");
													bool flag6 = num2 >= 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
													object obj7 = (nint)0 + (nint)2;
													object obj8 = obj7 + obj7;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FD0]");
													_ = 0;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
												object obj9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
													nint num3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v94+18]");
													if (num3 >= 0)
													{
														Color item2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
														_ = 0;
														list.AddWithResize(item2);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
														object obj10 = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
														nint num4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v94+18]");
														bool flag7 = num4 >= 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
														object obj11 = (nint)0 + (nint)2;
														object obj12 = obj11 + obj11;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
														_ = 0;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
													object obj13 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
														nint num5 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v96+18]");
														if (num5 >= 0)
														{
															Color item3 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
															_ = 0;
															list.AddWithResize(item3);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
															object obj14 = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
															nint num6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v96+18]");
															bool flag8 = num6 >= 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rax_v155 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
															object obj15 = (nint)0 + (nint)2;
															object obj16 = obj15 + obj15;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
															_ = 0;
														}
														List<Color> list2 = (List<Color>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
														list2.Add((Color)list);
														object obj17 = default(object);
														object obj4 = obj17;
														goto IL_0d19;
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
		goto IL_0bdf;
		IL_0bdf:
		throw new NullReferenceException();
		IL_0d19:
		if ((object)_TextValue != null)
		{
			TextMeshPro text5 = textValue2._Text;
			if ((object)textValue2._Text != null)
			{
				nint num7 = (nint)text5;
				Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
				textValue2._Text.color = color2;
				if ((object)CS_0024_003C_003E8__locals43.character != null)
				{
					float2 displaySizeSafe = CS_0024_003C_003E8__locals43.character.displaySizeSafe;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-5D]");
					float num8 = (CS_0024_003C_003E8__locals43.offset = 0f + 0.08f);
					GenericShadowText textValue3 = _TextValue;
					if ((object)_TextValue != null && (object)textValue3._Text != null)
					{
						float preferredWidth = textValue3._Text.preferredWidth;
						GenericShadowText textValue4 = _TextValue;
						if ((object)_TextValue != null && (object)textValue4._Text != null)
						{
							Transform transform = textValue4._Text.transform;
							if ((object)transform != null)
							{
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v68 (UnityEngine.Transform)+10]");
								bool flag9 = (nint)0 == 0;
								object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v68 (UnityEngine.Transform)+10]");
								Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj18);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-61]");
								float num9 = 0f * num8;
								float num10 = num9 + 0.16f;
								float width = num10 * 0.5f;
								CS_0024_003C_003E8__locals43.width = width;
								if ((object)CS_0024_003C_003E8__locals43.character != null)
								{
									float2 position = CS_0024_003C_003E8__locals43.character.position;
									if ((object)CS_0024_003C_003E8__locals43.character != null)
									{
										float2 position2 = CS_0024_003C_003E8__locals43.character.position;
										if ((object)_Icon != null)
										{
											Transform transform2 = _Icon.transform;
											bool flag10 = (object)transform2 == null;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1835 @ rax_v76 (UnityEngine.Transform)+10]");
											bool flag11 = (nint)0 == 0;
											object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1835 @ rax_v76 (UnityEngine.Transform)+10]");
											Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj19);
											bool flag12 = (object)_TextValue == null;
											Transform transform3 = _TextValue.transform;
											bool flag13 = (object)transform3 == null;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v81 (UnityEngine.Transform)+10]");
											bool flag14 = (nint)0 == 0;
											object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v81 (UnityEngine.Transform)+10]");
											Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj20);
											OverheadIconOffsetY offsetObj = new OverheadIconOffsetY();
											CS_0024_003C_003E8__locals43.offsetObj = offsetObj;
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[4];
											bool flag15 = array == null;
											if ((object)_Icon != null)
											{
												nint num11 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj21 = default(object);
												bool flag16 = obj21 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											GenericShadowText textValue5 = _TextValue;
											bool flag17 = (object)_TextValue == null;
											if ((object)textValue5._Text != null)
											{
												nint num12 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj22 = default(object);
												bool flag18 = obj22 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											GenericShadowText textValue6 = _TextValue;
											bool flag19 = (object)_TextValue == null;
											if ((object)textValue6._ShadowText != null)
											{
												nint num13 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj23 = default(object);
												bool flag20 = obj23 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (CS_0024_003C_003E8__locals43.offsetObj != null)
											{
												nint num14 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj24 = default(object);
												bool flag21 = obj24 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag22 = tweenConfig == null;
											tweenConfig.targets = array;
											_ = 0;
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-61]");
											tweenConfig.alpha = (float?)(object)0;
											float duration = CS_0024_003C_003E8__locals43.displayTimeMultiplier * 1000f;
											tweenConfig.duration = duration;
											Dictionary<string, object> dictionary = new Dictionary<string, object>();
											object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
											_ = 1107296256;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											bool flag23 = dictionary == null;
											object value3 = default(object);
											bool flag24 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"IconYOffset", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											tweenConfig.custom = dictionary;
											TweenCallback onStart = delegate
											{
												OverheadIconOffsetY offsetObj2 = CS_0024_003C_003E8__locals43.offsetObj;
												if (CS_0024_003C_003E8__locals43.offsetObj != null)
												{
													offsetObj2.IconYOffset = 0f;
													OverheadIconGizmo overheadIconGizmo = CS_0024_003C_003E8__locals43._003C_003E4__this;
													if ((object)CS_0024_003C_003E8__locals43._003C_003E4__this != null)
													{
														SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(overheadIconGizmo._Icon, 1f);
														OverheadIconGizmo overheadIconGizmo2 = CS_0024_003C_003E8__locals43._003C_003E4__this;
														if ((object)CS_0024_003C_003E8__locals43._003C_003E4__this != null && (object)overheadIconGizmo2._Icon != null)
														{
															overheadIconGizmo2._Icon.enabled = true;
															OverheadIconGizmo overheadIconGizmo3 = CS_0024_003C_003E8__locals43._003C_003E4__this;
															if ((object)CS_0024_003C_003E8__locals43._003C_003E4__this != null && (object)overheadIconGizmo3._TextValue != null)
															{
																overheadIconGizmo3._TextValue.SetAlpha(1f);
																OverheadIconGizmo overheadIconGizmo4 = CS_0024_003C_003E8__locals43._003C_003E4__this;
																if ((object)CS_0024_003C_003E8__locals43._003C_003E4__this != null && (object)overheadIconGizmo4._TextValue != null)
																{
																	overheadIconGizmo4._TextValue.enabled = true;
																	if ((object)CS_0024_003C_003E8__locals43.character != null)
																	{
																		float2 position3 = CS_0024_003C_003E8__locals43.character.position;
																		if ((object)CS_0024_003C_003E8__locals43.character != null)
																		{
																			float2 position4 = CS_0024_003C_003E8__locals43.character.position;
																			OverheadIconGizmo overheadIconGizmo5 = CS_0024_003C_003E8__locals43._003C_003E4__this;
																			if ((object)CS_0024_003C_003E8__locals43._003C_003E4__this != null && (object)overheadIconGizmo5._Icon != null)
																			{
																				Transform transform4 = overheadIconGizmo5._Icon.transform;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v27 (UnityEngine.Transform)+10]");
																				bool flag25 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v27 (UnityEngine.Transform)+10]");
																				Vector3 value4 = default(Vector3);
																				Transform.set_position_Injected((IntPtr)0, ref value4);
																				OverheadIconGizmo overheadIconGizmo6 = CS_0024_003C_003E8__locals43._003C_003E4__this;
																				Transform transform5 = overheadIconGizmo6._TextValue.transform;
																				bool flag26 = (object)transform5 == null;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v32 (UnityEngine.Transform)+10]");
																				bool flag27 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v32 (UnityEngine.Transform)+10]");
																				Vector3 value5 = default(Vector3);
																				Transform.set_position_Injected((IntPtr)0, ref value5);
																				return;
																			}
																		}
																	}
																}
															}
														}
													}
												}
												throw new NullReferenceException();
											};
											tweenConfig.onStart = onStart;
											TweenCallback onUpdate = delegate
											{
												//IL_00fc: Expected I, but got O
												float2 position3 = CS_0024_003C_003E8__locals43.character.position;
												float2 position4 = CS_0024_003C_003E8__locals43.character.position;
												OverheadIconGizmo overheadIconGizmo = CS_0024_003C_003E8__locals43._003C_003E4__this;
												Transform transform4 = overheadIconGizmo._Icon.transform;
												bool flag25 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												Vector3 value4 = default(Vector3);
												Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value4);
												OverheadIconGizmo overheadIconGizmo2 = CS_0024_003C_003E8__locals43._003C_003E4__this;
												Transform transform5 = overheadIconGizmo2._TextValue.transform;
												bool flag26 = (object)transform5 == null;
												bool flag27 = ((_003C_003Ec__DisplayClass6_0)(object)transform5).offsetObj == null;
												Vector3 value5 = default(Vector3);
												Transform.set_position_Injected((IntPtr)((_003C_003Ec__DisplayClass6_0)(object)transform5).offsetObj, ref value5);
											};
											tweenConfig.onUpdate = onUpdate;
											TweenCallback onComplete = delegate
											{
												TweenCallback callback = CS_0024_003C_003E8__locals43._003C_003E9__3;
												if (CS_0024_003C_003E8__locals43._003C_003E9__3 == null)
												{
													callback = (CS_0024_003C_003E8__locals43._003C_003E9__3 = delegate
													{
														//IL_0038: Expected O, but got I
														Component component = CS_0024_003C_003E8__locals43._003C_003E4__this;
														GameObject obj26 = CS_0024_003C_003E8__locals43._003C_003E4__this.gameObject;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1 (UnityEngine.Component)+28]");
														((ObjectPool)0).Release(obj26);
														CS_0024_003C_003E8__locals43.offsetObj = null;
													});
												}
												Tween tween = DOVirtual.DelayedCall(0.1f, callback, ignoreTimeScale: false);
											};
											tweenConfig.onComplete = onComplete;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
		goto IL_0bdf;
	}

	public OverheadIconGizmo()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
