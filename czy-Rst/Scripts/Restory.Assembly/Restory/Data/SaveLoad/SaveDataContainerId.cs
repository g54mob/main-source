using UnityEngine;

namespace Restory.Data.SaveLoad
{
	[CreateAssetMenu(menuName = "Restory/Data/SaveSystem/Create SaveDataContainerId", fileName = "SaveDataContainerId - NewName", order = 0)]
	public class SaveDataContainerId : ScriptableObject
	{
		[SerializeField]
		private string id = string.Empty;

		public string ID => id;
	}
}
