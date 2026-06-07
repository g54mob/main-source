using UnityEngine;

public class Slicer2DInputEvent
{
	public enum EventType
	{
		None = 0,
		Press = 1,
		Release = 2,
		Move = 3,
		SetPosition = 4
	}

	public EventType eventType;

	public Vector2 position;

	public float time;
}
