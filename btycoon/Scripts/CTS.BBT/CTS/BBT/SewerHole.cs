using System;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	public class SewerHole : WorkerFurnitureInteractor, IBodyDisposalMachine, IManageableFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		private string _furnitureLayerName = "Furniture";

		[field: SerializeField]
		public UsableFurnituresCategoriesSO UsableFurnitureCategoryData { get; private set; }

		[field: SerializeField]
		[field: Inject(false)]
		public BodyDisposalCredibility MachineCredibility { get; private set; }

		public MachineUpgrade MachineUpgrade => null;

		public MachineBloodQuality MachineBloodQuality => null;

		public MachineTechTree MachineTechTree => null;

		public EMachineProductionMode MachineProductionMode => EMachineProductionMode.None;

		public static event Action SoldSewerHole;

		public bool CanBeUsedToDisposeBody(Agent agent, Customer customer)
		{
			return CanBeUsed(agent);
		}

		public bool CanBeUsedToDisposeBody(Agent agent, DeadBodyData deadBodyData)
		{
			return CanBeUsed(agent);
		}

		public bool CanBeUsedToDisposeBody(DeadBodyData deadBodyData)
		{
			return CanBeUsed();
		}

		public AgentAction GetAction()
		{
			return new WorkerActionSewerBodyDrop(this);
		}

		public override void OnFurnitureSold()
		{
			if (CTSSingleton<BarFurnitures>.InstanceExists())
			{
				if (!CTSSingleton<BarFurnitures>.Instance.DoesAnyExist<SewerHole>())
				{
					SewerHole.SoldSewerHole?.Invoke();
				}
				base.OnFurnitureSold();
			}
		}
	}
}
