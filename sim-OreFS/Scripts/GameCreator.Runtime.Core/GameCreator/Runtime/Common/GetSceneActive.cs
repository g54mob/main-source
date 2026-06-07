using System;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Active Scene")]
	[Category("Active Scene")]
	[Image(typeof(IconUnity), ColorTheme.Type.TextNormal)]
	[Description("The active Scene reference")]
	public class GetSceneActive : PropertyTypeGetScene
	{
		public static PropertyGetScene Create => new PropertyGetScene(new GetSceneActive());

		public override string String => "Active Scene";

		public override int Get(Args args)
		{
			return SceneManager.GetActiveScene().buildIndex;
		}
	}
}
