using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Heraldry;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace NSMedieval.UI
{
	public class HeraldryCamera : MonoBehaviour
	{
		[SerializeField]
		private string path;

		private TextureCreationFlags flags;

		private Camera screenshotCamera;

		public void TakeSs()
		{
			screenshotCamera.gameObject.SetActive(value: true);
			Shoot();
		}

		private void Start()
		{
			screenshotCamera = base.gameObject.GetComponent<Camera>();
			screenshotCamera.gameObject.SetActive(value: false);
		}

		private void Shoot()
		{
			RenderTexture targetTexture = screenshotCamera.targetTexture;
			if (!SystemInfo.IsFormatSupported(targetTexture.graphicsFormat, FormatUsage.Render))
			{
				if (SystemInfo.IsFormatSupported(GraphicsFormat.D32_SFloat_S8_UInt, FormatUsage.Render))
				{
					Log.Info("Graphic format D32S8 is supported on this system.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryCamera.cs");
				}
				if (SystemInfo.IsFormatSupported(GraphicsFormat.D32_SFloat, FormatUsage.Render))
				{
					Log.Info("Graphic format D32 is supported on this system.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryCamera.cs");
				}
				if (SystemInfo.IsFormatSupported(GraphicsFormat.D24_UNorm_S8_UInt, FormatUsage.Render))
				{
					Log.Info("Graphic format D24S8 is supported on this system.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryCamera.cs");
				}
				if (SystemInfo.IsFormatSupported(GraphicsFormat.D24_UNorm, FormatUsage.Render))
				{
					Log.Info("Graphic format D24 is supported on this system.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryCamera.cs");
				}
				if (SystemInfo.IsFormatSupported(GraphicsFormat.D16_UNorm_S8_UInt, FormatUsage.Render))
				{
					Log.Info("Graphic format D16S8 is supported on this system.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryCamera.cs");
				}
				if (SystemInfo.IsFormatSupported(GraphicsFormat.D16_UNorm, FormatUsage.Render))
				{
					Log.Info("Graphic format D16 is supported on this system.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HeraldryCamera.cs");
				}
				targetTexture.depthStencilFormat = GraphicsFormat.D16_UNorm;
			}
			RenderTexture.active = targetTexture;
			Texture2D heraldryImage = new Texture2D(targetTexture.width, targetTexture.height, GraphicsFormat.R8G8B8A8_SRGB, flags);
			screenshotCamera.Render();
			MonoSingleton<HeraldryManager>.Instance.SaveHeraldryImage(heraldryImage, path);
			screenshotCamera.gameObject.SetActive(value: false);
		}
	}
}
