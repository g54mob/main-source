using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sphere Cast Position")]
	[Category("Physics/Sphere Cast Position")]
	[Image(typeof(IconSphereOutline), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	[Description("Returns the center of a sphere casted from a position towards a direction")]
	public class GetPositionPhysicsSphereCast : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionCharactersPlayer.Create;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalDecimal.Create(0.5f);

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionConstantDown.Create;

		[SerializeField]
		private PropertyGetDecimal m_MaxDistance = GetDecimalDecimal.Create(10f);

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionPhysicsSphereCast());

		public override string String => $"{m_Position} Cast Sphere";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Position.Get(args);
			Vector3 normalized = m_Direction.Get(args).normalized;
			if (normalized == Vector3.zero)
			{
				return default(Vector3);
			}
			float maxDistance = (float)m_MaxDistance.Get(args);
			float radius = (float)m_Radius.Get(args);
			if (!Physics.SphereCast(vector, radius, normalized, out var hitInfo, maxDistance, m_LayerMask, QueryTriggerInteraction.Ignore))
			{
				return vector;
			}
			return vector + normalized.normalized * hitInfo.distance;
		}
	}
}
