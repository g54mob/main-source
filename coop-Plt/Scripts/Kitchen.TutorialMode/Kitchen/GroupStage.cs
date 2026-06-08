using System;

namespace Kitchen
{
	public class GroupStage : TutorialCondition
	{
		public Type Stage;

		public GroupStage(Type type)
		{
			Stage = type;
		}
	}
}
