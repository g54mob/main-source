using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	[Serializable]
	[CreateAssetMenu(menuName = "Rendering/GPU Instancer Pro/LOD Group Data", order = 611)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_LOD_Group_Data")]
	public class GPUILODGroupData : ScriptableObject, IGPUIParameterBufferData, IGPUIDisposable, IDisposable
	{
		public GPUILODData[] lodDataArray;

		public float[] transitionValues = new float[8];

		public float[] fadeTransitionWidth = new float[8];

		public Bounds bounds;

		public float lodGroupSize = 1f;

		public int optionalRendererCount;

		[NonSerialized]
		public GPUIPrototype prototype;

		[NonSerialized]
		public bool requiresTreeProxy;

		[NonSerialized]
		private bool _hasSkinnedMeshes;

		[NonSerialized]
		private bool _hasSkinningComponent;

		public UnityAction<GPUILODGroupData> OnRegeneratedRenderers;

		public bool HasSkinning
		{
			get
			{
				return _hasSkinnedMeshes;
			}
			private set
			{
				_hasSkinnedMeshes = value;
				if (_hasSkinnedMeshes && requiresTreeProxy)
				{
					requiresTreeProxy = false;
				}
			}
		}

		public int Length
		{
			get
			{
				if (lodDataArray != null)
				{
					return lodDataArray.Length;
				}
				return 0;
			}
		}

		public GPUILODData this[int index]
		{
			get
			{
				return lodDataArray[index];
			}
			set
			{
				lodDataArray[index] = value;
			}
		}

		public GPUILODGroupData()
		{
			InitializeTransitionValues();
		}

		public static GPUILODGroupData CreateLODGroupData(GPUIPrototype prototype)
		{
			if (prototype == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not create LODGroupData. Prototype is null.");
				return null;
			}
			if (prototype.prototypeType == GPUIPrototypeType.LODGroupData)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not create LODGroupData. Prototype type is already LODGroupData.");
				return null;
			}
			GPUILODGroupData gPUILODGroupData = ScriptableObject.CreateInstance<GPUILODGroupData>();
			gPUILODGroupData.name = prototype.ToString();
			gPUILODGroupData.CreateRenderersFromPrototype(prototype);
			return gPUILODGroupData;
		}

		public static GPUILODGroupData CreateLODGroupData(GameObject prefabObject)
		{
			if (prefabObject == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not create LODGroupData. Prefab object is null.");
				return null;
			}
			GPUILODGroupData gPUILODGroupData = ScriptableObject.CreateInstance<GPUILODGroupData>();
			gPUILODGroupData.name = prefabObject.name;
			gPUILODGroupData.CreateRenderersFromGameObject(prefabObject);
			return gPUILODGroupData;
		}

		public static GPUILODGroupData CreateLODGroupData(Mesh mesh, Material[] materials, ShadowCastingMode shadowCastingMode = ShadowCastingMode.On, int layer = 0)
		{
			if (mesh == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not create LODGroupData. Mesh is null.");
				return null;
			}
			if (materials == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not create LODGroupData. Materials is null.");
				return null;
			}
			GPUILODGroupData gPUILODGroupData = ScriptableObject.CreateInstance<GPUILODGroupData>();
			gPUILODGroupData.name = mesh.name;
			gPUILODGroupData.CreateRenderersFromMeshAndMaterial(mesh, materials, shadowCastingMode, layer);
			return gPUILODGroupData;
		}

		public bool CreateRenderersFromPrototype(GPUIPrototype prototype)
		{
			if (prototype == null)
			{
				return false;
			}
			this.prototype = prototype;
			lodDataArray = new GPUILODData[0];
			if (prototype.prototypeType == GPUIPrototypeType.Prefab)
			{
				if (prototype.prefabObject == null)
				{
					return false;
				}
				CheckTreeProxyRequirement();
				if (CreateRenderersFromGameObject(prototype.prefabObject))
				{
					if (prototype.isGenerateBillboard)
					{
						if (prototype.billboardAsset == null)
						{
							prototype.billboardAsset = GPUIBillboardUtility.FindBillboardAsset(prototype.prefabObject);
						}
						if (prototype.billboardAsset != null && prototype.billboardAsset.albedoAtlasTexture != null)
						{
							int length = Length;
							AddLOD(0f);
							if (!prototype.prefabObject.HasComponent<LODGroup>() || !prototype.isBillboardReplaceLODCulled)
							{
								transitionValues[length - 1] = 1f - prototype.billboardDistance;
							}
							AddRenderer(length, GPUIBillboardUtility.GenerateQuadMesh(prototype.billboardAsset), new Material[1] { GPUIBillboardUtility.CreateBillboardMaterial(prototype.billboardAsset) }, Matrix4x4.identity, prototype.prefabObject.layer, ShadowCastingMode.Off, receiveShadows: true, MotionVectorGenerationMode.Camera, isSkinnedMesh: false, doesNotContributeToBounds: true, 1u, LightProbeUsage.BlendProbes);
						}
					}
					OnRegeneratedRenderers?.Invoke(this);
					return true;
				}
			}
			if (prototype.prototypeType == GPUIPrototypeType.MeshAndMaterial)
			{
				if (prototype.prototypeMesh == null)
				{
					return false;
				}
				return CreateRenderersFromMeshAndMaterial(prototype.prototypeMesh, prototype.prototypeMaterials, ShadowCastingMode.On, prototype.layer);
			}
			return false;
		}

		private void CheckTreeProxyRequirement()
		{
			if (requiresTreeProxy)
			{
				return;
			}
			if (prototype.isRequireTreeProxy)
			{
				requiresTreeProxy = true;
				return;
			}
			Tree[] componentsInChildren = prototype.prefabObject.GetComponentsInChildren<Tree>();
			foreach (Tree tree in componentsInChildren)
			{
				if (!(tree != null) || !tree.gameObject.HasComponent<MeshFilter>() || !tree.gameObject.TryGetComponent<MeshRenderer>(out var component))
				{
					continue;
				}
				Material[] sharedMaterials = component.sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (material != null && material.shader != null)
					{
						if (material.shader.name.Contains("Tree Creator"))
						{
							GPUIRenderingSystem.Instance._hasTreeCreatorWind = true;
						}
						else
						{
							requiresTreeProxy = true;
						}
						return;
					}
				}
				break;
			}
			Renderer[] componentsInChildren2 = prototype.prefabObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				Material[] sharedMaterials = componentsInChildren2[i].sharedMaterials;
				foreach (Material material2 in sharedMaterials)
				{
					if (material2 != null && material2.shader != null && material2.shader.name.Contains("Nature/SpeedTree"))
					{
						requiresTreeProxy = true;
						return;
					}
				}
			}
		}

		public bool CreateRenderersFromGameObject(GameObject prefabObject)
		{
			if (prefabObject == null)
			{
				return false;
			}
			_hasSkinningComponent = prefabObject.HasComponent<GPUISkinningBase>();
			lodDataArray = new GPUILODData[0];
			if (prefabObject.TryGetComponent<LODGroup>(out var component))
			{
				return GenerateRenderersFromLODGroup(component);
			}
			return GenerateRenderersFromMeshRenderers(prefabObject);
		}

		public bool CreateRenderersFromMeshAndMaterial(Mesh mesh, Material[] materials, ShadowCastingMode shadowCastingMode, int layer)
		{
			lodDataArray = new GPUILODData[0];
			AddLOD();
			Material[] array = new Material[materials.Length];
			Array.Copy(materials, array, materials.Length);
			AddRenderer(0, mesh, array, Matrix4x4.identity, layer, shadowCastingMode);
			return true;
		}

		private bool GenerateRenderersFromLODGroup(LODGroup lodGroup)
		{
			LOD[] lODs = lodGroup.GetLODs();
			lodGroupSize = lodGroup.size;
			for (int i = 0; i < lODs.Length; i++)
			{
				bool flag = false;
				List<Renderer> list = new List<Renderer>();
				LOD lOD = lODs[i];
				Renderer[] renderers = lOD.renderers;
				if (renderers != null)
				{
					Renderer[] array = renderers;
					foreach (Renderer renderer in array)
					{
						if (renderer != null)
						{
							if (renderer is MeshRenderer)
							{
								list.Add(renderer);
							}
							else if (renderer is BillboardRenderer)
							{
								flag = true;
							}
							else if (renderer is SkinnedMeshRenderer)
							{
								list.Add(renderer);
							}
						}
					}
				}
				if (list.Count == 0)
				{
					if (!flag)
					{
						Debug.LogWarning(GPUIConstants.LOG_PREFIX + "LOD Group has no mesh renderers. Prefab: " + lodGroup.gameObject.name + " LODIndex: " + i, lodGroup.gameObject);
					}
				}
				else
				{
					AddLOD(lOD.screenRelativeTransitionHeight, lOD.fadeTransitionWidth);
					for (int k = 0; k < list.Count; k++)
					{
						AddRenderer(list[k], lodGroup.transform, i);
					}
				}
			}
			return true;
		}

		private bool GenerateRenderersFromMeshRenderers(GameObject prefabObject)
		{
			AddLOD();
			if (!prefabObject)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can't create renderer(s): GameObject is null");
				return false;
			}
			List<Renderer> list = new List<Renderer>();
			prefabObject.transform.GetMeshRenderers(list, includeSkinnedMeshRenderers: true);
			if (list == null || list.Count == 0)
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Can't create renderer(s): no MeshRenderers found in the reference GameObject <" + prefabObject.name + "> or any of its children", prefabObject);
				return false;
			}
			foreach (Renderer item in list)
			{
				GPUIRendererData gPUIRendererData = AddRenderer(item, prefabObject.transform, 0);
				if (gPUIRendererData == null || !(item.gameObject != prefabObject) || !item.gameObject.TryGetComponent<GPUIOptionalRenderer>(out var component))
				{
					continue;
				}
				gPUIRendererData.optionalRendererNo = component.optionalRendererNo;
				if (gPUIRendererData.optionalRendererNo == 0)
				{
					continue;
				}
				bool flag = false;
				for (int i = 0; i < lodDataArray[0].Length; i++)
				{
					GPUIRendererData gPUIRendererData2 = lodDataArray[0][i];
					if (gPUIRendererData2 != null && gPUIRendererData2 != gPUIRendererData && gPUIRendererData2.optionalRendererNo == gPUIRendererData.optionalRendererNo)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					optionalRendererCount++;
				}
			}
			return true;
		}

		public GPUILODData AddLODAtIndex(int index, float transitionValue = -1f, float fadeTransitionWidth = 0f)
		{
			Array.Resize(ref lodDataArray, Length + 1);
			if (Length > 1)
			{
				for (int num = Length - 2; num >= index; num--)
				{
					lodDataArray[num + 1] = lodDataArray[num];
					transitionValues[num + 1] = transitionValues[num];
				}
			}
			lodDataArray[index] = new GPUILODData();
			if (transitionValue >= 0f)
			{
				transitionValues[index] = transitionValue;
			}
			else if (index == Length - 1)
			{
				transitionValues[index] = 0f;
			}
			else
			{
				float num2 = ((index == 0) ? 1f : transitionValues[index - 1]);
				float num3 = transitionValues[index + 1];
				transitionValues[index] = (num2 - num3) / 2f + num3;
			}
			this.fadeTransitionWidth[index] = fadeTransitionWidth;
			return lodDataArray[index];
		}

		public GPUILODData AddLOD(float transitionValue = -1f, float fadeTransitionWidth = 0f)
		{
			return AddLODAtIndex(Length, transitionValue, fadeTransitionWidth);
		}

		public void RemoveLODAtIndex(int index)
		{
			for (int i = index; i < Length - 1; i++)
			{
				lodDataArray[i] = lodDataArray[i + 1];
				transitionValues[i] = transitionValues[i + 1];
			}
			for (int j = Length - 1; j < 8; j++)
			{
				transitionValues[j] = 0f;
			}
			Array.Resize(ref lodDataArray, Length - 1);
		}

		public GPUIRendererData AddRenderer(Renderer renderer, Transform parentTransform, int lodIndex)
		{
			int forceMeshLod = -1;
			if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
			{
				if (skinnedMeshRenderer.sharedMesh == null)
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Can't add renderer: mesh is null. Make sure that all the SkinnedMeshRenderers on the prototype has a mesh assigned.", parentTransform.gameObject);
					return null;
				}
				if (skinnedMeshRenderer.sharedMaterials == null || skinnedMeshRenderer.sharedMaterials.Length == 0)
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Can't add renderer: no materials. Make sure that all the SkinnedMeshRenderers have their materials assigned.", parentTransform.gameObject);
					return null;
				}
				if (_hasSkinningComponent)
				{
					HasSkinning = true;
				}
				return AddRenderer(lodIndex, skinnedMeshRenderer.sharedMesh, (Material[])renderer.sharedMaterials.Clone(), parentTransform.GetTransformOffset(renderer.gameObject.transform), renderer.gameObject.layer, renderer.shadowCastingMode, renderer.receiveShadows, renderer.motionVectorGenerationMode, HasSkinning, doesNotContributeToBounds: false, renderer.renderingLayerMask, renderer.lightProbeUsage, forceMeshLod);
			}
			MeshFilter component = renderer.GetComponent<MeshFilter>();
			if (component == null)
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "MeshRenderer with no MeshFilter found on GameObject <" + parentTransform.name + ">. Are you missing a component?", parentTransform.gameObject);
				return null;
			}
			if (component.sharedMesh == null)
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Can't add renderer: mesh is null. Make sure that all the MeshFilters on the prototype has a mesh assigned.", parentTransform.gameObject);
				return null;
			}
			if (renderer.sharedMaterials == null || renderer.sharedMaterials.Length == 0)
			{
				Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Can't add renderer: no materials. Make sure that all the MeshRenderers have their materials assigned.", parentTransform.gameObject);
				return null;
			}
			return AddRenderer(lodIndex, component.sharedMesh, (Material[])renderer.sharedMaterials.Clone(), parentTransform.GetTransformOffset(renderer.gameObject.transform), renderer.gameObject.layer, renderer.shadowCastingMode, renderer.receiveShadows, renderer.motionVectorGenerationMode, isSkinnedMesh: false, doesNotContributeToBounds: false, renderer.renderingLayerMask, renderer.lightProbeUsage, forceMeshLod);
		}

		public GPUIRendererData AddRenderer(int lodIndex, Mesh mesh, Material[] materials, Matrix4x4 transformOffset, int layer, ShadowCastingMode shadowCastingMode, bool receiveShadows = true, MotionVectorGenerationMode motionVectorGenerationMode = MotionVectorGenerationMode.Camera, bool isSkinnedMesh = false, bool doesNotContributeToBounds = false, uint renderingLayerMask = 1u, LightProbeUsage lightProbeUsage = LightProbeUsage.Off, int forceMeshLod = -1)
		{
			if (Length <= lodIndex || this[lodIndex] == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can't add renderer: Invalid LOD");
				return null;
			}
			GPUIRendererData gPUIRendererData = new GPUIRendererData(mesh, materials, transformOffset, layer, shadowCastingMode, receiveShadows, motionVectorGenerationMode, isSkinnedMesh, doesNotContributeToBounds, renderingLayerMask, lightProbeUsage, forceMeshLod);
			this[lodIndex].Add(gPUIRendererData);
			CalculateBounds();
			return gPUIRendererData;
		}

		public void CalculateBounds()
		{
			if (lodDataArray == null || lodDataArray.Length == 0 || lodDataArray[0].rendererDataArray == null || lodDataArray[0].rendererDataArray.Length == 0)
			{
				return;
			}
			for (int i = 0; i < lodDataArray.Length; i++)
			{
				GPUILODData gPUILODData = lodDataArray[i];
				for (int j = 0; j < gPUILODData.rendererDataArray.Length; j++)
				{
					GPUIRendererData gPUIRendererData = gPUILODData.rendererDataArray[j];
					if (!gPUIRendererData.doesNotContributeToBounds)
					{
						Bounds bounds = gPUIRendererData.rendererMesh.bounds;
						bounds = bounds.GetMatrixAppliedBounds(gPUIRendererData.transformOffset);
						if (i == 0 && j == 0)
						{
							this.bounds = bounds;
						}
						else
						{
							this.bounds.Encapsulate(bounds);
						}
					}
				}
			}
			if (prototype != null && prototype.profile != null)
			{
				this.bounds.Expand(prototype.profile.boundsOffset);
			}
			SetParameterBufferData();
		}

		public void InitializeTransitionValues()
		{
			if (transitionValues == null)
			{
				transitionValues = new float[8];
			}
			else if (transitionValues.Length != 8)
			{
				Array.Resize(ref transitionValues, 8);
			}
			for (int i = 0; i < 8; i++)
			{
				if (i >= Length)
				{
					transitionValues[i] = 0f;
				}
				else if (i == 0)
				{
					transitionValues[i] = Mathf.Clamp01(transitionValues[i]);
				}
				else
				{
					transitionValues[i] = Mathf.Clamp(transitionValues[i], 0f, transitionValues[i - 1]);
				}
			}
			if (fadeTransitionWidth == null)
			{
				fadeTransitionWidth = new float[8];
			}
			else if (fadeTransitionWidth.Length != 8)
			{
				Array.Resize(ref fadeTransitionWidth, 8);
			}
		}

		public void SetParameterBufferData()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIDataBuffer<float> parameterBuffer = GPUIRenderingSystem.Instance.ParameterBuffer;
				InitializeTransitionValues();
				if (TryGetParameterBufferIndex(out var index))
				{
					parameterBuffer[index] = Length;
					parameterBuffer[index + 1] = bounds.center.x;
					parameterBuffer[index + 2] = bounds.center.y;
					parameterBuffer[index + 3] = bounds.center.z;
					parameterBuffer[index + 4] = bounds.extents.x;
					parameterBuffer[index + 5] = bounds.extents.y;
					parameterBuffer[index + 6] = bounds.extents.z;
					parameterBuffer[index + 23] = lodGroupSize;
				}
				else
				{
					index = parameterBuffer.Length;
					GPUIRenderingSystem.Instance.ParameterBufferIndexes.Add(this, index);
					parameterBuffer.Add(Length, bounds.center.x, bounds.center.y, bounds.center.z, bounds.extents.x, bounds.extents.y, bounds.extents.z);
					parameterBuffer.Add(transitionValues);
					parameterBuffer.Add(default(float), default(float), default(float), default(float), default(float), default(float), default(float), default(float));
					parameterBuffer.Add(lodGroupSize);
					parameterBuffer.Add(fadeTransitionWidth);
				}
				float lodBias = QualitySettings.lodBias;
				for (int i = 0; i < 8; i++)
				{
					parameterBuffer[index + 7 + i] = transitionValues[i] / lodBias;
				}
				for (int j = 0; j < 8 && j < Length; j++)
				{
					parameterBuffer[index + 15 + j] = (lodDataArray[j].IsShadowCasting() ? 1f : 0f);
				}
				for (int k = 0; k < 8; k++)
				{
					parameterBuffer[index + 24 + k] = fadeTransitionWidth[k];
				}
			}
		}

		public bool TryGetParameterBufferIndex(out int index)
		{
			return GPUIRenderingSystem.Instance.ParameterBufferIndexes.TryGetValue(this, out index);
		}

		public int GetMeshMaterialCombinationCount()
		{
			int num = 0;
			for (int i = 0; i < Length; i++)
			{
				GPUILODData gPUILODData = this[i];
				for (int j = 0; j < gPUILODData.Length; j++)
				{
					GPUIRendererData gPUIRendererData = gPUILODData[j];
					num += gPUIRendererData.rendererMaterials.Length;
				}
			}
			return num;
		}

		public override string ToString()
		{
			if (prototype != null)
			{
				return prototype.ToString();
			}
			return GPUIUtility.CamelToTitleCase(base.name.Replace("_", ""));
		}

		internal bool HasObjectMotion()
		{
			for (int i = 0; i < Length; i++)
			{
				for (int j = 0; j < lodDataArray[i].Length; j++)
				{
					if (lodDataArray[i].rendererDataArray[j].motionVectorGenerationMode == MotionVectorGenerationMode.Object)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void ReleaseBuffers()
		{
		}

		public void Dispose()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i].Dispose();
			}
		}

		public void RemoveReplacementMaterials()
		{
			if (lodDataArray != null)
			{
				GPUILODData[] array = lodDataArray;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].RemoveReplacementMaterials();
				}
			}
		}
	}
}
