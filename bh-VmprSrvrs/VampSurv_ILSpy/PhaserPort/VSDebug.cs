using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class VSDebug
{
	private static Material _debugMat;

	private static Mesh _debugMesh;

	private static List<Vector3> _debugLineVerts;

	private static List<Color> _debugLineColours;

	private static List<int> _debugLineIndices;

	public static bool s_drawDebug;

	public static void Init()
	{
		//IL_021b: Expected I4, but got O
		//IL_021b: Expected I4, but got O
		//IL_0220->IL0194: Incompatible stack heights: 1 vs 0
		Mesh debugMesh = new Mesh();
		_debugMesh = debugMesh;
		Shader shader = Shader.Find("Hidden/Internal-Colored");
		Material debugMat = new Material(shader);
		_debugMat = debugMat;
		if ((object)_debugMat != null)
		{
			int name = Shader.PropertyToID("_ZTest");
			_debugMat.SetFloatImpl(name, 0f);
			Material debugMesh2 = (Material)(object)_debugMesh;
			ushort[] array = new ushort[0];
			if ((object)_debugMesh != null)
			{
				int length2;
				if (array != null)
				{
					int length = array.Length;
					length2 = length;
				}
				else
				{
					length2 = 0;
				}
				if (_debugMesh.CheckCanAccessSubmesh(0, false))
				{
					int valuesLength = array?.Length ?? 0;
					_debugMesh.CheckIndicesArrayRange(valuesLength, 0, length2);
					bool flag = ((UnityEngine.Object)debugMesh2).m_CachedPtr == (IntPtr)0;
					object indices = default(object);
					object obj = default(object);
					object obj2 = default(object);
					Mesh.SetIndicesImpl_Injected(((UnityEngine.Object)debugMesh2).m_CachedPtr, 0, MeshTopology.Lines, IndexFormat.UInt16, (Array)indices, (int)obj, 0, (byte)(int)obj2 != 0, 0);
				}
				if ((object)_debugMesh != null)
				{
					_debugMesh.MarkDynamic();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static void FlushDebugLines(Vector3 offset)
	{
		//IL_00c9: Expected I4, but got I8
		//IL_00c9: Expected O, but got Ref
		//IL_00c9: Expected O, but got Ref
		List<Vector3> debugLineVerts = _debugLineVerts;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		if ((nint)0 != 0)
		{
			_debugMesh.ClearImpl(true);
			_debugMesh.SetVertices(_debugLineVerts);
			_debugMesh.SetColors(_debugLineColours);
			bool calculateBounds = default(bool);
			int baseVertex = default(int);
			_debugMesh.SetIndices(_debugLineIndices, MeshTopology.Lines, 0, calculateBounds, baseVertex);
			bool flag = _debugMat.SetPass(0);
			object obj = default(object);
			object obj2 = default(object);
			Graphics.DrawMeshNow(_debugMesh, (Vector3)(&obj), (Quaternion)(&obj2), -1);
		}
	}

	public static void ClearDebugLines()
	{
		List<Vector3> debugLineVerts = _debugLineVerts;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<Color> debugLineColours = _debugLineColours;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v2 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<int> debugLineIndices = _debugLineIndices;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v3 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
	}

	public static void DrawDebugLine(float2 point1, float2 point2)
	{
		//IL_001e: Expected F4, but got O
		//IL_001e: Expected F4, but got O
		float y = default(float);
		float y2 = default(float);
		Color colour = default(Color);
		DrawDebugLine((float)point1, y, (float)point2, y2, colour);
	}

	public static void DrawDebugLine(float2 point1, float2 point2, Color colour)
	{
		//IL_001e: Expected F4, but got O
		//IL_001e: Expected F4, but got O
		float y = default(float);
		float y2 = default(float);
		Color colour2 = default(Color);
		DrawDebugLine((float)point1, y, (float)point2, y2, colour2);
	}

	public static void DrawDebugLine(double x1, double y1, double x2, double y2)
	{
		Color colour = default(Color);
		DrawDebugLine(x1, y1, x2, y2, colour);
	}

	public static void DrawDebugLine(double x1, double y1, double x2, double y2, Color colour)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm3,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm2,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm9\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm8\"");
		Color colour2 = default(Color);
		DrawDebugLine(0f, 0f, 0f, 0f, colour2);
	}

	public unsafe static void DrawDebugLine(float x1, float y1, float x2, float y2, Color colour)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0190: Expected O, but got Ref
		//IL_01a3: Expected O, but got Ref
		//IL_01d4: Expected O, but got I
		//IL_023d: Expected O, but got I
		//IL_025d: Expected O, but got I
		//IL_0212: Expected O, but got Ref
		//IL_02a7: Expected O, but got I
		//IL_0300: Expected O, but got I
		//IL_0320: Expected O, but got I
		//IL_02e5: Expected O, but got Ref
		if (!s_drawDebug)
		{
			return;
		}
		object obj = x1 & -2147483649L;
		if ((nint)obj <= 2139095040)
		{
			object obj2 = x1 & -2147483649L;
			if ((nint)obj2 != 2139095040)
			{
				object obj3 = y1 & -2147483649L;
				if ((nint)obj3 <= 2139095040)
				{
					object obj4 = y1 & -2147483649L;
					if ((nint)obj4 != 2139095040)
					{
						object obj5 = x2 & -2147483649L;
						if ((nint)obj5 <= 2139095040)
						{
							object obj6 = x2 & -2147483649L;
							if ((nint)obj6 != 2139095040)
							{
								object obj7 = y2 & -2147483649L;
								if ((nint)obj7 <= 2139095040)
								{
									object obj8 = y2 & -2147483649L;
									if ((nint)obj8 != 2139095040)
									{
										object obj9 = default(object);
										_debugLineVerts.Add((Vector3)(&obj9));
										_debugLineVerts.Add((Vector3)(&obj9));
										List<Color> debugLineColours = _debugLineColours;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v3 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v3 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v3 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rdx_v6+18]");
										object obj12 = default(object);
										if (num >= 0)
										{
											debugLineColours.AddWithResize((Color)(&obj9));
											object obj11 = obj12;
											obj9 = obj12;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v3 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
											object obj13 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r9_v3 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
											object obj14 = (nint)0 + (nint)2;
											object obj15 = obj14 + obj14;
											object obj11 = obj12;
											object obj16 = default(object);
											obj9 = obj16;
										}
										List<Color> debugLineColours2 = _debugLineColours;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
										object obj17 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rdx_v8+18]");
										if (num2 >= 0)
										{
											debugLineColours2.AddWithResize((Color)(&obj9));
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
											object obj18 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
											object obj19 = (nint)0 + (nint)2;
											object obj20 = obj19 + obj19;
										}
										List<Vector3> debugLineVerts = _debugLineVerts;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rdx_v11 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
										int item = (int)(-2);
										_debugLineIndices.Add(item);
										List<Vector3> debugLineVerts2 = _debugLineVerts;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rdx_v15 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
										int item2 = (int)(-1);
										_debugLineIndices.Add(item2);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		Debug.LogError("DrawDebugLine called with invalid values!");
	}

	public static void DrawDebugRect(double x, double y, double width, float height)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm3,xmm7\"");
		Color colour = default(Color);
		DrawDebugRect(x, y, width, 0.0, colour);
	}

	public static void DrawDebugRect(double x, double y, double width, double height, Color colour)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,xmm9\"");
		Color colour2 = default(Color);
		DrawDebugLine(x, y, x, y, colour2);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm9\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,xmm9\"");
		DrawDebugLine(x, y, x, y, colour2);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm9\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm8\"");
		DrawDebugLine(x, y, x, y, colour2);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm8\"");
		DrawDebugLine(x, y, x, y, colour2);
	}

	public unsafe static void DrawDebugCircle(double x, double y, double radius)
	{
		//IL_001a: Expected O, but got Ref
		object obj = default(object);
		DrawDebugCircle(x, y, radius, (Color)(&obj));
	}

	public static void DrawDebugCircle(double x, double y, double radius, Color colour)
	{
		//IL_0040: Expected O, but got I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		if (s_drawDebug)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm11,xmm8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm12,xmm7\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm10,xmm6\"");
			object obj = 0;
			Color colour2 = default(Color);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,eax\"");
				float num = 0f * (1f / 32f);
				float num2 = 0f * (1f / 32f);
				float num3 = num * ((float)Math.PI * 2f);
				float num4 = num2 * ((float)Math.PI * 2f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float x2 = num3 * 0f;
				float y2 = num3 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float x3 = num4 * 0f;
				float y3 = num4 * 0f;
				DrawDebugLine(x2, y2, x3, y3, colour2);
				obj++;
			}
			while ((nint)obj < 32);
		}
	}

	public static void DrawBounds(Bounds bounds, Color colour)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm3,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm9\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
		Color colour2 = default(Color);
		DrawDebugRect(0.0, 0.0, 0.0, 0.0, colour2);
	}

	static VSDebug()
	{
		Shader shader = Shader.Find("Hidden/Internal-Colored");
		Material debugMat = new Material(shader);
		_debugMat = debugMat;
		Mesh debugMesh = new Mesh();
		_debugMesh = debugMesh;
		List<Vector3> debugLineVerts = new List<Vector3>();
		_debugLineVerts = debugLineVerts;
		List<Color> debugLineColours = new List<Color>();
		_debugLineColours = debugLineColours;
		List<int> debugLineIndices = new List<int>();
		_debugLineIndices = debugLineIndices;
		s_drawDebug = false;
	}
}
