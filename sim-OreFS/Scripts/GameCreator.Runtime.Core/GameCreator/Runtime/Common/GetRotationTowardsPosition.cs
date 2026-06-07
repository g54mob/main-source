using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Towards Position")]
	[Category("Math/Towards Position")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("Rotation from a position towards another position in space")]
	public class GetRotationTowardsPosition : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetPosition m_From = GetPositionSelf.Create();

		[SerializeField]
		protected PropertyGetPosition m_Towards = GetPositionTarget.Create();

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationTowardsPosition());

		public override string String => $"Towards {m_Towards}";

		public override Quaternion Get(Args args)
		{
			Vector3 vector = m_From.Get(args);
			Vector3 vector2 = m_Towards.Get(args) - vector;
			if (Vector3.Scale(vector2, Vector3Plane.NormalUp) == Vector3.zero)
			{
				return Quaternion.identity;
			}
			if (!(vector2 != Vector3.zero))
			{
				return Quaternion.identity;
			}
			return Quaternion.LookRotation(vector2);
		}
	}
}
