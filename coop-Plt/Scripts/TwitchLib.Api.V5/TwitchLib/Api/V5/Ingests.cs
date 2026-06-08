using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.V5.Models.Ingests;

namespace TwitchLib.Api.V5
{
	public class Ingests : ApiBase
	{
		public Ingests(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<TwitchLib.Api.V5.Models.Ingests.Ingests> GetIngestServerListAsync()
		{
			return TwitchGetGenericAsync<TwitchLib.Api.V5.Models.Ingests.Ingests>("/ingests", ApiVersion.V5);
		}
	}
}
