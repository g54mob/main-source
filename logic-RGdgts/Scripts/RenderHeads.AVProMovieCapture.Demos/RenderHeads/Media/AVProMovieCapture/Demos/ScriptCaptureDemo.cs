using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture.Demos
{
	public class ScriptCaptureDemo : MonoBehaviour
	{
		private const string X264CodecName = "x264vfw - H.264/MPEG-4 AVC codec";

		private const string FallbackCodecName = "Uncompressed";

		private Codec _videoCodec;

		private int _encoderHandle;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void CreateVideoFromByteArray(string filePath, int width, int height, int frameRate)
		{
		}
	}
}
