using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Predictions.CreatePrediction;
using TwitchLib.Api.Helix.Models.Predictions.EndPrediction;
using TwitchLib.Api.Helix.Models.Predictions.GetPredictions;

namespace TwitchLib.Api.Helix
{
	public class Predictions : ApiBase
	{
		public Predictions(IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
			: base(settings, rateLimiter, http)
		{
		}

		public Task<GetPredictionsResponse> GetPredictions(string broadcasterId, List<string> ids = null, string after = null, int first = 20, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Read_Predictions, accessToken);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
				new KeyValuePair<string, string>("first", first.ToString())
			};
			if (ids != null && ids.Count > 0)
			{
				foreach (string id in ids)
				{
					list.Add(new KeyValuePair<string, string>("id", id));
				}
			}
			if (after != null)
			{
				list.Add(new KeyValuePair<string, string>("after", after));
			}
			return TwitchGetGenericAsync<GetPredictionsResponse>("/predictions", ApiVersion.Helix, list, accessToken);
		}

		public Task<CreatePredictionResponse> CreatePrediction(CreatePredictionRequest request, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Manage_Predictions, accessToken);
			return TwitchPostGenericAsync<CreatePredictionResponse>("/predictions", ApiVersion.Helix, JsonConvert.SerializeObject(request), null, accessToken);
		}

		public Task<EndPredictionResponse> EndPrediction(string broadcasterId, string id, PredictionStatusEnum status, string winningOutcomeId = null, string accessToken = null)
		{
			DynamicScopeValidation(AuthScopes.Helix_Channel_Manage_Predictions, accessToken);
			JObject jObject = new JObject();
			jObject["broadcaster_id"] = broadcasterId;
			jObject["id"] = id;
			jObject["status"] = status.ToString();
			if (winningOutcomeId != null)
			{
				jObject["winning_outcome_id"] = winningOutcomeId;
			}
			return TwitchPatchGenericAsync<EndPredictionResponse>("/predictions", ApiVersion.Helix, jObject.ToString(), null, accessToken);
		}
	}
}
