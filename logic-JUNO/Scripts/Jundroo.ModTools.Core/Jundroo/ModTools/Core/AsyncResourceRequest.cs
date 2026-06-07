using System;
using UnityEngine;

namespace Jundroo.ModTools.Core
{
	public class AsyncResourceRequest<T> : AsyncAssetRequest<T> where T : UnityEngine.Object
	{
		private bool _instantiate;

		public ResourceRequest Request { get; private set; }

		public AsyncResourceRequest(ResourceRequest request, bool instantiate)
			: base((AsyncOperation)request)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			Request = request;
			_instantiate = instantiate;
		}

		protected override T LoadComplete()
		{
			T val = (T)Request.asset;
			if (val == null)
			{
				Debug.LogError("The asynchronously loaded asset was null.");
				return val;
			}
			if (_instantiate)
			{
				val = UnityEngine.Object.Instantiate(val);
				if (val == null)
				{
					Debug.LogError("The asynchronously loaded asset could not be instantiated.");
					return val;
				}
			}
			return val;
		}
	}
}
