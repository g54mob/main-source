using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Local to World Forward")]
	[Category("Transforms/Local to World Forward")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowUp))]
	[Description("The Transform's forward vector in world space")]
	[Keywords(new string[] { "Game Object" })]
	public class GetDirectionLocalForward : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionLocalForward());

		public override string String => $"{m_Transform} Forward";

		public GetDirectionLocalForward()
		{
		}

		public GetDirectionLocalForward(Transform transform)
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
			return gameObject.transform.forward;
		}
	}
}
