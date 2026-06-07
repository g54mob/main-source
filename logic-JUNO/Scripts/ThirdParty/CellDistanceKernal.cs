using System.Collections.Generic;
using UnityEngine;

public class CellDistanceKernal
{
	public int[] x;

	public int[] y;

	public float[] Distance;

	public float[] NeighbourClosestDistance;

	public int _iXLength;

	public int _iYLength;

	public float _fSearchSize;

	public bool _bClamp;

	protected bool _bIsSetup;

	public void SetupCheck(int iXLength, int iYLength, float fSearchSize, bool bClamp)
	{
		if (!_bIsSetup)
		{
			InitalizeKernal(iXLength, iYLength, fSearchSize, bClamp);
		}
		else if (iXLength != _iXLength || iYLength != _iYLength || fSearchSize != _fSearchSize || bClamp != _bClamp)
		{
			InitalizeKernal(iXLength, iYLength, fSearchSize, bClamp);
		}
	}

	public void InitalizeKernal(int iXLength, int iYLength, float fSearchSize, bool bClamp)
	{
		_iXLength = iXLength;
		_iYLength = iYLength;
		_fSearchSize = fSearchSize;
		_bClamp = bClamp;
		Vector2 vector = new Vector2(1f / (float)_iXLength, 1f / (float)_iYLength);
		int num = (int)(_fSearchSize * 2f * (float)_iXLength) + 2;
		int num2 = (int)(_fSearchSize * 2f * (float)_iYLength) + 2;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		List<float> list3 = new List<float>();
		List<float> list4 = new List<float>();
		List<int> list5 = new List<int>();
		List<int> list6 = new List<int>();
		List<float> list7 = new List<float>();
		List<float> list8 = new List<float>();
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int num3 = i - (int)((float)num / 2f);
				int num4 = j - (int)((float)num2 / 2f);
				float num5 = 0f;
				float num6 = 0f;
				if (num3 < 0)
				{
					num5 = 1f;
				}
				if (num3 > 0)
				{
					num5 = -1f;
				}
				if (num4 < 0)
				{
					num6 = 1f;
				}
				if (num4 > 0)
				{
					num6 = -1f;
				}
				float magnitude = new Vector2((float)num3 * vector.x, (float)num4 * vector.y).magnitude;
				float magnitude2 = new Vector2(((float)num3 + num5) * vector.x, ((float)num4 + num6) * vector.y).magnitude;
				magnitude /= _fSearchSize;
				magnitude2 /= _fSearchSize;
				list.Add(num3);
				list2.Add(num4);
				list3.Add(magnitude);
				list4.Add(magnitude2);
			}
		}
		int count = list3.Count;
		for (int k = 0; k < count; k++)
		{
			float num7 = float.MaxValue;
			int num8 = int.MinValue;
			for (int l = 0; l < list3.Count; l++)
			{
				if (list3[l] < num7)
				{
					num7 = list3[l];
					num8 = l;
				}
			}
			if (num8 != int.MinValue)
			{
				if (list3[num8] < 1f)
				{
					list5.Add(list[num8]);
					list6.Add(list2[num8]);
					list7.Add(list3[num8]);
					list8.Add(list4[num8]);
				}
				list.RemoveAt(num8);
				list2.RemoveAt(num8);
				list3.RemoveAt(num8);
				list4.RemoveAt(num8);
			}
		}
		x = list5.ToArray();
		y = list6.ToArray();
		Distance = list7.ToArray();
		NeighbourClosestDistance = list8.ToArray();
		_bIsSetup = true;
	}

	public int GetXSearchCoordinate(int ixSearchCenter, int iSearchIndex)
	{
		if (iSearchIndex >= x.Length)
		{
			return ixSearchCenter;
		}
		int num = ixSearchCenter + x[iSearchIndex];
		if (!_bClamp)
		{
			return num % _iXLength;
		}
		return Mathf.Clamp(num, 0, _iXLength);
	}

	public int GetYSearchCoordinate(int iySearchCenter, int iSearchIndex)
	{
		if (iSearchIndex >= y.Length)
		{
			return iySearchCenter;
		}
		int num = iySearchCenter + y[iSearchIndex];
		if (!_bClamp)
		{
			return num % _iYLength;
		}
		return Mathf.Clamp(num, 0, _iYLength);
	}

	public float GetDistance(int iSearchIndex)
	{
		if (iSearchIndex >= Distance.Length)
		{
			return float.MaxValue;
		}
		return Distance[iSearchIndex];
	}

	public float GetNeighbourShortestDistance(int iSearchIndex)
	{
		if (iSearchIndex >= NeighbourClosestDistance.Length)
		{
			return float.MaxValue;
		}
		return NeighbourClosestDistance[iSearchIndex];
	}

	public int KernalLength()
	{
		return Distance.Length;
	}
}
