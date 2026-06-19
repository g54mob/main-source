using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public class Vector3SerialziableArray : List<Vector3Serialziable>
	{
		public static implicit operator Vector3[](Vector3SerialziableArray v)
		{
			Vector3[] array = new Vector3[v.Count];
			for (int i = 0; i < v.Count; i++)
			{
				array[i] = v[i];
			}
			return array;
		}

		public static implicit operator Vector3SerialziableArray(Vector3[] v)
		{
			Vector3SerialziableArray vector3SerialziableArray = new Vector3SerialziableArray();
			for (int i = 0; i < v.Length; i++)
			{
				vector3SerialziableArray.Add(v[i]);
			}
			return vector3SerialziableArray;
		}
	}
}
