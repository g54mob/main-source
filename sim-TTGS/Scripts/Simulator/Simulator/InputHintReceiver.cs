using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	public class InputHintReceiver : MonoBehaviour
	{
		private readonly List<InputHint> m_inputHints = new List<InputHint>();

		private void OnEnable()
		{
			EventManager.OnWorldEvent += OnWorldEvent;
		}

		private void OnDisable()
		{
			EventManager.OnWorldEvent -= OnWorldEvent;
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.WORLD_REGISTRATION:
				InputHint.OnEnableEvent += OnInputHintEnable;
				InputHint.OnDisableEvent += OnInputHintDisable;
				InputHint.OnRefreshEvent += OnInputHintRefresh;
				break;
			case EWorldEvent.PREPARE_QUIT:
				InputHint.OnEnableEvent -= OnInputHintEnable;
				InputHint.OnDisableEvent -= OnInputHintDisable;
				InputHint.OnRefreshEvent -= OnInputHintRefresh;
				break;
			}
		}

		private void OnInputHintEnable(InputHint sender)
		{
			m_inputHints.Add(sender);
			Refresh();
		}

		private void OnInputHintDisable(InputHint sender)
		{
			m_inputHints.Remove(sender);
			Refresh();
		}

		private void OnInputHintRefresh(InputHint sender)
		{
			Refresh();
		}

		private void Refresh()
		{
			if (m_inputHints.Count == 0)
			{
				World.PlayerController.Hud.HideInputs();
				return;
			}
			List<InputHint> inputHints = m_inputHints;
			InputHint inputHint = inputHints[inputHints.Count - 1];
			World.PlayerController.Hud.HideInputs();
			World.PlayerController.Hud.ShowInputs(inputHint.DisplayDatas);
		}
	}
}
