using System;
using System.Collections.Generic;
using UnityEngine;

public class LandPanel : MonoBehaviour
{
	public enum SKIPEXTRASTATE
	{
		DEFAULT = 0,
		DONTSKIP = 1,
		SKIP = 2
	}

	private Panel panel;

	private Mesh mesh;

	private Vector3[] vertices;

	private Vector2[] uvs;

	private List<Vector4> uv2;

	private List<Vector4> uv3;

	private List<Vector4> uv4;

	private Color[] colors;

	private int[] tris;

	private float heightScale;

	[NonSerialized]
	public bool dirty;

	[NonSerialized]
	public SKIPEXTRASTATE skipRecalculateExtras;

	private Material material;

	public void Init(Panel panel)
	{
	}

	public void Refresh(bool forceRefresh)
	{
	}

	public static byte GetTextureSlot(byte level, int cx, int cz)
	{
		return 0;
	}

	private void MarshallSpecial(int p, byte level)
	{
	}

	public void ApplySpecials()
	{
	}

	private Vector3 GetVertex(int x, int y)
	{
		return default(Vector3);
	}

	private void MakeTriangle(int p, Vector3 v0, Vector3 v1, Vector3 v2, Color c0, Color c1, Color c2)
	{
	}

	private Vector3 CalculateNormal(Vector3 v1, Vector3 v2, Vector3 v3)
	{
		return default(Vector3);
	}

	private void IsVertexEdge(int x, int y, out bool upper, out bool lower)
	{
		upper = default(bool);
		lower = default(bool);
	}

	private Vector2 GetUVUnscaled(int t)
	{
		return default(Vector2);
	}

	public void DestroyPanel()
	{
	}
}
