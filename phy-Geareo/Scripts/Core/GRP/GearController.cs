using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class GearController
	{
		public IGear gear;

		public GearConfig gearConfig;

		public Dictionary<IGear, GearConn> connections;

		public List<IGear> neighbors;

		private List<IGear> newNeighbors;

		private List<IGear> toAdd;

		private List<IGear> toRemove;

		public void Setup(IGear gear, GearConfig gearConfig)
		{
		}

		public void Scan(Collider[] collidersBuffer, int count)
		{
		}

		public void Update()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
