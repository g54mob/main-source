using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class MonoBehaviourDistanceComparer : IComparer<MonoBehaviour>
	{
		private static MonoBehaviourDistanceComparer _default;

		private Vector3 _testPosition;

		private float _heightMultiplier = 1f;

		public static MonoBehaviourDistanceComparer Get(Vector3 testPosition, float heightMultiplier = 1f)
		{
			if (_default == null)
			{
				_default = new MonoBehaviourDistanceComparer();
			}
			_default._testPosition = testPosition;
			_default._heightMultiplier = heightMultiplier;
			return _default;
		}

		public int Compare(MonoBehaviour x, MonoBehaviour y)
		{
			if ((object)x == null || (object)y == null)
			{
				return 0;
			}
			float num = Vector3.SqrMagnitude((_testPosition - x.transform.position).MulY(_heightMultiplier));
			float num2 = Vector3.SqrMagnitude((_testPosition - y.transform.position).MulY(_heightMultiplier));
			if (num > num2)
			{
				return 1;
			}
			if (num < num2)
			{
				return -1;
			}
			return 0;
		}
	}
}
