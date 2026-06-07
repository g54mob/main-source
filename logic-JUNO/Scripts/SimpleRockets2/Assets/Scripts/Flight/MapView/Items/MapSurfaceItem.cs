using System;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapSurfaceItem : MapOrbitNode, ITargetableItem, ICameraFocusable
	{
		private CameraFocusableItemDestroyedHandler _cameraFocusableDestroyed;

		private ICurrentCameraTarget _cameraTarget;

		private IStationaryNode _node;

		private MapPlanet _parent;

		IPlanetNode ICameraFocusable.AssociatedPlanet => base.OrbitInfo.OrbitNode.Parent;

		string ITargetableItem.ClosestEncounterIcon => "NonPlayerCraftAlternative";

		bool ICameraFocusable.FocusByClick => true;

		ICameraFocusable ICameraFocusable.ItemToFocusOnWhenDeleted => base.ItemRegistry.GetPlanet(((ICameraFocusable)this).AssociatedPlanet);

		float ICameraFocusable.MinZoomDistance => AssociatedPlanetCameraFocusable.MinZoomDistance;

		string ITargetableItem.Name => base.OrbitInfo.OrbitNode.Name;

		public IStationaryNode Node => _node;

		IOrbitNode ICameraFocusable.OrbitNode => base.OrbitInfo.OrbitNode;

		Vector3 ICameraFocusable.Position => (Vector3)base.CoordinateConverter.ConvertSolarToMapView(base.OrbitInfo.OrbitNode.SolarPosition);

		public string StructureTypeName { get; private set; }

		protected override bool ShowTooltipOnHover
		{
			get
			{
				if (base.ItemIcon.enabled)
				{
					return base.ItemIcon.color.a > 0f;
				}
				return false;
			}
		}

		event CameraFocusableItemDestroyedHandler ICameraFocusable.Destroyed
		{
			add
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Combine(_cameraFocusableDestroyed, value);
			}
			remove
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Remove(_cameraFocusableDestroyed, value);
			}
		}

		public static MapSurfaceItem Create(IIocContainer ioc, IMapViewContext mapViewContext, IStationaryNode node, Camera mapCamera)
		{
			Sprite distanceIcon = UiUtils.LoadIconSprite(node.MapViewIcon);
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			StationaryMapOrbitNode node2 = new StationaryMapOrbitNode(ioc, node);
			MapSurfaceItem mapSurfaceItem = MapItem.Create<MapSurfaceItem>(ioc, mapViewContext, node2, node.Name, objectContainerProvider.OrbitCanvases, mapCamera, objectContainerProvider.Crafts, distanceIcon);
			mapSurfaceItem._node = node;
			mapSurfaceItem.StructureTypeName = node.StructureTypeName;
			return mapSurfaceItem;
		}

		public override void Destroy()
		{
			base.Destroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
		}

		double ITargetableItem.GetSphereOfInfluence(MapOrbitInfo other)
		{
			return 0.0;
		}

		public override void OnAfterCameraPositioned()
		{
			base.OnAfterCameraPositioned();
			bool flag = base.Data.ShowIcons && _cameraTarget.TargetsAssociatedPlanet == _parent;
			if (flag != base.ItemIcon.enabled)
			{
				base.ItemIcon.enabled = flag;
			}
			if (flag)
			{
				UpdateIconPosition();
				UpdateTooltip();
				Vector3 normalized = (MapPosition - _parent.MapPosition).normalized;
				Vector3 normalized2 = (MapPosition - base.Camera.transform.position).normalized;
				float num = 10000f * (MapPosition - base.Camera.transform.position).magnitude;
				num /= (float)_parent.PlanetNode.PlanetData.Radius;
				Color mapViewIconColor = _node.MapViewIconColor;
				float num2 = Vector3.Dot(normalized2, -normalized);
				float num3 = ((num2 > 0f) ? 1f : (num2 * 0.2f));
				mapViewIconColor.a *= num3 * Mathf.Clamp01(2.5f - num);
				base.ItemIcon.color = mapViewIconColor;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
		}

		protected override void OnMapItemInitialized()
		{
			base.OnMapItemInitialized();
			_cameraTarget = base.Ioc.Resolve<ICurrentCameraTarget>(base.MapViewContext);
			IItemRegistry itemRegistry = base.Ioc.Resolve<IItemRegistry>(base.MapViewContext);
			_parent = itemRegistry.GetPlanet(base.OrbitInfo.OrbitNode.Parent);
		}
	}
}
