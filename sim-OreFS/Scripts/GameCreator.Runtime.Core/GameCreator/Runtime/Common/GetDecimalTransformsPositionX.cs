using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Position X")]
	[Category("Transforms/Position X")]
	[Image(typeof(IconVector3), ColorTheme.Type.Red)]
	[Description("The X component of a Vector3 that represents a position in space")]
	[Keywords(new string[] { "Position", "Vector3", "Right", "Left" })]
	public class GetDecimalTransformsPositionX : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetPosition m_Position = GetPositionCharacter.Create;

		public override string String => $"{m_Position}.X";

		public override double Get(Args args)
		{
			return m_Position.Get(args).x;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Position.Get(gameObject).x;
		}
	}
}
