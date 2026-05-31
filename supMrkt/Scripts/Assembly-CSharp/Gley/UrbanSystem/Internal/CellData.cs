using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class CellData
	{
		[SerializeField]
		private CellProperties _cellProperties;

		[SerializeField]
		private CellWaypointsData _trafficWaypointsData;

		[SerializeField]
		private CellWaypointsData _pedestrianWaypointsData;

		[SerializeField]
		private List<int> _intersectionsInCell;

		[SerializeField]
		private bool _inView;

		public CellProperties CellProperties => null;

		public CellWaypointsData TrafficWaypointsData => null;

		public CellWaypointsData PedestrianWaypointsData => null;

		public List<int> IntersectionsInCell => null;

		public bool InView
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CellData(CellProperties cellProperties, CellWaypointsData trafficWaypointsData, CellWaypointsData pedestrianWaypointsData, List<int> intersectionsInCell)
		{
		}
	}
}
