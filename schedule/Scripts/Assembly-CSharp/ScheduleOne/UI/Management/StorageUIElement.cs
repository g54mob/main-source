using ScheduleOne.ObjectScripts;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management
{
	public class StorageUIElement : WorldspaceUIElement
	{
		public Image Icon;

		public PlaceableStorageEntity AssignedEntity { get; protected set; }

		public void Initialize(PlaceableStorageEntity entity)
		{
		}

		protected virtual void RefreshUI()
		{
		}
	}
}
