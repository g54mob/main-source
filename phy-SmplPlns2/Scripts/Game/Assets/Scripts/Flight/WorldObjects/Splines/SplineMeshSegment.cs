using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshCollider))]
	public class SplineMeshSegment : MonoBehaviour
	{
		[SerializeField]
		private Mesh _collider;

		[SerializeField]
		private int _currentLodLevel;

		[SerializeField]
		private MeshCollider _meshCollider;

		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private List<Mesh> _meshLods;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private int _segmentIndex;

		[SerializeField]
		private SplineComputer _spline;

		[SerializeField]
		private double _splinePositionEnd;

		[SerializeField]
		private double _splinePositionStart;

		public Mesh Collider => _collider;

		public int CurrentLodLevel => _currentLodLevel;

		public MeshCollider MeshCollider => _meshCollider;

		public IReadOnlyList<Mesh> MeshLods => _meshLods;

		public int SegmentIndex => _segmentIndex;

		public SplineComputer Spline => _spline;

		public double SplinePositionEnd => _splinePositionEnd;

		public double SplinePositionStart => _splinePositionStart;

		public static SplineMeshSegment Create(SplineComputer spline, Transform parent, Material material, int segmentIndex, double splinePositionStart, double splinePositionEnd)
		{
			GameObject gameObject = new GameObject($"SplineMeshSegment_{segmentIndex}");
			SplineMeshSegment splineMeshSegment = gameObject.AddComponent<SplineMeshSegment>();
			splineMeshSegment._spline = spline;
			splineMeshSegment._meshLods = new List<Mesh>();
			splineMeshSegment._segmentIndex = segmentIndex;
			splineMeshSegment._splinePositionStart = splinePositionStart;
			splineMeshSegment._splinePositionEnd = splinePositionEnd;
			splineMeshSegment._meshFilter = splineMeshSegment.GetComponent<MeshFilter>();
			splineMeshSegment._meshRenderer = splineMeshSegment.GetComponent<MeshRenderer>();
			splineMeshSegment._meshCollider = splineMeshSegment.GetComponent<MeshCollider>();
			splineMeshSegment._meshRenderer.sharedMaterial = material;
			ComponentUtility.SetComponentIndex(splineMeshSegment, 1);
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			return splineMeshSegment;
		}

		public void SetLodLevel(int level)
		{
			if (_currentLodLevel != level)
			{
				_currentLodLevel = level;
				UpdateLod();
			}
		}

		public void SetMeshCollider(Mesh mesh)
		{
			_collider = mesh;
			_meshCollider.sharedMesh = mesh;
			UpdateLod();
		}

		public void SetMeshLod(Mesh mesh, int lodLevel)
		{
			if (lodLevel < 0)
			{
				throw new ArgumentOutOfRangeException("lodLevel");
			}
			if (lodLevel > 5)
			{
				throw new ArgumentOutOfRangeException("lodLevel", $"Is an LOD level of {lodLevel} intended? If so, update code to support it.");
			}
			if (lodLevel >= _meshLods.Count)
			{
				for (int i = _meshLods.Count; i <= lodLevel; i++)
				{
					_meshLods.Add(null);
				}
			}
			_meshLods[lodLevel] = mesh;
			if (lodLevel == _currentLodLevel)
			{
				UpdateLod();
			}
		}

		[ContextMenu("Update LOD")]
		private void UpdateLod()
		{
			if (_currentLodLevel < 0 || _currentLodLevel >= _meshLods.Count || _meshLods[_currentLodLevel] == null)
			{
				_meshFilter.sharedMesh = null;
				_meshRenderer.enabled = false;
			}
			else
			{
				_meshFilter.sharedMesh = _meshLods[_currentLodLevel];
				_meshRenderer.enabled = true;
			}
			_meshCollider.enabled = _meshCollider.sharedMesh != null;
		}
	}
}
