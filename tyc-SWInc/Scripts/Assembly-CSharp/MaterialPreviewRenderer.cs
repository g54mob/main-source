using System.Collections.Generic;
using UnityEngine;

public class MaterialPreviewRenderer : MonoBehaviour
{
	public Camera Cam;

	public void StartRender(RenderTexture tex)
	{
		FixCamera();
		Cam.targetTexture = tex;
		Cam.enabled = true;
	}

	private void FixCamera()
	{
		FixPos(base.transform.parent.gameObject);
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Graphics.Blit(src, dst);
		RenderTexture nextRender = MaterialPreviewer.Instance.GetNextRender();
		if (nextRender != null)
		{
			FixCamera();
			Cam.targetTexture = nextRender;
		}
		else
		{
			Cam.enabled = false;
		}
	}

	private void GetAllPoints(Mesh m, Matrix4x4 t, List<Vector3> l)
	{
		Vector3[] vertices = m.vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			l.Add(t.MultiplyPoint(vertices[i]));
		}
	}

	public void FixPos(GameObject target)
	{
		Vector3 position = target.transform.position;
		target.transform.position = Vector3.zero;
		List<Vector3> list = new List<Vector3>();
		MeshFilter[] componentsInChildren = target.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if (meshFilter.sharedMesh != null)
			{
				GetAllPoints(meshFilter.sharedMesh, meshFilter.transform.localToWorldMatrix, list);
			}
		}
		SkinnedMeshRenderer[] componentsInChildren2 = target.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			if (skinnedMeshRenderer.sharedMesh != null)
			{
				Mesh mesh = new Mesh();
				skinnedMeshRenderer.BakeMesh(mesh);
				GetAllPoints(mesh, Matrix4x4.TRS(skinnedMeshRenderer.transform.position, skinnedMeshRenderer.transform.rotation, Vector3.one), list);
				Object.DestroyImmediate(mesh);
			}
		}
		Vector2 vector = new Vector2(99f, 99f);
		Vector2 vector2 = new Vector2(-99f, -99f);
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Cam.transform.rotation, Vector3.one);
		Matrix4x4 inverse = matrix4x.inverse;
		for (int j = 0; j < list.Count; j++)
		{
			Vector3 vector3 = inverse.MultiplyPoint(list[j]);
			vector = Vector2.Min(vector, vector3);
			vector2 = Vector2.Max(vector2, vector3);
		}
		Vector3 vector4 = matrix4x.MultiplyPoint((vector + vector2) * 0.5f);
		Cam.orthographicSize = Mathf.Max(vector2.x - vector.x, vector2.y - vector.y) * 0.51f;
		Cam.transform.position = vector4 - 20f * Cam.transform.forward;
		target.transform.position = position;
	}
}
