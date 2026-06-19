using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Room Item Filter Database", order = 1031)]
	public class RoomItemFilterDatabase : ScriptableObjectWithID
	{
		public RoomItemFilter[] Filters;

		public RoomItemFilter LockedFilter;
	}
}
