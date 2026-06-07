using System.Collections.Generic;
using UnityEngine;

public struct Pair2
{
	public Vector2 a;

	public Vector2 b;

	public static Pair2 zero;

	public Pair2(Vector2 a, Vector2 b)
	{
		this.a = default(Vector2);
		this.b = default(Vector2);
	}

	public Pair2D ToPair2D()
	{
		return null;
	}

	public static List<Pair2> GetList(List<Vector2D> list, bool connect = true)
	{
		return null;
	}

	public static List<Pair2> GetList(Vector2List list, bool connect = true)
	{
		return null;
	}
}
