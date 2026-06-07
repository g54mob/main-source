using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Craft;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using UnityEngine;

namespace ModApi.State.MapView
{
	public class MapViewData
	{
		public delegate void MapViewDataHandler(MapViewData source);

		public class ManeuverNodeStateConstants
		{
			public const string ChainRoot = "NodeChain";

			public const string CraftId = "craftId";

			public const string ManeuverNodes = "ManeuverNodes";
		}

		public class MapOptionsConstants
		{
			public const string MapOptions = "MapOptions";
		}

		public const string MapViewDataElementName = "MapView";

		private Func<IIocContainer> _iocGetter;

		private Dictionary<int, XElement> _maneuverNodes = new Dictionary<int, XElement>();

		public bool IsDirty { get; private set; }

		public MapItemDataSet MapItemDataSet { get; private set; }

		public XElement MapOptionsContainerElement { get; private set; }

		private XElement ManeuverNodesContainerElement { get; set; }

		private XElement MapItemsContainerElement { get; set; }

		public event MapViewDataHandler GeneratingXml;

		public MapViewData(Func<IIocContainer> iocGetter, XElement mapViewElement)
		{
			try
			{
				_iocGetter = iocGetter;
				MapOptionsContainerElement = mapViewElement?.Element("MapOptions");
				ManeuverNodesContainerElement = mapViewElement?.Element("ManeuverNodes");
				MapItemsContainerElement = mapViewElement?.Element("MapItems");
				LoadManeuverNodeData(ManeuverNodesContainerElement);
				LoadNodeData(MapItemsContainerElement);
			}
			catch (Exception ex)
			{
				Debug.LogError("An error occurred while trying to restore MapView data: " + ex.Message);
			}
		}

		public XElement GenerateXml()
		{
			this.GeneratingXml?.Invoke(this);
			XElement xElement = new XElement("MapView");
			if (!IsDirty)
			{
				xElement.Add(MapOptionsContainerElement);
				xElement.Add(ManeuverNodesContainerElement);
				xElement.Add(MapItemsContainerElement);
			}
			else
			{
				xElement.Add(GenerateXmlForMapOptions());
				xElement.Add(GenerateXmlForManeuverNodeData());
				xElement.Add(MapItemDataSet.GenerateXml());
			}
			return xElement;
		}

		public XElement GetManeuverNodesElement(ICraftNode craftNode)
		{
			int nodeId = craftNode.NodeId;
			if (_maneuverNodes.ContainsKey(nodeId))
			{
				return _maneuverNodes[nodeId];
			}
			return null;
		}

		public void RemoveManeuverNodesNotIn(IEnumerable<int> nodeIdsToKeep)
		{
			foreach (int item in _maneuverNodes.Keys.ToList().Except(nodeIdsToKeep))
			{
				_maneuverNodes.Remove(item);
			}
		}

		public void SetDirty()
		{
			IsDirty = true;
			ManeuverNodesContainerElement = null;
			MapItemsContainerElement = null;
		}

		public void UpdateManeuverNodeData(ICraftNode craftNode, XElement maneuverNodeData)
		{
			if (_maneuverNodes.ContainsKey(craftNode.NodeId))
			{
				_maneuverNodes[craftNode.NodeId] = maneuverNodeData;
			}
			else
			{
				_maneuverNodes.Add(craftNode.NodeId, maneuverNodeData);
			}
		}

		private XElement GenerateXmlForManeuverNodeData()
		{
			return new XElement("ManeuverNodes", _maneuverNodes.Values);
		}

		private XElement GenerateXmlForMapOptions()
		{
			return _iocGetter().Resolve<IMapOptions>().GenerateXml();
		}

		private void LoadManeuverNodeData(XElement maneuverNodesContainerElement)
		{
			if (maneuverNodesContainerElement == null)
			{
				return;
			}
			foreach (XElement item in maneuverNodesContainerElement.Elements("NodeChain"))
			{
				try
				{
					_maneuverNodes.Add(int.Parse(item.Attribute("craftId").Value), item);
				}
				catch (Exception ex)
				{
					Debug.LogError("An error occurred while trying to restore a maneuver node's data: " + ex.Message);
				}
			}
		}

		private void LoadNodeData(XElement mapItemsContainerElement)
		{
			try
			{
				MapItemDataSet = new MapItemDataSet(mapItemsContainerElement);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Debug.LogError("An error occurred while trying to restore a map node state data: " + ex.Message);
			}
		}
	}
}
