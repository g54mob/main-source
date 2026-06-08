using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public abstract class EndpointDiscoveryResolverBase
	{
		private IClientConfig _config;

		private Logger _logger;

		private LruCache<string, IList<DiscoveryEndpointBase>> _cache;

		private object objectCacheLock = new object();

		private const int _cacheKeyValidityInSeconds = 3600;

		private readonly bool _isServiceUrlSet;

		public virtual int CacheCount => _cache.Count;

		protected EndpointDiscoveryResolverBase(IClientConfig config, Logger logger)
		{
			_config = config;
			_logger = logger;
			_cache = new LruCache<string, IList<DiscoveryEndpointBase>>(config.EndpointDiscoveryCacheLimit);
			_isServiceUrlSet = !string.IsNullOrEmpty(config.ServiceURL);
		}

		public virtual IEnumerable<DiscoveryEndpointBase> ResolveEndpoints(EndpointOperationContextBase context, Func<IList<DiscoveryEndpointBase>> InvokeEndpointOperation)
		{
			if (_isServiceUrlSet)
			{
				return null;
			}
			string cacheKey = BuildEndpointDiscoveryCacheKey(context);
			_cache.EvictExpiredLRUListItems(3600);
			bool refreshCache = false;
			IEnumerable<DiscoveryEndpointBase> enumerable = ProcessEndpointCache(cacheKey, context.EvictCacheKey, context.EvictUri, out refreshCache);
			if (enumerable != null)
			{
				if (refreshCache)
				{
					Task.Run(delegate
					{
						ProcessInvokeEndpointOperation(cacheKey, InvokeEndpointOperation, endpointRequired: false);
					});
				}
				return enumerable;
			}
			if (context.EvictCacheKey)
			{
				return null;
			}
			if (context.EndpointDiscoveryData.Required)
			{
				enumerable = ProcessInvokeEndpointOperation(cacheKey, InvokeEndpointOperation, endpointRequired: true);
			}
			else if (_config.EndpointDiscoveryEnabled)
			{
				Task.Run(delegate
				{
					ProcessInvokeEndpointOperation(cacheKey, InvokeEndpointOperation, endpointRequired: false);
				});
				return null;
			}
			return enumerable;
		}

		private IEnumerable<DiscoveryEndpointBase> ProcessInvokeEndpointOperation(string cacheKey, Func<IList<DiscoveryEndpointBase>> InvokeEndpointOperation, bool endpointRequired)
		{
			IList<DiscoveryEndpointBase> list = null;
			try
			{
				list = InvokeEndpointOperation();
				if (list != null && list.Count > 0)
				{
					_cache.AddOrUpdate(cacheKey, list);
				}
				else
				{
					list = null;
					if (!endpointRequired)
					{
						List<DiscoveryEndpointBase> list2 = new List<DiscoveryEndpointBase>();
						list2.Add(new DiscoveryEndpoint(null, 1L));
						_cache.AddOrUpdate(cacheKey, list2);
					}
					_logger.DebugFormat("The request to discover endpoints did not return any endpoints.");
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "An unhandled exception occurred while trying to discover endpoints.");
			}
			if (list == null && endpointRequired)
			{
				throw new AmazonClientException("Failed to discover the endpoint for the request. Requests will not succeed until an endpoint can be retrieved or an endpoint is manually specified.");
			}
			return list;
		}

		public virtual IList<DiscoveryEndpointBase> GetDiscoveryEndpointsFromCache(string cacheKey)
		{
			IList<DiscoveryEndpointBase> value = null;
			if (!_cache.TryGetValue(cacheKey, out value))
			{
				return null;
			}
			return value;
		}

		private IEnumerable<DiscoveryEndpointBase> ProcessEndpointCache(string cacheKey, bool evictCacheKey, Uri evictUri, out bool refreshCache)
		{
			refreshCache = false;
			IList<DiscoveryEndpointBase> discoveryEndpointsFromCache = GetDiscoveryEndpointsFromCache(cacheKey);
			if (evictCacheKey && discoveryEndpointsFromCache != null)
			{
				string value = evictUri.ToString();
				lock (objectCacheLock)
				{
					for (int i = 0; i < discoveryEndpointsFromCache.Count; i++)
					{
						DiscoveryEndpointBase discoveryEndpointBase = discoveryEndpointsFromCache[i];
						if (discoveryEndpointBase.Address != null && discoveryEndpointBase.Address.Equals(value, StringComparison.OrdinalIgnoreCase))
						{
							discoveryEndpointsFromCache.RemoveAt(i);
							break;
						}
					}
				}
				if (discoveryEndpointsFromCache.Count == 0)
				{
					_cache.Evict(cacheKey);
					return null;
				}
			}
			if (discoveryEndpointsFromCache != null)
			{
				foreach (DiscoveryEndpointBase item in discoveryEndpointsFromCache)
				{
					if (item.HasExpired())
					{
						refreshCache = true;
						item.ExtendExpiration(1L);
					}
				}
				return discoveryEndpointsFromCache;
			}
			return null;
		}

		private static string BuildEndpointDiscoveryCacheKey(EndpointOperationContextBase context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(context.CustomerCredentials);
			SortedDictionary<string, string> identifiers = context.EndpointDiscoveryData.Identifiers;
			if (identifiers != null && identifiers.Count > 0)
			{
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, ".{0}", context.OperationName));
				foreach (KeyValuePair<string, string> item in identifiers)
				{
					stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, ".{0}", item.Value));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
