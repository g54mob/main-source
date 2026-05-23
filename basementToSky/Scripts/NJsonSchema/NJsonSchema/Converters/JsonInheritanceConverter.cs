using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Converters
{
	public class JsonInheritanceConverter : JsonConverter
	{
		private readonly Type _baseType;

		private readonly string _discriminatorName;

		private readonly bool _readTypeProperty;

		[ThreadStatic]
		private static bool _isReading;

		[ThreadStatic]
		private static bool _isWriting;

		public static string DefaultDiscriminatorName { get; } = "discriminator";

		public virtual string DiscriminatorName => _discriminatorName;

		public override bool CanWrite
		{
			get
			{
				if (_isWriting)
				{
					_isWriting = false;
					return false;
				}
				return true;
			}
		}

		public override bool CanRead
		{
			get
			{
				if (_isReading)
				{
					_isReading = false;
					return false;
				}
				return true;
			}
		}

		public JsonInheritanceConverter()
			: this(DefaultDiscriminatorName, readTypeProperty: false)
		{
		}

		public JsonInheritanceConverter(string discriminatorName)
			: this(discriminatorName, readTypeProperty: false)
		{
		}

		public JsonInheritanceConverter(string discriminatorName, bool readTypeProperty)
		{
			_discriminatorName = discriminatorName;
			_readTypeProperty = readTypeProperty;
		}

		public JsonInheritanceConverter(Type baseType)
			: this(baseType, DefaultDiscriminatorName, readTypeProperty: false)
		{
		}

		public JsonInheritanceConverter(Type baseType, string discriminatorName)
			: this(baseType, discriminatorName, readTypeProperty: false)
		{
		}

		public JsonInheritanceConverter(Type baseType, string discriminatorName, bool readTypeProperty)
			: this(discriminatorName, readTypeProperty)
		{
			_baseType = baseType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			try
			{
				_isWriting = true;
				JObject jObject = JObject.FromObject(value, serializer);
				jObject[_discriminatorName] = JToken.FromObject(GetDiscriminatorValue(value.GetType()));
				writer.WriteToken(jObject.CreateReader());
			}
			finally
			{
				_isWriting = false;
			}
		}

		public override bool CanConvert(Type objectType)
		{
			if (_baseType != null)
			{
				Type type = objectType;
				while (type != null)
				{
					if (type == _baseType)
					{
						return true;
					}
					type = type.GetTypeInfo().BaseType;
				}
				return false;
			}
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jObject = serializer.Deserialize<JObject>(reader);
			if (jObject == null)
			{
				return null;
			}
			string discriminatorValue = jObject.GetValue(_discriminatorName, StringComparison.OrdinalIgnoreCase)?.Value<string>();
			Type discriminatorType = GetDiscriminatorType(jObject, objectType, discriminatorValue);
			if (!(serializer.ContractResolver.ResolveContract(discriminatorType) is JsonObjectContract jsonObjectContract) || jsonObjectContract.Properties.All((JsonProperty p) => p.PropertyName != _discriminatorName))
			{
				jObject.Remove(_discriminatorName);
			}
			try
			{
				_isReading = true;
				return serializer.Deserialize(jObject.CreateReader(), discriminatorType);
			}
			finally
			{
				_isReading = false;
			}
		}

		public virtual string GetDiscriminatorValue(Type type)
		{
			string subtypeDiscriminator = GetSubtypeDiscriminator(type);
			if (subtypeDiscriminator != null)
			{
				return subtypeDiscriminator;
			}
			return type.Name;
		}

		protected virtual Type GetDiscriminatorType(JObject jObject, Type objectType, string discriminatorValue)
		{
			Type objectSubtype = GetObjectSubtype(objectType, discriminatorValue);
			if (objectSubtype != null)
			{
				return objectSubtype;
			}
			if (objectType.Name == discriminatorValue)
			{
				return objectType;
			}
			Type subtypeFromKnownTypeAttributes = GetSubtypeFromKnownTypeAttributes(objectType, discriminatorValue);
			if (subtypeFromKnownTypeAttributes != null)
			{
				return subtypeFromKnownTypeAttributes;
			}
			string name = objectType.Namespace + "." + discriminatorValue;
			Type type = objectType.GetTypeInfo().Assembly.GetType(name);
			if (type != null)
			{
				return type;
			}
			if (_readTypeProperty)
			{
				JToken value = jObject.GetValue("$type");
				if (value != null)
				{
					return Type.GetType(value.Value<string>());
				}
			}
			throw new InvalidOperationException("Could not find subtype of '" + objectType.Name + "' with discriminator '" + discriminatorValue + "'.");
		}

		private Type GetSubtypeFromKnownTypeAttributes(Type objectType, string discriminator)
		{
			Type type = objectType;
			do
			{
				IEnumerable<object> enumerable = from a in type.GetTypeInfo().GetCustomAttributes(inherit: false)
					where a.GetType().Name == "KnownTypeAttribute"
					select a;
				foreach (dynamic item in enumerable)
				{
					if (item.Type != null && item.Type.Name == discriminator)
					{
						return item.Type;
					}
					if (!((item.MethodName != null) ? true : false))
					{
						continue;
					}
					MethodInfo runtimeMethod = type.GetRuntimeMethod((string)item.MethodName, new Type[0]);
					if (!(runtimeMethod != null))
					{
						continue;
					}
					IEnumerable<Type> enumerable2 = (IEnumerable<Type>)runtimeMethod.Invoke(null, new object[0]);
					foreach (Type item2 in enumerable2)
					{
						if (item2.Name == discriminator)
						{
							return item2;
						}
					}
					return null;
				}
				type = type.GetTypeInfo().BaseType;
			}
			while (type != null);
			return null;
		}

		private static Type GetObjectSubtype(Type baseType, string discriminatorName)
		{
			IEnumerable<JsonInheritanceAttribute> source = baseType.GetTypeInfo().GetCustomAttributes(inherit: true).OfType<JsonInheritanceAttribute>();
			return source.SingleOrDefault((JsonInheritanceAttribute a) => a.Key == discriminatorName)?.Type;
		}

		private static string GetSubtypeDiscriminator(Type objectType)
		{
			IEnumerable<JsonInheritanceAttribute> source = objectType.GetTypeInfo().GetCustomAttributes(inherit: true).OfType<JsonInheritanceAttribute>();
			return source.SingleOrDefault((JsonInheritanceAttribute a) => a.Type == objectType)?.Key;
		}
	}
}
