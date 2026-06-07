using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Is Active")]
	[Category("Game Objects/Is Active")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Green)]
	[Description("Returns true if the game object exists and is active")]
	[Keywords(new string[] { "Game Object", "Asset", "Enabled", "Inactive", "Disabled" })]
	public class GetBoolGameObjectActive : PropertyTypeGetBool
	{
		[SerializeField]
		protected PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		public override string String => $"{m_GameObject} is Active";

		public override bool Get(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject != null)
			{
				return gameObject.activeInHierarchy;
			}
			return false;
		}

		public GetBoolGameObjectActive()
		{
		}

		public GetBoolGameObjectActive(GameObject gameObject)
			: this()
		{
			m_GameObject = GetGameObjectInstance.Create(gameObject);
		}

		public static PropertyGetBool Create(GameObject gameObject)
		{
			return new PropertyGetBool(new GetBoolGameObjectActive(gameObject));
		}
	}
}
