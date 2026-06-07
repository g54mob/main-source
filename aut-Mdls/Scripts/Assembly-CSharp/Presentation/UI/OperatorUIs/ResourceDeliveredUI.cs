using Data.FactoryFloor.Resources;
using Data.Statistics;
using TMPro;
using UnityEngine;

namespace Presentation.UI.OperatorUIs
{
	public class ResourceDeliveredUI : MonoBehaviour
	{
		private const string DeliveredTextLocaKey = "Demo.Delivered";

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private ResourceInfoPanelContent _infoPanel;

		[SerializeField]
		private StatisticsSO _statisticsSO;

		private string _resourceLocaKey;

		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void OnLanguageUpdate()
		{
			UpdateTitleText(_resourceLocaKey);
		}

		public void UpdateResource(ResourceDataSO resourceData)
		{
			_infoPanel.UpdateContent(resourceData as NonShapeResourceDataSO);
		}

		public void UpdateTitleText(string resourceLocaKey)
		{
			_resourceLocaKey = resourceLocaKey;
			_titleText.SetText(string.Format(LocalizationUtility.GetLocalizedText("Demo.Delivered"), LocalizationUtility.GetLocalizedText(resourceLocaKey)));
		}

		public void UpdateAmountText(int deliveredResourceId, bool alwaysShow, int max = -1)
		{
			uint deliveredStatistic = _statisticsSO.GetDeliveredStatistic(deliveredResourceId);
			deliveredStatistic -= _statisticsSO.GetWithdrawnStatistic(deliveredResourceId);
			base.gameObject.SetActive(deliveredStatistic != 0 || alwaysShow);
			string text = ((max == -1) ? deliveredStatistic.ToString() : $"{deliveredStatistic}/{max}");
			_amountText.SetText(text);
		}
	}
}
