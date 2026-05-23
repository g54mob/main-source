using System.Collections;
using System.Linq;
using System.Reflection;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Generation
{
	public static class SystemTextJsonUtilities
	{
		private sealed class SystemTextJsonContractResolver : DefaultContractResolver
		{
			private readonly dynamic _serializerOptions;

			public SystemTextJsonContractResolver(dynamic serializerOptions)
			{
				_serializerOptions = serializerOptions;
			}

			protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
			{
				object[] customAttributes = member.GetCustomAttributes(inherit: true);
				JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
				bool flag = false;
				object obj = customAttributes.FirstAssignableToTypeNameOrDefault("System.Text.Json.Serialization.JsonIgnoreAttribute");
				if (obj != null)
				{
					object obj2 = obj.TryGetPropertyValue<object>("Condition");
					if (obj2 == null || obj2.ToString() == "Always")
					{
						flag = true;
					}
				}
				jsonProperty.Ignored = flag || customAttributes.FirstAssignableToTypeNameOrDefault("System.Text.Json.Serialization.JsonExtensionDataAttribute") != null;
				if (_serializerOptions.PropertyNamingPolicy != null)
				{
					jsonProperty.PropertyName = _serializerOptions.PropertyNamingPolicy.ConvertName(member.Name);
				}
				dynamic val = customAttributes.FirstAssignableToTypeNameOrDefault("System.Text.Json.Serialization.JsonPropertyNameAttribute");
				if (val != null && !string.IsNullOrEmpty(val.Name))
				{
					jsonProperty.PropertyName = val.Name;
				}
				return jsonProperty;
			}
		}

		public static JsonSerializerSettings ConvertJsonOptionsToNewtonsoftSettings(dynamic serializerOptions)
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
			jsonSerializerSettings.ContractResolver = new SystemTextJsonContractResolver(serializerOptions);
			JsonSerializerSettings jsonSerializerSettings2 = jsonSerializerSettings;
			object obj = ((IEnumerable)serializerOptions.Converters).OfType<object>().FirstOrDefault((object c) => c.GetType().IsAssignableToTypeName("System.Text.Json.Serialization.JsonStringEnumConverter", TypeNameStyle.FullName));
			if (obj == null)
			{
				return jsonSerializerSettings2;
			}
			bool camelCaseText = IsCamelCaseEnumNamingPolicy(obj);
			jsonSerializerSettings2.Converters.Add(new StringEnumConverter(camelCaseText));
			return jsonSerializerSettings2;
		}

		private static bool IsCamelCaseEnumNamingPolicy(object jsonStringEnumConverter)
		{
			try
			{
				object obj = jsonStringEnumConverter.GetType().GetRuntimeFields().FirstOrDefault((FieldInfo x) => x.FieldType.FullName == "System.Text.Json.JsonNamingPolicy")?.GetValue(jsonStringEnumConverter);
				return obj != null && obj.GetType().FullName == "System.Text.Json.JsonCamelCaseNamingPolicy";
			}
			catch
			{
				return false;
			}
		}
	}
}
