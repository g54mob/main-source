using System.Collections.Generic;
using NSEipix;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Removes defeated targets from the list")]
	public class ClearDefeatedTargets : CommanderAIBTActionBase
	{
		public BBParameter<List<IDamageTakingAgent>> targets;

		protected override void OnStart()
		{
			List<IDamageTakingAgent> list = targets?.value;
			if (list == null)
			{
				EndAction();
				return;
			}
			foreach (IDamageTakingAgent item in list.IterateInReverseDynamic())
			{
				if (item == null)
				{
					list.Remove(item);
					continue;
				}
				if (item is BaseBuildingInstance baseBuildingInstance)
				{
					DoorComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
					if (componentInstance != null && componentInstance.LockState != LockState.ForcedOpen)
					{
						continue;
					}
				}
				if (item.HasDisposed || item.HasDiedOrFainted)
				{
					list.Remove(item);
				}
			}
			EndAction();
		}
	}
}
