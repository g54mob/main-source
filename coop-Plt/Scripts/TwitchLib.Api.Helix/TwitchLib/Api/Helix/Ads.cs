using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Ads;

namespace TwitchLib.Api.Helix
{
	public class Ads : ApiBase
	{
		public Ads(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<StartCommercialResponse> StartCommercial(StartCommercialRequest request, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Edit_Commercial, accessToken);
			return TwitchPostGenericAsync<StartCommercialResponse>("/channels/commercial", ApiVersion.Helix, JsonConvert.SerializeObject(request), null, accessToken);
		}
	}
}
