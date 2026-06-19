using UnityEngine;

namespace FPL
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public class BuiltIn_CameraDepthNormal : MonoBehaviour
	{
		[SerializeField]
		private Camera cam;

		private void OnEnable()
		{
			if (cam == null)
			{
				cam = GetComponent<Camera>();
			}
			cam.depthTextureMode |= DepthTextureMode.DepthNormals;
		}
	}
}
