using Restory.Data.Devices;
using UnityEngine;

namespace Restory.Data.PC
{
	[CreateAssetMenu(menuName = "Restory/PC/HackingContentTable", fileName = "HackingContentTable")]
	public class HackingContentTable : ScriptableObject
	{
		[Header("Categories")]
		[SerializeField]
		private DeviceCategory consoleCategory;

		[SerializeField]
		private DeviceCategory phoneCategory;

		[SerializeField]
		private DeviceCategory laptopCategory;

		[Space]
		[Header("Localization")]
		[SerializeField]
		private string consoleCheckLocalizationKey;

		[SerializeField]
		private string phoneCheckLocalizationKey;

		[SerializeField]
		private string laptopCheckLocalizationKey;

		[Space]
		[Header("Content")]
		[SerializeField]
		[TextArea(10, 25)]
		private string consoleContent;

		[SerializeField]
		[TextArea(10, 25)]
		private string phoneContent;

		[SerializeField]
		[TextArea(10, 25)]
		private string laptopContent;

		public bool IsTableContainsDataForDeviceCategory(IDeviceCategory category, out string deviceCheckLocalizationKey, out string hackingContent)
		{
			deviceCheckLocalizationKey = string.Empty;
			hackingContent = string.Empty;
			if (category == null)
			{
				Debug.LogError("Failed to get data for device, category is null");
				return false;
			}
			if (category.ID == consoleCategory.ID)
			{
				deviceCheckLocalizationKey = consoleCheckLocalizationKey;
				hackingContent = consoleContent;
				return true;
			}
			if (category.ID == phoneCategory.ID)
			{
				deviceCheckLocalizationKey = phoneCheckLocalizationKey;
				hackingContent = phoneContent;
				return true;
			}
			if (category.ID == laptopCategory.ID)
			{
				deviceCheckLocalizationKey = laptopCheckLocalizationKey;
				hackingContent = laptopContent;
				return true;
			}
			Debug.LogError("HackingContentTable not contains data for category " + category.ID);
			return false;
		}
	}
}
