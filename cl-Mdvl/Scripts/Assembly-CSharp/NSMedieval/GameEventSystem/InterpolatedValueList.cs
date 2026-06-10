using System;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class InterpolatedValueList : NSEipix.Base.Model
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private int threshold;

		[SerializeField]
		private SerializablePair<int, float>[] list;

		private int largestKey;

		private bool largestKeyInit;

		public string Name => name;

		public int GetLargestKey()
		{
			if (!largestKeyInit)
			{
				largestKeyInit = true;
				largestKey = list.Max((SerializablePair<int, float> item) => item.Key);
			}
			return largestKey;
		}

		public bool IsEmpty()
		{
			if (list != null)
			{
				return list.Length == 0;
			}
			return true;
		}

		public float GetMultiplierInterpolated(int keyValue)
		{
			if (keyValue <= threshold || list == null || list.Length == 0)
			{
				return 0f;
			}
			if (list.Length == 1)
			{
				return list[0].Value;
			}
			int num = int.MaxValue;
			int num2 = int.MaxValue;
			int num3 = 0;
			int num4 = 0;
			float value = list[0].Value;
			float value2 = list[0].Value;
			SerializablePair<int, float>[] array = list;
			foreach (SerializablePair<int, float> serializablePair in array)
			{
				int num5 = Math.Abs(serializablePair.Key - keyValue);
				if (num5 < num && serializablePair.Key <= keyValue)
				{
					num = num5;
					num3 = serializablePair.Key;
					value = serializablePair.Value;
				}
				num5 = Math.Abs(serializablePair.Key - keyValue);
				if (num5 < num2 && serializablePair.Key >= keyValue)
				{
					num2 = num5;
					num4 = serializablePair.Key;
					value2 = serializablePair.Value;
				}
			}
			if (num3 == num4)
			{
				return value;
			}
			float t = (float)(keyValue - num3) / (float)(num4 - num3);
			return Mathf.Lerp(value, value2, t);
		}

		public override string GetID()
		{
			return name;
		}
	}
}
