using UnityEngine;

namespace Gh.Tk
{
	public class StarRevealCameraRatio : MonoBehaviour
	{
		private Camera _camera;

		public Material renderTextureMat;

		public RenderTexture renderTexture { get; set; }

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
