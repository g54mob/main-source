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
					public int[] triangles = new int[0];

					public Submesh()
					{
					}

					public Submesh(int[] input)
					{
						triangles = new int[input.Length];
						input.CopyTo(triangles, 0);
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
						percent = perc;
						value = val;
						ids = vertIds;
					}

					public void AddId(int id)
					{
						int[] array = new int[ids.Length + 1];
						ids.CopyTo(array, 0);
						array[^1] = id;
						ids = array;
					}
				}

				[SerializeField]
				[HideInInspector]
				public Vector3[] vertices = new Vector3[0];

				[SerializeField]
				[HideInInspector]
				public Vector3[] normals = new Vector3[0];

				[SerializeField]
				[HideInInspector]
				public Vector4[] tangents = new Vector4[0];

				[SerializeField]
				[HideInInspector]
				public Color[] colors = new Color[0];

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv = new Vector2[0];

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv2 = new Vector2[0];

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv3 = new Vector2[0];

				[SerializeField]
				[HideInInspector]
				public Vector2[] uv4 = new Vector2[0];

				[SerializeField]
				[HideInInspector]
				public int[] triangles = new int[0];

				[SerializeField]
				[HideInInspector]
				public List<Submesh> subMeshes = new List<Submesh>();

				[SerializeField]
				[HideInInspector]
				public TS_Bounds bounds = new TS_Bounds(Vector3.zero, Vector3.zero);

				[SerializeField]
				[HideInInspector]
				public List<VertexGroup> vertexGroups = new List<VertexGroup>();

				[SerializeField]
				[HideInInspector]
				private Mesh _mesh;

				[SerializeField]
				[HideInInspector]
				private Vector3 _rotation = Vector3.zero;

				[SerializeField]
				[HideInInspector]
				private Vector3 _offset = Vector3.zero;

				[SerializeField]
				[HideInInspector]
				private Vector3 _scale = Vector3.one;

				[SerializeField]
				[HideInInspector]
				private Vector2 _uvScale = Vector2.one;

				[SerializeField]
				[HideInInspector]
				private Vector2 _uvOffset = Vector2.zero;

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
						return _mesh;
					}
					set
					{
						if (_mesh != value)
						{
							_mesh = value;
							Refresh();
						}
					}
				}

				public Vector3 rotation
				{
					get
					{
						return _rotation;
					}
					set
					{
						if (rotation != value)
						{
							_rotation = value;
							Refresh();
						}
					}
				}

				public Vector3 offset
				{
					get
					{
						return _offset;
					}
					set
					{
						if (_offset != value)
						{
							_offset = value;
							Refresh();
						}
					}
				}

				public Vector3 scale
				{
					get
					{
						return _scale;
					}
					set
					{
						if (_scale != value)
						{
							_scale = value;
							Refresh();
						}
					}
				}

				public BoundsSpacing spacing
				{
					get
					{
						return _spacing;
					}
					set
					{
						if (_spacing.back != value.back || _spacing.front != value.front)
						{
							_spacing = value;
							Refresh();
						}
					}
				}

				public Vector2 uvScale
				{
					get
					{
						return _uvScale;
					}
					set
					{
						if (_uvScale != value)
						{
							_uvScale = value;
							Refresh();
						}
					}
				}

				public Vector2 uvOffset
				{
					get
					{
						return _uvOffset;
					}
					set
					{
						if (_uvOffset != value)
						{
							_uvOffset = value;
							Refresh();
						}
					}
				}

				public float uvRotation
				{
					get
					{
						return _uvRotation;
					}
					set
					{
						if (_uvRotation != value)
						{
							_uvRotation = value;
							Refresh();
						}
					}
				}

				public float vertexGroupingMargin
				{
					get
					{
						return _vertexGroupingMargin;
					}
					set
					{
						if (_vertexGroupingMargin != value)
						{
							_vertexGroupingMargin = value;
							Refresh();
						}
					}
				}

				public MirrorMethod mirror
				{
					get
					{
						return _mirror;
					}
					set
					{
						if (_mirror != value)
						{
							_mirror = value;
							Refresh();
						}
					}
				}

				public bool removeInnerFaces
				{
					get
					{
						return _removeInnerFaces;
					}
					set
					{
						if (_removeInnerFaces != value)
						{
							_removeInnerFaces = value;
							Refresh();
						}
					}
				}

				public bool flipFaces
				{
					get
					{
						return _flipFaces;
					}
					set
					{
						if (_flipFaces != value)
						{
							_flipFaces = value;
							Refresh();
						}
					}
				}

				public bool doubleSided
				{
					get
					{
						return _doubleSided;
					}
					set
					{
						if (_doubleSided != value)
						{
							_doubleSided = value;
							Refresh();
						}
					}
				}

				internal MeshDefinition Copy()
				{
					MeshDefinition meshDefinition = new MeshDefinition(_mesh);
					meshDefinition.vertices = new Vector3[vertices.Length];
					meshDefinition.normals = new Vector3[normals.Length];
					meshDefinition.colors = new Color[colors.Length];
					meshDefinition.tangents = new Vector4[tangents.Length];
					meshDefinition.uv = new Vector2[uv.Length];
					meshDefinition.uv2 = new Vector2[uv2.Length];
					meshDefinition.uv3 = new Vector2[uv3.Length];
					meshDefinition.uv4 = new Vector2[uv4.Length];
					meshDefinition.triangles = new int[triangles.Length];
					vertices.CopyTo(meshDefinition.vertices, 0);
					normals.CopyTo(meshDefinition.normals, 0);
					colors.CopyTo(meshDefinition.colors, 0);
					tangents.CopyTo(meshDefinition.tangents, 0);
					uv.CopyTo(meshDefinition.uv, 0);
					uv2.CopyTo(meshDefinition.uv2, 0);
					uv3.CopyTo(meshDefinition.uv3, 0);
					uv4.CopyTo(meshDefinition.uv4, 0);
					triangles.CopyTo(meshDefinition.triangles, 0);
					meshDefinition.bounds = new TS_Bounds(bounds.min, bounds.max);
					meshDefinition.subMeshes = new List<Submesh>();
					for (int i = 0; i < subMeshes.Count; i++)
					{
						meshDefinition.subMeshes.Add(new Submesh(new int[subMeshes[i].triangles.Length]));
						subMeshes[i].triangles.CopyTo(meshDefinition.subMeshes[meshDefinition.subMeshes.Count - 1].triangles, 0);
					}
					meshDefinition._mirror = _mirror;
					meshDefinition._offset = _offset;
					meshDefinition._rotation = _rotation;
					meshDefinition._scale = _scale;
					meshDefinition._uvOffset = _uvOffset;
					meshDefinition._uvScale = _uvScale;
					meshDefinition._uvRotation = _uvRotation;
					meshDefinition._flipFaces = _flipFaces;
					meshDefinition._doubleSided = _doubleSided;
					return meshDefinition;
				}

				public MeshDefinition(Mesh input)
				{
					_mesh = input;
					Refresh();
				}

				public void Refresh()
				{
					if (_mesh == null)
					{
						vertices = new Vector3[0];
						normals = new Vector3[0];
						colors = new Color[0];
						uv = new Vector2[0];
						uv2 = new Vector2[0];
						uv3 = new Vector2[0];
						uv4 = new Vector2[0];
						tangents = new Vector4[0];
						triangles = new int[0];
						subMeshes = new List<Submesh>();
						vertexGroups = new List<VertexGroup>();
						return;
					}
					if (vertices.Length != _mesh.vertexCount)
					{
						vertices = new Vector3[_mesh.vertexCount];
					}
					if (normals.Length != _mesh.normals.Length)
					{
						normals = new Vector3[_mesh.normals.Length];
					}
					if (colors.Length != _mesh.colors.Length)
					{
						colors = new Color[_mesh.colors.Length];
					}
					if (uv.Length != _mesh.uv.Length)
					{
						uv = new Vector2[_mesh.uv.Length];
					}
					if (uv2.Length != _mesh.uv2.Length)
					{
						uv2 = new Vector2[_mesh.uv2.Length];
					}
					if (uv3.Length != _mesh.uv3.Length)
					{
						uv3 = new Vector2[_mesh.uv3.Length];
					}
					if (uv4.Length != _mesh.uv4.Length)
					{
						uv4 = new Vector2[_mesh.uv4.Length];
					}
					if (tangents.Length != _mesh.tangents.Length)
					{
						tangents = new Vector4[_mesh.tangents.Length];
					}
					if (triangles.Length != _mesh.triangles.Length)
					{
						triangles = new int[_mesh.triangles.Length];
					}
					vertices = _mesh.vertices;
					normals = _mesh.normals;
					colors = _mesh.colors;
					uv = _mesh.uv;
					uv2 = _mesh.uv2;
					uv3 = _mesh.uv3;
					uv4 = _mesh.uv4;
					tangents = _mesh.tangents;
					triangles = _mesh.triangles;
					colors = _mesh.colors;
					while (subMeshes.Count > _mesh.subMeshCount)
					{
						subMeshes.RemoveAt(0);
					}
					while (subMeshes.Count < _mesh.subMeshCount)
					{
						subMeshes.Add(new Submesh(new int[0]));
					}
					for (int i = 0; i < subMeshes.Count; i++)
					{
						subMeshes[i].triangles = _mesh.GetTriangles(i);
					}
					if (colors.Length != vertices.Length)
					{
						colors = new Color[vertices.Length];
						for (int j = 0; j < colors.Length; j++)
						{
							colors[j] = Color.white;
						}
					}
					Mirror();
					if (_doubleSided)
					{
						DoubleSided();
					}
					else if (_flipFaces)
					{
						FlipFaces();
					}
					TransformVertices();
					CalculateBounds();
					if (_removeInnerFaces)
					{
						RemoveInnerFaces();
					}
					GroupVertices();
					if (bounds.size.z < 0.002f || bounds.size.x < 0.002f || bounds.size.y < 0.002f)
					{
						Debug.LogWarning("The size of [" + _mesh.name + "]'s bounds is too small! This could cause an issue if the [Auto Count] option is enabled!");
					}
				}

				private void RemoveInnerFaces()
				{
					float num = float.MaxValue;
					float num2 = 0f;
					for (int i = 0; i < vertices.Length; i++)
					{
						if (vertices[i].z < num)
						{
							num = vertices[i].z;
						}
						if (vertices[i].z > num2)
						{
							num2 = vertices[i].z;
						}
					}
					for (int j = 0; j < subMeshes.Count; j++)
					{
						List<int> list = new List<int>();
						for (int k = 0; k < subMeshes[j].triangles.Length; k += 3)
						{
							bool flag = true;
							bool flag2 = true;
							for (int l = k; l < k + 3; l++)
							{
								int num3 = subMeshes[j].triangles[l];
								if (!Mathf.Approximately(vertices[num3].z, num2))
								{
									flag = false;
								}
								if (!Mathf.Approximately(vertices[num3].z, num))
								{
									flag2 = false;
								}
							}
							if (!flag && !flag2)
							{
								list.Add(subMeshes[j].triangles[k]);
								list.Add(subMeshes[j].triangles[k + 1]);
								list.Add(subMeshes[j].triangles[k + 2]);
							}
						}
						subMeshes[j].triangles = list.ToArray();
					}
				}

				private void FlipFaces()
				{
					TS_Mesh tS_Mesh = new TS_Mesh();
					tS_Mesh.normals = normals;
					tS_Mesh.tangents = tangents;
					tS_Mesh.triangles = triangles;
					for (int i = 0; i < subMeshes.Count; i++)
					{
						tS_Mesh.subMeshes.Add(subMeshes[i].triangles);
					}
					MeshUtility.FlipFaces(tS_Mesh);
				}

				private void DoubleSided()
				{
					TS_Mesh tS_Mesh = new TS_Mesh();
					tS_Mesh.vertices = vertices;
					tS_Mesh.normals = normals;
					tS_Mesh.tangents = tangents;
					tS_Mesh.colors = colors;
					tS_Mesh.uv = uv;
					tS_Mesh.uv2 = uv2;
					tS_Mesh.uv3 = uv3;
					tS_Mesh.uv4 = uv4;
					tS_Mesh.triangles = triangles;
					for (int i = 0; i < subMeshes.Count; i++)
					{
						tS_Mesh.subMeshes.Add(subMeshes[i].triangles);
					}
					MeshUtility.MakeDoublesided(tS_Mesh);
					vertices = tS_Mesh.vertices;
					normals = tS_Mesh.normals;
					tangents = tS_Mesh.tangents;
					colors = tS_Mesh.colors;
					uv = tS_Mesh.uv;
					uv2 = tS_Mesh.uv2;
					uv3 = tS_Mesh.uv3;
					uv4 = tS_Mesh.uv4;
					triangles = tS_Mesh.triangles;
					for (int j = 0; j < subMeshes.Count; j++)
					{
						subMeshes[j].triangles = tS_Mesh.subMeshes[j];
					}
				}

				public void Write(TS_Mesh target, int forceMaterialId = -1)
				{
					if (target.vertices.Length != vertices.Length)
					{
						target.vertices = new Vector3[vertices.Length];
					}
					if (target.normals.Length != normals.Length)
					{
						target.normals = new Vector3[normals.Length];
					}
					if (target.colors.Length != colors.Length)
					{
						target.colors = new Color[colors.Length];
					}
					if (target.uv.Length != uv.Length)
					{
						target.uv = new Vector2[uv.Length];
					}
					if (target.uv2.Length != uv2.Length)
					{
						target.uv2 = new Vector2[uv2.Length];
					}
					if (target.uv3.Length != uv3.Length)
					{
						target.uv3 = new Vector2[uv3.Length];
					}
					if (target.uv4.Length != uv4.Length)
					{
						target.uv4 = new Vector2[uv4.Length];
					}
					if (target.tangents.Length != tangents.Length)
					{
						target.tangents = new Vector4[tangents.Length];
					}
					if (target.triangles.Length != triangles.Length)
					{
						target.triangles = new int[triangles.Length];
					}
					vertices.CopyTo(target.vertices, 0);
					normals.CopyTo(target.normals, 0);
					colors.CopyTo(target.colors, 0);
					uv.CopyTo(target.uv, 0);
					uv2.CopyTo(target.uv2, 0);
					uv3.CopyTo(target.uv3, 0);
					uv4.CopyTo(target.uv4, 0);
					tangents.CopyTo(target.tangents, 0);
					triangles.CopyTo(target.triangles, 0);
					if (target.subMeshes == null)
					{
						target.subMeshes = new List<int[]>();
					}
					if (forceMaterialId >= 0)
					{
						while (target.subMeshes.Count > forceMaterialId + 1)
						{
							target.subMeshes.RemoveAt(0);
						}
						while (target.subMeshes.Count < forceMaterialId + 1)
						{
							target.subMeshes.Add(new int[0]);
						}
						for (int i = 0; i < target.subMeshes.Count; i++)
						{
							if (i != forceMaterialId)
							{
								if (target.subMeshes[i].Length != 0)
								{
									target.subMeshes[i] = new int[0];
								}
								continue;
							}
							if (target.subMeshes[i].Length != triangles.Length)
							{
								target.subMeshes[i] = new int[triangles.Length];
							}
							triangles.CopyTo(target.subMeshes[i], 0);
						}
						return;
					}
					while (target.subMeshes.Count > subMeshes.Count)
					{
						target.subMeshes.RemoveAt(0);
					}
					while (target.subMeshes.Count < subMeshes.Count)
					{
						target.subMeshes.Add(new int[0]);
					}
					for (int j = 0; j < subMeshes.Count; j++)
					{
						if (subMeshes[j].triangles.Length != target.subMeshes[j].Length)
						{
							target.subMeshes[j] = new int[subMeshes[j].triangles.Length];
						}
						subMeshes[j].triangles.CopyTo(target.subMeshes[j], 0);
					}
				}

				private void CalculateBounds()
				{
					Vector3 zero = Vector3.zero;
					Vector3 zero2 = Vector3.zero;
					for (int i = 0; i < vertices.Length; i++)
					{
						if (vertices[i].x < zero.x)
						{
							zero.x = vertices[i].x;
						}
						else if (vertices[i].x > zero2.x)
						{
							zero2.x = vertices[i].x;
						}
						if (vertices[i].y < zero.y)
						{
							zero.y = vertices[i].y;
						}
						else if (vertices[i].y > zero2.y)
						{
							zero2.y = vertices[i].y;
						}
						if (vertices[i].z < zero.z)
						{
							zero.z = vertices[i].z;
						}
						else if (vertices[i].z > zero2.z)
						{
							zero2.z = vertices[i].z;
						}
					}
					zero.z -= spacing.back;
					zero2.z += spacing.front;
					bounds.CreateFromMinMax(zero, zero2);
				}

				private void Mirror()
				{
					if (_mirror == MirrorMethod.None)
					{
						return;
					}
					switch (_mirror)
					{
					case MirrorMethod.X:
					{
						for (int j = 0; j < vertices.Length; j++)
						{
							vertices[j].x *= -1f;
							normals[j].x = 0f - normals[j].x;
						}
						break;
					}
					case MirrorMethod.Y:
					{
						for (int k = 0; k < vertices.Length; k++)
						{
							vertices[k].y *= -1f;
							normals[k].y = 0f - normals[k].y;
						}
						break;
					}
					case MirrorMethod.Z:
					{
						for (int i = 0; i < vertices.Length; i++)
						{
							vertices[i].z *= -1f;
							normals[i].z = 0f - normals[i].z;
						}
						break;
					}
					}
					for (int l = 0; l < triangles.Length; l += 3)
					{
						int num = triangles[l];
						triangles[l] = triangles[l + 2];
						triangles[l + 2] = num;
					}
					for (int m = 0; m < subMeshes.Count; m++)
					{
						for (int n = 0; n < subMeshes[m].triangles.Length; n += 3)
						{
							int num2 = subMeshes[m].triangles[n];
							subMeshes[m].triangles[n] = subMeshes[m].triangles[n + 2];
							subMeshes[m].triangles[n + 2] = num2;
						}
					}
					CalculateTangents();
				}

				private void TransformVertices()
				{
					Matrix4x4 matrix4x = default(Matrix4x4);
					matrix4x.SetTRS(_offset, Quaternion.Euler(_rotation), _scale);
					Matrix4x4 transpose = matrix4x.inverse.transpose;
					for (int i = 0; i < vertices.Length; i++)
					{
						vertices[i] = matrix4x.MultiplyPoint3x4(vertices[i]);
						normals[i] = transpose.MultiplyVector(normals[i]).normalized;
					}
					for (int j = 0; j < tangents.Length; j++)
					{
						tangents[j] = transpose.MultiplyVector(tangents[j]);
					}
					for (int k = 0; k < uv.Length; k++)
					{
						uv[k].x *= _uvScale.x;
						uv[k].y *= _uvScale.y;
						uv[k] += _uvOffset;
						uv[k] = Quaternion.AngleAxis(uvRotation, Vector3.forward) * uv[k];
					}
				}

				private void GroupVertices()
				{
					vertexGroups = new List<VertexGroup>();
					for (int i = 0; i < vertices.Length; i++)
					{
						float z = vertices[i].z;
						double perc = DMath.Clamp01(DMath.InverseLerp(bounds.min.z, bounds.max.z, z));
						int num = FindInsertIndex(vertices[i], z);
						if (num >= vertexGroups.Count)
						{
							vertexGroups.Add(new VertexGroup(z, perc, new int[1] { i }));
							continue;
						}
						float num2 = Mathf.Abs(vertexGroups[num].value - z);
						if (num2 < vertexGroupingMargin || Mathf.Approximately(num2, vertexGroupingMargin))
						{
							vertexGroups[num].AddId(i);
						}
						else if (vertexGroups[num].value < z)
						{
							vertexGroups.Insert(num, new VertexGroup(z, perc, new int[1] { i }));
						}
						else if (num < vertexGroups.Count - 1)
						{
							vertexGroups.Insert(num + 1, new VertexGroup(z, perc, new int[1] { i }));
						}
						else
						{
							vertexGroups.Add(new VertexGroup(z, perc, new int[1] { i }));
						}
					}
				}

				private int FindInsertIndex(Vector3 pos, float value)
				{
					int num = 0;
					int num2 = vertexGroups.Count - 1;
					while (num <= num2)
					{
						int num3 = num + (num2 - num) / 2;
						if (vertexGroups[num3].value == value)
						{
							return num3;
						}
						if (vertexGroups[num3].value < value)
						{
							num2 = num3 - 1;
						}
						else
						{
							num = num3 + 1;
						}
					}
					return num;
				}

				private void CalculateTangents()
				{
					if (vertices.Length == 0)
					{
						tangents = new Vector4[0];
						return;
					}
					tangents = new Vector4[vertices.Length];
					Vector3[] array = new Vector3[vertices.Length];
					Vector3[] array2 = new Vector3[vertices.Length];
					for (int i = 0; i < subMeshes.Count; i++)
					{
						for (int j = 0; j < subMeshes[i].triangles.Length; j += 3)
						{
							int num = subMeshes[i].triangles[j];
							int num2 = subMeshes[i].triangles[j + 1];
							int num3 = subMeshes[i].triangles[j + 2];
							float num4 = vertices[num2].x - vertices[num].x;
							float num5 = vertices[num3].x - vertices[num].x;
							float num6 = vertices[num2].y - vertices[num].y;
							float num7 = vertices[num3].y - vertices[num].y;
							float num8 = vertices[num2].z - vertices[num].z;
							float num9 = vertices[num3].z - vertices[num].z;
							float num10 = uv[num2].x - uv[num].x;
							float num11 = uv[num3].x - uv[num].x;
							float num12 = uv[num2].y - uv[num].y;
							float num13 = uv[num3].y - uv[num].y;
							float num14 = num10 * num13 - num11 * num12;
							float num15 = ((num14 == 0f) ? 0f : (1f / num14));
							Vector3 vector = new Vector3((num13 * num4 - num12 * num5) * num15, (num13 * num6 - num12 * num7) * num15, (num13 * num8 - num12 * num9) * num15);
							Vector3 vector2 = new Vector3((num10 * num5 - num11 * num4) * num15, (num10 * num7 - num11 * num6) * num15, (num10 * num9 - num11 * num8) * num15);
							array[num] += vector;
							array[num2] += vector;
							array[num3] += vector;
							array2[num] += vector2;
							array2[num2] += vector2;
							array2[num3] += vector2;
						}
					}
					for (int k = 0; k < vertices.Length; k++)
					{
						Vector3 normal = normals[k];
						Vector3 tangent = array[k];
						Vector3.OrthoNormalize(ref normal, ref tangent);
						tangents[k].x = tangent.x;
						tangents[k].y = tangent.y;
						tangents[k].z = tangent.z;
						tangents[k].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array2[k]) < 0f) ? (-1f) : 1f);
					}
				}
			}

			public string name = "Channel";

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
			private List<MeshDefinition> meshes = new List<MeshDefinition>();

			[SerializeField]
			[HideInInspector]
			private double _clipFrom;

			[SerializeField]
			[HideInInspector]
			private double _clipTo = 1.0;

			[SerializeField]
			[HideInInspector]
			private bool _randomOrder;

			[SerializeField]
			[HideInInspector]
			private UVOverride _overrideUVs;

			[SerializeField]
			[HideInInspector]
			private Vector2 _uvScale = Vector2.one;

			[SerializeField]
			[HideInInspector]
			private Vector2 _uvOffset = Vector2.zero;

			[SerializeField]
			[HideInInspector]
			private bool _overrideNormal;

			[SerializeField]
			[HideInInspector]
			private Vector3 _customNormal = Vector3.up;

			[SerializeField]
			[HideInInspector]
			private Type _type;

			[SerializeField]
			[HideInInspector]
			private int _count = 1;

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
			private Vector3 _minRotation = Vector3.zero;

			[SerializeField]
			[HideInInspector]
			private Vector3 _maxRotation = Vector3.zero;

			[SerializeField]
			[HideInInspector]
			private bool _randomOffset;

			[SerializeField]
			[HideInInspector]
			private Vector2 _minOffset = Vector2.one;

			[SerializeField]
			[HideInInspector]
			private Vector2 _maxOffset = Vector2.one;

			[SerializeField]
			[HideInInspector]
			private bool _randomScale;

			[SerializeField]
			[HideInInspector]
			private bool _uniformRandomScale;

			[SerializeField]
			[HideInInspector]
			private Vector3 _minScale = Vector3.one;

			[SerializeField]
			[HideInInspector]
			private Vector3 _maxScale = Vector3.one;

			private int iterator;

			[SerializeField]
			[HideInInspector]
			private bool _overrideMaterialID;

			[SerializeField]
			[HideInInspector]
			private int _targetMaterialID;

			[SerializeField]
			[HideInInspector]
			protected MeshScaleModifier _scaleModifier = new MeshScaleModifier();

			public double clipFrom
			{
				get
				{
					return _clipFrom;
				}
				set
				{
					if (value != _clipFrom)
					{
						_clipFrom = value;
						Rebuild();
					}
				}
			}

			public double clipTo
			{
				get
				{
					return _clipTo;
				}
				set
				{
					if (value != _clipTo)
					{
						_clipTo = value;
						Rebuild();
					}
				}
			}

			public bool randomOffset
			{
				get
				{
					return _randomOffset;
				}
				set
				{
					if (value != _randomOffset)
					{
						_randomOffset = value;
						Rebuild();
					}
				}
			}

			public Vector2Handler offsetHandler
			{
				get
				{
					return _offsetHandler;
				}
				set
				{
					if (value != _offsetHandler)
					{
						_offsetHandler = value;
						Rebuild();
					}
				}
			}

			public bool overrideMaterialID
			{
				get
				{
					return _overrideMaterialID;
				}
				set
				{
					if (value != _overrideMaterialID)
					{
						_overrideMaterialID = value;
						Rebuild();
					}
				}
			}

			public int targetMaterialID
			{
				get
				{
					return _targetMaterialID;
				}
				set
				{
					if (value != _targetMaterialID)
					{
						_targetMaterialID = value;
						Rebuild();
					}
				}
			}

			public bool randomRotation
			{
				get
				{
					return _randomRotation;
				}
				set
				{
					if (value != _randomRotation)
					{
						_randomRotation = value;
						Rebuild();
					}
				}
			}

			public QuaternionHandler placeRotationHandler
			{
				get
				{
					return _placeRotationHandler;
				}
				set
				{
					if (value != _placeRotationHandler)
					{
						_placeRotationHandler = value;
						Rebuild();
					}
				}
			}

			public FloatHandler extrudeRotationHandler
			{
				get
				{
					return _extrudeRotationHandler;
				}
				set
				{
					if (value != _extrudeRotationHandler)
					{
						_extrudeRotationHandler = value;
						Rebuild();
					}
				}
			}

			public bool randomScale
			{
				get
				{
					return _randomScale;
				}
				set
				{
					if (value != _randomScale)
					{
						_randomScale = value;
						Rebuild();
					}
				}
			}

			public Vector3Handler scaleHandler
			{
				get
				{
					return _scaleHandler;
				}
				set
				{
					if (value != _scaleHandler)
					{
						_scaleHandler = value;
						Rebuild();
					}
				}
			}

			public bool uniformRandomScale
			{
				get
				{
					return _uniformRandomScale;
				}
				set
				{
					if (value != _uniformRandomScale)
					{
						_uniformRandomScale = value;
						Rebuild();
					}
				}
			}

			public int offsetSeed
			{
				get
				{
					return _offsetSeed;
				}
				set
				{
					if (value != _offsetSeed)
					{
						_offsetSeed = value;
						Rebuild();
					}
				}
			}

			public int rotationSeed
			{
				get
				{
					return _rotationSeed;
				}
				set
				{
					if (value != _rotationSeed)
					{
						_rotationSeed = value;
						Rebuild();
					}
				}
			}

			public int scaleSeed
			{
				get
				{
					return _scaleSeed;
				}
				set
				{
					if (value != _scaleSeed)
					{
						_scaleSeed = value;
						Rebuild();
					}
				}
			}

			public double spacing
			{
				get
				{
					return _spacing;
				}
				set
				{
					if (value != _spacing)
					{
						_spacing = value;
						Rebuild();
					}
				}
			}

			public Vector2 minOffset
			{
				get
				{
					return _minOffset;
				}
				set
				{
					if (value != _minOffset)
					{
						_minOffset = value;
						Rebuild();
					}
				}
			}

			public Vector2 maxOffset
			{
				get
				{
					return _maxOffset;
				}
				set
				{
					if (value != _maxOffset)
					{
						_maxOffset = value;
						Rebuild();
					}
				}
			}

			public Vector3 minRotation
			{
				get
				{
					return _minRotation;
				}
				set
				{
					if (value != _minRotation)
					{
						_minRotation = value;
						Rebuild();
					}
				}
			}

			public Vector3 maxRotation
			{
				get
				{
					return _maxRotation;
				}
				set
				{
					if (value != _maxRotation)
					{
						_maxRotation = value;
						Rebuild();
					}
				}
			}

			public Vector3 minScale
			{
				get
				{
					return _minScale;
				}
				set
				{
					if (value != _minScale)
					{
						_minScale = value;
						Rebuild();
					}
				}
			}

			public Vector3 maxScale
			{
				get
				{
					return _maxScale;
				}
				set
				{
					if (value != _maxScale)
					{
						_maxScale = value;
						Rebuild();
					}
				}
			}

			public Type type
			{
				get
				{
					return _type;
				}
				set
				{
					if (value != _type)
					{
						_type = value;
						Rebuild();
					}
				}
			}

			public bool randomOrder
			{
				get
				{
					return _randomOrder;
				}
				set
				{
					if (value != _randomOrder)
					{
						_randomOrder = value;
						Rebuild();
					}
				}
			}

			public int randomSeed
			{
				get
				{
					return _iterationSeed;
				}
				set
				{
					if (value != _iterationSeed)
					{
						_iterationSeed = value;
						if (_randomOrder)
						{
							Rebuild();
						}
					}
				}
			}

			public int count
			{
				get
				{
					return _count;
				}
				set
				{
					if (value != _count)
					{
						_count = value;
						if (_count < 1)
						{
							_count = 1;
						}
						Rebuild();
					}
				}
			}

			public bool autoCount
			{
				get
				{
					return _autoCount;
				}
				set
				{
					if (value != _autoCount)
					{
						_autoCount = value;
						Rebuild();
					}
				}
			}

			public UVOverride overrideUVs
			{
				get
				{
					return _overrideUVs;
				}
				set
				{
					if (value != _overrideUVs)
					{
						_overrideUVs = value;
						Rebuild();
					}
				}
			}

			public Vector2 uvOffset
			{
				get
				{
					return _uvOffset;
				}
				set
				{
					if (value != _uvOffset)
					{
						_uvOffset = value;
						Rebuild();
					}
				}
			}

			public Vector2 uvScale
			{
				get
				{
					return _uvScale;
				}
				set
				{
					if (value != _uvScale)
					{
						_uvScale = value;
						Rebuild();
					}
				}
			}

			public bool overrideNormal
			{
				get
				{
					return _overrideNormal;
				}
				set
				{
					if (value != _overrideNormal)
					{
						_overrideNormal = value;
						Rebuild();
					}
				}
			}

			public Vector3 customNormal
			{
				get
				{
					return _customNormal;
				}
				set
				{
					if (value != _customNormal)
					{
						_customNormal = value;
						Rebuild();
					}
				}
			}

			public MeshScaleModifier scaleModifier => _scaleModifier;

			public Channel(string n, SplineMesh parent)
			{
				name = n;
				owner = parent;
				Init();
			}

			public Channel(string n, Mesh inputMesh, SplineMesh parent)
			{
				name = n;
				owner = parent;
				meshes.Add(new MeshDefinition(inputMesh));
				Init();
				Rebuild();
			}

			private void Init()
			{
				_minScale = (_maxScale = Vector3.one);
				_minOffset = (_maxOffset = Vector3.zero);
				_minRotation = (_maxRotation = Vector3.zero);
			}

			public void CopyTo(Channel target)
			{
				target.meshes.Clear();
				for (int i = 0; i < meshes.Count; i++)
				{
					target.meshes.Add(meshes[i].Copy());
				}
				target._clipFrom = _clipFrom;
				target._clipTo = _clipTo;
				target._customNormal = _customNormal;
				target._iterationSeed = _iterationSeed;
				target._minOffset = _minOffset;
				target._minRotation = _minRotation;
				target._minScale = _minScale;
				target._maxOffset = _maxOffset;
				target._maxRotation = _maxRotation;
				target._maxScale = _maxScale;
				target._randomOffset = _randomOffset;
				target._randomRotation = _randomRotation;
				target._randomScale = _randomScale;
				target._offsetSeed = _offsetSeed;
				target._offsetHandler = _offsetHandler;
				target._rotationSeed = _rotationSeed;
				target._placeRotationHandler = _placeRotationHandler;
				target._extrudeRotationHandler = _extrudeRotationHandler;
				target._scaleSeed = _scaleSeed;
				target._scaleHandler = _scaleHandler;
				target._iterationSeed = _iterationSeed;
				target._count = _count;
				target._spacing = _spacing;
				target._overrideUVs = _overrideUVs;
				target._type = _type;
				target._overrideMaterialID = _overrideMaterialID;
				target._targetMaterialID = _targetMaterialID;
				target._overrideNormal = _overrideNormal;
			}

			public int GetMeshCount()
			{
				return meshes.Count;
			}

			public void SwapMeshes(int a, int b)
			{
				if (a >= 0 && a < meshes.Count && b >= 0 && b < meshes.Count)
				{
					MeshDefinition value = meshes[b];
					meshes[b] = meshes[a];
					meshes[a] = value;
					Rebuild();
				}
			}

			public void DuplicateMesh(int index)
			{
				if (index >= 0 && index < meshes.Count)
				{
					meshes.Add(meshes[index].Copy());
					Rebuild();
				}
			}

			public MeshDefinition GetMesh(int index)
			{
				return meshes[index];
			}

			public void AddMesh(Mesh input)
			{
				meshes.Add(new MeshDefinition(input));
				Rebuild();
			}

			public void AddMesh(MeshDefinition meshDefinition)
			{
				if (!meshes.Contains(meshDefinition))
				{
					meshes.Add(meshDefinition);
					Rebuild();
				}
			}

			public void RemoveMesh(int index)
			{
				meshes.RemoveAt(index);
				Rebuild();
			}

			public void ResetIteration()
			{
				if (_randomOrder)
				{
					iterationRandom = new System.Random(_iterationSeed);
				}
				if (_randomOffset)
				{
					_offsetRandom = new System.Random(_offsetSeed);
				}
				if (_randomRotation)
				{
					_rotationRandom = new System.Random(_rotationSeed);
				}
				if (_randomScale)
				{
					_scaleRandom = new System.Random(_scaleSeed);
				}
				iterator = 0;
			}

			public (Vector2, Quaternion, Vector3) GetCustomPlaceValues(double percent)
			{
				(Vector2, Quaternion, Vector3) result = (Vector2.zero, Quaternion.identity, Vector3.one);
				if (_offsetHandler != null)
				{
					result.Item1 = _offsetHandler(percent);
				}
				if (_placeRotationHandler != null)
				{
					result.Item2 = _placeRotationHandler(percent);
				}
				if (_scaleHandler != null)
				{
					result.Item3 = _scaleHandler(percent);
				}
				return result;
			}

			public (Vector2, float, Vector3) GetCustomExtrudeValues(double percent)
			{
				(Vector2, float, Vector3) result = (Vector2.zero, 0f, Vector3.one);
				if (_offsetHandler != null)
				{
					result.Item1 = _offsetHandler(percent);
				}
				if (_extrudeRotationHandler != null)
				{
					result.Item2 = _extrudeRotationHandler(percent);
				}
				if (_scaleHandler != null)
				{
					result.Item3 = _scaleHandler(percent);
				}
				return result;
			}

			public Vector2 NextRandomOffset()
			{
				if (_randomOffset)
				{
					return new Vector2(Mathf.Lerp(_minOffset.x, _maxOffset.x, (float)_offsetRandom.NextDouble()), Mathf.Lerp(_minOffset.y, _maxOffset.y, (float)_offsetRandom.NextDouble()));
				}
				return _minOffset;
			}

			public Quaternion NextRandomQuaternion()
			{
				if (_randomRotation)
				{
					return Quaternion.Euler(new Vector3(Mathf.Lerp(_minRotation.x, _maxRotation.x, (float)_rotationRandom.NextDouble()), Mathf.Lerp(_minRotation.y, _maxRotation.y, (float)_rotationRandom.NextDouble()), Mathf.Lerp(_minRotation.z, _maxRotation.z, (float)_rotationRandom.NextDouble())));
				}
				return Quaternion.Euler(_minRotation);
			}

			public float NextRandomAngle()
			{
				if (_randomRotation)
				{
					return Mathf.Lerp(_minRotation.z, _maxRotation.z, (float)_rotationRandom.NextDouble());
				}
				return _minRotation.z;
			}

			public Vector3 NextRandomScale()
			{
				if (_randomScale)
				{
					if (_uniformRandomScale)
					{
						return Vector3.Lerp(new Vector3(_minScale.x, _minScale.y, 1f), new Vector3(_maxScale.x, _maxScale.y, 1f), (float)_scaleRandom.NextDouble());
					}
					return new Vector3(Mathf.Lerp(_minScale.x, _maxScale.x, (float)_scaleRandom.NextDouble()), Mathf.Lerp(_minScale.y, _maxScale.y, (float)_scaleRandom.NextDouble()), 1f);
				}
				return new Vector3(_minScale.x, _minScale.y, 1f);
			}

			public Vector3 NextPlaceScale()
			{
				if (_randomScale)
				{
					if (_uniformRandomScale)
					{
						return Vector3.Lerp(_minScale, _maxScale, (float)_scaleRandom.NextDouble());
					}
					return new Vector3(Mathf.Lerp(_minScale.x, _maxScale.x, (float)_scaleRandom.NextDouble()), Mathf.Lerp(_minScale.y, _maxScale.y, (float)_scaleRandom.NextDouble()), Mathf.Lerp(_minScale.z, _maxScale.z, (float)_scaleRandom.NextDouble()));
				}
				return _minScale;
			}

			public MeshDefinition NextMesh()
			{
				if (_randomOrder)
				{
					return meshes[iterationRandom.Next(meshes.Count)];
				}
				if (iterator >= meshes.Count)
				{
					iterator = 0;
				}
				return meshes[iterator++];
			}

			internal void Rebuild()
			{
				if (owner != null)
				{
					owner.Rebuild();
				}
			}

			private void Refresh()
			{
				for (int i = 0; i < meshes.Count; i++)
				{
					meshes[i].Refresh();
				}
				Rebuild();
			}
		}

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("channels")]
		private List<Channel> _channels = new List<Channel>();

		private bool _useLastResult;

		private List<TS_Mesh> _combineMeshes = new List<TS_Mesh>();

		private Matrix4x4 _vertexMatrix;

		private Matrix4x4 _normalMatrix;

		private SplineSample _lastResult;

		private SplineSample _modifiedResult;

		protected override string meshName => "Custom Mesh";

		protected override void Awake()
		{
			base.Awake();
		}

		protected override void Reset()
		{
			base.Reset();
			AddChannel("Channel 1");
		}

		public void RemoveChannel(int index)
		{
			_channels.RemoveAt(index);
			Rebuild();
		}

		public void SwapChannels(int a, int b)
		{
			if (a >= 0 && a < _channels.Count && b >= 0 && b < _channels.Count)
			{
				Channel value = _channels[b];
				_channels[b] = _channels[a];
				_channels[a] = value;
				Rebuild();
			}
		}

		public Channel AddChannel(Mesh inputMesh, string name)
		{
			Channel channel = new Channel(name, inputMesh, this);
			_channels.Add(channel);
			return channel;
		}

		public Channel AddChannel(string name)
		{
			Channel channel = new Channel(name, this);
			_channels.Add(channel);
			return channel;
		}

		public int GetChannelCount()
		{
			return _channels.Count;
		}

		public Channel GetChannel(int index)
		{
			return _channels[index];
		}

		protected override void BuildMesh()
		{
			base.BuildMesh();
			Generate();
		}

		private void Generate()
		{
			int num = 0;
			for (int i = 0; i < _channels.Count; i++)
			{
				if (_channels[i].GetMeshCount() == 0)
				{
					continue;
				}
				if (_channels[i].autoCount)
				{
					float num2 = 0f;
					for (int j = 0; j < _channels[i].GetMeshCount(); j++)
					{
						num2 += _channels[i].GetMesh(j).bounds.size.z;
					}
					if (_channels[i].GetMeshCount() > 1)
					{
						num2 /= (float)_channels[i].GetMeshCount();
					}
					if (num2 > 0f)
					{
						int num3 = Mathf.RoundToInt(CalculateLength(_channels[i].clipFrom, _channels[i].clipTo, preventInvert: false) / num2);
						if (num3 < 1)
						{
							num3 = 1;
						}
						_channels[i].count = num3;
					}
				}
				num += _channels[i].count;
			}
			if (num == 0)
			{
				base._tsMesh.Clear();
				return;
			}
			if (_combineMeshes.Count < num)
			{
				_combineMeshes.AddRange(new TS_Mesh[num - _combineMeshes.Count]);
			}
			else if (_combineMeshes.Count > num)
			{
				_combineMeshes.RemoveRange(_combineMeshes.Count - 1 - (_combineMeshes.Count - num), _combineMeshes.Count - num);
			}
			int num4 = 0;
			for (int k = 0; k < _channels.Count; k++)
			{
				if (_channels[k].GetMeshCount() == 0)
				{
					continue;
				}
				_channels[k].ResetIteration();
				_useLastResult = false;
				double num5 = 1.0 / (double)_channels[k].count;
				double num6 = num5 * _channels[k].spacing * 0.5;
				switch (_channels[k].type)
				{
				case Channel.Type.Extrude:
				{
					for (int m = 0; m < _channels[k].count; m++)
					{
						double num7 = DMath.Lerp(_channels[k].clipFrom, _channels[k].clipTo, (double)m * num5 + num6);
						double to = DMath.Lerp(_channels[k].clipFrom, _channels[k].clipTo, (double)m * num5 + num5 - num6);
						if (_combineMeshes[num4] == null)
						{
							_combineMeshes[num4] = new TS_Mesh();
						}
						Extrude(_channels[k], _combineMeshes[num4], num7, to);
						num4++;
					}
					if (num6 == 0.0)
					{
						_useLastResult = true;
					}
					break;
				}
				case Channel.Type.Place:
				{
					for (int l = 0; l < _channels[k].count; l++)
					{
						if (_combineMeshes[num4] == null)
						{
							_combineMeshes[num4] = new TS_Mesh();
						}
						Place(_channels[k], _combineMeshes[num4], DMath.Lerp(_channels[k].clipFrom, _channels[k].clipTo, (double)l / (double)Mathf.Max(_channels[k].count - 1, 1)));
						num4++;
					}
					break;
				}
				}
			}
			base._tsMesh.Combine(_combineMeshes);
		}

		private void Place(Channel channel, TS_Mesh target, double percent)
		{
			Channel.MeshDefinition meshDefinition = channel.NextMesh();
			if (target == null)
			{
				target = new TS_Mesh();
			}
			meshDefinition.Write(target, channel.overrideMaterialID ? channel.targetMaterialID : (-1));
			Vector2 vector = channel.NextRandomOffset();
			Quaternion quaternion = channel.NextRandomQuaternion();
			(Vector2, Quaternion, Vector3) customPlaceValues = channel.GetCustomPlaceValues(percent);
			Vector2 vector2 = vector + customPlaceValues.Item1 + new Vector2(base.offset.x, base.offset.y);
			Quaternion quaternion2 = quaternion * Quaternion.AngleAxis(base.rotation, Vector3.forward) * customPlaceValues.Item2;
			Vector3 vector3 = channel.NextPlaceScale();
			Evaluate(percent, ref evalResult);
			ModifySample(ref evalResult);
			Vector3 up = evalResult.up;
			Vector3 right = evalResult.right;
			Vector3 forward = evalResult.forward;
			if (channel.overrideNormal)
			{
				evalResult.forward = Vector3.Cross(evalResult.right, channel.customNormal);
				evalResult.up = channel.customNormal;
			}
			if (!channel.scaleModifier.useClippedPercent)
			{
				UnclipPercent(ref evalResult.percent);
			}
			Vector3 scale = channel.scaleModifier.GetScale(evalResult);
			vector3.x *= customPlaceValues.Item3.x * scale.x;
			vector3.y *= customPlaceValues.Item3.y * scale.y;
			vector3.z *= customPlaceValues.Item3.z * scale.z;
			if (!channel.scaleModifier.useClippedPercent)
			{
				ClipPercent(ref evalResult.percent);
			}
			float baseSize = GetBaseSize(evalResult);
			_vertexMatrix.SetTRS(evalResult.position + right * (vector2.x * baseSize) + up * (vector2.y * baseSize) + forward * base.offset.z, evalResult.rotation * quaternion2, vector3 * baseSize);
			_normalMatrix = _vertexMatrix.inverse.transpose;
			for (int i = 0; i < target.vertexCount; i++)
			{
				target.vertices[i] = _vertexMatrix.MultiplyPoint3x4(meshDefinition.vertices[i]);
				target.normals[i] = _normalMatrix.MultiplyVector(meshDefinition.normals[i]);
			}
			for (int j = 0; j < Mathf.Min(target.colors.Length, meshDefinition.colors.Length); j++)
			{
				target.colors[j] = meshDefinition.colors[j] * evalResult.color * base.color;
			}
		}

		private void Extrude(Channel channel, TS_Mesh target, double from, double to)
		{
			Channel.MeshDefinition meshDefinition = channel.NextMesh();
			if (target == null)
			{
				target = new TS_Mesh();
			}
			meshDefinition.Write(target, channel.overrideMaterialID ? channel.targetMaterialID : (-1));
			Vector2 zero = Vector2.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 vector = channel.NextRandomOffset();
			Vector3 vector2 = channel.NextRandomScale();
			float num = channel.NextRandomAngle();
			for (int i = 0; i < meshDefinition.vertexGroups.Count; i++)
			{
				if (_useLastResult && i == meshDefinition.vertexGroups.Count)
				{
					evalResult = _lastResult;
				}
				else
				{
					Evaluate(DMath.Lerp(from, to, meshDefinition.vertexGroups[i].percent), ref evalResult);
				}
				ModifySample(ref evalResult, ref _modifiedResult);
				Vector3 up = _modifiedResult.up;
				Vector3 right = _modifiedResult.right;
				Vector3 forward = _modifiedResult.forward;
				if (channel.overrideNormal)
				{
					_modifiedResult.forward = Vector3.Cross(_modifiedResult.right, channel.customNormal);
					_modifiedResult.up = channel.customNormal;
				}
				(Vector2, float, Vector3) customExtrudeValues = channel.GetCustomExtrudeValues(_modifiedResult.percent);
				Vector3 vector3 = base.offset + vector + (Vector3)customExtrudeValues.Item1;
				float angle = base.rotation + num + customExtrudeValues.Item2;
				Vector3 vector4 = vector2;
				if (!channel.scaleModifier.useClippedPercent)
				{
					UnclipPercent(ref _modifiedResult.percent);
				}
				Vector2 vector5 = channel.scaleModifier.GetScale(_modifiedResult);
				if (!channel.scaleModifier.useClippedPercent)
				{
					ClipPercent(ref _modifiedResult.percent);
				}
				vector4.x *= customExtrudeValues.Item3.x * vector5.x;
				vector4.y *= customExtrudeValues.Item3.y * vector5.y;
				vector4.z = 1f;
				float num2 = _modifiedResult.size;
				_vertexMatrix.SetTRS(_modifiedResult.position + right * (vector3.x * num2) + up * (vector3.y * num2) + forward * base.offset.z, _modifiedResult.rotation * Quaternion.AngleAxis(angle, Vector3.forward), vector4 * num2);
				_normalMatrix = _vertexMatrix.inverse.transpose;
				if (i == 0)
				{
					_lastResult = evalResult;
				}
				for (int j = 0; j < meshDefinition.vertexGroups[i].ids.Length; j++)
				{
					int num3 = meshDefinition.vertexGroups[i].ids[j];
					zero2 = meshDefinition.vertices[num3];
					zero2.z = 0f;
					target.vertices[num3] = _vertexMatrix.MultiplyPoint3x4(zero2);
					zero2 = meshDefinition.normals[num3];
					target.normals[num3] = _normalMatrix.MultiplyVector(zero2);
					target.colors[num3] = target.colors[num3] * _modifiedResult.color * base.color;
					if (target.uv.Length > num3)
					{
						zero = target.uv[num3];
						switch (channel.overrideUVs)
						{
						case Channel.UVOverride.ClampU:
							zero.x = (float)_modifiedResult.percent;
							break;
						case Channel.UVOverride.ClampV:
							zero.y = (float)_modifiedResult.percent;
							break;
						case Channel.UVOverride.UniformU:
							zero.x = CalculateLength(0.0, ClipPercent(_modifiedResult.percent));
							break;
						case Channel.UVOverride.UniformV:
							zero.y = CalculateLength(0.0, ClipPercent(_modifiedResult.percent));
							break;
						}
						target.uv[num3] = new Vector2(zero.x * base.uvScale.x * channel.uvScale.x, zero.y * base.uvScale.y * channel.uvScale.y);
						target.uv[num3] += base.uvOffset + channel.uvOffset;
					}
				}
			}
		}
	}
}
