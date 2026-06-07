using System;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	[Serializable]
	public class WaterReflectionOptions
	{
		[SerializeField]
		private float _clipPlaneOffset = 0.07f;

		[SerializeField]
		private float _farClipPlane = 10000000f;

		[SerializeField]
		private LayerMask _layers = 0;

		[SerializeField]
		private bool _pixelLights;

		[SerializeField]
		private int _resolution = 512;

		public float ClipPlaneOffset
		{
			get
			{
				return _clipPlaneOffset;
			}
			set
			{
				_clipPlaneOffset = value;
			}
		}

		public float FarClipPlane
		{
			get
			{
				return _farClipPlane;
			}
			set
			{
				_farClipPlane = value;
			}
		}

		public LayerMask Layers
		{
			get
			{
				return _layers;
			}
			set
			{
				_layers = value;
			}
		}

		public bool PixelLights
		{
			get
			{
				return _pixelLights;
			}
			set
			{
				_pixelLights = value;
			}
		}

		public int Resolution
		{
			get
			{
				return _resolution;
			}
			set
			{
				_resolution = value;
			}
		}
	}
}
