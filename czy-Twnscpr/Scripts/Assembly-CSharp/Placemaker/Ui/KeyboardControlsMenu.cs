using System.Collections.Generic;
using Placemaker.SceneProcessing;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class KeyboardControlsMenu : UIBehaviour, UiMaster.IUiSetup, IOnScenePostProcess
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
		private CanvasGroup darkener;

		[SerializeField]
		private Transform keyParent;

		[SerializeField]
		private GenericControlsMenu controlsMenu;

		public UpdateState darkenState;

		private const string category = "Default";

		private const string uiCategory = "UI";

		private const string layout = "Default";

		private bool conflictFound;

		private static List<string> bindingActions;

		private static List<string> possibleBindingCharacters;

		private InputMapper inputMapperJoystickKeyboard;

		private InputMapper inputMapperMouse;

		private ControllerTypeGroup selectedControllerGroupType;

		private int selectedControllerGroupId;

		private TargetMapping replaceTargetMapping;

		public GameObject rebindingDialogPanel;

		public ControlBindingKey currentKey;

		public void OnSetup(UiMaster master)
		{
		}

		public void OnControlBindingClicked(ControlBindingKey controlBindingKey)
		{
		}

		public void DarkenerClicked()
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		private void SetupMenu()
		{
		}

		private void OnInputMapped(InputMapper.InputMappedEventData obj)
		{
		}

		private bool OnIsElementAllowed(ControllerPollingInfo obj)
		{
			return false;
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

		private void OnConflictFound(InputMapper.ConflictFoundEventData data)
		{
		}

		private void OnStopped(InputMapper.StoppedEventData data)
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

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}
	}
}
