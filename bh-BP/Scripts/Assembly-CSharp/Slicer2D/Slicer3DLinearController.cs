using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	public class Slicer3DLinearController : MonoBehaviour
	{
		public bool addForce;

		public float addForceAmount;

		public bool drawSlicer;

		public float lineWidth;

		public float zPosition;

		public Color slicerColor;

		private Pair2D linearPair;

		private List<Pair2D> linearEvents;

		private bool mouseDown;

		public void OnRenderObject()
		{
		}

		public void LateUpdate()
		{
		}

		private void LinearSlice(Pair2D slice)
		{
		}
	}
}
