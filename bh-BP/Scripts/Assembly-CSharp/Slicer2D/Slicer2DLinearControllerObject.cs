using System;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DLinearControllerObject : Slicer2DControllerObject
	{
		private Pair2[] linearPair;

		public bool startedSlice;

		public bool endSliceIfPossible;

		public bool startSliceIfPossible;

		public bool strippedLinear;

		public float minVertexDistance;

		public bool displayCollisions;

		public bool sliceJoints;

		public bool autocomplete;

		public bool autocompleteDisplay;

		public float autocompleteDistance;

		public bool addForce;

		public float addForceAmount;

		public void Initialize()
		{
		}

		public Pair2 GetPair(int id)
		{
			return default(Pair2);
		}

		public void Update()
		{
		}

		public void Draw(Transform transform)
		{
		}

		private bool LinearSlice(Pair2D slice)
		{
			return false;
		}

		public static Vector2List GetLinearVertices(Pair2 pair, float minVertexDistance)
		{
			return default(Vector2List);
		}
	}
}
