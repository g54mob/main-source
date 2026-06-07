using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class SceneReference : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string m_SceneName;

		[SerializeField]
		private int m_SceneIndex;

		public string Name => m_SceneName;

		public int Index => m_SceneIndex;

		public static implicit operator string(SceneReference sceneReference)
		{
			return sceneReference.Name;
		}

		public override string ToString()
		{
			if (!string.IsNullOrEmpty(Name))
			{
				return Name;
			}
			return "(none)";
		}

		public static int GetSceneIndex(string target)
		{
			for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
			{
				string scenePathByBuildIndex = SceneUtility.GetScenePathByBuildIndex(i);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(scenePathByBuildIndex);
				if (target == scenePathByBuildIndex || fileNameWithoutExtension == target)
				{
					return i;
				}
			}
			return -1;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}
	}
}
