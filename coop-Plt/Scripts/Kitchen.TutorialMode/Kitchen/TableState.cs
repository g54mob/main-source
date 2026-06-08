using System;

namespace Kitchen
{
	public class TableState : TutorialCondition
	{
		public Type State;

		public TableState(Type type)
		{
			State = type;
		}
	}
}
