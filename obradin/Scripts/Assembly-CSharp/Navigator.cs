using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
	public struct Mark
	{
		public bool valid;

		public Vector2 pos;

		public Vector2 dir;
	}

	private struct Tri
	{
		public Vector2 p0;

		public Vector2 p1;

		public Vector2 p2;

		public Vector2 uv0;

		public Vector2 uv1;

		public Vector2 uv2;

		public float area;
	}

	private class Deck
	{
		public float y;

		public List<Tri> tris = new List<Tri>();
	}

	public int width;

	public int height;

	private List<Deck> decks = new List<Deck>();

	private void Start()
	{
		decks.Clear();
		MeshFilter[] componentsInChildren = base.gameObject.GetComponentsInChildren<MeshFilter>(true);
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			Mesh sharedMesh = meshFilter.sharedMesh;
			Vector2[] uv = sharedMesh.uv;
			Vector3[] vertices = sharedMesh.vertices;
			int[] triangles = sharedMesh.triangles;
			Deck deck = new Deck();
			deck.y = meshFilter.transform.localPosition.y;
			Matrix4x4 matrix4x = base.transform.worldToLocalMatrix * meshFilter.transform.localToWorldMatrix;
			for (int j = 0; j < triangles.Length; j += 3)
			{
				Tri item = new Tri
				{
					p0 = matrix4x.MultiplyPoint(vertices[triangles[j + 2]]).ToVector2XZ(),
					p1 = matrix4x.MultiplyPoint(vertices[triangles[j + 1]]).ToVector2XZ(),
					p2 = matrix4x.MultiplyPoint(vertices[triangles[j]]).ToVector2XZ(),
					uv0 = uv[triangles[j + 2]],
					uv1 = uv[triangles[j + 1]],
					uv2 = uv[triangles[j]]
				};
				item.area = GetArea(item.p0, item.p1, item.p2);
				deck.tris.Add(item);
			}
			decks.Add(deck);
			meshFilter.gameObject.SetActive(false);
		}
		decks.Sort((Deck a, Deck b) => b.y.CompareTo(a.y));
	}

	public Mark GetMark(Vector3 worldPos, Vector3 worldDir)
	{
		Mark result = default(Mark);
		Vector3 v = base.transform.worldToLocalMatrix.MultiplyPoint(worldPos);
		foreach (Deck deck in decks)
		{
			if (v.y < deck.y)
			{
				continue;
			}
			Vector2 p = v.ToVector2XZ();
			foreach (Tri tri in deck.tris)
			{
				float area = tri.area;
				float num = GetArea(tri.p1, tri.p2, p) / area;
				if (num < 0f)
				{
					continue;
				}
				float num2 = GetArea(tri.p2, tri.p0, p) / area;
				if (!(num2 < 0f))
				{
					float num3 = GetArea(tri.p0, tri.p1, p) / area;
					if (!(num3 < 0f))
					{
						Vector2 vector = num * tri.uv0 + num2 * tri.uv1 + num3 * tri.uv2;
						result.pos = new Vector2(vector.x * (float)width, vector.y * (float)height);
						result.dir = worldDir.ToVector2XZ();
						result.valid = true;
						break;
					}
				}
			}
			break;
		}
		return result;
	}

	private static float GetArea(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		Vector2 vector = p1 - p3;
		Vector2 vector2 = p2 - p3;
		return (vector.x * vector2.y - vector.y * vector2.x) * 0.5f;
	}
}
