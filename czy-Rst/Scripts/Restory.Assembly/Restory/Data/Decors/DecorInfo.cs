using Restory.Data.InteractiveObjects;
using UnityEngine;

namespace Restory.Data.Decors
{
	[CreateAssetMenu(menuName = "Restory/Decors/DecorInfo", fileName = "Name - DecorInfo")]
	public class DecorInfo : InteractiveObjectInfo
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string descriptionLocalizationKey;

		[SerializeField]
		private DecorCategory category;

		[SerializeField]
		[Min(0f)]
		private int zen = 1;

		[SerializeField]
		[Min(1f)]
		private int defaultPrice = 1;

		[SerializeField]
		private bool isNotForSale;

		public string NameLocalizationKey => nameLocalizationKey;

		public string DescriptionLocalizationKey => descriptionLocalizationKey;

		public DecorCategory Category => category;

		public int Zen => zen;

		public int DefaultPrice => defaultPrice;

		public bool IsNotForSale => isNotForSale;
	}
}
