using MG_BlocksEngine2.Environment;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_ListItem : MonoBehaviour
	{
		private BE2_UI_VariableListViewer _variableListViewer;

		public TMP_InputField inputField;

		private Button _removeItemButton;

		private void Awake()
		{
			_variableListViewer = GetComponentInParent<BE2_UI_VariableListViewer>();
			inputField = base.transform.GetChild(0).GetComponent<TMP_InputField>();
			_removeItemButton = base.transform.GetChild(1).GetComponent<Button>();
		}

		private void OnEnable()
		{
			inputField.onEndEdit.AddListener(delegate
			{
				_variableListViewer.UpdateListValues();
			});
			_removeItemButton.onClick.AddListener(RemoveItem);
		}

		private void OnDisable()
		{
			inputField.onEndEdit.RemoveAllListeners();
			_removeItemButton.onClick.RemoveAllListeners();
		}

		public void RemoveItem()
		{
			BE2_VariablesListManager.instance.RemoveListItem(_variableListViewer.listName, base.transform.GetSiblingIndex());
			base.gameObject.SetActive(value: false);
			BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
			Object.Destroy(base.gameObject);
		}
	}
}
