using UnityEngine;

public class TreeChunker : MonoBehaviour
{
	[Header("Grid Settings")]
	[Tooltip("World-space size of each chunk (XZ).")]
	[SerializeField]
	private float chunkSize;

	[Header("LOD Settings")]
	[Tooltip("Screen height ratio below which the chunk culls entirely.")]
	[Range(0.001f, 0.5f)]
	[SerializeField]
	private float cullThreshold;

	[Tooltip("Enable cross-fade on each chunk's LODGroup.")]
	[SerializeField]
	private bool crossFade;

	[Tooltip("Cross-fade animation duration (seconds). Only used if crossFade is true.")]
	[Range(0.1f, 2f)]
	[SerializeField]
	private float crossFadeDuration;
}
