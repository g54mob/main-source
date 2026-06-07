using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("World to Local Direction")]
	[Category("Transforms/World to Local Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue)]
	[Description("Transforms the direction from World Space to Local Space")]
	[Keywords(new string[] { "Game Object" })]
	public class GetDirectionWorldValue : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionVector.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionWorldValue());

		public override string String => $"{m_Transform} {m_Direction}";

		public override Vector3 Get(Args args)
		{
			Transform transform = m_Transform.Get<Transform>(args);
			Vector3 vector = m_Direction.Get(args);
			if (!(transform != null))
			{
				return vector;
			}
			return transform.InverseTransformDirection(vector);
		}

		public static PropertyGetDirection CreateSelf(Vector3 direction = default(Vector3))
		{
			return new PropertyGetDirection(new GetDirectionWorldValue
			{
				m_Transform = GetGameObjectSelf.Create(),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}

		public static PropertyGetDirection CreateTarget(Vector3 direction = default(Vector3))
		{
			return new PropertyGetDirection(new GetDirectionWorldValue
			{
				m_Transform = GetGameObjectTarget.Create(),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}

		public static PropertyGetDirection CreatePlayer(Vector3 direction = default(Vector3))
		{
			return new PropertyGetDirection(new GetDirectionWorldValue
			{
				m_Transform = GetGameObjectPlayer.Create(),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}

		public static PropertyGetDirection CreateGameObject(GameObject gameObject, Vector3 direction)
		{
			return new PropertyGetDirection(new GetDirectionWorldValue
			{
				m_Transform = GetGameObjectInstance.Create(gameObject),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}
	}
}
