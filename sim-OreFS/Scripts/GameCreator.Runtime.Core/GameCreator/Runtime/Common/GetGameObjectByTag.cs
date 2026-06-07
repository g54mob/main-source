using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Find by Tag")]
	[Category("Game Objects/Find by Tag")]
	[Image(typeof(IconTag), ColorTheme.Type.Yellow)]
	[Description("Searches the scene for a Game Object with a specific tag")]
	public class GetGameObjectByTag : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected PropertyGetString m_Tag = new PropertyGetString("");

		public override string String => m_Tag.ToString();

		public override GameObject EditorValue => GameObject.FindWithTag(m_Tag.ToString());

		public override GameObject Get(Args args)
		{
			return GameObject.FindWithTag(m_Tag.Get(args));
		}
	}
}
