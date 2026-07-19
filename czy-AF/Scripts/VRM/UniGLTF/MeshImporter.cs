using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace UniGLTF
{
	public class MeshImporter
	{
		[Serializable]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Float4
		{
			public float x;

			public float y;

			public float z;

			public float w;

			public Float4 One()
			{
				float num = x + y + z + w;
				float num2 = 1f / num;
				return new Float4
				{
					x = x * num2,
					y = y * num2,
					z = z * num2,
					w = w * num2
				};
			}
		}

		public class MeshContext
		{
			public string name;

			public Vector3[] positions;

			public Vector3[] normals;

			public Vector4[] tangents;

			public Vector2[] uv;

			public Color[] colors;

			public List<BoneWeight> boneWeights = new List<BoneWeight>();

			public List<int[]> subMeshes = new List<int[]>();

			public List<int> materialIndices = new List<int>();

			public List<BlendShape> blendShapes = new List<BlendShape>();
		}

		private const float FRAME_WEIGHT = 100f;

		private static MeshContext _ImportMeshSharingMorphTarget(ImporterContext ctx, glTFMesh gltfMesh)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector4> list3 = new List<Vector4>();
			List<Vector2> list4 = new List<Vector2>();
			List<Color> list5 = new List<Color>();
			List<BlendShape> list6 = new List<BlendShape>();
			MeshContext meshContext = new MeshContext();
			List<string> targetNames = gltfMesh.extras.targetNames;
			for (int i = 1; i < gltfMesh.primitives.Count; i++)
			{
				if (gltfMesh.primitives[i].targets.Count != targetNames.Count)
				{
					throw new FormatException($"different targets length: {gltfMesh.primitives[i]} with targetNames length.");
				}
			}
			for (int j = 0; j < targetNames.Count; j++)
			{
				BlendShape item = new BlendShape((!string.IsNullOrEmpty(targetNames[j])) ? targetNames[j] : j.ToString());
				list6.Add(item);
			}
			foreach (glTFPrimitives primitive in gltfMesh.primitives)
			{
				int count = list.Count;
				int indices = primitive.indices;
				int count2 = list.Count;
				list.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(primitive.attributes.POSITION)
					select x.ReverseZ());
				count2 = list.Count - count2;
				if (primitive.attributes.NORMAL != -1)
				{
					list2.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(primitive.attributes.NORMAL)
						select x.ReverseZ());
				}
				if (primitive.attributes.TANGENT != -1)
				{
					list3.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector4>(primitive.attributes.TANGENT)
						select x.ReverseZ());
				}
				if (primitive.attributes.TEXCOORD_0 != -1)
				{
					if (ctx.IsGeneratedUniGLTFAndOlder(1, 16))
					{
						list4.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector2>(primitive.attributes.TEXCOORD_0)
							select x.ReverseY());
					}
					else
					{
						list4.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector2>(primitive.attributes.TEXCOORD_0)
							select x.ReverseUV());
					}
				}
				else
				{
					list4.AddRange(new Vector2[count2]);
				}
				if (primitive.attributes.COLOR_0 != -1)
				{
					list5.AddRange(ctx.GLTF.GetArrayFromAccessor<Color>(primitive.attributes.COLOR_0));
				}
				if (primitive.attributes.JOINTS_0 != -1 && primitive.attributes.WEIGHTS_0 != -1)
				{
					UShort4[] arrayFromAccessor = ctx.GLTF.GetArrayFromAccessor<UShort4>(primitive.attributes.JOINTS_0);
					Float4[] array = (from x in ctx.GLTF.GetArrayFromAccessor<Float4>(primitive.attributes.WEIGHTS_0)
						select x.One()).ToArray();
					for (int num = 0; num < arrayFromAccessor.Length; num++)
					{
						BoneWeight item2 = new BoneWeight
						{
							boneIndex0 = arrayFromAccessor[num].x,
							weight0 = array[num].x,
							boneIndex1 = arrayFromAccessor[num].y,
							weight1 = array[num].y,
							boneIndex2 = arrayFromAccessor[num].z,
							weight2 = array[num].z,
							boneIndex3 = arrayFromAccessor[num].w,
							weight3 = array[num].w
						};
						meshContext.boneWeights.Add(item2);
					}
				}
				if (primitive.targets != null && primitive.targets.Count > 0)
				{
					for (int num2 = 0; num2 < primitive.targets.Count; num2++)
					{
						gltfMorphTarget gltfMorphTarget2 = primitive.targets[num2];
						if (gltfMorphTarget2.POSITION != -1)
						{
							list6[num2].Positions.AddRange((from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.POSITION)
								select x.ReverseZ()).ToArray());
						}
						if (gltfMorphTarget2.NORMAL != -1)
						{
							list6[num2].Normals.AddRange((from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.NORMAL)
								select x.ReverseZ()).ToArray());
						}
						if (gltfMorphTarget2.TANGENT != -1)
						{
							list6[num2].Tangents.AddRange((from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.TANGENT)
								select x.ReverseZ()).ToArray());
						}
					}
				}
				int[] array2 = ((indices >= 0) ? ctx.GLTF.GetIndices(indices) : TriangleUtil.FlipTriangle(Enumerable.Range(0, meshContext.positions.Length)).ToArray());
				for (int num3 = 0; num3 < array2.Length; num3++)
				{
					array2[num3] += count;
				}
				meshContext.subMeshes.Add(array2);
				meshContext.materialIndices.Add(primitive.material);
			}
			meshContext.positions = list.ToArray();
			meshContext.normals = list2.ToArray();
			meshContext.tangents = list3.ToArray();
			meshContext.uv = list4.ToArray();
			meshContext.blendShapes = list6;
			return meshContext;
		}

		private static MeshContext _ImportMeshIndependentVertexBuffer(ImporterContext ctx, glTFMesh gltfMesh)
		{
			List<gltfMorphTarget> targets = gltfMesh.primitives[0].targets;
			for (int i = 1; i < gltfMesh.primitives.Count; i++)
			{
				if (!gltfMesh.primitives[i].targets.SequenceEqual(targets))
				{
					throw new NotImplementedException($"different targets: {gltfMesh.primitives[i]} with {targets}");
				}
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector4> list3 = new List<Vector4>();
			List<Vector2> list4 = new List<Vector2>();
			List<Color> list5 = new List<Color>();
			MeshContext meshContext = new MeshContext();
			foreach (glTFPrimitives primitive in gltfMesh.primitives)
			{
				int count = list.Count;
				int indices = primitive.indices;
				int count2 = list.Count;
				list.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(primitive.attributes.POSITION)
					select x.ReverseZ());
				count2 = list.Count - count2;
				if (primitive.attributes.NORMAL != -1)
				{
					list2.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(primitive.attributes.NORMAL)
						select x.ReverseZ());
				}
				if (primitive.attributes.TANGENT != -1)
				{
					list3.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector4>(primitive.attributes.TANGENT)
						select x.ReverseZ());
				}
				if (primitive.attributes.TEXCOORD_0 != -1)
				{
					if (ctx.IsGeneratedUniGLTFAndOlder(1, 16))
					{
						list4.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector2>(primitive.attributes.TEXCOORD_0)
							select x.ReverseY());
					}
					else
					{
						list4.AddRange(from x in ctx.GLTF.GetArrayFromAccessor<Vector2>(primitive.attributes.TEXCOORD_0)
							select x.ReverseUV());
					}
				}
				else
				{
					list4.AddRange(new Vector2[count2]);
				}
				if (primitive.attributes.COLOR_0 != -1)
				{
					list5.AddRange(ctx.GLTF.GetArrayFromAccessor<Color>(primitive.attributes.COLOR_0));
				}
				if (primitive.attributes.JOINTS_0 != -1 && primitive.attributes.WEIGHTS_0 != -1)
				{
					UShort4[] arrayFromAccessor = ctx.GLTF.GetArrayFromAccessor<UShort4>(primitive.attributes.JOINTS_0);
					Float4[] array = (from x in ctx.GLTF.GetArrayFromAccessor<Float4>(primitive.attributes.WEIGHTS_0)
						select x.One()).ToArray();
					for (int num = 0; num < arrayFromAccessor.Length; num++)
					{
						BoneWeight item = new BoneWeight
						{
							boneIndex0 = arrayFromAccessor[num].x,
							weight0 = array[num].x,
							boneIndex1 = arrayFromAccessor[num].y,
							weight1 = array[num].y,
							boneIndex2 = arrayFromAccessor[num].z,
							weight2 = array[num].z,
							boneIndex3 = arrayFromAccessor[num].w,
							weight3 = array[num].w
						};
						meshContext.boneWeights.Add(item);
					}
				}
				if (primitive.targets != null && primitive.targets.Count > 0)
				{
					for (int num2 = 0; num2 < primitive.targets.Count; num2++)
					{
						gltfMorphTarget gltfMorphTarget2 = primitive.targets[num2];
						BlendShape blendShape = new BlendShape((!string.IsNullOrEmpty(primitive.extras.targetNames[num2])) ? primitive.extras.targetNames[num2] : num2.ToString());
						if (gltfMorphTarget2.POSITION != -1)
						{
							blendShape.Positions.AddRange((from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.POSITION)
								select x.ReverseZ()).ToArray());
						}
						if (gltfMorphTarget2.NORMAL != -1)
						{
							blendShape.Normals.AddRange((from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.NORMAL)
								select x.ReverseZ()).ToArray());
						}
						if (gltfMorphTarget2.TANGENT != -1)
						{
							blendShape.Tangents.AddRange((from x in ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.TANGENT)
								select x.ReverseZ()).ToArray());
						}
						meshContext.blendShapes.Add(blendShape);
					}
				}
				int[] array2 = ((indices >= 0) ? ctx.GLTF.GetIndices(indices) : TriangleUtil.FlipTriangle(Enumerable.Range(0, meshContext.positions.Length)).ToArray());
				for (int num3 = 0; num3 < array2.Length; num3++)
				{
					array2[num3] += count;
				}
				meshContext.subMeshes.Add(array2);
				meshContext.materialIndices.Add(primitive.material);
			}
			meshContext.positions = list.ToArray();
			meshContext.normals = list2.ToArray();
			meshContext.tangents = list3.ToArray();
			meshContext.uv = list4.ToArray();
			return meshContext;
		}

		private static MeshContext _ImportMeshSharingVertexBuffer(ImporterContext ctx, glTFMesh gltfMesh)
		{
			MeshContext meshContext = new MeshContext();
			glTFPrimitives prim = gltfMesh.primitives.First();
			meshContext.positions = ctx.GLTF.GetArrayFromAccessor<Vector3>(prim.attributes.POSITION).SelectInplace((Vector3 x) => x.ReverseZ());
			if (prim.attributes.NORMAL != -1)
			{
				meshContext.normals = ctx.GLTF.GetArrayFromAccessor<Vector3>(prim.attributes.NORMAL).SelectInplace((Vector3 x) => x.ReverseZ());
			}
			if (prim.attributes.TANGENT != -1)
			{
				meshContext.tangents = ctx.GLTF.GetArrayFromAccessor<Vector4>(prim.attributes.TANGENT).SelectInplace((Vector4 x) => x.ReverseZ());
			}
			if (prim.attributes.TEXCOORD_0 != -1)
			{
				if (ctx.IsGeneratedUniGLTFAndOlder(1, 16))
				{
					meshContext.uv = ctx.GLTF.GetArrayFromAccessor<Vector2>(prim.attributes.TEXCOORD_0).SelectInplace((Vector2 x) => x.ReverseY());
				}
				else
				{
					meshContext.uv = ctx.GLTF.GetArrayFromAccessor<Vector2>(prim.attributes.TEXCOORD_0).SelectInplace((Vector2 x) => x.ReverseUV());
				}
			}
			else
			{
				meshContext.uv = new Vector2[meshContext.positions.Length];
			}
			if (prim.attributes.COLOR_0 != -1)
			{
				if (ctx.GLTF.accessors[prim.attributes.COLOR_0].TypeCount == 3)
				{
					Vector3[] arrayFromAccessor = ctx.GLTF.GetArrayFromAccessor<Vector3>(prim.attributes.COLOR_0);
					meshContext.colors = new Color[arrayFromAccessor.Length];
					for (int num = 0; num < arrayFromAccessor.Length; num++)
					{
						Vector3 vector = arrayFromAccessor[num];
						meshContext.colors[num] = new Color(vector.x, vector.y, vector.z);
					}
				}
				else
				{
					if (ctx.GLTF.accessors[prim.attributes.COLOR_0].TypeCount != 4)
					{
						throw new NotImplementedException($"unknown color type {ctx.GLTF.accessors[prim.attributes.COLOR_0].type}");
					}
					meshContext.colors = ctx.GLTF.GetArrayFromAccessor<Color>(prim.attributes.COLOR_0);
				}
			}
			if (prim.attributes.JOINTS_0 != -1 && prim.attributes.WEIGHTS_0 != -1)
			{
				UShort4[] arrayFromAccessor2 = ctx.GLTF.GetArrayFromAccessor<UShort4>(prim.attributes.JOINTS_0);
				Float4[] arrayFromAccessor3 = ctx.GLTF.GetArrayFromAccessor<Float4>(prim.attributes.WEIGHTS_0);
				for (int num2 = 0; num2 < arrayFromAccessor3.Length; num2++)
				{
					arrayFromAccessor3[num2] = arrayFromAccessor3[num2].One();
				}
				for (int num3 = 0; num3 < arrayFromAccessor2.Length; num3++)
				{
					BoneWeight item = new BoneWeight
					{
						boneIndex0 = arrayFromAccessor2[num3].x,
						weight0 = arrayFromAccessor3[num3].x,
						boneIndex1 = arrayFromAccessor2[num3].y,
						weight1 = arrayFromAccessor3[num3].y,
						boneIndex2 = arrayFromAccessor2[num3].z,
						weight2 = arrayFromAccessor3[num3].z,
						boneIndex3 = arrayFromAccessor2[num3].w,
						weight3 = arrayFromAccessor3[num3].w
					};
					meshContext.boneWeights.Add(item);
				}
			}
			if (prim.targets != null && prim.targets.Count > 0)
			{
				meshContext.blendShapes.AddRange(prim.targets.Select((gltfMorphTarget x, int i) => new BlendShape((i < prim.extras.targetNames.Count && !string.IsNullOrEmpty(prim.extras.targetNames[i])) ? prim.extras.targetNames[i] : i.ToString())));
				for (int num4 = 0; num4 < prim.targets.Count; num4++)
				{
					gltfMorphTarget gltfMorphTarget2 = prim.targets[num4];
					BlendShape blendShape = meshContext.blendShapes[num4];
					if (gltfMorphTarget2.POSITION != -1)
					{
						blendShape.Positions.Assign(ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.POSITION), (Vector3 x) => x.ReverseZ());
					}
					if (gltfMorphTarget2.NORMAL != -1)
					{
						blendShape.Normals.Assign(ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.NORMAL), (Vector3 x) => x.ReverseZ());
					}
					if (gltfMorphTarget2.TANGENT != -1)
					{
						blendShape.Tangents.Assign(ctx.GLTF.GetArrayFromAccessor<Vector3>(gltfMorphTarget2.TANGENT), (Vector3 x) => x.ReverseZ());
					}
				}
			}
			foreach (glTFPrimitives primitive in gltfMesh.primitives)
			{
				if (primitive.indices == -1)
				{
					meshContext.subMeshes.Add(TriangleUtil.FlipTriangle(Enumerable.Range(0, meshContext.positions.Length)).ToArray());
				}
				else
				{
					int[] indices = ctx.GLTF.GetIndices(primitive.indices);
					meshContext.subMeshes.Add(indices);
				}
				meshContext.materialIndices.Add(primitive.material);
			}
			return meshContext;
		}

		public MeshContext ReadMesh(ImporterContext ctx, int meshIndex)
		{
			glTFMesh glTFMesh2 = ctx.GLTF.meshes[meshIndex];
			MeshContext meshContext;
			if (glTFMesh2.extras != null && glTFMesh2.extras.targetNames.Count > 0)
			{
				meshContext = _ImportMeshSharingMorphTarget(ctx, glTFMesh2);
			}
			else
			{
				glTFAttributes glTFAttributes2 = null;
				bool flag = true;
				foreach (glTFPrimitives primitive in glTFMesh2.primitives)
				{
					if (glTFAttributes2 != null && !primitive.attributes.Equals(glTFAttributes2))
					{
						flag = false;
						break;
					}
					glTFAttributes2 = primitive.attributes;
				}
				meshContext = (flag ? _ImportMeshSharingVertexBuffer(ctx, glTFMesh2) : _ImportMeshIndependentVertexBuffer(ctx, glTFMesh2));
			}
			meshContext.name = glTFMesh2.name;
			if (string.IsNullOrEmpty(meshContext.name))
			{
				meshContext.name = $"UniGLTF import#{meshIndex}";
			}
			return meshContext;
		}

		public static MeshWithMaterials BuildMesh(ImporterContext ctx, MeshContext meshContext)
		{
			if (!meshContext.materialIndices.Any())
			{
				meshContext.materialIndices.Add(0);
			}
			Mesh mesh = new Mesh();
			mesh.name = meshContext.name;
			if (meshContext.positions.Length > 65535)
			{
				mesh.indexFormat = IndexFormat.UInt32;
			}
			mesh.vertices = meshContext.positions;
			bool flag = false;
			if (meshContext.normals != null && meshContext.normals.Length != 0)
			{
				mesh.normals = meshContext.normals;
			}
			else
			{
				flag = true;
			}
			if (meshContext.uv != null && meshContext.uv.Length != 0)
			{
				mesh.uv = meshContext.uv;
			}
			bool flag2 = true;
			if (meshContext.colors != null && meshContext.colors.Length != 0)
			{
				mesh.colors = meshContext.colors;
			}
			if (meshContext.boneWeights != null && meshContext.boneWeights.Count > 0)
			{
				mesh.boneWeights = meshContext.boneWeights.ToArray();
			}
			mesh.subMeshCount = meshContext.subMeshes.Count;
			for (int i = 0; i < meshContext.subMeshes.Count; i++)
			{
				mesh.SetTriangles(meshContext.subMeshes[i], i);
			}
			if (flag)
			{
				mesh.RecalculateNormals();
			}
			if (flag2)
			{
				mesh.RecalculateTangents();
			}
			MeshWithMaterials result = new MeshWithMaterials
			{
				Mesh = mesh,
				Materials = meshContext.materialIndices.Select((int x) => ctx.GetMaterial(x)).ToArray()
			};
			if (meshContext.blendShapes != null)
			{
				Vector3[] array = null;
				foreach (BlendShape blendShape in meshContext.blendShapes)
				{
					if (blendShape.Positions.Count > 0)
					{
						if (blendShape.Positions.Count == mesh.vertexCount)
						{
							mesh.AddBlendShapeFrame(blendShape.Name, 100f, blendShape.Positions.ToArray(), (meshContext.normals != null && meshContext.normals.Length == mesh.vertexCount && blendShape.Normals.Count() == blendShape.Positions.Count()) ? blendShape.Normals.ToArray() : null, null);
							continue;
						}
						Debug.LogWarningFormat("May be partial primitive has blendShape. Require separate mesh or extend blend shape, but not implemented: {0}", blendShape.Name);
					}
					else
					{
						if (array == null)
						{
							array = new Vector3[mesh.vertexCount];
						}
						mesh.AddBlendShapeFrame(blendShape.Name, 100f, array, null, null);
					}
				}
			}
			return result;
		}

		public static IEnumerator BuildMeshCoroutine(ImporterContext ctx, MeshContext meshContext)
		{
			if (!meshContext.materialIndices.Any())
			{
				meshContext.materialIndices.Add(0);
			}
			Mesh mesh = new Mesh
			{
				name = meshContext.name
			};
			if (meshContext.positions.Length > 65535)
			{
				mesh.indexFormat = IndexFormat.UInt32;
			}
			mesh.vertices = meshContext.positions;
			bool flag = false;
			if (meshContext.normals != null && meshContext.normals.Length != 0)
			{
				mesh.normals = meshContext.normals;
			}
			else
			{
				flag = true;
			}
			if (meshContext.uv != null && meshContext.uv.Length != 0)
			{
				mesh.uv = meshContext.uv;
			}
			bool flag2 = true;
			if (meshContext.colors != null && meshContext.colors.Length != 0)
			{
				mesh.colors = meshContext.colors;
			}
			if (meshContext.boneWeights != null && meshContext.boneWeights.Count > 0)
			{
				mesh.boneWeights = meshContext.boneWeights.ToArray();
			}
			mesh.subMeshCount = meshContext.subMeshes.Count;
			for (int i = 0; i < meshContext.subMeshes.Count; i++)
			{
				mesh.SetTriangles(meshContext.subMeshes[i], i);
			}
			if (flag)
			{
				mesh.RecalculateNormals();
			}
			if (flag2)
			{
				yield return null;
				mesh.RecalculateTangents();
				yield return null;
			}
			MeshWithMaterials result = new MeshWithMaterials
			{
				Mesh = mesh,
				Materials = meshContext.materialIndices.Select((int x) => ctx.GetMaterial(x)).ToArray()
			};
			yield return null;
			if (meshContext.blendShapes != null)
			{
				Vector3[] emptyVertices = null;
				foreach (BlendShape blendShape in meshContext.blendShapes)
				{
					if (blendShape.Positions.Count > 0)
					{
						if (blendShape.Positions.Count == mesh.vertexCount)
						{
							mesh.AddBlendShapeFrame(blendShape.Name, 100f, blendShape.Positions.ToArray(), (meshContext.normals != null && meshContext.normals.Length == mesh.vertexCount && blendShape.Normals.Count() == blendShape.Positions.Count()) ? blendShape.Normals.ToArray() : null, null);
							yield return null;
						}
						else
						{
							Debug.LogWarningFormat("May be partial primitive has blendShape. Require separate mesh or extend blend shape, but not implemented: {0}", blendShape.Name);
						}
					}
					else
					{
						if (emptyVertices == null)
						{
							emptyVertices = new Vector3[mesh.vertexCount];
						}
						mesh.AddBlendShapeFrame(blendShape.Name, 100f, emptyVertices, null, null);
						yield return null;
					}
				}
			}
			yield return result;
		}

		public static void CalcTangents(Mesh mesh)
		{
			int vertexCount = mesh.vertexCount;
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			Vector2[] uv = mesh.uv;
			int[] triangles = mesh.triangles;
			int num = triangles.Length / 3;
			Vector4[] array = new Vector4[vertexCount];
			Vector3[] array2 = new Vector3[vertexCount];
			Vector3[] array3 = new Vector3[vertexCount];
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				int num3 = triangles[num2];
				int num4 = triangles[num2 + 1];
				int num5 = triangles[num2 + 2];
				Vector3 vector = vertices[num3];
				Vector3 vector2 = vertices[num4];
				Vector3 vector3 = vertices[num5];
				Vector2 vector4 = uv[num3];
				Vector2 vector5 = uv[num4];
				Vector2 vector6 = uv[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = 1f / (num12 * num15 - num13 * num14);
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num16, (num15 * num8 - num14 * num9) * num16, (num15 * num10 - num14 * num11) * num16);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num16, (num12 * num9 - num13 * num8) * num16, (num12 * num11 - num13 * num10) * num16);
				array2[num3] += vector7;
				array2[num4] += vector7;
				array2[num5] += vector7;
				array3[num3] += vector8;
				array3[num4] += vector8;
				array3[num5] += vector8;
				num2 += 3;
			}
			for (int j = 0; j < vertexCount; j++)
			{
				Vector3 normal = normals[j];
				Vector3 tangent = array2[j];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				array[j].x = tangent.x;
				array[j].y = tangent.y;
				array[j].z = tangent.z;
				array[j].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array3[j]) < 0f) ? (-1f) : 1f);
			}
			mesh.tangents = array;
		}
	}
}
