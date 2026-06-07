using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Local to World Direction")]
	[Category("Transforms/Local to World Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("Transforms the direction from Local Space to World Space")]
	[Keywords(new string[] { "Game Object" })]
	public class GetDirectionLocalValue : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionVector.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionLocalValue());

		public override string String => $"{m_Transform} {m_Direction}";

		public override Vector3 Get(Args args)
		{
			Transform transform = m_Transform.Get<Transform>(args);
			Vector3 vector = m_Direction.Get(args);
			if (!(transform != null))
			{
				return vector;
			}
			return transform.TransformDirection(vector);
		}

		public static PropertyGetDirection CreateSelf(Vector3 direction = default(Vector3))
		{
			return new PropertyGetDirection(new GetDirectionLocalValue
			{
				m_Transform = GetGameObjectSelf.Create(),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}

		public static PropertyGetDirection CreateTarget(Vector3 direction = default(Vector3))
		{
			return new PropertyGetDirection(new GetDirectionLocalValue
			{
				m_Transform = GetGameObjectTarget.Create(),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}

		public static PropertyGetDirection CreatePlayer(Vector3 direction = default(Vector3))
		{
			return new PropertyGetDirection(new GetDirectionLocalValue
			{
				m_Transform = GetGameObjectPlayer.Create(),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}

		public static PropertyGetDirection CreateGameObject(GameObject gameObject, Vector3 direction)
		{
			return new PropertyGetDirection(new GetDirectionLocalValue
			{
				m_Transform = GetGameObjectInstance.Create(gameObject),
				m_Direction = GetDirectionVector.Create(direction)
			});
		}
	}
}
