using System;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	public class ControlMapperSaver : MonoBehaviour
	{
		private ControlMapper cm;

		private bool changed;

		public event Action EnabledChanged;

		private void Awake()
		{
			cm = GetComponent<ControlMapper>();
			cm.InputPollingStartedEvent += OnInputPollingStartedEvent;
			cm.InputPollingEndedEvent += OnInputPollingEndedEvent;
			ControlMapper.ControlBindingChanged += OnBindingsChanged;
			foreach (ControllerMap allMap in InputManager.NewPlayer.controllers.maps.GetAllMaps())
			{
				for (int num = allMap.AllMaps.Count - 1; num >= 0; num--)
				{
					ActionElementMap actionElementMap = allMap.AllMaps[num];
					actionElementMap.invert = false;
					if (actionElementMap.controllerMap.categoryId == 0 && actionElementMap.actionId == InputManager.Actions.AlternativeScroll)
					{
						InputManager.NewPlayer.controllers.maps.GetMap(ControllerType.Keyboard, 0, 4, 0).CreateElementMap(actionElementMap.actionId, actionElementMap.axisContribution, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						actionElementMap.controllerMap.DeleteElementMap(actionElementMap.id);
					}
				}
			}
		}

		private void OnDestroy()
		{
			ControlMapper.ControlBindingChanged -= OnBindingsChanged;
		}

		private void OnBindingsChanged()
		{
			changed = true;
		}

		private void OnInputPollingStartedEvent()
		{
			InputManager.SetAllMapsBesidesPredicateEnabled((ControllerMap m) => false, enabled: false);
		}

		private void OnInputPollingEndedEvent()
		{
			InputManager.SetAllMapsBesidesPredicateEnabled((ControllerMap m) => false, enabled: true);
		}

		private void OnDisable()
		{
			ReInput.userDataStore.Save();
			if (changed)
			{
				InputManager.Fire_KeybindingsChanged();
				changed = false;
			}
			this.EnabledChanged?.Invoke();
		}

		private void OnEnable()
		{
			this.EnabledChanged?.Invoke();
		}
	}
}
