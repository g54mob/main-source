using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Position")]
	[Category("Game Objects/Game Object Position")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Description("Returns the position of the Game Object")]
	public class GetPositionGameObject : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionGameObject());

		public override string String => $"{m_GameObject}";

		public GetPositionGameObject()
		{
		}

		public GetPositionGameObject(GameObject gameObject)
		{
			m_GameObject = GetGameObjectInstance.Create(gameObject);
		}

		public GetPositionGameObject(PropertyGetGameObject gameObject)
		{
			m_GameObject = gameObject;
		}

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (!(gameObject != null))
			{
				return default(Vector3);
			}
			return gameObject.transform.position;
		}
	}
}
