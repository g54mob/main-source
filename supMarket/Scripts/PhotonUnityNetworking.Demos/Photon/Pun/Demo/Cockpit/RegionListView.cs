using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.Demo.Cockpit
{
	public class RegionListView : MonoBehaviour
	{
		public RegionListCell CellPrototype;

		private Dictionary<string, RegionListCell> regionCellList;

		public void OnEnable()
		{
		}

		public void OnRegionListUpdate(List<Region> regionList)
		{
		}

		public void ResetList()
		{
		}
	}
}
