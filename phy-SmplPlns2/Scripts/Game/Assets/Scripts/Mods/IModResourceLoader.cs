using System;
using Assets.Scripts.Mods.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Resource;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public interface IModResourceLoader
	{
		ModInfo ModInfo { get; }

		event EventHandler<GameObjectLoadedEventArgs> GameObjectLoaded;

		T LoadAsset<T>(string path) where T : UnityEngine.Object;

		UnityEngine.Object LoadAsset(string path, Type type);

		UniTask<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object;

		AsyncAssetRequest<UnityEngine.Object> LoadAssetAsyncRequest(string path, Type type);

		AsyncAssetRequest<T> LoadAssetAsyncRequest<T>(string path) where T : UnityEngine.Object;
	}
}
