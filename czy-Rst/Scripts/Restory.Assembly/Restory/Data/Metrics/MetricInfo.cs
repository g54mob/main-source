using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Metrics
{
	[CreateAssetMenu(menuName = "Restory/Metrics/MetricInfo", fileName = "Name - MetricInfo")]
	public class MetricInfo : RestoryEntityInfoBase
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string descriptionLocalizationKey;

		public string NameLocalizationKey => nameLocalizationKey;

		public string DescriptionLocalizationKey => descriptionLocalizationKey;
	}
}
