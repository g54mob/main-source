using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibTessDotNet;
using UnityEngine;

public static class SwincBooster
{
	private static bool _forceLegacy = false;

	private static ObjectPool<Tess> _tessPool = new ObjectPool<Tess>(() => new Tess
	{
		NoEmptyPolygons = true
	});

	public static bool UsingLegacy
	{
		get
		{
			return _forceLegacy;
		}
	}

	[DllImport("SwincBoost")]
	private static extern int GetTesselator();

	[DllImport("SwincBoost")]
	private static extern void ReleaseTesselator(int id);

	[DllImport("SwincBoost")]
	private static extern void AddContour(int id, IntPtr vertices, int amount);

	[DllImport("SwincBoost")]
	private static extern bool Tesselate(int id);

	[DllImport("SwincBoost")]
	private static extern IntPtr GetVertices(int id);

	[DllImport("SwincBoost")]
	private static extern int GetVertexCount(int id);

	[DllImport("SwincBoost")]
	private static extern IntPtr GetElements(int id);

	[DllImport("SwincBoost")]
	private static extern int GetElementCount(int id);

	private static float[] ToFloatArr(IList<Vector2> vertices, bool reverse)
	{
		float[] array = new float[vertices.Count * 2];
		for (int i = 0; i < vertices.Count; i++)
		{
			if (reverse)
			{
				array[i * 2] = vertices[vertices.Count - 1 - i].x;
				array[i * 2 + 1] = vertices[vertices.Count - 1 - i].y;
			}
			else
			{
				array[i * 2] = vertices[i].x;
				array[i * 2 + 1] = vertices[i].y;
			}
		}
		return array;
	}

	private static T2[] SelectInPlace<T1, T2>(this IList<T1> arr, Func<T1, T2> select)
	{
		T2[] array = new T2[arr.Count];
		for (int i = 0; i < arr.Count; i++)
		{
			array[i] = select(arr[i]);
		}
		return array;
	}

	public static bool Clockwise(IList<Vector2> s)
	{
		float num = 0f;
		for (int i = 0; i < s.Count; i++)
		{
			Vector2 vector = s[i];
			Vector2 vector2 = s[(i + 1) % s.Count];
			num += (vector2.x - vector.x) * (vector2.y + vector.y);
		}
		return num > 0f;
	}

	public static ValueTuple<Vector2[], int[]> Tesselate(IList<Vector2> main, IEnumerable<IList<Vector2>> holes, bool forPathFinding)
	{
		if (_forceLegacy)
		{
			return TesselateLegacy(main, holes);
		}
		int tesselator;
		try
		{
			tesselator = GetTesselator();
		}
		catch (DllNotFoundException ex)
		{
			Debug.Log("Swinc boost library missing:\n" + ex.ToString());
			_forceLegacy = true;
			return TesselateLegacy(main, holes);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			_forceLegacy = true;
			return TesselateLegacy(main, holes);
		}
		GCHandle gCHandle = GCHandle.Alloc(ToFloatArr(main, Clockwise(main)), GCHandleType.Pinned);
		AddContour(tesselator, gCHandle.AddrOfPinnedObject(), main.Count);
		gCHandle.Free();
		foreach (IList<Vector2> hole in holes)
		{
			gCHandle = GCHandle.Alloc(ToFloatArr(hole, Clockwise(hole)), GCHandleType.Pinned);
			AddContour(tesselator, gCHandle.AddrOfPinnedObject(), hole.Count);
			gCHandle.Free();
		}
		ValueTuple<Vector2[], int[]> result = new ValueTuple<Vector2[], int[]>(null, null);
		if (Tesselate(tesselator))
		{
			int vertexCount = GetVertexCount(tesselator);
			float[] array = new float[vertexCount * 2];
			Vector2[] array2 = new Vector2[vertexCount];
			Marshal.Copy(GetVertices(tesselator), array, 0, array.Length);
			for (int i = 0; i < vertexCount; i++)
			{
				array2[i] = new Vector2(array[i * 2], array[i * 2 + 1]);
			}
			int[] array3 = new int[GetElementCount(tesselator) * 3];
			Marshal.Copy(GetElements(tesselator), array3, 0, array3.Length);
			result = new ValueTuple<Vector2[], int[]>(array2, array3);
		}
		ReleaseTesselator(tesselator);
		return result;
	}

	private static ValueTuple<Vector2[], int[]> TesselateLegacy(IList<Vector2> main, IEnumerable<IList<Vector2>> holes)
	{
		Tess tess;
		lock (_tessPool)
		{
			tess = _tessPool.Get();
		}
		tess.AddContourFast(main, false);
		foreach (IList<Vector2> hole in holes)
		{
			tess.AddContourFast(hole, true);
		}
		tess.Tessellate(WindingRule.EvenOdd, ElementType.ConstrainedDelauneyTriangles, 3, null, new Vec3(0f, -1f, 0f));
		ValueTuple<Vector2[], int[]> result = new ValueTuple<Vector2[], int[]>(tess.Vertices.SelectInPlace((ContourVertex x) => new Vector2(x.Position.X, x.Position.Z)), tess.Elements);
		lock (_tessPool)
		{
			_tessPool.Release(tess);
			return result;
		}
	}
}
