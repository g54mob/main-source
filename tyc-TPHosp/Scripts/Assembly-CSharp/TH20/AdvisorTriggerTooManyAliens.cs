using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerTooManyAliens : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerTooManyAliensDefinition _definition;

		public AdvisorTriggerTooManyAliens(AdvisorTriggerTooManyAliensDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.GetAliensManager().NumAliens > _definition.AlienCountThreshold)
			{
				return _definition.PriorityLevel;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
