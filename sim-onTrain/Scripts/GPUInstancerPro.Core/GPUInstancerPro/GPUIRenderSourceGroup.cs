using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIRenderSourceGroup : IGPUIDisposable, IDisposable
	{
		private MaterialPropertyBlock _mpb;

		private GPUIMaterialPropertyOverrides _materialPropertyOverrides;

		private List<IGPUIDisposable> _dependentDisposables;

		private GPUILODGroupData _lodGroupData;

		public int Key { get; private set; }

		public int GroupID { get; private set; }

		public int PrototypeKey { get; private set; }

		public GPUIProfile Profile { get; private set; }

		public List<GPUIRenderSource> RenderSources { get; private set; }

		public string Name { get; private set; }

		public int BufferSize { get; private set; }

		public int InstanceCount { get; private set; }

		public GPUITransformBufferData TransformBufferData { get; private set; }

		public GPUITransformBufferType TransformBufferType { get; private set; }

		public List<string> ShaderKeywords { get; private set; }

		public GPUILODGroupData LODGroupData
		{
			get
			{
				if (_lodGroupData == null)
				{
					GPUIRenderingSystem.Instance.LODGroupDataProvider.TryGetData(PrototypeKey, out _lodGroupData);
				}
				return _lodGroupData;
			}
		}

		public GPUIRenderSourceGroup(int prototypeKey, GPUIProfile profile, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			PrototypeKey = prototypeKey;
			Profile = profile;
			GroupID = groupID;
			RenderSources = new List<GPUIRenderSource>();
			TransformBufferType = transformBufferType;
			ShaderKeywords = new List<string>();
			AddShaderKeywords(shaderKeywords);
			Key = GetKey(prototypeKey, profile, groupID, ShaderKeywords);
			if (LODGroupData != null)
			{
				Name = _lodGroupData.ToString();
			}
			else
			{
				Name = "KEY[" + Key + "]";
			}
		}

		internal void UpdateCommandBuffer(GPUICameraData cameraData)
		{
			if (LODGroupData == null)
			{
				return;
			}
			int length = _lodGroupData.Length;
			if (!cameraData.TryGetVisibilityBufferIndex(this, out var visibilityBufferIndex))
			{
				visibilityBufferIndex = cameraData._visibilityBuffer.Length;
				cameraData._visibilityBufferIndexes.Add(Key, visibilityBufferIndex);
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < length; j++)
					{
						cameraData._visibilityBuffer.Add(new GPUIVisibilityData
						{
							commandCount = 0u
						});
					}
				}
			}
			for (int k = 0; k < 2; k++)
			{
				for (int l = 0; l < length; l++)
				{
					int index = visibilityBufferIndex + length * k + l;
					GPUIVisibilityData value = cameraData._visibilityBuffer[index];
					GPUILODData gPUILODData = _lodGroupData[l];
					if (value.commandCount == 0)
					{
						uint length2 = (uint)cameraData._commandBuffer.Length;
						List<GraphicsBuffer.IndirectDrawIndexedArgs> commandBufferArgs = gPUILODData.GetCommandBufferArgs();
						cameraData._commandBuffer.Add(commandBufferArgs);
						value.commandStartIndex = length2;
						value.commandCount = (uint)commandBufferArgs.Count;
						value.additional = (uint)k;
					}
					cameraData._visibilityBuffer[index] = value;
				}
			}
		}

		internal void SetBufferSize(GPUIRenderSource renderSource, int renderSourceBufferSize, bool isCopyPreviousData)
		{
			if (renderSource.bufferSize == renderSourceBufferSize)
			{
				return;
			}
			int bufferSize = renderSource.bufferSize;
			renderSource.bufferSize = renderSourceBufferSize;
			if (renderSource.instanceCount > renderSourceBufferSize)
			{
				renderSource.instanceCount = renderSourceBufferSize;
			}
			renderSource.bufferStartIndex = 0;
			BufferSize = 0;
			if (RenderSources.Count > 1)
			{
				foreach (GPUIRenderSource renderSource2 in RenderSources)
				{
					renderSource2.bufferStartIndex = BufferSize;
					BufferSize += renderSource2.bufferSize;
				}
				GPUIShaderBuffer transformBuffer = null;
				GPUIShaderBuffer previousTransformBuffer = null;
				if (TransformBufferData == null)
				{
					TransformBufferData = new GPUITransformBufferData(this);
					isCopyPreviousData = false;
				}
				else
				{
					isCopyPreviousData |= TransformBufferData.ResizeTransformBuffer(out previousTransformBuffer, out transformBuffer);
				}
				if (isCopyPreviousData)
				{
					CopyTransformBufferData(previousTransformBuffer, transformBuffer, 0, 0, renderSource.bufferStartIndex);
					CopyTransformBufferData(previousTransformBuffer, transformBuffer, renderSource.bufferStartIndex + bufferSize, renderSource.bufferStartIndex + renderSource.bufferSize, BufferSize - renderSource.bufferStartIndex - renderSource.bufferSize);
				}
				previousTransformBuffer?.Dispose();
			}
			else
			{
				BufferSize = renderSource.bufferSize;
				if (TransformBufferData == null)
				{
					TransformBufferData = new GPUITransformBufferData(this);
				}
				else
				{
					TransformBufferData.ResizeTransformBuffer(isCopyPreviousData);
				}
			}
			if (BufferSize == 0)
			{
				ReleaseBuffers();
			}
			else
			{
				GPUIRenderingSystem.Instance.UpdateCommandBuffers(this);
			}
		}

		internal void CopyTransformBufferData(GPUIShaderBuffer managedBuffer, GPUIShaderBuffer transformBuffer, int managedBufferStartIndex, int graphicsBufferStartIndex, int count)
		{
			if (managedBuffer != null && transformBuffer != null && !TransformBufferData.IsCameraBasedBuffer && count > 0)
			{
				transformBuffer.Buffer.SetData(managedBuffer.Buffer, managedBufferStartIndex, graphicsBufferStartIndex, count);
			}
		}

		internal void SetInstanceCount(GPUIRenderSource renderSource, int renderSourceInstanceCount)
		{
			if (renderSource.instanceCount != renderSourceInstanceCount)
			{
				renderSource.instanceCount = renderSourceInstanceCount;
				UpdateInstanceCount();
			}
		}

		private void UpdateInstanceCount()
		{
			InstanceCount = 0;
			foreach (GPUIRenderSource renderSource in RenderSources)
			{
				InstanceCount += renderSource.instanceCount;
			}
		}

		internal void SetTransformBufferData<T>(GPUIRenderSource renderSource, NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			if (count > 0)
			{
				int num = graphicsBufferStartIndex + count;
				bool isCopyPreviousData = graphicsBufferStartIndex != 0 || count < InstanceCount;
				if (renderSource.bufferSize < num)
				{
					SetBufferSize(renderSource, num, isCopyPreviousData);
				}
				TransformBufferData.SetTransformBufferData(matrices, managedBufferStartIndex, renderSource.bufferStartIndex + graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				if (renderSource.instanceCount < count)
				{
					SetInstanceCount(renderSource, count);
				}
			}
		}

		internal void SetTransformBufferData<T>(GPUIRenderSource renderSource, T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			if (count > 0)
			{
				int num = graphicsBufferStartIndex + count;
				bool isCopyPreviousData = graphicsBufferStartIndex != 0 || count < InstanceCount;
				if (renderSource.bufferSize < num)
				{
					SetBufferSize(renderSource, num, isCopyPreviousData);
				}
				TransformBufferData.SetTransformBufferData(matrices, managedBufferStartIndex, renderSource.bufferStartIndex + graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				if (renderSource.instanceCount < count)
				{
					SetInstanceCount(renderSource, count);
				}
			}
		}

		internal void SetTransformBufferData<T>(GPUIRenderSource renderSource, List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			if (count > 0)
			{
				int num = graphicsBufferStartIndex + count;
				bool isCopyPreviousData = graphicsBufferStartIndex != 0 || count < InstanceCount;
				if (renderSource.bufferSize < num)
				{
					SetBufferSize(renderSource, num, isCopyPreviousData);
				}
				TransformBufferData.SetTransformBufferData(matrices, managedBufferStartIndex, renderSource.bufferStartIndex + graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
				if (renderSource.instanceCount < count)
				{
					SetInstanceCount(renderSource, count);
				}
			}
		}

		internal void UpdateTransformBufferData(int frameNo)
		{
			TransformBufferData?.UpdateData(frameNo);
		}

		private void RemoveRenderSource(GPUIRenderSource renderSource)
		{
			int num = RenderSources.IndexOf(renderSource);
			if (num < 0)
			{
				return;
			}
			RenderSources.RemoveAt(num);
			if (renderSource.bufferSize == 0)
			{
				return;
			}
			BufferSize = 0;
			foreach (GPUIRenderSource renderSource2 in RenderSources)
			{
				renderSource2.bufferStartIndex = BufferSize;
				BufferSize += renderSource2.bufferSize;
			}
			UpdateInstanceCount();
			TransformBufferData.RemoveIndexes(renderSource.bufferStartIndex, renderSource.bufferSize);
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.UpdateCommandBuffers(this);
			}
		}

		internal void Dispose(GPUIRenderSource renderSource)
		{
			if (RenderSources != null && RenderSources.Contains(renderSource))
			{
				if (RenderSources.Count == 1)
				{
					Dispose();
				}
				else
				{
					RemoveRenderSource(renderSource);
				}
			}
		}

		public void Dispose()
		{
			ReleaseBuffers();
			BufferSize = 0;
			if (RenderSources != null)
			{
				foreach (GPUIRenderSource renderSource in RenderSources)
				{
					renderSource?.DisposeRenderSource();
				}
			}
			RenderSources = null;
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.RenderSourceGroupProvider.Remove(Key);
			}
			if (_dependentDisposables == null)
			{
				return;
			}
			foreach (IGPUIDisposable dependentDisposable in _dependentDisposables)
			{
				dependentDisposable.Dispose();
			}
			_dependentDisposables = null;
		}

		public void ReleaseBuffers()
		{
			if (TransformBufferData != null)
			{
				TransformBufferData.Dispose();
				TransformBufferData = null;
			}
		}

		internal bool AddRenderSource(UnityEngine.Object source, GPUIRenderSource renderSource)
		{
			if (RenderSources.Exists((GPUIRenderSource rs) => rs.Key == renderSource.Key))
			{
				Debug.LogWarning("Renderer already registered for: " + Name + " with Key:" + renderSource.Key, source);
				return false;
			}
			RenderSources.Add(renderSource);
			return true;
		}

		internal void AddDependentDisposable(IGPUIDisposable gpuiDisposable)
		{
			if (_dependentDisposables == null)
			{
				_dependentDisposables = new List<IGPUIDisposable>();
			}
			if (!_dependentDisposables.Contains(gpuiDisposable))
			{
				_dependentDisposables.Add(gpuiDisposable);
			}
		}

		private void CreateMaterialPropertyBlock()
		{
			if (_mpb == null)
			{
				_mpb = new MaterialPropertyBlock();
				_mpb.SetVector(GPUIConstants.PROP_unity_LODFade, new Vector4(1f, 16f, 0f, 0f));
			}
		}

		internal MaterialPropertyBlock GetMaterialPropertyBlock(GPUILODGroupData lgd, GPUICameraData cameraData)
		{
			CreateMaterialPropertyBlock();
			if (Application.isPlaying && lgd.requiresTreeProxy)
			{
				GPUIRenderingSystem.Instance.TreeProxyProvider.GetMaterialPropertyBlock(lgd, cameraData, _mpb);
			}
			return _mpb;
		}

		internal void ApplyMaterialPropertyOverrides(MaterialPropertyBlock mpb, int lodIndex, int rendererIndex)
		{
			if (_materialPropertyOverrides != null)
			{
				_materialPropertyOverrides.ApplyOverrides(mpb, lodIndex, rendererIndex);
			}
		}

		public void AddMaterialPropertyOverride(string propertyName, object value, int lodIndex = -1, int rendererIndex = -1)
		{
			AddMaterialPropertyOverride(Shader.PropertyToID(propertyName), value, lodIndex, rendererIndex);
		}

		public void AddMaterialPropertyOverride(int nameID, object value, int lodIndex = -1, int rendererIndex = -1)
		{
			GPUILODGroupData lODGroupData = LODGroupData;
			if (lODGroupData != null && !lODGroupData.requiresTreeProxy)
			{
				CreateMaterialPropertyBlock();
				_mpb.SetValue(nameID, value);
				return;
			}
			if (_materialPropertyOverrides == null)
			{
				_materialPropertyOverrides = new GPUIMaterialPropertyOverrides();
			}
			_materialPropertyOverrides.AddOverride(lodIndex, rendererIndex, nameID, value);
		}

		private void AddShaderKeyword(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword) && !ShaderKeywords.Contains(keyword))
			{
				ShaderKeywords.Add(keyword);
			}
		}

		private void AddShaderKeywords(IEnumerable<string> keywords)
		{
			if (keywords == null)
			{
				return;
			}
			foreach (string keyword in keywords)
			{
				AddShaderKeyword(keyword);
			}
		}

		public static int GetKey(int prototypeKey, GPUIProfile profile, int groupID, List<string> shaderKeywords)
		{
			if (shaderKeywords == null || shaderKeywords.Count == 0)
			{
				return GPUIUtility.GenerateHash(prototypeKey, profile.GetInstanceID(), groupID);
			}
			shaderKeywords.Sort();
			return GPUIUtility.GenerateHash(prototypeKey, profile.GetInstanceID(), groupID, string.Concat(shaderKeywords).GetHashCode());
		}

		public int GetRenderSourceKey(UnityEngine.Object source)
		{
			return GPUIUtility.GenerateHash(source.GetInstanceID(), Key);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
