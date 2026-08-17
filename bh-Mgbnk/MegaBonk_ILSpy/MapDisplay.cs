using UnityEngine;

public class MapDisplay : MonoBehaviour
{
	public Renderer textureRender;

	public MeshFilter meshFilter;

	public MeshRenderer meshRenderer;

	public MeshCollider meshCollider;

	public unsafe void DrawTexture(Texture2D texture)
	{
		//IL_0066: Expected O, but got Ref
		Material sharedMaterial = textureRender.GetSharedMaterial();
		sharedMaterial.mainTexture = texture;
		Transform transform = textureRender.transform;
		int width = texture.width;
		int height = texture.height;
		int num = default(int);
		transform.localScale = (Vector3)(&num);
	}

	public void DrawMesh(MeshData meshData)
	{
		Mesh sharedMesh = meshData.CreateMesh();
		meshFilter.sharedMesh = sharedMesh;
		Mesh sharedMesh2 = meshFilter.sharedMesh;
		meshCollider.sharedMesh = sharedMesh2;
	}
}
