using UnityEngine;

namespace TriLib
{
	public class JSHelper : MonoBehaviour
	{
		private static JSHelper _instance;

		public BrowserFilesLoadedEvent OnBrowserFilesLoaded;

		public static JSHelper Instance => null;

		public string GetBrowserFileName(int index)
		{
			return null;
		}

		public byte[] GetBrowserFileData(int index)
		{
			return null;
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnPaste(string value)
		{
		}

		private void FilesLoaded(int filesCount)
		{
		}
	}
}
