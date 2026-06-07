using Jundroo.Common.Resource;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public class AsyncModAssetRequest<T> : AsyncAssetRequest<T> where T : Object
	{
		private ModResourceLoader _modResourceLoader;

		public AssetBundleRequest Request { get; private set; }

		public AsyncModAssetRequest(AssetBundleRequest request, ModResourceLoader modResourceLoader)
			: base((AsyncOperation)request)
		{
			Request = request;
			_modResourceLoader = modResourceLoader;
		}

		protected override T LoadComplete()
		{
			T val = (T)Request.asset;
			if (val is GameObject obj)
			{
				return _modResourceLoader.PostProcessLoadedGameObject(obj) as T;
			}
			if (val is Material material)
			{
				_modResourceLoader.PostProcessLoadedMaterial(material, null, null);
			}
			return val;
		}
	}
}
