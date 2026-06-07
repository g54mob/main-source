using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture.Demos
{
	public class TextureCaptureDemo : MonoBehaviour
	{
		[SerializeField]
		private Shader _shader;

		[SerializeField]
		private int _textureWidth;

		[SerializeField]
		private int _textureHeight;

		[SerializeField]
		private CaptureFromTexture _movieCapture;

		private Material _material;

		private RenderTexture _texture;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void UpdateTexture()
		{
		}

		private void OnGUI()
		{
		}
	}
}
