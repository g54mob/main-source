using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[CreateAssetMenu(menuName = "Flotsam/Narrative/Radio Message", order = 1)]
	public class RadioMessageProperties : PersistentProperties
	{
		private enum MessageType
		{
			Specialist = 0,
			Narrative = 1
		}

		[SerializeField]
		private MessageType _type;

		[SerializeField]
		private LocalizedString _title;

		[SerializeField]
		private LocalizedString _description;

		[SerializeField]
		private Sprite _illustration;

		[SerializeField]
		private AgentProfile _sender;

		[SerializeField]
		[Tooltip("Senders name, when this value is null the name of the pastbackground of the sender will be returned")]
		private LocalizedString _senderName;

		[SerializeField]
		[Tooltip("Senders icon, when this value is null the icon of the pastbackground of the sender will be returned")]
		private Sprite _senderIcon;

		[SerializeReference]
		[InstantiateSerializeReference]
		private IScenarioTriggerableCondition[] _conditions;

		[SerializeField]
		private QuestProperties _quest;

		[SerializeField]
		private QuestProperties[] _relatedQuests;

		[SerializeField]
		[ConditionalHide("_quest", true, true)]
		private DialogueTreeProperties _dialogueProperties;

		[SerializeField]
		[ConditionalHide("_quest", true, InverseCondition1 = true, ConditionalSourceField2 = "_dialogueProperties", InverseCondition2 = false)]
		private DialogueBranchReference _dialogueBranch;

		[SerializeField]
		[ConditionalHide("_quest", true, true)]
		private BearingFeatures _bearingFeatures;

		[Header("Receiving Dialogue")]
		[SerializeField]
		private bool _overrideReceivingDialogue;

		[SerializeField]
		[ConditionalHide("_overrideReceivingDialogue", HideInInspector = true)]
		private DialogueBranchReference _receivingDialogue;

		public override Types Type => Types.RadioMessage;

		public LocalizedString Title => _title;

		public LocalizedString Description => _description;

		public Sprite Illustration => _illustration;

		public AgentProfile Sender => _sender;

		public QuestProperties Quest => _quest;

		public DialogueTreeProperties DialogueProperties => _dialogueProperties;

		public DialogueBranchReference DialogueBranch => _dialogueBranch;

		public BearingFeatures BearingFeatures => _bearingFeatures;

		public bool IsRadioMessage => true;

		public bool AreConditionsMet()
		{
			if (_conditions.IsNullOrEmpty())
			{
				return true;
			}
			IScenarioTriggerableCondition[] conditions = _conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				if (!conditions[i].IsMet())
				{
					return false;
				}
			}
			return true;
		}

		public bool IsAvailable()
		{
			switch (_type)
			{
			case MessageType.Specialist:
				if (!Community.PlayerCommunity.HasActor(_sender) && !HasActiveQuest())
				{
					return AreConditionsMet();
				}
				return false;
			case MessageType.Narrative:
				if (!StoryManager.IsQuestActiveOrCompleted(_quest))
				{
					return AreConditionsMet();
				}
				return false;
			default:
				Debug.LogException(new NotImplementedException());
				return false;
			}
		}

		private bool HasActiveQuest()
		{
			StoryManager storyManager = GameManager.StoryManager;
			if ((bool)storyManager)
			{
				if (storyManager.IsActiveQuest(_quest))
				{
					return true;
				}
				if (_relatedQuests.IsNullOrEmpty())
				{
					return false;
				}
				QuestProperties[] relatedQuests = _relatedQuests;
				foreach (QuestProperties questProperties in relatedQuests)
				{
					if (storyManager.IsActiveQuest(questProperties))
					{
						return true;
					}
				}
			}
			return false;
		}

		public string GetSenderName()
		{
			if (!_senderName.mTerm.IsNullOrEmpty())
			{
				return _senderName;
			}
			if ((bool)_sender && (bool)_sender.PastBackground)
			{
				return _sender.PastBackground.Name;
			}
			return string.Empty;
		}

		public Sprite GetSenderIcon()
		{
			if ((bool)_senderIcon)
			{
				return _senderIcon;
			}
			if ((bool)_sender && (bool)_sender.PastBackground)
			{
				return _sender.PastBackground.IconProperties.Sprite;
			}
			return null;
		}

		public bool TryGetReceivingDialogue(out DialogueBranchReference dialogue)
		{
			if (_overrideReceivingDialogue)
			{
				dialogue = _receivingDialogue;
				return true;
			}
			dialogue = default(DialogueBranchReference);
			return false;
		}
	}
}
