using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Exists")]
	[Category("Game Objects/Exists")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Blue)]
	[Description("Returns true if the game object exists")]
	[Keywords(new string[] { "Game Object", "Asset" })]
	public class GetBoolGameObjectExists : PropertyTypeGetBool
	{
		[SerializeField]
		protected PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		public override string String => $"{m_GameObject} Exists";

		public override bool Get(Args args)
		{
			return m_GameObject.Get(args) != null;
		}

		public GetBoolGameObjectExists()
		{
		}

		public GetBoolGameObjectExists(GameObject gameObject)
			: this()
		{
			m_GameObject = GetGameObjectInstance.Create(gameObject);
		}

		public static PropertyGetBool Create(GameObject gameObject)
		{
			return new PropertyGetBool(new GetBoolGameObjectExists(gameObject));
		}
	}
}
