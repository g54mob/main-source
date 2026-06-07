using UnityEngine;

namespace Gh.Tk
{
	public class PreferedZone : MonoBehaviour
	{
		[DropDownChoice(typeof(RoomZones), "GetAllZoneIds")]
		public string[] PreferedZoneIds;
	}
}
