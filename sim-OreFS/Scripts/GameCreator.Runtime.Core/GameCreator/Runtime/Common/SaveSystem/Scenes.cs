using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common.SaveSystem
{
	public class Scenes : IGameSave
	{
		[Serializable]
		public class Token
		{
			[SerializeField]
			private string[] m_Names;

			public int Count => m_Names.Length;

			public string[] Names => m_Names;

			private Token()
			{
				int sceneCount = SceneManager.sceneCount;
				m_Names = new string[sceneCount];
				for (int i = 0; i < sceneCount; i++)
				{
					m_Names[i] = SceneManager.GetSceneAt(i).name;
				}
			}

			public static Token Create()
			{
				return new Token();
			}
		}

		public const string ID = "scenes";

		[NonSerialized]
		private float[] m_ScenesProgress = Array.Empty<float>();

		public float Progress
		{
			get
			{
				if (m_ScenesProgress.Length == 0)
				{
					return 1f;
				}
				float num = 0f;
				float[] scenesProgress = m_ScenesProgress;
				foreach (float num2 in scenesProgress)
				{
					num += num2;
				}
				return num / (float)m_ScenesProgress.Length;
			}
		}

		public string SaveID => "scenes";

		public bool IsShared => false;

		public Type SaveType => typeof(Token);

		public LoadMode LoadMode => LoadMode.Greedy;

		public object GetSaveData(bool includeNonSavable)
		{
			return Token.Create();
		}

		public async Task OnLoad(object value)
		{
			if (!(value is Token token))
			{
				throw new Exception("Cannot convert 'token' to 'Scenes.Token'");
			}
			if (token.Count != 0)
			{
				string[] scenes = TRepository<GeneralRepository>.Get.Save.Load switch
				{
					LoadSceneMode.AllSavedScenes => token.Names, 
					LoadSceneMode.MainSavedScene => new string[1] { token.Names[0] }, 
					LoadSceneMode.Scene => new string[1] { TRepository<GeneralRepository>.Get.Save.GetSceneName(Args.EMPTY) }, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
				m_ScenesProgress = new float[scenes.Length];
				await LoadScene(0, scenes, UnityEngine.SceneManagement.LoadSceneMode.Single);
				int i = 1;
				while (i < scenes.Length)
				{
					await LoadScene(i, scenes, UnityEngine.SceneManagement.LoadSceneMode.Additive);
					int num = i + 1;
					i = num;
				}
				await Task.Yield();
			}
		}

		public static async Task LoadScene(int index)
		{
			SceneManager.LoadScene(index);
			await Task.Yield();
		}

		private async Task LoadScene(int index, IReadOnlyList<string> names, UnityEngine.SceneManagement.LoadSceneMode mode)
		{
			AsyncOperation async = SceneManager.LoadSceneAsync(names[index], mode);
			while (!AsyncManager.ExitRequest && !async.isDone)
			{
				m_ScenesProgress[index] = async.progress;
				await Task.Yield();
			}
		}
	}
}
