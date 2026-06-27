using Restory.Data.InteractiveObjects;
using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementsBoxInfo", fileName = "Name - ElementsBoxInfo")]
	public class ElementsBoxInfo : InteractiveObjectInfo
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string descriptionLocalizationKey;

		[SerializeField]
		[Min(1f)]
		private int defaultPrice = 1;

		public string NameLocalizationKey => nameLocalizationKey;

		public string DescriptionLocalizationKey => descriptionLocalizationKey;

		public int DefaultPrice => defaultPrice;
	}
}
