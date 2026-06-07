using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Local to World Left")]
	[Category("Transforms/Local to World Left")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Description("The Transform's left vector in world space")]
	[Keywords(new string[] { "Game Object" })]
	public class GetDirectionLocalLeft : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionLocalLeft());

		public override string String => $"{m_Transform} Left";

		public GetDirectionLocalLeft()
		{
		}

		public GetDirectionLocalLeft(Transform transform)
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
			return -gameObject.transform.right;
		}
	}
}
