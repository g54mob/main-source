using System;
using Muna.API;
using Muna.Beta;
using Muna.Services;

namespace Muna
{
	public sealed class Muna
	{
		[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
		public sealed class EmbedAttribute : Attribute
		{
			internal readonly string[] tags;

			public EmbedAttribute(params string[] tags)
			{
				this.tags = tags;
			}
		}

		public readonly UserService Users;

		public readonly PredictorService Predictors;

		public readonly PredictionService Predictions;

		public readonly BetaClient Beta;

		public readonly MunaClient client;

		public const string Version = "0.0.51";

		internal const string URL = "https://api.muna.ai/v1";

		public Muna(string? accessKey = null, string? url = null)
			: this(new DotNetClient(url ?? "https://api.muna.ai/v1", accessKey))
		{
		}

		public Muna(MunaClient client)
		{
			this.client = client;
			Users = new UserService(client);
			Predictors = new PredictorService(client);
			Predictions = new PredictionService(client);
			Beta = new BetaClient(client, Predictors, Predictions);
		}
	}
}
