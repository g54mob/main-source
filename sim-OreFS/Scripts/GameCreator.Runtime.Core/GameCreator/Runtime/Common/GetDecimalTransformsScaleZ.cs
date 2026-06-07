using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scale Z")]
	[Category("Transforms/Scale Z")]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue)]
	[Description("The Z component of a Vector3 that represents a scale")]
	[Keywords(new string[] { "Position", "Vector3", "Forward", "Backward" })]
	public class GetDecimalTransformsScaleZ : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetScale m_Scale = GetScaleSelf.Create;

		public override string String => $"{m_Scale}.Z";

		public override double Get(Args args)
		{
			return m_Scale.Get(args).z;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Scale.Get(gameObject).z;
		}
	}
}
