using System;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.Shops.Banners
{
	public class GUI_Banner : MonoBehaviour
	{
		[SerializeField]
		private Button itemButton;

		public event Action OnBannerClicked;

		private void OnEnable()
		{
			itemButton.onClick.AddListener(ResolveItemButtonClicked);
		}

		private void OnDisable()
		{
			if (itemButton.MonoShellExists())
			{
				itemButton.onClick.RemoveListener(ResolveItemButtonClicked);
			}
		}

		private void ResolveItemButtonClicked()
		{
			this.OnBannerClicked?.Invoke();
		}
	}
}
