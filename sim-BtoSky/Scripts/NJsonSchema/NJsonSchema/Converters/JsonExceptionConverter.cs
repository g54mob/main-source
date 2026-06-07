using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Converters
{
	public class JsonExceptionConverter : JsonConverter
	{
		private readonly DefaultContractResolver _defaultContractResolver = new DefaultContractResolver();

		private readonly IDictionary<string, Assembly> _searchedNamespaces;

		private readonly bool _hideStackTrace;

		public override bool CanWrite => true;

		public JsonExceptionConverter()
			: this(hideStackTrace: true, new Dictionary<string, Assembly>())
		{
		}

		public JsonExceptionConverter(bool hideStackTrace, IDictionary<string, Assembly> searchedNamespaces)
		{
			_hideStackTrace = hideStackTrace;
			_searchedNamespaces = searchedNamespaces;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is Exception ex)
			{
				DefaultContractResolver defaultContractResolver = (serializer.ContractResolver as DefaultContractResolver) ?? _defaultContractResolver;
				JObject jObject = new JObject();
				jObject.Add(defaultContractResolver.GetResolvedPropertyName("discriminator"), ex.GetType().Name);
				jObject.Add(defaultContractResolver.GetResolvedPropertyName("Message"), ex.Message);
				jObject.Add(defaultContractResolver.GetResolvedPropertyName("StackTrace"), _hideStackTrace ? "HIDDEN" : ex.StackTrace);
				jObject.Add(defaultContractResolver.GetResolvedPropertyName("Source"), ex.Source);
				jObject.Add(defaultContractResolver.GetResolvedPropertyName("InnerException"), (ex.InnerException != null) ? JToken.FromObject(ex.InnerException, serializer) : null);
				foreach (KeyValuePair<PropertyInfo, string> exceptionProperty in GetExceptionProperties(value.GetType()))
				{
					object value2 = exceptionProperty.Key.GetValue(ex);
					if (value2 != null)
					{
						jObject.AddFirst(new JProperty(defaultContractResolver.GetResolvedPropertyName(exceptionProperty.Value), JToken.FromObject(value2, serializer)));
					}
				}
				value = jObject;
			}
			serializer.Serialize(writer, value);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Exception).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jObject = serializer.Deserialize<JObject>(reader);
			if (jObject == null)
			{
				return null;
			}
			JsonSerializer jsonSerializer = new JsonSerializer();
			jsonSerializer.ContractResolver = (IContractResolver)Activator.CreateInstance(serializer.ContractResolver.GetType());
			FieldInfo field = GetField(typeof(DefaultContractResolver), "_sharedCache");
			if (field != null)
			{
				field.SetValue(jsonSerializer.ContractResolver, false);
			}
			dynamic contractResolver = jsonSerializer.ContractResolver;
			if (jsonSerializer.ContractResolver.GetType().GetRuntimeProperty("IgnoreSerializableAttribute") != null)
			{
				contractResolver.IgnoreSerializableAttribute = true;
			}
			if (jsonSerializer.ContractResolver.GetType().GetRuntimeProperty("IgnoreSerializableInterface") != null)
			{
				contractResolver.IgnoreSerializableInterface = true;
			}
			if (jObject.TryGetValue("discriminator", StringComparison.OrdinalIgnoreCase, out JToken value))
			{
				string text = value.Value<string>();
				if (!objectType.Name.Equals(text))
				{
					Type type = Type.GetType("System." + text, throwOnError: false);
					if (type != null)
					{
						objectType = type;
					}
					else
					{
						foreach (KeyValuePair<string, Assembly> searchedNamespace in _searchedNamespaces)
						{
							type = searchedNamespace.Value.GetType(searchedNamespace.Key + "." + text);
							if (type != null)
							{
								objectType = type;
								break;
							}
						}
					}
				}
			}
			object obj = jObject.ToObject(objectType, jsonSerializer);
			foreach (KeyValuePair<PropertyInfo, string> exceptionProperty in GetExceptionProperties(obj.GetType()))
			{
				object value2 = jObject.GetValue(contractResolver.GetResolvedPropertyName(exceptionProperty.Value))?.ToObject(exceptionProperty.Key.PropertyType);
				if (exceptionProperty.Key.SetMethod != null)
				{
					exceptionProperty.Key.SetValue(obj, value2);
					continue;
				}
				string text2 = exceptionProperty.Value.Substring(0, 1).ToLowerInvariant() + exceptionProperty.Value.Substring(1);
				field = GetField(objectType, "m_" + text2);
				if (field != null)
				{
					field.SetValue(obj, value2);
					continue;
				}
				field = GetField(objectType, "_" + text2);
				if (field != null)
				{
					field.SetValue(obj, value2);
				}
			}
			SetExceptionFieldValue(jObject, "Message", obj, "_message", contractResolver, jsonSerializer);
			SetExceptionFieldValue(jObject, "StackTrace", obj, "_stackTraceString", contractResolver, jsonSerializer);
			SetExceptionFieldValue(jObject, "Source", obj, "_source", contractResolver, jsonSerializer);
			SetExceptionFieldValue(jObject, "InnerException", obj, "_innerException", contractResolver, serializer);
			return obj;
		}

		private FieldInfo GetField(Type type, string fieldName)
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			FieldInfo declaredField = typeInfo.GetDeclaredField(fieldName);
			if (declaredField == null && typeInfo.BaseType != null)
			{
				return GetField(typeInfo.BaseType, fieldName);
			}
			return declaredField;
		}

		private IDictionary<PropertyInfo, string> GetExceptionProperties(Type exceptionType)
		{
			Dictionary<PropertyInfo, string> dictionary = new Dictionary<PropertyInfo, string>();
			foreach (PropertyInfo item in from p in exceptionType.GetRuntimeProperties()
				where p.GetMethod?.IsPublic ?? false
				select p)
			{
				JsonPropertyAttribute customAttribute = item.GetCustomAttribute<JsonPropertyAttribute>();
				string value = ((customAttribute != null) ? customAttribute.PropertyName : item.Name);
				if (!new string[8] { "Message", "StackTrace", "Source", "InnerException", "Data", "TargetSite", "HelpLink", "HResult" }.Contains(value))
				{
					dictionary[item] = value;
				}
			}
			return dictionary;
		}

		private void SetExceptionFieldValue(JObject jObject, string propertyName, object value, string fieldName, IContractResolver resolver, JsonSerializer serializer)
		{
			FieldInfo declaredField = typeof(Exception).GetTypeInfo().GetDeclaredField(fieldName);
			string jsonPropertyName = ((resolver is DefaultContractResolver) ? ((DefaultContractResolver)resolver).GetResolvedPropertyName(propertyName) : propertyName);
			JProperty jProperty = jObject.Properties().FirstOrDefault((JProperty p) => string.Equals(p.Name, jsonPropertyName, StringComparison.OrdinalIgnoreCase));
			if (jProperty != null)
			{
				object value2 = jProperty.Value.ToObject(declaredField.FieldType, serializer);
				declaredField.SetValue(value, value2);
			}
		}
	}
}
