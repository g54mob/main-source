using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

public class SpriteReel : MonoBehaviour
{
	private Texture2D _generatedTexture;

	private float _Speed;

	private float yVal;

	private int _padding;

	private void Start()
	{
	}

	public unsafe void Build(Sprite s)
	{
		//IL_0008: Expected O, but got Ref
		//IL_035f: Expected O, but got Ref
		//IL_03b5: Expected O, but got Ref
		//IL_040b: Expected O, but got Ref
		//IL_0461: Expected O, but got Ref
		//IL_012a: Expected O, but got Ref
		//IL_0158: Expected O, but got I
		//IL_04b7: Expected O, but got Ref
		//IL_04e0: Expected O, but got I
		//IL_0222: Expected O, but got I
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_031f: Expected O, but got I
		//IL_02cd: Invalid comparison between O and F4
		//IL_02ec: Invalid comparison between O and F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Texture2D texture = s.texture;
		_generatedTexture = texture;
		RawImage component = GetComponent<RawImage>();
		Texture2D texture2 = s.texture;
		component.texture = texture2;
		Material materialForRendering = component.materialForRendering;
		_ = 0;
		bool flag = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Sprite.get_rect_Injected(((UnityEngine.Object)s).m_CachedPtr, out *(Rect*)obj3);
		Texture2D texture3 = s.texture;
		int width = texture3.width;
		_ = 0;
		bool flag2 = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Sprite.get_rect_Injected(((UnityEngine.Object)s).m_CachedPtr, out *(Rect*)obj4);
		Texture2D texture4 = s.texture;
		int height = texture4.height;
		_ = 0;
		bool flag3 = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Sprite.get_rect_Injected(((UnityEngine.Object)s).m_CachedPtr, out *(Rect*)obj5);
		Texture2D texture5 = s.texture;
		int width2 = texture5.width;
		_ = 0;
		bool flag4 = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Sprite.get_rect_Injected(((UnityEngine.Object)s).m_CachedPtr, out *(Rect*)obj6);
		Texture2D texture6 = s.texture;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		int num = (int)((nint)0 / (nint)width);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
		int num2 = (int)((nint)0 / (nint)width2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
		int num3 = (int)((nint)0 / (nint)height);
		int height2 = texture6.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-D]");
		int num4 = (int)((nint)0 / (nint)height2);
		Vector4 value = (Vector4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
		((Material)0).SetVector("_SpriteRect", value);
		Material materialForRendering2 = component.materialForRendering;
		Texture2D texture7 = s.texture;
		int height3 = texture7.height;
		int num5 = Shader.PropertyToID("_YPadding");
		float value2 = (float)_padding / (float)height3;
		materialForRendering2.SetFloatImpl(num5, value2);
		component.SetMaterialDirty();
		_ = 0;
		bool flag5 = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Sprite.get_rect_Injected(((UnityEngine.Object)s).m_CachedPtr, out *(Rect*)obj7);
		int padding = _padding;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
		object obj8 = (nint)padding + (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
		float num6 = 0f / (float)obj8;
		yVal = num6;
		RectTransform component2 = GetComponent<RectTransform>();
		Vector2 sizeDelta = component2.sizeDelta;
		RectTransform component3 = GetComponent<RectTransform>();
		Vector2 sizeDelta2 = component3.sizeDelta;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+73]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7F]");
		object obj9 = num7 / 0;
		_ = 0;
		_ = 1065353216;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
		object obj10 = 0 / obj8;
		float num8 = (yVal = (float)obj10 * (float)obj9);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362DA2h\"");
		if ((object)component.m_UVRect == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362DA2h\"");
			Rect rect = default(Rect);
			if ((object)rect == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362DA2h\"");
				if ((object)rect == (object)1f)
				{
					bool flag6 = (object)rect == (object)num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362DA2h\"");
					if (flag6)
					{
						return;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		component.m_UVRect = (Rect)0;
		component.SetVerticesDirty();
	}

	private void Update()
	{
		//IL_00c8: Expected O, but got F4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00a2: Expected O, but got I4
		//IL_0055: Invalid comparison between O and F4
		//IL_0076: Invalid comparison between O and F4
		RawImage component = GetComponent<RawImage>();
		component.texture = _generatedTexture;
		object obj = Time.deltaTime;
		object obj3 = default(object);
		object obj2 = obj3 * _Speed;
		Rect rect = default(Rect);
		object obj4 = obj2 + (object)rect;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362FBBh\"");
		if ((object)component.m_UVRect == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362FBBh\"");
			if ((object)rect == obj4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362FBBh\"");
				if ((object)rect == (object)1f)
				{
					bool flag = (object)rect == (object)yVal;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187362FBBh\"");
					if (flag)
					{
						return;
					}
				}
			}
		}
		component.m_UVRect = (Rect)0;
		component.SetVerticesDirty();
	}

	public SpriteReel()
	{
		//IL_0020: Expected I, but got O
		_padding = 5;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
