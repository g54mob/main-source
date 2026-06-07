using System.Collections.Generic;
using Placemaker.SceneProcessing;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class KeyboardAndMouseControlRemap : UIBehaviour, UiMaster.IUiSetup, IOnScenePostProcess
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private GenericControlsMenu genericControlsMenu;

		[SerializeField]
		private Transform keyParent;

		[SerializeField]
		private Transform keyLayout;

		[SerializeField]
		private GenericControlsMenu controlsMenu;

		[SerializeField]
		private CanvasGroup darkener;

		public UpdateState darkenState;

		private InputMapper inputMapper;

		private static List<string> possibleBindingCharacters;

		private const string category = "Default";

		private const string uiCategory = "UI";

		private const string layout = "Default";

		[SerializeField]
		private bool buttonMapState;

		[SerializeField]
		private bool conflictFound;

		public ControlBindingKey currentKey;

		[SerializeField]
		private List<ControlBindingKey> controlBindingKeys;

		[SerializeField]
		private bool hasSetup;

		public void OnSetup(UiMaster master)
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}

		private void Setup()
		{
		}

		private void OnInputFieldClicked(ControlBindingKey controlBindingKey)
		{
		}

		private void RefreshControls()
		{
		}

		private new void OnEnable()
		{
		}

		private new void OnDisable()
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

		public bool CanKeyBeMapped(string CharacterName)
		{
			return false;
		}

		public void OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}

		public void DarkenerClicked()
		{
		}

		public void LeaveControlRemapButton()
		{
		}

		public void ResetControlsButton()
		{
		}
	}
}
