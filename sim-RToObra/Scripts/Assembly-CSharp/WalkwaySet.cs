using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WalkwaySet
{
	public List<Walkway> walkways;

	public WalkwaySet(ICollection<Walkway> walkways_)
	{
		walkways = new List<Walkway>(walkways_);
	}

	public Walkway.Sample GetBestSample(Vector3 footPos)
	{
		Walkway.Sample sample = default(Walkway.Sample);
		foreach (Walkway walkway in walkways)
		{
			if (!(walkway == null))
			{
				Walkway.Sample sample2 = walkway.GetSample(footPos.ToVector2XZ());
				if (sample2.valid && sample2.worldY < footPos.y + 0.1f)
				{
					sample = GetBetter(sample2, sample);
				}
			}
		}
		return sample;
	}

	public static Walkway.Sample GetBetter(Walkway.Sample a, Walkway.Sample b)
	{
		if (!b.valid)
		{
			return a;
		}
		if (!a.valid)
		{
			return b;
		}
		if (Mathf.Abs(a.worldY - b.worldY) < 0.05f)
		{
			if (a.walkway.transform.position.y > b.walkway.transform.position.y)
			{
				return a;
			}
			return b;
		}
		if (a.worldY > b.worldY)
		{
			return a;
		}
		return b;
	}

	public Walkway Find(string id, string requiredCallingId = null)
	{
		foreach (Walkway walkway in walkways)
		{
			if (walkway.id == id)
			{
				return walkway;
			}
		}
		if (requiredCallingId != null)
		{
			throw new UnityException(string.Format("Required walkway \"{0}\" not found. Referenced by {1}", id, requiredCallingId));
		}
		return null;
	}

	public Walkway FindUnderTrapdoor(WalkwayTrapdoor trapdoor)
	{
		Vector3 position = trapdoor.transform.position;
		float num = float.MaxValue;
		Walkway result = null;
		foreach (Walkway walkway in walkways)
		{
			float y = walkway.transform.worldToLocalMatrix.MultiplyPoint(position).y;
			if (y > -0.1f && y < num)
			{
				result = walkway;
				num = y;
			}
		}
		return result;
	}
}
