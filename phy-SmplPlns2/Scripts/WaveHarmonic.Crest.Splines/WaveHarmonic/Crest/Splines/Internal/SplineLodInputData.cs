using System;
using UnityEngine;

namespace WaveHarmonic.Crest.Splines.Internal
{
	[Serializable]
	public abstract class SplineLodInputData<T> : SplineLodInputData where T : SplinePointData
	{
		private protected override void CreateOrUpdateSplineMesh()
		{
			_IsDirty = false;
			if (_Material == null)
			{
				_Material = new Material(SplineShader);
			}
			LodInput.SetBlendFromPreset(_Material, _Input.Blend);
			if (_Spline == null)
			{
				Helpers.Destroy(_Mesh);
				_Mesh = null;
				return;
			}
			float radius = (_OverrideRadius ? _Radius : _Spline.Radius);
			int subdivisions = (_OverrideSubdivisions ? _Subdivisions : _Spline.Subdivisions);
			SplineMeshUtility.GenerateMeshFromSpline<T>(_Spline, _Spline.transform, subdivisions, radius, DefaultCustomSplineData, ref _Mesh, ref _SplineBoundingPoints);
			RecalculateCulling();
		}
	}
}
