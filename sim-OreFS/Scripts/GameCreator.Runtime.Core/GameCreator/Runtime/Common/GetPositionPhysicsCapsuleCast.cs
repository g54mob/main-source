using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Capsule Cast Position")]
	[Category("Physics/Capsule Cast Position")]
	[Image(typeof(IconCapsuleOutline), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	[Description("Returns the center of a vertical capsule casted from its center towards a direction")]
	public class GetPositionPhysicsCapsuleCast : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetPosition m_Center = GetPositionCharactersPlayer.Create;

		[SerializeField]
		private PropertyGetDecimal m_Height = GetDecimalCharacterHeight.Create;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalCharacterRadius.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionConstantDown.Create;

		[SerializeField]
		private PropertyGetDecimal m_MaxDistance = GetDecimalDecimal.Create(10f);

		[SerializeField]
		private LayerMask m_LayerMask = -5;

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionPhysicsCapsuleCast());

		public override string String => $"{m_Center} Cast Sphere";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Center.Get(args);
			float val = (float)m_Height.Get(args);
			float num = (float)m_Radius.Get(args);
			val = Math.Max(val, num * 2f);
			Vector3 point = vector - Vector3.up * (val / 2f - num);
			Vector3 point2 = vector + Vector3.up * (val / 2f - num);
			Vector3 vector2 = m_Direction.Get(args);
			if (vector2 == Vector3.zero)
			{
				return default(Vector3);
			}
			float maxDistance = (float)m_MaxDistance.Get(args);
			if (!Physics.CapsuleCast(point, point2, num, vector2.normalized, out var hitInfo, maxDistance, m_LayerMask, QueryTriggerInteraction.Ignore))
			{
				return vector;
			}
			return vector + vector2.normalized * hitInfo.distance;
		}
	}
}
