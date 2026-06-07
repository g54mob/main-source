using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TriLib
{
	public class JSHelper : MonoBehaviour
	{
		private static JSHelper _instance;

		public BrowserFilesLoadedEvent OnBrowserFilesLoaded;

		public static JSHelper Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameObject().AddComponent<JSHelper>();
				}
				return _instance;
			}
		}

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
			if (_instance != null && _instance != this)
			{
				Debug.LogError("Only one TriLibJSHelper instance allowed. Destroying new instance.");
				Object.Destroy(base.gameObject);
			}
			else
			{
				base.name = "TriLibJSHelper";
				_instance = this;
			}
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				_instance = null;
			}
		}

		private void OnPaste(string value)
		{
			GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
			if (!(currentSelectedGameObject == null))
			{
				InputField componentInParent = currentSelectedGameObject.GetComponentInParent<InputField>();
				if (!(componentInParent == null))
				{
					componentInParent.text = $"{componentInParent.text.Substring(0, componentInParent.selectionAnchorPosition)}{value}{componentInParent.text.Substring(componentInParent.selectionFocusPosition)}";
				}
			}
		}

		private void FilesLoaded(int filesCount)
		{
			if (OnBrowserFilesLoaded != null)
			{
				OnBrowserFilesLoaded.Invoke(filesCount);
			}
		}
	}
}
