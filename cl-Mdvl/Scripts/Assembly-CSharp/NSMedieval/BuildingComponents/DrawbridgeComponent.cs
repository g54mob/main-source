using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(DoorComponent))]
	public class DrawbridgeComponent : MonoBehaviour
	{
		[SerializeField]
		private DoorComponent doorComponent;

		[SerializeField]
		private List<Vec3Int> drawbridgePositions = new List<Vec3Int>();

		[SerializeField]
		private DoorComponentInstance doorComponentInstance;

		[SerializeField]
		public GameObject drawbridgeWalkable;

		[SerializeField]
		private BoxCollider drawbridgeWalkableCollider;

		[SerializeField]
		private BoxCollider drawbridgeSelectableCollider;

		[SerializeField]
		private BoxCollider drawbridgeCombatCoverCollider;

		public List<Vec3Int> DrawbridgePositions => drawbridgePositions;

		public DoorComponent DoorComponent => doorComponent;

		private void Start()
		{
			doorComponent.DoorEnteredFinishedStateEvent += OnDoorEnteredFinishedState;
			drawbridgeWalkableCollider.enabled = false;
			drawbridgeSelectableCollider.enabled = false;
			drawbridgeCombatCoverCollider.enabled = false;
		}

		private void OnDoorEnteredFinishedState(bool afterLoading)
		{
			doorComponentInstance = doorComponent.ComponentInstance;
			CacheDrawbridgeOpenAreaPositions();
			doorComponentInstance.DisposeComponentsEvent += OnDisposeComponents;
			LockState lockState = doorComponentInstance.LockState;
			if (lockState == LockState.AlwaysOpen || lockState == LockState.ForcedOpen)
			{
				ActivateDrawbridgeWalkability();
			}
			drawbridgeWalkableCollider.enabled = true;
			drawbridgeSelectableCollider.enabled = true;
			drawbridgeCombatCoverCollider.enabled = true;
			BoxColliderSettings obj = doorComponent.ComponentInstance?.Blueprint?.BoxColliderSettings;
			obj?.ApplyToBoxCollider(drawbridgeWalkableCollider);
			obj?.ApplyToBoxCollider(drawbridgeSelectableCollider);
			obj?.ApplyToBoxCollider(drawbridgeCombatCoverCollider);
			doorComponentInstance.DrawbridgeClosingCanceledEvent += OnDrawbridgeClosingCanceled;
		}

		private void OnDisposeComponents(IDisposable disposable)
		{
			DeactivateDrawbridgeWalkability();
			drawbridgePositions.Clear();
			drawbridgeWalkableCollider.enabled = false;
			drawbridgeSelectableCollider.enabled = false;
			drawbridgeCombatCoverCollider.enabled = false;
		}

		public void DrawbridgeOpened()
		{
			ActivateDrawbridgeWalkability();
		}

		public void DrawbridgeClosingDisableTraversable()
		{
			DeactivateDrawbridgeWalkability();
		}

		private void OnDrawbridgeClosingCanceled()
		{
			ActivateDrawbridgeWalkability();
		}

		private void ActivateDrawbridgeWalkability()
		{
			if (LoadingController.IsLeavingMainScene || LoadingController.IsSceneTransition || MonoSingleton<LoadingController>.IsApplicationIsQuitting())
			{
				return;
			}
			drawbridgeWalkableCollider.enabled = true;
			foreach (Vec3Int drawbridgePosition in drawbridgePositions)
			{
				doorComponentInstance.Map.GetNode(drawbridgePosition).AddDrawbridge(doorComponent.ComponentInstance.OwnerBuilding);
			}
		}

		private void DeactivateDrawbridgeWalkability()
		{
			if (LoadingController.IsLeavingMainScene || LoadingController.IsSceneTransition || MonoSingleton<LoadingController>.IsApplicationIsQuitting())
			{
				return;
			}
			drawbridgeWalkableCollider.enabled = false;
			foreach (Vec3Int drawbridgePosition in drawbridgePositions)
			{
				doorComponentInstance.Map.GetNode(drawbridgePosition).RemoveDrawbridge(doorComponent.ComponentInstance.OwnerBuilding);
			}
		}

		private void CacheDrawbridgeOpenAreaPositions()
		{
			int num;
			for (num = Mathf.Abs((int)doorComponentInstance.Angle); num >= 360; num -= 360)
			{
			}
			Vec3Int gridPosition = doorComponentInstance.GridPosition;
			int x = doorComponentInstance.OwnerBuilding.Blueprint.Size.x;
			int num2 = doorComponentInstance.OwnerBuilding.Blueprint.Size.y * World.MapBlockHeight;
			switch (num)
			{
			case 0:
			{
				for (int k = gridPosition.x; k < gridPosition.x + x; k++)
				{
					for (int l = gridPosition.z + 1; l <= gridPosition.z + num2; l++)
					{
						Vec3Int item4 = new Vec3Int(k, gridPosition.y, l);
						drawbridgePositions.Add(item4);
					}
				}
				break;
			}
			case 180:
			{
				for (int num4 = gridPosition.x; num4 > gridPosition.x - x; num4--)
				{
					for (int num5 = gridPosition.z - 1; num5 >= gridPosition.z - num2; num5--)
					{
						Vec3Int item2 = new Vec3Int(num4, gridPosition.y, num5);
						drawbridgePositions.Add(item2);
					}
				}
				break;
			}
			case 90:
			{
				for (int j = gridPosition.x + 1; j <= gridPosition.x + num2; j++)
				{
					for (int num6 = gridPosition.z; num6 > gridPosition.z - x; num6--)
					{
						Vec3Int item3 = new Vec3Int(j, gridPosition.y, num6);
						drawbridgePositions.Add(item3);
					}
				}
				break;
			}
			case 270:
			{
				for (int num3 = gridPosition.x - 1; num3 >= gridPosition.x - num2; num3--)
				{
					for (int i = gridPosition.z; i < gridPosition.z + x; i++)
					{
						Vec3Int item = new Vec3Int(num3, gridPosition.y, i);
						drawbridgePositions.Add(item);
					}
				}
				break;
			}
			}
		}
	}
}
