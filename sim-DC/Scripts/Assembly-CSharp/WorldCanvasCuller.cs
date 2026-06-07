using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class WorldCanvasCuller : MonoBehaviour
{
	[Tooltip("When the canvas is farther than this distance, it will be disabled.")]
	private float maxDistance;

	private Canvas canvas;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
