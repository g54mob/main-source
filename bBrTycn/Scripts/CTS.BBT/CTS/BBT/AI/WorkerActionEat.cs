using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class WorkerActionEat : WorkerAction
	{
		private StationStock Station;

		private DrinkSO _bloodSO;

		public WorkerActionEat()
		{
			base.Name = GetType().Name.Remove(0, 13);
			_bloodSO = (DrinkSO)Resources.Load("Scriptables/Drinks/Blood");
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!(p_agentRef.FurnitureAssignment.CurrentAssignment is StationStock) && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<StationStock>())
			{
				return false;
			}
			if (!_bloodSO.CanBePrepared())
			{
				return false;
			}
			return true;
		}

		public override void OnStart()
		{
			if ((bool)Station && (!Station.InUse || Station.User == base.ActionAgent))
			{
				base.ActionAgent.FurnitureAssignment.StartUsing(Station);
			}
			else if (!base.ActionAgent.FurnitureAssignment.TryGetAssignment<StationStock>(out Station))
			{
				if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetInteractor<StationStock>(out Station))
				{
					base.ActionAgent.FurnitureAssignment.StartUsing(Station);
				}
				else
				{
					CancelAction("Couldn't find station");
				}
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(Station, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		public override void OnComplete()
		{
			base.OnComplete();
			base.ActionAgent.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Hunger, 1f);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
