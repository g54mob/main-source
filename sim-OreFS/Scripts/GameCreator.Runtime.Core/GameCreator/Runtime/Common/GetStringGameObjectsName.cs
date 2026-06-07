using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Name")]
	[Category("Game Objects/Game Object Name")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Description("Returns the name of the game object")]
	public class GetStringGameObjectsName : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		public static PropertyGetString Create => new PropertyGetString(new GetStringGameObjectsName());

		public override string String => $"{m_GameObject}'s Name";

		public override string EditorValue
		{
			get
			{
				if (!(m_GameObject.EditorValue != null))
				{
					return null;
				}
				return m_GameObject.EditorValue.name;
			}
		}

		public override string Get(Args args)
		{
			return GetName(args);
		}

		private string GetName(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (!(gameObject != null))
			{
				return string.Empty;
			}
			return gameObject.name;
		}
	}
}
