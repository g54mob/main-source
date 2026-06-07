using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Position Z")]
	[Category("Transforms/Position Z")]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue)]
	[Description("The Z component of a Vector3 that represents a position in space")]
	[Keywords(new string[] { "Position", "Vector3", "Forward", "Backward" })]
	public class GetDecimalTransformsPositionZ : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetPosition m_Position = GetPositionCharacter.Create;

		public override string String => $"{m_Position}.Z";

		public override double Get(Args args)
		{
			return m_Position.Get(args).z;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Position.Get(gameObject).z;
		}
	}
}
