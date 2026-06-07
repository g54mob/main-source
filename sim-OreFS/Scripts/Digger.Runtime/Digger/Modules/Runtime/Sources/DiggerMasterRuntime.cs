using System;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;

namespace Digger.Modules.Runtime.Sources
{
	[DefaultExecutionOrder(-10)]
	[AddComponentMenu("Digger/Digger Master Runtime")]
	public class DiggerMasterRuntime : ADiggerRuntimeMonoBehaviour
	{
		public bool enablePersistence;

		private DiggerSystem[] diggerSystems;

		private bool isRunningAsync;

		private readonly Queue<ModificationParameters> buffer = new Queue<ModificationParameters>();

		private int bufferSize = 16;

		private readonly BasicOperation basicOperation = new BasicOperation();

		private readonly KernelOperation kernelOperation = new KernelOperation();

		public bool IsRunningAsync => isRunningAsync;

		public int BufferSize
		{
			get
			{
				return bufferSize;
			}
			set
			{
				bufferSize = Math.Max(1, value);
			}
		}

		public void Modify<T>(IOperation<T> operation) where T : struct, IJobParallelFor
		{
			if (isRunningAsync)
			{
				Debug.LogError("Cannot Modify as asynchronous modification is already in progress");
				return;
			}
			DiggerSystem[] array = diggerSystems;
			foreach (DiggerSystem diggerSystem in array)
			{
				if (operation.GetAreaToModify(diggerSystem).NeedsModification)
				{
					diggerSystem.Modify(operation).GetAwaiter().GetResult();
				}
			}
		}

		public void Modify(ModificationParameters p)
		{
			if (isRunningAsync)
			{
				Debug.LogError("Cannot Modify as asynchronous modification is already in progress");
			}
			else if (p.Action == ActionType.Smooth && p.Brush != BrushType.Sphere)
			{
				Debug.LogError("Smooth action only supports Sphere brush");
			}
			else if (p.Action == ActionType.Smooth || p.Action == ActionType.BETA_Sharpen)
			{
				kernelOperation.Params = p;
				Modify(kernelOperation);
			}
			else
			{
				basicOperation.Params = p;
				Modify(basicOperation);
			}
		}

		public void Modify(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity, float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false, bool opacityIsTarget = false, bool bypassDestructability = false, bool paintWhileDigging = true)
		{
			Modify(new ModificationParameters
			{
				Position = position,
				Brush = brush,
				Action = action,
				TextureIndex = textureIndex,
				Opacity = opacity,
				Size = size,
				StalagmiteUpsideDown = stalagmiteUpsideDown,
				OpacityIsTarget = opacityIsTarget,
				PaintWhileDigging = paintWhileDigging,
				BypassDestructability = bypassDestructability,
				Callback = null
			});
		}

		public async Awaitable ModifyAsync<T>(IOperation<T> operation, Action<ModificationResult> callback = null) where T : struct, IJobParallelFor
		{
			if (isRunningAsync)
			{
				Debug.LogError("Cannot Modify as asynchronous modification is already in progress");
				return;
			}
			isRunningAsync = true;
			ModificationResult aggregatedResult = ModificationResult.Empty;
			try
			{
				DiggerSystem[] array = diggerSystems;
				foreach (DiggerSystem diggerSystem in array)
				{
					if (operation.GetAreaToModify(diggerSystem).NeedsModification)
					{
						aggregatedResult.Add(await diggerSystem.Modify(operation, useBackgroundThreads: true));
					}
				}
			}
			finally
			{
				isRunningAsync = false;
			}
			callback?.Invoke(aggregatedResult);
		}

		public async Awaitable ModifyAsync(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity, float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false, bool opacityIsTarget = false, bool bypassDestructability = false, bool paintWhileDigging = true, Action<ModificationResult> callback = null)
		{
			await ModifyAsync(new ModificationParameters
			{
				Position = position,
				Brush = brush,
				Action = action,
				TextureIndex = textureIndex,
				Opacity = opacity,
				Size = size,
				StalagmiteUpsideDown = stalagmiteUpsideDown,
				OpacityIsTarget = opacityIsTarget,
				PaintWhileDigging = paintWhileDigging,
				BypassDestructability = bypassDestructability,
				Callback = callback
			});
		}

		public async Awaitable ModifyAsync(ModificationParameters p)
		{
			if (p.Action == ActionType.Smooth && p.Brush != BrushType.Sphere)
			{
				Debug.LogError("Smooth action only supports Sphere brush");
				p.Brush = BrushType.Sphere;
			}
			if (p.Action == ActionType.Smooth || p.Action == ActionType.BETA_Sharpen)
			{
				kernelOperation.Params = p;
				await ModifyAsync(kernelOperation, p.Callback);
			}
			else
			{
				basicOperation.Params = p;
				await ModifyAsync(basicOperation, p.Callback);
			}
		}

		public bool ModifyAsyncBuffured(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity, float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false, bool opacityIsTarget = false, bool bypassDestructability = false, bool paintWhileDigging = true, Action<ModificationResult> callback = null)
		{
			if (buffer.Count >= BufferSize)
			{
				return false;
			}
			return ModifyAsyncBuffured(new ModificationParameters
			{
				Position = position,
				Brush = brush,
				Action = action,
				TextureIndex = textureIndex,
				Opacity = opacity,
				Size = size,
				StalagmiteUpsideDown = stalagmiteUpsideDown,
				OpacityIsTarget = opacityIsTarget,
				PaintWhileDigging = paintWhileDigging,
				BypassDestructability = bypassDestructability,
				Callback = callback
			});
		}

		public bool ModifyAsyncBuffured(ModificationParameters parameters)
		{
			if (buffer.Count >= BufferSize)
			{
				return false;
			}
			buffer.Enqueue(parameters);
			return true;
		}

		private void Update()
		{
			if (!isRunningAsync && buffer.Count > 0)
			{
				ModificationParameters p = buffer.Dequeue();
				StartCoroutine(ModifyAsync(p));
			}
		}

		public void PersistAll()
		{
			if (isRunningAsync)
			{
				Debug.LogError("Cannot Persist as asynchronous modification is already in progress");
				return;
			}
			DiggerSystem[] array = diggerSystems;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].PersistAtRuntime();
			}
		}

		public void DeleteAllPersistedData()
		{
			DiggerSystem[] array = diggerSystems;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DeleteDataPersistedAtRuntime();
			}
		}

		public void ClearBuffer()
		{
			buffer.Clear();
			isRunningAsync = false;
		}

		public void ClearScene()
		{
			DiggerSystem[] array = diggerSystems;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ClearAtRuntime();
			}
		}

		public void SetPersistenceDataPathPrefix(string pathPrefix)
		{
			DiggerSystem[] array = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].PersistenceSubPath = pathPrefix;
			}
		}

		public void SetupRuntimeTerrain(Terrain terrain, string guid = null)
		{
			DiggerSystem diggerSystem = UnityEngine.Object.FindFirstObjectByType<DiggerSystem>();
			if (!diggerSystem)
			{
				Debug.LogError("SetupRuntimeTerrain needs at least one terrain to be already setup with Digger. You must have at least one terrain with Digger on it to be able to setup other terrains at runtime");
				return;
			}
			GameObject obj = new GameObject("Digger");
			obj.transform.parent = terrain.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			DiggerSystem diggerSystem2 = obj.AddComponent<DiggerSystem>();
			diggerSystem2.Guid = guid;
			diggerSystem2.PreInit(enablePersistence: true);
			diggerSystem2.PersistenceSubPath = diggerSystem.PersistenceSubPath;
			diggerSystem2.Materials = diggerSystem.Materials;
			diggerSystem2.TerrainTextures = diggerSystem.TerrainTextures;
			diggerSystem2.Terrain.terrainData.enableHolesTextureCompression = false;
			diggerSystem2.Terrain.materialTemplate = diggerSystem.Terrain.materialTemplate;
			diggerSystem2.Init((Application.isEditor && !Application.isPlaying) ? LoadType.Minimal : LoadType.Minimal_and_LoadVoxels);
			RefreshTerrainList();
		}

		public void RefreshTerrainList()
		{
			diggerSystems = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
		}

		private void Awake()
		{
			diggerSystems = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
			DiggerSystem[] array = diggerSystems;
			foreach (DiggerSystem diggerSystem in array)
			{
				Init(diggerSystem);
			}
		}

		private void Init(DiggerSystem diggerSystem)
		{
			if (!diggerSystem.IsInitialized)
			{
				diggerSystem.Terrain.terrainData.enableHolesTextureCompression = false;
				diggerSystem.PreInit(enablePersistence);
				diggerSystem.Init((Application.isEditor && !Application.isPlaying) ? LoadType.Minimal : LoadType.Minimal_and_LoadVoxels);
			}
		}
	}
}
