using System.Collections.Generic;

namespace NSMedieval.State
{
	public interface ILifeLogOwner
	{
		LinkedList<LifeEventLogStruct> LifeEventLogs { get; }

		void LogLifeEvent(LifeEventLogStruct lifeEvent);
	}
}
