using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Direction Z")]
	[Category("Transforms/Direction Z")]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue)]
	[Description("The Z component of a Vector3 that represents a direction")]
	[Keywords(new string[] { "Position", "Vector3", "Forward", "Backward" })]
	public class GetDecimalTransformsDirectionZ : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionSelf.Create;

		public override string String => $"{m_Direction}.Z";

		public override double Get(Args args)
		{
			return m_Direction.Get(args).z;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Direction.Get(gameObject).z;
		}
	}
}
