using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Rendering;
using Timberborn.SelectionSystem;
using Timberborn.WaterBuildings;
using UnityEngine;

namespace Timberborn.WaterBuildingsUI
{
	internal class SluiceMarker : BaseComponent, IAwakableComponent, IUpdatableComponent, ISelectionListener
	{
		private static readonly Color32 MarkerColor = Color.blue;

		private static readonly float MarkerYOffset = 0.02f;

		private readonly MarkerDrawerFactory _markerDrawerFactory;

		private Sluice _sluice;

		private SluiceState _sluiceState;

		private MeshDrawer _markerDrawer;

		private BlockObject _blockObject;

		public SluiceMarker(MarkerDrawerFactory markerDrawerFactory)
		{
			_markerDrawerFactory = markerDrawerFactory;
		}

		public void Awake()
		{
			_sluice = GetComponent<Sluice>();
			_sluiceState = GetComponent<SluiceState>();
			_blockObject = GetComponent<BlockObject>();
			_markerDrawer = _markerDrawerFactory.CreateTileDrawer(MarkerColor);
			DisableComponent();
		}

		public void Update()
		{
			Vector3Int targetCoordinates = _sluice.TargetCoordinates;
			Vector3Int coordinates = new Vector3Int(targetCoordinates.x, targetCoordinates.y, _sluice.MaxHeight);
			_markerDrawer.DrawAtCoordinates(coordinates, _sluiceState.OutflowLimit + MarkerYOffset);
		}

		public void OnSelect()
		{
			if (!_blockObject.IsPreview)
			{
				EnableComponent();
			}
		}

		public void OnUnselect()
		{
			DisableComponent();
		}
	}
}
