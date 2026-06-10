using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Manager;
using NSMedieval.Tools;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval
{
	public sealed class TrebuchetInputListener : InputListener
	{
		private SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		private Vector3 mousePosition = Vector3.zero;

		private Vector3 targetPos = Vector3.zero;

		private int raycastMask = -1;

		public TrebuchetInputListener()
			: base(InputListenerType.Trebuchet)
		{
			raycastMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("Water")) | (1 << LayerMask.NameToLayer("BuildingWalkable")) | (1 << LayerMask.NameToLayer("RaycastPlaneHelper")) | (1 << LayerMask.NameToLayer("VoxelMapPathfinding")) | (1 << LayerMask.NameToLayer("BuildableSurface"));
		}

		public override void Dispose()
		{
			base.Dispose();
			siegeWeaponComponentInstance = null;
		}

		public override void Enable()
		{
			BaseBuildingViewComponent baseBuildingViewComponent = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.FirstOrDefault((SelectableObject item) => item is BaseBuildingViewComponent) as BaseBuildingViewComponent;
			if (baseBuildingViewComponent != null)
			{
				siegeWeaponComponentInstance = baseBuildingViewComponent.BaseBuildingInstance.GetComponentInstance<SiegeWeaponComponentInstance>();
			}
			base.Enable();
		}

		public override void Disable()
		{
			siegeWeaponComponentInstance = null;
			base.Disable();
		}

		public override void Update()
		{
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = this.siegeWeaponComponentInstance;
			if (siegeWeaponComponentInstance == null || !siegeWeaponComponentInstance.IsPlayerTargeting)
			{
				base.Update();
				return;
			}
			RaycastUtils.RaycastMouseToSurface(out var position, raycastMask);
			Vector3 normalized = (position - this.siegeWeaponComponentInstance.ProjectileLaunchPosition).normalized;
			mousePosition = position;
			targetPos = position + new Vector3(normalized.x, 0f, normalized.z);
			this.siegeWeaponComponentInstance.UpdateCrosshair(mousePosition);
			base.Update();
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			switch (button)
			{
			case 0:
				if (siegeWeaponComponentInstance == null)
				{
					Disable();
				}
				else if (!siegeWeaponComponentInstance.IsTargetOutOfRange(mousePosition))
				{
					siegeWeaponComponentInstance?.MouseLeftClick(targetPos);
					Disable();
				}
				break;
			case 1:
				if (siegeWeaponComponentInstance == null)
				{
					Disable();
					break;
				}
				siegeWeaponComponentInstance?.MouseRightClick();
				Disable();
				break;
			}
			base.MouseButtonDown(button, position);
		}

		public override bool IsStopEventPropagation()
		{
			return true;
		}
	}
}
