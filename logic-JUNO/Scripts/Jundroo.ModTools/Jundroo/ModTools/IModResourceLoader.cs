using System;
using UnityEngine;

namespace Jundroo.ModTools
{
	public interface IModResourceLoader
	{
		T LoadAsset<T>(string path) where T : UnityEngine.Object;

		UnityEngine.Object LoadAsset(string path, Type type);

		AsyncAssetRequest<UnityEngine.Object> LoadAssetAsync(string path, Type type);

		AsyncAssetRequest<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object;
	}
}
