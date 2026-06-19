using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public abstract class WaterFeatureLayerRenderer : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		protected LayerRenderer _layerRenderer;

		[HideInInspector]
		[SerializeField]
		private bool _run;

		private int runTrue;

		private int runFalse;

		[HideInInspector]
		[SerializeField]
		public bool run
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void RunThisFrame()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
