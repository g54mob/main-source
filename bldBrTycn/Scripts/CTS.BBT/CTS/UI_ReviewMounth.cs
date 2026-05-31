using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class UI_ReviewMounth : MonoBehaviour
	{
		[SerializeField]
		private UI_ReviewPanel _humanReview;

		[SerializeField]
		private UI_ReviewPanel _vampireReview;

		[SerializeField]
		private bool _isCurrentMounth;

		private void Awake()
		{
			if (_isCurrentMounth)
			{
				AgentActionTakeOrder.SatisfactionTriggered += AgentActionTakeOrder_SatisfactionTriggered;
				WorkerChoreDrinkDelivery.SatisfactionTriggered += WorkerChoreDrinkDelivery_SatisfactionTriggered;
				AgentNeedsSatisfaction.SatisfactionTriggered += AgentNeedsSatisfaction_SatisfactionTriggered;
			}
		}

		private void OnDestroy()
		{
			if (_isCurrentMounth)
			{
				AgentActionTakeOrder.SatisfactionTriggered -= AgentActionTakeOrder_SatisfactionTriggered;
				WorkerChoreDrinkDelivery.SatisfactionTriggered -= WorkerChoreDrinkDelivery_SatisfactionTriggered;
				AgentNeedsSatisfaction.SatisfactionTriggered -= AgentNeedsSatisfaction_SatisfactionTriggered;
			}
		}

		private void AgentNeedsSatisfaction_SatisfactionTriggered(StatSatisfactionEvent obj)
		{
			if (obj.Stat == EAgentStatistics.ToiletBladderStartAction)
			{
				if (obj.Agent.IsHuman)
				{
					_humanReview.AddToiletReview(obj.IsGood);
				}
				else
				{
					_vampireReview.AddToiletReview(obj.IsGood);
				}
			}
			else if (obj.Stat == EAgentStatistics.Fun)
			{
				if (obj.Agent.IsHuman)
				{
					_humanReview.AddFunReview(obj.IsGood);
				}
				else
				{
					_vampireReview.AddFunReview(obj.IsGood);
				}
			}
		}

		private void WorkerChoreDrinkDelivery_SatisfactionTriggered(SatisfactionEvent obj)
		{
			if (obj.Agent.IsHuman)
			{
				_humanReview.AddDrinkReview(obj.IsGood);
			}
			else
			{
				_vampireReview.AddDrinkReview(obj.IsGood);
			}
		}

		private void AgentActionTakeOrder_SatisfactionTriggered(SatisfactionEvent obj)
		{
			if (obj.Agent.IsHuman)
			{
				_humanReview.AddServiceReview(obj.IsGood);
			}
			else
			{
				_vampireReview.AddServiceReview(obj.IsGood);
			}
		}

		public void SetValuesFromOther(UI_ReviewMounth other)
		{
			_humanReview.SetValuesFromOther(other._humanReview);
			_vampireReview.SetValuesFromOther(other._vampireReview);
		}

		public void ClearValues()
		{
			_humanReview.ClearValues();
			_vampireReview.ClearValues();
		}

		public void LoadStruct(ReviewMounthSaveStruct save)
		{
			ClearValues();
			_humanReview.LoadStruct(save.HumanReview);
			_vampireReview.LoadStruct(save.VampireReview);
		}

		public ReviewMounthSaveStruct SaveStruct()
		{
			return new ReviewMounthSaveStruct
			{
				HumanReview = _humanReview.SaveStruct(),
				VampireReview = _vampireReview.SaveStruct()
			};
		}
	}
}
