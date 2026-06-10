using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Layering;
using NGS.MeshFusionPro;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Managers
{
	public class MeshFusionControllersManager : MonoSingleton<MeshFusionControllersManager>
	{
		private const int CellSize = 5;

		private readonly Dictionary<int, RuntimeMeshFusion> runtimeByHash = new Dictionary<int, RuntimeMeshFusion>();

		private int lastIndex;

		private bool loadingComplete;

		private readonly HashSet<BaseBuildingViewComponent> toRemove = new HashSet<BaseBuildingViewComponent>();

		private readonly HashSet<BaseBuildingViewComponent> toAdd = new HashSet<BaseBuildingViewComponent>();

		public RuntimeMeshFusion GetRuntimeMeshFusion(int hash)
		{
			if (runtimeByHash.TryGetValue(hash, out var value))
			{
				return value;
			}
			RuntimeMeshFusion runtimeMeshFusion = CreateNewRuntime(lastIndex);
			runtimeByHash.Add(hash, runtimeMeshFusion);
			lastIndex++;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\MeshFusionControllersManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Created runtime ");
				messageBuilder.AppendFormatted(runtimeMeshFusion);
				messageBuilder.AppendLiteral(", index = ");
				messageBuilder.AppendFormatted(runtimeMeshFusion.ControllerIndex);
			}
			Log.Info(messageBuilder);
			return runtimeMeshFusion;
		}

		private RuntimeMeshFusion CreateNewRuntime(int index)
		{
			GameObject obj = new GameObject();
			obj.transform.SetParent(base.transform);
			obj.name = $"RuntimeMeshFusion_{index}";
			RuntimeMeshFusion runtimeMeshFusion = obj.AddComponent<RuntimeMeshFusion>();
			runtimeMeshFusion.ControllerIndex = index;
			runtimeMeshFusion.CellSize = 5;
			runtimeMeshFusion.MeshType = MeshType.Lightweight;
			return runtimeMeshFusion;
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			runtimeByHash.Clear();
			toAdd.Clear();
			toRemove.Clear();
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
		}

		private void Update()
		{
			if (toAdd.Count == 0 && toRemove.Count == 0)
			{
				return;
			}
			foreach (BaseBuildingViewComponent item in toRemove)
			{
				RemoveFromMeshFusionInternal(item);
			}
			foreach (BaseBuildingViewComponent item2 in toAdd)
			{
				AddToMeshFusionInternal(item2);
			}
			toAdd.Clear();
			toRemove.Clear();
		}

		private void OnLoadingComplete()
		{
			loadingComplete = true;
		}

		public void RefreshMeshFusion(BaseBuildingViewComponent baseBuildingViewComponent)
		{
			Log.Debug("*** *** RefreshMeshFusion", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\MeshFusionControllersManager.cs");
			toAdd.Add(baseBuildingViewComponent);
			toRemove.Add(baseBuildingViewComponent);
		}

		public void AddToMeshFusion(BaseBuildingViewComponent buildingView)
		{
			toAdd.Add(buildingView);
		}

		public void RemoveFromMeshFusion(BaseBuildingViewComponent buildingView)
		{
			toRemove.Add(buildingView);
		}

		private void AddToMeshFusionInternal(BaseBuildingViewComponent buildingView)
		{
			if (buildingView.HasDisposed || buildingView.BaseBuildingInstance == null || buildingView.BaseBuildingInstance.HasDisposed || buildingView.BaseBuildingInstance.Blueprint == null)
			{
				return;
			}
			int meshFusionVariationsHash = buildingView.GetMeshFusionVariationsHash();
			RuntimeMeshFusion runtimeMeshFusion = GetRuntimeMeshFusion(meshFusionVariationsHash);
			Dictionary<string, ShadowCastingMode> dictionary = MonoSingleton<BuildingPlacementManager>.Instance.ShadowCastingModes[buildingView.BaseBuildingInstance.Blueprint.PrefabID];
			foreach (MeshFusionSource meshFusionSource in buildingView.MeshFusionSources)
			{
				meshFusionSource.ControllerIndex = runtimeMeshFusion.ControllerIndex;
				if (dictionary.TryGetValue(meshFusionSource.name, out var value))
				{
					meshFusionSource.SetShadowCastingMode = true;
					meshFusionSource.ShadowCastingModeValue = value;
				}
				else
				{
					meshFusionSource.SetShadowCastingMode = false;
				}
				meshFusionSource.onCombineFinished += buildingView.OnMeshCombinedEvent;
				if (!meshFusionSource.SkipLayerHide)
				{
					meshFusionSource.onCombineFinished += OnFirstCombineFinished;
				}
				meshFusionSource.AssignToController();
			}
		}

		private void RemoveFromMeshFusionInternal(BaseBuildingViewComponent buildingView)
		{
			foreach (MeshFusionSource meshFusionSource in buildingView.MeshFusionSources)
			{
				meshFusionSource.UndoCombine();
			}
		}

		private void OnFirstCombineFinished(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
			source.onCombineFinished -= OnFirstCombineFinished;
			foreach (ICombinedObjectPart part in parts)
			{
				BaseCombinedObject baseCombinedObject = part.Root as BaseCombinedObject;
				if (!(baseCombinedObject == null))
				{
					baseCombinedObject.gameObject.GetOrAddComponent<LayerObjectHideMeshFusion>();
				}
			}
		}
	}
}
