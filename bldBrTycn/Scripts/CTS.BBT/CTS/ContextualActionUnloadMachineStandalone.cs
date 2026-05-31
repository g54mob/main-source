using System;
using CTS.BBT;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ContextualActionUnloadMachineStandalone : MenuContextualAction<MachineBase>
	{
		[SerializeField]
		private bool _shouldVictimPanic = true;

		public override void Setup()
		{
		}

		protected override bool CanBePerformed()
		{
			if ((bool)contextActor.Victim)
			{
				return !contextActor.Victim.ActionPlayer.HasAnyActionOfType<CustomerActionGetUnloaded>();
			}
			return false;
		}

		protected override void Execution()
		{
			contextActor.Victim.ActionPlayer.PlayInstantly(new CustomerActionGetUnloaded(contextActor, _shouldVictimPanic));
		}
	}
}
