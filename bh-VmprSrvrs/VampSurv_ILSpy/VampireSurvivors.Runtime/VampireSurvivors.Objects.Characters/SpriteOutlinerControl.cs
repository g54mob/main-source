using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SpriteOutlinerControl : MonoBehaviour
{
	private static readonly int SpriteRect;

	private MeshRenderer _meshRenderer;

	private bool _outlineOffsetNegative;

	public unsafe void ShowOutline(SpriteRenderer spriteRenderer, Color colour, bool matchRendererPosition = false)
	{
		//IL_0256: Expected O, but got I4
		//IL_01a9: Expected O, but got Ref
		//IL_0031->IL021f: Incompatible stack heights: 1 vs 0
		//IL_00bd->IL021f: Incompatible stack heights: 1 vs 0
		//IL_00e9->IL021f: Incompatible stack heights: 1 vs 0
		//IL_0115->IL021f: Incompatible stack heights: 1 vs 0
		//IL_013f->IL021f: Incompatible stack heights: 1 vs 0
		//IL_016b->IL021f: Incompatible stack heights: 1 vs 0
		//IL_0197->IL021f: Incompatible stack heights: 1 vs 0
		//IL_01d5->IL021f: Incompatible stack heights: 1 vs 0
		//IL_01f8->IL021f: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				GameObject gameObject2 = base.gameObject;
				if ((object)gameObject2 == null)
				{
					goto IL_021f;
				}
				gameObject2.SetActive(value: true);
			}
			GameObject meshRenderer = (GameObject)(object)_meshRenderer;
			if ((object)_meshRenderer == null || ((UnityEngine.Object)meshRenderer).m_CachedPtr == (IntPtr)0)
			{
				MeshRenderer component = GetComponent<MeshRenderer>();
				_meshRenderer = component;
			}
			if ((object)spriteRenderer != null)
			{
				Sprite sprite = spriteRenderer.sprite;
				if ((object)_meshRenderer != null)
				{
					Material material = ((Renderer)_meshRenderer).GetMaterial();
					if ((object)sprite != null)
					{
						Texture2D texture = sprite.texture;
						if ((object)material != null)
						{
							material.mainTexture = texture;
							if ((object)_meshRenderer != null)
							{
								Material material2 = ((Renderer)_meshRenderer).GetMaterial();
								if ((object)material2 != null)
								{
									object obj2 = default(object);
									material2.color = (Color)(&obj2);
									string sortingLayerName = spriteRenderer.sortingLayerName;
									if ((object)_meshRenderer != null)
									{
										_meshRenderer.sortingLayerName = sortingLayerName;
										Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 405 Invalid \"Jump target not found in method: 0x187564CF0\"");
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_021f;
		IL_021f:
		throw new NullReferenceException();
	}

	public unsafe void UpdateSprite(SpriteRenderer spriteRenderer, bool matchRendererPosition = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_02e0: Expected O, but got Ref
		//IL_0305: Expected O, but got Ref
		//IL_032a: Expected O, but got Ref
		//IL_034f: Expected O, but got Ref
		//IL_0100: Expected O, but got Ref
		//IL_03bf: Expected O, but got Ref
		//IL_03e4: Expected O, but got Ref
		//IL_043d: Expected O, but got Ref
		//IL_0462: Expected O, but got Ref
		//IL_04bd: Expected O, but got Ref
		//IL_04f4: Invalid comparison between I and F4
		//IL_0550: Expected O, but got Ref
		//IL_059b: Expected O, but got I8
		//IL_0630: Expected O, but got Ref
		//IL_0216: Expected O, but got I
		//IL_01b2: Expected O, but got I4
		//IL_023b: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_068a: Expected O, but got Ref
		//IL_06a0: Expected O, but got I
		//IL_05d8: Expected O, but got Ref
		//IL_05f0: Expected O, but got I
		//IL_0379->IL0263: Incompatible stack heights: 4 vs 0
		//IL_01f7->IL0263: Incompatible stack heights: 10 vs 0
		//IL_07c2->IL0263: Incompatible stack heights: 13 vs 0
		//IL_0262->IL0262: Incompatible stack heights: 13 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			if (!core._isGameRunning)
			{
				return;
			}
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				if (!gameObject.activeSelf)
				{
					return;
				}
				if ((object)spriteRenderer != null)
				{
					Sprite sprite = spriteRenderer.sprite;
					if ((object)_meshRenderer != null)
					{
						Material material = ((Renderer)_meshRenderer).GetMaterial();
						if ((object)sprite != null)
						{
							_ = 0;
							bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj3);
							_ = 0;
							bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj4);
							_ = 0;
							bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj5);
							_ = 0;
							bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj6);
							if ((object)material != null)
							{
								Vector4 value = (Vector4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-D]");
								_ = 0;
								material.SetVector(SpriteRect, value);
								if (spriteRenderer.flipX)
								{
								}
								Transform transform = base.transform;
								_ = 0;
								bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj7);
								_ = 0;
								bool flag6 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
								object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj8);
								bool flag7 = (object)transform == null;
								_ = 1f;
								bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
								Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj9);
								_ = 0;
								bool flag9 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
								object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj10);
								Vector2 pivot = sprite.pivot;
								_ = 0;
								bool flag10 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
								object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj11);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875652BFh\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
								if (0f == 1f)
								{
								}
								Transform transform2 = base.transform;
								bool num;
								bool num2;
								bool num3;
								if (matchRendererPosition)
								{
									Transform transform3 = spriteRenderer.transform;
									if ((object)transform3 == null)
									{
										goto IL_0263;
									}
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v129 (UnityEngine.Transform)+10]");
									bool flag11 = (nint)0 == 0;
									num = flag11;
									object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v129 (UnityEngine.Transform)+10]");
									Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj12);
									bool flag12 = (object)transform2 == null;
									num2 = flag12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
									object obj13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
									_ = 0;
									bool flag13 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									num3 = flag13;
									object obj14 = 0;
									object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									float num4 = 2f;
									object obj16 = (nint)((UnityEngine.Object)transform2).m_CachedPtr;
								}
								else
								{
									_ = 0;
									bool flag14 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
									num = flag14;
									object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
									Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj17);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-D]");
									float num5 = 0f * 0.01f;
									bool flag15 = _outlineOffsetNegative;
									object obj18 = 4294967295L;
									if (!flag15)
									{
										obj18 = 1;
									}
									float num6 = num5 * 0.5f;
									float num4 = num6 * (float)obj18;
									bool flag16 = (object)transform2 == null;
									num2 = flag16;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2156 @ rax_v124 (UnityEngine.Transform)+10]");
									bool flag17 = (nint)0 == 0;
									num3 = flag17;
									object obj14 = 0;
									object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
									object obj13 = obj18;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2156 @ rax_v124 (UnityEngine.Transform)+10]");
									object obj16 = 0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2387 @ rax_v125 (should have been resolved before IL gen)");
								int sortingOrder = spriteRenderer.sortingOrder;
								if ((object)_meshRenderer != null)
								{
									int sortingOrder2 = sortingOrder + 4000;
									_meshRenderer.sortingOrder = sortingOrder2;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0263;
		IL_0263:
		throw new NullReferenceException();
	}

	public void HideOutline()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public void SetOutlineOffsetNegative()
	{
		_outlineOffsetNegative = true;
	}

	public SpriteOutlinerControl()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static SpriteOutlinerControl()
	{
		int spriteRect = Shader.PropertyToID("_SpriteRect");
		SpriteRect = spriteRect;
	}
}
