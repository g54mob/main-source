using System;
using UnityEngine;
using UnityEngine.Events;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableDialogue : ScenarioTriggerableBase, IDialogueInteractable
	{
		[Header("Dialogue")]
		[SerializeField]
		private DialogueBranchReference _dialogueBranchReference;

		[SerializeField]
		private ActorProfile _actorProfile;

		public DialogueTreeProperties DialogueProperties => _dialogueBranchReference.Dialogue;

		public AgentDescriptor Actor { get; private set; }

		public UnityEvent<TriggerableDialogue> EndOfDialogueEvent { get; private set; } = new UnityEvent<TriggerableDialogue>();

		protected override bool Trigger(AgentDescriptor actor = null)
		{
			Actor = actor;
			if (Actor == null && (bool)_actorProfile)
			{
				Actor = _actorProfile.GetActorDiscriptor() as AgentDescriptor;
			}
			DialogueGameEvent.DispatchDialogueStartRequest(this);
			return true;
		}

		public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
		{
			if (response == DialogueResponseType.EndOfDialogue)
			{
				EndOfDialogueEvent.Invoke(this);
			}
		}

		public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
		{
			return _dialogueBranchReference.TryGetReference(out entryPoint);
		}

		public bool TryGetMainSpeaker(out AgentDescriptor descriptor)
		{
			descriptor = Actor;
			return descriptor != null;
		}
	}
}
