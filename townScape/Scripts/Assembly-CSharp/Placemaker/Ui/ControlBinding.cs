using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ControlBinding : UIBehaviour, UiMaster.IUiSetup
	{
		public enum ControllerTypeGroup
		{
			KeyboardAndMouse = 0,
			Joystick = 1
		}

		private struct TargetMapping
		{
			public ControllerMap controllerMap;

			public int actionElementMapId;
		}

		public enum RowVisibilityCategory
		{
			KeyboardAndMouse = 0,
			Joystick = 1,
			All = 2
		}

		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private BindingRow srcBindingRow;

		[SerializeField]
		private Transform rowsLayout;

		[SerializeField]
		private TextMeshProUGUI statusText;

		[SerializeField]
		private List<BindingRow> bindingRows;

		[SerializeField]
		private List<BindingRow> bindingRowsPool;

		public UpdateState openState;

		private const string category = "Default";

		private const string uiCategory = "UI";

		private const string layout = "Default";

		private bool conflictFound;

		[SerializeField]
		private bool buttonMapState;

		private static List<string> bindingActions;

		private static List<string> possibleBindingCharacters;

		private InputMapper inputMapperJoystickKeyboard;

		private InputMapper inputMapperMouse;

		private ControllerTypeGroup selectedControllerGroupType;

		private int selectedControllerGroupId;

		private TargetMapping replaceTargetMapping;

		public GameObject rebindingDialogPanel;

		public void OnSetup(UiMaster master)
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		public void Open()
		{
		}

		public void Close(bool openSettings)
		{
		}

		private void SetupMenu()
		{
		}

		private new void OnEnable()
		{
		}

		private new void OnDisable()
		{
		}

		public void Confirm()
		{
		}

		public void LoadDefaultControls()
		{
		}

		private void SetRowButtons()
		{
		}

		private void SetRow(InputAction action, AxisRange actionRange, string label, RowVisibilityCategory visibility, int index)
		{
		}

		private void OnInputMapped(InputMapper.InputMappedEventData data)
		{
		}

		private void OnConflictFound(InputMapper.ConflictFoundEventData data)
		{
		}

		private void OnStopped(InputMapper.StoppedEventData data)
		{
		}

		private bool OnIsElementAllowed(ControllerPollingInfo info)
		{
			return false;
		}

		private void OnInputFieldClicked(int index, int actionElementMapToReplaceId, bool isAltField)
		{
		}

		private void StartListeningDelayedMouseAndKeyboard(int index, ControllerMap keyboardMap, ControllerMap mouseMap, int actionElementMapToReplaceId, bool isAltField)
		{
		}

		private void StartListeningDelayedJoystick(int index, int actionElementMapToReplaceId)
		{
		}

		public void OnControllerSelected(int controllerType)
		{
		}

		private void SetSelectedController(ControllerTypeGroup controllerTypeGroup)
		{
		}

		public bool AreAllActionsMapped()
		{
			return false;
		}

		public bool CanKeyBeMapped(string CharacterName)
		{
			return false;
		}

		private void SetStatusText(string text)
		{
		}
	}
}
