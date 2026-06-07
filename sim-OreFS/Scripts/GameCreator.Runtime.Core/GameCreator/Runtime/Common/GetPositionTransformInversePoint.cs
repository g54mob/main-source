using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Inverse Transform Point")]
	[Category("Transforms/Inverse Transform Point")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Description("Transforms the world space point to local space and returns the value")]
	public class GetPositionTransformInversePoint : PropertyTypeGetPosition
	{
		[SerializeField]
		protected PropertyGetPosition m_Point = GetPositionVector3.Create();

		[SerializeField]
		protected PropertyGetGameObject m_To = GetGameObjectPlayer.Create();

		public override string String => $"{m_To} {m_Point}";

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_To.Get(args);
			Vector3 vector = m_Point.Get(args);
			if (!(gameObject != null))
			{
				return vector;
			}
			return gameObject.transform.InverseTransformPoint(vector);
		}

		public GetPositionTransformInversePoint()
		{
		}

		public GetPositionTransformInversePoint(Vector3 point)
		{
			m_Point = GetPositionVector3.Create(point);
		}

		public static PropertyGetPosition Create(Vector3 point)
		{
			return new PropertyGetPosition(new GetPositionTransformInversePoint(point));
		}
	}
}
