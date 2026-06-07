using System;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slice2DLayer
	{
		[SerializeField]
		private Slice2DLayerType layer;

		[SerializeField]
		private bool[] layers;

		public static Slice2DLayer Create()
		{
			return null;
		}

		public void SetLayerType(Slice2DLayerType type)
		{
		}

		public void SetLayer(int id, bool value)
		{
		}

		public void DisableLayers()
		{
		}

		public Slice2DLayerType GetLayerType()
		{
			return default(Slice2DLayerType);
		}

		public bool GetLayerState(int id)
		{
			return false;
		}
	}
}
