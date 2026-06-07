using UnityEngine;

namespace Events.AutoSave
{
	[CreateAssetMenu(menuName = "Events/AutoSave/On Auto Save", fileName = "AutoSaveEvent", order = 0)]
	public class AutoSaveEvent : BaseEvent<int>
	{
	}
}
