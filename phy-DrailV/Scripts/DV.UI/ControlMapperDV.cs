using System.Collections.Generic;
using System.Linq;
using DV.RailDriver;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

public class ControlMapperDV : ControlMapper
{
	[Header("DV shit")]
	public Selector selector;

	public RailDriver railDriver;

	private List<string> controllerNames = new List<string>();

	protected override void Start()
	{
		base.Start();
		selector.SelectionChanged += OnControllerSelectionChanged;
		railDriver = SingletonBehaviour<RailDriver>.Instance;
	}

	private void OnControllerSelectionChanged(IClickable clickable, int selectedindex)
	{
		OnButtonActivated(assignedControllerButtons[selectedindex].buttonInfo);
	}

	protected override void OnControllerAssignmentConfirmed(int windowId, Player player, int controllerId, ControllerType controllerType)
	{
		base.OnControllerAssignmentConfirmed(windowId, player, controllerId, controllerType);
		OnButtonActivated(assignedControllerButtons.First(delegate(GUIButton b)
		{
			int intData = b.buttonInfo.intData;
			int num = intData & 0xFFFF;
			ControllerType controllerType2 = (ControllerType)(intData >> 16);
			return num == controllerId && controllerType2 == controllerType;
		}).buttonInfo, force: true);
	}

	protected override void RedrawMapCategoriesGroup(bool playTransitions)
	{
		if (base.showMapCategories)
		{
			for (int i = 0; i < mapCategoryButtons.Count; i++)
			{
				bool marked = currentMapCategoryId == mapCategoryButtons[i].buttonInfo.intData;
				mapCategoryButtons[i].SetInteractible(state: true, playTransitions);
				mapCategoryButtons[i].rectTransform.GetComponentInChildren<IMarkable>().ToggleMarked(marked);
			}
		}
	}

	protected override void RedrawControllerGroup()
	{
		int num = -1;
		bool drawRailDriver = SingletonBehaviour<RailDriver>.Instance.activeWrapper != null;
		references.controllerNameLabel.text = _language.none;
		UITools.SetInteractable(references.removeControllerButton, state: false, playTransition: false);
		UITools.SetInteractable(references.assignControllerButton, state: false, playTransition: false);
		UITools.SetInteractable(references.calibrateControllerButton, state: false, playTransition: false);
		if (ShowAssignedControllers())
		{
			foreach (GUIButton assignedControllerButton in assignedControllerButtons)
			{
				if (!(assignedControllerButton.gameObject == null))
				{
					if (base.currentUISelection == assignedControllerButton.gameObject)
					{
						num = assignedControllerButton.buttonInfo.intData;
					}
					Object.Destroy(assignedControllerButton.gameObject);
				}
			}
			assignedControllerButtons.Clear();
			assignedControllerButtonsPlaceholder.SetActive(state: true);
		}
		Player player = ReInput.players.GetPlayer(currentPlayerId);
		if (player == null)
		{
			return;
		}
		assignedControllerButtonsPlaceholder.SetActive(state: false);
		Controller[] array = (from c in player.controllers.JoysticksAndCustomControllers()
			where drawRailDriver || !c.name.Equals("RailDriverDV")
			select c).ToArray();
		if (ShowAssignedControllers())
		{
			controllerNames.Clear();
			if (array.Length != 0)
			{
				controllerNames.AddRange(array.Select((Controller c) => c.name));
			}
			else
			{
				controllerNames.Add(assignedControllerButtonsPlaceholder.buttonInfo.text.text);
			}
			selector.SetValues(controllerNames);
			selector.ToggleInteractable(controllerNames.Count > 1);
			Controller[] array2 = array;
			foreach (Controller controller in array2)
			{
				GUIButton gUIButton2 = CreateButton(_language.GetControllerName(controller), references.assignedControllersGroup.content, Vector2.zero);
				int id = controller.id;
				id |= (int)controller.type << 16;
				gUIButton2.SetButtonInfoData("AssignedControllerSelection", id);
				gUIButton2.SetOnClickCallback(base.OnButtonActivated);
				gUIButton2.buttonInfo.OnSelectedEvent += base.OnUIElementSelected;
				gUIButton2.buttonInfo.gameObject.SetActive(value: false);
				assignedControllerButtons.Add(gUIButton2);
				if (controller.id == customControllerId && controller.type == currentControllerType)
				{
					gUIButton2.SetInteractible(state: false, playTransition: true);
					selector.SetSelectedIndex(assignedControllerButtons.Count - 1, fireEvent: false);
				}
			}
			if (array.Length != 0 && !base.isJoystickSelected)
			{
				Controller controller2 = array[0];
				customControllerId = controller2.id;
				currentControllerType = controller2.type;
				assignedControllerButtons[0].SetInteractible(state: false, playTransition: false);
				selector.SetSelectedIndex(0);
			}
			if (num >= 0)
			{
				for (int num3 = 0; num3 < assignedControllerButtons.Count; num3++)
				{
					GUIButton gUIButton3 = assignedControllerButtons[num3];
					if (gUIButton3.buttonInfo.intData == num)
					{
						SetUISelection(gUIButton3.gameObject);
						selector.SetSelectedIndex(num3);
						break;
					}
				}
			}
		}
		else if (array.Length != 0 && !base.isJoystickSelected)
		{
			Controller controller3 = array[0];
			customControllerId = controller3.id;
			currentControllerType = controller3.type;
			selector.SetSelectedIndex(0);
		}
		if (base.isJoystickSelected && player.controllers.JoystickAndCustomControllersCount() > 0)
		{
			references.removeControllerButton.interactable = true;
			references.controllerNameLabel.text = _language.GetControllerName(base.currentController);
			if (base.currentController.axisCount > 0)
			{
				references.calibrateControllerButton.interactable = true;
			}
		}
		int joystickCount = player.controllers.joystickCount;
		int joystickCount2 = ReInput.controllers.joystickCount;
		int num4 = GetMaxControllersPerPlayer();
		bool flag = num4 == 0;
		if (joystickCount2 > 0 && joystickCount < joystickCount2 && (num4 == 1 || flag || joystickCount < num4))
		{
			UITools.SetInteractable(references.assignControllerButton, state: true, playTransition: false);
		}
	}
}
