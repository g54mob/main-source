using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class DealDoorDamageComponent : MonoBehaviour
	{
		[SerializeField]
		private DoorComponent doorComponent;

		[SerializeField]
		private DrawbridgeComponent drawbridgeComponent;

		[NonSerialized]
		private bool idleOpenTriggered;

		private void OnIdleOpened()
		{
			if (!idleOpenTriggered)
			{
				idleOpenTriggered = true;
				OnDealDoorDamage();
			}
		}

		public void OnDealDoorDamage()
		{
			DoorComponentInstance componentInstance = doorComponent.ComponentInstance;
			if (componentInstance == null || componentInstance.HasDisposed || componentInstance.OwnerBuilding == null || componentInstance.OwnerBuilding.HasDisposed || !componentInstance.Blueprint.DealDamageWhenClosing)
			{
				return;
			}
			if (componentInstance.Blueprint.DoorType == DoorType.Portcullis)
			{
				MonoSingleton<CombatController>.Instance.DealGateDamage(componentInstance);
			}
			else if (componentInstance.Blueprint.DoorType == DoorType.Drawbridge)
			{
				if (componentInstance.LockState != LockState.ForcedOpen)
				{
					MonoSingleton<CombatController>.Instance.DealDrawbridgeDamage(drawbridgeComponent);
				}
				drawbridgeComponent.DrawbridgeOpened();
			}
		}

		private void OnDrawbridgeClosingDisableTraversable()
		{
			idleOpenTriggered = false;
			drawbridgeComponent?.DrawbridgeClosingDisableTraversable();
		}

		private void OnDrawbridgeClosing25()
		{
			UpdateDamagePercent(0.25f);
		}

		private void OnDrawbridgeClosing50()
		{
			UpdateDamagePercent(0.5f);
		}

		private void OnDrawbridgeClosing75()
		{
			UpdateDamagePercent(0.75f);
		}

		private void OnDrawbridgeClosing100()
		{
			UpdateDamagePercent(1f);
		}

		private void UpdateDamagePercent(float damagePercent)
		{
			DoorComponentInstance componentInstance = doorComponent.ComponentInstance;
			if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.OwnerBuilding != null && !componentInstance.OwnerBuilding.HasDisposed)
			{
				componentInstance.SetDamagePercent(damagePercent);
			}
		}
	}
}
