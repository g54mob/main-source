using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Tools.Textures;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.Initialization;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace NSMedieval.Modding
{
	public class AddressableModManager : MonoSingleton<AddressableModManager>
	{
		private class AddressableRecordData
		{
			public string Key { get; init; }

			public string AssetId { get; init; }

			public AsyncOperationHandle<UnityEngine.Object> ObjectHandle { get; init; }

			public AsyncOperationHandle<GameObject> GameObjectHandle { get; init; }

			public void Dispose()
			{
				switch (Key)
				{
				case "Texture":
					MonoRepository<TextureRepository, KeyTexturePair>.Instance.RemoveByID(AssetId);
					break;
				case "Sprite":
					MonoRepository<SpriteRepository, KeySpritePair>.Instance.RemoveByID(AssetId);
					break;
				case "SpriteAsset":
					MonoRepository<SpriteAssetRepository, KeySpriteAssetPair>.Instance.RemoveByID(AssetId);
					break;
				case "Mesh":
					MonoRepository<MeshRepository, KeyGameObjectPair>.Instance.RemoveByID(AssetId);
					break;
				default:
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("AddressableRecordData key ");
						messageBuilder.AppendFormatted(Key);
						messageBuilder.AppendLiteral(" not supported");
					}
					Log.Error(messageBuilder);
					break;
				}
				}
				Release();
			}

			public void Release()
			{
				if (GameObjectHandle.IsValid())
				{
					Addressables.ReleaseInstance(GameObjectHandle);
				}
				if (ObjectHandle.IsValid())
				{
					Addressables.ReleaseInstance(ObjectHandle);
				}
			}
		}

		private const string MeshKey = "Mesh";

		private const string TextureKey = "Texture";

		private const string SpriteAssetKey = "SpriteAsset";

		private const string SpriteKey = "Sprite";

		private static readonly Queue<string> ModLoadQueue = new Queue<string>();

		private static bool isProcessing;

		private readonly Dictionary<string, List<AddressableRecordData>> addressableRecordDataDictionary = new Dictionary<string, List<AddressableRecordData>>();

		private readonly Dictionary<string, List<IResourceLocation>> labelLocations = new Dictionary<string, List<IResourceLocation>>();

		private readonly string[] labels = new string[5] { "Mesh", "Texture", "Sprite", "SpriteAsset", "Prefab" };

		private string currentPath;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void DomainReload()
		{
			isProcessing = false;
			ModLoadQueue.Clear();
		}

		public async void LoadAssetsFromPath(string path)
		{
			lock (ModLoadQueue)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Load enqueueing ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Debug(messageBuilder);
				ModLoadQueue.Enqueue(path);
			}
			await ProcessQueue(LoadModsInternal);
		}

		public async void UnloadAssetsFromPath(string path)
		{
			lock (ModLoadQueue)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Unload enqueueing ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Info(messageBuilder);
				ModLoadQueue.Enqueue(path);
			}
			await ProcessQueue(UnloadModsInternal);
		}

		private async Task ProcessQueue(Func<string, Task> callback)
		{
			if (isProcessing)
			{
				return;
			}
			isProcessing = true;
			while (true)
			{
				string path;
				lock (ModLoadQueue)
				{
					if (ModLoadQueue.Count == 0)
					{
						isProcessing = false;
						break;
					}
					path = ModLoadQueue.Dequeue();
				}
				try
				{
					await callback(path);
				}
				catch (Exception ex)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(23, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Error loading mod at ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
						messageBuilder.AppendLiteral(": ");
						messageBuilder.AppendFormatted(ex.Message);
					}
					Log.Error(messageBuilder);
				}
				path = null;
			}
		}

		private void ReleaseHandles()
		{
			foreach (AddressableRecordData item in addressableRecordDataDictionary.Values.SelectMany((List<AddressableRecordData> list) => list))
			{
				item.Release();
			}
			addressableRecordDataDictionary.Clear();
		}

		private async Task LoadModsInternal(string path)
		{
			_ = 1;
			try
			{
				ClearLabelLocations();
				AddressablesRuntimeProperties.ClearCachedPropertyValues();
				ModdingUtils.SetLoadPath(path);
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				FileInfo fileInfo = directoryInfo.GetFiles().FirstOrDefault((FileInfo f) => f.Extension == ".json");
				bool isEnabled;
				if (fileInfo == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("No valid catalog file at ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
					}
					Log.Error(messageBuilder);
					return;
				}
				IResourceLocator resourceLocator = await LoadCatalog(fileInfo.FullName);
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(23, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Loaded Locators: ");
					messageBuilder2.AppendFormatted(resourceLocator);
					messageBuilder2.AppendLiteral(" from ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(fileInfo.FullName));
				}
				Log.Info(messageBuilder2);
				foreach (object key in resourceLocator.Keys)
				{
					if (!resourceLocator.Locate(key, typeof(object), out var locations))
					{
						FVLogDebugInterpolationHandler messageBuilder3 = new FVLogDebugInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("Could not locate locator ");
							messageBuilder3.AppendFormatted(key);
						}
						Log.Debug(messageBuilder3);
						continue;
					}
					if (!labelLocations.TryGetValue(key.ToString(), out var value))
					{
						FVLogDebugInterpolationHandler messageBuilder3 = new FVLogDebugInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("Could not locate label locator ");
							messageBuilder3.AppendFormatted(key);
						}
						Log.Debug(messageBuilder3);
						continue;
					}
					foreach (IResourceLocation item in locations)
					{
						value.Add(item);
					}
					messageBuilder2 = new FVLogInfoInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Added instance: ");
						messageBuilder2.AppendFormatted(locations[0].PrimaryKey);
						messageBuilder2.AppendLiteral(" ");
						messageBuilder2.AppendFormatted(locations[0].Dependencies[0].InternalId);
					}
					Log.Info(messageBuilder2);
				}
				currentPath = path;
				addressableRecordDataDictionary.TryAdd(currentPath, new List<AddressableRecordData>());
				await LoadAssets();
				messageBuilder2 = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Loaded ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(currentPath));
					messageBuilder2.AppendLiteral(" with ");
					messageBuilder2.AppendFormatted(addressableRecordDataDictionary[currentPath].Count);
					messageBuilder2.AppendLiteral(" assets");
				}
				Log.Info(messageBuilder2);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
			}
		}

		private void ClearLabelLocations()
		{
			foreach (List<IResourceLocation> value in labelLocations.Values)
			{
				value.Clear();
			}
		}

		private async Task LoadAssets()
		{
			List<AsyncOperationHandle> list = new List<AsyncOperationHandle>();
			foreach (KeyValuePair<string, List<IResourceLocation>> labelLocation in labelLocations)
			{
				string key = labelLocation.Key;
				List<IResourceLocation> value = labelLocation.Value;
				switch (key)
				{
				case "Mesh":
					foreach (IResourceLocation location4 in value)
					{
						AsyncOperationHandle<GameObject> asyncOperationHandle4 = Addressables.LoadAssetAsync<GameObject>(location4);
						list.Add(asyncOperationHandle4);
						asyncOperationHandle4.Completed += delegate(AsyncOperationHandle<GameObject> h)
						{
							TryAddMesh(location4.PrimaryKey, h);
						};
					}
					break;
				case "Texture":
					foreach (IResourceLocation location3 in value)
					{
						AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle3 = Addressables.LoadAssetAsync<UnityEngine.Object>(location3);
						list.Add(asyncOperationHandle3);
						asyncOperationHandle3.Completed += delegate(AsyncOperationHandle<UnityEngine.Object> h)
						{
							TryAddTexture(location3.PrimaryKey, h);
						};
					}
					break;
				case "SpriteAsset":
					foreach (IResourceLocation location2 in value)
					{
						AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle2 = Addressables.LoadAssetAsync<UnityEngine.Object>(location2);
						list.Add(asyncOperationHandle2);
						asyncOperationHandle2.Completed += delegate(AsyncOperationHandle<UnityEngine.Object> h)
						{
							TryAddSpriteAsset(location2.PrimaryKey, h);
						};
					}
					break;
				case "Sprite":
					foreach (IResourceLocation location in value)
					{
						AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle = Addressables.LoadAssetAsync<UnityEngine.Object>(location);
						list.Add(asyncOperationHandle);
						asyncOperationHandle.Completed += delegate(AsyncOperationHandle<UnityEngine.Object> h)
						{
							TryAddSprite(location.PrimaryKey, h);
						};
					}
					break;
				}
			}
			await Task.WhenAll(list.Select((AsyncOperationHandle h) => h.Task));
		}

		private void TryAddMesh(string assetId, AsyncOperationHandle<GameObject> asyncOperationHandle)
		{
			bool isEnabled;
			if (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TryAddMesh() failed for key: ");
					messageBuilder.AppendFormatted(assetId);
				}
				Log.Error(messageBuilder);
				return;
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Adding Mesh: ");
				messageBuilder2.AppendFormatted(assetId);
			}
			Log.Trace(messageBuilder2);
			MonoRepository<MeshRepository, KeyGameObjectPair>.Instance.AddNew(assetId, asyncOperationHandle.Result);
			addressableRecordDataDictionary[currentPath].Add(new AddressableRecordData
			{
				Key = "Mesh",
				AssetId = assetId,
				GameObjectHandle = asyncOperationHandle
			});
		}

		private void TryAddTexture(string assetId, AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle)
		{
			bool isEnabled;
			if (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TryAddTexture() failed for key: ");
					messageBuilder.AppendFormatted(assetId);
				}
				Log.Error(messageBuilder);
				return;
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Adding Texture: ");
				messageBuilder2.AppendFormatted(assetId);
			}
			Log.Trace(messageBuilder2);
			MonoRepository<TextureRepository, KeyTexturePair>.Instance.AddNew(assetId, asyncOperationHandle.Result);
			addressableRecordDataDictionary[currentPath].Add(new AddressableRecordData
			{
				Key = "Texture",
				AssetId = assetId,
				ObjectHandle = asyncOperationHandle
			});
		}

		private void TryAddSprite(string assetId, AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle)
		{
			bool isEnabled;
			if (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TryAddTexture() failed for key: ");
					messageBuilder.AppendFormatted(assetId);
				}
				Log.Error(messageBuilder);
				return;
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Adding Sprite: ");
				messageBuilder2.AppendFormatted(assetId);
			}
			Log.Trace(messageBuilder2);
			if (!(asyncOperationHandle.Result is Texture2D texture))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(asyncOperationHandle.Result);
					messageBuilder.AppendLiteral(" Object is not Texture 2D. Can't be converted to Sprite");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Sprite spriteFromTexture = TextureUtils.GetSpriteFromTexture(texture);
				MonoRepository<SpriteRepository, KeySpritePair>.Instance.AddNew(assetId, spriteFromTexture);
				addressableRecordDataDictionary[currentPath].Add(new AddressableRecordData
				{
					Key = "Sprite",
					AssetId = assetId,
					ObjectHandle = asyncOperationHandle
				});
			}
		}

		private void TryAddSpriteAsset(string assetId, AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle)
		{
			bool isEnabled;
			if (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TryAddTexture() failed for key: ");
					messageBuilder.AppendFormatted(assetId);
				}
				Log.Error(messageBuilder);
				return;
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Adding SpriteAsset: ");
				messageBuilder2.AppendFormatted(assetId);
			}
			Log.Trace(messageBuilder2);
			MonoRepository<SpriteAssetRepository, KeySpriteAssetPair>.Instance.AddNew(assetId, asyncOperationHandle.Result);
			addressableRecordDataDictionary[currentPath].Add(new AddressableRecordData
			{
				Key = "SpriteAsset",
				AssetId = assetId,
				ObjectHandle = asyncOperationHandle
			});
		}

		private Task UnloadModsInternal(string path)
		{
			try
			{
				addressableRecordDataDictionary.TryGetValue(path, out var value);
				if (value == null || value.Count == 0)
				{
					return Task.CompletedTask;
				}
				foreach (AddressableRecordData item in value)
				{
					item.Dispose();
				}
				addressableRecordDataDictionary.Remove(path);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\AddressableModManager.cs");
				throw;
			}
			return Task.CompletedTask;
		}

		private async Task<IResourceLocator> LoadCatalog(string path)
		{
			return await Addressables.LoadContentCatalogAsync(path, autoReleaseHandle: true).Task;
		}

		private void Start()
		{
			string[] array = labels;
			foreach (string key in array)
			{
				labelLocations.Add(key, new List<IResourceLocation>());
			}
		}

		protected override void OnDestroy()
		{
			ReleaseHandles();
			base.OnDestroy();
		}
	}
}
