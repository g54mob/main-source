using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scene Asset")]
	[Category("Scene Asset")]
	[Image(typeof(IconUnity), ColorTheme.Type.TextNormal)]
	[Description("The Scene reference by referencing the project scene object")]
	public class GetSceneAsset : PropertyTypeGetScene
	{
		[SerializeField]
		protected SceneReference m_Scene = new SceneReference();

		public static PropertyGetScene Create => new PropertyGetScene(new GetSceneAsset());

		public override string String => m_Scene.ToString();

		public override int Get(Args args)
		{
			return m_Scene.Index;
		}

		public override int Get(GameObject gameObject)
		{
			return m_Scene.Index;
		}
	}
}
