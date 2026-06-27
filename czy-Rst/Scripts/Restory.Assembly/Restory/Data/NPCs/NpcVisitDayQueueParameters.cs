using System;
using JetBrains.Annotations;
using Restory.Data.Visits;

namespace Restory.Data.NPCs
{
	[Serializable]
	public struct NpcVisitDayQueueParameters
	{
		public bool AlreadyExistsInDayQueue;

		public VisitTimeInterval Time;

		public NpcVisit VisitType;

		[UsedImplicitly]
		private string GetVisitTypeName()
		{
			string name = VisitType.GetType().Name;
			if (VisitType is StoryNpcVisit storyNpcVisit)
			{
				return $"{name} {storyNpcVisit.VisitType}";
			}
			return name;
		}
	}
}
