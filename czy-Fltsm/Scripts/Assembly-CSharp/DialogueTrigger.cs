using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Attributes;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class DialogueTrigger : IDialogueInteractable
{
	[Serializable]
	private class ResponseHandler
	{
		[Serializable]
		public struct Path
		{
			[GeneratedEnum]
			public DialogueResponseType[] Array;
		}

		[SerializeField]
		[Tooltip("Use a response path instead of a single response to trigger this handler?")]
		public bool UseResponsePath;

		[ConditionalHide("UseResponsePath", true, true)]
		[GeneratedEnum]
		public DialogueResponseType Response;

		[ConditionalHide("UseResponsePath", true, false)]
		[Wrapper("Array")]
		public Path ResponsePath;

		[SerializeReference]
		[InstantiateSerializeReference]
		public IDialogueEvent Event;

		public bool HandlesResponse(DialogueResponseType response, List<DialogueResponseType> responsePath)
		{
			if (UseResponsePath)
			{
				if (responsePath.Count != ResponsePath.Array.Length)
				{
					return false;
				}
				for (int i = 0; i < responsePath.Count; i++)
				{
					if (responsePath[i] != ResponsePath.Array[i])
					{
						return false;
					}
				}
				return true;
			}
			return response == Response;
		}
	}

	[SerializeField]
	[FormerlySerializedAs("Trigger")]
	private DialogueTriggerType _trigger;

	[SerializeField]
	[FormerlySerializedAs("Dialogue")]
	private DialogueBranchReference _dialogue;

	[SerializeField]
	private bool _triggerOnlyOnce = true;

	[SerializeField]
	[Tooltip("Should this dialogue be queued if there is an active dialogue?")]
	private bool _enqueue = true;

	[SerializeField]
	private List<ResponseHandler> _responseHandlers = new List<ResponseHandler>();

	[SerializeField]
	[Min(0f)]
	private float _delay;

	[SerializeField]
	[HideInInspector]
	private ushort _uniqueID;

	private IDialogueContextProvider _context;

	private Action<DialogueResponseType, Dialogue> _responseCallback;

	private ListPool<DialogueResponseType>.List _responsePath;

	public DialogueTriggerType Type => _trigger;

	public DialogueTreeProperties DialogueProperties { get; private set; }

	public bool TriggerOnlyOnce => _triggerOnlyOnce;

	public bool EndOfDialogueReceived { get; private set; }

	public ushort UniqueID => _uniqueID;

	public bool Queue => _enqueue;

	public float Delay => _delay;

	public void Trigger()
	{
		_responsePath = ListPool<DialogueResponseType>.Get();
		if (SetDialogueProperties(_dialogue.Dialogue))
		{
			DialogueGameEvent.DispatchDialogueStartRequest(this);
		}
		else
		{
			OnDialogueResponse(DialogueResponseType.EndOfDialogue, null);
		}
	}

	public void Trigger(IDialogueContextProvider context, Action<DialogueResponseType, Dialogue> responseCallback = null)
	{
		_context = context;
		Trigger(responseCallback);
	}

	private void Trigger(Action<DialogueResponseType, Dialogue> responseCallback = null)
	{
		_responseCallback = responseCallback;
		_responsePath = ListPool<DialogueResponseType>.Get();
		if (_dialogue.Branch != DialogueBranchType.None && SetDialogueProperties(_dialogue.Dialogue))
		{
			DialogueGameEvent.DispatchDialogueStartRequest(this);
		}
		else
		{
			OnDialogueResponse(DialogueResponseType.EndOfDialogue, null);
		}
	}

	public IEnumerator TriggerRoutine(float fallbackWaitTime = 0f)
	{
		if (ValidateDialogue())
		{
			Trigger();
			while (!EndOfDialogueReceived)
			{
				yield return null;
			}
		}
		else if (0f < fallbackWaitTime)
		{
			yield return new WaitForSeconds(fallbackWaitTime);
		}
	}

	private bool SetDialogueProperties(DialogueTreeProperties dialogueProperties)
	{
		if ((bool)dialogueProperties)
		{
			DialogueProperties = dialogueProperties;
			return true;
		}
		return false;
	}

	public bool ValidateDialogue(DialogueTreeProperties dialogueProperties = null)
	{
		return _dialogue.ValidateReference(dialogueProperties);
	}

	public void AssignUniqueID(ushort id)
	{
		_uniqueID = id;
	}

	public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
	{
		return _dialogue.TryGetReference(out entryPoint, DialogueProperties);
	}

	public bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
	{
		if (_context != null)
		{
			return _context.TryGetMainSpeaker(out mainSpeaker);
		}
		mainSpeaker = null;
		return false;
	}

	public bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
	{
		if (_context != null)
		{
			return _context.TryGetActorDescriptor(actorType, out actorDescriptor);
		}
		return StoryManager.DialogueContext.TryGetActor(actorType, out actorDescriptor);
	}

	public bool TryGetLandmark(out LandmarkSpawner landmarkSpawner)
	{
		landmarkSpawner = null;
		if (_context != null)
		{
			return _context.TryGetLandmark(out landmarkSpawner);
		}
		return false;
	}

	public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
	{
		if (dialogue != null && dialogue.IsInRepeat)
		{
			return;
		}
		_responseCallback?.Invoke(response, dialogue);
		if (response == DialogueResponseType.None)
		{
			return;
		}
		if (_responsePath == null)
		{
			_responsePath = ListPool<DialogueResponseType>.Get();
		}
		_responsePath.Add(response);
		foreach (ResponseHandler responseHandler in _responseHandlers)
		{
			if (responseHandler.HandlesResponse(response, _responsePath))
			{
				responseHandler.Event.TriggerEvent(dialogue);
			}
		}
		if (response == DialogueResponseType.EndOfDialogue)
		{
			EndOfDialogueReceived = true;
			_responseCallback = null;
			_responsePath.Dispose();
			_responsePath = null;
		}
	}
}
