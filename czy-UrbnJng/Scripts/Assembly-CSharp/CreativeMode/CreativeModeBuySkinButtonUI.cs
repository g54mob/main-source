using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class CreativeModeBuySkinButtonUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI costText;

		[SerializeField]
		private Button buyButton;

		private ObjectSO selectedObjectSo;

		private string SelectedGuid;

		private int variant;

		private void OnEnable()
		{
			buyButton.onClick.AddListener(BuySkin);
		}

		private void OnDestroy()
		{
			buyButton.onClick.RemoveListener(BuySkin);
		}

		public void SelectSkin(ObjectSO objectSo, string GUID, bool skinClose, int variantNumber)
		{
			selectedObjectSo = objectSo;
			SelectedGuid = GUID;
			variant = variantNumber;
			buyButton.gameObject.SetActive(value: false);
			if (skinClose)
			{
				buyButton.gameObject.SetActive(value: true);
				costText.text = selectedObjectSo.variantsList[variantNumber].price.ToString();
			}
		}

		private void BuySkin()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.Coins >= selectedObjectSo.variantsList[variant].price)
			{
				AllServices.Container.Single<ICoinService>().SubtractCoin(selectedObjectSo.variantsList[variant].price);
				buyButton.gameObject.SetActive(value: false);
				CollectionManager.Instance.NewSkinPurchased(SelectedGuid, selectedObjectSo);
			}
			buyButton.gameObject.SetActive(value: false);
		}
	}
}
