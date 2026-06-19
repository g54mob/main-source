using System;
using System.Collections.Generic;

namespace TH20
{
	public class LoadedDice
	{
		private readonly int _mNumWeights;

		private readonly float[] _mWeights;

		private readonly int[] _mAlias;

		private readonly Random _mRnd;

		public int NumWeights => _mNumWeights;

		public LoadedDice(Random random, float[] weights)
		{
			_mRnd = random;
			_mNumWeights = weights.Length;
			_mWeights = new float[_mNumWeights];
			_mAlias = new int[_mNumWeights];
			float num = 0f;
			for (int i = 0; i < _mNumWeights; i++)
			{
				num += weights[i];
			}
			float num2 = 1f / num * (float)_mNumWeights;
			float[] array = new float[_mNumWeights];
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			list.Capacity = _mNumWeights;
			list2.Capacity = _mNumWeights;
			for (int j = 0; j < _mNumWeights; j++)
			{
				array[j] = weights[j] * num2;
				if (array[j] < 1f)
				{
					list.Add(j);
				}
				else
				{
					list2.Add(j);
				}
			}
			while (list.Count > 0 && list2.Count > 0)
			{
				int num3 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				int num4 = list2[list2.Count - 1];
				list2.RemoveAt(list2.Count - 1);
				_mWeights[num3] = array[num3];
				_mAlias[num3] = num4;
				array[num4] = array[num4] + array[num3] - 1f;
				if (array[num4] < 1f)
				{
					list.Add(num4);
				}
				else
				{
					list2.Add(num4);
				}
			}
			while (list2.Count > 0)
			{
				int num5 = list2[list2.Count - 1];
				list2.RemoveAt(list2.Count - 1);
				_mWeights[num5] = 1f;
			}
			while (list.Count > 0)
			{
				int num6 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				_mWeights[num6] = 1f;
			}
		}

		public int Roll()
		{
			int num = _mRnd.Next(0, _mNumWeights);
			if (!(_mRnd.NextDouble() <= (double)_mWeights[num]))
			{
				return _mAlias[num];
			}
			return num;
		}
	}
}
