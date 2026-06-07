using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Unload Scene")]
	[Description("Unloads an active scene")]
	[Category("Scenes/Unload Scene")]
	[Parameter("Scene", "The scene to be unloaded")]
	[Keywords(new string[] { "Change", "Remove" })]
	[Image(typeof(IconUnity), ColorTheme.Type.TextLight)]
	public class InstructionCommonSceneUnload : Instruction
	{
		[SerializeField]
		private PropertyGetScene m_Scene = new PropertyGetScene();

		private AsyncOperation m_AsyncOperation;

		public override string Title => $"Unload scene {m_Scene}";

		protected override async Task Run(Args args)
		{
			int sceneBuildIndex = m_Scene.Get(args);
			m_AsyncOperation = SceneManager.UnloadSceneAsync(sceneBuildIndex);
			await Until(() => m_AsyncOperation.isDone);
		}
	}
}
