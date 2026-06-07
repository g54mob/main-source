using System;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class ReductionSettings : IDataValidate
	{
		[Range(0f, 0.2f)]
		public float simpleDistance;

		[Range(0f, 0.2f)]
		public float shapeDistance;

		public bool IsEnabled => false;

		public float GetMaxConnectionDistance()
		{
			return 0f;
		}

		public ReductionSettings Clone()
		{
			return null;
		}

		public void DataValidate()
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
