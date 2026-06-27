using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public static class BlitUtility
	{
		private struct MeshSetupResult
		{
			public readonly int ItemsToDraw;

			public readonly int VertexIndex;

			public readonly int TriangleIndex;

			public MeshSetupResult(int itemsToDraw, int vertexIndex, int triangleIndex)
			{
				ItemsToDraw = itemsToDraw;
				VertexIndex = vertexIndex;
				TriangleIndex = triangleIndex;
			}
		}

		public struct Vertex
		{
			public Vector4 Position;

			public Vector3 Normal;
		}

		private static readonly int MainTexHash = Shader.PropertyToID("_MainTex");

		private static readonly int NormalMatricesHash = Shader.PropertyToID("_NormalMatrices");

		private static Vector4[] normals;

		private static ushort[] tempIndicies;

		private static Vector4[] tempVertecies;

		private static readonly VertexAttributeDescriptor[] vertexParams = new VertexAttributeDescriptor[2]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 4),
			new VertexAttributeDescriptor(VertexAttribute.Normal)
		};

		private const int BatchSize = 128;

		private const int DefaultBufferSize = 16;

		private static Vertex[] vertices = new Vertex[4096];

		private static ushort[] indices = new ushort[20480];

		private static Matrix4x4[] matrices = new Matrix4x4[16];

		private static Matrix4x4[] batchMatrices = new Matrix4x4[128];

		private static Matrix4x4[] rotationMatrices = new Matrix4x4[16];

		private static Matrix4x4[] batchRotationMatrices = new Matrix4x4[128];

		private static readonly Matrix4x4[] identityMatrixArray = new Matrix4x4[1] { Matrix4x4.identity };

		private static MeshSetupResult? currentSetupResult;

		private static MaterialPropertyBlock propertyBlock;

		private static bool? supportsInstancing;

		private static bool SupportsInstancing
		{
			get
			{
				if (supportsInstancing.HasValue)
				{
					return supportsInstancing.Value;
				}
				supportsInstancing = SystemInfo.supportsInstancing;
				return supportsInstancing.Value;
			}
		}

		private static void UpdateBounds(Renderer renderer, OutlineTarget target)
		{
			if (target.renderer is MeshRenderer)
			{
				MeshFilter component = renderer.GetComponent<MeshFilter>();
				if (component.sharedMesh != null)
				{
					component.sharedMesh.RecalculateBounds();
				}
			}
			else if (target.renderer is SkinnedMeshRenderer skinnedMeshRenderer && skinnedMeshRenderer.sharedMesh != null)
			{
				skinnedMeshRenderer.sharedMesh.RecalculateBounds();
			}
		}

		public static void PrepareForRendering(OutlineParameters parameters)
		{
			if (parameters.BlitMesh == null)
			{
				parameters.BlitMesh = parameters.MeshPool.AllocateMesh();
			}
			MeshSetupResult? meshSetupResult = (currentSetupResult = (SupportsInstancing ? SetupForInstancing(parameters) : SetupForBruteForce(parameters)));
			if (meshSetupResult.HasValue)
			{
				parameters.BlitMesh.SetVertexBufferParams(meshSetupResult.Value.VertexIndex, vertexParams);
				parameters.BlitMesh.SetVertexBufferData(vertices, 0, 0, meshSetupResult.Value.VertexIndex, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				parameters.BlitMesh.SetIndexBufferParams(meshSetupResult.Value.TriangleIndex, IndexFormat.UInt16);
				parameters.BlitMesh.SetIndexBufferData(indices, 0, 0, meshSetupResult.Value.TriangleIndex, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				parameters.BlitMesh.subMeshCount = 1;
				parameters.BlitMesh.SetSubMesh(0, new SubMeshDescriptor(0, meshSetupResult.Value.TriangleIndex), MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			}
		}

		private static void CheckModel()
		{
			if (normals == null || tempVertecies == null || tempIndicies == null)
			{
				Mesh mesh = Resources.Load<Mesh>("Easy performant outline/Models/Rounded box");
				tempVertecies = Array.ConvertAll(mesh.vertices, (Vector3 x) => new Vector4(x.x, x.y, x.z, 1f));
				tempIndicies = Array.ConvertAll(mesh.triangles, (int x) => (ushort)x);
				normals = Array.ConvertAll(mesh.normals, (Converter<Vector3, Vector4>)((Vector3 x) => x));
				Resources.UnloadAsset(mesh);
			}
		}

		private static MeshSetupResult? SetupForInstancing(OutlineParameters parameters)
		{
			CheckModel();
			if (vertices.Length < tempVertecies.Length)
			{
				Array.Resize(ref vertices, tempVertecies.Length);
			}
			if (indices.Length < tempIndicies.Length)
			{
				Array.Resize(ref indices, tempIndicies.Length);
			}
			int num = 0;
			foreach (Outlinable item in parameters.OutlinablesToRender)
			{
				num += item.OutlineTargets.Count;
			}
			while (matrices.Length < num)
			{
				Array.Resize(ref matrices, matrices.Length * 2);
			}
			while (rotationMatrices.Length < num)
			{
				Array.Resize(ref rotationMatrices, rotationMatrices.Length * 2);
			}
			int vertexIndex = 0;
			for (int i = 0; i < tempIndicies.Length; i++)
			{
				indices[i] = tempIndicies[i];
			}
			for (int j = 0; j < tempVertecies.Length; j++)
			{
				vertices[vertexIndex++] = new Vertex
				{
					Position = tempVertecies[j],
					Normal = normals[j]
				};
			}
			int num2 = 0;
			foreach (Outlinable item2 in parameters.OutlinablesToRender)
			{
				if (item2.DrawingMode != OutlinableDrawingMode.Normal)
				{
					continue;
				}
				foreach (OutlineTarget outlineTarget in item2.OutlineTargets)
				{
					Renderer renderer = outlineTarget.Renderer;
					if (!outlineTarget.IsVisible)
					{
						continue;
					}
					bool flag = false;
					Bounds bounds = default(Bounds);
					if (outlineTarget.BoundsMode == BoundsMode.Manual)
					{
						bounds = outlineTarget.Bounds;
						Vector3 size = bounds.size;
						Vector3 localScale = renderer.transform.localScale;
						size.x /= localScale.x;
						size.y /= localScale.y;
						size.z /= localScale.z;
						bounds.size = size;
					}
					else
					{
						if (outlineTarget.BoundsMode == BoundsMode.ForceRecalculate)
						{
							UpdateBounds(outlineTarget.Renderer, outlineTarget);
						}
						MeshRenderer meshRenderer = renderer as MeshRenderer;
						int num3 = ((!(meshRenderer == null)) ? meshRenderer.subMeshStartIndex : 0) + outlineTarget.SubmeshIndex;
						MeshFilter meshFilter = ((meshRenderer == null) ? null : meshRenderer.GetComponent<MeshFilter>());
						Mesh mesh = ((meshFilter == null) ? null : meshFilter.sharedMesh);
						if (mesh != null && mesh.subMeshCount > num3)
						{
							bounds = mesh.GetSubMesh(num3).bounds;
							flag = meshRenderer.isPartOfStaticBatch;
						}
						else
						{
							flag = true;
							bounds = renderer.bounds;
						}
					}
					if (flag)
					{
						rotationMatrices[num2] = Matrix4x4.identity;
						matrices[num2++] = Matrix4x4.TRS(bounds.center, Quaternion.identity, bounds.size);
						continue;
					}
					Transform transform = outlineTarget.renderer.transform;
					Vector3 size2 = bounds.size;
					rotationMatrices[num2] = Matrix4x4.Rotate(transform.rotation);
					matrices[num2++] = transform.localToWorldMatrix * Matrix4x4.Translate(bounds.center) * Matrix4x4.Scale(size2);
				}
			}
			return new MeshSetupResult(num2, vertexIndex, tempIndicies.Length);
		}

		private static MeshSetupResult? SetupForBruteForce(OutlineParameters parameters)
		{
			CheckModel();
			int num = tempVertecies.Length;
			int num2 = 0;
			int triangleIndex = 0;
			int num3 = 0;
			foreach (Outlinable item in parameters.OutlinablesToRender)
			{
				num3 += num * item.OutlineTargets.Count;
			}
			if (vertices.Length < num3)
			{
				Array.Resize(ref vertices, num3 * 2);
				Array.Resize(ref indices, vertices.Length * 5);
			}
			foreach (Outlinable item2 in parameters.OutlinablesToRender)
			{
				if (item2.DrawingMode != OutlinableDrawingMode.Normal)
				{
					continue;
				}
				for (int i = 0; i < item2.OutlineTargets.Count; i++)
				{
					OutlineTarget outlineTarget = item2.OutlineTargets[i];
					Renderer renderer = outlineTarget.Renderer;
					if (!outlineTarget.IsVisible)
					{
						continue;
					}
					bool flag = false;
					Bounds bounds = default(Bounds);
					if (outlineTarget.BoundsMode == BoundsMode.Manual)
					{
						bounds = outlineTarget.Bounds;
						Vector3 size = bounds.size;
						Vector3 localScale = renderer.transform.localScale;
						size.x /= localScale.x;
						size.y /= localScale.y;
						size.z /= localScale.z;
						bounds.size = size;
					}
					else
					{
						if (outlineTarget.BoundsMode == BoundsMode.ForceRecalculate)
						{
							UpdateBounds(outlineTarget.Renderer, outlineTarget);
						}
						MeshRenderer meshRenderer = renderer as MeshRenderer;
						int num4 = ((!(meshRenderer == null)) ? meshRenderer.subMeshStartIndex : 0) + outlineTarget.SubmeshIndex;
						MeshFilter meshFilter = ((meshRenderer == null) ? null : meshRenderer.GetComponent<MeshFilter>());
						Mesh mesh = ((meshFilter == null) ? null : meshFilter.sharedMesh);
						if (mesh != null && mesh.subMeshCount > num4)
						{
							bounds = mesh.GetSubMesh(num4).bounds;
						}
						else
						{
							flag = true;
							bounds = renderer.bounds;
						}
					}
					Vector4 vector = bounds.size;
					vector.w = 1f;
					Vector4 vector2 = bounds.center;
					Matrix4x4 matrix4x = Matrix4x4.identity;
					Matrix4x4 matrix4x2 = Matrix4x4.identity;
					if (!flag && (outlineTarget.BoundsMode == BoundsMode.Manual || !renderer.isPartOfStaticBatch))
					{
						matrix4x = outlineTarget.renderer.transform.localToWorldMatrix;
						matrix4x2 = Matrix4x4.Rotate(renderer.transform.rotation);
					}
					int num5 = tempIndicies.Length;
					for (int j = 0; j < num5; j++)
					{
						indices[triangleIndex++] = (ushort)(tempIndicies[j] + num2);
					}
					for (int k = 0; k < num; k++)
					{
						Vector4 vector3 = matrix4x2 * normals[k];
						Vector4 vector4 = tempVertecies[k];
						Vector4 vector5 = new Vector4(vector4.x * vector.x, vector4.y * vector.y, vector4.z * vector.z, 1f);
						Vertex vertex = new Vertex
						{
							Position = matrix4x * (vector2 + vector5),
							Normal = vector3
						};
						vertices[num2++] = vertex;
					}
				}
			}
			rotationMatrices[0] = Matrix4x4.identity;
			return new MeshSetupResult(1, num2, triangleIndex);
		}

		private static void RenderInstancedBatched(CommandBufferWrapper buffer, Mesh mesh, Material material, int pass, int count)
		{
			if (propertyBlock == null)
			{
				propertyBlock = new MaterialPropertyBlock();
			}
			propertyBlock.Clear();
			int num = 0;
			while (count > 0)
			{
				int num2 = Mathf.Min(128, count);
				Array.Copy(rotationMatrices, num, batchRotationMatrices, 0, num2);
				Array.Copy(matrices, num, batchMatrices, 0, num2);
				propertyBlock.SetMatrixArray(NormalMatricesHash, batchRotationMatrices);
				buffer.DrawMeshInstanced(mesh, 0, material, pass, batchMatrices, num2, propertyBlock);
				count -= num2;
				num += num2;
			}
		}

		public static void Blit(OutlineParameters parameters, RTHandle source, RTHandle destination, RTHandle destinationDepth, int eyeSlice, Material material, int pass = -1, Rect? viewport = null)
		{
			if (!currentSetupResult.HasValue)
			{
				Debug.LogError("Setup process wasn't completed.");
				return;
			}
			CommandBufferWrapper buffer = parameters.Buffer;
			buffer.SetRenderTarget(destination, destinationDepth, eyeSlice);
			if (viewport.HasValue)
			{
				parameters.Buffer.SetViewport(viewport.Value);
			}
			buffer.SetGlobalTexture(MainTexHash, source);
			if (SupportsInstancing)
			{
				RenderInstancedBatched(buffer, parameters.BlitMesh, material, pass, currentSetupResult.Value.ItemsToDraw);
				return;
			}
			material.SetMatrixArray(NormalMatricesHash, identityMatrixArray);
			buffer.DrawMesh(parameters.BlitMesh, Matrix4x4.identity, material, 0, pass);
		}

		public static void Draw(OutlineParameters parameters, RTHandle destination, RTHandle destinationDepth, int eyeSlice, Material material, int pass = -1, Rect? viewport = null)
		{
			if (!currentSetupResult.HasValue)
			{
				Debug.LogError("Setup process wasn't completed.");
				return;
			}
			CommandBufferWrapper buffer = parameters.Buffer;
			buffer.SetRenderTarget(destination, destinationDepth, eyeSlice);
			if (viewport.HasValue)
			{
				parameters.Buffer.SetViewport(viewport.Value);
			}
			if (SupportsInstancing)
			{
				if (propertyBlock == null)
				{
					propertyBlock = new MaterialPropertyBlock();
				}
				propertyBlock.Clear();
				propertyBlock.SetMatrixArray(NormalMatricesHash, rotationMatrices);
				buffer.DrawMeshInstanced(parameters.BlitMesh, 0, material, pass, matrices, currentSetupResult.Value.ItemsToDraw, propertyBlock);
			}
			else
			{
				material.SetMatrixArray(NormalMatricesHash, identityMatrixArray);
				buffer.DrawMesh(parameters.BlitMesh, Matrix4x4.identity, material, 0, pass);
			}
		}
	}
}
