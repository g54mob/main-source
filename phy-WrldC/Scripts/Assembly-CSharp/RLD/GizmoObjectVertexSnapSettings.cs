using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class GizmoObjectVertexSnapSettings : Settings
	{
		[SerializeField]
		private int _snapDestinationLayers = -1;

		[SerializeField]
		private bool _canSnapToGrid = true;

		[SerializeField]
		private bool _canSnapToObjectVerts = true;

		public int SnapDestinationLayers
		{
			get
			{
				return _snapDestinationLayers;
			}
			set
			{
				_snapDestinationLayers = value;
			}
		}

		public bool CanSnapToGrid
		{
			get
			{
				return _canSnapToGrid;
			}
			set
			{
				_canSnapToGrid = value;
			}
		}

		public bool CanSnapToObjectVerts
		{
			get
			{
				return _canSnapToObjectVerts;
			}
			set
			{
				_canSnapToObjectVerts = value;
			}
		}

		public bool IsLayerSnapDestination(int objectLayer)
		{
			return LayerEx.IsLayerBitSet(_snapDestinationLayers, objectLayer);
		}

		public void SetLayerSnapDestination(int objectLayer, bool isSnapDestination)
		{
			if (isSnapDestination)
			{
				_snapDestinationLayers = LayerEx.SetLayerBit(_snapDestinationLayers, objectLayer);
			}
			else
			{
				_snapDestinationLayers = LayerEx.ClearLayerBit(_snapDestinationLayers, objectLayer);
			}
		}

		public void Transfer(GizmoObjectVertexSnapSettings destination)
		{
			destination.SnapDestinationLayers = SnapDestinationLayers;
			destination.CanSnapToGrid = CanSnapToGrid;
			destination.CanSnapToObjectVerts = CanSnapToObjectVerts;
		}
	}
}
