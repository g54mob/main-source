using UnityEngine;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Waveform Generator")]
	public class WaveformGenerator : MeshGenerator
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public enum Space
		{
			World = 0,
			Local = 1
		}

		public enum UVWrapMode
		{
			Clamp = 0,
			UniformX = 1,
			UniformY = 2,
			Uniform = 3
		}

		[SerializeField]
		[HideInInspector]
		private Axis _axis = Axis.Y;

		[SerializeField]
		[HideInInspector]
		private bool _symmetry;

		[SerializeField]
		[HideInInspector]
		private UVWrapMode _uvWrapMode;

		[SerializeField]
		[HideInInspector]
		private int _slices = 1;

		public Axis axis
		{
			get
			{
				return _axis;
			}
			set
			{
				if (value != _axis)
				{
					_axis = value;
					Rebuild();
				}
			}
		}

		public bool symmetry
		{
			get
			{
				return _symmetry;
			}
			set
			{
				if (value != _symmetry)
				{
					_symmetry = value;
					Rebuild();
				}
			}
		}

		public UVWrapMode uvWrapMode
		{
			get
			{
				return _uvWrapMode;
			}
			set
			{
				if (value != _uvWrapMode)
				{
					_uvWrapMode = value;
					Rebuild();
				}
			}
		}

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

		protected override string meshName => "Waveform";

		protected override void BuildMesh()
		{
			base.BuildMesh();
			Generate();
		}

		protected override void Build()
		{
			base.Build();
		}

		protected override void LateRun()
		{
			base.LateRun();
		}

		private void Generate()
		{
			int vertexCount = base.sampleCount * (_slices + 1);
			AllocateMesh(vertexCount, _slices * (base.sampleCount - 1) * 6);
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			_ = base.spline.position;
			Vector3 vector = base.spline.TransformDirection(Vector3.right);
			switch (_axis)
			{
			case Axis.Y:
				vector = base.spline.TransformDirection(Vector3.up);
				break;
			case Axis.Z:
				vector = base.spline.TransformDirection(Vector3.forward);
				break;
			}
			Vector3 b = Vector3.zero;
			for (int i = 0; i < base.sampleCount; i++)
			{
				GetSample(i, ref evalResult);
				float baseSize = GetBaseSize(evalResult);
				Vector3 position = evalResult.position;
				Vector3 vector2 = base.spline.InverseTransformPoint(position);
				Vector3 point = vector2;
				Vector3 forward = evalResult.forward;
				Vector3 up = evalResult.up;
				float num4 = 1f;
				if ((_uvWrapMode == UVWrapMode.UniformX || _uvWrapMode == UVWrapMode.Uniform) && i > 0)
				{
					num3 += Vector3.Distance(evalResult.position, b);
				}
				switch (_axis)
				{
				case Axis.X:
					point.x = (_symmetry ? (0f - vector2.x) : 0f);
					num4 = base.uvScale.y * Mathf.Abs(vector2.x);
					num2 += vector2.x;
					break;
				case Axis.Y:
					point.y = (_symmetry ? (0f - vector2.y) : 0f);
					num4 = base.uvScale.y * Mathf.Abs(vector2.y);
					num2 += vector2.y;
					break;
				case Axis.Z:
					point.z = (_symmetry ? (0f - vector2.z) : 0f);
					num4 = base.uvScale.y * Mathf.Abs(vector2.z);
					num2 += vector2.z;
					break;
				}
				point = base.spline.TransformPoint(point);
				Vector3 normalized = Vector3.Cross(vector, forward).normalized;
				Vector3 vector3 = Vector3.Cross(up, forward);
				for (int j = 0; j < _slices + 1; j++)
				{
					float num5 = (float)j / (float)_slices;
					base._tsMesh.vertices[num] = Vector3.Lerp(point, position, num5) + vector * (base.offset.y * baseSize) + vector3 * (base.offset.x * baseSize);
					base._tsMesh.normals[num] = normalized;
					switch (_uvWrapMode)
					{
					case UVWrapMode.Clamp:
						base._tsMesh.uv[num] = new Vector2((float)evalResult.percent * base.uvScale.x + base.uvOffset.x, num5 * base.uvScale.y + base.uvOffset.y);
						break;
					case UVWrapMode.UniformX:
						base._tsMesh.uv[num] = new Vector2(num3 * base.uvScale.x + base.uvOffset.x, num5 * base.uvScale.y + base.uvOffset.y);
						break;
					case UVWrapMode.UniformY:
						base._tsMesh.uv[num] = new Vector2((float)evalResult.percent * base.uvScale.x + base.uvOffset.x, num4 * num5 * base.uvScale.y + base.uvOffset.y);
						break;
					case UVWrapMode.Uniform:
						base._tsMesh.uv[num] = new Vector2(num3 * base.uvScale.x + base.uvOffset.x, num4 * num5 * base.uvScale.y + base.uvOffset.y);
						break;
					}
					base._tsMesh.colors[num] = GetBaseColor(evalResult) * base.color;
					num++;
				}
				b = evalResult.position;
			}
			if (base.sampleCount > 0)
			{
				num2 /= (float)base.sampleCount;
			}
			MeshUtility.GeneratePlaneTriangles(ref base._tsMesh.triangles, _slices, base.sampleCount, num2 < 0f);
		}
	}
}
