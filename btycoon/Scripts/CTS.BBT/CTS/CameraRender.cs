using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class CameraRender : CTSSingleton<CameraRender>
	{
		[SerializeField]
		private RenderTexture _renderTexture;

		public RenderTexture RenderTexture => _renderTexture;

		protected override void SingletonAwake()
		{
			_renderTexture = Object.Instantiate(_renderTexture);
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void Render(int? cullingMask = null)
		{
			int cullingMask2 = MainCamera.CameraReference.cullingMask;
			if (cullingMask.HasValue)
			{
				MainCamera.CameraReference.cullingMask = cullingMask.Value;
			}
			MonoSingleton<MainCamera>.Instance.RenderToTexture(RenderTexture);
			MainCamera.CameraReference.cullingMask = cullingMask2;
		}
	}
}
