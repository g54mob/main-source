using System.Collections.Generic;
using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class WargameStandQueue : StandQueue
	{
		private static List<WargameStandQueue> _queues = new List<WargameStandQueue>();

		private static bool TryGetWaitingStandUser(out IStandUser user)
		{
			foreach (WargameStandQueue queue in _queues)
			{
				if (queue.GiveFirstInLine(out user))
				{
					return true;
				}
			}
			user = null;
			return false;
		}

		private void OnEnable()
		{
			Register(register: true);
		}

		private void OnDisable()
		{
			Register(register: false);
		}

		private void Register(bool register)
		{
			if (register)
			{
				_queues.Add(this);
			}
			else
			{
				_queues.Remove(this);
			}
		}

		public override bool PopFirstInLine(out IStandUser user)
		{
			if (base.PopFirstInLine(out user))
			{
				return true;
			}
			return TryGetWaitingStandUser(out user);
		}

		private bool GiveFirstInLine(out IStandUser user)
		{
			return base.PopFirstInLine(out user);
		}
	}
}
