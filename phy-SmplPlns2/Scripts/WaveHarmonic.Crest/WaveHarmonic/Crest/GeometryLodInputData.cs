using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class GeometryLodInputData : LodInputData
	{
		[Tooltip("Geometry to render into the simulation.")]
		[SerializeField]
		internal Mesh _Geometry;

		private Material _Material;

		private protected abstract Shader GeometryShader { get; }

		internal override bool IsEnabled => _Geometry != null;

		public Mesh Geometry
		{
			get
			{
				return _Geometry;
			}
			set
			{
				SetGeometry(_Geometry, _Geometry = value);
			}
		}

		internal override void Draw(Lod lod, Component component, CommandBuffer buffer, RenderTargetIdentifier target, int slices)
		{
			buffer.DrawMesh(_Geometry, component.transform.localToWorldMatrix, _Material);
		}

		internal override void OnEnable()
		{
			if (_Material == null)
			{
				_Material = new Material(GeometryShader);
			}
			LodInput.SetBlendFromPreset(_Material, _Input.Blend);
		}

		internal override void OnDisable()
		{
		}

		internal override void RecalculateBounds()
		{
			_Bounds = _Input.transform.TransformBounds(_Geometry.bounds);
		}

		internal override void RecalculateRect()
		{
			_Rect = base.Bounds.RectXZ();
		}

		private void SetGeometry(Mesh previous, Mesh current)
		{
			if (!(previous == current))
			{
				RecalculateCulling();
			}
		}
	}
}
