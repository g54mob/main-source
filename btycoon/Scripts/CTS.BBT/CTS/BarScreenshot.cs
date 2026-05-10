using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class BarScreenshot : CTSSingleton<BarScreenshot>
	{
		[SerializeField]
		private RenderTexture _renderTexture;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private InterimAgency _agency;

		public Texture2D Texture2D { get; private set; }

		protected override void SingletonAwake()
		{
			_agency.OnInterimEnter += OnAgencyEnter;
			ProfileManager.Saving += OnSaving;
		}

		protected override void OnSingletonDestroy()
		{
			_agency.OnInterimEnter -= OnAgencyEnter;
			ProfileManager.Saving -= OnSaving;
		}

		private void OnSaving()
		{
			if (!_agency.isInAgnecy)
			{
				Capture();
			}
		}

		private void OnAgencyEnter()
		{
			Capture();
		}

		public void Capture()
		{
			CaptureScreenshot();
		}

		public void CaptureScreenshot()
		{
			CTSSingleton<CameraRender>.Instance.Render(MainCamera.CameraReference.cullingMask & ~(1 << LayerMask.NameToLayer("UI")));
			RenderTexture renderTexture = CTSSingleton<CameraRender>.Instance.RenderTexture;
			Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = active;
			Texture2D = texture2D;
		}
	}
}
