using UnityEngine;

public class HousePlantController : MonoBehaviour
{
	[Header("Configuration")]
	public Vector3 spawnLocalPosition;

	public Vector2 sizeScale;

	[Header("Deterministic Values")]
	public int poolIndex;

	public float scaleIndex;

	public float rotation;

	public float colourLerp;

	[Header("State")]
	public GameObject spawnedPlant;

	public bool isLoaded;

	private void OnEnable()
	{
	}
}
