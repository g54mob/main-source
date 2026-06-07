using Events.UI.BarInfo;
using UnityEngine;

namespace Events.UI
{
	[CreateAssetMenu(menuName = "Events/UI/ShowBarInfoEvent", fileName = "ShowBarInfoEvent", order = 0)]
	public class ShowBarInfoEvent : BaseEvent<BarInfoDto>
	{
	}
}
