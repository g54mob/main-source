using UnityEngine;

[CreateAssetMenu(fileName = "New Gradient Data", menuName = "Super Text Mesh/Texture Data", order = 1)]
public class STMTextureData : ScriptableObject
{
	public Texture texture;

	public FilterMode filterMode;

	public bool relativeToLetter;

	public bool scaleWithText;

	public Vector2 tiling = Vector2.one;

	public Vector2 offset = Vector2.zero;

	public Vector2 scrollSpeed = Vector2.one;
}
