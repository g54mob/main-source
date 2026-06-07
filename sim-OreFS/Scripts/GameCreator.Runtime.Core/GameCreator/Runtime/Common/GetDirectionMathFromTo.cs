using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("From Positions")]
	[Category("Math/From Positions")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("Creates a direction from a point towards another")]
	public class GetDirectionMathFromTo : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetPosition m_From = GetPositionSelf.Create();

		[SerializeField]
		private PropertyGetPosition m_To = GetPositionTarget.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathFromTo());

		public override string String => $"({m_From} -> {m_To})";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_From.Get(args);
			return m_To.Get(args) - vector;
		}
	}
}
