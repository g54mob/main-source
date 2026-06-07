using System.Collections.Generic;
using System.Text;
using UnityEngine;

public sealed class FastObjImporter
{
	private static FastObjImporter _instance;

	private List<int> triangles;

	private List<Vector3> vertices;

	private List<Vector2> uv;

	private List<Vector3> normals;

	private List<Vector3Int> faceData;

	private List<int> intArray;

	private const int MIN_POW_10 = -32;

	private const int MAX_POW_10 = 32;

	private const int NUM_POWS_10 = 65;

	private static readonly float[] pow10;

	public Vector3 scale;

	public Vector3 offset;

	public static FastObjImporter Instance => null;

	public Mesh ImportFile(string filePath, Vector3 scale, Vector3 offset)
	{
		return null;
	}

	private void LoadMeshData(string fileName)
	{
	}

	private float GetFloat(StringBuilder sb, ref int start, ref StringBuilder sbFloat)
	{
		return 0f;
	}

	private int GetIntNoSkip(StringBuilder sb, ref int start, ref StringBuilder sbInt)
	{
		return 0;
	}

	private int GetInt(StringBuilder sb, ref int start, ref StringBuilder sbInt, bool dontSkipSpace = false)
	{
		return 0;
	}

	private static float[] GenerateLookupTable()
	{
		return null;
	}

	private float ParseFloat(StringBuilder value)
	{
		return 0f;
	}

	private int IntParseFast(StringBuilder value)
	{
		return 0;
	}
}
