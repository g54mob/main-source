using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.Internal
{
	[RequiresUnreferencedCode("ClientContext has not been updated to support producing JSON using source generators. For requests that need client context JSON the JSON must be created manually.")]
	public class ClientContext
	{
		private const string CLIENT_KEY = "client";

		private const string CLIENT_ID_KEY = "client_id";

		private const string CLIENT_APP_TITLE_KEY = "app_title";

		private const string CLIENT_APP_VERSION_NAME_KEY = "app_version_name";

		private const string CLIENT_APP_VERSION_CODE_KEY = "app_version_code";

		private const string CLIENT_APP_PACKAGE_NAME_KEY = "app_package_name";

		private const string CUSTOM_KEY = "custom";

		private const string ENV_KEY = "env";

		private const string ENV_PLATFORM_KEY = "platform";

		private const string ENV_MODEL_KEY = "model";

		private const string ENV_MAKE_KEY = "make";

		private const string ENV_PLATFORM_VERSION_KEY = "platform_version";

		private const string ENV_LOCALE_KEY = "locale";

		private const string SERVICES_KEY = "services";

		private const string SERVICE_MOBILE_ANALYTICS_KEY = "mobile_analytics";

		private const string SERVICE_MOBILE_ANALYTICS_APP_ID_KEY = "app_id";

		private IDictionary<string, string> _client;

		private IDictionary<string, string> _custom;

		private IDictionary<string, string> _env;

		private IDictionary<string, IDictionary> _services;

		private IDictionary _clientContext;

		private static object _lock = new object();

		private const string APP_ID_KEY = "APP_ID_KEY";

		private const string CLIENT_ID_CACHE_FILENAME = "client-ID-cache";

		public string AppID { get; set; }

		public void AddCustomAttributes(string key, string value)
		{
			lock (_lock)
			{
				if (_custom == null)
				{
					_custom = new Dictionary<string, string>();
				}
				_custom.Add(key, value);
			}
		}

		public string ToJsonString()
		{
			lock (_lock)
			{
				_client = new Dictionary<string, string>();
				_env = new Dictionary<string, string>();
				_services = new Dictionary<string, IDictionary>();
				if (!string.IsNullOrEmpty(AppID))
				{
					IDictionary dictionary = new Dictionary<string, string>();
					dictionary.Add("app_id", AppID);
					_services.Add("mobile_analytics", dictionary);
				}
				_clientContext = new Dictionary<string, IDictionary>();
				_clientContext.Add("client", _client);
				_clientContext.Add("env", _env);
				_clientContext.Add("custom", _custom);
				_clientContext.Add("services", _services);
				return JsonSerializer.Serialize(_clientContext);
			}
		}
	}
}
