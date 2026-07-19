using System;
using UnityEngine;

public class Vector3ToHash
{
	private int m_hashCode;

	private Vector3 m_v;

	public Vector3ToHash(Vector3 v)
	{
		m_v = v;
		m_hashCode = new
		{
			x = Math.Round(v.x, 4),
			y = Math.Round(v.y, 4),
			z = Math.Round(v.z, 4)
		}.GetHashCode();
	}

	public override int GetHashCode()
	{
		return m_hashCode;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return ((Vector3ToHash)obj).m_v == m_v;
	}
}
