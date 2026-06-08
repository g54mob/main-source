using System;

namespace Amazon.Runtime.Internal
{
	public abstract class EndpointOperationContextBase
	{
		private string _customerCredentials;

		private string _operationName;

		private EndpointDiscoveryDataBase _endpointDiscoveryData;

		private bool _evictCacheKey;

		private Uri _evictUri;

		public virtual string CustomerCredentials
		{
			get
			{
				return _customerCredentials;
			}
			protected set
			{
				_customerCredentials = value;
			}
		}

		public virtual string OperationName
		{
			get
			{
				return _operationName;
			}
			protected set
			{
				_operationName = value;
			}
		}

		public virtual EndpointDiscoveryDataBase EndpointDiscoveryData
		{
			get
			{
				return _endpointDiscoveryData;
			}
			protected set
			{
				_endpointDiscoveryData = value;
			}
		}

		public virtual bool EvictCacheKey
		{
			get
			{
				return _evictCacheKey;
			}
			protected set
			{
				_evictCacheKey = value;
			}
		}

		public virtual Uri EvictUri
		{
			get
			{
				return _evictUri;
			}
			protected set
			{
				_evictUri = value;
			}
		}

		protected EndpointOperationContextBase(string customerCredentials, string operationName, EndpointDiscoveryDataBase endpointDiscoveryData, bool evictCacheKey, Uri evictUri)
		{
			if (string.IsNullOrEmpty(customerCredentials))
			{
				throw new ArgumentNullException("customerCredentials");
			}
			_customerCredentials = customerCredentials;
			_operationName = operationName;
			_endpointDiscoveryData = endpointDiscoveryData;
			_evictCacheKey = evictCacheKey;
			_evictUri = evictUri;
		}
	}
}
