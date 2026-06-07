using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scale Y")]
	[Category("Transforms/Scale Y")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("The Y component of a Vector3 that represents a scale")]
	[Keywords(new string[] { "Position", "Vector3", "Up", "Down" })]
	public class GetDecimalTransformsScaleY : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetScale m_Scale = GetScaleSelf.Create;

		public override string String => $"{m_Scale}.Y";

		public override double Get(Args args)
		{
			return m_Scale.Get(args).y;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Scale.Get(gameObject).y;
		}
	}
}
