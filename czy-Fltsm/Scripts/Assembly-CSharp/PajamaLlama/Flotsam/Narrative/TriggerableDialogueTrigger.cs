using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableDialogueTrigger : ScenarioTriggerableBase, IDialogueContextProvider
	{
		[Serializable]
		private struct ResponsePath
		{
			public DialogueResponseType[] Responses;

			public bool IsMatch(List<DialogueResponseType> responsePath)
			{
				if (responsePath.Count != Responses.Length)
				{
					return false;
				}
				int num = Responses.Length;
				while (0 < num--)
				{
					if (Responses[num] != responsePath[num])
					{
						return false;
					}
				}
				return true;
			}
		}

		[Header("Dialogue")]
		[SerializeField]
		private DialogueTrigger _dialogueTrigger;

		[SerializeField]
		private AgentProfile _mainSpeaker;

		[SerializeField]
		private ResponsePath[] _resetResponsePaths;

		private List<DialogueResponseType> _responsePath;

		public DialogueTreeProperties DialogueProperties => _dialogueTrigger.DialogueProperties;

		public IReadOnlyList<DialogueTriggerType> SupportedTriggers { get; private set; } = new List<DialogueTriggerType> { DialogueTriggerType.None };

		protected override bool Trigger(AgentDescriptor actorDescriptor)
		{
			if (ConditionsAreMet())
			{
				if (_resetResponsePaths.IsNullOrEmpty())
				{
					_dialogueTrigger.Trigger(this);
				}
				else
				{
					_dialogueTrigger.Trigger(this, OnDialogueResponse);
				}
				return true;
			}
			return false;
		}

		public bool TryGetMainSpeaker(out AgentDescriptor agentDescriptor)
		{
			if ((bool)_mainSpeaker)
			{
				agentDescriptor = _mainSpeaker.GetDescriptor();
				return true;
			}
			agentDescriptor = null;
			return false;
		}

		public bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
		{
			return false;
		}

		private void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
		{
			switch (response)
			{
			case DialogueResponseType.EndOfDialogue:
				_responsePath.Dispose();
				_responsePath = null;
				return;
			case DialogueResponseType.None:
				return;
			}
			if (_responsePath == null)
			{
				_responsePath = ListPool<DialogueResponseType>.Get();
			}
			_responsePath.Add(response);
			ResponsePath[] resetResponsePaths = _resetResponsePaths;
			foreach (ResponsePath responsePath in resetResponsePaths)
			{
				if (responsePath.IsMatch(_responsePath))
				{
					Reset();
				}
			}
		}
	}
}
