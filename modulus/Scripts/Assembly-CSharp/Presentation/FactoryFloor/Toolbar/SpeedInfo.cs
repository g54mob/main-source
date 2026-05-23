using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.FactoryObjectBehaviours.CustomInputOutputSpeeds;
using Data.Operator;
using Data.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class SpeedInfo : MonoBehaviour
	{
		[Header("Data")]
		[SerializeField]
		private FactoryObjectUIData _uiData;

		[Header("Variables")]
		[SerializeField]
		private IntVariableSO _factoryStepsPerSecond;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[Header("UI Elements")]
		[SerializeField]
		private Transform _inputParent;

		[SerializeField]
		private Transform _outputParent;

		[SerializeField]
		private TextMeshProUGUI _inputTextOriginal;

		[SerializeField]
		private TextMeshProUGUI _outputTextOriginal;

		[SerializeField]
		private TextMeshProUGUI _connectedText;

		[SerializeField]
		private LayoutElement _speedInfoInputContainer;

		[LocaKey]
		[SerializeField]
		private string _frequencyLocaKey;

		[Header("Connection Lines")]
		[SerializeField]
		private Transform _connectionLinesInputParent;

		[SerializeField]
		private Transform _connectionLinesOutputParent;

		[SerializeField]
		private GameObject _connectionLineInputOriginal;

		[SerializeField]
		private GameObject _connectionLineOutputOriginal;

		[SerializeField]
		private CanvasGroup _connectionLinesInputCanvasGroup;

		[SerializeField]
		private CanvasGroup _connectionLinesOutputCanvasGroup;

		[SerializeField]
		private GameObject _connectionLineInput;

		[SerializeField]
		private GameObject _connectionLineOutput;

		private string _frequencyText;

		private List<TextMeshProUGUI> _inputs;

		private List<TextMeshProUGUI> _outputs;

		private List<GameObject> _inputConnectionLines;

		private List<GameObject> _outputConnectionLines;

		private int _configuredOutputCount;

		private int _newFrequency;

		private bool _useNewFrequency;

		private bool _showConnectionLines = true;

		private FactoryObject _factoryObject;

		private void Awake()
		{
			OnLanguageUpdate();
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_inputs = new List<TextMeshProUGUI> { _inputTextOriginal };
			_outputs = new List<TextMeshProUGUI> { _outputTextOriginal };
			_inputConnectionLines = new List<GameObject> { _connectionLineInputOriginal };
			_outputConnectionLines = new List<GameObject> { _connectionLineOutputOriginal };
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void OnLanguageUpdate()
		{
			_frequencyText = LocalizationUtility.GetLocalizedText(_frequencyLocaKey);
		}

		private void SetNoFrequencyText(string locaKey)
		{
			_connectedText.SetText(LocalizationUtility.GetLocalizedText(locaKey));
			_connectedText.gameObject.SetActive(value: true);
			_inputParent.gameObject.SetActive(value: false);
			_outputParent.gameObject.SetActive(value: false);
			_connectionLinesInputParent.gameObject.SetActive(value: false);
			_connectionLinesOutputParent.gameObject.SetActive(value: false);
		}

		private void OnEnable()
		{
			BuildSpeedInfo();
		}

		private void BuildSpeedInfo()
		{
			if (_uiData == null)
			{
				return;
			}
			if (_uiData.OutputDefinedByBeltSpeed && _uiData.InputDefinedByBeltSpeed)
			{
				SetNoFrequencyText("Factory.OutputAndInputSpeedConnected");
				return;
			}
			if (_uiData.OutputDefinedByBeltSpeed)
			{
				SetNoFrequencyText("Factory.OutputSpeedConnected");
				return;
			}
			if (_uiData.InputDefinedByBeltSpeed)
			{
				SetNoFrequencyText("Factory.InputSpeedConnected");
				return;
			}
			_connectedText.gameObject.SetActive(value: false);
			int num = ((_uiData.FactoryObject == null) ? 1 : (_uiData.FactoryObject.InputPositionsData?.Count ?? 0));
			int num2 = ((_uiData.FactoryObject == null) ? 1 : (_uiData.FactoryObject.OutputPositions?.Count ?? 0));
			_connectionLineInput.SetActive(num >= num2);
			_connectionLineOutput.SetActive(num < num2);
			if (_uiData.InputDefinedByConfiguration && _factoryObject?.GetResourceHolderBehaviour() is ICustomInputSpeeds customInputSpeeds && customInputSpeeds.IsConfigSet())
			{
				num = Mathf.Min(customInputSpeeds.GetInputFrequencies().Length, num);
			}
			bool active = _showConnectionLines && (_uiData.IsConnector || (!_uiData.HideInput && !_uiData.HideOutput && num > 0 && num2 > 0));
			_connectionLinesInputParent.gameObject.SetActive(active);
			_connectionLinesOutputParent.gameObject.SetActive(active);
			if (_uiData.HideOutput && _uiData.HideInput)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			base.gameObject.SetActive(value: true);
			SetInfoItems(_inputs, _inputParent, _inputConnectionLines, _connectionLinesInputParent, _connectionLinesInputCanvasGroup, num, SetInputValue, _uiData.HideInput);
			if (_uiData.IsConnector)
			{
				SetInfoItems(_outputs, _outputParent, _outputConnectionLines, _connectionLinesOutputParent, _connectionLinesOutputCanvasGroup, num, SetOutputValue);
			}
			else
			{
				SetInfoItems(_outputs, _outputParent, _outputConnectionLines, _connectionLinesOutputParent, _connectionLinesOutputCanvasGroup, num2, SetOutputValue, _uiData.HideOutput);
			}
		}

		public void SetSpeedsFromUIData(FactoryObjectUIData factoryObjectUIData)
		{
			_useNewFrequency = false;
			_configuredOutputCount = 0;
			_uiData = factoryObjectUIData;
			_factoryObject = null;
			if (base.gameObject.activeInHierarchy)
			{
				BuildSpeedInfo();
			}
		}

		public void SetSpeedsFromNode(FactoryObjectUIData factoryObjectUIData, int newFrequency)
		{
			_useNewFrequency = true;
			_configuredOutputCount = 0;
			_newFrequency = newFrequency;
			_uiData = factoryObjectUIData;
			_factoryObject = null;
			if (base.gameObject.activeInHierarchy)
			{
				BuildSpeedInfo();
			}
		}

		public void SetSpeedsFromConfiguredOperator(FactoryObjectUIData factoryObjectUIData, int configuredOutputCount, int uniqueInputCount, int uniqueOutputCount, FactoryObject factoryObject)
		{
			bool flag = uniqueInputCount > 0 && uniqueOutputCount > 0;
			_speedInfoInputContainer.minWidth = (flag ? ((float)((uniqueInputCount > 2) ? 2 : uniqueInputCount) * 192f + 20f * (float)(uniqueInputCount - 1) + 44f) : 0f);
			_showConnectionLines = !flag;
			_useNewFrequency = false;
			_configuredOutputCount = configuredOutputCount;
			_uiData = factoryObjectUIData;
			_factoryObject = factoryObject;
			if (base.gameObject.activeInHierarchy)
			{
				BuildSpeedInfo();
			}
		}

		private void SetInputValue(TextMeshProUGUI infoObject, int count, int index)
		{
			if (_uiData.InputDefinedByConfiguration)
			{
				if (!(_factoryObject?.GetResourceHolderBehaviour() is ICustomInputSpeeds customInputSpeeds))
				{
					infoObject.SetText(string.Format(_frequencyText, "??", "FrequencyUnitUI"));
					return;
				}
				if (!customInputSpeeds.IsConfigSet())
				{
					infoObject.SetText(string.Format(_frequencyText, "??", "FrequencyUnitUI"));
					return;
				}
				float num = (float)_factoryStepsPerSecond.Value * (float)_globalUpdateMultiplier.Value / (float)customInputSpeeds.GetInputFrequencies()[index];
				infoObject.SetText(string.Format(_frequencyText, num * _uiData.InputMultiplier * 60f, "FrequencyUnitUI"));
			}
			else
			{
				float num2 = (float)_factoryStepsPerSecond.Value * (float)_globalUpdateMultiplier.Value / (float)GetFrequency();
				infoObject.SetText(string.Format(_frequencyText, num2 * _uiData.InputMultiplier * 60f, "FrequencyUnitUI"));
			}
		}

		private int GetFrequency()
		{
			if (_useNewFrequency)
			{
				return _newFrequency;
			}
			if (_uiData.FactoryObjectBehaviour == null)
			{
				Debug.LogError("UIData of " + _uiData.NameLocKey + " doesn't have a FactoryObjectBehaviour attached.");
				return 0;
			}
			return _uiData.FactoryObjectBehaviour.VariableUpdateFrequency.Value;
		}

		private void SetOutputValue(TextMeshProUGUI infoObject, int count, int index)
		{
			if (_uiData.OutputDefinedByConfiguration)
			{
				if (_configuredOutputCount > 0)
				{
					float num = (float)_factoryStepsPerSecond.Value * (float)_globalUpdateMultiplier.Value / (float)GetFrequency();
					infoObject.SetText(string.Format(_frequencyText, num * _uiData.OutputMultiplier * (float)_configuredOutputCount * 60f, "FrequencyUnitUI"));
				}
				else
				{
					infoObject.SetText(string.Format(_frequencyText, "??", "FrequencyUnitUI"));
				}
			}
			else
			{
				float num2 = (float)_factoryStepsPerSecond.Value * (float)_globalUpdateMultiplier.Value / (float)GetFrequency();
				infoObject.SetText(string.Format(_frequencyText, num2 * _uiData.OutputMultiplier * 60f, "FrequencyUnitUI"));
			}
		}

		private void SetInfoItems(List<TextMeshProUGUI> textObjects, Transform parent, List<GameObject> lineObjects, Transform lineParent, CanvasGroup lineCanvasGroup, int inputOutputAmount, Action<TextMeshProUGUI, int, int> SetValueAction, bool hide = false)
		{
			for (int i = 0; i < textObjects.Count; i++)
			{
				textObjects[i].gameObject.SetActive(value: false);
				lineObjects[i].SetActive(value: false);
			}
			for (int j = 0; j < inputOutputAmount; j++)
			{
				TextMeshProUGUI textMeshProUGUI;
				GameObject gameObject;
				if (j >= textObjects.Count)
				{
					textMeshProUGUI = UnityEngine.Object.Instantiate(textObjects[0], parent);
					gameObject = UnityEngine.Object.Instantiate(lineObjects[0], lineParent);
					textObjects.Add(textMeshProUGUI);
					lineObjects.Add(gameObject);
				}
				else
				{
					textMeshProUGUI = textObjects[j];
					gameObject = lineObjects[j];
				}
				textMeshProUGUI.gameObject.SetActive(value: true);
				gameObject.SetActive(value: true);
				SetValueAction(textMeshProUGUI, inputOutputAmount, j);
			}
			parent.gameObject.SetActive(!hide && inputOutputAmount > 0);
		}
	}
}
