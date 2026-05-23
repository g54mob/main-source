using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Multi Condition", fileName = "MultiCondition", order = 0)]
	public class MultiConditionSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[Header("REQUIRE BOTH:ANDs and ORs need to both be true. Else it is either.")]
		[SerializeField]
		private bool requireBOTH;

		[SerializeField]
		private List<AbstractSubQuestValidatorSO> _AND_validator;

		[SerializeField]
		private List<AbstractSubQuestValidatorSO> _OR_validator;

		public override bool IsValid()
		{
			bool flag = EvaluateANDs();
			bool flag2 = EvaluateORs();
			if (!requireBOTH)
			{
				return flag || flag2;
			}
			return flag && flag2;
		}

		private bool EvaluateORs()
		{
			foreach (AbstractSubQuestValidatorSO item in _OR_validator)
			{
				if (item.IsValid())
				{
					return true;
				}
			}
			return false;
		}

		private bool EvaluateANDs()
		{
			if (_AND_validator.Count == 0)
			{
				return false;
			}
			foreach (AbstractSubQuestValidatorSO item in _AND_validator)
			{
				if (!item.IsValid())
				{
					return false;
				}
			}
			return true;
		}

		public override void Reset()
		{
			foreach (AbstractSubQuestValidatorSO item in _AND_validator)
			{
				item.Reset();
			}
			foreach (AbstractSubQuestValidatorSO item2 in _OR_validator)
			{
				item2.Reset();
			}
		}

		public override float GetProgress()
		{
			int num = _AND_validator.Count((AbstractSubQuestValidatorSO v) => v.IsValid());
			int num2 = _OR_validator.Count((AbstractSubQuestValidatorSO v) => v.IsValid());
			return num + num2;
		}

		public override float GetProgressTarget()
		{
			return _AND_validator.Count + _OR_validator.Count;
		}
	}
}
