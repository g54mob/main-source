using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("Game Objects/None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null game object reference")]
	public class GetGameObjectNone : PropertyTypeGetGameObject
	{
		public override string String => "None";

		public override GameObject Get(Args args)
		{
			return null;
		}

		public override GameObject Get(GameObject gameObject)
		{
			return null;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectNone());
		}
	}
}
