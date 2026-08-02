using System;
using Newtonsoft.Json.Linq;
using Rhizomatic.Utility;

namespace Rhizomatic.Reactive
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class JsonDataStateAttribute : JsonDataAttribute
	{
		public JsonDataStateAttribute(string key = "")
			: base(null, null, hasDefaultValue: false, null, null)
		{
		}

		private static object Serialize(object value)
		{
			return null;
		}

		private static void Deserialize(object target, JsonData.Member member, JToken value)
		{
		}
	}
}
