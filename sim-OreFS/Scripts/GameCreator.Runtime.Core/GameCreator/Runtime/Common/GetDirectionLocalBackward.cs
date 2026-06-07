using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Local to World Backward")]
	[Category("Transforms/Local to World Backward")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowDown))]
	[Description("The Transform's backward vector in world space")]
	[Keywords(new string[] { "Game Object" })]
	public class GetDirectionLocalBackward : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionLocalBackward());

		public override string String => $"{m_Transform} Backward";

		public GetDirectionLocalBackward()
		{
		}

		public GetDirectionLocalBackward(Transform transform)
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
			return -gameObject.transform.forward;
		}
	}
}
