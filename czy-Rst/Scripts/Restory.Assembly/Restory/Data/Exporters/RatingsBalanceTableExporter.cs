using System;
using Restory.Data.Tips;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.Shops.Elements;
using Restory.Gameplay.WorkshopStatus;
using UnityEngine;

namespace Restory.Data.Exporters
{
	[CreateAssetMenu(menuName = "Restory/Exporters/RatingsBalanceTableExporter", fileName = "RatingsBalanceTableExporter")]
	public class RatingsBalanceTableExporter : ScriptableObject
	{
		private const string TARGETS_GROUP = "Targets";

		private const string TIPS_GROUP = "TipsGeneratorSettings Table";

		private const string ELEMENTS_GROUP = "ElementsShopService Table";

		private const string RATING_GROUP = "RatingBasedWorkshopStatusEvaluator Table";

		[SerializeField]
		private TipsGeneratorSettings tipsGeneratorSettings;

		[SerializeField]
		private ElementsShopService elementsShopService;

		[SerializeField]
		private RatingBasedWorkshopStatusEvaluator ratingBasedWorkshopStatusEvaluator;

		[SerializeField]
		private string tipsMultiplierHeaderName = "TipsMultiplier";

		[SerializeField]
		private string statusesForTipsMultiplierHeaderName = "StatusesForTipsMultiplier";

		[SerializeField]
		private string licensePriceMultiplierHeaderName = "LicensePriceMultiplier";

		[SerializeField]
		private string statusesForLicensePriceMultiplierHeaderName = "StatusesForLicensePriceMultiplier";

		[SerializeField]
		private string reviewsByRatingHeaderName = "Reviews\\Rating";

		[Space]
		[SerializeField]
		private float importedTipsMultiplier;

		[SerializeField]
		private StatusInfo[] importedTipsStatuses = Array.Empty<StatusInfo>();

		[SerializeField]
		private float importedLicenseMultiplier;

		[SerializeField]
		private StatusInfo[] importedLicenseStatuses = Array.Empty<StatusInfo>();

		[SerializeField]
		private RatingBasedWorkshopStatusEvaluator.ReviewsThresholdRow[] importedRatingRows = Array.Empty<RatingBasedWorkshopStatusEvaluator.ReviewsThresholdRow>();

		public TipsGeneratorSettings TipsGeneratorSettings => tipsGeneratorSettings;

		public ElementsShopService ElementsShopService => elementsShopService;

		public RatingBasedWorkshopStatusEvaluator RatingBasedWorkshopStatusEvaluator => ratingBasedWorkshopStatusEvaluator;

		public string TipsMultiplierHeaderName => tipsMultiplierHeaderName;

		public string StatusesForTipsMultiplierHeaderName => statusesForTipsMultiplierHeaderName;

		public string LicensePriceMultiplierHeaderName => licensePriceMultiplierHeaderName;

		public string StatusesForLicensePriceMultiplierHeaderName => statusesForLicensePriceMultiplierHeaderName;

		public string ReviewsByRatingHeaderName => reviewsByRatingHeaderName;
	}
}
