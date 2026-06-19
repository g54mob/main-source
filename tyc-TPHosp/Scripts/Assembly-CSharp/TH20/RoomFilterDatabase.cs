using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Room Filter Database", order = 1034)]
	public class RoomFilterDatabase : ScriptableObjectWithID
	{
		public RoomFilter[] Filters;
	}
}
