using Restory.Data.Tables.Parameters;
using UnityEngine;

namespace Restory.Data.Localization
{
	[CreateAssetMenu(menuName = "Restory/LocalizationSystem/Create SpecifiedLocalizationKeysDatabase", fileName = "SpecifiedLocalizationKeysDatabase", order = 0)]
	public class SpecifiedLocalizationKeysDatabase : ScriptableObject, IGameParametersEntity
	{
		[SerializeField]
		[LocalizationKey]
		private string resetDeviceCustomizationConfirmationDialogue = string.Empty;

		public string ResetDeviceCustomizationConfirmationDialogue => resetDeviceCustomizationConfirmationDialogue;
	}
}
