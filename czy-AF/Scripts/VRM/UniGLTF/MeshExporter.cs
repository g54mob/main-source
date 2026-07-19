using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public static class MeshExporter
	{
		private static glTFMesh ExportPrimitives(glTF gltf, int bufferIndex, string rendererName, Mesh mesh, Material[] materials, List<Material> unityMaterials, bool removeVertexColor)
		{
			Vector3[] array = mesh.vertices.Select((Vector3 y) => y.ReverseZ()).ToArray();
			int num = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, array, glBufferTarget.ARRAY_BUFFER);
			gltf.accessors[num].min = array.Aggregate(array[0], (Vector3 a, Vector3 b) => new Vector3(Mathf.Min(a.x, b.x), Math.Min(a.y, b.y), Mathf.Min(a.z, b.z))).ToArray();
			gltf.accessors[num].max = array.Aggregate(array[0], (Vector3 a, Vector3 b) => new Vector3(Mathf.Max(a.x, b.x), Math.Max(a.y, b.y), Mathf.Max(a.z, b.z))).ToArray();
			int num2 = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, mesh.normals.Select((Vector3 y) => y.normalized.ReverseZ()).ToArray(), glBufferTarget.ARRAY_BUFFER);
			int num3 = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, mesh.uv.Select((Vector2 y) => y.ReverseUV()).ToArray(), glBufferTarget.ARRAY_BUFFER);
			int num4 = -1;
			if (!removeVertexColor)
			{
				num4 = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, mesh.colors, glBufferTarget.ARRAY_BUFFER);
			}
			BoneWeight[] boneWeights = mesh.boneWeights;
			int num5 = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, boneWeights.Select((BoneWeight y) => new Vector4(y.weight0, y.weight1, y.weight2, y.weight3)).ToArray(), glBufferTarget.ARRAY_BUFFER);
			int num6 = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, boneWeights.Select((BoneWeight y) => new UShort4((ushort)y.boneIndex0, (ushort)y.boneIndex1, (ushort)y.boneIndex2, (ushort)y.boneIndex3)).ToArray(), glBufferTarget.ARRAY_BUFFER);
			glTFAttributes glTFAttributes2 = new glTFAttributes
			{
				POSITION = num
			};
			if (num2 != -1)
			{
				glTFAttributes2.NORMAL = num2;
			}
			if (num3 != -1)
			{
				glTFAttributes2.TEXCOORD_0 = num3;
			}
			if (num4 != -1)
			{
				glTFAttributes2.COLOR_0 = num4;
			}
			if (num5 != -1)
			{
				glTFAttributes2.WEIGHTS_0 = num5;
			}
			if (num6 != -1)
			{
				glTFAttributes2.JOINTS_0 = num6;
			}
			glTFMesh glTFMesh2 = new glTFMesh(mesh.name);
			for (int num7 = 0; num7 < mesh.subMeshCount; num7++)
			{
				uint[] array2 = (from y in TriangleUtil.FlipTriangle(mesh.GetIndices(num7))
					select (uint)y).ToArray();
				int indices = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, array2, glBufferTarget.ELEMENT_ARRAY_BUFFER);
				if (num7 >= materials.Length)
				{
					Debug.LogWarningFormat("{0}.materials is not enough", rendererName);
					break;
				}
				glTFMesh2.primitives.Add(new glTFPrimitives
				{
					attributes = glTFAttributes2,
					indices = indices,
					mode = 4,
					material = unityMaterials.IndexOf(materials[num7])
				});
			}
			return glTFMesh2;
		}

		private static bool UseSparse(bool usePosition, Vector3 position, bool useNormal, Vector3 normal, bool useTangent, Vector3 tangent)
		{
			if ((!usePosition || !(position != Vector3.zero)) && (!useNormal || !(normal != Vector3.zero)))
			{
				if (useTangent)
				{
					return tangent != Vector3.zero;
				}
				return false;
			}
			return true;
		}

		private static gltfMorphTarget ExportMorphTarget(glTF gltf, int bufferIndex, Mesh mesh, int j, bool useSparseAccessorForMorphTarget, bool exportOnlyBlendShapePosition)
		{
			Vector3[] blendShapeVertices = mesh.vertices;
			bool usePosition = blendShapeVertices != null && blendShapeVertices.Length != 0;
			Vector3[] blendShapeNormals = mesh.normals;
			bool useNormal = usePosition && blendShapeNormals != null && blendShapeNormals.Length == blendShapeVertices.Length;
			Vector3[] blendShapeTangents = ((IEnumerable<Vector4>)mesh.tangents).Select((Func<Vector4, Vector3>)((Vector4 y) => y)).ToArray();
			bool useTangent = false;
			int blendShapeFrameCount = mesh.GetBlendShapeFrameCount(j);
			mesh.GetBlendShapeFrameVertices(j, blendShapeFrameCount - 1, blendShapeVertices, blendShapeNormals, null);
			int num = -1;
			int nORMAL = -1;
			int tANGENT = -1;
			if (useSparseAccessorForMorphTarget)
			{
				int accessorCount = blendShapeVertices.Length;
				int[] array = (from x in Enumerable.Range(0, blendShapeVertices.Length)
					where UseSparse(usePosition, blendShapeVertices[x], useNormal, blendShapeNormals[x], useTangent, blendShapeTangents[x])
					select x).ToArray();
				if (array.Length == 0)
				{
					usePosition = false;
					useNormal = false;
					useTangent = false;
				}
				else
				{
					Debug.LogFormat("Sparse {0}/{1}", array.Length, mesh.vertexCount);
				}
				int sparseViewIndex = -1;
				if (usePosition)
				{
					sparseViewIndex = gltf.ExtendBufferAndGetViewIndex(bufferIndex, array);
					blendShapeVertices = array.Select((int x) => blendShapeVertices[x].ReverseZ()).ToArray();
					num = gltf.ExtendSparseBufferAndGetAccessorIndex(bufferIndex, accessorCount, blendShapeVertices, array, sparseViewIndex, glBufferTarget.ARRAY_BUFFER);
				}
				if (useNormal)
				{
					blendShapeNormals = array.Select((int x) => blendShapeNormals[x].ReverseZ()).ToArray();
					nORMAL = gltf.ExtendSparseBufferAndGetAccessorIndex(bufferIndex, accessorCount, blendShapeNormals, array, sparseViewIndex, glBufferTarget.ARRAY_BUFFER);
				}
				if (useTangent)
				{
					blendShapeTangents = array.Select((int x) => blendShapeTangents[x].ReverseZ()).ToArray();
					tANGENT = gltf.ExtendSparseBufferAndGetAccessorIndex(bufferIndex, accessorCount, blendShapeTangents, array, sparseViewIndex, glBufferTarget.ARRAY_BUFFER);
				}
			}
			else
			{
				for (int num2 = 0; num2 < blendShapeVertices.Length; num2++)
				{
					blendShapeVertices[num2] = blendShapeVertices[num2].ReverseZ();
				}
				if (usePosition)
				{
					num = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, blendShapeVertices, glBufferTarget.ARRAY_BUFFER);
				}
				if (useNormal)
				{
					for (int num3 = 0; num3 < blendShapeNormals.Length; num3++)
					{
						blendShapeNormals[num3] = blendShapeNormals[num3].ReverseZ();
					}
					nORMAL = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, blendShapeNormals, glBufferTarget.ARRAY_BUFFER);
				}
				if (useTangent)
				{
					for (int num4 = 0; num4 < blendShapeTangents.Length; num4++)
					{
						blendShapeTangents[num4] = blendShapeTangents[num4].ReverseZ();
					}
					tANGENT = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, blendShapeTangents, glBufferTarget.ARRAY_BUFFER);
				}
			}
			if (num != -1)
			{
				gltf.accessors[num].min = blendShapeVertices.Aggregate(blendShapeVertices[0], (Vector3 a, Vector3 b) => new Vector3(Mathf.Min(a.x, b.x), Math.Min(a.y, b.y), Mathf.Min(a.z, b.z))).ToArray();
				gltf.accessors[num].max = blendShapeVertices.Aggregate(blendShapeVertices[0], (Vector3 a, Vector3 b) => new Vector3(Mathf.Max(a.x, b.x), Math.Max(a.y, b.y), Mathf.Max(a.z, b.z))).ToArray();
			}
			return new gltfMorphTarget
			{
				POSITION = num,
				NORMAL = nORMAL,
				TANGENT = tANGENT
			};
		}

		public static IEnumerable<(Mesh, glTFMesh, Dictionary<int, int>)> ExportMeshes(glTF gltf, int bufferIndex, List<MeshWithRenderer> unityMeshes, List<Material> unityMaterials, bool useSparseAccessorForMorphTarget, bool exportOnlyBlendShapePosition, bool removeVertexColor)
		{
			int i = 0;
			while (i < unityMeshes.Count)
			{
				MeshWithRenderer meshWithRenderer = unityMeshes[i];
				Mesh mesh = meshWithRenderer.Mesh;
				Material[] sharedMaterials = meshWithRenderer.Renderer.sharedMaterials;
				glTFMesh glTFMesh2 = ExportPrimitives(gltf, bufferIndex, meshWithRenderer.Renderer.name, mesh, sharedMaterials, unityMaterials, removeVertexColor);
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				int num = 0;
				for (int j = 0; j < mesh.blendShapeCount; j++)
				{
					gltfMorphTarget gltfMorphTarget2 = ExportMorphTarget(gltf, bufferIndex, mesh, j, useSparseAccessorForMorphTarget, exportOnlyBlendShapePosition);
					if (gltfMorphTarget2.POSITION >= 0 || gltfMorphTarget2.NORMAL >= 0 || gltfMorphTarget2.TANGENT >= 0)
					{
						dictionary.Add(j, num++);
						for (int k = 0; k < glTFMesh2.primitives.Count; k++)
						{
							glTFMesh2.primitives[k].targets.Add(gltfMorphTarget2);
							glTFMesh2.primitives[k].extras.targetNames.Add(mesh.GetBlendShapeName(j));
						}
					}
				}
				yield return (mesh, glTFMesh2, dictionary);
				int num2 = i + 1;
				i = num2;
			}
		}
	}
}
