using System;
using System.Collections.Generic;
using UnityEngine;
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

		public Bounds bounds;

		public float lodGroupSize = 1f;

		[NonSerialized]
		public GPUIPrototype prototype;

		[NonSerialized]
		public bool allowSkinnedMeshes;

		[NonSerialized]
		public bool isUVsSet;

		[NonSerialized]
		public bool requiresTreeProxy;

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
				Debug.LogError("Can not create LODGroupData. Prototype is null.");
				return null;
			}
			if (prototype.prototypeType == GPUIPrototypeType.LODGroupData)
			{
				Debug.LogError("Can not create LODGroupData. Prototype type is already LODGroupData.");
				return null;
			}
			GPUILODGroupData gPUILODGroupData = ScriptableObject.CreateInstance<GPUILODGroupData>();
			gPUILODGroupData.name = prototype.ToString();
			gPUILODGroupData.allowSkinnedMeshes = prototype.enableSkinnedMeshRendering;
			gPUILODGroupData.CreateRenderersFromPrototype(prototype);
			return gPUILODGroupData;
		}

		public static GPUILODGroupData CreateLODGroupData(GameObject prefabObject)
		{
			if (prefabObject == null)
			{
				Debug.LogError("Can not create LODGroupData. Prefab object is null.");
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
				Debug.LogError("Can not create LODGroupData. Mesh is null.");
				return null;
			}
			if (materials == null)
			{
				Debug.LogError("Can not create LODGroupData. Materials is null.");
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
				if (!requiresTreeProxy)
				{
					requiresTreeProxy = prototype.prefabObject.HasComponentInChildren<Tree>();
				}
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
							AddRenderer(length, GPUIBillboardUtility.GenerateQuadMesh(prototype.billboardAsset), new Material[1] { GPUIBillboardUtility.CreateBillboardMaterial(prototype.billboardAsset) }, Matrix4x4.identity, prototype.prefabObject.layer, ShadowCastingMode.Off, receiveShadows: true, MotionVectorGenerationMode.Camera, isSkinnedMesh: false, doesNotContributeToBounds: true);
						}
					}
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

		public bool CreateRenderersFromGameObject(GameObject prefabObject)
		{
			if (prefabObject == null)
			{
				return false;
			}
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
				if (lODs[i].renderers != null)
				{
					Renderer[] renderers = lODs[i].renderers;
					foreach (Renderer renderer in renderers)
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
							else if (allowSkinnedMeshes && renderer is SkinnedMeshRenderer)
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
						Debug.LogWarning("LOD Group has no mesh renderers. Prefab: " + lodGroup.gameObject.name + " LODIndex: " + i, lodGroup.gameObject);
					}
					continue;
				}
				AddLOD(lODs[i].screenRelativeTransitionHeight);
				for (int k = 0; k < list.Count; k++)
				{
					AddRenderer(list[k], lodGroup.gameObject.transform, i);
				}
			}
			return true;
		}

		private bool GenerateRenderersFromMeshRenderers(GameObject prefabObject)
		{
			AddLOD();
			if (!prefabObject)
			{
				Debug.LogError("Can't create renderer(s): GameObject is null");
				return false;
			}
			List<Renderer> list = new List<Renderer>();
			prefabObject.transform.GetMeshRenderers(list, allowSkinnedMeshes);
			if (list == null || list.Count == 0)
			{
				Debug.LogWarning("Can't create renderer(s): no MeshRenderers found in the reference GameObject <" + prefabObject.name + "> or any of its children", prefabObject);
				return false;
			}
			foreach (Renderer item in list)
			{
				AddRenderer(item, prefabObject.transform, 0);
			}
			return true;
		}

		public GPUILODData AddLODAtIndex(int index, float transitionValue = -1f)
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
			return lodDataArray[index];
		}

		public GPUILODData AddLOD(float transitionValue = -1f)
		{
			return AddLODAtIndex(Length, transitionValue);
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

		public void AddRenderer(Renderer renderer, Transform parentTransform, int lodIndex)
		{
			if (allowSkinnedMeshes && renderer is SkinnedMeshRenderer skinnedMeshRenderer)
			{
				if (skinnedMeshRenderer.sharedMesh == null)
				{
					Debug.LogWarning("Can't add renderer: mesh is null. Make sure that all the SkinnedMeshRenderers on the prototype has a mesh assigned.", parentTransform.gameObject);
				}
				else if (skinnedMeshRenderer.sharedMaterials == null || skinnedMeshRenderer.sharedMaterials.Length == 0)
				{
					Debug.LogWarning("Can't add renderer: no materials. Make sure that all the SkinnedMeshRenderers have their materials assigned.", parentTransform.gameObject);
				}
				else
				{
					AddRenderer(lodIndex, skinnedMeshRenderer.sharedMesh, (Material[])renderer.sharedMaterials.Clone(), parentTransform.GetTransformOffset(renderer.gameObject.transform), renderer.gameObject.layer, renderer.shadowCastingMode, renderer.receiveShadows, renderer.motionVectorGenerationMode, isSkinnedMesh: true, doesNotContributeToBounds: false, renderer.renderingLayerMask);
				}
				return;
			}
			MeshFilter component = renderer.GetComponent<MeshFilter>();
			if (component == null)
			{
				Debug.LogWarning("MeshRenderer with no MeshFilter found on GameObject <" + parentTransform.name + ">. Are you missing a component?", parentTransform.gameObject);
			}
			else if (component.sharedMesh == null)
			{
				Debug.LogWarning("Can't add renderer: mesh is null. Make sure that all the MeshFilters on the prototype has a mesh assigned.", parentTransform.gameObject);
			}
			else if (renderer.sharedMaterials == null || renderer.sharedMaterials.Length == 0)
			{
				Debug.LogWarning("Can't add renderer: no materials. Make sure that all the MeshRenderers have their materials assigned.", parentTransform.gameObject);
			}
			else
			{
				AddRenderer(lodIndex, component.sharedMesh, (Material[])renderer.sharedMaterials.Clone(), parentTransform.GetTransformOffset(renderer.gameObject.transform), renderer.gameObject.layer, renderer.shadowCastingMode, renderer.receiveShadows, renderer.motionVectorGenerationMode, isSkinnedMesh: false, doesNotContributeToBounds: false, renderer.renderingLayerMask);
			}
		}

		public void AddRenderer(int lodIndex, Mesh mesh, Material[] materials, Matrix4x4 transformOffset, int layer, ShadowCastingMode shadowCastingMode, bool receiveShadows = true, MotionVectorGenerationMode motionVectorGenerationMode = MotionVectorGenerationMode.Camera, bool isSkinnedMesh = false, bool doesNotContributeToBounds = false, uint renderingLayerMask = 1u)
		{
			if (Length <= lodIndex || this[lodIndex] == null)
			{
				Debug.LogError("Can't add renderer: Invalid LOD");
				return;
			}
			this[lodIndex].Add(new GPUIRendererData(mesh, materials, transformOffset, layer, shadowCastingMode, receiveShadows, motionVectorGenerationMode, isSkinnedMesh, doesNotContributeToBounds, renderingLayerMask));
			CalculateBounds();
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
	}
}
