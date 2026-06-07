using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.Apps
{
	public class DebugApp : MultiToolEditorApp, IRetroDebuggerListener, RetroUICodeEditor.IListener, RetroUITextInput_InputManager.IListener, AssetContainer.IListener
	{
		public enum EditMode
		{
			Standard = 0,
			VIM = 1
		}

		private class AutocompletingFunctionArgs
		{
			public string documentationSymbol;

			public int line;

			public string prefix;

			public string suffix;
		}

		private MultitoolConsoleService console;

		private MultitoolDebugInfoService debugInfo;

		public GameObject debugControlButtons;

		public EditMode editMode;

		public RetroUICodeEditor codeEditor;

		public TextMeshProUGUI selectCpuOrAssetLabel;

		public TextMeshProUGUI selectCpuAssetLabel;

		public TextMeshProUGUI cpuNameLabel;

		public GameObject debugButton;

		public CodeEditorAutocompletePopup autocompletePopup;

		public CodeEditorDebugTooltip debugTooltip;

		public GameObject wordWrapButton;

		private CPUModule selectedCpu;

		public Color errorHightlightColor;

		public Color pauseHightlightColor;

		private RetroNativeCore.CheckResult sourceCheckResult;

		public Sprite lensCursor;

		private DebugAppStacktraceService stacktraceService;

		private MultitoolDocumentationInfoService documentationInfoService;

		private EditMode _editMode;

		private Gadget lastGadget;

		private bool openingNewAsset;

		private bool sourceChanged;

		private bool needSourceCheck;

		private float sourceChangedTime;

		private AutocompleteResult lastAutocomplteResult;

		private string lastAutocompleteCleanedText;

		private RetroNativeCore.AutocompleteRequest lastAutocompleteRequest;

		private uint lastAutocompleteRequestId;

		private List<AutocompletingFunctionArgs> autocompletingFunctionArgs;

		private uint lastSourceCheckId;

		private bool stacktraseJustOpened;

		private bool debugEnabled;

		public CodeAsset selectedCodeAsset { get; private set; }

		private bool wordWrap
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public override void Init()
		{
		}

		private void ApplyConf()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		private void RefreshWordWrapButton()
		{
		}

		public void OnWordWrapButtonClick()
		{
		}

		public override void OnGadgetEndEdit()
		{
		}

		private void RefreshTitle()
		{
		}

		public override bool SupportsVariableResolution()
		{
			return false;
		}

		public override MultitoolCanvas.ShaderMode GetShaderMode()
		{
			return default(MultitoolCanvas.ShaderMode);
		}

		private void RefreshEditMode()
		{
		}

		public override void OnGadgetTurnOn()
		{
		}

		public override void OnGadgetTurnOff()
		{
		}

		public void SetCPU(CPUModule cpu, CodeAsset newCodeAsset = null)
		{
		}

		public void SetCodeAsset(CodeAsset codeAsset)
		{
		}

		public override void EditAsset(Asset asset)
		{
		}

		public override void OnMultitoolOpen()
		{
		}

		public override void OnSetGadget(Gadget gadget)
		{
		}

		private void OnAssetSelectionChange()
		{
		}

		public void OnSourceChange(RetroUICodeEditor codeEditor)
		{
		}

		public void OnNewLine(RetroUITextInput_InputManager inputManager)
		{
		}

		public void OnInsertFromKeyboard(RetroUITextInput_InputManager inputManager)
		{
		}

		public override void OnSolderModule(Module module)
		{
		}

		public override void OnUnsolderModule(Module module)
		{
		}

		public void OnAutocompleteRequest(RetroUITextInput_InputManager inputManager)
		{
		}

		public void RequestAutocomplete()
		{
		}

		private void OnAutocompleteResult(uint requestId, AutocompleteResult result)
		{
		}

		private void ShowAutocomplete(RetroNativeCore.AutocompleteRequest request, AutocompleteResult result)
		{
		}

		private void HideAutocomplete()
		{
		}

		private void SetPanelPosition(RectTransform target, RetroUIText.TextCoord textPosition, float horizontalOffset = 0f)
		{
		}

		private int CheckAutocompletingFunctionArgs(out int startIndex, out int endIndex)
		{
			startIndex = default(int);
			endIndex = default(int);
			return 0;
		}

		private void OnBeginAutocompletingFunctionArgs(string documentationSymbol)
		{
		}

		private void OnAutocompleteSelection(AutocompleteEntry autocompleteEntry, RetroUIText.TextCoord beginCoord, int charsToReplace)
		{
		}

		private void OnAutocompleteCancel()
		{
		}

		private void Update()
		{
		}

		private void RequestSourceCheck()
		{
		}

		private void OnCheckSourceResult(uint id, RetroNativeCore.CheckResult result)
		{
		}

		private void UpdateUI()
		{
		}

		public void OnDebugButton()
		{
		}

		public void OnDebugStepButton()
		{
		}

		public void OnDebugContinueButton()
		{
		}

		public void OnZoomPlusButton()
		{
		}

		public void OnZoomMinusButton()
		{
		}

		private void EnableDebug()
		{
		}

		private void DisableDebug()
		{
		}

		public void OnDebugStateChange()
		{
		}

		private void LockCode()
		{
		}

		private void UnlockCode()
		{
		}

		public void OnBreakpointsChanged(RetroUICodeEditor codeEditor)
		{
		}

		public void OnDebugBreak(ModuleId cpuId, LuaStacktrace stacktrace)
		{
		}

		private IEnumerator OnBreakpointC(CPUModule cpu, LuaStacktrace stacktrace)
		{
			return null;
		}

		public void SelectNextCpu()
		{
		}

		private void OnEndEditCommandBar(string s)
		{
		}

		private IEnumerator OnEndEditCommandBarCoroutine(string s)
		{
			return null;
		}

		private void OnSubmitCommandBar(string s)
		{
		}

		public void OnAssetAddedToContainer(AssetContainer container, AssetSelector assetSelector)
		{
		}

		public void OnAssetRemovedFromContainer(AssetContainer container, AssetSelector assetSelector)
		{
		}

		public override void OnSelectModule(Module module)
		{
		}
	}
}
