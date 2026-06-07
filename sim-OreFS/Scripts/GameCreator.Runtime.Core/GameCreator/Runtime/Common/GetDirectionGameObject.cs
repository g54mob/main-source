using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Direction")]
	[Category("Game Objects/Game Object Direction")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Description("The forward direction of the game object in World Space")]
	public class GetDirectionGameObject : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectPlayer.Create();

		public override string String => $"{m_GameObject} Direction";

		public override Vector3 Get(Args args)
		{
			Transform transform = m_GameObject.Get<Transform>(args);
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.forward;
		}

		public static PropertyGetDirection Create()
		{
			return new PropertyGetDirection(new GetDirectionGameObject
			{
				m_GameObject = GetGameObjectPlayer.Create()
			});
		}

		public static PropertyGetDirection Create(GameObject gameObject)
		{
			return new PropertyGetDirection(new GetDirectionGameObject
			{
				m_GameObject = GetGameObjectInstance.Create(gameObject)
			});
		}
	}
}
