using System;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Contracts.Requirements;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Career
{
	public class LocationNode
	{
		private Action _createNode;

		private int _requests;

		private StructureNode _structureNode;

		public Color IconColor
		{
			get
			{
				return _structureNode?.MapViewIconColor ?? Color.white;
			}
			set
			{
				if (_structureNode != null)
				{
					_structureNode.MapViewIconColor = value;
				}
			}
		}

		public string Name { get; }

		public virtual IPlanetNode Parent { get; private set; }

		public virtual Vector3d Position => _structureNode.Position;

		public bool ShowInGameView
		{
			get
			{
				return _structureNode.Enabled;
			}
			set
			{
				_structureNode.Enabled = value;
			}
		}

		public string StructureTypeName { get; set; }

		public Vector3d SurfacePosition => _structureNode.SurfacePosition;

		public LocationNode(IPlanetNode parent, ContractLocation contractLocation, string icon)
		{
			LocationNode locationNode = this;
			Parent = parent;
			Name = contractLocation.Name;
			_createNode = delegate
			{
				StructureNodeData structureNodeData = contractLocation.Style switch
				{
					RaceRequirement.CheckpointStyleType.Cylinder => new StructureNodeData(locationNode.Name, "Flight/GameView/Structures/LocationCylinder"), 
					RaceRequirement.CheckpointStyleType.Ring => new StructureNodeData(locationNode.Name, "Flight/GameView/Structures/LocationRing"), 
					_ => new StructureNodeData(locationNode.Name, "Flight/GameView/Structures/LocationSphere"), 
				};
				structureNodeData.Latitude = contractLocation.LatLonAgl.x;
				structureNodeData.Longitude = contractLocation.LatLonAgl.y;
				structureNodeData.Elevation = contractLocation.LatLonAgl.z;
				structureNodeData.ElevationType = AltitudeType.AboveGroundLevel;
				structureNodeData.LocalScale = Vector3.one * Mathf.Abs((float)contractLocation.Range) * 2f;
				structureNodeData.GameViewLoadDistance = contractLocation.LoadDistance;
				structureNodeData.VisibleInMapView = contractLocation.VisibleInMapView;
				locationNode._structureNode = new StructureNode(structureNodeData, parent, icon);
				parent.AddChildNode(locationNode._structureNode);
				if (parent.IsTerrainDataLoaded)
				{
					locationNode._structureNode.OnTerrainDataLoaded();
				}
			};
		}

		public LocationNode()
		{
		}

		public double CalculateDistanceToPosition(Vector3d position)
		{
			return (Position - position).magnitude;
		}

		public virtual void Register(IFlightContext flightContext)
		{
			_requests++;
			if (_requests > 0 && _structureNode == null)
			{
				_createNode();
			}
		}

		public void SetAsTarget()
		{
			IIocContainer iocContainer = Game.Instance.FlightScene.IocContainer;
			IMapViewContext context = (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context;
			IItemRegistry itemRegistry = iocContainer.Resolve<IItemRegistry>(context);
			ITargetableItem targetableItem = null;
			if (_structureNode == null)
			{
				return;
			}
			foreach (MapItem item in itemRegistry.Items)
			{
				if ((item as MapSurfaceItem)?.Node == _structureNode)
				{
					targetableItem = item as ITargetableItem;
					break;
				}
			}
			if (targetableItem != null)
			{
				iocContainer.Resolve<INavigationTargetProvider>(context).SetNavigationTarget(targetableItem);
			}
		}

		public void Unregister()
		{
			_requests--;
			if (_requests <= 0 && _structureNode != null)
			{
				if (_structureNode.GameViewObject.IsLoadedInGameView)
				{
					Game.Instance.FlightScene.ViewManager.GameView.RemoveGameViewObject(_structureNode.GameViewObject, flightEnd: false);
				}
				_structureNode.DestroyStructure();
				_structureNode = null;
			}
		}
	}
}
