using System.Collections;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class CameraFader : MonoBehaviour
	{
		private static CameraFader _current;

		private float alpha;

		private Texture2D _blackTexture;

		private Texture2D blackTexture => null;

		public static CameraFader current => null;

		public void FadeIn(float time)
		{
		}

		public void FadeOut(float time)
		{
		}

		private IEnumerator CoroutineFadeIn(float time)
		{
			return null;
		}

		private IEnumerator CoroutineFadeOut(float time)
		{
			return null;
		}

		private void OnGUI()
		{
		}
	}
}
