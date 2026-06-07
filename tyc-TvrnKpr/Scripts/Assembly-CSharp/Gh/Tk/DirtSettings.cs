using UnityEngine;

namespace Gh.Tk
{
	public class DirtSettings : MonoBehaviour
	{
		public DirtSetting[] Settings;

		public DustSettings DustSettings;

		[DropDownChoice(typeof(RoomZones), "GetAllZoneIds")]
		public string[] DeepCleanZoneOrder;

		public float PropFilthTraitThreshold;
	}
}
