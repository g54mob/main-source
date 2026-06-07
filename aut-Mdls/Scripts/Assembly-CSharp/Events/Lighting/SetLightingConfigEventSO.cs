using Data.Lighting;
using UnityEngine;

namespace Events.Lighting
{
	[CreateAssetMenu(menuName = "Events/Lighting/SetLightingConfigEventSO", fileName = "SetLightingConfigEventSO", order = 0)]
	public class SetLightingConfigEventSO : BaseEvent<LightingConfig>
	{
	}
}
