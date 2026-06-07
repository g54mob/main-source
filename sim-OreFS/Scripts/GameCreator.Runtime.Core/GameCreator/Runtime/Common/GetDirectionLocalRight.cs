using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Local to World Right")]
	[Category("Transforms/Local to World Right")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Description("The Transform's right vector in world space")]
	[Keywords(new string[] { "Game Object" })]
	public class GetDirectionLocalRight : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionLocalRight());

		public override string String => $"{m_Transform} Right";

		public GetDirectionLocalRight()
		{
		}

		public GetDirectionLocalRight(Transform transform)
		{
			m_Transform = GetGameObjectTransform.Create(transform);
		}

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (!(gameObject != null))
			{
				return default(Vector3);
			}
			return gameObject.transform.right;
		}
	}
}
