using System;
using System.Collections.Generic;
using System.Reflection;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.CustomWheelCollider
{
	public class TireTrackRenderer : MonoBehaviour
	{
		private struct SegmentBounds
		{
			public Vector3 Max;

			public Vector3 Min;

			public bool Visible;
		}

		private static class ShaderPropertyIds
		{
			public static readonly int NextSegment = Shader.PropertyToID("_nextSegment");

			public static readonly int SegmentFadeRange = Shader.PropertyToID("_segmentFadeRange");

			public static readonly int TotalSegments = Shader.PropertyToID("_totalSegments");
		}

		private const int _BoundsBucketSize = 4;

		private static Matrix4x4 _drawMatrix = Matrix4x4.identity;

		private SegmentBounds[][] _bounds;

		private int _currentNotVisibleCount;

		private bool _dirtyMeshData;

		private List<int> _dirtySegments;

		private bool _initialized;

		[SerializeField]
		private Material _material;

		[SerializeField]
		private int _maxSegments = 1000;

		private Mesh _mesh;

		[SerializeField]
		private float _minDistance = 0.5f;

		private float _minDistanceSquared;

		private int _nextSegment;

		private Vector3 _previousSegmentPosition;

		[SerializeField]
		private int _segmentFadeRange = 100;

		private bool _segmentStart;

		private Transform _transform;

		[SerializeField]
		private bool _updating;

		private List<Vector3> _uvList;

		private Vector3[] _uvs;

		private Vector3[] _vertices;

		public float CurrentOpacityMultiplier { get; set; }

		public bool Updating
		{
			get
			{
				return _updating;
			}
			set
			{
				if (_updating != value && _maxSegments > 0)
				{
					if (value)
					{
						BeginSegment();
					}
					else
					{
						EndSegment();
					}
				}
				_updating = value;
			}
		}

		public float Width { get; set; }

		public void Initialize(Material tireTracksMat = null)
		{
			if (!_initialized)
			{
				if ((bool)tireTracksMat)
				{
					_material = tireTracksMat;
				}
				switch (Game.Instance.QualitySettings.VisualEffects.TireTracks.Value)
				{
				case VisualEffectsQualitySettings.TireTrackQuality.Off:
					_maxSegments = 0;
					base.enabled = false;
					break;
				case VisualEffectsQualitySettings.TireTrackQuality.Low:
					_maxSegments /= 5;
					_segmentFadeRange /= 5;
					break;
				case VisualEffectsQualitySettings.TireTrackQuality.Medium:
					_maxSegments /= 2;
					_segmentFadeRange /= 2;
					break;
				}
				_transform = base.transform;
				_mesh = new Mesh();
				_mesh.name = "Tire Track Mesh";
				_mesh.MarkDynamic();
				_material = UnityEngine.Object.Instantiate(_material);
				_material.SetFloat(ShaderPropertyIds.TotalSegments, _maxSegments);
				_material.SetFloat(ShaderPropertyIds.SegmentFadeRange, _segmentFadeRange);
				InitializeVertices();
				InitializeUVs();
				InitializeTriangles();
				InitializeBounds();
				_minDistanceSquared = _minDistance * _minDistance;
				_currentNotVisibleCount = _maxSegments + 1;
				_dirtySegments = new List<int>();
				_initialized = true;
			}
		}

		public void MoveAllSections(Vector3 positionDelta)
		{
			if (!base.enabled)
			{
				return;
			}
			_previousSegmentPosition += positionDelta;
			for (int i = 0; i < _vertices.Length; i++)
			{
				_vertices[i] += positionDelta;
			}
			for (int j = 0; j < _bounds.Length; j++)
			{
				SegmentBounds[] array = _bounds[j];
				for (int k = 0; k < array.Length; k++)
				{
					array[k].Min += positionDelta;
					array[k].Max += positionDelta;
				}
			}
			_dirtyMeshData = true;
		}

		protected virtual void LateUpdate()
		{
			if (!_updating && _currentNotVisibleCount > _maxSegments)
			{
				return;
			}
			Vector3 position = _transform.position;
			Vector3 vector = position - _previousSegmentPosition;
			float sqrMagnitude = vector.sqrMagnitude;
			bool flag = sqrMagnitude > _minDistanceSquared;
			if (_updating)
			{
				_currentNotVisibleCount = 0;
				if (flag)
				{
					Vector3 vector2 = _transform.TransformDirection(Vector3.left) * (Width * 0.5f);
					SetSegmentDirty(_nextSegment);
					int num = _nextSegment * 2;
					int num2 = num + 1;
					int num3 = ((_nextSegment == 0) ? (_maxSegments - 1) : (_nextSegment - 1)) * 2;
					int num4 = num3 + 1;
					_nextSegment = ((_nextSegment != _maxSegments) ? (_nextSegment + 1) : 0);
					SetSegmentDirty(_nextSegment);
					int num5 = _nextSegment * 2;
					int num6 = num5 + 1;
					_vertices[num] = position - vector2;
					_vertices[num2] = position + vector2;
					_uvs[num].z = CurrentOpacityMultiplier;
					_uvs[num2].z = CurrentOpacityMultiplier;
					_vertices[num5] = _vertices[num];
					_vertices[num6] = _vertices[num2];
					_uvs[num5].z = 0f;
					_uvs[num6].z = 0f;
					Vector3 lhs = vector / (float)Math.Sqrt(sqrMagnitude);
					Vector3 normalized = (_vertices[num] - _vertices[num3]).normalized;
					Vector3 normalized2 = (_vertices[num2] - _vertices[num4]).normalized;
					if (Vector3.Dot(lhs, normalized) < 0f)
					{
						_vertices[num] = _vertices[num3];
					}
					if (Vector3.Dot(lhs, normalized2) < 0f)
					{
						_vertices[num2] = _vertices[num4];
					}
					_previousSegmentPosition = position;
					_segmentStart = false;
				}
				else if (sqrMagnitude > Mathf.Epsilon)
				{
					Vector3 vector3 = _transform.TransformDirection(Vector3.left) * (Width * 0.5f);
					int num7 = ((_nextSegment == 0) ? (_maxSegments - 1) : (_nextSegment - 1));
					SetSegmentDirty(_nextSegment);
					int num8 = num7 * 2;
					_vertices[num8] = position - vector3;
					_vertices[num8 + 1] = position + vector3;
					if (!_segmentStart)
					{
						_uvs[num8].z = CurrentOpacityMultiplier;
						_uvs[num8 + 1].z = CurrentOpacityMultiplier;
					}
				}
			}
			else if (flag)
			{
				SetSegmentDirty(_nextSegment);
				int num9 = _nextSegment * 2;
				_vertices[num9] = position;
				_vertices[num9 + 1] = position;
				_uvs[num9].z = 0f;
				_uvs[num9 + 1].z = 0f;
				_nextSegment = ((_nextSegment != _maxSegments) ? (_nextSegment + 1) : 0);
				_currentNotVisibleCount++;
				_previousSegmentPosition = position;
				_segmentStart = false;
			}
			if (_dirtySegments.Count > 0 || _dirtyMeshData)
			{
				UpdateMesh();
				_material.SetFloat(ShaderPropertyIds.NextSegment, _nextSegment);
			}
			Graphics.DrawMesh(_mesh, _drawMatrix, _material, 0, null, 0, null, castShadows: false, receiveShadows: false, useLightProbes: false);
		}

		protected virtual void OnDestroy()
		{
			if (_initialized)
			{
				if (_mesh != null)
				{
					UnityEngine.Object.Destroy(_mesh);
				}
				if (_material != null)
				{
					UnityEngine.Object.Destroy(_material);
				}
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
			if (_initialized)
			{
				Gizmos.color = Color.green;
				Gizmos.matrix = _drawMatrix;
				Gizmos.DrawWireCube(_mesh.bounds.center, _mesh.bounds.size);
			}
		}

		private void Awake()
		{
			if (!Game.InFlightScene)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void BeginSegment()
		{
			Vector3 position = _transform.position;
			Vector3 vector = _transform.TransformDirection(Vector3.left) * (Width * 0.5f);
			SetSegmentDirty(_nextSegment);
			int num = _nextSegment * 2;
			int num2 = num + 1;
			_nextSegment = ((_nextSegment != _maxSegments) ? (_nextSegment + 1) : 0);
			SetSegmentDirty(_nextSegment);
			int num3 = _nextSegment * 2;
			int num4 = num3 + 1;
			Vector3 vector2 = position - vector;
			Vector3 vector3 = position + vector;
			_vertices[num] = vector2;
			_vertices[num2] = vector3;
			_uvs[num].z = 0f;
			_uvs[num2].z = 0f;
			_vertices[num3] = vector2;
			_vertices[num4] = vector3;
			_uvs[num3].z = 0f;
			_uvs[num4].z = 0f;
			_previousSegmentPosition = position;
			_segmentStart = true;
		}

		private void EndSegment()
		{
			int num = ((_nextSegment == 0) ? (_maxSegments - 1) : (_nextSegment - 1));
			SetSegmentDirty(num);
			int num2 = num * 2;
			int num3 = num2 + 1;
			_uvs[num2].z = 0f;
			_uvs[num3].z = 0f;
			_previousSegmentPosition = _transform.position;
			_segmentStart = false;
		}

		private void InitializeBounds()
		{
			if (_maxSegments > 0)
			{
				_bounds = new SegmentBounds[(int)Math.Ceiling(Math.Log(_maxSegments, 4.0))][];
				for (int i = 0; i < _bounds.Length; i++)
				{
					_bounds[i] = new SegmentBounds[(int)Math.Pow(i + 1, 4.0)];
				}
			}
		}

		private void InitializeTriangles()
		{
			int[] array = new int[(_maxSegments + 1) * 2 * 3];
			for (int i = 0; i < _maxSegments; i++)
			{
				int num = i * 2;
				int num2 = i * 6;
				array[num2] = num;
				array[num2 + 1] = num + 1;
				array[num2 + 2] = num + 2;
				array[num2 + 3] = num + 1;
				array[num2 + 4] = num + 3;
				array[num2 + 5] = num + 2;
			}
			int num3 = _maxSegments * 2;
			int num4 = _maxSegments * 6;
			array[num4] = num3;
			array[num4 + 1] = num3 + 1;
			array[num4 + 2] = 0;
			array[num4 + 3] = num3 + 1;
			array[num4 + 4] = 1;
			array[num4 + 5] = 0;
			_mesh.SetTriangles(array, 0);
		}

		private void InitializeUVs()
		{
			_uvs = new Vector3[_maxSegments * 2 + 2];
			for (int i = 0; i <= _maxSegments; i++)
			{
				_uvs[i * 2] = new Vector3(1f, i, 0f);
				_uvs[i * 2 + 1] = new Vector3(-1f, i, 0f);
			}
			_uvList = new List<Vector3>();
			Type typeFromHandle = typeof(List<Vector3>);
			typeFromHandle.GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(_uvList, _uvs);
			typeFromHandle.GetField("_size", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(_uvList, _uvs.Length);
			_mesh.SetUVs(0, _uvList);
		}

		private void InitializeVertices()
		{
			_vertices = new Vector3[_maxSegments * 2 + 2];
			_mesh.vertices = _vertices;
		}

		private void SetSegmentDirty(int segment)
		{
			segment /= 4;
			if (!_dirtySegments.Contains(segment))
			{
				_dirtySegments.Add(segment);
			}
		}

		private void UpdateMesh()
		{
			_dirtyMeshData = false;
			_mesh.vertices = _vertices;
			_mesh.SetUVs(0, _uvList);
			foreach (int dirtySegment in _dirtySegments)
			{
				int num = _bounds.Length - 1;
				int num2 = dirtySegment * 4 * 2;
				Vector3 vector = Vector3.zero;
				Vector3 max = Vector3.zero;
				bool flag = false;
				bool flag2 = true;
				for (int i = 0; i < 4; i++)
				{
					bool flag3 = num2 < _vertices.Length && _uvs[num2].z > 0f;
					flag = flag || flag3;
					if (flag3)
					{
						if (flag2)
						{
							flag2 = false;
							vector = _vertices[num2];
							max = vector;
						}
						else
						{
							Vector3 vector2 = _vertices[num2];
							if (vector2.x < vector.x)
							{
								vector.x = vector2.x;
							}
							else if (vector2.x > max.x)
							{
								max.x = vector2.x;
							}
							if (vector2.y < vector.y)
							{
								vector.y = vector2.y;
							}
							else if (vector2.y > max.y)
							{
								max.y = vector2.y;
							}
							if (vector2.z < vector.z)
							{
								vector.z = vector2.z;
							}
							else if (vector2.z > max.z)
							{
								max.z = vector2.z;
							}
						}
					}
					num2 += 2;
				}
				SegmentBounds segmentBounds = new SegmentBounds
				{
					Visible = flag,
					Min = vector,
					Max = max
				};
				_bounds[num][dirtySegment] = segmentBounds;
				num--;
				int num3 = dirtySegment / 4;
				while (num >= 0)
				{
					num2 = num3 * 4;
					int num4 = num + 1;
					SegmentBounds segmentBounds2 = new SegmentBounds
					{
						Visible = false
					};
					flag2 = true;
					for (int j = 0; j < 4; j++)
					{
						SegmentBounds segmentBounds3 = _bounds[num4][num2 + j];
						if (!segmentBounds3.Visible)
						{
							continue;
						}
						segmentBounds2.Visible = true;
						if (flag2)
						{
							flag2 = false;
							segmentBounds2.Min = segmentBounds3.Min;
							segmentBounds2.Max = segmentBounds3.Max;
							continue;
						}
						if (segmentBounds2.Min.x > segmentBounds3.Min.x)
						{
							segmentBounds2.Min.x = segmentBounds3.Min.x;
						}
						if (segmentBounds2.Max.x < segmentBounds3.Max.x)
						{
							segmentBounds2.Max.x = segmentBounds3.Max.x;
						}
						if (segmentBounds2.Min.y > segmentBounds3.Min.y)
						{
							segmentBounds2.Min.y = segmentBounds3.Min.y;
						}
						if (segmentBounds2.Max.y < segmentBounds3.Max.y)
						{
							segmentBounds2.Max.y = segmentBounds3.Max.y;
						}
						if (segmentBounds2.Min.z > segmentBounds3.Min.z)
						{
							segmentBounds2.Min.z = segmentBounds3.Min.z;
						}
						if (segmentBounds2.Max.z < segmentBounds3.Max.z)
						{
							segmentBounds2.Max.z = segmentBounds3.Max.z;
						}
					}
					_bounds[num][num3] = segmentBounds2;
					num--;
					num3 /= 4;
				}
			}
			SegmentBounds segmentBounds4 = _bounds[0][0];
			Vector3 vector3 = segmentBounds4.Max - segmentBounds4.Min;
			Bounds bounds = new Bounds(segmentBounds4.Min + vector3 * 0.5f, vector3);
			_mesh.bounds = bounds;
			_dirtySegments.Clear();
		}
	}
}
