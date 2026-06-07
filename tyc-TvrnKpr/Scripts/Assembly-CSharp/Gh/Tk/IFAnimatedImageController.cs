using UnityEngine;

namespace Gh.Tk
{
	public class IFAnimatedImageController : MonoBehaviour
	{
		public ShaderPropertyAnimator animatedImageWipe;

		public GameObject activeScene;

		public GameObject nextScene;

		private bool _switchToNextScene;

		private bool _wipeOutDone;

		[SerializeField]
		private RenderTexture _sceneRenderTexture;

		private void Update()
		{
		}

		internal void Reset()
		{
		}
	}
}
