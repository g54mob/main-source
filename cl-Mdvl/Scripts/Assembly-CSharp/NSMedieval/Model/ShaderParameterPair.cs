using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ShaderParameterPair
	{
		[SerializeField]
		private string parameterId;

		[SerializeField]
		private float parameterValue;

		public string ParameterId => parameterId;

		public float ParameterValue => parameterValue;
	}
}
