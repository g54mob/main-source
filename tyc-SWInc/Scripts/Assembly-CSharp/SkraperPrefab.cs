using System;
using UnityEngine;

public class SkraperPrefab : MonoBehaviour
{
	[ContextMenuItem("Generate area", "GenerateArea")]
	public Rect Area;

	public MeshRenderer Atlas;

	public MeshRenderer Colorable;

	public Vector2 AtlasSize;

	public float Chance = 1f;

	public void Init(Color rColor, Color gColor, Color bColor, System.Random rnd)
	{
		if (Atlas != null)
		{
			int num = rnd.Next(0, (int)AtlasSize.x);
			int num2 = rnd.Next(0, (int)AtlasSize.y);
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetVector("_TextureOffset", new Vector4((float)num / AtlasSize.x, (float)num2 / AtlasSize.y, 1f / AtlasSize.x, 1f / AtlasSize.y));
			Atlas.SetPropertyBlock(materialPropertyBlock);
		}
		if (Colorable != null)
		{
			MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
			materialPropertyBlock2.SetColor("_RedColor", rColor);
			materialPropertyBlock2.SetColor("_GreenColor", gColor);
			materialPropertyBlock2.SetColor("_BlueColor", bColor);
			Colorable.SetPropertyBlock(materialPropertyBlock2);
		}
	}

	public void GenerateArea()
	{
		Vector2 lhs = new Vector2(float.MaxValue, float.MaxValue);
		Vector2 lhs2 = new Vector2(float.MinValue, float.MinValue);
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter obj in componentsInChildren)
		{
			Matrix4x4 localToWorldMatrix = obj.transform.localToWorldMatrix;
			Vector3[] vertices = obj.sharedMesh.vertices;
			for (int j = 0; j < vertices.Length; j++)
			{
				Vector2 rhs = localToWorldMatrix.MultiplyPoint(vertices[j]).FlattenVector3();
				lhs = Vector2.Min(lhs, rhs);
				lhs2 = Vector2.Max(lhs2, rhs);
			}
		}
		Area = Rect.MinMaxRect(lhs.x - 0.5f, lhs.y - 0.5f, lhs2.x + 0.5f, lhs2.y + 0.5f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(Area.center.ToVector3(0f), Area.size.ToVector3(0f));
		Gizmos.matrix = Matrix4x4.identity;
	}
}
