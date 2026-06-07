using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Inverse Transform Direction")]
	[Category("Transforms/Inverse Transform Direction")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Description("Transforms the world space direction to local space and returns the value")]
	public class GetDirectionTransformInverseDirection : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionVector.Create(Vector3.forward);

		[SerializeField]
		protected PropertyGetGameObject m_To = GetGameObjectPlayer.Create();

		public override string String => $"{m_To} {m_Direction}";

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_To.Get(args);
			Vector3 vector = m_Direction.Get(args);
			if (!(gameObject != null))
			{
				return vector;
			}
			return gameObject.transform.InverseTransformDirection(vector);
		}

		public static PropertyGetDirection Create(PropertyGetDirection direction, PropertyGetGameObject to)
		{
			return new PropertyGetDirection(new GetDirectionTransformInverseDirection
			{
				m_Direction = direction,
				m_To = to
			});
		}

		public static PropertyGetDirection Create()
		{
			return new PropertyGetDirection(new GetDirectionTransformInverseDirection());
		}
	}
}
