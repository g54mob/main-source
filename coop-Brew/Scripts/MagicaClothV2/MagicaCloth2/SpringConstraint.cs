using System;
using UnityEngine;

namespace MagicaCloth2
{
	public class SpringConstraint : IDisposable
	{
		[Serializable]
		public class SerializeData : IDataValidate
		{
			public bool useSpring;

			[Range(0.001f, 0.2f)]
			public float springPower;

			[Range(0f, 0.5f)]
			public float limitDistance;

			[Range(0f, 1f)]
			public float normalLimitRatio;

			[Range(0f, 1f)]
			public float springNoise;

			public void DataValidate()
			{
			}

			public SerializeData Clone()
			{
				return null;
			}
		}

		public struct SpringConstraintParams
		{
			public float springPower;

			public float limitDistance;

			public float normalLimitRatio;

			public float springNoise;

			public void Convert(SerializeData sdata, ClothProcess.ClothType clothType)
			{
			}
		}

		public void Dispose()
		{
		}
	}
}
