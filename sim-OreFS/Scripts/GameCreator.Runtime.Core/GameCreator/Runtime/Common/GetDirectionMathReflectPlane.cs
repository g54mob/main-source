using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Reflect from Plane")]
	[Category("Math/Reflect from Plane")]
	[Image(typeof(IconReflection), ColorTheme.Type.Green)]
	[Description("Reflects a direction going straight into the normal of a Plane")]
	public class GetDirectionMathReflectPlane : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDirection m_PlaneNormal = new PropertyGetDirection();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathReflectPlane());

		public override string String => $"({m_Direction} reflect {m_PlaneNormal})";

		public override Vector3 Get(Args args)
		{
			return Vector3.Reflect(m_Direction.Get(args), m_PlaneNormal.Get(args));
		}
	}
}
