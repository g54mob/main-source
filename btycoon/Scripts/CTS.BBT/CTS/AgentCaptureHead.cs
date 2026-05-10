using System;
using UnityEngine;

namespace CTS
{
	[Obsolete]
	public class AgentCaptureHead : MonoBehaviour
	{
		[SerializeField]
		private Camera _headViewCam;

		private int _width = 1024;

		private int _height = 1024;

		private int _depth = 24;

		private Texture2D _tmpTexture;

		private Sprite _tmpSprite;

		public void CaptureHead()
		{
			RenderTexture renderTexture = new RenderTexture(_width, _height, _depth);
			Rect rect = new Rect(0f, 0f, _width, _height);
			Texture2D texture2D = new Texture2D(_width, _height, TextureFormat.RGBA32, mipChain: false);
			_headViewCam.gameObject.SetActive(value: true);
			_headViewCam.targetTexture = renderTexture;
			_headViewCam.Render();
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(rect, 0, 0);
			texture2D.Apply();
			_headViewCam.targetTexture = null;
			RenderTexture.active = active;
			UnityEngine.Object.Destroy(renderTexture);
			_headViewCam.gameObject.SetActive(value: false);
			_tmpSprite = Sprite.Create(texture2D, rect, Vector2.zero);
		}

		public Sprite GetPhoto()
		{
			return _tmpSprite;
		}
	}
}
