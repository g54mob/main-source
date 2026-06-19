using System.Collections.Generic;
using System.Linq;
using AssembleSystem;
using AssembleSystem.FSM.Parts;
using AssembleSystem.FSM.Parts.States;
using AssembleSystem.Utils;
using Items;
using Loxodon.Framework.Contexts;
using Minigames;
using Player.FSM;
using StarterAssets;
using UI.HUD;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerPartProgressor : MonoBehaviour
	{
		public enum ToolDirection
		{
			TIGHTEN = 0,
			UNTIGHTEN = 1
		}

		[SerializeField]
		private RaycasterInfo _playerRaycastInfo;

		[SerializeField]
		private PlayerItemHolder _playerItemHolder;

		[SerializeField]
		private PlayerItemPicker _playerItemPicker;

		[SerializeField]
		private FirstPersonController _fpsController;

		private bool _minigameOpened;

		private IProgressable _currentProgressable;

		private ToolDirection _currentToolDirection;

		private MinigamesControllerView _minigamesController;

		private ScrewdriverMinigameView _screwMinigame;

		private WrenchMinigameView _wrenchMinigame;

		private WorldUIOutliner _worldUIOutliner;

		private InfoCursorsViewModel _infoCursorsViewModel;

		private ToolIconViewModel _toolIconViewModel;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private IPlayerEquipService _equipToolService;

		[Inject]
		private PlayerHUDView _HUDView;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerFSM;

		private void Start()
		{
			_minigamesController = _HUDView.MinigamesController;
			_screwMinigame = _minigamesController.ScrewdriverMinigame;
			_wrenchMinigame = _minigamesController.WrenchMinigame;
			_worldUIOutliner = _HUDView.WorldUIHighlighter;
			ApplicationContext applicationContext = Loxodon.Framework.Contexts.Context.GetApplicationContext();
			_infoCursorsViewModel = applicationContext.GetService<InfoCursorsViewModel>();
			_toolIconViewModel = applicationContext.GetService<ToolIconViewModel>();
		}

		private void OnEnable()
		{
			_inputService.OnInteract += ShowAssembleMinigame;
		}

		private void OnDisable()
		{
			_inputService.OnInteract -= ShowAssembleMinigame;
		}

		private void TryChangeDirection(float value)
		{
			if (value > 0f)
			{
				_currentToolDirection = ToolDirection.TIGHTEN;
			}
			else if (value < 0f)
			{
				_currentToolDirection = ToolDirection.UNTIGHTEN;
			}
		}

		private void ShowAssembleMinigame(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (_playerFSM.IsPlacing)
				{
					return;
				}
				Transform transform = _playerRaycastInfo.Hit.transform;
				if (transform == null)
				{
					return;
				}
				if (transform.TryGetComponent<PartObject>(out var component))
				{
					IProgressable progressable = component;
					if (progressable == null)
					{
						return;
					}
					List<PartObject> dependantParts = component.GetDependantParts();
					if (dependantParts != null)
					{
						foreach (PartObject item in dependantParts)
						{
							if (item.StateMachine.Placed)
							{
								return;
							}
						}
					}
					if (!component.StateMachine.Placed)
					{
						return;
					}
					EquipableToolItem equipableToolItem = _equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) as EquipableToolItem;
					if (equipableToolItem != null)
					{
						_minigameOpened = true;
						_currentProgressable = progressable;
						switch (equipableToolItem.ToolObject.ToolType)
						{
						case ProgressToolType.Screw:
							OpenScrewMinigame(progressable);
							break;
						case ProgressToolType.Spanner:
							OpenWrenchMinigame(progressable);
							break;
						}
					}
				}
			}
			if (context.canceled && _minigameOpened)
			{
				CloseAllMinigames();
				_currentProgressable = null;
			}
		}

		private void OpenWrenchMinigame(IProgressable progressable)
		{
			_wrenchMinigame.Progressor.OnProgressChanged += OnProgressChange;
			CursorLockKeeper.Apply(CursorLockMode.None, visible: true);
			_playerItemHolder.enabled = false;
			_playerItemPicker.enabled = false;
			_fpsController.SetCanRotateCamera(value: false);
			CursorControl.SetLocalCursorPos(new Vector2(Screen.width / 3, Screen.height / 3));
			_toolIconViewModel.Enabled = false;
			_infoCursorsViewModel.EnableUseHintSeperately(value: false);
			_minigamesController.EnableWrenchMinigame(progressable.CurrentProgress);
		}

		private void OpenScrewMinigame(IProgressable progressable)
		{
			_screwMinigame.Progressor.OnProgressChanged += OnProgressChange;
			CursorLockKeeper.Apply(CursorLockMode.None, visible: true);
			_playerItemHolder.enabled = false;
			_playerItemPicker.enabled = false;
			_fpsController.SetCanRotateCamera(value: false);
			CursorControl.SetLocalCursorPos(new Vector2(Screen.width / 3, Screen.height / 3));
			_toolIconViewModel.Enabled = false;
			_infoCursorsViewModel.EnableUseHintSeperately(value: false);
			_minigamesController.EnableScrewdriverMinigame(progressable.CurrentProgress);
		}

		private void CloseAllMinigames()
		{
			CursorLockKeeper.Apply(CursorLockMode.Locked, visible: false);
			_playerItemHolder.enabled = true;
			_playerItemPicker.enabled = true;
			_fpsController.SetCanRotateCamera(value: true);
			_minigamesController.DisableScrewMinigame();
			_minigamesController.DisableWrenchMinigame();
			_worldUIOutliner.gameObject.SetActive(value: true);
			_minigameOpened = false;
			UnsubscribeFromProgressables();
		}

		public void UnsubscribeFromProgressables()
		{
			_screwMinigame.Progressor.OnProgressChanged -= OnProgressChange;
			_wrenchMinigame.Progressor.OnProgressChanged -= OnProgressChange;
		}

		private void OnProgressChange(float progress)
		{
			if (_currentProgressable != null)
			{
				_currentProgressable.SetProgress(progress);
			}
		}

		private void TryProgressAssembleObjectOld(InputAction.CallbackContext context)
		{
			if (context.canceled)
			{
				EquipableToolItem equipableToolItem = _equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) as EquipableToolItem;
				if (equipableToolItem != null && equipableToolItem.ToolObject.AnyUseSoundPlaying())
				{
					equipableToolItem.ToolObject.StopUseSounds();
				}
			}
			if (!(_playerRaycastInfo.Hit.transform != null))
			{
				return;
			}
			if (_playerRaycastInfo.Hit.transform.TryGetComponent<ITempPart>(out var component))
			{
				Debug.Log(component.MainPart.gameObject.name);
				IProgressable mainPart = component.MainPart;
				if (mainPart == null)
				{
					return;
				}
				EquipableToolItem equipableToolItem2 = _equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) as EquipableToolItem;
				if (equipableToolItem2 == null || equipableToolItem2.ToolObject.ToolType != mainPart.ProgressTool)
				{
					return;
				}
				switch (equipableToolItem2.ToolObject.ToolUseType)
				{
				case ToolObject.UseType.Hold:
					if (context.started)
					{
						equipableToolItem2.ToolObject.PlayUseSounds();
						Debug.Log("Holding Start");
						_currentProgressable = mainPart;
					}
					else if (context.canceled)
					{
						equipableToolItem2.ToolObject.StopUseSounds();
						Debug.Log("Holding End");
						_currentProgressable = null;
					}
					break;
				case ToolObject.UseType.Click:
					if (context.performed)
					{
						equipableToolItem2.ToolObject.PlayUseSounds();
						Debug.Log("Click once");
						float num = equipableToolItem2.ToolObject.Power;
						if (_currentToolDirection == ToolDirection.TIGHTEN)
						{
							num = Mathf.Abs(num);
						}
						else if (_currentToolDirection == ToolDirection.UNTIGHTEN)
						{
							num = 0f - Mathf.Abs(num);
						}
						mainPart.AddProgress(num);
						((IProgressable)(component as MonoBehaviour).GetComponent<PartObject>()).AddProgress(num);
					}
					break;
				}
			}
			else
			{
				if (!_playerRaycastInfo.Hit.transform.TryGetComponent<PartObject>(out var component2))
				{
					return;
				}
				IProgressable progressable = component2;
				if (progressable == null || component2.enabled)
				{
					return;
				}
				AssembleObjectParent component3 = component2.AssembleParent.GetComponent<AssembleObjectParent>();
				List<PartConfig> dependantPartsConfigs = component3.GetDependantPartsConfigs(component2.Config);
				if (component3.GetPartsObjects(dependantPartsConfigs).Any((PartObject x) => x.StateMachine.Placed))
				{
					return;
				}
				EquipableToolItem equipableToolItem3 = _equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) as EquipableToolItem;
				if (equipableToolItem3 == null || equipableToolItem3.ToolObject.ToolType != progressable.ProgressTool)
				{
					return;
				}
				switch (equipableToolItem3.ToolObject.ToolUseType)
				{
				case ToolObject.UseType.Hold:
					if (context.started)
					{
						Debug.Log("Holding Start");
						equipableToolItem3.ToolObject.PlayUseSounds();
						_currentProgressable = progressable;
					}
					else if (context.canceled)
					{
						Debug.Log("Holding End");
						equipableToolItem3.ToolObject.StopUseSounds();
						_currentProgressable = null;
					}
					break;
				case ToolObject.UseType.Click:
					if (context.performed)
					{
						equipableToolItem3.ToolObject.PlayUseSounds();
						Debug.Log("Click once");
						float num2 = equipableToolItem3.ToolObject.Power;
						if (_currentToolDirection == ToolDirection.TIGHTEN)
						{
							num2 = Mathf.Abs(num2);
						}
						else if (_currentToolDirection == ToolDirection.UNTIGHTEN)
						{
							num2 = 0f - Mathf.Abs(num2);
						}
						progressable.AddProgress(num2);
						((IProgressable)component2).AddProgress(num2);
					}
					break;
				}
			}
		}

		private void Update()
		{
			UpdateAssemblyPartHints();
		}

		private void UpdateAssemblyPartHints()
		{
			Transform transform = _playerRaycastInfo.Hit.transform;
			if (transform == null || !transform.TryGetComponent<PartObject>(out var component) || component.StateMachine == null)
			{
				_HUDView.SetAssemblyPartHints(placed: false, tightened: false, readyToInstall: false);
				return;
			}
			PartObjectStateMachine stateMachine = component.StateMachine;
			if (!stateMachine.Placed || IsCoveredByDependant(component))
			{
				_HUDView.SetAssemblyPartHints(placed: false, tightened: false, readyToInstall: false);
				return;
			}
			AssembleObjectParent assembleObjectParent = ((component.AssembleParent != null) ? component.AssembleParent.GetComponent<AssembleObjectParent>() : null);
			if (assembleObjectParent != null && assembleObjectParent.StateMachine != null && assembleObjectParent.StateMachine.Assembled)
			{
				_HUDView.SetAssemblyPartHints(placed: false, tightened: false, readyToInstall: false);
				return;
			}
			bool placed = !stateMachine.Tightened;
			bool tightened = stateMachine.Tightened;
			bool readyToInstall = stateMachine.Tightened && HasDependants(component);
			_HUDView.SetAssemblyPartHints(placed, tightened, readyToInstall);
		}

		private bool IsCoveredByDependant(PartObject part)
		{
			foreach (PartObject dependantPart in part.GetDependantParts())
			{
				if (dependantPart != null && dependantPart.StateMachine != null && dependantPart.StateMachine.Placed)
				{
					return true;
				}
			}
			return false;
		}

		private bool HasDependants(PartObject part)
		{
			List<PartObject> dependantParts = part.GetDependantParts();
			if (dependantParts != null)
			{
				return dependantParts.Count > 0;
			}
			return false;
		}
	}
}
