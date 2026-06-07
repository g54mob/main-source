using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Load Scene")]
	[Description("Loads a new Scene")]
	[Category("Scenes/Load Scene")]
	[Parameter("Scene", "The scene to be loaded")]
	[Parameter("Mode", "Single mode replaces all other scenes. Additive mode loads the scene on top of the others")]
	[Parameter("Async", "Loads the scene in the background or freeze the game until its done")]
	[Parameter("Scene Entries", "Define the starting location of the player and other characters after loading the scene")]
	[Keywords(new string[] { "Change" })]
	[Image(typeof(IconUnity), ColorTheme.Type.TextNormal)]
	public class InstructionCommonSceneLoad : Instruction
	{
		[SerializeField]
		private PropertyGetScene m_Scene = new PropertyGetScene();

		[SerializeField]
		private UnityEngine.SceneManagement.LoadSceneMode m_Mode;

		[SerializeField]
		private bool m_Async;

		[SerializeField]
		private SceneEntries m_SceneEntries = new SceneEntries();

		private AsyncOperation m_Loader;

		public override string Title => string.Format("Load{0} scene {1}{2}", (m_Mode == UnityEngine.SceneManagement.LoadSceneMode.Additive) ? " additive" : string.Empty, m_Scene, m_Async ? " (async)" : string.Empty);

		protected override async Task Run(Args args)
		{
			int num = m_Scene.Get(args);
			m_SceneEntries.Schedule(num, args);
			if (m_Async)
			{
				m_Loader = SceneManager.LoadSceneAsync(num, m_Mode);
				await Until(() => m_Loader.isDone || ApplicationManager.IsExiting);
			}
			else
			{
				SceneManager.LoadScene(num, m_Mode);
			}
		}
	}
}
