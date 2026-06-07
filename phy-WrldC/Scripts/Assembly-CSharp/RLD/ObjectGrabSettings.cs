using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectGrabSettings : Settings
	{
		[SerializeField]
		private bool _alignAxis = true;

		[SerializeField]
		private TransformAxis _alignmentAxis = TransformAxis.PositiveY;

		[SerializeField]
		private float _rotationSensitivity = 1f;

		[SerializeField]
		private float _scaleSensitivity = 0.03f;

		[SerializeField]
		private float _offsetFromSurfaceSensitivity = 0.03f;

		[SerializeField]
		private float _offsetFromAnchorSensitivity = 0.03f;

		[SerializeField]
		private ObjectGrabSurfaceFlags _surfaceFlags = (ObjectGrabSurfaceFlags)7;

		[SerializeField]
		private float _defaultOffsetFromSurface;

		[SerializeField]
		private int _surfaceLayers = -1;

		[SerializeField]
		private ObjectLayerGrabSettings[] _layerGrabSettings = new ObjectLayerGrabSettings[LayerEx.GetMaxLayer() + 1];

		[SerializeField]
		private int _sphericalMeshLayers;

		[SerializeField]
		private int _terrainMeshLayers;

		public bool AlignAxis
		{
			get
			{
				return _alignAxis;
			}
			set
			{
				_alignAxis = value;
			}
		}

		public TransformAxis AlignmentAxis
		{
			get
			{
				return _alignmentAxis;
			}
			set
			{
				_alignmentAxis = value;
			}
		}

		public float RotationSensitivity
		{
			get
			{
				return _rotationSensitivity;
			}
			set
			{
				_rotationSensitivity = Mathf.Clamp(value, 0.01f, 1f);
			}
		}

		public float ScaleSensitivity
		{
			get
			{
				return _scaleSensitivity;
			}
			set
			{
				_scaleSensitivity = Mathf.Clamp(value, 0.01f, 1f);
			}
		}

		public float OffsetFromSurfaceSensitivity
		{
			get
			{
				return _offsetFromSurfaceSensitivity;
			}
			set
			{
				_offsetFromSurfaceSensitivity = Mathf.Clamp(value, 0.01f, 1f);
			}
		}

		public float OffsetFromAnchorSensitivity
		{
			get
			{
				return _offsetFromAnchorSensitivity;
			}
			set
			{
				_offsetFromAnchorSensitivity = Mathf.Clamp(value, 0.01f, 1f);
			}
		}

		public ObjectGrabSurfaceFlags SurfaceFlags
		{
			get
			{
				return _surfaceFlags;
			}
			set
			{
				_surfaceFlags = value;
			}
		}

		public float DefaultOffsetFromSurface
		{
			get
			{
				return _defaultOffsetFromSurface;
			}
			set
			{
				_defaultOffsetFromSurface = value;
			}
		}

		public int SurfaceLayers
		{
			get
			{
				return _surfaceLayers;
			}
			set
			{
				_surfaceLayers = value;
			}
		}

		public int SphericalMeshLayers
		{
			get
			{
				return _sphericalMeshLayers;
			}
			set
			{
				_sphericalMeshLayers = value;
			}
		}

		public int TerrainMeshLayers
		{
			get
			{
				return _terrainMeshLayers;
			}
			set
			{
				_terrainMeshLayers = value;
			}
		}

		public ObjectGrabSettings()
		{
			for (int i = 0; i < _layerGrabSettings.Length; i++)
			{
				_layerGrabSettings[i] = new ObjectLayerGrabSettings(i);
			}
		}

		public ObjectLayerGrabSettings GetLayerGrabSettings(int layer)
		{
			return _layerGrabSettings[layer];
		}
	}
}
