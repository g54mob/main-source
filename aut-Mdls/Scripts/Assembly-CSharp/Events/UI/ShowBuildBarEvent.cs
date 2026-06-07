using Presentation.FactoryFloor.Toolbar;
using UnityEngine;

namespace Events.UI
{
	[CreateAssetMenu(menuName = "Events/UI/ShowBuildBarEvent", fileName = "ShowBuildBarEvent", order = 0)]
	public class ShowBuildBarEvent : BaseEvent<(BuildMode, int)>
	{
	}
}
