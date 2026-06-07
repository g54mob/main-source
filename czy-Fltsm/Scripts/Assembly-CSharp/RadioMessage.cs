using System;
using System.Runtime.Serialization;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class RadioMessage : IDialogueInteractable
{
	[Serializable]
	public class PersistentData
	{
		[OptionalField(VersionAdded = 2)]
		private readonly int _propertiesIndex;

		[OptionalField(VersionAdded = 2)]
		private readonly ushort _senderID;

		[OptionalField(VersionAdded = 2)]
		private readonly int _dayReceived;

		[OptionalField(VersionAdded = 3)]
		private readonly bool _isNew;

		[OptionalField(VersionAdded = 2)]
		private PersistentReference<Quest>.Reference _quest;

		private readonly bool _isDistressSignal;

		private readonly int _dialoguePropertiesID = -1;

		private readonly PersistentProperties.Types _dialogueProviderType = PersistentProperties.Types.DialogueProperties;

		public PersistentData(RadioMessage message)
		{
			_propertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(message.Properties);
			_senderID = message.Sender.UniqueID;
			_dayReceived = message.DayReceived;
			_isNew = message.IsNew;
			_quest = message.Quest;
		}

		public bool TryRestore(out RadioMessage radioMessage)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<RadioMessageProperties>(_propertiesIndex, out var reference))
			{
				if (ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, _senderID))
				{
					radioMessage = new RadioMessage(reference, actorDescriptor);
				}
				else
				{
					Debug.LogException(new Exception($"Unable to restore RadioMessage sender for RadioMessage '{reference}'!"));
					radioMessage = new RadioMessage(reference);
				}
				radioMessage.DayReceived = _dayReceived;
				radioMessage.IsNew = _isNew;
				radioMessage.Quest = _quest;
				return true;
			}
			radioMessage = null;
			Debug.LogException(new Exception("Unable to restore RadioMessage!"));
			return false;
		}
	}

	private DialogueTreeProperties _dialogueProperties;

	private bool _wasOption;

	public RadioMessageProperties Properties { get; }

	public AgentDescriptor Sender { get; }

	public bool IsDistressSignal { get; }

	public DialogueTreeProperties DialogueProperties => _dialogueProperties;

	public int DayReceived { get; private set; }

	public bool IsNew { get; private set; }

	public bool IsDialogueOption { get; private set; }

	public Quest Quest { get; private set; }

	public RadioMessage(RadioMessageProperties properties)
		: this(properties, properties.Sender.GetDescriptor())
	{
		_dialogueProperties = Properties.DialogueProperties;
	}

	private RadioMessage(RadioMessageProperties properties, AgentDescriptor sender)
	{
		Properties = properties;
		Sender = sender;
		DayReceived = GameManager.TimeManager.Days.Count;
		IsNew = true;
	}

	public void Trigger()
	{
		if (Properties == null)
		{
			return;
		}
		if ((bool)Properties.Quest)
		{
			Quest = StoryManager.StartQuest(Properties.Quest);
		}
		else if (!StoryManager.StartDistressSignal(Sender))
		{
			if (Properties.DialogueBranch.ValidateReference())
			{
				DialogueGameEvent.DispatchDialogueStartRequest(this);
			}
			else
			{
				OnDialogueResponse(DialogueResponseType.EndOfDialogue, null);
			}
		}
	}

	public void EvaluateOutOfRange(Vector3 townheartWorldPosition, float failDistanceX)
	{
		QuestVariableBase[] variables = Quest.Variables;
		foreach (QuestVariableBase questVariableBase in variables)
		{
			if (questVariableBase.IsReferencedByActiveObjective())
			{
				ISpawner spawner = questVariableBase.Get<ISpawner>(null);
				if (spawner == null || failDistanceX < townheartWorldPosition.x - spawner.WorldPosition.x)
				{
					Quest.SetFailed();
					break;
				}
			}
		}
	}

	public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
	{
		if (LandmarkPicker.Settings.Get(500f, 0f, Properties.Sender.Regions).SpawnDrifter(out var landmarkSpawner, Sender))
		{
			landmarkSpawner.ClearFogOfWar();
			landmarkSpawner.SetBearingFeatures(Properties.BearingFeatures);
		}
	}

	public void OnOption()
	{
		_wasOption = true;
	}

	public void OnPanelClosed()
	{
		if (_wasOption)
		{
			IsNew = false;
		}
		_wasOption = false;
		IsDialogueOption = false;
	}

	public bool IsCompleted()
	{
		if (Quest == null || !Quest.IsCompleted)
		{
			return Community.PlayerCommunity.HasActor(Sender);
		}
		return true;
	}

	public bool IsFailed()
	{
		if (Quest == null || Quest.QuestState == Quest.State.Failed || Quest.QuestState == Quest.State.Abandoned)
		{
			return !Community.PlayerCommunity.HasActor(Sender);
		}
		return false;
	}

	public bool TryGetReceivingDialogue(out DialogueBranchReference dialogue)
	{
		if (IsNew && Properties.TryGetReceivingDialogue(out dialogue))
		{
			IsDialogueOption = true;
			return true;
		}
		dialogue = default(DialogueBranchReference);
		return false;
	}

	public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
	{
		entryPoint = null;
		if ((bool)Properties)
		{
			return Properties.DialogueBranch.TryGetReference(out entryPoint);
		}
		return false;
	}

	public bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
	{
		mainSpeaker = Sender;
		return true;
	}

	public static PersistentData GetPersistentData(RadioMessage radioMessage)
	{
		if (radioMessage == null)
		{
			return null;
		}
		return new PersistentData(radioMessage);
	}
}
