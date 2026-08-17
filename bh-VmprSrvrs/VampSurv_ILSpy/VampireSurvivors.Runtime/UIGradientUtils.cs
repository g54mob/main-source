using System;
using Cpp2ILInjected;
using UnityEngine;

public static class UIGradientUtils
{
	public struct Matrix2x3
	{
		public float m00;

		public float m01;

		public float m02;

		public float m10;

		public float m11;

		public float m12;

		public Matrix2x3(float m00, float m01, float m02, float m10, float m11, float m12)
		{
			float num = default(float);
			this.m10 = num;
			this.m00 = m00;
			float num2 = default(float);
			this.m12 = num2;
			this.m01 = m01;
			this.m02 = m02;
			float num3 = default(float);
			this.m11 = num3;
		}

		public static Vector2 operator *(Matrix2x3 m, Vector2 v)
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	private static Vector2[] ms_verticesPositions;

	public static Vector2[] VerticePositions => ms_verticesPositions;

	public unsafe static Matrix2x3 LocalPositionMatrix(Rect rect, Vector2 dir)
	{
		//IL_004e: Expected native int or pointer, but got O
		//IL_008f: Expected native int or pointer, but got O
		//IL_00ec: Expected native int or pointer, but got O
		//IL_012c: Expected native int or pointer, but got O
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected F4, but got Unknown
		//IL_015d: Expected native int or pointer, but got O
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected F4, but got Unknown
		//IL_018f: Expected native int or pointer, but got O
		float m = (float)dir / rect.m_Width;
		float num = rect.m_XMin / rect.m_Width;
		float num2 = rect.m_YMin / rect.m_Height;
		Matrix2x3 matrix2x = default(Matrix2x3);
		((Matrix2x3*)(nint)matrix2x)->m00 = m;
		object obj = default(object);
		float m2 = (float)obj / rect.m_Height;
		float num3 = num + 0.5f;
		float num4 = num2 + 0.5f;
		((Matrix2x3*)(nint)matrix2x)->m01 = m2;
		float m3 = (float)dir / rect.m_Height;
		float num5 = (float)obj * num4;
		float num6 = (float)dir * num3;
		float num7 = (float)dir * num4;
		float num8 = num6 - num5;
		((Matrix2x3*)(nint)matrix2x)->m11 = m3;
		float m4 = (float)obj / rect.m_Width;
		float num9 = (float)obj * num3;
		float num10 = num8 - 0.5f;
		((Matrix2x3*)(nint)matrix2x)->m10 = m4;
		float num11 = num9 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float m5 = num10 ^ 0;
		((Matrix2x3*)(nint)matrix2x)->m02 = m5;
		float num12 = num11 - 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float m6 = num12 ^ 0;
		((Matrix2x3*)(nint)matrix2x)->m12 = m6;
		return matrix2x;
	}

	public static Vector2 RotationDir(float angle)
	{
		float num = angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public static Vector2 CompensateAspectRatio(Rect rect, Vector2 dir)
	{
		float num = rect.m_Height / rect.m_Width;
		object obj = default(object);
		float num2 = num * (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Vector2 result = default(Vector2);
		return result;
	}

	public static float InverseLerp(float a, float b, float v)
	{
		//IL_002f: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018695886Bh\"");
		if (a == b)
		{
			return 0f;
		}
		float num = v - a;
		float num2 = b - a;
		return num / num2;
	}

	public unsafe static Color Bilerp(Color a1, Color a2, Color b1, Color b2, Vector2 t)
	{
		//IL_0008: Expected native int or pointer, but got O
		Color color = default(Color);
		float r = default(float);
		((Color*)(nint)color)->r = r;
		return color;
	}

	public unsafe static void Lerp(UIVertex a, UIVertex b, float t, ref UIVertex c)
	{
		//IL_0027: Expected O, but got I
		//IL_008b: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ rdx (UnityEngine.UIVertex)+8]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (UnityEngine.UIVertex)+8]");
		object obj = num - 0;
		_ = a.position;
		_ = b.position;
		float num2 = (float)obj * t;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (UnityEngine.UIVertex)+8]");
		float num4 = num3 + 0f;
		object obj2 = default(object);
		ref UIVertex reference = ref *(UIVertex*)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ rdx (UnityEngine.UIVertex)+14]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (UnityEngine.UIVertex)+14]");
		object obj3 = num5 - 0;
		_ = a.normal;
		float num6 = (float)obj3 * t;
		float num7 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (UnityEngine.UIVertex)+14]");
		float num8 = num7 + 0f;
		_ = b.normal;
		Color32 color = Color32.LerpUnclamped(a.color, b.color, t);
	}

	static UIGradientUtils()
	{
		//IL_0090: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_00d6: Expected I, but got O
		//IL_00f9: Expected I, but got O
		Vector2[] array = new Vector2[4];
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_ = Vector2.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_ = Vector2.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
		_ = 0;
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v10 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		_ = Vector2.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		_ = 0;
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v12 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		_ = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v10 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		ms_verticesPositions = array;
	}
}
