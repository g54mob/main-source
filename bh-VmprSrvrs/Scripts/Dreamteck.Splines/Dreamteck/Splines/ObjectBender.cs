using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Object Bender")]
	public class ObjectBender : SplineUser
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public enum NormalMode
		{
			Spline = 0,
			Auto = 1,
			Custom = 2
		}

		public enum ForwardMode
		{
			Spline = 0,
			Custom = 1
		}

		[Serializable]
		public class BendProperty
		{
			public bool enabled;

			public TS_Transform transform;

			public bool applyRotation;

			public bool applyScale;

			public bool generateLightmapUVs;

			[SerializeField]
			[HideInInspector]
			private bool _bendMesh;

			[SerializeField]
			[HideInInspector]
			private bool _bendSpline;

			[SerializeField]
			[HideInInspector]
			private bool _bendCollider;

			private float colliderUpdateDue;

			public float colliderUpdateRate;

			private bool updateCollider;

			public Vector3 originalPosition;

			public Vector3 originalScale;

			public Quaternion originalRotation;

			public Quaternion parentRotation;

			public Vector3 positionPercent;

			public Vector3[] vertexPercents;

			public Vector3[] normals;

			public Vector3[] colliderVertexPercents;

			public Vector3[] colliderNormals;

			[SerializeField]
			[HideInInspector]
			private Mesh originalMesh;

			[SerializeField]
			[HideInInspector]
			private Mesh originalColliderMesh;

			private Spline _originalSpline;

			[SerializeField]
			[HideInInspector]
			private Mesh destinationMesh;

			[SerializeField]
			[HideInInspector]
			private Mesh destinationColliderMesh;

			public Spline destinationSpline;

			public TS_Mesh _editMesh;

			public TS_Mesh _editColliderMesh;

			public MeshFilter filter;

			public MeshCollider collider;

			public SplineComputer splineComputer;

			public Vector3[] splinePointPercents;

			public Vector3[] primaryTangentPercents;

			public Vector3[] secondaryTangentPercents;

			[SerializeField]
			[HideInInspector]
			private bool parent;

			public bool isValid => false;

			public bool bendMesh
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool bendCollider
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool bendSpline
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public TS_Mesh editMesh => null;

			public TS_Mesh editColliderMesh => null;

			public Spline originalSpline => null;

			public bool isParent => false;

			public BendProperty(Transform t, bool parent = false)
			{
			}

			public void Revert()
			{
			}

			private void RevertMesh()
			{
			}

			private void RevertTransform()
			{
			}

			private void RevertCollider()
			{
			}

			public void Apply(bool applyTransform)
			{
			}

			public void Update()
			{
			}

			private void ApplyMesh()
			{
			}

			private void ApplyCollider()
			{
			}

			private void ApplySpline()
			{
			}
		}

		[SerializeField]
		[HideInInspector]
		private bool _bend;

		[HideInInspector]
		public BendProperty[] bendProperties;

		[SerializeField]
		[HideInInspector]
		private bool _parentIsTheSpline;

		[SerializeField]
		[HideInInspector]
		private TS_Bounds bounds;

		[SerializeField]
		[HideInInspector]
		private Axis _axis;

		[SerializeField]
		[HideInInspector]
		private NormalMode _normalMode;

		[SerializeField]
		[HideInInspector]
		private ForwardMode _forwardMode;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("_upVector")]
		private Vector3 _customNormal;

		[SerializeField]
		[HideInInspector]
		private Vector3 _customForward;

		private Matrix4x4 normalMatrix;

		private Quaternion bendRotation;

		public bool bend
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Axis axis
		{
			get
			{
				return default(Axis);
			}
			set
			{
			}
		}

		public NormalMode upMode
		{
			get
			{
				return default(NormalMode);
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

		public ForwardMode forwardMode
		{
			get
			{
				return default(ForwardMode);
			}
			set
			{
			}
		}

		public Vector3 customForward
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		private void GetTransformsRecursively(Transform current, ref List<Transform> transformList)
		{
		}

		private void GetObjects()
		{
		}

		public TS_Bounds GetBounds()
		{
			return null;
		}

		private void CreateProperty(ref BendProperty property, Transform t)
		{
		}

		private void CalculateBounds()
		{
		}

		private void CalculatePropertyBounds(ref BendProperty property)
		{
		}

		public void CalculatePercents(BendProperty property)
		{
		}

		private void Revert()
		{
		}

		public void UpdateReferences()
		{
		}

		private void GetevalResult(Vector3 percentage)
		{
		}

		private Vector3 GetPercentage(Vector3 point)
		{
			return default(Vector3);
		}

		protected override void Build()
		{
		}

		private void Bend()
		{
		}

		public void BendObject(BendProperty p)
		{
		}

		private void BendMesh(Vector3[] vertexPercents, Vector3[] originalNormals, TS_Mesh mesh, Matrix4x4 worldToLocalMatrix)
		{
		}

		protected override void PostBuild()
		{
		}

		protected override void LateRun()
		{
		}
	}
}
