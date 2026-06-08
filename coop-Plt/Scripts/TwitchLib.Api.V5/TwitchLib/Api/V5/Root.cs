using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Models.Root;

namespace TwitchLib.Api.V5
{
	public class Root : ApiBase
	{
		public Root(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<TwitchLib.Api.Core.Models.Root.Root> GetRootAsync(string authToken = null, string clientId = null)
		{
			return TwitchGetGenericAsync<TwitchLib.Api.Core.Models.Root.Root>("", ApiVersion.V5, null, authToken, clientId);
		}
	}
}
