#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Quests.SubQuestEvents;
using Data.Quests.Validators;
using Data.UI.Controls;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Data.Quests
{
	[CreateAssetMenu(menuName = "Quests/SubQuest", fileName = "SubQuest", order = 2)]
	public class SubQuestSO : ScriptableObject
	{
		[LocaKey]
		[SerializeField]
		private string _subQuestDescriptionKey;

		[Tooltip("Loca key above can reference input actions using {0}")]
		[SerializeField]
		private List<InputActionReference> _inputActionsReferences = new List<InputActionReference>();

		[ShowIf("_hasInputActions")]
		[SerializeField]
		private bool _useLongRebindAction = true;

		[ShowIf("_hasInputActions")]
		[SerializeField]
		private string _inBetween;

		[ShowIf("_hasInputActions")]
		[SerializeField]
		private SettingsRebindRuntimeInfo _settingsRebindRuntimeInfo;

		[SerializeField]
		private bool _sendGAEvent = true;

		[SerializeField]
		private bool _timedEvent;

		[SerializeField]
		private bool _hideInQuestUI;

		[Expandable]
		[SerializeField]
		private AbstractSubQuestValidatorSO _validator;

		[SerializeField]
		private bool _completesEntireQuest;

		[SerializeField]
		private List<AbstractSubQuestEventSO> _onStartSubquestEvents;

		[SerializeField]
		private List<AbstractSubQuestEventSO> _onUpdateSubquestEvents;

		[SerializeField]
		private List<AbstractSubQuestEventSO> _onCompleteSubquestEvents;

		public AbstractSubQuestValidatorSO Validator => _validator;

		public bool HideInQuestUI => _hideInQuestUI;

		public bool CompletesEntireQuest => _completesEntireQuest;

		public string SubQuestDescription => GetSubQuestDescription();

		public string LocaKey => _subQuestDescriptionKey;

		public bool SendGAEvent => _sendGAEvent;

		public bool TimedEvent => _timedEvent;

		private bool _hasInputActions => _inputActionsReferences.Count > 0;

		private string GetSubQuestDescription()
		{
			if (string.IsNullOrEmpty(_subQuestDescriptionKey))
			{
				return string.Empty;
			}
			string text = LocalizationUtility.GetLocalizedText(_subQuestDescriptionKey);
			for (int i = 0; i < _inputActionsReferences.Count; i++)
			{
				if (_settingsRebindRuntimeInfo.TryGetBindingString(_inputActionsReferences[i], out var bindingString, _useLongRebindAction, _inBetween))
				{
					text = text.Replace("{" + i + "}", bindingString);
				}
			}
			return text;
		}

		public void OnStart()
		{
			foreach (AbstractSubQuestEventSO onStartSubquestEvent in _onStartSubquestEvents)
			{
				onStartSubquestEvent?.Execute();
			}
		}

		public void OnUpdate()
		{
			foreach (AbstractSubQuestEventSO onUpdateSubquestEvent in _onUpdateSubquestEvents)
			{
				onUpdateSubquestEvent?.Execute();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void OnComplete()
		{
			foreach (AbstractSubQuestEventSO onCompleteSubquestEvent in _onCompleteSubquestEvents)
			{
				onCompleteSubquestEvent?.Execute();
			}
		}

		private void Reset()
		{
			if (_validator == null)
			{
				this.LogError("VALIDATOR CANNOT BE NULL IN " + base.name, "Reset", 100);
			}
		}
	}
}
