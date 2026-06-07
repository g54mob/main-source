using UnityEngine;

public struct Circle
{
	private Vector2 origin;

	private float radius;

	public Vector2 Origin => origin;

	public float Radius => radius;

	public Circle(Vector2 origin, float radius)
	{
		this.origin = origin;
		this.radius = radius;
	}

	public override string ToString()
	{
		return $"[Line: Origin={origin}, Radius={radius}]";
	}
}
