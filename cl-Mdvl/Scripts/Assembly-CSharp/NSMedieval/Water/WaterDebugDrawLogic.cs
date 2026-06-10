using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.Water
{
	public class WaterDebugDrawLogic
	{
		private const string FlowInDebugPrefab = "FlowInDebugPrefab";

		private const string FlowOutDebugPrefab = "FlowOutDebugPrefab";

		private const string FlowLoadingChangeDebugPrefab = "FlowLoadingChangeDebugPrefab";

		private const string FlowGameChangeDebugPrefab = "FlowGameChangeDebugPrefab";

		public static bool FlowInFlowOutDebugRenderEnabled;

		public static bool SnapCameraToFlowChangePosition;

		public static bool DebugRenderRiverOriginalPositions;

		private readonly RenderParams flowInRenderParams;

		private readonly RenderParams flowOutRenderParams;

		private readonly RenderParams flowGameChangeRenderParams;

		private readonly RenderParams flowLoadingChangeRenderParams;

		private readonly Mesh flowInMesh;

		private readonly Mesh flowOutMesh;

		private readonly Mesh flowChangeMesh;

		private VillageMap map;

		private int dataLength;

		private float[] flowInChangedBuffer;

		private float[] flowOutChangedBuffer;

		private float[] prevFlowIn;

		private bool[] prevFlowOut;

		private bool initDone;

		private bool mapLoaded;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			FlowInFlowOutDebugRenderEnabled = false;
			SnapCameraToFlowChangePosition = false;
			DebugRenderRiverOriginalPositions = false;
		}

		public WaterDebugDrawLogic(VillageMap villageMap)
		{
			map = villageMap;
			dataLength = map.Size.x * map.Size.y * map.Size.z;
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("FlowInDebugPrefab");
			Material sharedMaterial = byAddress.GetComponent<MeshRenderer>().sharedMaterial;
			flowInMesh = byAddress.GetComponent<MeshFilter>().sharedMesh;
			flowInRenderParams = new RenderParams(sharedMaterial);
			GameObject byAddress2 = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("FlowOutDebugPrefab");
			Material sharedMaterial2 = byAddress2.GetComponent<MeshRenderer>().sharedMaterial;
			flowOutMesh = byAddress2.GetComponent<MeshFilter>().sharedMesh;
			flowOutRenderParams = new RenderParams(sharedMaterial2);
			GameObject byAddress3 = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("FlowGameChangeDebugPrefab");
			Material sharedMaterial3 = byAddress3.GetComponent<MeshRenderer>().sharedMaterial;
			flowChangeMesh = byAddress3.GetComponent<MeshFilter>().sharedMesh;
			flowGameChangeRenderParams = new RenderParams(sharedMaterial3);
			GameObject byAddress4 = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("FlowLoadingChangeDebugPrefab");
			Material sharedMaterial4 = byAddress4.GetComponent<MeshRenderer>().sharedMaterial;
			flowChangeMesh = byAddress4.GetComponent<MeshFilter>().sharedMesh;
			flowLoadingChangeRenderParams = new RenderParams(sharedMaterial4);
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		public void Dispose()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			map = null;
			flowInChangedBuffer = null;
			flowOutChangedBuffer = null;
		}

		private void OnMapLoaded(bool loadedFromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			mapLoaded = true;
		}

		private void OnPreCullCallback(Camera cam)
		{
			if (FlowInFlowOutDebugRenderEnabled && mapLoaded && (cam.name.Equals("GameplayCamera") || cam.name.Equals("PhotoModeCamera")))
			{
				CheckLazyInitBuffers();
				ProcessFlowChangeBuffers();
				RenderFlowInFlowOut();
			}
		}

		private void ProcessFlowChangeBuffers()
		{
			bool flag = false;
			Vector3 position = Vector3.zero;
			WaterSimLogic waterSimLogic = map.WaterManager.WaterSimLogic;
			float[] flowInData = waterSimLogic.FlowInData;
			bool[] flowOutData = waterSimLogic.FlowOutData;
			for (int i = 0; i < dataLength; i++)
			{
				if (math.abs(prevFlowIn[i] - flowInData[i]) > 0.01f)
				{
					prevFlowIn[i] = flowInData[i];
					flowInChangedBuffer[i] = 1f;
					waterSimLogic.FlowInOutChanged[i] |= 8;
					if (SnapCameraToFlowChangePosition)
					{
						flag = true;
						position = GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i));
					}
				}
				if (prevFlowOut[i] != flowOutData[i])
				{
					prevFlowOut[i] = flowOutData[i];
					flowOutChangedBuffer[i] = 1f;
					waterSimLogic.FlowInOutChanged[i] |= 8;
					if (SnapCameraToFlowChangePosition)
					{
						flag = true;
						position = GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i));
					}
				}
			}
			if (flag)
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(position, snap: true);
			}
		}

		private void CheckLazyInitBuffers()
		{
			if (!initDone)
			{
				initDone = true;
				if (flowInChangedBuffer == null)
				{
					flowInChangedBuffer = new float[dataLength];
				}
				if (flowOutChangedBuffer == null)
				{
					flowOutChangedBuffer = new float[dataLength];
				}
				if (prevFlowOut == null)
				{
					prevFlowOut = new bool[dataLength];
				}
				if (prevFlowIn == null)
				{
					prevFlowIn = new float[dataLength];
				}
				for (int i = 0; i < dataLength; i++)
				{
					prevFlowIn[i] = map.WaterManager.WaterSimLogic.FlowInData[i];
					prevFlowOut[i] = map.WaterManager.WaterSimLogic.FlowOutData[i];
				}
			}
		}

		private void RenderFlowInFlowOut()
		{
			int num = map.Size.x * map.Size.y * map.Size.z;
			Quaternion identity = Quaternion.identity;
			WaterSimLogic waterSimLogic = map.WaterManager.WaterSimLogic;
			int[] flowInOutChanged = waterSimLogic.FlowInOutChanged;
			for (int i = 0; i < num; i++)
			{
				int num2 = flowInOutChanged[i];
				if ((num2 & 6) != 0)
				{
					Graphics.RenderMesh(objectToWorld: Matrix4x4.TRS(GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i)), identity, Vector3.one), rparams: in flowLoadingChangeRenderParams, mesh: flowChangeMesh, submeshIndex: 0);
				}
				if ((num2 & 8) != 0)
				{
					Matrix4x4 objectToWorld = Matrix4x4.TRS(GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i)), identity, Vector3.one);
					Graphics.RenderMesh(in flowGameChangeRenderParams, flowChangeMesh, 0, objectToWorld);
				}
				if (waterSimLogic.FlowInData[i] > 0f)
				{
					float num3 = 1f;
					if (flowInChangedBuffer[i] > 0f)
					{
						flowInChangedBuffer[i] = Math.Max(0f, flowInChangedBuffer[i] - Time.smoothDeltaTime * 0.1f);
						num3 = GetMeshScale(flowInChangedBuffer[i]);
					}
					Matrix4x4 objectToWorld2 = Matrix4x4.TRS(GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i)), identity, Vector3.one * num3);
					Graphics.RenderMesh(in flowInRenderParams, flowInMesh, 0, objectToWorld2);
				}
				if (waterSimLogic.FlowOutData[i] && (waterSimLogic.WaterData[i] > 0f || map.GridSpaceData[i].IsWalkable))
				{
					float num4 = 1f;
					if (flowOutChangedBuffer[i] > 0f)
					{
						flowOutChangedBuffer[i] = Math.Max(0f, flowOutChangedBuffer[i] - Time.smoothDeltaTime * 0.1f);
						num4 = GetMeshScale(flowOutChangedBuffer[i]);
					}
					Matrix4x4 objectToWorld3 = Matrix4x4.TRS(GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i)), identity, Vector3.one * num4);
					Graphics.RenderMesh(in flowOutRenderParams, flowOutMesh, 0, objectToWorld3);
				}
				if (DebugRenderRiverOriginalPositions && waterSimLogic.RiverHeight != null)
				{
					int num5 = GridDataIndexTools.Get2dIndexXZ(GridDataIndexTools.GetX(i), GridDataIndexTools.GetZ(i));
					if (num5 < waterSimLogic.RiverHeight.Length && waterSimLogic.RiverHeight[num5] > 0f && map.GridSpaceData[i].IsWalkable)
					{
						Matrix4x4 objectToWorld4 = Matrix4x4.TRS(GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(i)), identity, Vector3.one);
						Graphics.RenderMesh(in flowLoadingChangeRenderParams, flowChangeMesh, 0, objectToWorld4);
					}
				}
			}
			static float GetMeshScale(float value)
			{
				return math.lerp(value, 1f + math.sin(value * 3.14f * 30f) * 0.4f * value * value, value);
			}
		}
	}
}
