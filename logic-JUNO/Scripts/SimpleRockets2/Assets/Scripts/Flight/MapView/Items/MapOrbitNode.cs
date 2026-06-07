using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.State.MapView;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapOrbitNode : MapItem
	{
		private ICameraFocusable _associatedPlanetCameraFocusable;

		private IItemRegistry _itemRegistry;

		public override ICameraFocusable AssociatedPlanetCameraFocusable => _associatedPlanetCameraFocusable;

		public MapItemData Data { get; private set; }

		protected MapOrbitLine OrbitLine { get; private set; }

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (OrbitLine != null)
			{
				OrbitLine.Destroy();
			}
			Data?.Destroy();
		}

		protected override void OnMapItemInitialized()
		{
			base.OnMapItemInitialized();
			IMapStateProvider mapStateProvider = base.Ioc.Resolve<IMapStateProvider>(base.MapViewContext);
			Data = mapStateProvider.Data.MapItemDataSet.GetItem(base.OrbitInfo.OrbitNode, createIfNecessary: true);
			if (Data.Type == MapItemType.Structure)
			{
				Data.SupportsOrbitLines = false;
			}
			_itemRegistry = base.Ioc.Resolve<IItemRegistry>(base.MapViewContext);
			base.SupportsContextMenuSelection = true;
			UpdateAssociatedPlanetCameraFocusable();
			base.OrbitInfo.OrbitNode.ChangedSoI += OnChangedSoi;
		}

		protected void SetOrbitLine(MapOrbitLine orbitLine)
		{
			OrbitLine = orbitLine;
		}

		private void OnChangedSoi(IOrbitNode source)
		{
			UpdateAssociatedPlanetCameraFocusable();
		}

		private void UpdateAssociatedPlanetCameraFocusable()
		{
			IPlanetNode parent = base.OrbitInfo.OrbitNode.Parent;
			if (parent != null)
			{
				_associatedPlanetCameraFocusable = _itemRegistry.GetPlanet(parent);
			}
			else
			{
				_associatedPlanetCameraFocusable = _itemRegistry.RootPlanet;
			}
		}
	}
}
