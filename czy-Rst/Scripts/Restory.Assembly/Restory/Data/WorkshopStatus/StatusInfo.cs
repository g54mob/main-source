using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.WorkshopStatus
{
	[CreateAssetMenu(menuName = "Restory/WorkshopStatus/StatusInfo", fileName = "Name - StatusInfo")]
	public class StatusInfo : RestoryEntityInfoBase
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private StatusCategory category;

		public string NameLocalizationKey => nameLocalizationKey;

		public StatusCategory Category => category;
	}
}
