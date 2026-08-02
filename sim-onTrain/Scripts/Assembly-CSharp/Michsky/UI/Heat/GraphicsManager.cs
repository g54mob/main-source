using UnityEngine;

namespace Michsky.UI.Heat
{
	public class GraphicsManager : MonoBehaviour
	{
		public enum TextureOption
		{
			FullRes = 0,
			HalfRes = 1,
			QuarterRes = 2,
			EighthResh = 3
		}

		public enum AnisotropicOption
		{
			None = 0,
			PerTexture = 1,
			ForcedOn = 2
		}

		[SerializeField]
		private Dropdown resolutionDropdown;

		[SerializeField]
		private bool initializeResolutions = true;

		private Resolution[] resolutions;

		private void Awake()
		{
			if (initializeResolutions && resolutionDropdown != null)
			{
				InitializeResolutions();
			}
		}

		public void InitializeResolutions()
		{
			resolutions = Screen.resolutions;
			resolutionDropdown.items.Clear();
			int selectedItemIndex = 0;
			for (int i = 0; i < resolutions.Length; i++)
			{
				int index = i;
				string title = resolutions[i].width + "x" + resolutions[i].height;
				resolutionDropdown.CreateNewItem(title, notify: false);
				resolutionDropdown.items[i].onItemSelection.AddListener(delegate
				{
					SetResolution(index);
				});
				if (resolutions[i].refreshRateRatio.numerator != Screen.currentResolution.refreshRateRatio.numerator)
				{
					resolutionDropdown.items[i].isInvisible = true;
				}
				if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRateRatio.numerator == Screen.currentResolution.refreshRateRatio.numerator)
				{
					selectedItemIndex = index;
				}
			}
			resolutionDropdown.selectedItemIndex = selectedItemIndex;
			resolutionDropdown.Initialize();
		}

		public void SetResolution(int resolutionIndex)
		{
			Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
		}

		public void SetVSync(bool value)
		{
			if (value)
			{
				QualitySettings.vSyncCount = 2;
			}
			else
			{
				QualitySettings.vSyncCount = 0;
			}
		}

		public void SetFrameRate(int value)
		{
			Application.targetFrameRate = value;
		}

		public void SetWindowFullscreen()
		{
			Screen.fullScreen = true;
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
		}

		public void SetWindowBorderless()
		{
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		}

		public void SetWindowWindowed()
		{
			Screen.fullScreen = false;
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}

		public void SetTextureQuality(TextureOption option)
		{
			switch (option)
			{
			case TextureOption.FullRes:
				QualitySettings.globalTextureMipmapLimit = 0;
				break;
			case TextureOption.HalfRes:
				QualitySettings.globalTextureMipmapLimit = 1;
				break;
			case TextureOption.QuarterRes:
				QualitySettings.globalTextureMipmapLimit = 2;
				break;
			case TextureOption.EighthResh:
				QualitySettings.globalTextureMipmapLimit = 3;
				break;
			}
		}

		public void SetTextureQuality(int index)
		{
			switch (index)
			{
			case 0:
				SetTextureQuality(TextureOption.FullRes);
				break;
			case 1:
				SetTextureQuality(TextureOption.HalfRes);
				break;
			case 2:
				SetTextureQuality(TextureOption.QuarterRes);
				break;
			case 3:
				SetTextureQuality(TextureOption.EighthResh);
				break;
			}
		}

		public void SetAnisotropicFiltering(AnisotropicOption option)
		{
			switch (option)
			{
			case AnisotropicOption.ForcedOn:
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
				break;
			case AnisotropicOption.PerTexture:
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
				break;
			case AnisotropicOption.None:
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
				break;
			}
		}

		public void SetAnisotropicFiltering(int index)
		{
			switch (index)
			{
			case 2:
				SetAnisotropicFiltering(AnisotropicOption.ForcedOn);
				break;
			case 1:
				SetAnisotropicFiltering(AnisotropicOption.PerTexture);
				break;
			case 0:
				SetAnisotropicFiltering(AnisotropicOption.None);
				break;
			}
		}
	}
}
