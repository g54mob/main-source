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

		private List<GPUIShaderCommandParams> _shaderCommandParams;

		internal Vector4[] _shaderCommandParamsArray;

		private Dictionary<int, Vector2> _shaderCommandOptionalParams;

		internal bool _requireShaderCommandParamsUpdate;

		private GPUILODGroupData _lodGroupData;

		private static readonly Color[] materialColors = new Color[8]
		{
			new Color(1f, 0f, 0f, 1f),
			new Color(0f, 0f, 1f, 1f),
			new Color(1f, 1f, 0f, 1f),
			new Color(1f, 0.5f, 0f, 1f),
			new Color(0f, 1f, 1f, 1f),
			new Color(0.5f, 0f, 1f, 1f),
			new Color(1f, 0f, 1f, 1f),
			new Color(0f, 1f, 0f, 1f)
		};

		private static readonly string[] _colorPropertyNames = new string[4] { "_Color", "_BaseColor", "_HealthyColor", "_DryColor" };

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

		public GPUIPrototype Prototype
		{
			get
			{
				GPUILODGroupData lODGroupData = LODGroupData;
				if (LODGroupData == null)
				{
					return null;
				}
				return lODGroupData.prototype;
			}
		}

		public bool IsLODColorDebuggingEnabled { get; private set; }

		public GPUIRenderSourceGroup(int prototypeKey, GPUIProfile profile, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null, GPUILODGroupData lodGroupData = null)
		{
			PrototypeKey = prototypeKey;
			Profile = profile;
			GroupID = groupID;
			RenderSources = new List<GPUIRenderSource>();
			TransformBufferType = transformBufferType;
			_lodGroupData = lodGroupData;
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
			_shaderCommandParams = new List<GPUIShaderCommandParams>();
			_shaderCommandOptionalParams = new Dictionary<int, Vector2>();
		}

		internal void UpdateCommandBuffer(GPUICameraData cameraData)
		{
			if (LODGroupData == null)
			{
				return;
			}
			int length = _lodGroupData.Length;
			GPUIVisibilityData element = new GPUIVisibilityData
			{
				additional = 3u
			};
			GPUIProfile profile = Profile;
			if (!cameraData.TryGetVisibilityBufferIndex(this, out var visibilityBufferIndex))
			{
				visibilityBufferIndex = cameraData._visibilityBuffer.Length;
				cameraData._visibilityBufferIndexes[Key] = visibilityBufferIndex;
				for (int i = 0; i < length * 2; i++)
				{
					cameraData._visibilityBuffer.Add(element);
				}
				if (_lodGroupData.optionalRendererCount > 0)
				{
					for (int j = 0; j < _lodGroupData.optionalRendererCount * 2; j++)
					{
						cameraData._visibilityBuffer.Add(element);
					}
				}
			}
			_shaderCommandParams.Clear();
			int num = 0;
			for (int k = 0; k < 2; k++)
			{
				for (int l = 0; l < length; l++)
				{
					int index = visibilityBufferIndex + length * k + l;
					GPUIVisibilityData value = cameraData._visibilityBuffer[index];
					GPUILODData gPUILODData = _lodGroupData[l];
					if (value.additional > 1)
					{
						uint length2 = (uint)cameraData._commandBuffer.Length;
						List<GraphicsBuffer.IndirectDrawIndexedArgs> commandBufferArgs = gPUILODData.GetCommandBufferArgs(profile);
						cameraData._commandBuffer.Add(commandBufferArgs);
						value.commandStartIndex = length2;
						value.commandCount = (uint)commandBufferArgs.Count;
						value.additional = (uint)k;
					}
					gPUILODData.LoadShaderCommandParams(_shaderCommandParams, num, l);
					num++;
					cameraData._visibilityBuffer[index] = value;
				}
			}
			if (_lodGroupData.optionalRendererCount > 0)
			{
				if (_shaderCommandParams.Count == 0)
				{
					num = 0;
				}
				GPUILODData gPUILODData2 = _lodGroupData[0];
				for (int m = 0; m < _lodGroupData.optionalRendererCount; m++)
				{
					List<GraphicsBuffer.IndirectDrawIndexedArgs> optionalRendererCommandBufferArgs = gPUILODData2.GetOptionalRendererCommandBufferArgs(m + 1, profile);
					for (int n = 0; n < 2; n++)
					{
						int index2 = visibilityBufferIndex + 2 + n + m * 2;
						GPUIVisibilityData value2 = cameraData._visibilityBuffer[index2];
						if (value2.additional > 1)
						{
							uint length3 = (uint)cameraData._commandBuffer.Length;
							cameraData._commandBuffer.Add(optionalRendererCommandBufferArgs);
							value2.commandStartIndex = length3;
							value2.commandCount = (uint)optionalRendererCommandBufferArgs.Count;
							value2.additional = (uint)n;
						}
						gPUILODData2.LoadShaderCommandParamsForOptionalRenderers(_shaderCommandParams, num, m + 1);
						num++;
						cameraData._visibilityBuffer[index2] = value2;
					}
				}
			}
			CreateShaderCommandParamsArray();
		}

		private void CreateShaderCommandParamsArray()
		{
			int num = 5;
			_shaderCommandParamsArray = new Vector4[_shaderCommandParams.Count * num];
			Matrix4x4 identity = Matrix4x4.identity;
			for (int i = 0; i < _shaderCommandParams.Count; i++)
			{
				GPUIShaderCommandParams gPUIShaderCommandParams = _shaderCommandParams[i];
				if (!_shaderCommandOptionalParams.TryGetValue(gPUIShaderCommandParams.key, out var value))
				{
					value = Vector2.zero;
				}
				_shaderCommandParamsArray[i * num] = new Vector4(gPUIShaderCommandParams.instanceDataBufferShiftMultiplier, (gPUIShaderCommandParams.transformOffset != identity) ? 1f : 0f, value.x, value.y);
				_shaderCommandParamsArray[i * num + 1] = gPUIShaderCommandParams.transformOffset.GetRow(0);
				_shaderCommandParamsArray[i * num + 2] = gPUIShaderCommandParams.transformOffset.GetRow(1);
				_shaderCommandParamsArray[i * num + 3] = gPUIShaderCommandParams.transformOffset.GetRow(2);
				_shaderCommandParamsArray[i * num + 4] = gPUIShaderCommandParams.transformOffset.GetRow(3);
			}
			_requireShaderCommandParamsUpdate = true;
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
				UpdateInstanceCount();
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
			GPUIRenderingSystem.Instance.OnRenderSourceGroupBufferSizeChanged(this);
			GPUIRenderingSystem.Instance.OnRenderSourceBufferSizeChanged(renderSource, bufferSize);
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
			renderSource.instanceCount = renderSourceInstanceCount;
			UpdateInstanceCount();
		}

		private void UpdateInstanceCount()
		{
			InstanceCount = 0;
			foreach (GPUIRenderSource renderSource in RenderSources)
			{
				InstanceCount += renderSource.instanceCount;
			}
		}

		internal void SetTransformBufferData<T>(GPUIRenderSource renderSource, NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : unmanaged
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

		internal void SetTransformBufferData<T>(GPUIRenderSource renderSource, T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : unmanaged
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

		internal void SetTransformBufferData<T>(GPUIRenderSource renderSource, List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : unmanaged
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
			GPUIRenderingSystem.Instance.OnRenderSourceGroupBufferSizeChanged(this);
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
				dependentDisposable?.Dispose();
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

		internal bool AddRenderSource(GPUIRenderSource renderSource)
		{
			if (RenderSources.Exists((GPUIRenderSource rs) => rs.Key == renderSource.Key))
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Renderer already registered for: " + Name + " with Key:" + renderSource.Key, renderSource.source);
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
				ResetMaterialPropertyBlock();
			}
		}

		public MaterialPropertyBlock GetMaterialPropertyBlock()
		{
			CreateMaterialPropertyBlock();
			return _mpb;
		}

		private void ResetMaterialPropertyBlock()
		{
			_mpb.Clear();
			_mpb.SetVector(GPUIConstants.PROP_unity_LODFade, new Vector4(1f, 16f, 0f, 0f));
			if (_materialPropertyOverrides != null)
			{
				_materialPropertyOverrides.ApplyDirectOverrides(_mpb);
			}
		}

		internal MaterialPropertyBlock GetMaterialPropertyBlock(GPUILODGroupData lgd)
		{
			CreateMaterialPropertyBlock();
			if (Application.isPlaying && lgd.requiresTreeProxy)
			{
				GPUIRenderingSystem.Instance.TreeProxyProvider.GetMaterialPropertyBlock(lgd, _mpb);
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

		public void AddMaterialPropertyOverride(string propertyName, object value, int lodIndex = -1, int rendererIndex = -1, bool isPersistent = false)
		{
			AddMaterialPropertyOverride(Shader.PropertyToID(propertyName), value, lodIndex, rendererIndex, isPersistent);
		}

		public void AddMaterialPropertyOverride(int nameID, object value, int lodIndex = -1, int rendererIndex = -1, bool isPersistent = false)
		{
			bool isAppliedDirectlyToMBP = false;
			GPUILODGroupData lODGroupData = LODGroupData;
			if (isPersistent && lODGroupData != null && !lODGroupData.requiresTreeProxy && lodIndex < 0 && rendererIndex < 0)
			{
				CreateMaterialPropertyBlock();
				_mpb.SetValue(nameID, value);
				isAppliedDirectlyToMBP = true;
			}
			if (_materialPropertyOverrides == null)
			{
				_materialPropertyOverrides = new GPUIMaterialPropertyOverrides();
			}
			_materialPropertyOverrides.AddOverride(lodIndex, rendererIndex, nameID, value, isPersistent, isAppliedDirectlyToMBP);
		}

		public void RemoveMaterialPropertyOverrides(string propertyName)
		{
			RemoveMaterialPropertyOverrides(Shader.PropertyToID(propertyName));
		}

		public void RemoveMaterialPropertyOverrides(int nameID)
		{
			ResetMaterialPropertyBlock();
			if (_materialPropertyOverrides != null)
			{
				_materialPropertyOverrides.RemoveMaterialPropertyOverrides(nameID);
			}
		}

		public void ClearMaterialPropertyOverrides()
		{
			ResetMaterialPropertyBlock();
			if (_materialPropertyOverrides != null)
			{
				_materialPropertyOverrides.ClearOverrides();
			}
		}

		public bool AddShaderKeyword(string keyword)
		{
			if (string.IsNullOrEmpty(keyword))
			{
				return false;
			}
			if (!ShaderKeywords.Contains(keyword))
			{
				ShaderKeywords.Add(keyword);
				return true;
			}
			return false;
		}

		public bool RemoveShaderKeyword(string keyword)
		{
			if (string.IsNullOrEmpty(keyword))
			{
				return false;
			}
			return ShaderKeywords.Remove(keyword);
		}

		public void RemoveReplacementMaterials()
		{
			GPUILODGroupData lODGroupData = LODGroupData;
			if (!(lODGroupData == null))
			{
				lODGroupData.RemoveReplacementMaterials();
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

		public void SetCommandShaderOptionalParams(int lodNo, int rendererNo, Vector2 optionalParams)
		{
			int key = lodNo + 10 * rendererNo;
			_shaderCommandOptionalParams[key] = optionalParams;
			CreateShaderCommandParamsArray();
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

		public void SetLODColorDebuggingEnabled(bool enabled, string colorPropertyName = null)
		{
			if (enabled)
			{
				IsLODColorDebuggingEnabled = true;
				for (int i = 0; i < materialColors.Length; i++)
				{
					if (!string.IsNullOrEmpty(colorPropertyName))
					{
						AddMaterialPropertyOverride(colorPropertyName, materialColors[i], i);
						continue;
					}
					for (int j = 0; j < _colorPropertyNames.Length; j++)
					{
						AddMaterialPropertyOverride(_colorPropertyNames[j], materialColors[i], i);
					}
				}
				return;
			}
			IsLODColorDebuggingEnabled = false;
			if (!string.IsNullOrEmpty(colorPropertyName))
			{
				RemoveMaterialPropertyOverrides(colorPropertyName);
				return;
			}
			for (int k = 0; k < _colorPropertyNames.Length; k++)
			{
				RemoveMaterialPropertyOverrides(_colorPropertyNames[k]);
			}
		}
	}
}
