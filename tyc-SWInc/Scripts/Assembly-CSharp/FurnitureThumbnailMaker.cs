using System.Collections.Generic;
using System.IO;
using DevConsole;
using UnityEngine;

public class FurnitureThumbnailMaker : MonoBehaviour
{
	public static FurnitureThumbnailMaker Instance;

	public Camera ThumbnailCam;

	public RenderTexture Target;

	public Material BlitMat;

	public Light light;

	private void Awake()
	{
		Instance = this;
		ThumbnailCam.targetTexture = Target;
	}

	private void OnDestroy()
	{
		Instance = null;
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
		List<Vector3> list = new List<Vector3>();
		MeshFilter[] componentsInChildren = target.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			GetAllPoints(meshFilter.sharedMesh, meshFilter.transform.localToWorldMatrix, list);
		}
		SkinnedMeshRenderer[] componentsInChildren2 = target.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			Mesh mesh = new Mesh();
			skinnedMeshRenderer.BakeMesh(mesh);
			GetAllPoints(mesh, Matrix4x4.TRS(skinnedMeshRenderer.transform.position, skinnedMeshRenderer.transform.rotation, Vector3.one), list);
			Object.DestroyImmediate(mesh);
		}
		Vector2 vector = new Vector2(99f, 99f);
		Vector2 vector2 = new Vector2(-99f, -99f);
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, ThumbnailCam.transform.rotation, Vector3.one);
		Matrix4x4 inverse = matrix4x.inverse;
		for (int j = 0; j < list.Count; j++)
		{
			Vector3 vector3 = inverse.MultiplyPoint(list[j]);
			vector = Vector2.Min(vector, vector3);
			vector2 = Vector2.Max(vector2, vector3);
		}
		Vector3 vector4 = matrix4x.MultiplyPoint((vector + vector2) * 0.5f);
		ThumbnailCam.orthographicSize = Mathf.Max(vector2.x - vector.x, vector2.y - vector.y) * 0.51f;
		ThumbnailCam.transform.position = vector4 - 4f * ThumbnailCam.transform.forward;
	}

	public Vector3[] GetMinMax(GameObject obj)
	{
		Vector3 vector = Vector3.one * 500f;
		Vector3 vector2 = Vector3.one * -500f;
		MeshFilter[] componentsInChildren = obj.GetComponentsInChildren<MeshFilter>(true);
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			Renderer component = meshFilter.GetComponent<Renderer>();
			if (component == null || !component.enabled)
			{
				continue;
			}
			MeshFilter localItem = meshFilter;
			foreach (Vector3 item in meshFilter.sharedMesh.vertices.Select((Vector3 x) => localItem.transform.localToWorldMatrix.MultiplyPoint(x)))
			{
				vector = Utilities.MinVector(vector, item);
				vector2 = Utilities.MaxVector(vector2, item);
			}
		}
		return new Vector3[2] { vector, vector2 };
	}

	private void Preview(GameObject activeObject)
	{
		FixPos(activeObject);
		ThumbnailCam.Render();
	}

	public void TakePicture(string furnitureName)
	{
		GameObject furniture = ObjectDatabase.Instance.GetFurniture(furnitureName);
		if (furniture != null)
		{
			GameObject gameObject = Object.Instantiate(furniture);
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.name = furniture.name;
			gameObject.GetComponent<Furniture>().isTemporary = true;
			gameObject.GetComponent<Furniture>().ForceTemporary();
			gameObject.SetActive(true);
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer = 9;
			}
			string path = "Furniture/" + furniture.name.Replace(" ", "") + "Thumb.png";
			light.enabled = true;
			Preview(gameObject);
			RenderTexture renderTexture = new RenderTexture(Target.width / 2, Target.height / 2, 16, RenderTextureFormat.ARGB32);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			BlitMat.SetFloat("_inputSize", 256f);
			Graphics.Blit(Target, renderTexture, BlitMat);
			Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = active;
			Object.Destroy(renderTexture);
			File.WriteAllBytes(path, texture2D.EncodeToPNG());
			Object.Destroy(gameObject);
			Object.Destroy(texture2D);
			light.enabled = false;
			Console.Log("Thumbnail saved as " + Path.GetFullPath(path));
		}
		else
		{
			Console.Log("Furniture not found");
		}
	}
}
