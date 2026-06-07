using System;
using System.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.PlanetStudio.Flyouts;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.PlanetObjects
{
	public class StructureObject : SurfaceObject
	{
		private PlanetDataScript _body;

		private RadialFlatten _radialFlatten;

		private StructureNodeData _structureNode;

		public override AltitudeType AltitudeType => AltitudeType.AboveGroundLevel;

		public override bool Collapsed
		{
			get
			{
				return _structureNode.Collapsed;
			}
			set
			{
				_structureNode.Collapsed = value;
			}
		}

		public StructureNodeData Data => _structureNode;

		public override double Elevation
		{
			get
			{
				return _structureNode.Elevation;
			}
			set
			{
				_structureNode.Elevation = value;
			}
		}

		public override double Heading
		{
			get
			{
				return _structureNode.Heading;
			}
			set
			{
				_structureNode.Heading = value;
			}
		}

		public override string Icon => "icon-structure";

		public override double Latitude
		{
			get
			{
				return _structureNode.Latitude;
			}
			set
			{
				_structureNode.Latitude = value;
				UpdateRadialFlattenPosition();
			}
		}

		public override double Longitude
		{
			get
			{
				return _structureNode.Longitude;
			}
			set
			{
				_structureNode.Longitude = value;
				UpdateRadialFlattenPosition();
			}
		}

		public override string Name
		{
			get
			{
				return _structureNode.Name;
			}
			set
			{
				_structureNode.Name = value;
			}
		}

		public override string TypeName => "Structure";

		public bool VisibleInMapView
		{
			get
			{
				return _structureNode.VisibleInMapView;
			}
			set
			{
				_structureNode.VisibleInMapView = value;
			}
		}

		public StructureObject(StructureNodeData structureNode, PlanetObjectsFlyoutScript flyout)
			: base(flyout)
		{
			_structureNode = structureNode;
			_body = base.Flyout.Designer.CurrentCelestialBody;
			_radialFlatten = flyout.Designer.CurrentCelestialBody.TerrainData.Modifiers.Where(delegate(PlanetModifier x)
			{
				Guid? guid = (x as RadialFlatten)?.StructureNodeId;
				Guid id = _structureNode.Id;
				if (!guid.HasValue)
				{
					return false;
				}
				return !guid.HasValue || guid.GetValueOrDefault() == id;
			}).FirstOrDefault() as RadialFlatten;
		}

		public override void Delete(PlanetDataScript planetData, CelestialBodyViewerScript viewer)
		{
			planetData.StructureNodes.Remove(_structureNode);
			StructureNode structureNode = (from x in viewer.PlanetScript.PlanetNode.DynamicNodes
				select x as StructureNode into x
				where x?.Data == _structureNode
				select x).FirstOrDefault();
			if (structureNode != null)
			{
				viewer.PlanetScript.PlanetNode.RemoveChildNode(structureNode);
				if (structureNode.GameViewObject != null)
				{
					viewer.RemoveGameViewObject(structureNode.GameViewObject, flightEnd: false);
				}
			}
			else
			{
				Debug.LogFormat("Could not find game view object");
			}
			if (_radialFlatten != null)
			{
				DeleteRadialFlattenModifier();
				base.Flyout.Designer.RaiseCelestialBodyModifiedEvent();
			}
		}

		public void FixNegativeBoxColliderScales()
		{
			StructureNode structureNodeFromViewer = GetStructureNodeFromViewer(base.Flyout.CelestialBodyViewer);
			if (structureNodeFromViewer?.GameObject != null)
			{
				StructureNode.FixNegativeBoxColliderScales(structureNodeFromViewer.GameObject);
			}
		}

		public override void GenerateModel(InspectorModel model, Action refreshUI)
		{
			base.GenerateModel(model, refreshUI);
			GroupModel groupModel = model.AddGroup(new GroupModel("Level of Detail"));
			groupModel.Add(new NumericInputModel("Load Distance", () => Data.GameViewLoadDistance, delegate(double x)
			{
				Data.GameViewLoadDistance = x;
				GetStructureNodeFromViewer(base.Flyout.CelestialBodyViewer)?.ResetLevelOfDetail();
			})).Tooltip = "The distance in meters from the player that the structure should be loaded during flight.";
			groupModel.Add(new TextModel("Current LOD", delegate
			{
				StructureNode structureNodeFromViewer = GetStructureNodeFromViewer(base.Flyout.CelestialBodyViewer);
				return (structureNodeFromViewer != null && structureNodeFromViewer.IsLoadedInGameView) ? structureNodeFromViewer.CurrentLod.ToString() : "Not Loaded";
			}));
			for (int num = 0; num < Data.LodDistanceScalars.Length; num++)
			{
				int i = num;
				groupModel.Add(new NumericInputModel($"LOD {i + 1} - Distance", () => Data.LodDistanceScalars[i], delegate(double x)
				{
					Data.LodDistanceScalars[i] = x;
					RefreshLevelOfDetail();
				}, 0.0, 1.0)).Tooltip = "This number is multiplied by Load Distance to calculate the distance from the player that the structure should load sub-structures with this LOD (or lower).";
			}
			TableRowModel tableRowModel = new TableRowModel();
			groupModel.Add(tableRowModel);
			tableRowModel.Add(new TextButtonModel("Add", delegate
			{
				double[] array = new double[Data.LodDistanceScalars.Length + 1];
				for (int j = 0; j < Data.LodDistanceScalars.Length; j++)
				{
					array[j] = Data.LodDistanceScalars[j];
				}
				Data.LodDistanceScalars = array;
				refreshUI();
			}));
			tableRowModel.Add(new TextButtonModel("Remove", delegate
			{
				double[] lodDistanceScalars = Data.LodDistanceScalars;
				if (lodDistanceScalars != null && lodDistanceScalars.Length != 0)
				{
					double[] array = new double[Data.LodDistanceScalars.Length - 1];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = Data.LodDistanceScalars[j];
					}
					Data.LodDistanceScalars = array;
					refreshUI();
				}
			}));
			model.Add(new ToggleModel("Visible in Map View", () => VisibleInMapView, delegate(bool x)
			{
				VisibleInMapView = x;
			}, "Determines whether or not this structure will be visible and targetable in map view."));
			model.Add(new ToggleModel("Flatten Terrain", () => _radialFlatten != null, delegate
			{
				if (_radialFlatten == null)
				{
					CreateRadialFlattenModifier();
				}
				else
				{
					DeleteRadialFlattenModifier();
					base.Flyout.Designer.RaiseCelestialBodyModifiedEvent();
				}
			}, "When enabled, the terrain will be flattened around the structure."));
			NumericInputModel numericInputModel = model.Add(new NumericInputModel("Elevation (ASL)", () => _radialFlatten?.Elevation ?? 0.0, delegate(double x)
			{
				_radialFlatten.Elevation = x;
			}));
			numericInputModel.DetermineVisibility = () => _radialFlatten != null;
			numericInputModel.Tooltip = "The height above sea level, in meters, to which the terrain should be flattened.";
			NumericInputModel numericInputModel2 = model.Add(new NumericInputModel("Inner Radius", () => _radialFlatten?.InnerRadius ?? 0.0, delegate(double x)
			{
				_radialFlatten.InnerRadius = x;
			}, 0.0, 10000.0));
			numericInputModel2.DetermineVisibility = () => _radialFlatten != null;
			numericInputModel2.Tooltip = "The inner radius, in meters, of the terrain to flatten. All terrain within this radius will be set to the specified elevation value. The elevation will be interpolated back to non-flattened terrain from the inner radius to the outer radius.";
			NumericInputModel numericInputModel3 = model.Add(new NumericInputModel("Outer Radius", () => _radialFlatten?.OuterRadius ?? 0.0, delegate(double x)
			{
				_radialFlatten.OuterRadius = x;
			}, 0.0, 10000.0));
			numericInputModel3.DetermineVisibility = () => _radialFlatten != null;
			numericInputModel3.Tooltip = "The outer radius, in meters, of the terrain to flatten. All terrain beyond this radius will not be impacted by this modifier. The elevation will be interpolated from flattened terrain to non-flattened terrain from the inner radius to the outer radius.";
		}

		public override bool OnReceiveDropInTreeView(IPlanetObject planetObject, IPlanetObject insertBefore)
		{
			StructureNode structureNodeFromViewer = GetStructureNodeFromViewer(base.Flyout.CelestialBodyViewer);
			return SubStructureObject.HandleDropSubStructureInTreeView(_structureNode, structureNodeFromViewer.GameViewObject?.GameObject?.transform, planetObject, insertBefore, base.Flyout);
		}

		public void RecreateGameObjects()
		{
			StructureNode structureNodeFromViewer = GetStructureNodeFromViewer(base.Flyout.CelestialBodyViewer);
			if (structureNodeFromViewer != null && structureNodeFromViewer.IsLoadedInGameView)
			{
				structureNodeFromViewer.CreateGameObjects();
			}
		}

		public void RefreshLevelOfDetail()
		{
			StructureNode structureNodeFromViewer = GetStructureNodeFromViewer(base.Flyout.CelestialBodyViewer);
			if (structureNodeFromViewer != null && structureNodeFromViewer.IsLoadedInGameView)
			{
				structureNodeFromViewer.ResetLevelOfDetail();
			}
		}

		public override void UpdateGameViewObject(CelestialBodyViewerScript viewer)
		{
			StructureNode structureNodeFromViewer = GetStructureNodeFromViewer(viewer);
			if (structureNodeFromViewer != null)
			{
				structureNodeFromViewer.OnPositionChanged();
			}
			else
			{
				Debug.LogFormat("Could not find game view object");
			}
		}

		private void CreateRadialFlattenModifier()
		{
			GameObject gameObject = new GameObject("RadialFlatten");
			gameObject.transform.SetParent(_body.TerrainData.HeightFinalPass, worldPositionStays: false);
			_radialFlatten = gameObject.AddComponent<RadialFlatten>();
			_radialFlatten.Name = "Structure Radial Flatten";
			_radialFlatten.StructureNodeId = _structureNode.Id;
			_radialFlatten.OuterRadius = 5000.0;
			_radialFlatten.InnerRadius = 1200.0;
			_radialFlatten.SetPass(VertexDataPlanetModifierPassType.HeightFinal, null);
			_body.TerrainData.Modifiers.Add(_radialFlatten);
			UpdateRadialFlattenPosition();
		}

		private void DeleteRadialFlattenModifier()
		{
			_body.TerrainData.Modifiers.Remove(_radialFlatten);
			UnityEngine.Object.DestroyImmediate(_radialFlatten.gameObject);
			_radialFlatten = null;
		}

		private StructureNode GetStructureNodeFromViewer(CelestialBodyViewerScript viewer)
		{
			return (from x in viewer.PlanetScript.PlanetNode.DynamicNodes
				select x as StructureNode into x
				where x?.Data == _structureNode
				select x).FirstOrDefault();
		}

		private void UpdateRadialFlattenPosition()
		{
			if (_radialFlatten != null)
			{
				Vector3d surfacePosition = base.Flyout.CelestialBodyViewer.PlanetScript.PlanetNode.GetSurfacePosition(_structureNode.Latitude * 0.01745329, _structureNode.Longitude * 0.01745329, AltitudeType.AboveSeaLevel, 0.0);
				_radialFlatten.Elevation = base.Flyout.CelestialBodyViewer.PlanetScript.PlanetNode.TerrainGenerator.GetHeight(surfacePosition.normalized);
				_radialFlatten.Latlong = new Vector2d(_structureNode.Latitude, _structureNode.Longitude);
				base.Flyout.Designer.RaiseCelestialBodyModifiedEvent();
			}
		}
	}
}
