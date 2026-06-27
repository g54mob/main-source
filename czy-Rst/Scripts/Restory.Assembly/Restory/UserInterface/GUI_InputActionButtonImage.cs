using System;
using System.Collections.Generic;
using Restory.Data.GUIControllerElements;
using Restory.Data.Remapping;
using Restory.Gameplay.GameSettings;
using Restory.Gameplay.PlayerInput;
using Restory.Remapping;
using Rewired;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public sealed class GUI_InputActionButtonImage : MonoBehaviour
	{
		[Serializable]
		public struct ControllerInfo
		{
			public ControllerType controllerType;

			public int controllerId;

			public ControllerInfo(ControllerType controllerType)
			{
				this.controllerType = controllerType;
				controllerId = 0;
			}

			public ControllerInfo(ControllerType controllerType, int controllerId)
			{
				this.controllerType = controllerType;
				this.controllerId = controllerId;
			}
		}

		private static class Style
		{
			public const string Data = "Data";

			public const string Gui = "GUI";
		}

		[SerializeField]
		private Restory.Data.Remapping.InputAction inputAction;

		[SerializeField]
		private AxisRange axisRange;

		[SerializeField]
		private bool hold;

		[SerializeField]
		private ControllerType controllerType;

		[SerializeField]
		private List<ControllerInfo> additionalControllers = new List<ControllerInfo>();

		[SerializeField]
		private GuiControllerTemplateList controllerTemplateList;

		[SerializeField]
		private ControllerIdsList controllerIdsList;

		[SerializeField]
		private RewiredControllerIdsDependencyMap rewiredControllerIdsDependencyMap;

		[Space]
		[SerializeField]
		private Image targetImage;

		private ControllerId controllerId;

		private IGuiControllerTemplate template;

		private IGuiControllerTemplateElement element;

		private GameSettingsManager gameSettingsManager;

		private IPlayerInput playerInput;

		private IInputUserData inputUserData;

		private bool subscribedOnGamepadScheme;

		private bool subscribedOnControllerChanged;

		public Restory.Data.Remapping.InputAction InputAction
		{
			get
			{
				return inputAction;
			}
			set
			{
				SetInputAction(value);
			}
		}

		public AxisRange AxisRange
		{
			get
			{
				return axisRange;
			}
			set
			{
				SetAxisRange(value);
			}
		}

		public bool Hold
		{
			get
			{
				return hold;
			}
			set
			{
				SetHold(value);
			}
		}

		public ControllerType ControllerType
		{
			get
			{
				return controllerType;
			}
			set
			{
				SetControllerType(value);
			}
		}

		public IReadOnlyList<ControllerInfo> AdditionalControllers
		{
			get
			{
				return additionalControllers;
			}
			set
			{
				SetAdditionalControllers(value);
			}
		}

		public GuiControllerTemplateList СontrollerTemplateList
		{
			get
			{
				return controllerTemplateList;
			}
			set
			{
				SetСontrollerTemplateList(value);
			}
		}

		[Inject]
		private void Construct(GameSettingsManager gameSettingsManager, IPlayerInput playerInput, IInputUserData inputUserData)
		{
			this.gameSettingsManager = gameSettingsManager;
			this.playerInput = playerInput;
			this.inputUserData = inputUserData;
			if (base.isActiveAndEnabled)
			{
				UpdateData();
				UpdateImage();
				SubscribeOnControllerChanged();
				SubscribeOnGamepadScheme();
			}
		}

		private void OnEnable()
		{
			UpdateData();
			UpdateImage();
			SubscribeOnControllerChanged();
			SubscribeOnGamepadScheme();
		}

		private void OnDisable()
		{
			UnsubscribeOnControllerChanged();
			UnsubscribeOnGamepadScheme();
		}

		public void SetInputActionAndAxis(Restory.Data.Remapping.InputAction inputAction, AxisRange axisRange, bool hold)
		{
			this.inputAction = inputAction;
			this.axisRange = axisRange;
			this.hold = hold;
			UpdateData();
			UpdateImage();
		}

		public void SetInputActionAndAxis(Restory.Data.Remapping.InputAction inputAction, AxisRange axisRange)
		{
			this.inputAction = inputAction;
			this.axisRange = axisRange;
			UpdateData();
			UpdateImage();
		}

		public void SetInputAction(Restory.Data.Remapping.InputAction inputAction)
		{
			if (!(this.inputAction == inputAction))
			{
				this.inputAction = inputAction;
				UpdateData();
				UpdateImage();
			}
		}

		public void SetAxisRange(AxisRange axisRange)
		{
			if (this.axisRange != axisRange)
			{
				this.axisRange = axisRange;
				UpdateData();
				UpdateImage();
			}
		}

		public void SetHold(bool hold)
		{
			if (this.hold != hold)
			{
				this.hold = hold;
				UpdateImage();
			}
		}

		public void SetControllerType(ControllerType controllerType)
		{
			if (this.controllerType != controllerType)
			{
				this.controllerType = controllerType;
				UpdateData();
				UpdateImage();
			}
		}

		public void SetСontrollerTemplateList(GuiControllerTemplateList controllerTemplateList)
		{
			if (!(this.controllerTemplateList == controllerTemplateList))
			{
				this.controllerTemplateList = controllerTemplateList;
				UpdateImage();
			}
		}

		public void ClearAdditionalControllers()
		{
			additionalControllers.Clear();
			UpdateData();
			UpdateImage();
		}

		public void SetAdditionalControllers(ControllerType controllerType)
		{
			additionalControllers.Clear();
			additionalControllers.Add(new ControllerInfo(controllerType));
			UpdateData();
			UpdateImage();
		}

		public void SetAdditionalControllers(IEnumerable<ControllerInfo> additionalControllers)
		{
			this.additionalControllers.Clear();
			this.additionalControllers.AddRange(additionalControllers);
			UpdateData();
			UpdateImage();
		}

		public void SetAdditionalControllers(params ControllerInfo[] additionalControllers)
		{
			this.additionalControllers.Clear();
			this.additionalControllers.AddRange(additionalControllers);
			UpdateData();
			UpdateImage();
		}

		public void UpdateData()
		{
			if (inputAction == null || playerInput == null)
			{
				controllerId = null;
				template = null;
				element = null;
			}
			else
			{
				TryGetElementMap(out var actionElementMap);
				UpdateControllerId(actionElementMap?.controllerMap.controller);
				UpdateTemplate();
				UpdateTemplateElement(GetElementId(actionElementMap));
			}
		}

		private bool TryGetElementMap(out ActionElementMap actionElementMap)
		{
			int num = playerInput.ControllerId;
			if (inputUserData.ActionsDependencyMap.GetRewiredFirstActionElementMap(playerInput.Id, controllerType, num, inputAction, axisRange, out actionElementMap))
			{
				return true;
			}
			foreach (ControllerInfo additionalController in additionalControllers)
			{
				if (inputUserData.ActionsDependencyMap.GetRewiredFirstActionElementMap(playerInput.Id, additionalController.controllerType, num, inputAction, axisRange, out actionElementMap))
				{
					return true;
				}
			}
			actionElementMap = null;
			return false;
		}

		private static int GetElementId(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				return -1;
			}
			Controller controller = actionElementMap.controllerMap.controller;
			if (controller.templateCount > 0)
			{
				IGamepadTemplate gamepadTemplate = controller.GetTemplate<IGamepadTemplate>();
				if (gamepadTemplate != null)
				{
					List<ControllerTemplateElementTarget> list = new List<ControllerTemplateElementTarget>();
					if (gamepadTemplate.GetElementTargets(actionElementMap, list) > 0)
					{
						return list[0].element.id;
					}
				}
			}
			return actionElementMap.elementIdentifierId;
		}

		private void UpdateControllerId(Controller controller)
		{
			if (controller == null)
			{
				controllerId = null;
				return;
			}
			switch (controller.type)
			{
			case ControllerType.Mouse:
				controllerId = controllerIdsList.MouseId;
				break;
			case ControllerType.Keyboard:
				controllerId = controllerIdsList.KeyboardId;
				break;
			case ControllerType.Joystick:
				if ((gameSettingsManager == null || string.IsNullOrEmpty(gameSettingsManager.GamepadScheme) || !controllerIdsList.TryGetControllerId(gameSettingsManager.GamepadScheme, out controllerId)) && !rewiredControllerIdsDependencyMap.TryGetControllerId(controller.hardwareTypeGuid, out controllerId))
				{
					controllerId = controllerIdsList.DefaultGamepadId;
				}
				break;
			}
		}

		private void UpdateTemplate()
		{
			if (controllerId == null)
			{
				template = null;
			}
			else
			{
				controllerTemplateList.TryGetGuiControllerTemplate(controllerId, out template);
			}
		}

		private void UpdateTemplateElement(int elementId)
		{
			element = ((template == null) ? null : template.GetElement(elementId));
		}

		public void UpdateImage()
		{
			if (element == null)
			{
				targetImage.overrideSprite = null;
			}
			else
			{
				targetImage.overrideSprite = (hold ? element.GetPressSprite() : element.GetSprite(axisRange));
			}
		}

		private void SubscribeOnGamepadScheme()
		{
			if (!subscribedOnGamepadScheme && !(gameSettingsManager == null))
			{
				subscribedOnGamepadScheme = true;
				gameSettingsManager.GamepadSchemeChanged += OnGamepadScheme;
			}
		}

		private void UnsubscribeOnGamepadScheme()
		{
			if (subscribedOnGamepadScheme)
			{
				subscribedOnGamepadScheme = false;
				if (gameSettingsManager != null)
				{
					gameSettingsManager.GamepadSchemeChanged -= OnGamepadScheme;
				}
			}
		}

		private void OnGamepadScheme(string id)
		{
			UpdateData();
			UpdateImage();
		}

		private void SubscribeOnControllerChanged()
		{
			if (!subscribedOnControllerChanged && playerInput != null)
			{
				subscribedOnControllerChanged = true;
				playerInput.ControllerAddedEvent += OnControllerChanged;
			}
		}

		private void UnsubscribeOnControllerChanged()
		{
			if (subscribedOnControllerChanged)
			{
				subscribedOnControllerChanged = false;
				if (playerInput != null)
				{
					playerInput.ControllerAddedEvent -= OnControllerChanged;
				}
			}
		}

		private void OnControllerChanged(int id)
		{
			UpdateData();
			UpdateImage();
		}
	}
}
