using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("Heat UI/UI Manager/UI Manager Logo")]
	public class UIManagerLogo : MonoBehaviour
	{
		public enum LogoType
		{
			GameLogo = 0,
			BrandLogo = 1
		}

		public UIManager UIManagerAsset;

		private Image objImage;

		[SerializeField]
		private LogoType logoType;

		private void Awake()
		{
			base.enabled = true;
			if (UIManagerAsset == null)
			{
				UIManagerAsset = Resources.Load<UIManager>("Heat UI Manager");
			}
			if (objImage == null)
			{
				objImage = GetComponent<Image>();
			}
			if (!UIManagerAsset.enableDynamicUpdate)
			{
				UpdateImage();
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (!(UIManagerAsset == null) && UIManagerAsset.enableDynamicUpdate)
			{
				UpdateImage();
			}
		}

		private void UpdateImage()
		{
			if (!(objImage == null))
			{
				if (logoType == LogoType.GameLogo)
				{
					objImage.sprite = UIManagerAsset.gameLogo;
				}
				else if (logoType == LogoType.BrandLogo)
				{
					objImage.sprite = UIManagerAsset.brandLogo;
				}
			}
		}
	}
}
