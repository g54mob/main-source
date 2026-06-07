using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Project on Plane")]
	[Category("Math/Project on Plane")]
	[Image(typeof(IconProjection), ColorTheme.Type.Green)]
	[Description("Projects a direction onto the normal of a Plane")]
	public class GetDirectionMathProjectPlane : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDirection m_PlaneNormal = new PropertyGetDirection();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathProjectPlane());

		public override string String => $"({m_Direction} project {m_PlaneNormal})";

		public override Vector3 Get(Args args)
		{
			return Vector3.ProjectOnPlane(m_Direction.Get(args), m_PlaneNormal.Get(args));
		}
	}
}
