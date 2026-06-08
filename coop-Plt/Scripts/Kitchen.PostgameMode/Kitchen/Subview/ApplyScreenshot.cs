using UnityEngine;

namespace Kitchen.Subview
{
	public class ApplyScreenshot : MonoBehaviour
	{
		public MeshRenderer Photo;

		private static readonly int Photograph = Shader.PropertyToID("_Photograph");

		private MemoryManagerHandle Handle;

		private void Awake()
		{
			Handle = this;
			if (ScreenshotCamera.Screenshot != null)
			{
				Handle.Register(Photo.material);
				Photo.material.SetTexture(Photograph, ScreenshotCamera.Screenshot);
			}
		}

		private void OnDestroy()
		{
			Handle.Dispose();
		}
	}
}
