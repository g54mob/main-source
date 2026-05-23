using System.Collections;
using System.Collections.Generic;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_VariableListViewer : MonoBehaviour
	{
		public string listName;

		private Transform _panelListOp;

		private Transform _panelList;

		private Button _removeListButton;

		private Toggle _showListToggle;

		private Button _createItemButton;

		public Transform panelListItem;

		private void Awake()
		{
			_panelListOp = base.transform.GetChild(0);
			_panelList = base.transform.GetChild(1);
			_removeListButton = _panelListOp.GetChild(0).GetComponent<Button>();
			_showListToggle = _panelListOp.GetChild(2).GetComponent<Toggle>();
			_createItemButton = _panelList.GetChild(_panelList.childCount - 1).GetComponent<Button>();
			listName = GetVariableName();
		}

		private void OnEnable()
		{
			_removeListButton.onClick.AddListener(RemoveList);
			_createItemButton.onClick.AddListener(delegate
			{
				AddListItem("", select: true);
			});
			_showListToggle.onValueChanged.AddListener(delegate
			{
				_panelList.gameObject.SetActive(_showListToggle.isOn);
				BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
			});
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAnyVariableValueChanged, UpdateViewerValues);
			UpdateViewerValues();
		}

		private void OnDisable()
		{
			_removeListButton.onClick.RemoveAllListeners();
			_createItemButton.onClick.RemoveAllListeners();
			_showListToggle.onValueChanged.RemoveAllListeners();
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAnyVariableValueChanged, UpdateViewerValues);
		}

		private void Start()
		{
			UpdateViewerValues();
			UpdateListValues();
		}

		public void RefreshViewer()
		{
			listName = GetVariableName();
			UpdateViewerValues();
			UpdateListValues();
		}

		private void UpdateViewerValues()
		{
			StartCoroutine(C_UpdateViewerValues());
		}

		private IEnumerator C_UpdateViewerValues()
		{
			yield return new WaitForEndOfFrame();
			List<string> listStringValues = BE2_VariablesListManager.instance.GetListStringValues(listName);
			for (int i = 0; i < 10000; i++)
			{
				BE2_UI_ListItem component = _panelList.GetChild(i).GetComponent<BE2_UI_ListItem>();
				if (listStringValues.Count > i && (bool)component)
				{
					component.inputField.text = listStringValues[i];
					continue;
				}
				if (listStringValues.Count > i && !component)
				{
					AddListItem(listStringValues[i]);
					continue;
				}
				if (listStringValues.Count <= i && (bool)component)
				{
					component.RemoveItem();
					continue;
				}
				break;
			}
		}

		public void UpdateListValues()
		{
			List<string> list = new List<string>();
			foreach (Transform panel in _panelList)
			{
				BE2_UI_ListItem component = panel.GetComponent<BE2_UI_ListItem>();
				if ((bool)component)
				{
					list.Add(component.inputField.text);
				}
			}
			BE2_VariablesListManager.instance.AddOrUpdateList(listName, list);
		}

		private string GetVariableName()
		{
			return BE2_Text.GetBE2Text(base.transform.GetComponentInChildren<BE2_UI_SelectionBlock>().transform.GetChild(0).GetChild(0).GetChild(0)).text;
		}

		public void RemoveList()
		{
			BE2_VariablesListManager.instance.RemoveList(listName);
			base.gameObject.SetActive(value: false);
			BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
			Object.Destroy(base.gameObject);
		}

		public void AddListItem(string value, bool select = false)
		{
			Transform obj = Object.Instantiate(panelListItem, _panelList);
			obj.localScale = Vector3.one;
			obj.SetSiblingIndex(_panelList.childCount - 2);
			BE2_UI_ListItem component = obj.GetComponent<BE2_UI_ListItem>();
			component.inputField.text = value;
			if (select)
			{
				component.inputField.Select();
			}
			BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
		}
	}
}
