using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Transform Point")]
	[Category("Transforms/Transform Point")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Description("Transforms the local space point to world space and returns the value")]
	public class GetPositionTransformPoint : PropertyTypeGetPosition
	{
		[SerializeField]
		protected PropertyGetGameObject m_From = GetGameObjectPlayer.Create();

		[SerializeField]
		protected PropertyGetPosition m_Point = GetPositionVector3.Create();

		public override string String => $"{m_From} {m_Point}";

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_From.Get(args);
			Vector3 vector = m_Point.Get(args);
			if (!(gameObject != null))
			{
				return vector;
			}
			return gameObject.transform.TransformPoint(vector);
		}

		public GetPositionTransformPoint()
		{
		}

		public GetPositionTransformPoint(Vector3 point)
		{
			m_Point = GetPositionVector3.Create(point);
		}

		public static PropertyGetPosition Create(Vector3 point)
		{
			return new PropertyGetPosition(new GetPositionTransformPoint(point));
		}
	}
}
