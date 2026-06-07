using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Find by Name")]
	[Category("Game Objects/Find by Name")]
	[Image(typeof(IconSearch), ColorTheme.Type.Yellow)]
	[Description("Searches the scene for a Game Object with a specific name")]
	public class GetGameObjectByName : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected PropertyGetString m_Name = new PropertyGetString("");

		public override string String => m_Name.ToString();

		public override GameObject EditorValue => GameObject.Find(m_Name.ToString());

		public override GameObject Get(Args args)
		{
			return GameObject.Find(m_Name.Get(args));
		}
	}
}
