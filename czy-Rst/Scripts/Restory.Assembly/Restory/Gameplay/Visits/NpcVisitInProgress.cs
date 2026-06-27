using Restory.Data.Visits;

namespace Restory.Gameplay.Visits
{
	public class NpcVisitInProgress
	{
		public NpcVisit Visit { get; private set; }

		public bool DidInteractionHappen { get; private set; }

		public bool IsVisitImmediate { get; private set; }

		public void SetNewVisit(NpcVisit visit, bool isVisitImmediate = false)
		{
			Visit = visit;
			DidInteractionHappen = false;
			IsVisitImmediate = isVisitImmediate;
		}

		public void ProcessInteractionBetweenPlayerAndNpc()
		{
			DidInteractionHappen = true;
		}

		public void Clear()
		{
			Visit = null;
			DidInteractionHappen = false;
		}
	}
}
