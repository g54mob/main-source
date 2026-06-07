using UnityEngine;

namespace Jundroo.ModTools.Core
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
			return (T)Request.asset;
		}
	}
}
