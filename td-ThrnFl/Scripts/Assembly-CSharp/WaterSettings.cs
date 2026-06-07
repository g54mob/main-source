using UnityEngine;

[CreateAssetMenu(menuName = "SimpleSiege/Water Settings", fileName = "New Water Settings")]
public class WaterSettings : ScriptableObject
{
	public float riverScrollSpeed = -0.04f;

	public Vector2 riverTextureTiling = new Vector2(2f, 16f);

	public float oceanScrollSpeed = 0.04f;

	public Vector2 oceanTextureTiling = new Vector2(80f, 20f);

	[Range(0f, 1f)]
	public float selfShadingSize = 0.724f;

	[Range(0f, 1f)]
	public float oceanSelfShadingSize = 0.724f;
}
