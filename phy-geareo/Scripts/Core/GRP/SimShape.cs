using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public abstract class SimShape : MonoBehaviour
	{
		public bool hasShape;

		public float density;

		public PhysicsMaterial material;

		public HashSet<SimShape> connections;

		public PartSim part { get; private set; }

		public Cluster cluster { get; set; }

		public ClusterItem clusterItem { get; set; }

		public bool isStatic => false;

		public void Setup(PartSim part)
		{
		}

		public void AddConnection(SimShape shape)
		{
		}

		public void SetMaterial(MaterialRowConfig mat)
		{
		}

		public List<SimShape> GetGroup()
		{
			return null;
		}

		private static void _GetGroup(SimShape shape, List<SimShape> res)
		{
		}

		public virtual Collider GetShapeCollider()
		{
			return null;
		}

		public abstract float GetVolume();

		public virtual Vector3 GetCenter()
		{
			return default(Vector3);
		}
	}
}
