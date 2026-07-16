using UnityEngine;

public class Marker
{
	public Vector2 Position { get; private set; }

	public Quaternion Rotation { get; private set; }

	public Marker(Vector2 position, Quaternion rotation)
	{
		Position = position;
		Rotation = rotation;
	}
}
