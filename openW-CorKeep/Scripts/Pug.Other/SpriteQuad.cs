using UnityEngine;

[ExecuteInEditMode]
public class SpriteQuad : MonoBehaviour
{
	[Header("Settings:")]
	public Sprite sprite;

	private Mesh mesh;

	private MeshRenderer meshRenderer;

	private Material material;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		if (sprite != null)
		{
			SetupMeshRenderer();
		}
		else
		{
			material.mainTexture = null;
		}
	}

	private void SetupMeshRenderer()
	{
		material = meshRenderer.sharedMaterial;
		material.mainTexture = sprite.texture;
		float num = sprite.texture.width;
		float num2 = sprite.texture.height;
		float pixelsPerUnit = sprite.pixelsPerUnit;
		float x = num / pixelsPerUnit;
		float y = num2 / pixelsPerUnit;
		base.transform.localScale = new Vector3(x, y, 1f);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
