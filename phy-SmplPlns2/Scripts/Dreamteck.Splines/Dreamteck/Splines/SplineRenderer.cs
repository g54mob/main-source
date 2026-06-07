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
		public bool autoOrient = true;

		[HideInInspector]
		public int updateFrameInterval;

		[SerializeField]
		[HideInInspector]
		private int _slices = 1;

		private int _currentFrame;

		private Vector3 _vertexDirection = Vector3.up;

		private bool _orthographic;

		private bool _init;

		public int slices
		{
			get
			{
				return _slices;
			}
			set
			{
				if (value != _slices)
				{
					if (value < 1)
					{
						value = 1;
					}
					_slices = value;
					Rebuild();
				}
			}
		}

		private void Start()
		{
			if (Camera.current != null)
			{
				_orthographic = Camera.current.orthographic;
			}
			else if (Camera.main != null)
			{
				_orthographic = Camera.main.orthographic;
			}
			CreateMesh();
		}

		protected override void LateRun()
		{
			if (updateFrameInterval > 0)
			{
				_currentFrame++;
				if (_currentFrame > updateFrameInterval)
				{
					_currentFrame = 0;
				}
			}
		}

		protected override void BuildMesh()
		{
			base.BuildMesh();
			GenerateVertices(_vertexDirection, _orthographic);
			MeshUtility.GeneratePlaneTriangles(ref base._tsMesh.triangles, _slices, base.sampleCount, flip: false);
		}

		public void RenderWithCamera(Camera cam)
		{
			_orthographic = cam.orthographic;
			if (_orthographic)
			{
				_vertexDirection = -cam.transform.forward;
			}
			else
			{
				_vertexDirection = cam.transform.position;
			}
			BuildMesh();
			WriteMesh();
		}

		private void OnWillRenderObject()
		{
			if (autoOrient && (updateFrameInterval <= 0 || _currentFrame == 0))
			{
				if (!Application.isPlaying && !_init)
				{
					Awake();
					_init = true;
				}
				if (Camera.current != null)
				{
					RenderWithCamera(Camera.current);
				}
				else if ((bool)Camera.main)
				{
					RenderWithCamera(Camera.main);
				}
			}
		}

		public void GenerateVertices(Vector3 vertexDirection, bool orthoGraphic)
		{
			AllocateMesh((_slices + 1) * base.sampleCount, _slices * (base.sampleCount - 1) * 6);
			int num = 0;
			ResetUVDistance();
			bool flag = base.offset != Vector3.zero;
			for (int i = 0; i < base.sampleCount; i++)
			{
				GetSample(i, ref evalResult);
				Vector3 position = evalResult.position;
				if (flag)
				{
					position += base.offset.x * -Vector3.Cross(evalResult.forward, evalResult.up) + base.offset.y * evalResult.up + base.offset.z * evalResult.forward;
				}
				Vector3 vector = ((!orthoGraphic) ? (vertexDirection - position).normalized : vertexDirection);
				Vector3 normalized = Vector3.Cross(evalResult.forward, vector).normalized;
				if (base.uvMode == UVMode.UniformClamp || base.uvMode == UVMode.UniformClip)
				{
					AddUVDistance(i);
				}
				Color color = evalResult.color * base.color;
				for (int j = 0; j < _slices + 1; j++)
				{
					float num2 = (float)j / (float)_slices;
					base._tsMesh.vertices[num] = position - normalized * evalResult.size * 0.5f * base.size + normalized * evalResult.size * num2 * base.size;
					CalculateUVs(evalResult.percent, num2);
					base._tsMesh.uv[num] = Vector2.one * 0.5f + (Vector2)(Quaternion.AngleAxis(base.uvRotation + 180f, Vector3.forward) * (Vector2.one * 0.5f - MeshGenerator.__uvs));
					base._tsMesh.normals[num] = vector;
					base._tsMesh.colors[num] = color;
					num++;
				}
			}
		}
	}
}
