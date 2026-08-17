using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Nothke.Utils;

public static class RTUtils
{
	private static Mesh quad;

	private static Shader blitShader;

	private static Material blitMaterial;

	private static RenderTexture prevRT;

	public static Mesh GetQuad()
	{
		//IL_027e: Expected I4, but got O
		//IL_02ca: Expected I4, but got O
		Mesh mesh = quad;
		if ((object)quad != null && ((UnityEngine.Object)mesh).m_CachedPtr != (IntPtr)0)
		{
			return quad;
		}
		Mesh mesh2 = new Mesh();
		Vector3[] array = new Vector3[4];
		if (array.Length > 0)
		{
			_ = 0;
			if (array.Length > 1)
			{
				_ = 0;
				if (array.Length > 2)
				{
					_ = 0;
					if (array.Length > 3)
					{
						_ = 0;
						int length = array.Length;
						Array values = default(Array);
						int valuesArrayLength = default(int);
						int valuesStart = default(int);
						int valuesCount = default(int);
						mesh2.SetSizedArrayForChannel(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, values, valuesArrayLength, valuesStart, valuesCount, (MeshUpdateFlags)array);
						mesh2.triangles = new int[6] { 0, 2, 1, 2, 3, 1 };
						Vector2[] array2 = new Vector2[4];
						if (array2.Length > 0)
						{
							_ = 0;
							if (array2.Length > 1)
							{
								_ = 1065353216;
								if (array2.Length > 2)
								{
									_ = 0;
									_ = 1065353216;
									if (array2.Length > 3)
									{
										_ = 1065353216;
										_ = 1065353216;
										int length2 = array2.Length;
										mesh2.SetSizedArrayForChannel(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2, values, valuesArrayLength, valuesStart, valuesCount, (MeshUpdateFlags)array2);
										quad = mesh2;
										return quad;
									}
								}
							}
						}
					}
				}
			}
		}
		return (Mesh)(object)new IndexOutOfRangeException();
	}

	public static Shader GetBlitShader()
	{
		Shader shader = blitShader;
		if ((object)blitShader == null || ((UnityEngine.Object)shader).m_CachedPtr == (IntPtr)0)
		{
			Shader shader2 = Shader.Find("Sprites/Default");
			if ((object)shader2 == null || ((UnityEngine.Object)shader2).m_CachedPtr == (IntPtr)0)
			{
				Debug.LogError("Sprites/Default shader not found, did you forget to include it in the project settings?");
			}
			blitShader = shader2;
		}
		return blitShader;
	}

	public static Material GetBlitMaterial()
	{
		Material material = blitMaterial;
		if ((object)blitMaterial != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
		{
			return blitMaterial;
		}
		Shader shader = GetBlitShader();
		return new Material(shader);
	}

	public unsafe static void BeginOrthoRendering(RenderTexture rt, float zBegin = -100f, float zEnd = 100f)
	{
		//IL_0035: Expected F4, but got I
		//IL_0035: Expected F4, but got O
		//IL_0035: Expected F4, but got O
		//IL_0035: Expected F4, but got Ref
		//IL_0042: Expected O, but got Ref
		_ = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		IntPtr intPtr = default(IntPtr);
		Matrix4x4.Ortho_Injected((float)(nint)(&obj), (float)obj2, (float)obj3, (float)(nint)intPtr, 0f, 1f, out *(Matrix4x4*)null);
		object obj4 = default(object);
		BeginRendering(rt, (Matrix4x4)(&obj4));
	}

	public unsafe static void BeginPixelRendering(RenderTexture rt, float zBegin = -100f, float zEnd = 100f)
	{
		//IL_002e: Expected I, but got O
		//IL_006f: Expected F4, but got I4
		//IL_006f: Expected F4, but got I
		//IL_006f: Expected F4, but got I
		//IL_006f: Expected F4, but got I
		//IL_006f: Expected F4, but got Ref
		//IL_007c: Expected O, but got Ref
		int width = rt.width;
		nint num = (nint)rt;
		int height = rt.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v5 (Il2CppClass<UnityEngine.RenderTexture>)+1B0]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v5 (Il2CppClass<UnityEngine.RenderTexture>)+1A8]");
		object obj = default(object);
		IntPtr intPtr = default(IntPtr);
		Matrix4x4.Ortho_Injected((float)(nint)(&obj), (float)num2, 0f, (float)(nint)intPtr, 0f, (float)width, out *(Matrix4x4*)null);
		object obj2 = default(object);
		BeginRendering(rt, (Matrix4x4)(&obj2));
	}

	public unsafe static void BeginPerspectiveRendering(RenderTexture rt, float fov, [In] ref Vector3 position, [In] ref Quaternion rotation, float zNear = 0.01f, float zFar = 1000f)
	{
		//IL_0017: Expected O, but got Ref
		//IL_003b: Expected I, but got O
		//IL_0056: Expected O, but got I4
		//IL_0077: Expected O, but got Ref
		//IL_00a0: Expected Ref, but got F4
		//IL_00a0: Expected F4, but got Ref
		//IL_00a0: Expected F4, but got I
		//IL_00a0: Expected F4, but got I
		//IL_00a0: Expected F4, but got O
		//IL_0160: Expected O, but got Ref
		//IL_016e: Expected O, but got Ref
		//IL_00d5: Expected O, but got Ref
		//IL_00f0: Expected O, but got Ref
		//IL_0136: Expected O, but got Ref
		//IL_0151: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int width = rt.width;
		nint num = (nint)rt;
		_ = 0;
		_ = 0;
		_ = 0;
		obj = 0;
		int height = rt.height;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v9 (Il2CppClass<UnityEngine.RenderTexture>)+1B0]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v9 (Il2CppClass<UnityEngine.RenderTexture>)+1A8]");
		Matrix4x4.Perspective_Injected((float)obj3, (float)num2, 0f, (float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref rotation), out *(Matrix4x4*)fov);
		_ = rotation;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		Vector3 pos = default(Vector3);
		Vector3 s = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos, ref *(Quaternion*)obj5, ref s, out *(Matrix4x4*)obj4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1+40]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		Matrix4x4 m = default(Matrix4x4);
		Matrix4x4.Inverse_Injected(ref m, out *(Matrix4x4*)obj6);
		Matrix4x4 matrix4x = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-10]");
		_ = 0;
		_ = (matrix4x * (Matrix4x4)(&m)).m03;
		BeginRendering(rt, (Matrix4x4)(&m));
	}

	public unsafe static void BeginRendering(RenderTexture rt, Matrix4x4 projectionMatrix)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ca: Expected O, but got I
		//IL_0038: Expected O, but got I
		//IL_02ef: Expected O, but got Ref
		//IL_0135: Expected O, but got Ref
		//IL_01e2: Expected O, but got Ref
		//IL_01f0: Expected O, but got Ref
		//IL_020b: Expected O, but got Ref
		//IL_0219: Expected O, but got Ref
		//IL_0293: Expected native int or pointer, but got O
		//IL_02a5: Expected native int or pointer, but got O
		//IL_02b7: Expected native int or pointer, but got O
		//IL_02c9: Expected native int or pointer, but got O
		//IL_02d3->IL00d8: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Camera current = Camera.current;
		bool flag = (object)current == null;
		IntPtr intPtr = default(IntPtr);
		Matrix4x4 matrix4x = (Matrix4x4)(nint)intPtr;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)current).m_CachedPtr == (IntPtr)0;
			matrix4x = (Matrix4x4)(nint)intPtr;
			if (!flag2)
			{
				Camera current2 = Camera.current;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)current2).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Camera.get_worldToCameraMatrix_Injected(((UnityEngine.Object)current2).m_CachedPtr, out *(Matrix4x4*)obj3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				Matrix4x4.Inverse_Injected(ref *(Matrix4x4*)obj5, out *(Matrix4x4*)obj4);
				matrix4x = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				Matrix4x4 matrix4x2 = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
				_ = 0;
				_ = projectionMatrix.m00;
				_ = projectionMatrix.m01;
				_ = projectionMatrix.m02;
				_ = projectionMatrix.m03;
				Matrix4x4 matrix4x3 = matrix4x2 * matrix4x;
				((Matrix4x4*)(nint)projectionMatrix)->m00 = matrix4x3.m00;
				((Matrix4x4*)(nint)projectionMatrix)->m01 = matrix4x3.m01;
				((Matrix4x4*)(nint)projectionMatrix)->m02 = matrix4x3.m02;
				((Matrix4x4*)(nint)projectionMatrix)->m03 = matrix4x3.m03;
			}
		}
		RenderTexture active = RenderTexture.GetActive();
		prevRT = active;
		IntPtr active_Injected = ((UnityEngine.Object)rt)?.m_CachedPtr ?? ((IntPtr)0);
		RenderTexture.SetActive_Injected(active_Injected);
		GL.PushMatrix();
		_ = projectionMatrix.m00;
		_ = projectionMatrix.m01;
		_ = projectionMatrix.m02;
		_ = projectionMatrix.m03;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		GL.LoadProjectionMatrix_Injected(ref *(Matrix4x4*)obj6);
	}

	public static void EndRendering(RenderTexture rt)
	{
		// ILSpy could not decompile this. Please report the exception below,
		// along with the assembly it came from, at https://github.com/icsharpcode/ILSpy/issues/new
		// System.IndexOutOfRangeException: Index was outside the bounds of the array.
		//    at ICSharpCode.Decompiler.IL.ILReader.ReadBlock(ImportedBlock block, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/IL/ILReader.cs:line 521
		//    at ICSharpCode.Decompiler.IL.ILReader.ReadInstructions(CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/IL/ILReader.cs:line 504
		//    at ICSharpCode.Decompiler.IL.ILReader.ReadIL(MethodDefinitionHandle method, MethodBodyBlock body, GenericContext genericContext, ILFunctionKind kind, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/IL/ILReader.cs:line 724
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext, ExtensionInfo extensionInfo) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 2282
	}

	public unsafe static void DrawMesh(RenderTexture rt, Mesh mesh, Material material, [In] ref Matrix4x4 objectMatrix, int pass = 0)
	{
		//IL_004f: Expected I4, but got I8
		//IL_004f: Expected O, but got Ref
		int pass2 = default(int);
		if (material.SetPass(pass2))
		{
			object obj = default(object);
			Graphics.DrawMeshNow(mesh, (Matrix4x4)(&obj), -1);
		}
	}

	public static void DrawTMPText(RenderTexture rt, TMP_Text text, [In] ref Vector2 position, float size)
	{
		int width = rt.width;
		int height = rt.height;
		Vector3 pos = default(Vector3);
		Quaternion q = default(Quaternion);
		Vector3 s = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos, ref q, ref s, out Matrix4x4 _);
		Material fontSharedMaterial = text.fontSharedMaterial;
		Mesh mesh = text.mesh;
		Matrix4x4 objectMatrix = default(Matrix4x4);
		int pass = default(int);
		DrawMesh(rt, mesh, fontSharedMaterial, ref objectMatrix, pass);
	}

	public static void DrawTMPText(RenderTexture rt, TMP_Text text, [In] ref Matrix4x4 matrix)
	{
		Material fontSharedMaterial = text.fontSharedMaterial;
		Mesh mesh = text.mesh;
		int pass = default(int);
		DrawMesh(rt, mesh, fontSharedMaterial, ref matrix, pass);
	}

	public static void BlitTMPText(RenderTexture rt, TMP_Text text, [In] ref Vector2 pos, float size, bool clear = true, Color clearColor = default(Color))
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 88;
		int width = rt.width;
		int height = rt.height;
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 pos2 = default(Vector3);
		Quaternion q = default(Quaternion);
		Vector3 s = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos2, ref q, ref s, out Matrix4x4 _);
		Material fontSharedMaterial = text.fontSharedMaterial;
		Mesh mesh = text.mesh;
		Matrix4x4 objectMatrix = (Matrix4x4)(obj - 80);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-60]");
		_ = 0;
		bool invertCulling = default(bool);
		bool clear2 = default(bool);
		Color clearColor2 = default(Color);
		BlitMesh(rt, objectMatrix, mesh, fontSharedMaterial, invertCulling, clear2, clearColor2);
	}

	public unsafe static void BlitTMPText(RenderTexture rt, TMP_Text text, Matrix4x4 objectMatrix, bool clear = true, Color clearColor = default(Color))
	{
		//IL_0054: Expected O, but got Ref
		Material fontSharedMaterial = text.fontSharedMaterial;
		Mesh mesh = text.mesh;
		object obj = default(object);
		bool invertCulling = default(bool);
		bool clear2 = default(bool);
		Color clearColor2 = default(Color);
		BlitMesh(rt, (Matrix4x4)(&obj), mesh, fontSharedMaterial, invertCulling, clear2, clearColor2);
	}

	public unsafe static void BlitMesh(RenderTexture rt, Matrix4x4 objectMatrix, Mesh mesh, Material material, bool invertCulling = true, bool clear = true, Color clearColor = default(Color))
	{
		//IL_0008: Expected O, but got Ref
		//IL_038e: Expected O, but got Ref
		//IL_03ae: Expected F4, but got O
		//IL_03ae: Expected F4, but got O
		//IL_03ae: Expected F4, but got O
		//IL_03ae: Expected F4, but got O
		//IL_03be: Expected F4, but got I
		//IL_03ce: Expected F4, but got I
		//IL_03de: Expected F4, but got I
		//IL_03ee: Expected F4, but got I
		//IL_01e0: Expected F4, but got I4
		//IL_004a: Expected F4, but got I4
		//IL_020e: Expected O, but got I4
		//IL_04d8: Expected O, but got Ref
		//IL_040a: Expected O, but got Ref
		//IL_0425: Expected O, but got Ref
		//IL_044c: Expected F4, but got I
		//IL_045c: Expected F4, but got I
		//IL_0469: Expected O, but got Ref
		//IL_04b1: Expected O, but got I
		//IL_04f9: Expected O, but got I4
		//IL_00dd: Expected O, but got I
		//IL_00e5: Expected F4, but got O
		//IL_0320: Expected F4, but got O
		//IL_0129: Expected I4, but got I8
		//IL_0129: Expected O, but got Ref
		//IL_0136: Expected O, but got Ref
		//IL_0143: Expected I4, but got I8
		//IL_037b: Expected O, but got I
		//IL_04bc->IL01f7: Incompatible stack heights: 1 vs 0
		Matrix4x4 ret = default(Matrix4x4);
		object obj = (object)(&ret);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref ret, 64));
		Matrix4x4.Ortho_Injected((float)obj2, (float)objectMatrix, (float)mesh, (float)material, 0f, 1f, out *(Matrix4x4*)null);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		float num = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		float num3 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		float num4 = 0f;
		Camera current = Camera.current;
		bool flag = (object)current == null;
		float num5 = 1f;
		Material material2 = material;
		float num6 = 0f;
		Matrix4x4 matrix4x = (Matrix4x4)mesh;
		Matrix4x4 ret2 = default(Matrix4x4);
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)current).m_CachedPtr == (IntPtr)0;
			num5 = 1f;
			material2 = material;
			num6 = 0f;
			matrix4x = (Matrix4x4)mesh;
			if (!flag2)
			{
				Camera current2 = Camera.current;
				obj = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)current2).m_CachedPtr == (IntPtr)0;
				Camera.get_worldToCameraMatrix_Injected(((UnityEngine.Object)current2).m_CachedPtr, out ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
				_ = 0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref ret, 128));
				Matrix4x4.Inverse_Injected(ref *(Matrix4x4*)obj3, out ret2);
				matrix4x = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref ret, 128));
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
				num6 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
				num5 = 0f;
				Matrix4x4 matrix4x2 = (Matrix4x4)(&ret2) * matrix4x;
				num = matrix4x2.m00;
				num2 = matrix4x2.m01;
				num3 = matrix4x2.m02;
				num4 = matrix4x2.m03;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
				ret2 = (Matrix4x4)0;
				material2 = null;
			}
		}
		RenderTexture active = RenderTexture.GetActive();
		IntPtr active_Injected = ((UnityEngine.Object)rt)?.m_CachedPtr ?? ((IntPtr)0);
		RenderTexture.SetActive_Injected(active_Injected);
		bool flag4 = material.SetPass(0);
		GL.PushMatrix();
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref ret, 128));
		GL.LoadProjectionMatrix_Injected(ref *(Matrix4x4*)obj4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
		GL.invertCulling = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		bool flag5 = (nint)0 == 0;
		float num7 = 1f;
		int num8 = 0;
		int num9 = 0;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
			object obj5 = 0;
			num6 = (float)obj5;
			num9 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref ret, 64));
			GL.GLClear_Injected(true, true, ref *(Color*)num9, (float)material2);
			num7 = 1f;
			num8 = 1;
		}
		bool flag6 = !flag4;
		Matrix4x4 matrix4x3 = (Matrix4x4)num8;
		if (!flag6)
		{
			num6 = objectMatrix.m02;
			num5 = objectMatrix.m03;
			Graphics.DrawMeshNow(mesh, (Matrix4x4)(&ret2), -1);
			material2 = null;
			matrix4x3 = (Matrix4x4)(&ret2);
			num9 = -1;
		}
		GL.PopMatrix();
		GL.invertCulling = false;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rcx_v29 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag7 = (object)active == null;
		nint num11 = 0;
		if (!flag7)
		{
			num11 = ((UnityEngine.Object)active).m_CachedPtr;
		}
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v1471 @ rax_v41 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 233 ConditionalJump @-1, v633 @ ZF_v53 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public static void DrawQuad(RenderTexture rt, Material material, [In] ref Rect rect)
	{
		Vector3 pos = default(Vector3);
		Quaternion q = default(Quaternion);
		Vector3 s = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos, ref q, ref s, out Matrix4x4 _);
		Mesh mesh = GetQuad();
		Matrix4x4 objectMatrix = default(Matrix4x4);
		int pass = default(int);
		DrawMesh(rt, mesh, material, ref objectMatrix, pass);
	}

	public static void DrawSprite(RenderTexture rt, Texture texture, [In] ref Rect rect)
	{
		Material material = blitMaterial;
		Material material2;
		if ((object)blitMaterial != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
		{
			material2 = blitMaterial;
		}
		else
		{
			Shader shader = GetBlitShader();
			Material material3 = new Material(shader);
			material2 = material3;
		}
		material2.mainTexture = texture;
		Vector3 pos = default(Vector3);
		Quaternion q = default(Quaternion);
		Vector3 s = default(Vector3);
		Matrix4x4.TRS_Injected(ref pos, ref q, ref s, out Matrix4x4 _);
		Mesh mesh = GetQuad();
		Matrix4x4 objectMatrix = default(Matrix4x4);
		int pass = default(int);
		DrawMesh(rt, mesh, material2, ref objectMatrix, pass);
	}

	public static float Aspect(Texture rt)
	{
		int width = rt.width;
		int height = rt.height;
		return (float)width / (float)height;
	}

	public unsafe static Texture2D ConvertToTexture2D(RenderTexture rt, TextureFormat format = TextureFormat.RGB24, FilterMode filterMode = FilterMode.Bilinear)
	{
		//IL_0045: Expected O, but got I4
		//IL_013c: Expected O, but got Ref
		int width = rt.width;
		int height = rt.height;
		int mipCount = default(int);
		bool linear = default(bool);
		IntPtr nativeTex = default(IntPtr);
		bool createUninitialized = default(bool);
		Texture2D texture2D = new Texture2D(width, height, format, mipCount, linear, nativeTex, createUninitialized, (MipmapLimitDescriptor)1);
		texture2D.filterMode = filterMode;
		RenderTexture active = RenderTexture.GetActive();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v17 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		RenderTexture.SetActive_Injected(((UnityEngine.Object)rt).m_CachedPtr);
		int width2 = rt.width;
		int height2 = rt.height;
		object obj = default(object);
		texture2D.ReadPixels((Rect)(&obj), 0, 0);
		texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v25 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag = (object)active == null;
		nint active_Injected = 0;
		if (!flag)
		{
			active_Injected = ((UnityEngine.Object)active).m_CachedPtr;
		}
		RenderTexture.SetActive_Injected((IntPtr)active_Injected);
		return texture2D;
	}

	public unsafe static void DrawTextureGUI(Texture texture)
	{
		//IL_0031: Expected O, but got Ref
		int width = texture.width;
		int height = texture.height;
		object obj = default(object);
		GUI.DrawTexture((Rect)(&obj), texture);
	}
}
