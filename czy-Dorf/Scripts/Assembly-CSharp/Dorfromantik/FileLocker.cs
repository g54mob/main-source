using System.IO;
using UnityEngine;

namespace Dorfromantik
{
	public class FileLocker : MonoBehaviour
	{
		[SerializeField]
		private string pathInPersistentData;

		private FileStream openFile;

		private void OpenFile()
		{
			openFile = File.Open(Path.Combine(Application.persistentDataPath, pathInPersistentData), FileMode.Open);
		}

		private void CloseFile()
		{
			if (openFile != null)
			{
				openFile.Close();
				openFile = null;
			}
		}

		private void OnDestroy()
		{
			CloseFile();
		}
	}
}
