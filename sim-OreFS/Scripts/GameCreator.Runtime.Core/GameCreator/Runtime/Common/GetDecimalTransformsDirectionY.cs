using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Direction Y")]
	[Category("Transforms/Direction Y")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("The Y component of a Vector3 that represents a direction")]
	[Keywords(new string[] { "Position", "Vector3", "Up", "Down" })]
	public class GetDecimalTransformsDirectionY : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionSelf.Create;

		public override string String => $"{m_Direction}.Y";

		public override double Get(Args args)
		{
			return m_Direction.Get(args).y;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Direction.Get(gameObject).y;
		}
	}
}
