using UnityEngine;

[ExecuteInEditMode]
public class EnableDepthInForwardCamera : MonoBehaviour
{
	private void OnEnable()
	{
		if (GetComponent<Camera>().depthTextureMode == DepthTextureMode.None)
		{
			GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		}
	}

	private void Update()
	{
	}
}
