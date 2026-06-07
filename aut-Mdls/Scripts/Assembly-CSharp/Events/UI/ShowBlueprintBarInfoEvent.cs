using Events.UI.BarInfo;
using UnityEngine;

namespace Events.UI
{
	[CreateAssetMenu(menuName = "Events/UI/Blueprints/ShowBlueprintBarInfoEvent", fileName = "ShowBlueprintBarInfoEvent", order = 0)]
	public class ShowBlueprintBarInfoEvent : BaseEvent<BlueprintBarInfoDto>
	{
	}
}
