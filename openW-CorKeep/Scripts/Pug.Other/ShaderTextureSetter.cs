using UnityEngine;

[ExecuteInEditMode]
public class ShaderTextureSetter : MonoBehaviour
{
	public string texName;

	public Texture2D texture;

	private void Awake()
	{
	}

	private void Start()
	{
		Renderer component = GetComponent<Renderer>();
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		component.GetPropertyBlock(materialPropertyBlock);
		materialPropertyBlock.SetTexture(texName, texture);
		component.SetPropertyBlock(materialPropertyBlock);
	}
}
