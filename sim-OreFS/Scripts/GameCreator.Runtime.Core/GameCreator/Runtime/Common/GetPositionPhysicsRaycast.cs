using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Raycast Position")]
	[Category("Physics/Raycast Position")]
	[Image(typeof(IconLineStartEnd), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	[Description("Returns the position of ray casting from a position towards a direction")]
	public class GetPositionPhysicsRaycast : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionCharactersPlayer.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionConstantDown.Create;

		[SerializeField]
		private PropertyGetDecimal m_MaxDistance = GetDecimalDecimal.Create(10f);

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionPhysicsRaycast());

		public override string String => $"{m_Position} Raycast";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Position.Get(args);
			Vector3 vector2 = m_Direction.Get(args);
			if (vector2 == Vector3.zero)
			{
				return default(Vector3);
			}
			float maxDistance = (float)m_MaxDistance.Get(args);
			if (!Physics.Raycast(vector, vector2.normalized, out var hitInfo, maxDistance, m_LayerMask, QueryTriggerInteraction.Ignore))
			{
				return vector;
			}
			return hitInfo.point;
		}
	}
}
