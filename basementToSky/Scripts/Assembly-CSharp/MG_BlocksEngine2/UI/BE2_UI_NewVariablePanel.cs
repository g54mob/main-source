using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_NewVariablePanel : MonoBehaviour
	{
		private Button _buttonCreate;

		private BE2_InputField _inputVarName;

		public Transform variablePanelTemplate;

		private void Awake()
		{
			_buttonCreate = base.transform.GetChild(2).GetComponent<Button>();
			_inputVarName = BE2_InputField.GetBE2Component(base.transform.GetChild(1));
		}

		private void Start()
		{
			_buttonCreate.onClick.AddListener(OnButtonCreateVariable);
		}

		private void OnButtonCreateVariable()
		{
			string text = _inputVarName.text;
			if (text != "")
			{
				CreateVariable(text);
			}
		}

		public void CreateVariable(string varName)
		{
			if (!BE2_VariablesManager.instance.ContainsVariable(varName))
			{
				bool activeSelf = base.transform.parent.gameObject.activeSelf;
				base.transform.parent.gameObject.SetActive(value: true);
				Transform transform = Object.Instantiate(variablePanelTemplate, Vector3.zero, Quaternion.identity, base.transform.parent);
				transform.SetSiblingIndex(base.transform.GetSiblingIndex() + 1);
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
				transform.localEulerAngles = Vector3.zero;
				transform.GetChild(0).GetComponent<I_BE2_Block>();
				BE2_Text.GetBE2Text(transform.GetComponentInChildren<BE2_UI_SelectionBlock>().transform.GetChild(0).GetChild(0).GetChild(0)).text = varName;
				BE2_VariablesManager.instance.AddOrUpdateVariable(varName, "0");
				transform.GetComponent<BE2_UI_VariableViewer>().RefreshViewer();
				BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
				base.transform.parent.gameObject.SetActive(activeSelf);
			}
		}
	}
}
