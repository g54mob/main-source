using Restory.Data.PC;
using Restory.Gameplay.PC;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.WorkshopRatingsApplication
{
	public class GUI_WorkshopRatingsBanner : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private PcAppInfo browserAppInfo;

		private PcAppManager pcAppManager;

		[Inject]
		private void Construct(PcAppManager pcAppManager)
		{
			this.pcAppManager = pcAppManager;
		}

		private void OnEnable()
		{
			button.onClick.AddListener(ShowDecorShop);
		}

		private void OnDisable()
		{
			button.onClick.RemoveListener(ShowDecorShop);
		}

		private void ShowDecorShop()
		{
			pcAppManager.LaunchPcApp(browserAppInfo);
			if (pcAppManager.LaunchedApp != null && pcAppManager.LaunchedApp is GUI_WebBrowser gUI_WebBrowser)
			{
				gUI_WebBrowser.DecorShopTabActivator.Activate();
			}
		}
	}
}
