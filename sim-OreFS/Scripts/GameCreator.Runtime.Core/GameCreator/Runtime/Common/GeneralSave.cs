using System;
using System.IO;
using GameCreator.Runtime.Common.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class GeneralSave
	{
		[SerializeReference]
		private TDataEncryption m_Encryption = new EncryptionNone();

		[SerializeReference]
		private TDataStorage m_Storage = new StoragePlayerPrefs();

		[SerializeField]
		private LoadSceneMode m_Load;

		[SerializeField]
		private PropertyGetScene m_Scene = GetSceneActive.Create;

		public IDataEncryption Encryption => m_Encryption;

		public IDataStorage Storage => m_Storage;

		public LoadSceneMode Load => m_Load;

		public string GetSceneName(Args args)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(m_Scene.Get(args)));
			if (fileNameWithoutExtension == string.Empty)
			{
				Debug.LogError("No Load Scene was specified");
			}
			return fileNameWithoutExtension;
		}
	}
}
