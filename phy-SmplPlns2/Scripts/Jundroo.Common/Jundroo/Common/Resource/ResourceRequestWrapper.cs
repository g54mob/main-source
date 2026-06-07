using UnityEngine;

namespace Jundroo.Common.Resource
{
	public class ResourceRequestWrapper<T> where T : Object
	{
		private bool _logErrors;

		public T Asset
		{
			get
			{
				Object asset = Request.asset;
				if (asset == null && _logErrors)
				{
					Debug.LogErrorFormat("The asset at path '{0}' could not be found.", Path);
				}
				return (T)asset;
			}
		}

		public string Path { get; }

		public ResourceRequest Request { get; }

		public ResourceRequestWrapper(ResourceRequest request, string path, bool logErrors = true)
		{
			Request = request;
			Path = path;
			_logErrors = logErrors;
		}
	}
}
