using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	public class Slicer2DComplexController : MonoBehaviour
	{
		public Slicer2DVisuals visuals;

		public bool addForce;

		public float addForceAmount;

		private static Vector2List[] points;

		private float minVertexDistance;

		public Slicer2DInputController input;

		public Slicer2D.SliceType complexSliceType;

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		private void ComplexSlice(List<Vector2D> slice)
		{
		}
	}
}
