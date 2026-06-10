using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Unity.Collections;
using UnityEngine;

namespace NSMedieval
{
	public class InstancedRenderer
	{
		private const int UnityMaxInstancedMeshes = 500;

		[NonSerialized]
		private Matrix4x4[] instancedDrawMatrices;

		[NonSerialized]
		private int totalDrawCount;

		[NonSerialized]
		private int batchDrawCount;

		[NonSerialized]
		private Mesh mesh;

		[NonSerialized]
		private readonly RenderParams renderParams;

		[NonSerialized]
		private NativeArray<int> indices;

		[NonSerialized]
		private ComputeBuffer indicesBuffer;

		[NonSerialized]
		private readonly string indicesBufferNameInShader;

		[NonSerialized]
		private int startIndex;

		public int DataLength => indices.Length;

		public InstancedRenderer(Mesh mesh, RenderParams renderParams, string indicesBufferNameInShader, int dataLength)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(42, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Fire\\InstancedRenderer.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating instanced renderer ");
				messageBuilder.AppendFormatted(mesh.name);
				messageBuilder.AppendLiteral(", dataLength: ");
				messageBuilder.AppendFormatted(dataLength);
			}
			Log.Info(messageBuilder);
			this.mesh = mesh;
			indices = new NativeArray<int>(dataLength, Allocator.Persistent);
			indicesBuffer = new ComputeBuffer(dataLength, 4);
			this.indicesBufferNameInShader = indicesBufferNameInShader;
			this.renderParams = renderParams;
			this.renderParams.matProps = new MaterialPropertyBlock();
			this.renderParams.matProps.SetBuffer(this.indicesBufferNameInShader, indicesBuffer);
			instancedDrawMatrices = new Matrix4x4[dataLength];
		}

		public void Dispose()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Fire\\InstancedRenderer.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Disposing instanced renderer ");
				messageBuilder.AppendFormatted((mesh != null) ? mesh.name : string.Empty);
				messageBuilder.AppendLiteral(", dataLength: ");
				messageBuilder.AppendFormatted(indices.IsCreated ? indices.Length : 0);
			}
			Log.Info(messageBuilder);
			instancedDrawMatrices = null;
			mesh = null;
			if (indices.IsCreated)
			{
				indices.Dispose();
			}
			indicesBuffer.Release();
			indicesBuffer = null;
		}

		public void QueueRender(Vector3 position, Quaternion rotation, Vector3 scale, int nodeIndex)
		{
			instancedDrawMatrices[totalDrawCount] = Matrix4x4.TRS(position, rotation, scale);
			indices[totalDrawCount] = nodeIndex;
			totalDrawCount++;
			batchDrawCount++;
			if (batchDrawCount >= 500)
			{
				indicesBuffer.SetData(indices);
				renderParams.matProps.SetInt("startIndex", startIndex);
				Graphics.RenderMeshInstanced(in renderParams, mesh, 0, instancedDrawMatrices, batchDrawCount, startIndex);
				startIndex = totalDrawCount;
				batchDrawCount = 0;
			}
		}

		public void FinishRender()
		{
			if (batchDrawCount == 0)
			{
				totalDrawCount = 0;
				batchDrawCount = 0;
				return;
			}
			indicesBuffer.SetData(indices);
			renderParams.matProps.SetInt("startIndex", startIndex);
			Graphics.RenderMeshInstanced(in renderParams, mesh, 0, instancedDrawMatrices, batchDrawCount, startIndex);
			totalDrawCount = 0;
			batchDrawCount = 0;
			startIndex = 0;
		}

		public void SetBufferOnMaterial(string name, ComputeBuffer buffer)
		{
			renderParams.matProps.SetBuffer(name, buffer);
		}

		public void Flush()
		{
			totalDrawCount = 0;
			batchDrawCount = 0;
			startIndex = 0;
		}
	}
}
