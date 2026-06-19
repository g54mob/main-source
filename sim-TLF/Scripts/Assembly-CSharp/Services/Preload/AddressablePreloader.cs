using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Zenject;

namespace Services.Preload
{
	public class AddressablePreloader : IInitializable, IDisposable
	{
		public const string PreloadLabel = "preload";

		private readonly List<AsyncOperationHandle> _handles = new List<AsyncOperationHandle>();

		public bool IsCompleted { get; private set; }

		public float Progress { get; private set; }

		public event Action<float> OnProgressChanged;

		public event Action OnPreloadCompleted;

		void IInitializable.Initialize()
		{
			PreloadAllAsync().Forget();
		}

		private async UniTaskVoid PreloadAllAsync()
		{
			AsyncOperationHandle<IList<IResourceLocation>> locationsHandle;
			try
			{
				locationsHandle = Addressables.LoadResourceLocationsAsync("preload", typeof(UnityEngine.Object));
				await locationsHandle.ToUniTask();
			}
			catch (Exception ex)
			{
				Debug.Log("[Preloader] Лейбл 'preload' не знайдено, пропускаємо. (" + ex.GetType().Name + ")");
				Complete();
				return;
			}
			if (locationsHandle.Status != AsyncOperationStatus.Succeeded)
			{
				Debug.LogWarning("[Preloader] Не вдалось отримати локації для лейблу 'preload'.");
				Addressables.Release(locationsHandle);
				Complete();
				return;
			}
			IList<IResourceLocation> result = locationsHandle.Result;
			Addressables.Release(locationsHandle);
			if (result == null || result.Count == 0)
			{
				Debug.Log("[Preloader] Немає адресаблів з лейблом 'preload'.");
				Complete();
				return;
			}
			Debug.Log($"[Preloader] Починаю фонове завантаження {result.Count} асетів...");
			int total = result.Count;
			int done = 0;
			foreach (IResourceLocation location in result)
			{
				AsyncOperationHandle<UnityEngine.Object> handle = Addressables.LoadAssetAsync<UnityEngine.Object>(location);
				_handles.Add(handle);
				await handle.ToUniTask();
				if (handle.Status != AsyncOperationStatus.Succeeded)
				{
					Debug.LogWarning("[Preloader] Не вдалось завантажити: " + location.PrimaryKey);
				}
				done++;
				Progress = (float)done / (float)total;
				this.OnProgressChanged?.Invoke(Progress);
				await UniTask.Yield(PlayerLoopTiming.Update);
			}
			Complete();
		}

		private void Complete()
		{
			IsCompleted = true;
			Debug.Log("[Preloader] Фонове завантаження завершено.");
			this.OnPreloadCompleted?.Invoke();
		}

		void IDisposable.Dispose()
		{
			foreach (AsyncOperationHandle handle in _handles)
			{
				if (handle.IsValid())
				{
					Addressables.Release(handle);
				}
			}
			_handles.Clear();
		}
	}
}
