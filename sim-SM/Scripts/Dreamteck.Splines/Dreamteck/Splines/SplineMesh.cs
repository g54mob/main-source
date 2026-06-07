using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Spline Mesh")]
	public class SplineMesh : MeshGenerator
	{
		[Serializable]
		public class Channel
		{
			public delegate float FloatHandler(double percent);

			public delegate Vector2 Vector2Handler(double percent);

			public delegate Vector3 Vector3Handler(double percent);

			public delegate Quaternion QuaternionHandler(double percent);

			public enum Type
			{
				Extrude = 0,
				Place = 1
			}

			public enum UVOverride
			{
				None = 0,
				ClampU = 1,
				ClampV = 2,
				UniformU = 3,
				UniformV = 4
			}

			[Serializable]
			public struct BoundsSpacing
			{
				public float front;

				public float back;
			}

			[Serializable]
			public class MeshDefinition
			{
				public enum MirrorMethod
				{
					None = 0,
					X = 1,
					Y = 2,
					Z = 3
				}

				[Serializable]
				public class Submesh
				{
					public int[] triangles;

					public Submesh()
					{
					}

					public Submesh(int[] input)
					{
					}
				}

				[Serializable]
				public class VertexGroup
				{
					public float value;

					public double percent;

					public int[] ids;

					public VertexGroup(float val, double perc, int[] vertIds)
					{
					}

					public void AddId(int id)
					{
					}
				}

				[SerializeField]
				[HideInInspector]
				public Vector3[] vertices;

				[SerializeField]
				[HideInInspector]
				public Vector3[] normals;

				[SerializeField]
				[HideInInspector]
				public Vector4[] tangents;

				[SerializeField]
				[HideInInspector]
				public Color[] colors;

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv;

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv2;

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv3;

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv4;

				[SerializeField]
				[HideInInspector]
				public int[] triangles;

				[SerializeField]
				[HideInInspector]
				public List<Submesh> subMeshes;

				[SerializeField]
				[HideInInspector]
				public TS_Bounds bounds;

				[SerializeField]
				[HideInInspector]
				public List<VertexGroup> vertexGroups;

				[SerializeField]
				[HideInInspector]
				private Mesh _mesh;

				[SerializeField]
				[HideInInspector]
				private Vector3 _rotation;

				[SerializeField]
				[HideInInspector]
				private Vector3 _offset;

				[SerializeField]
				[HideInInspector]
				private Vector3 _scale;

				[SerializeField]
				[HideInInspector]
				private Vector2 _uvScale;

				[SerializeField]
				[HideInInspector]
				private Vector2 _uvOffset;

				[SerializeField]
				[HideInInspector]
				private float _uvRotation;

				[SerializeField]
				[HideInInspector]
				private MirrorMethod _mirror;

				[SerializeField]
				[HideInInspector]
				public BoundsSpacing _spacing;

				[SerializeField]
				[HideInInspector]
				private float _vertexGroupingMargin;

				[SerializeField]
				[HideInInspector]
				private bool _removeInnerFaces;

				[SerializeField]
				[HideInInspector]
				private bool _flipFaces;

				[SerializeField]
				[HideInInspector]
				private bool _doubleSided;

				public Mesh mesh
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public Vector3 rotation
				{
					get
					{
						return default(Vector3);
					}
					set
					{
					}
				}

				public Vector3 offset
				{
					get
					{
						return default(Vector3);
					}
					set
					{
					}
				}

				public Vector3 scale
				{
					get
					{
						return default(Vector3);
					}
					set
					{
					}
				}

				public BoundsSpacing spacing
				{
					get
					{
						return default(BoundsSpacing);
					}
					set
					{
					}
				}

				public Vector2 uvScale
				{
					get
					{
						return default(Vector2);
					}
					set
					{
					}
				}

				public Vector2 uvOffset
				{
					get
					{
						return default(Vector2);
					}
					set
					{
					}
				}

				public float uvRotation
				{
					get
					{
						return 0f;
					}
					set
					{
					}
				}

				public float vertexGroupingMargin
				{
					get
					{
						return 0f;
					}
					set
					{
					}
				}

				public MirrorMethod mirror
				{
					get
					{
						return default(MirrorMethod);
					}
					set
					{
					}
				}

				public bool removeInnerFaces
				{
					get
					{
						return false;
					}
					set
					{
					}
				}

				public bool flipFaces
				{
					get
					{
						return false;
					}
					set
					{
					}
				}

				public bool doubleSided
				{
					get
					{
						return false;
					}
					set
					{
					}
				}

				internal MeshDefinition Copy()
				{
					return null;
				}

				public MeshDefinition(Mesh input)
				{
				}

				public void Refresh()
				{
				}

				private void RemoveInnerFaces()
				{
				}

				private void FlipFaces()
				{
				}

				private void DoubleSided()
				{
				}

				public void Write(TS_Mesh target, int forceMaterialId = -1)
				{
				}

				private void CalculateBounds()
				{
				}

				private void Mirror()
				{
				}

				private void TransformVertices()
				{
				}

				private void GroupVertices()
				{
				}

				private int FindInsertIndex(Vector3 pos, float value)
				{
					return 0;
				}

				private void CalculateTangents()
				{
				}
			}

			public string name;

			private System.Random iterationRandom;

			[SerializeField]
			[HideInInspector]
			private int _iterationSeed;

			[SerializeField]
			[HideInInspector]
			private int _offsetSeed;

			private System.Random _offsetRandom;

			private Vector2Handler _offsetHandler;

			[SerializeField]
			[HideInInspector]
			private int _rotationSeed;

			private System.Random _rotationRandom;

			private QuaternionHandler _placeRotationHandler;

			private FloatHandler _extrudeRotationHandler;

			[SerializeField]
			[HideInInspector]
			private int _scaleSeed;

			private System.Random _scaleRandom;

			private Vector3Handler _scaleHandler;

			[SerializeField]
			internal SplineMesh owner;

			[SerializeField]
			[HideInInspector]
			private List<MeshDefinition> meshes;

			[SerializeField]
			[HideInInspector]
			private double _clipFrom;

			[SerializeField]
			[HideInInspector]
			private double _clipTo;

			[SerializeField]
			[HideInInspector]
			private bool _randomOrder;

			[SerializeField]
			[HideInInspector]
			private UVOverride _overrideUVs;

			[SerializeField]
			[HideInInspector]
			private Vector2 _uvScale;

			[SerializeField]
			[HideInInspector]
			private Vector2 _uvOffset;

			[SerializeField]
			[HideInInspector]
			private bool _overrideNormal;

			[SerializeField]
			[HideInInspector]
			private Vector3 _customNormal;

			[SerializeField]
			[HideInInspector]
			private Type _type;

			[SerializeField]
			[HideInInspector]
			private int _count;

			[SerializeField]
			[HideInInspector]
			private bool _autoCount;

			[SerializeField]
			[HideInInspector]
			private double _spacing;

			[SerializeField]
			[HideInInspector]
			private bool _randomRotation;

			[SerializeField]
			[HideInInspector]
			private Vector3 _minRotation;

			[SerializeField]
			[HideInInspector]
			private Vector3 _maxRotation;

			[SerializeField]
			[HideInInspector]
			private bool _randomOffset;

			[SerializeField]
			[HideInInspector]
			private Vector2 _minOffset;

			[SerializeField]
			[HideInInspector]
			private Vector2 _maxOffset;

			[SerializeField]
			[HideInInspector]
			private bool _randomScale;

			[SerializeField]
			[HideInInspector]
			private bool _uniformRandomScale;

			[SerializeField]
			[HideInInspector]
			private Vector3 _minScale;

			[SerializeField]
			[HideInInspector]
			private Vector3 _maxScale;

			private int iterator;

			[SerializeField]
			[HideInInspector]
			private bool _overrideMaterialID;

			[SerializeField]
			[HideInInspector]
			private int _targetMaterialID;

			[SerializeField]
			[HideInInspector]
			protected MeshScaleModifier _scaleModifier;

			public double clipFrom
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public double clipTo
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public bool randomOffset
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Vector2Handler offsetHandler
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public bool overrideMaterialID
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int targetMaterialID
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool randomRotation
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public QuaternionHandler placeRotationHandler
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public FloatHandler extrudeRotationHandler
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public bool randomScale
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Vector3Handler scaleHandler
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public bool uniformRandomScale
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int offsetSeed
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int rotationSeed
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int scaleSeed
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public double spacing
			{
				get
				{
					return 0.0;
				}
				set
				{
				}
			}

			public Vector2 minOffset
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public Vector2 maxOffset
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public Vector3 minRotation
			{
				get
				{
					return default(Vector3);
				}
				set
				{
				}
			}

			public Vector3 maxRotation
			{
				get
				{
					return default(Vector3);
				}
				set
				{
				}
			}

			public Vector3 minScale
			{
				get
				{
					return default(Vector3);
				}
				set
				{
				}
			}

			public Vector3 maxScale
			{
				get
				{
					return default(Vector3);
				}
				set
				{
				}
			}

			public Type type
			{
				get
				{
					return default(Type);
				}
				set
				{
				}
			}

			public bool randomOrder
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int randomSeed
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int count
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool autoCount
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public UVOverride overrideUVs
			{
				get
				{
					return default(UVOverride);
				}
				set
				{
				}
			}

			public Vector2 uvOffset
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public Vector2 uvScale
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public bool overrideNormal
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Vector3 customNormal
			{
				get
				{
					return default(Vector3);
				}
				set
				{
				}
			}

			public MeshScaleModifier scaleModifier => null;

			public Channel(string n, SplineMesh parent)
			{
			}

			public Channel(string n, Mesh inputMesh, SplineMesh parent)
			{
			}

			private void Init()
			{
			}

			public void CopyTo(Channel target)
			{
			}

			public int GetMeshCount()
			{
				return 0;
			}

			public void SwapMeshes(int a, int b)
			{
			}

			public void DuplicateMesh(int index)
			{
			}

			public MeshDefinition GetMesh(int index)
			{
				return null;
			}

			public void AddMesh(Mesh input)
			{
			}

			public void AddMesh(MeshDefinition meshDefinition)
			{
			}

			public void RemoveMesh(int index)
			{
			}

			public void ResetIteration()
			{
			}

			public (Vector2, Quaternion, Vector3) GetCustomPlaceValues(double percent)
			{
				return default((Vector2, Quaternion, Vector3));
			}

			public (Vector2, float, Vector3) GetCustomExtrudeValues(double percent)
			{
				return default((Vector2, float, Vector3));
			}

			public Vector2 NextRandomOffset()
			{
				return default(Vector2);
			}

			public Quaternion NextRandomQuaternion()
			{
				return default(Quaternion);
			}

			public float NextRandomAngle()
			{
				return 0f;
			}

			public Vector3 NextRandomScale()
			{
				return default(Vector3);
			}

			public Vector3 NextPlaceScale()
			{
				return default(Vector3);
			}

			public MeshDefinition NextMesh()
			{
				return null;
			}

			internal void Rebuild()
			{
			}

			private void Refresh()
			{
			}
		}

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("channels")]
		private List<Channel> _channels;

		private bool _useLastResult;

		private List<TS_Mesh> _combineMeshes;

		private Matrix4x4 _vertexMatrix;

		private Matrix4x4 _normalMatrix;

		private SplineSample _lastResult;

		private SplineSample _modifiedResult;

		protected override string meshName => null;

		protected override void Awake()
		{
		}

		protected override void Reset()
		{
		}

		public void RemoveChannel(int index)
		{
		}

		public void SwapChannels(int a, int b)
		{
		}

		public Channel AddChannel(Mesh inputMesh, string name)
		{
			return null;
		}

		public Channel AddChannel(string name)
		{
			return null;
		}

		public int GetChannelCount()
		{
			return 0;
		}

		public Channel GetChannel(int index)
		{
			return null;
		}

		protected override void BuildMesh()
		{
		}

		private void Generate()
		{
		}

		private void Place(Channel channel, TS_Mesh target, double percent)
		{
		}

		private void Extrude(Channel channel, TS_Mesh target, double from, double to)
		{
		}
	}
}
