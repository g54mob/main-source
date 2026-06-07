using System;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapStaticOrbitItem : MapOrbitNode, ITargetableItem, ICameraFocusable
	{
		private static Material _sharedMaterial;

		private CameraFocusableItemDestroyedHandler _cameraFocusableDestroyed;

		private IMapOptions _options;

		private MapOrbitLine _orbitLine;

		IPlanetNode ICameraFocusable.AssociatedPlanet => base.OrbitInfo.OrbitNode.Parent;

		string ITargetableItem.ClosestEncounterIcon => "NonPlayerCraftAlternative";

		bool ICameraFocusable.FocusByClick => true;

		ICameraFocusable ICameraFocusable.ItemToFocusOnWhenDeleted => base.ItemRegistry.GetPlanet(((ICameraFocusable)this).AssociatedPlanet);

		float ICameraFocusable.MinZoomDistance => AssociatedPlanetCameraFocusable.MinZoomDistance;

		string ITargetableItem.Name => base.OrbitInfo.OrbitNode.Name;

		IOrbitNode ICameraFocusable.OrbitNode => base.OrbitInfo.OrbitNode;

		Vector3 ICameraFocusable.Position => (Vector3)base.CoordinateConverter.ConvertSolarToMapView(base.OrbitInfo.OrbitNode.SolarPosition);

		protected override bool ShowTooltipOnHover
		{
			get
			{
				if (base.ItemIcon.enabled)
				{
					return base.UiVisibilityAtItemPosition > 0f;
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

		public static MapStaticOrbitItem Create(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode craftNode, Camera mapCamera)
		{
			Sprite distanceIcon = UiUtils.LoadIconSprite("NonPlayerCraft");
			string text = "Non-PlayerCraft";
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			return MapItem.Create<MapStaticOrbitItem>(ioc, mapViewContext, craftNode, text, objectContainerProvider.OrbitCanvases, mapCamera, objectContainerProvider.Crafts, distanceIcon);
		}

		public override void Destroy()
		{
			base.Destroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
		}

		double ITargetableItem.GetSphereOfInfluence(MapOrbitInfo other)
		{
			if (other.OrbitNode is PlanetNode)
			{
				return 0.0;
			}
			return _options.Targeting.CraftSoiDistance;
		}

		public override void OnAfterCameraPositioned()
		{
			base.OnAfterCameraPositioned();
			bool showIcons = base.Data.ShowIcons;
			if (showIcons != base.ItemIcon.enabled)
			{
				base.ItemIcon.enabled = showIcons;
			}
			if (showIcons)
			{
				UpdateIconPosition();
				UpdateTooltip();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
			if (base.OrbitInfo.OrbitNode is CraftNode)
			{
				(base.OrbitInfo.OrbitNode as CraftNode).PhysicsEnabled -= OnCraftNodePhysicsEnabled;
			}
		}

		protected override void OnMapItemInitialized()
		{
			base.OnMapItemInitialized();
			if (base.OrbitInfo.OrbitNode is CraftNode)
			{
				(base.OrbitInfo.OrbitNode as CraftNode).PhysicsEnabled += OnCraftNodePhysicsEnabled;
			}
			IIocContainer ioc = base.Ioc;
			_options = ioc.Resolve<IMapOptions>();
		}

		protected override void Start()
		{
			base.Start();
			SetOrbitLine(MapOrbitLine.Create(base.Ioc, base.MapViewContext, base.OrbitInfo.OrbitNode, base.Data, base.Color, "StaticOrbit", base.Camera, GetOrCreateMaterial(), isSharedMaterial: true));
		}

		private static Material GetOrCreateMaterial()
		{
			if (_sharedMaterial == null)
			{
				_sharedMaterial = new Material(Shader.Find("Jundroo/MapView/CraftStaticOrbitLine"));
			}
			return _sharedMaterial;
		}

		private void OnCraftNodePhysicsEnabled(ICraftNode source, PhysicsChangeReason reason)
		{
			MapItem.SwitchType<MapCraft>(this);
		}
	}
}
