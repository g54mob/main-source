using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Transform Direction")]
	[Category("Transforms/Transform Direction")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Description("Transforms the local space direction to world space and returns the value")]
	public class GetDirectionTransformDirection : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_From = GetGameObjectPlayer.Create();

		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionVector.Create();

		public override string String => $"{m_From} {m_Direction}";

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_From.Get(args);
			Vector3 vector = m_Direction.Get(args);
			if (!(gameObject != null))
			{
				return vector;
			}
			return gameObject.transform.TransformDirection(vector);
		}

		public GetDirectionTransformDirection()
		{
		}

		public GetDirectionTransformDirection(Vector3 direction)
		{
			m_Direction = GetDirectionVector.Create(direction);
		}

		public static PropertyGetDirection Create(Vector3 direction)
		{
			return new PropertyGetDirection(new GetDirectionTransformDirection(direction));
		}

		public static PropertyGetDirection Create(PropertyGetGameObject from, PropertyGetDirection direction)
		{
			return new PropertyGetDirection(new GetDirectionTransformDirection
			{
				m_From = from,
				m_Direction = direction
			});
		}
	}
}
