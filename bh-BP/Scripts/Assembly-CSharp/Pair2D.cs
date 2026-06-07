using System.Collections.Generic;
using UnityEngine;

public class Pair2D
{
	public Vector2D A;

	public Vector2D B;

	public new string ToString()
	{
		return null;
	}

	public Pair2D(Vector2D pointA, Vector2D pointB)
	{
	}

	public Pair2D(Vector2 pointA, Vector2 pointB)
	{
	}

	public Pair2 ToPair2()
	{
		return default(Pair2);
	}

	public static List<Pair2D> GetList(List<Vector2D> list, bool connect = true)
	{
		return null;
	}

	public static Pair2D Zero()
	{
		return null;
	}
}
