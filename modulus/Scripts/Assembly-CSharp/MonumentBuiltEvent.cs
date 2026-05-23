using Data.FactoryFloor;
using Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/FactoryFloor/MonumentBuiltEvent", fileName = "MonumentBuiltEvent", order = 0)]
public class MonumentBuiltEvent : BaseEvent<FactoryObject>
{
}
