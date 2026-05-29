using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(Quest))]
	public class QuestConditionToStart : MonoBehaviour
	{
		private Quest _questToLaunch;

		[SerializeField]
		private EQuestStartCondition _condition;

		[SerializeField]
		[ShowIf("_condition", EQuestStartCondition.OtherQuestSuccess)]
		private Quest _questToSucceed;

		[SerializeField]
		[ShowIf("_condition", EQuestStartCondition.Time)]
		private float _secondsToWait;

		protected bool QuestConditionMet;

		protected virtual void Awake()
		{
			_questToLaunch = GetComponent<Quest>();
		}

		protected virtual void OnEnable()
		{
			if (_condition == EQuestStartCondition.OtherQuestSuccess && (bool)_questToSucceed)
			{
				_questToSucceed.Validated += OnConditionQuestValidated;
			}
		}

		protected virtual void OnDisable()
		{
			if (_condition == EQuestStartCondition.OtherQuestSuccess && (bool)_questToSucceed)
			{
				_questToSucceed.Validated -= OnConditionQuestValidated;
			}
		}

		private IEnumerator Start()
		{
			switch (_condition)
			{
			case EQuestStartCondition.None:
				StartQuest();
				break;
			case EQuestStartCondition.Time:
				yield return new WaitForSeconds(_secondsToWait);
				StartQuest();
				break;
			}
		}

		protected void OnConditionQuestValidated()
		{
			QuestConditionMet = true;
			ConditionsCheck();
		}

		protected virtual void ConditionsCheck()
		{
			if (QuestConditionMet)
			{
				StartQuest();
			}
		}

		protected virtual void StartQuest()
		{
			OnDisable();
			_questToLaunch.StartQuest();
		}
	}
}
