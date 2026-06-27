using Restory.Data.WorkshopStatus;
using Restory.Gameplay.Shops.Elements;
using Restory.Gameplay.Tips;
using Restory.Gameplay.WorkshopStatus;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.WorkshopRatingsApplication
{
	public class GUI_WorkshopRatingsBonuses : MonoBehaviour
	{
		[SerializeField]
		private GameObject licenseBonusText;

		[SerializeField]
		private GameObject tipsBonusText;

		private WorkshopStatusService workshopStatusService;

		private ElementsShopService elementsShopService;

		private TipsGenerator tipsGenerator;

		[Inject]
		private void Construct(WorkshopStatusService workshopStatusService, ElementsShopService elementsShopService, TipsGenerator tipsGenerator)
		{
			this.workshopStatusService = workshopStatusService;
			this.elementsShopService = elementsShopService;
			this.tipsGenerator = tipsGenerator;
			if (base.isActiveAndEnabled)
			{
				UpdateView();
				if (workshopStatusService != null)
				{
					workshopStatusService.OnStatusAdded -= ResolveOnStatusAdded;
					workshopStatusService.OnStatusAdded += ResolveOnStatusAdded;
					workshopStatusService.OnStatusRemoved -= ResolveOnStatusRemoved;
					workshopStatusService.OnStatusRemoved += ResolveOnStatusRemoved;
				}
			}
		}

		private void OnEnable()
		{
			UpdateView();
			if (workshopStatusService != null)
			{
				workshopStatusService.OnStatusAdded -= ResolveOnStatusAdded;
				workshopStatusService.OnStatusAdded += ResolveOnStatusAdded;
				workshopStatusService.OnStatusRemoved -= ResolveOnStatusRemoved;
				workshopStatusService.OnStatusRemoved += ResolveOnStatusRemoved;
			}
		}

		private void OnDisable()
		{
			if (workshopStatusService.MonoShellExists())
			{
				workshopStatusService.OnStatusAdded -= ResolveOnStatusAdded;
				workshopStatusService.OnStatusRemoved -= ResolveOnStatusRemoved;
			}
		}

		private void UpdateView()
		{
			if (!(elementsShopService == null) && tipsGenerator != null)
			{
				licenseBonusText.SetActive(elementsShopService.ContainsLicenseMultiplierStatus());
				tipsBonusText.SetActive(tipsGenerator.ContainsMultiplierStatus());
			}
		}

		private void ResolveOnStatusAdded(WorkshopStatusService service, StatusInfo status)
		{
			UpdateView();
		}

		private void ResolveOnStatusRemoved(WorkshopStatusService service, StatusInfo status)
		{
			UpdateView();
		}
	}
}
