using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Room Item Filter", order = 1032)]
	public class RoomItemFilter : ScriptableObjectWithID
	{
		public LocalisedString LocalisedName;

		public bool IsUGC;
	}
}
