using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class CameraTargetCache : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Camera _camera;

		private RenderTexture _renderTexture;

		protected override void OnAwake()
		{
			base.OnAwake();
			if ((bool)_camera.targetTexture)
			{
				_camera.targetTexture = Object.Instantiate(_camera.targetTexture);
				_renderTexture = _camera.targetTexture;
			}
		}

		private void OnDestroy()
		{
			if ((bool)_renderTexture)
			{
				_renderTexture.Release();
				_renderTexture = null;
			}
		}
	}
}
