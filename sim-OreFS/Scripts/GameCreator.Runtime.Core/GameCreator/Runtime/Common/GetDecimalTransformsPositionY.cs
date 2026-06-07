using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Position Y")]
	[Category("Transforms/Position Y")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("The Y component of a Vector3 that represents a position in space")]
	[Keywords(new string[] { "Position", "Vector3", "Up", "Down" })]
	public class GetDecimalTransformsPositionY : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetPosition m_Position = GetPositionCharacter.Create;

		public override string String => $"{m_Position}.Y";

		public override double Get(Args args)
		{
			return m_Position.Get(args).y;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Position.Get(gameObject).y;
		}
	}
}
