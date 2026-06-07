using System;
using UnityEngine;

namespace Events.UI.Overlays
{
	[CreateAssetMenu(menuName = "Events/UI/Overlays/Fade From Black", fileName = "FadeFromBlackEvent", order = 0)]
	public class FadeFromBlackEvent : BaseEvent<(Action callback, bool showUI)>
	{
	}
}
