using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SkywardRay.FileBrowser
{
	public class SfbInternal : MonoBehaviour
	{
		public SfbSettings settings;

		private SfbFileSystemEntry currentDirectory;

		private Action<string[]> outputMethod;

		private Action callbackCloseWindow;

		private SfbHistory history;

		private SfbFileSystem fileSystem;

		private List<KeyCode> heldKeys;

		private string[] extensions;

		private string selectedExtension;

		private GameObject loadingAnimation;

		private SfbSavedLocations savedLocations;

		private SfbMode mode;

		private List<SfbPromt> openPromts;

		private bool independantCanvas;

		private SfbWindow window;

		private Canvas canvas;

		private GameObject tooltip;

		private bool prefabsValid;

		private bool repopulatingFileBrowser;

		private bool fileBrowserKeepScroll;

		private bool locationBrowserKeepScroll;

		private SfbIElement focusedElement;

		public GameObject prefabCanvas;

		public GameObject prefabWindow;

		public GameObject prefabPromtDelete;

		public GameObject prefabPromtNewFolder;

		public GameObject prefabPromtOverwrite;

		public GameObject prefabPromtWarning;

		public GameObject prefabLoadingAnimation;

		public GameObject prefabTooltip;

		public bool IsWindowOpen => false;

		public SfbMode Mode => default(SfbMode);

		public SfbFileSystemEntry CurrentDirectory => null;

		public void Start()
		{
		}

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

		private bool InitializeBrowser(string path, Action<string[]> outputMethod, Action callbackCloseWindow, string[] extensions = null)
		{
			return false;
		}

		public void HideWindow()
		{
		}

		public void ShowWindow()
		{
		}

		public void FakeFileSystem(SfbFileSystem fileSystem)
		{
		}

		public SfbFileSystem GetFileSystem()
		{
			return null;
		}

		public void SetParentCanvas(Canvas canvas)
		{
		}

		public List<KeyCode> GetHeldKeys()
		{
			return null;
		}

		private void Update()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void ProcessKeyPresses()
		{
		}

		private static IEnumerable<KeyCode> GetDownKeys()
		{
			return null;
		}

		private void UpdateHeldKeys()
		{
		}

		private bool OpenWindow()
		{
			return false;
		}

		public void CloseWindow()
		{
		}

		private void InternalChangeDirectory(SfbFileSystemEntry entry)
		{
		}

		public void ChangeDirectory(SfbFileSystemEntry entry)
		{
		}

		public bool DirectoryExistsInCurrentDirectory(string input)
		{
			return false;
		}

		public bool HasValidExtension(SfbFileSystemEntry fileSystemEntry)
		{
			return false;
		}

		public bool IsValidExtension(string input)
		{
			return false;
		}

		private IEnumerator RepopulateFileBrowserPanel()
		{
			return null;
		}

		private void RepopulateLocationBrowserPanel()
		{
		}

		private void SetMode(SfbMode mode)
		{
		}

		public void ListenerDropMenu(SfbDropMenuType type, string input)
		{
		}

		private void SetSelectedExtension()
		{
		}

		private void SetSelectedExtension(string input)
		{
		}

		public void PromtWarning(string message)
		{
		}

		public bool PromtSubmitInputField(SfbInputField inputField)
		{
			return false;
		}

		public void SetElementFocus(SfbIElement element)
		{
		}

		private void SendToFocusedElement(string message)
		{
		}

		public void SaveSavedLocations()
		{
		}

		public void LoadSavedLocations()
		{
		}

		public List<SfbEntryWrapper> GetSelectedEntries()
		{
			return null;
		}

		public void SelectedEntry(SfbFileSystemEntry entry)
		{
		}

		public void SelectionEvent()
		{
		}

		public void DeselectAllEntries()
		{
		}

		public void ListenerDisabledWindowPanel()
		{
		}

		public void ClosingOpenPromt(SfbPromt promt)
		{
		}

		public void CloseAllOpenPromts()
		{
		}

		public void AddOpenPromt(SfbPromt promt)
		{
		}

		public string GetFullFileNameInput()
		{
			return null;
		}

		public string GetFileNameInput()
		{
			return null;
		}

		public void SetFileNameInput(string val)
		{
		}

		public void ShowTooltip(SfbFileSystemEntry entry, PointerEventData eventData)
		{
		}

		public void HideTooltip()
		{
		}

		private bool CheckPrefabs()
		{
			return false;
		}

		public void SetButtonListeners(Button button, SfbButtonAction action)
		{
		}

		private void ListenerClick(SfbButtonAction action)
		{
		}

		private void ListenerHistoryBack()
		{
		}

		private void ListenerHistoryForward()
		{
		}

		private void ListenerOpenParentDirectory()
		{
		}

		private void ListenerDesktopButton()
		{
		}

		private void ListenerHomeButton()
		{
		}

		private void ListenerReloadBrowsers()
		{
		}

		private void ListenerAddToFavorites()
		{
		}

		private void ListenerNewFolder()
		{
		}

		public void ListenerNewFolderConfirm(string input)
		{
		}

		public void ListenerSubmitOpenSelection()
		{
		}

		public void ListenerSubmitSaveFile()
		{
		}

		public void ListenerSubmitSaveFileConfirm()
		{
		}

		private void ListenerOpenExtensionsDropMenu()
		{
		}

		private void ListenerDeleteSelection()
		{
		}

		public void ListenerDeleteSelectionConfirm()
		{
		}

		public void SubmitPathInputField(string input)
		{
		}

		public bool SubmitNewFolderInputField(string input)
		{
			return false;
		}

		public void SubmitFileNameInputField(string input)
		{
		}
	}
}
