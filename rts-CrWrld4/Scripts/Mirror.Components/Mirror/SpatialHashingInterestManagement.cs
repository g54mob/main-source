using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public class SpatialHashingInterestManagement : InterestManagement
	{
		public enum CheckMethod
		{
			XZ_FOR_3D = 0,
			XY_FOR_2D = 1
		}

		public int visRange;

		public float rebuildInterval;

		private double lastRebuildTime;

		public CheckMethod checkMethod;

		public bool showSlider;

		private Grid2D<NetworkConnection> grid;

		public int resolution => 0;

		private Vector2Int ProjectToGrid(Vector3 position)
		{
			return default(Vector2Int);
		}

		public override bool OnCheckObserver(NetworkIdentity identity, NetworkConnection newObserver)
		{
			return false;
		}

		public override void OnRebuildObservers(NetworkIdentity identity, HashSet<NetworkConnection> newObservers, bool initialize)
		{
		}

		internal void Update()
		{
		}

		private void OnGUI()
		{
		}
	}
}
