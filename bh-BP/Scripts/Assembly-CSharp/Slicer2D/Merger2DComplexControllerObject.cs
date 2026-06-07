using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Merger2DComplexControllerObject : Slicer2DControllerObject
	{
		public Vector2List[] pointsList;

		private bool startedSlice;

		public Slicer2D.SliceType complexSliceType;

		public bool autocomplete;

		public bool autocompleteDisplay;

		public float autocompleteDistance;

		public float minVertexDistance;

		public bool endSliceIfPossible;

		public bool startSliceIfPossible;

		public void Initialize()
		{
		}

		public Vector2List GetList(int id)
		{
			return default(Vector2List);
		}

		public Vector2List GetPoints(int id)
		{
			return default(Vector2List);
		}

		public void Update()
		{
		}

		public void Draw(Transform transform)
		{
		}

		private bool ComplexMerge(List<Vector2D> slice)
		{
			return false;
		}
	}
}
