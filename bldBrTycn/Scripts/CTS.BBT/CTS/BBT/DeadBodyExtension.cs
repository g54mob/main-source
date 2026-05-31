using System;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS.BBT
{
	public static class DeadBodyExtension
	{
		private static readonly Func<IBodyDisposalMachine, Agent, DeadBodyData, bool> _canBodyBeDiscarded = (IBodyDisposalMachine machine, Agent agent, DeadBodyData body) => machine.MachineCredibility.Credibility >= body.Credibility && machine.CanBeUsedToDisposeBody(agent, body);

		public static Func<IBodyDisposalMachine, Agent, DeadBodyData, bool> CanBodyBeDiscarded(this DeadBodyData deadBodyData)
		{
			return _canBodyBeDiscarded;
		}

		public static bool IsInAnyBodyBag(this DeadBodyData deadBodyData)
		{
			foreach (BodyBag item in StaticObjectSet<BodyBag>.List)
			{
				if (item.BodyData == deadBodyData)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsInAnyMorgue(this DeadBodyData deadBodyData)
		{
			return (object)deadBodyData.CurrentMorgue() != null;
		}

		public static bool IsInMorgue(this DeadBodyData deadBodyData, StationMorgue morgue)
		{
			return morgue.DeadBodies.Contains(deadBodyData);
		}

		public static StationMorgue CurrentMorgue(this DeadBodyData deadBodyData)
		{
			if (!CTSSingleton<BarFurnitures>.InstanceExists())
			{
				return null;
			}
			foreach (StationMorgue item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationMorgue>())
			{
				if (item.DeadBodies.Contains(deadBodyData))
				{
					return item;
				}
			}
			return null;
		}
	}
}
