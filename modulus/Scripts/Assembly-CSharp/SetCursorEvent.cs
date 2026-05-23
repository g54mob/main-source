using Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/UI/SetCursorEvent", fileName = "SetCursorEvent", order = 0)]
public class SetCursorEvent : BaseEvent<(Texture2D, string, Vector2)>
{
}
