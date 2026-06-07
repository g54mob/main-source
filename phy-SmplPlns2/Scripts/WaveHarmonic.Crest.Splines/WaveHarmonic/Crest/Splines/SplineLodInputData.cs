using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	public abstract class SplineLodInputData : LodInputData, IReceiveSplineChangeMessages
	{
		[Tooltip("The <i>Crest Spline</i> to use with this input.")]
		[SerializeField]
		internal Spline _Spline;

		[Tooltip("Whether to override the spline's radius.")]
		[SerializeField]
		internal bool _OverrideRadius;

		[Tooltip("The radius of the spline.")]
		[FormerlySerializedAs("_Width")]
		[SerializeField]
		internal float _Radius = 20f;

		[Tooltip("Whether to override the spline's subdivisions.")]
		[SerializeField]
		internal bool _OverrideSubdivisions;

		[Tooltip("Increasing subdivision increases the geometry density.\n\nMostly useful for water level changes. High values can reduce staircasing effect.")]
		[SerializeField]
		internal int _Subdivisions = 1;

		internal Mesh _Mesh;

		internal Vector3[] _SplineBoundingPoints = new Vector3[0];

		internal Material _Material;

		private protected bool _IsDirty;

		[Obsolete("Please use OverrideRadius and/or OverrideSubdivisions instead.")]
		[Tooltip("Whether to override the settings with the same name on the spline component.")]
		[HideInInspector]
		[SerializeField]
		internal bool _OverrideSplineSettings;

		public bool OverrideRadius
		{
			get
			{
				return _OverrideRadius;
			}
			set
			{
				_OverrideRadius = value;
			}
		}

		[Obsolete("Please use OverrideRadius and/or OverrideSubdivisions instead.")]
		public bool OverrideSplineSettings
		{
			get
			{
				return _OverrideSplineSettings;
			}
			set
			{
				SetOverrideSplineSettings(_OverrideSplineSettings, _OverrideSplineSettings = value);
			}
		}

		public bool OverrideSubdivisions
		{
			get
			{
				return _OverrideSubdivisions;
			}
			set
			{
				_OverrideSubdivisions = value;
			}
		}

		public float Radius
		{
			get
			{
				return GetRadius();
			}
			set
			{
				_Radius = value;
			}
		}

		public Spline Spline
		{
			get
			{
				return _Spline;
			}
			set
			{
				_Spline = value;
			}
		}

		public int Subdivisions
		{
			get
			{
				return GetSubdivisions();
			}
			set
			{
				_Subdivisions = value;
			}
		}

		public Mesh Mesh => _Mesh;

		private protected abstract Shader SplineShader { get; }

		private protected abstract Vector4 DefaultCustomSplineData { get; }

		internal override bool IsEnabled
		{
			get
			{
				if (_Spline != null)
				{
					return _Material != null;
				}
				return false;
			}
		}

		private protected override int Version => Mathf.Max(base.Version, 1);

		private protected abstract void CreateOrUpdateSplineMesh();

		private float GetRadius()
		{
			if (!OverrideRadius && !(_Spline == null))
			{
				return _Spline.Radius;
			}
			return _Radius;
		}

		private int GetSubdivisions()
		{
			if (!OverrideSubdivisions && !(_Spline == null))
			{
				return _Spline.Subdivisions;
			}
			return _Subdivisions;
		}

		internal override void RecalculateRect()
		{
			if (_SplineBoundingPoints.Length < 2)
			{
				_Rect = Rect.zero;
				return;
			}
			Bounds bounds = base.Bounds;
			_Rect = Rect.MinMaxRect(bounds.min.x, bounds.min.z, bounds.max.x, bounds.max.z);
		}

		internal override void RecalculateBounds()
		{
			if (_SplineBoundingPoints.Length > 1)
			{
				_Bounds = GeometryUtility.CalculateBounds(_SplineBoundingPoints, _Input.transform.localToWorldMatrix);
			}
		}

		internal override void OnEnable()
		{
			CreateOrUpdateSplineMesh();
		}

		internal override void OnDisable()
		{
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (_IsDirty)
			{
				CreateOrUpdateSplineMesh();
			}
			if (!(_Material == null))
			{
				_Material.SetFloat(ShaderIDs.s_FeatherWidth, _Input.FeatherWidth);
			}
		}

		internal override void Draw(Lod lod, Component component, CommandBuffer buffer, RenderTargetIdentifier target, int slice)
		{
			Mesh mesh = _Mesh;
			Material material = _Material;
			if (mesh != null && material != null)
			{
				int shaderPass = ((ShapeWaves.s_RenderPassOverride > -1) ? ShapeWaves.s_RenderPassOverride : 0);
				buffer.DrawMesh(mesh, component.transform.localToWorldMatrix, material, 0, shaderPass);
			}
		}

		void IReceiveSplineChangeMessages.OnSplineChange()
		{
			_IsDirty = true;
		}

		[Obsolete]
		private void SetOverrideSplineSettings(bool previous, bool current, bool force = false)
		{
			if (previous != current || force)
			{
				_OverrideRadius = current;
				_OverrideSubdivisions = current;
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				SetOverrideSplineSettings(_OverrideSplineSettings, _OverrideSplineSettings, force: true);
			}
		}
	}
}
