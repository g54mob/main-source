using UnityEngine;

namespace TH20
{
	public class RenderToTexture
	{
		private readonly Camera _camera;

		private readonly int _width;

		private readonly int _height;

		public int Width => _width;

		public int Height => _height;

		public RenderToTexture(Camera camera, int width, int height)
		{
			_camera = camera;
			_width = width;
			_height = height;
		}

		public byte[] RenderToJpg(int quality = 75)
		{
			RenderTexture renderTexture = new RenderTexture(_width, _height, 24);
			_camera.targetTexture = renderTexture;
			_camera.Render();
			Texture2D texture2D = new Texture2D(_width, _height, TextureFormat.RGB24, mipChain: false);
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, _width, _height), 0, 0);
			_camera.targetTexture = null;
			RenderTexture.active = null;
			renderTexture.Release();
			return texture2D.EncodeToJPG(quality);
		}
	}
}
