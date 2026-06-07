using UnityEngine;

public class WaterFlow : MonoBehaviour
{
	[Header("Flow Settings")]
	[Tooltip("Controls the speed of the random movement. Lower value means slower flow (Default: 0.02f).")]
	public float flowSpeed;

	[Tooltip("Controls the maximum distance the texture will shift. Lower value means less intense distortion (Default: 0.02f).")]
	public float noiseScale;

	private Renderer rend;

	private Material waterMaterial;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
