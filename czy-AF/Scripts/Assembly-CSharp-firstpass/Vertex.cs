using UnityEngine;

public class Vertex
{
	public float x;

	public float y;

	public float z;

	public Vertex(float _x, float _y, float _z)
	{
		x = _x;
		y = _y;
		z = _z;
	}

	public Vertex(Vector3 _pos)
	{
		x = _pos.x;
		y = _pos.y;
		z = _pos.z;
	}
}
