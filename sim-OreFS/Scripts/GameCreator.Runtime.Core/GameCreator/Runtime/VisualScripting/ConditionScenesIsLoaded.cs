using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Scene Loaded")]
	[Description("Returns true if the scene has been loaded")]
	[Parameter("Scene", "The Unity Scene reference used in the condition")]
	[Category("Scenes/Is Scene Loaded")]
	[Image(typeof(IconUnity), ColorTheme.Type.TextNormal)]
	public class ConditionScenesIsLoaded : Condition
	{
		[SerializeField]
		private PropertyGetScene m_Scene = new PropertyGetScene();

		protected override string Summary => $"is scene {m_Scene} Loaded";

		protected override bool Run(Args args)
		{
			Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(m_Scene.Get(args));
			if (sceneByBuildIndex.IsValid())
			{
				return sceneByBuildIndex.isLoaded;
			}
			return false;
		}
	}
}
