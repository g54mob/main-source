using UnityEngine;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Spline Renderer")]
	[ExecuteInEditMode]
	public class SplineRenderer : MeshGenerator
	{
		[HideInInspector]
		public bool autoOrient;

		[HideInInspector]
		public int updateFrameInterval;

		[SerializeField]
		[HideInInspector]
		private int _slices;

		private int _currentFrame;

		private Vector3 _vertexDirection;

		private bool _orthographic;

		private bool _init;

		public int slices
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		protected override void LateRun()
		{
		}

		protected override void BuildMesh()
		{
		}

		public void RenderWithCamera(Camera cam)
		{
		}

		private void OnWillRenderObject()
		{
		}

		public void GenerateVertices(Vector3 vertexDirection, bool orthoGraphic)
		{
		}
	}
}
