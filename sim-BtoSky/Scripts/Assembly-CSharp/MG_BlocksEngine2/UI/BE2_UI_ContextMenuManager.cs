using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_ContextMenuManager : MonoBehaviour
	{
		private I_BE2_UI_ContextMenu[] _contextMenuArray;

		private I_BE2_UI_ContextMenu currentContextMenu;

		private static BE2_UI_ContextMenuManager _instance;

		public BE2_UI_PanelCancel panelCancel;

		public bool isActive;

		public static BE2_UI_ContextMenuManager instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindObjectOfType<BE2_UI_ContextMenuManager>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		private void Start()
		{
			_contextMenuArray = new I_BE2_UI_ContextMenu[0];
			foreach (Transform item in base.transform)
			{
				I_BE2_UI_ContextMenu component = item.GetComponent<I_BE2_UI_ContextMenu>();
				if (component != null)
				{
					BE2_ArrayUtils.Add(ref _contextMenuArray, component);
				}
			}
			CloseContextMenu();
		}

		public void OpenContextMenu<T>(int menuIndex, T target, params string[] options)
		{
			if (!isActive)
			{
				currentContextMenu = _contextMenuArray[menuIndex];
				currentContextMenu.Open(target, options);
				isActive = true;
				panelCancel.transform.gameObject.SetActive(value: true);
			}
		}

		public void CloseContextMenu()
		{
			if (isActive)
			{
				if (currentContextMenu != null)
				{
					currentContextMenu.Close();
					currentContextMenu = null;
				}
				isActive = false;
				panelCancel.transform.gameObject.SetActive(value: false);
			}
		}
	}
}
