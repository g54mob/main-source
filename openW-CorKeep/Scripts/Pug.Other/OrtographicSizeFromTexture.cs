using UnityEngine;

public class OrtographicSizeFromTexture : MonoBehaviour
{
	public Camera cameraToSet;

	private void Awake()
	{
		cameraToSet.orthographicSize = cameraToSet.targetTexture.height / 2;
	}
}
