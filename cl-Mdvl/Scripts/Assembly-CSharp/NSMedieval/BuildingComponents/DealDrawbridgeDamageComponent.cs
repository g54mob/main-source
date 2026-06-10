using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(DoorComponent), typeof(DrawbridgeComponent))]
	public class DealDrawbridgeDamageComponent : MonoBehaviour
	{
		[SerializeField]
		private DoorComponent doorComponent;

		[SerializeField]
		private DrawbridgeComponent drawbridgeComponent;

		public void OnDealDoorDamage()
		{
			DoorComponentInstance componentInstance = doorComponent.ComponentInstance;
			if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.OwnerBuilding != null && !componentInstance.OwnerBuilding.HasDisposed && componentInstance.Blueprint.DealDamageWhenClosing)
			{
				MonoSingleton<CombatController>.Instance.DealGateDamage(componentInstance);
			}
		}
	}
}
