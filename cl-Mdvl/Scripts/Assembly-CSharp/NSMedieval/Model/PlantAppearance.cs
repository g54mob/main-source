using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class PlantAppearance
	{
		[SerializeField]
		private float scale;

		[SerializeField]
		private ShaderParameterPair[] shaderParameters = new ShaderParameterPair[0];

		public float Scale => scale;

		public ShaderParameterPair[] ShaderParameters => shaderParameters;
	}
}
