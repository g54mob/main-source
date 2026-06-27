using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomHelper
{
	public static Vector3 TriangleRandomPos(Vector3 _p1, Vector3 _p2, Vector3 _p3)
	{
		Vector3 vector = new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		return (vector.x * _p1 + vector.y * _p2 + vector.z * _p3) / (vector.x + vector.y + vector.z);
	}

	public static Vector3 SphereRandomPos(Vector3 _sphereCenter, float _radius)
	{
		float x = UnityEngine.Random.Range(_sphereCenter.x - _radius, _sphereCenter.x + _radius);
		float y = UnityEngine.Random.Range(_sphereCenter.y - _radius, _sphereCenter.y + _radius);
		float z = UnityEngine.Random.Range(_sphereCenter.z - _radius, _sphereCenter.z + _radius);
		return new Vector3(x, y, z);
	}

	public static Vector3 CircleRandomPos(Vector3 _circleCenter, float _radius, Vector3 _Up)
	{
		Vector3 vector = Vector3.one - _Up;
		float x = UnityEngine.Random.Range(_circleCenter.x - _radius * vector.x, _circleCenter.x + _radius * vector.x);
		float y = UnityEngine.Random.Range(_circleCenter.y - _radius * vector.y, _circleCenter.y + _radius * vector.y);
		float z = UnityEngine.Random.Range(_circleCenter.z - _radius * vector.z, _circleCenter.z + _radius * vector.z);
		return new Vector3(x, y, z);
	}

	public static Vector3 CircleRandomPos(Vector3 _circleCenter, float _radiusMin, float _radiusMax)
	{
		float f = 360f * UnityEngine.Random.value;
		float x = UnityEngine.Random.Range(_radiusMin, _radiusMax) * Mathf.Cos(f);
		float z = UnityEngine.Random.Range(_radiusMin, _radiusMax) * Mathf.Sin(f);
		return _circleCenter + new Vector3(x, 0f, z);
	}

	public static Vector3[] CircleRandomPos(Vector3 _circleCenter, float _radiusMin, float _radiusMax, int returnAmount = 3)
	{
		int num = Mathf.Max(Mathf.Abs(returnAmount), 1);
		Vector3[] array = new Vector3[num];
		for (int i = 0; i < num; i++)
		{
			float f = 360f * UnityEngine.Random.value;
			float x = UnityEngine.Random.Range(_radiusMin, _radiusMax) * Mathf.Cos(f);
			float z = UnityEngine.Random.Range(_radiusMin, _radiusMax) * Mathf.Sin(f);
			Vector3 vector = _circleCenter + new Vector3(x, 0f, z);
			array[i] = vector;
		}
		return array;
	}

	public static Vector3[] CircleRandomPos(Vector3 _circleCenter, float _radiusMin, float _radiusMax, int returnAmount = 3, float pointsOffset = 0f)
	{
		List<Vector3> list = new List<Vector3>();
		Vector3 item = CircleRandomPos(_circleCenter, _radiusMin, _radiusMax);
		list.Add(item);
		float num = Mathf.Clamp(pointsOffset, 0f, _radiusMax);
		int num2 = Mathf.Max(Mathf.FloorToInt((MathF.PI * _radiusMax * _radiusMax - MathF.PI * _radiusMin * _radiusMin) / (MathF.PI * num * num)), returnAmount);
		for (int i = 0; i < num2; i++)
		{
			bool flag = false;
			while (!flag)
			{
				flag = true;
				Vector3 vector = CircleRandomPos(_circleCenter, _radiusMin, _radiusMax);
				foreach (Vector3 item2 in list)
				{
					if (Vector3.Distance(item2, vector) < num)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(vector);
				}
			}
		}
		Vector3[] array = new Vector3[num2];
		for (int j = 0; j < num2; j++)
		{
			array[j] = list[j];
		}
		return array;
	}

	public static int RandomSign()
	{
		if (UnityEngine.Random.Range(0, 2) != 1)
		{
			return -1;
		}
		return 1;
	}
}
