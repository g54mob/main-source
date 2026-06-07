using System;
using Newtonsoft.Json.Serialization;

namespace Coherence.Log.Targets
{
	public class LogJsonContractResolver : DefaultContractResolver
	{
		protected override JsonContract CreateContract(Type objectType)
		{
			return null;
		}
	}
}
