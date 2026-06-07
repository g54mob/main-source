using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropWireAnchor : MonoBehaviour
	{
		public PropWire srcWire;

		public List<PropWire> propWires;

		public byte voxelType;

		public PropNode wireConnectorNode;

		public Vector3 connectPos;

		private void OnDrawGizmos()
		{
		}
	}
}
