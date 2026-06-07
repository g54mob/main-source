using Events;
using UnityEngine;
using Utils.Enums;

[CreateAssetMenu(menuName = "Events/Camera/AvailableCamMovementChanged", fileName = "AvailableCamMovementChanged", order = 0)]
public class AvailableCamMovementChangedEvent : BaseEvent<MovementDirectionFlags>
{
}
