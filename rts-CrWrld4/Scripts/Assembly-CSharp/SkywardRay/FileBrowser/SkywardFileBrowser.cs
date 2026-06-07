using System;
using UnityEngine;

namespace SkywardRay.FileBrowser
{
	public class SkywardFileBrowser : MonoBehaviour
	{
		public GameObject prefabCanvas;

		public GameObject prefabWindow;

		public GameObject prefabPromtDelete;

		public GameObject prefabPromtNewFolder;

		public GameObject prefabPromtOverwrite;

		public GameObject prefabPromtWarning;

		public GameObject prefabLoadingAnimation;

		public GameObject prefabTooltip;

		private SfbInternal _mSfbInternal;

		private SfbInternal SfbInternal => null;

		public bool IsWindowOpen => false;

		public SfbMode Mode => default(SfbMode);

		public SfbSettings Settings => null;

		public bool OpenFile(string path, Action<string[]> outputMethod, string[] extensions = null)
		{
			return false;
		}

		public bool OpenFile(string path, Action<string[]> outputMethod, Action callbackCloseWindow, string[] extensions = null)
		{
			return false;
		}

		public bool SaveFile(string path, Action<string[]> outputMethod, string[] extensions = null)
		{
			return false;
		}

		public bool SaveFile(string path, Action<string[]> outputMethod, Action callbackCloseWindow, string[] extensions = null)
		{
			return false;
		}

		public void SetFileNameInput(string fileName)
		{
		}

		public void HideWindow()
		{
		}

		public void CloseWindow()
		{
		}

		public void ShowWindow()
		{
		}

		public void FakeFileSystem(SfbFileSystem fileSystem)
		{
		}

		public void SetParentCanvas(Canvas canvas)
		{
		}

		public string GetCurrentDirectoryPath()
		{
			return null;
		}
	}
}
