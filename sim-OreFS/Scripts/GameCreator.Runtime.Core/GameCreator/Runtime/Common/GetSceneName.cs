using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scene Name")]
	[Category("Scene Name")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow)]
	[Description("The Scene reference by its name or path")]
	public class GetSceneName : PropertyTypeGetScene
	{
		[SerializeField]
		private PropertyGetString m_SceneName = GetStringString.Create;

		public static PropertyGetScene Create => new PropertyGetScene(new GetSceneName());

		public override string String => $"{m_SceneName}";

		public override int Get(Args args)
		{
			return SceneReference.GetSceneIndex(m_SceneName.Get(args));
		}
	}
}
