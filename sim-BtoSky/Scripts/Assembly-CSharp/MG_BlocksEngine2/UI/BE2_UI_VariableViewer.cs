using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_VariableViewer : MonoBehaviour
	{
		private string _variable;

		private BE2_InputField _inputField;

		private Button _removeButton;

		private void Awake()
		{
			_variable = GetVariableName();
			foreach (Transform item in base.transform)
			{
				_inputField = BE2_InputField.GetBE2Component(item);
				if (!_removeButton)
				{
					_removeButton = item.GetComponent<Button>();
				}
			}
			_removeButton.onClick.AddListener(RemoveVariable);
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAnyVariableValueChanged, UpdateViewerValue);
			_inputField.onEndEdit.AddListener(delegate
			{
				UpdateVariableValue();
			});
		}

		private void OnDisable()
		{
			_inputField.onEndEdit.RemoveAllListeners();
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAnyVariableValueChanged, UpdateViewerValue);
		}

		private void Start()
		{
			UpdateViewerValue();
			UpdateVariableValue();
		}

		public void RefreshViewer()
		{
			_variable = GetVariableName();
			UpdateViewerValue();
			UpdateVariableValue();
		}

		private void UpdateViewerValue()
		{
			_inputField.text = BE2_VariablesManager.instance.GetVariableStringValue(_variable);
		}

		private void UpdateVariableValue()
		{
			BE2_VariablesManager.instance.AddOrUpdateVariable(_variable, _inputField.text);
		}

		private string GetVariableName()
		{
			return BE2_Text.GetBE2Text(base.transform.GetComponentInChildren<BE2_UI_SelectionBlock>().transform.GetChild(0).GetChild(0).GetChild(0)).text;
		}

		public void RemoveVariable()
		{
			BE2_VariablesManager.instance.RemoveVariable(_variable);
			base.gameObject.SetActive(value: false);
			BE2_UI_BlocksSelectionViewer.Instance.ForceRebuildLayout();
			Object.Destroy(base.gameObject);
		}
	}
}
