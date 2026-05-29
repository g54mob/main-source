using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class TransformDistanceComparer : IComparer<Transform>
	{
		private static TransformDistanceComparer _default;

		private Vector3 _testPosition;

		private float _heightMultiplier = 1f;

		public static TransformDistanceComparer Get(Vector3 testPosition, float heightMultiplier = 1f)
		{
			if (_default == null)
			{
				_default = new TransformDistanceComparer();
			}
			_default._testPosition = testPosition;
			_default._heightMultiplier = heightMultiplier;
			return _default;
		}

		public int Compare(Transform x, Transform y)
		{
			float num = Vector3.SqrMagnitude((_testPosition - x.position).MulY(_heightMultiplier));
			float num2 = Vector3.SqrMagnitude((_testPosition - y.position).MulY(_heightMultiplier));
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
