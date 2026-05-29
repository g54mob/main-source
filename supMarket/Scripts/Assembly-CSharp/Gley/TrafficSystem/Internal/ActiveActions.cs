using System.Collections.Generic;

namespace Gley.TrafficSystem.Internal
{
	internal readonly struct ActiveActions
	{
		private readonly List<DriveAction> _activeActions;

		internal List<DriveAction> CurrentActiveActions => null;

		public ActiveActions(List<DriveAction> activeActions)
		{
			_activeActions = null;
		}

		internal void Add(DriveAction newAction)
		{
		}

		internal void Remove(DriveActions actionType)
		{
		}

		internal void RemoveAll(DriveActions[] movingActions)
		{
		}

		internal void Insert(int position, DriveAction newAction)
		{
		}

		internal bool Contains(DriveActions actionType)
		{
			return false;
		}
	}
}
