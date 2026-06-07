using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Subtract Positions")]
	[Category("Math/Subtract Positions")]
	[Image(typeof(IconMinusCircle), ColorTheme.Type.Green)]
	[Description("Subtracts two positions to create a direction")]
	public class GetDirectionMathSubtractPositions : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_From = GetDirectionSelf.Create;

		[SerializeField]
		private PropertyGetDirection m_To = GetDirectionTarget.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathSubtractPositions());

		public override string String => $"From {m_From} to {m_To})";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_From.Get(args);
			return m_To.Get(args) - vector;
		}
	}
}
