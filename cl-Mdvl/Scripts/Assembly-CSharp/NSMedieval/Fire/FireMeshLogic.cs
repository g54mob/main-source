using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Fire
{
	public class FireMeshLogic
	{
		public enum DebugDrawMode
		{
			None = 0,
			FlameValue = 1,
			DamageAccumulated = 2,
			Flammability = 3
		}

		[NonSerialized]
		private static Material debugMaterial;

		[NonSerialized]
		private static Mesh quadMesh;

		[NonSerialized]
		private static bool renderParamsInitialized;

		[NonSerialized]
		private static InstancedRenderer fireMeshRenderer;

		[NonSerialized]
		private static InstancedRenderer greekFireMeshRenderer;

		[NonSerialized]
		private static InstancedRenderer debugMeshRenderer;

		[NonSerialized]
		private static InstancedRenderer oilBlobMeshRenderer;

		[NonSerialized]
		private static InstancedRenderer greekFireOilBlobMeshRenderer;

		[NonSerialized]
		private static RenderParams fireMeshRenderParams;

		[NonSerialized]
		private static RenderParams greekFireMeshRenderParams;

		[NonSerialized]
		private static RenderParams debugMeshRenderParams;

		[NonSerialized]
		private static RenderParams oilBlobMeshRenderParams;

		[NonSerialized]
		private static RenderParams greekFireOilBlobMeshRenderParams;

		[NonSerialized]
		private static NativeArray<uint> tagsByNode;

		[NonSerialized]
		private static ComputeBuffer tagsComputeBuffer;

		private const uint PlantCanopyMask = 1073741824u;

		private const string FirePrefabAddressable = "FireObject";

		private const string GreekFirePrefabAddressable = "GreekFireObject";

		private const string OilBlobPrefabAddressable = "OilBlobObject";

		private const string GreekFireOilBlobPrefabAddressable = "GreekFireOilBlobObject";

		private const string FireSpawnParticleId = "spawn_fire";

		private const string FireSpawnOnOilParticleId = "spawn_fire";

		private const string FireRemoveParticleId = "remove_fire";

		[NonSerialized]
		private FireSimLogic fireSimLogic;

		[NonSerialized]
		private VillageMap villageMap;

		private int dataLength;

		[NonSerialized]
		private InstancedRenderer[] renderersByFlameType;

		[NonSerialized]
		private Dictionary<int, uint> tagChangedSet;

		[NonSerialized]
		private readonly Dictionary<int, bool> shadowCasterChanged = new Dictionary<int, bool>();

		[NonSerialized]
		private bool gameStarted;

		public DebugDrawMode DebugDraw { get; set; }

		public bool RenderEnabled { get; set; } = true;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			if (debugMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(debugMaterial);
				debugMaterial = null;
			}
			if (quadMesh != null)
			{
				UnityEngine.Object.DestroyImmediate(quadMesh);
				quadMesh = null;
			}
			fireMeshRenderer?.Dispose();
			fireMeshRenderer = null;
			oilBlobMeshRenderer?.Dispose();
			oilBlobMeshRenderer = null;
			greekFireOilBlobMeshRenderer?.Dispose();
			greekFireOilBlobMeshRenderer = null;
			greekFireMeshRenderer?.Dispose();
			greekFireMeshRenderer = null;
			debugMeshRenderer?.Dispose();
			debugMeshRenderer = null;
			fireMeshRenderParams = default(RenderParams);
			greekFireMeshRenderParams = default(RenderParams);
			debugMeshRenderParams = default(RenderParams);
			oilBlobMeshRenderParams = default(RenderParams);
			greekFireOilBlobMeshRenderParams = default(RenderParams);
			renderParamsInitialized = false;
		}

		public static void InitStaticArrays()
		{
			tagsByNode = ArrayStorage.GetNativeArray<uint>("FireMeshLogic.tagsByNode", GridDataIndexTools.MaxDataLength);
			tagsComputeBuffer = ArrayStorage.GetComputeBuffer("FireMeshLogic.tagsComputeBuffer", GridDataIndexTools.MaxDataLength, 4);
			if (!renderParamsInitialized)
			{
				RenderParams renderParams = new RenderParams(GetMaterial("FireObject"));
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				renderParams.lightProbeUsage = LightProbeUsage.Off;
				renderParams.reflectionProbeUsage = ReflectionProbeUsage.Off;
				fireMeshRenderParams = renderParams;
				renderParams = new RenderParams(GetMaterial("GreekFireObject"));
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				renderParams.lightProbeUsage = LightProbeUsage.Off;
				renderParams.reflectionProbeUsage = ReflectionProbeUsage.Off;
				greekFireMeshRenderParams = renderParams;
				renderParams = new RenderParams(GetMaterial("OilBlobObject"));
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				renderParams.lightProbeUsage = LightProbeUsage.Off;
				renderParams.reflectionProbeUsage = ReflectionProbeUsage.Off;
				oilBlobMeshRenderParams = renderParams;
				renderParams = new RenderParams(GetMaterial("GreekFireOilBlobObject"));
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				renderParams.lightProbeUsage = LightProbeUsage.Off;
				renderParams.reflectionProbeUsage = ReflectionProbeUsage.Off;
				greekFireOilBlobMeshRenderParams = renderParams;
				debugMaterial = new Material(Shader.Find("Custom/FireDebugShader"))
				{
					enableInstancing = true,
					color = new Color(1f, 1f, 1f, 0.5f)
				};
				renderParams = new RenderParams(debugMaterial);
				renderParams.receiveShadows = false;
				renderParams.shadowCastingMode = ShadowCastingMode.Off;
				debugMeshRenderParams = renderParams;
				renderParamsInitialized = true;
			}
			if (fireMeshRenderer == null || fireMeshRenderer.DataLength != GridDataIndexTools.MaxDataLength)
			{
				fireMeshRenderer?.Dispose();
				fireMeshRenderer = null;
				oilBlobMeshRenderer?.Dispose();
				oilBlobMeshRenderer = null;
				greekFireOilBlobMeshRenderer?.Dispose();
				greekFireOilBlobMeshRenderer = null;
				greekFireMeshRenderer?.Dispose();
				greekFireMeshRenderer = null;
				debugMeshRenderer?.Dispose();
				debugMeshRenderer = null;
				quadMesh = CreateDebugQuadMesh();
				fireMeshRenderer = new InstancedRenderer(GetMesh("FireObject"), fireMeshRenderParams, "nodeIndexArray", GridDataIndexTools.MaxDataLength);
				greekFireMeshRenderer = new InstancedRenderer(GetMesh("GreekFireObject"), greekFireMeshRenderParams, "nodeIndexArray", GridDataIndexTools.MaxDataLength);
				debugMeshRenderer = new InstancedRenderer(quadMesh, debugMeshRenderParams, "nodeIndexArray", GridDataIndexTools.MaxDataLength);
				oilBlobMeshRenderer = new InstancedRenderer(GetMesh("OilBlobObject"), oilBlobMeshRenderParams, "nodeIndexArray", GridDataIndexTools.MaxDataLength);
				greekFireOilBlobMeshRenderer = new InstancedRenderer(GetMesh("GreekFireOilBlobObject"), greekFireOilBlobMeshRenderParams, "nodeIndexArray", GridDataIndexTools.MaxDataLength);
			}
			else
			{
				fireMeshRenderer.Flush();
				greekFireMeshRenderer.Flush();
				debugMeshRenderer.Flush();
				oilBlobMeshRenderer.Flush();
				greekFireOilBlobMeshRenderer.Flush();
			}
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(tagsByNode, dataLength);
		}

		private static Mesh GetMesh(string prefabName)
		{
			return MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(prefabName).GetComponent<MeshFilter>().sharedMesh;
		}

		private static Material GetMaterial(string prefabName)
		{
			return MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(prefabName).GetComponent<MeshRenderer>().sharedMaterial;
		}

		public void Initialize(FireSimLogic fireSimLogic, VillageMap villageMap)
		{
			if (this.fireSimLogic == null)
			{
				dataLength = fireSimLogic.DataLength;
				InitStaticArrays();
				ClearStaticArrays();
				this.fireSimLogic = fireSimLogic;
				this.villageMap = villageMap;
				renderersByFlameType = new InstancedRenderer[2] { fireMeshRenderer, greekFireMeshRenderer };
				tagChangedSet = new Dictionary<int, uint>();
				this.villageMap.NodeTagChangedEvent += OnNodeTagChanged;
				this.villageMap.NodeIsShadowCasterChangedEvent += OnNodeIsShadowCasterChanged;
				MonoSingleton<FireController>.Instance.FireAddedEvent += OnFireAdded;
				MonoSingleton<FireController>.Instance.FireRemovedEvent += OnFireRemoved;
				MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
			}
		}

		private void OnSceneSetup()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
				MonoSingleton<SceneController>.Instance.LateTick += OnLateTick;
			}
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			gameStarted = true;
			UnityEngine.Object.FindObjectOfType<FireParticleSystems>()?.Initialize(villageMap);
		}

		private void OnFireAdded(NativeParallelHashSet<int> addedIndices)
		{
			foreach (int item in addedIndices)
			{
				Vector3 worldPosition = GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(item));
				if (fireSimLogic.OilBlobHealth[item] > 0f)
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("spawn_fire", worldPosition);
					MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(worldPosition, CameraShakeStrength.Weak);
				}
				else
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("spawn_fire", worldPosition);
				}
			}
		}

		private void OnFireRemoved(NativeParallelHashSet<int> removedIndices)
		{
			foreach (int item in removedIndices)
			{
				Vector3 worldPosition = GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(item));
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("remove_fire", worldPosition);
			}
		}

		private void OnPreCullCallback(Camera cam)
		{
			if (gameStarted && MonoSingleton<CameraManager>.IsInstantiated() && (cam == MonoSingleton<CameraManager>.Instance.GameplayCamera || cam == MonoSingleton<CameraManager>.Instance.PhotoModeCamera))
			{
				Render();
			}
		}

		public void Dispose()
		{
			gameStarted = false;
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			if (villageMap != null)
			{
				villageMap.NodeTagChangedEvent -= OnNodeTagChanged;
				villageMap.NodeIsShadowCasterChangedEvent -= OnNodeIsShadowCasterChanged;
			}
			fireSimLogic = null;
			villageMap = null;
			renderersByFlameType = null;
			tagChangedSet.Clear();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
			}
			if (MonoSingleton<FireController>.IsInstantiated())
			{
				MonoSingleton<FireController>.Instance.FireAddedEvent -= OnFireAdded;
				MonoSingleton<FireController>.Instance.FireRemovedEvent -= OnFireRemoved;
			}
		}

		private void OnNodeTagChanged(MapNode node, MapNodeTags oldTag)
		{
			tagChangedSet.TryAdd(node.Index, (uint)node.Tag);
		}

		private void OnNodeIsShadowCasterChanged(MapNode node, bool isShadowCaster)
		{
			if (!shadowCasterChanged.TryAdd(node.Index, isShadowCaster))
			{
				shadowCasterChanged[node.Index] = isShadowCaster;
			}
		}

		private void OnLateTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("FireMeshLogic.LateTick"))
			{
				bool flag = shadowCasterChanged.Count > 0 || tagChangedSet.Count > 0;
				if (shadowCasterChanged.Count > 0)
				{
					foreach (KeyValuePair<int, bool> item in shadowCasterChanged)
					{
						if (item.Value)
						{
							tagsByNode[item.Key] |= 1073741824u;
						}
						else
						{
							tagsByNode[item.Key] &= 3221225471u;
						}
					}
					shadowCasterChanged.Clear();
				}
				if (tagChangedSet.Count > 0)
				{
					foreach (KeyValuePair<int, uint> item2 in tagChangedSet)
					{
						uint num = tagsByNode[item2.Key];
						tagsByNode[item2.Key] = (num & 0x40000000) | (item2.Value & 0xBFFFFFFFu);
					}
					tagChangedSet.Clear();
				}
				if (flag)
				{
					tagsComputeBuffer.SetData(tagsByNode, 0, 0, dataLength);
				}
			}
		}

		private static Mesh CreateDebugQuadMesh()
		{
			List<int> triangles = new List<int>();
			List<Vector3> vertices = new List<Vector3>();
			MeshDataUtils.AppendUnitQuad(ref vertices, ref triangles, Vector3.zero);
			return MeshDataUtils.ToMesh(ref vertices, ref triangles);
		}

		private void Render()
		{
			if (RenderEnabled && fireSimLogic != null)
			{
				if (DebugDraw == DebugDrawMode.None)
				{
					fireSimLogic?.NodesOnFireSafeOperation(RenderFireMeshes);
					fireSimLogic?.NodesOnFireSafeOperation(RenderOilBlobs);
				}
				else
				{
					RenderDebug();
				}
			}
		}

		private void RenderOilBlobs(NativeArray<int> nodeIndicesOnFire, int nodeIndicesOnFireCount, NativeArray<float> flameData, NativeArray<byte> flameType)
		{
			int oilBlobNodesCount = fireSimLogic.OilBlobNodesCount;
			NativeArray<float> oilBlobHealth = fireSimLogic.OilBlobHealth;
			NativeArray<byte> oilBlobType = fireSimLogic.OilBlobType;
			NativeArray<int> oilBlobNodesArray = fireSimLogic.OilBlobNodesArray;
			for (int i = 0; i < oilBlobNodesCount; i++)
			{
				int num = oilBlobNodesArray[i];
				if (oilBlobHealth[num] > 0f)
				{
					int x = GridDataIndexTools.GetX(num);
					int y = GridDataIndexTools.GetY(num);
					int z = GridDataIndexTools.GetZ(num);
					if (oilBlobType[num] == 1)
					{
						greekFireOilBlobMeshRenderer.QueueRender(new Vector3(x, y * World.MapBlockHeight, z), Quaternion.identity, Vector3.one * (oilBlobHealth[num] * 1f), num);
					}
					else
					{
						oilBlobMeshRenderer.QueueRender(new Vector3(x, y * World.MapBlockHeight, z), Quaternion.identity, Vector3.one * (oilBlobHealth[num] * 1f), num);
					}
				}
			}
			oilBlobMeshRenderer.FinishRender();
			greekFireOilBlobMeshRenderer.FinishRender();
		}

		private void RenderDebug()
		{
			if (DebugDraw == DebugDrawMode.FlameValue)
			{
				fireSimLogic.NodesOnFireSafeOperation(delegate(NativeArray<int> fireIndices, int fireIndicesCount, NativeArray<float> fireValues, NativeArray<byte> flameType)
				{
					RenderMesh(fireIndices, fireIndicesCount, fireSimLogic.FlammabilityNative, debugMeshRenderer);
				});
				return;
			}
			HashSet<int> hashSet = HashSetPool<int>.Get();
			for (int num = 0; num < fireSimLogic.DataLength; num++)
			{
				if (villageMap.GridSpaceData[num].IsWalkable)
				{
					if (DebugDraw == DebugDrawMode.DamageAccumulated && fireSimLogic.GetFireDamageAccumulated(num) > 0f)
					{
						hashSet.Add(num);
					}
					if (DebugDraw == DebugDrawMode.Flammability && fireSimLogic.GetFlammability(num) > 0f)
					{
						hashSet.Add(num);
					}
				}
			}
			switch (DebugDraw)
			{
			case DebugDrawMode.DamageAccumulated:
				RenderMesh(hashSet, fireSimLogic.FireDamageAccumulated, debugMeshRenderer);
				break;
			case DebugDrawMode.Flammability:
				RenderMesh(hashSet, fireSimLogic.FlammabilityNative, debugMeshRenderer);
				break;
			}
			HashSetPool<int>.Return(hashSet);
		}

		private void RenderFireMeshes(NativeArray<int> nodesOnFire, int nodeIndicesCount, NativeArray<float> fireData, NativeArray<byte> flameTypeData)
		{
			RenderMesh(nodesOnFire, nodeIndicesCount, fireData, flameTypeData, renderersByFlameType);
		}

		private static void RenderMesh(NativeArray<int> nodeIndices, int nodeIndicesCount, NativeArray<float> dataToRead, InstancedRenderer renderer)
		{
			for (int i = 0; i < nodeIndicesCount; i++)
			{
				int num = nodeIndices[i];
				if (dataToRead[num] > 0f)
				{
					int x = GridDataIndexTools.GetX(num);
					int y = GridDataIndexTools.GetY(num);
					int z = GridDataIndexTools.GetZ(num);
					renderer.QueueRender(new Vector3(x, y * World.MapBlockHeight, z), Quaternion.identity, Vector3.one, num);
				}
			}
			renderer.FinishRender();
		}

		private static void RenderMesh(HashSet<int> nodeIndices, NativeArray<float> meshScaleArray, InstancedRenderer meshRenderer, float scale = 1f, float yOffset = 0f)
		{
			foreach (int nodeIndex in nodeIndices)
			{
				float num = ((meshScaleArray[nodeIndex] > 0f) ? 1f : 0f);
				if (num > 0.01f)
				{
					int x = GridDataIndexTools.GetX(nodeIndex);
					int y = GridDataIndexTools.GetY(nodeIndex);
					int z = GridDataIndexTools.GetZ(nodeIndex);
					num *= scale;
					meshRenderer.QueueRender(new Vector3(x, (float)(y * World.MapBlockHeight) + yOffset, z), Quaternion.identity, new Vector3(num, num * 2f, num), nodeIndex);
				}
			}
			meshRenderer.FinishRender();
		}

		private void RenderMesh(NativeArray<int> nodeIndices, int nodeIndicesCount, NativeArray<float> dataToRead, NativeArray<byte> flameType, InstancedRenderer[] renderersByFlameType, float yOffset = 0f)
		{
			InstancedRenderer[] array = renderersByFlameType;
			foreach (InstancedRenderer obj in array)
			{
				obj.SetBufferOnMaterial("nodeTags", tagsComputeBuffer);
				obj.SetBufferOnMaterial("nodeFlameHealth", fireSimLogic.FireDataComputeBuffer);
				obj.SetBufferOnMaterial("temperatureBuffer", villageMap.TemperatureManager.CombinedBuffer);
			}
			for (int j = 0; j < nodeIndicesCount; j++)
			{
				int num = nodeIndices[j];
				if (dataToRead[num] > 0f)
				{
					int x = GridDataIndexTools.GetX(num);
					int y = GridDataIndexTools.GetY(num);
					int z = GridDataIndexTools.GetZ(num);
					renderersByFlameType[flameType[num]].QueueRender(new Vector3(x, (float)(y * World.MapBlockHeight) + yOffset, z), Quaternion.identity, Vector3.one, num);
				}
			}
			array = renderersByFlameType;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FinishRender();
			}
		}
	}
}
