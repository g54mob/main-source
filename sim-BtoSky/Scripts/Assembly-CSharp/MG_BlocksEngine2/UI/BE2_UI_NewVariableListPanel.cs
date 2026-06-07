using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_NewVariableListPanel : MonoBehaviour
	{
		private Button _buttonCreate;

		private BE2_InputField _inputListName;

		public Transform variablePanelTemplate;

		private void Awake()
		{
			_buttonCreate = base.transform.GetChild(2).GetComponent<Button>();
			_inputListName = BE2_InputField.GetBE2Component(base.transform.GetChild(1));
		}

		private void Start()
		{
			_buttonCreate.onClick.AddListener(OnButtonCreateList);
		}

		private void OnButtonCreateList()
		{
			string text = _inputListName.text;
			if (text != "")
			{
				CreateList(text);
			}
		}

		public void CreateList(string listName)
		{
			if (!BE2_VariablesListManager.instance.ContainsList(listName))
			{
				bool activeSelf = base.transform.parent.gameObject.activeSelf;
				base.transform.parent.gameObject.SetActive(value: true);
				Transform transform = Object.Instantiate(variablePanelTemplate, Vector3.zero, Quaternion.identity, base.transform.parent);
				transform.SetSiblingIndex(base.transform.GetSiblingIndex() + 1);
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
				transform.localEulerAngles = Vector3.zero;
				transform.GetChild(0).GetComponent<I_BE2_Block>();
				BE2_Text.GetBE2Text(transform.GetComponentInChildren<BE2_UI_SelectionBlock>().transform.GetChild(0).GetChild(0).GetChild(0)).text = listName;
				transform.GetComponent<BE2_UI_VariableListViewer>().RefreshViewer();
				BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
				base.transform.parent.gameObject.SetActive(activeSelf);
			}
		}
	}
}
