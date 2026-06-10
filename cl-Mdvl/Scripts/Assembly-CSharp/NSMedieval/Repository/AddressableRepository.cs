using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace NSMedieval.Repository
{
	public abstract class AddressableRepository<T, TM, TO> : MonoRepository<T, TM> where T : MonoBehaviour where TM : NSEipix.Base.Model where TO : Object
	{
		private readonly List<AsyncOperationHandle<TO>> operationList = new List<AsyncOperationHandle<TO>>();

		private readonly Dictionary<string, HashSet<string>> primaryKeysByLabel = new Dictionary<string, HashSet<string>>();

		private bool loadOnStartup;

		public void SetLoadOnStartup(bool value)
		{
			loadOnStartup = value;
		}

		public void AddNew(string key, Object obj)
		{
			AddNewObject(key, obj);
		}

		public bool HasItemsInLabel(string label)
		{
			if (string.IsNullOrEmpty(label))
			{
				return false;
			}
			if (primaryKeysByLabel.TryGetValue(label, out var value))
			{
				return value.Count > 0;
			}
			return false;
		}

		public List<TO> GetAllByLabel(string label)
		{
			List<TO> list = new List<TO>();
			if (string.IsNullOrEmpty(label))
			{
				Log.Error("Label argument is null or empty", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
				return list;
			}
			bool isEnabled;
			if (!primaryKeysByLabel.TryGetValue(label, out var value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Label ");
					messageBuilder.AppendFormatted(label);
					messageBuilder.AppendLiteral(" does not exist in dictionary!");
				}
				Log.Error(messageBuilder);
				return list;
			}
			foreach (string item in value)
			{
				TO byAddress = GetByAddress(item);
				if (byAddress == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Asset ");
						messageBuilder.AppendFormatted(item);
						messageBuilder.AppendLiteral(" is null!");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					list.Add(byAddress);
				}
			}
			return list;
		}

		public TO GetByAddress(string objectAddress)
		{
			TM byID = GetByID(objectAddress);
			if (byID != null && byID is Pair<TO> pair)
			{
				return pair.Value;
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Couldn't find Addressable Object: ");
				messageBuilder.AppendFormatted(objectAddress);
				messageBuilder.AppendLiteral("!");
			}
			Log.Warning(messageBuilder);
			return null;
		}

		public abstract List<string> AddressableLabels();

		protected virtual List<string> GetLabelsToCache()
		{
			return null;
		}

		protected virtual void OnStart()
		{
		}

		public abstract void AddNewObject(string key, Object obj, bool overwrite = false);

		private void Start()
		{
			if (loadOnStartup)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(27, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loading addressable repo ");
					messageBuilder.AppendFormatted(GetType());
					messageBuilder.AppendLiteral(". ");
				}
				Log.Debug(messageBuilder);
				LoadResources();
				messageBuilder = new FVLogDebugInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loading of addressable repo ");
					messageBuilder.AppendFormatted(GetType());
					messageBuilder.AppendLiteral(" done. ");
				}
				Log.Debug(messageBuilder);
			}
			CacheLabels();
			OnStart();
		}

		public void LoadResources()
		{
			AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(AddressableLabels(), Addressables.MergeMode.Union, typeof(TO));
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<IList<IResourceLocation>> locations)
			{
				int locationsCount = locations.Result.Count;
				int counter = 0;
				List<AsyncOperationHandle> list = new List<AsyncOperationHandle>(locationsCount);
				foreach (IResourceLocation location in locations.Result)
				{
					AsyncOperationHandle<TO> asyncOperationHandle2 = Addressables.LoadAssetAsync<TO>(location);
					asyncOperationHandle2.Completed += delegate(AsyncOperationHandle<TO> handle)
					{
						int num = counter;
						counter = num + 1;
						operationList.Add(handle);
						AddNewObject(location.PrimaryKey, handle.Result);
						if (counter >= locationsCount)
						{
							DebugTimer.EndTimer("TO");
						}
						else
						{
							DebugTimer.LogStep("TO", " --- Loaded " + location.PrimaryKey);
						}
					};
					list.Add(asyncOperationHandle2);
				}
				AsyncOperationHandle<IList<AsyncOperationHandle>> asyncOperationHandle3 = Addressables.ResourceManager.CreateGenericGroupOperation(list, releasedCachedOpOnComplete: true);
				asyncOperationHandle3.Completed += delegate
				{
					Log.Debug("UI Repository Loading Done", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
				};
			};
		}

		private void CacheLabels()
		{
			List<string> labelsToCache = GetLabelsToCache();
			if (labelsToCache == null || labelsToCache.Count == 0)
			{
				return;
			}
			foreach (string label in labelsToCache)
			{
				primaryKeysByLabel[label] = new HashSet<string>();
				if (this is SpriteRepository)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("primaryKeysByLabel['");
						messageBuilder.AppendFormatted(label);
						messageBuilder.AppendLiteral("'] init hash set done");
					}
					Log.Info(messageBuilder);
				}
				AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(new List<string> { label }, Addressables.MergeMode.Union, typeof(TO));
				asyncOperationHandle.Completed += delegate(AsyncOperationHandle<IList<IResourceLocation>> locations)
				{
					foreach (IResourceLocation item in locations.Result)
					{
						primaryKeysByLabel[label].Add(item.PrimaryKey);
					}
					if (this is SpriteRepository)
					{
						bool isEnabled2;
						if (locations.Status == AsyncOperationStatus.Succeeded)
						{
							FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(35, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
							if (isEnabled2)
							{
								messageBuilder2.AppendLiteral("primaryKeysByLabel['");
								messageBuilder2.AppendFormatted(label);
								messageBuilder2.AppendLiteral("'] added ");
								messageBuilder2.AppendFormatted(locations.Result.Count);
								messageBuilder2.AppendLiteral(" items");
							}
							Log.Info(messageBuilder2);
						}
						else
						{
							FVLogErrorInterpolationHandler messageBuilder3 = new FVLogErrorInterpolationHandler(68, 3, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\AddressableRepository.cs");
							if (isEnabled2)
							{
								messageBuilder3.AppendLiteral("primaryKeysByLabel['");
								messageBuilder3.AppendFormatted(label);
								messageBuilder3.AppendLiteral("'] completed with status ");
								messageBuilder3.AppendFormatted(locations.Status);
								messageBuilder3.AppendLiteral(", operation exception: ");
								messageBuilder3.AppendFormatted(locations.OperationException);
							}
							Log.Error(messageBuilder3);
						}
					}
				};
			}
		}

		protected virtual void OnDestroy()
		{
			foreach (AsyncOperationHandle<TO> operation in operationList)
			{
				Addressables.Release(operation);
			}
		}
	}
}
