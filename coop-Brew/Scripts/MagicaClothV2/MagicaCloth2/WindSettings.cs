using System;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class WindSettings : IValid, IDataValidate
	{
		[Range(0f, 2f)]
		public float influence;

		[Range(0f, 2f)]
		public float frequency;

		[Range(0f, 2f)]
		public float turbulence;

		[Range(0f, 1f)]
		public float blend;

		[Range(0f, 1f)]
		public float synchronization;

		[Range(0f, 1f)]
		public float depthWeight;

		[Range(0f, 10f)]
		public float movingWind;

		public bool IsValid()
		{
			return false;
		}

		public void DataValidate()
		{
		}

		public WindSettings Clone()
		{
			return null;
		}
	}
}
