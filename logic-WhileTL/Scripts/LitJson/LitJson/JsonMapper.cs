using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace LitJson
{
	public class JsonMapper
	{
		[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
		public class IncludeAttribute : Attribute
		{
		}

		private static int max_nesting_depth;

		private static IFormatProvider datetime_format;

		private static IDictionary<Type, ExporterFunc> base_exporters_table;

		private static IDictionary<Type, ExporterFunc> custom_exporters_table;

		private static IDictionary<Type, IDictionary<Type, ImporterFunc>> base_importers_table;

		private static IDictionary<Type, IDictionary<Type, ImporterFunc>> custom_importers_table;

		private static IDictionary<Type, FactoryFunc> custom_factory_table;

		private static IDictionary<Type, ArrayMetadata> array_metadata;

		private static readonly object array_metadata_lock;

		private static IDictionary<Type, IDictionary<Type, MethodInfo>> conv_ops;

		private static readonly object conv_ops_lock;

		private static IDictionary<Type, ObjectMetadata> object_metadata;

		private static readonly object object_metadata_lock;

		private static IDictionary<Type, IList<PropertyMetadata>> type_properties;

		private static readonly object type_properties_lock;

		private static JsonWriter static_writer;

		private static readonly object static_writer_lock;

		static JsonMapper()
		{
			array_metadata_lock = new object();
			conv_ops_lock = new object();
			object_metadata_lock = new object();
			type_properties_lock = new object();
			static_writer_lock = new object();
			max_nesting_depth = 100;
			array_metadata = new Dictionary<Type, ArrayMetadata>();
			conv_ops = new Dictionary<Type, IDictionary<Type, MethodInfo>>();
			object_metadata = new Dictionary<Type, ObjectMetadata>();
			type_properties = new Dictionary<Type, IList<PropertyMetadata>>();
			static_writer = new JsonWriter();
			datetime_format = DateTimeFormatInfo.InvariantInfo;
			base_exporters_table = new Dictionary<Type, ExporterFunc>();
			custom_exporters_table = new Dictionary<Type, ExporterFunc>();
			base_importers_table = new Dictionary<Type, IDictionary<Type, ImporterFunc>>();
			custom_importers_table = new Dictionary<Type, IDictionary<Type, ImporterFunc>>();
			RegisterBaseExporters();
			RegisterBaseImporters();
			custom_factory_table = new Dictionary<Type, FactoryFunc>();
		}

		private static void AddArrayMetadata(Type type)
		{
			if (array_metadata.ContainsKey(type))
			{
				return;
			}
			ArrayMetadata value = new ArrayMetadata
			{
				IsArray = type.IsArray
			};
			if ((object)type.GetInterface("System.Collections.IList") != null)
			{
				value.IsList = true;
			}
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!(propertyInfo.Name != "Item"))
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters.Length == 1 && (object)indexParameters[0].ParameterType == typeof(int))
					{
						value.ElementType = propertyInfo.PropertyType;
					}
				}
			}
			lock (array_metadata_lock)
			{
				try
				{
					array_metadata.Add(type, value);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void AddObjectMetadata(Type type)
		{
			if (object_metadata.ContainsKey(type))
			{
				return;
			}
			ObjectMetadata value = default(ObjectMetadata);
			if ((object)type.GetInterface("System.Collections.IDictionary") != null)
			{
				value.IsDictionary = true;
			}
			value.Properties = new Dictionary<string, PropertyMetadata>();
			HashSet<string> hashSet = new HashSet<string>();
			object[] customAttributes = type.GetCustomAttributes(inherit: true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Attribute attribute = (Attribute)customAttributes[i];
				if (attribute is JsonIgnoreMember)
				{
					JsonIgnoreMember jsonIgnoreMember = (JsonIgnoreMember)attribute;
					hashSet.UnionWith(jsonIgnoreMember.Members);
				}
			}
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.Name == "Item")
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters.Length == 1 && (object)indexParameters[0].ParameterType == typeof(string))
					{
						value.ElementType = propertyInfo.PropertyType;
					}
				}
				else if (((object)propertyInfo.GetGetMethod() != null && propertyInfo.GetGetMethod().IsPublic) || ((object)propertyInfo.GetSetMethod() != null && propertyInfo.GetSetMethod().IsPublic) || propertyInfo.GetCustomAttributes(typeof(IncludeAttribute), inherit: true).Length != 0)
				{
					PropertyMetadata p_data = new PropertyMetadata
					{
						Info = propertyInfo,
						Type = propertyInfo.PropertyType
					};
					if (hashSet.Contains(propertyInfo.Name))
					{
						p_data.Ignore = JsonIgnoreWhen.Serializing | JsonIgnoreWhen.Deserializing;
					}
					ProcessAttributes(ref p_data, propertyInfo);
					value.Properties.Add(propertyInfo.Name, p_data);
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.IsPublic || fieldInfo.GetCustomAttributes(typeof(IncludeAttribute), inherit: true).Length != 0)
				{
					PropertyMetadata p_data2 = new PropertyMetadata
					{
						Info = fieldInfo,
						IsField = true,
						Type = fieldInfo.FieldType
					};
					if (hashSet.Contains(fieldInfo.Name))
					{
						p_data2.Ignore = JsonIgnoreWhen.Serializing | JsonIgnoreWhen.Deserializing;
					}
					ProcessAttributes(ref p_data2, fieldInfo);
					value.Properties.Add(fieldInfo.Name, p_data2);
				}
			}
			lock (object_metadata_lock)
			{
				try
				{
					object_metadata.Add(type, value);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void AddTypeProperties(Type type)
		{
			if (type_properties.ContainsKey(type))
			{
				return;
			}
			IList<PropertyMetadata> list = new List<PropertyMetadata>();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!(propertyInfo.Name == "Item") && (((object)propertyInfo.GetGetMethod() != null && propertyInfo.GetGetMethod().IsPublic) || ((object)propertyInfo.GetSetMethod() != null && propertyInfo.GetSetMethod().IsPublic)))
				{
					PropertyMetadata p_data = new PropertyMetadata
					{
						Info = propertyInfo,
						IsField = false
					};
					ProcessAttributes(ref p_data, propertyInfo);
					list.Add(p_data);
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.IsPublic || fieldInfo.GetCustomAttributes(typeof(IncludeAttribute), inherit: true).Length != 0)
				{
					PropertyMetadata p_data2 = new PropertyMetadata
					{
						Info = fieldInfo,
						IsField = true
					};
					ProcessAttributes(ref p_data2, fieldInfo);
					list.Add(p_data2);
				}
			}
			lock (type_properties_lock)
			{
				try
				{
					type_properties.Add(type, list);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void ProcessAttributes(ref PropertyMetadata p_data, MemberInfo m_info)
		{
			object[] customAttributes = m_info.GetCustomAttributes(inherit: true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Attribute attribute = (Attribute)customAttributes[i];
				if (attribute is JsonIgnore)
				{
					JsonIgnore jsonIgnore = (JsonIgnore)attribute;
					p_data.Ignore = jsonIgnore.Usage;
				}
			}
		}

		private static object CreateInstance(Type type)
		{
			if (custom_factory_table.TryGetValue(type, out var value))
			{
				return value();
			}
			type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null)?.Invoke(null);
			return Activator.CreateInstance(type);
		}

		private static MethodInfo GetConvOp(Type t1, Type t2)
		{
			lock (conv_ops_lock)
			{
				if (!conv_ops.ContainsKey(t1))
				{
					conv_ops.Add(t1, new Dictionary<Type, MethodInfo>());
				}
			}
			if (conv_ops[t1].ContainsKey(t2))
			{
				return conv_ops[t1][t2];
			}
			MethodInfo method = t1.GetMethod("op_Implicit", new Type[1] { t2 });
			lock (conv_ops_lock)
			{
				try
				{
					conv_ops[t1].Add(t2, method);
					return method;
				}
				catch (ArgumentException)
				{
					return conv_ops[t1][t2];
				}
			}
		}

		private static object ReadValue(Type inst_type, JsonReader reader)
		{
			reader.Read();
			if (reader.Token == JsonToken.ArrayEnd)
			{
				return null;
			}
			Type underlyingType = Nullable.GetUnderlyingType(inst_type);
			Type type = underlyingType ?? inst_type;
			if (reader.Token == JsonToken.Null)
			{
				if (inst_type.IsClass || (object)underlyingType != null)
				{
					return null;
				}
				throw new JsonException($"Can't assign null to an instance of type {inst_type}");
			}
			if (reader.Token == JsonToken.Double || reader.Token == JsonToken.Int || reader.Token == JsonToken.Long || reader.Token == JsonToken.String || reader.Token == JsonToken.Boolean)
			{
				Type type2 = reader.Value.GetType();
				if (type.IsAssignableFrom(type2))
				{
					return reader.Value;
				}
				if (custom_importers_table.ContainsKey(type2) && custom_importers_table[type2].ContainsKey(type))
				{
					ImporterFunc importerFunc = custom_importers_table[type2][type];
					return importerFunc(reader.Value);
				}
				if (base_importers_table.ContainsKey(type2) && base_importers_table[type2].ContainsKey(type))
				{
					ImporterFunc importerFunc2 = base_importers_table[type2][type];
					return importerFunc2(reader.Value);
				}
				if (type.IsEnum)
				{
					return Enum.ToObject(type, reader.Value);
				}
				MethodInfo convOp = GetConvOp(type, type2);
				if ((object)convOp != null)
				{
					return convOp.Invoke(null, new object[1] { reader.Value });
				}
				throw new JsonException($"Can't assign value '{reader.Value}' (type {type2}) to type {inst_type}");
			}
			object obj = null;
			if (reader.Token == JsonToken.ArrayStart)
			{
				ImporterFunc importerFunc3 = null;
				if (custom_importers_table.ContainsKey(typeof(JsonData)) && custom_importers_table[typeof(JsonData)].ContainsKey(inst_type))
				{
					importerFunc3 = custom_importers_table[typeof(JsonData)][inst_type];
					inst_type = typeof(JsonData);
				}
				AddArrayMetadata(inst_type);
				ArrayMetadata arrayMetadata = array_metadata[inst_type];
				if (!arrayMetadata.IsArray && !arrayMetadata.IsList)
				{
					throw new JsonException($"Type {inst_type} can't act as an array");
				}
				IList list;
				Type elementType;
				if (!arrayMetadata.IsArray)
				{
					list = (IList)CreateInstance(inst_type);
					elementType = arrayMetadata.ElementType;
				}
				else
				{
					list = new ArrayList();
					elementType = inst_type.GetElementType();
				}
				while (true)
				{
					object obj2 = ReadValue(elementType, reader);
					if (obj2 == null && reader.Token == JsonToken.ArrayEnd)
					{
						break;
					}
					list.Add(obj2);
				}
				if (arrayMetadata.IsArray)
				{
					int count = list.Count;
					obj = Array.CreateInstance(elementType, count);
					for (int i = 0; i < count; i++)
					{
						((Array)obj).SetValue(list[i], i);
					}
				}
				else
				{
					obj = list;
				}
				if (importerFunc3 != null)
				{
					obj = importerFunc3(obj);
				}
			}
			else if (reader.Token == JsonToken.ObjectStart)
			{
				bool flag = false;
				string text = null;
				reader.Read();
				if (reader.Token == JsonToken.ObjectEnd)
				{
					flag = true;
				}
				else
				{
					text = (string)reader.Value;
					if (reader.TypeHinting && text == reader.HintTypeName)
					{
						reader.Read();
						string typeName = (string)reader.Value;
						reader.Read();
						if ((string)reader.Value == reader.HintValueName)
						{
							type = Type.GetType(typeName);
							object result = ReadValue(type, reader);
							reader.Read();
							if (reader.Token != JsonToken.ObjectEnd)
							{
								throw new JsonException("Invalid type hinting object, has too many properties");
							}
							return result;
						}
						throw new JsonException("Expected __value__ property for type hinting but instead got " + reader.Value);
					}
				}
				ImporterFunc importerFunc4 = null;
				if (custom_importers_table.ContainsKey(typeof(JsonData)) && custom_importers_table[typeof(JsonData)].ContainsKey(type))
				{
					importerFunc4 = custom_importers_table[typeof(JsonData)][type];
					type = typeof(JsonData);
				}
				AddObjectMetadata(type);
				ObjectMetadata objectMetadata = object_metadata[type];
				obj = CreateInstance(type);
				bool flag2 = true;
				while (!flag)
				{
					if (flag2)
					{
						flag2 = false;
					}
					else
					{
						reader.Read();
						if (reader.Token == JsonToken.ObjectEnd)
						{
							break;
						}
						text = (string)reader.Value;
					}
					if (objectMetadata.Properties.ContainsKey(text))
					{
						PropertyMetadata propertyMetadata = objectMetadata.Properties[text];
						if ((propertyMetadata.Ignore & JsonIgnoreWhen.Deserializing) > JsonIgnoreWhen.Never)
						{
							ReadSkip(reader);
							continue;
						}
						if (propertyMetadata.IsField)
						{
							((FieldInfo)propertyMetadata.Info).SetValue(obj, ReadValue(propertyMetadata.Type, reader));
							continue;
						}
						PropertyInfo propertyInfo = (PropertyInfo)propertyMetadata.Info;
						if (propertyInfo.CanWrite)
						{
							propertyInfo.SetValue(obj, ReadValue(propertyMetadata.Type, reader), null);
						}
						else
						{
							ReadValue(propertyMetadata.Type, reader);
						}
					}
					else if (!objectMetadata.IsDictionary)
					{
						if (!reader.SkipNonMembers)
						{
							throw new JsonException($"The type {inst_type} doesn't have the property '{text}'");
						}
						ReadSkip(reader);
					}
					else
					{
						((IDictionary)obj).Add(text, ReadValue(objectMetadata.ElementType, reader));
					}
				}
				if (importerFunc4 != null)
				{
					obj = importerFunc4(obj);
				}
			}
			return obj;
		}

		private static IJsonWrapper ReadValue(WrapperFactory factory, JsonReader reader)
		{
			reader.Read();
			if (reader.Token == JsonToken.ArrayEnd || reader.Token == JsonToken.Null)
			{
				return null;
			}
			IJsonWrapper jsonWrapper = factory();
			if (reader.Token == JsonToken.String)
			{
				jsonWrapper.SetString((string)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Double)
			{
				jsonWrapper.SetDouble((double)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Int)
			{
				jsonWrapper.SetInt((int)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Long)
			{
				jsonWrapper.SetLong((long)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Boolean)
			{
				jsonWrapper.SetBoolean((bool)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.ArrayStart)
			{
				jsonWrapper.SetJsonType(JsonType.Array);
				while (true)
				{
					IJsonWrapper jsonWrapper2 = ReadValue(factory, reader);
					if (jsonWrapper2 == null && reader.Token == JsonToken.ArrayEnd)
					{
						break;
					}
					jsonWrapper.Add(jsonWrapper2);
				}
			}
			else if (reader.Token == JsonToken.ObjectStart)
			{
				jsonWrapper.SetJsonType(JsonType.Object);
				while (true)
				{
					reader.Read();
					if (reader.Token == JsonToken.ObjectEnd)
					{
						break;
					}
					string key = (string)reader.Value;
					jsonWrapper[key] = ReadValue(factory, reader);
				}
			}
			return jsonWrapper;
		}

		private static void ReadSkip(JsonReader reader)
		{
			ToWrapper(() => new JsonMockWrapper(), reader);
		}

		private static void RegisterBaseExporters()
		{
			base_exporters_table[typeof(byte)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((byte)obj));
			};
			base_exporters_table[typeof(char)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToString((char)obj));
			};
			base_exporters_table[typeof(DateTime)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToString((DateTime)obj, datetime_format));
			};
			base_exporters_table[typeof(float)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToDouble((float)obj));
			};
			base_exporters_table[typeof(decimal)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write((decimal)obj);
			};
			base_exporters_table[typeof(sbyte)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((sbyte)obj));
			};
			base_exporters_table[typeof(short)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((short)obj));
			};
			base_exporters_table[typeof(ushort)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((ushort)obj));
			};
			base_exporters_table[typeof(uint)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToUInt64((uint)obj));
			};
			base_exporters_table[typeof(ulong)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write((ulong)obj);
			};
			base_exporters_table[typeof(float)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToDouble((float)obj));
			};
		}

		private static void RegisterBaseImporters()
		{
			ImporterFunc importer = (object input) => Convert.ToByte((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(byte), importer);
			importer = (object input) => Convert.ToUInt64((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(ulong), importer);
			importer = (object input) => Convert.ToSByte((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(sbyte), importer);
			importer = (object input) => Convert.ToInt16((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(short), importer);
			importer = (object input) => Convert.ToUInt16((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(ushort), importer);
			importer = (object input) => Convert.ToUInt32((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(uint), importer);
			importer = (object input) => Convert.ToInt64((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(long), importer);
			importer = (object input) => Convert.ToSingle((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(float), importer);
			importer = (object input) => Convert.ToSingle((double)input);
			RegisterImporter(base_importers_table, typeof(double), typeof(float), importer);
			importer = (object input) => Convert.ToDouble((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(double), importer);
			importer = (object input) => Convert.ToDecimal((double)input);
			RegisterImporter(base_importers_table, typeof(double), typeof(decimal), importer);
			importer = (object input) => Convert.ToUInt32((long)input);
			RegisterImporter(base_importers_table, typeof(long), typeof(uint), importer);
			importer = (object input) => Convert.ToChar((string)input);
			RegisterImporter(base_importers_table, typeof(string), typeof(char), importer);
			importer = (object input) => Convert.ToDateTime((string)input, datetime_format);
			RegisterImporter(base_importers_table, typeof(string), typeof(DateTime), importer);
			importer = (object input) => Convert.ToInt64((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(long), importer);
		}

		private static void RegisterImporter(IDictionary<Type, IDictionary<Type, ImporterFunc>> table, Type json_type, Type value_type, ImporterFunc importer)
		{
			if (!table.ContainsKey(json_type))
			{
				table.Add(json_type, new Dictionary<Type, ImporterFunc>());
			}
			table[json_type][value_type] = importer;
		}

		private static void WriteValue(object obj, JsonWriter writer, bool writer_is_private, int depth)
		{
			if (depth > max_nesting_depth)
			{
				throw new JsonException($"Max allowed object depth reached while trying to export from type {obj.GetType()}");
			}
			if (obj == null)
			{
				writer.Write(null);
				return;
			}
			if (obj is IJsonWrapper)
			{
				if (writer_is_private)
				{
					writer.TextWriter.Write(((IJsonWrapper)obj).ToJson());
				}
				else
				{
					((IJsonWrapper)obj).ToJson(writer);
				}
				return;
			}
			if (obj is string)
			{
				writer.Write((string)obj);
				return;
			}
			if (obj is double)
			{
				writer.Write((double)obj);
				return;
			}
			if (obj is int)
			{
				writer.Write((int)obj);
				return;
			}
			if (obj is bool)
			{
				writer.Write((bool)obj);
				return;
			}
			if (obj is long)
			{
				writer.Write((long)obj);
				return;
			}
			if (obj is Array)
			{
				writer.WriteArrayStart();
				Array array = (Array)obj;
				Type elementType = array.GetType().GetElementType();
				foreach (object item in array)
				{
					if (writer.TypeHinting && ((item != null) & ((object)item.GetType() != elementType)))
					{
						writer.WriteObjectStart();
						writer.WritePropertyName(writer.HintTypeName);
						writer.Write(item.GetType().FullName);
						writer.WritePropertyName(writer.HintValueName);
						WriteValue(item, writer, writer_is_private, depth + 1);
						writer.WriteObjectEnd();
					}
					else
					{
						WriteValue(item, writer, writer_is_private, depth + 1);
					}
				}
				writer.WriteArrayEnd();
				return;
			}
			if (obj is IList)
			{
				writer.WriteArrayStart();
				IList list = (IList)obj;
				Type type = typeof(object);
				if (list.GetType().GetGenericArguments().Length > 0)
				{
					type = list.GetType().GetGenericArguments()[0];
				}
				foreach (object item2 in list)
				{
					if (writer.TypeHinting && item2 != null && (object)item2.GetType() != type)
					{
						writer.WriteObjectStart();
						writer.WritePropertyName(writer.HintTypeName);
						writer.Write(item2.GetType().AssemblyQualifiedName);
						writer.WritePropertyName(writer.HintValueName);
						WriteValue(item2, writer, writer_is_private, depth + 1);
						writer.WriteObjectEnd();
					}
					else
					{
						WriteValue(item2, writer, writer_is_private, depth + 1);
					}
				}
				writer.WriteArrayEnd();
				return;
			}
			if (obj is IDictionary)
			{
				writer.WriteObjectStart();
				IDictionary dictionary = (IDictionary)obj;
				Type type2 = typeof(object);
				if (dictionary.GetType().GetGenericArguments().Length > 1)
				{
					type2 = dictionary.GetType().GetGenericArguments()[1];
				}
				foreach (DictionaryEntry item3 in dictionary)
				{
					writer.WritePropertyName((string)item3.Key);
					if (writer.TypeHinting && item3.Value != null && (object)item3.Value.GetType() != type2)
					{
						writer.WriteObjectStart();
						writer.WritePropertyName(writer.HintTypeName);
						writer.Write(item3.Value.GetType().AssemblyQualifiedName);
						writer.WritePropertyName(writer.HintValueName);
						WriteValue(item3.Value, writer, writer_is_private, depth + 1);
						writer.WriteObjectEnd();
					}
					else
					{
						WriteValue(item3.Value, writer, writer_is_private, depth + 1);
					}
				}
				writer.WriteObjectEnd();
				return;
			}
			Type type3 = obj.GetType();
			if (custom_exporters_table.ContainsKey(type3))
			{
				ExporterFunc exporterFunc = custom_exporters_table[type3];
				exporterFunc(obj, writer);
				return;
			}
			if (base_exporters_table.ContainsKey(type3))
			{
				ExporterFunc exporterFunc2 = base_exporters_table[type3];
				exporterFunc2(obj, writer);
				return;
			}
			if (obj is Enum)
			{
				Type underlyingType = Enum.GetUnderlyingType(type3);
				if ((object)underlyingType == typeof(long) || (object)underlyingType == typeof(uint) || (object)underlyingType == typeof(ulong))
				{
					writer.Write((ulong)obj);
				}
				else
				{
					writer.Write((int)obj);
				}
				return;
			}
			AddTypeProperties(type3);
			IList<PropertyMetadata> list2 = type_properties[type3];
			writer.WriteObjectStart();
			foreach (PropertyMetadata item4 in list2)
			{
				if ((item4.Ignore & JsonIgnoreWhen.Serializing) > JsonIgnoreWhen.Never)
				{
					continue;
				}
				if (item4.IsField)
				{
					FieldInfo fieldInfo = (FieldInfo)item4.Info;
					writer.WritePropertyName(fieldInfo.Name);
					object value = fieldInfo.GetValue(obj);
					if (writer.TypeHinting && value != null && (object)fieldInfo.FieldType != value.GetType())
					{
						writer.WriteObjectStart();
						writer.WritePropertyName(writer.HintTypeName);
						writer.Write(value.GetType().AssemblyQualifiedName);
						writer.WritePropertyName(writer.HintValueName);
						WriteValue(value, writer, writer_is_private, depth + 1);
						writer.WriteObjectEnd();
					}
					else
					{
						WriteValue(value, writer, writer_is_private, depth + 1);
					}
					continue;
				}
				PropertyInfo propertyInfo = (PropertyInfo)item4.Info;
				if (propertyInfo.CanRead)
				{
					writer.WritePropertyName(propertyInfo.Name);
					object value2 = propertyInfo.GetValue(obj, null);
					if (writer.TypeHinting && value2 != null && (object)propertyInfo.PropertyType != value2.GetType())
					{
						writer.WriteObjectStart();
						writer.WritePropertyName(writer.HintTypeName);
						writer.Write(value2.GetType().AssemblyQualifiedName);
						writer.WritePropertyName(writer.HintValueName);
						WriteValue(value2, writer, writer_is_private, depth + 1);
						writer.WriteObjectEnd();
					}
					else
					{
						WriteValue(value2, writer, writer_is_private, depth + 1);
					}
				}
			}
			writer.WriteObjectEnd();
		}

		public static string ToJson(object obj)
		{
			lock (static_writer_lock)
			{
				static_writer.Reset();
				WriteValue(obj, static_writer, writer_is_private: true, 0);
				return static_writer.ToString();
			}
		}

		public static void ToJson(object obj, JsonWriter writer)
		{
			WriteValue(obj, writer, writer_is_private: false, 0);
		}

		public static JsonData ToObject(JsonReader reader)
		{
			return (JsonData)ToWrapper(() => new JsonData(), reader);
		}

		public static JsonData ToObject(TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			return (JsonData)ToWrapper(() => new JsonData(), reader2);
		}

		public static JsonData ToObject(string json)
		{
			return (JsonData)ToWrapper(() => new JsonData(), json);
		}

		public static T ToObject<T>(JsonReader reader)
		{
			return (T)ReadValue(typeof(T), reader);
		}

		public static T ToObject<T>(TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			return (T)ReadValue(typeof(T), reader2);
		}

		public static T ToObject<T>(string json)
		{
			JsonReader reader = new JsonReader(json);
			return (T)ReadValue(typeof(T), reader);
		}

		public static object ToObject(Type type, JsonReader reader)
		{
			return ReadValue(type, reader);
		}

		public static object ToObject(Type type, TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			return ReadValue(type, reader2);
		}

		public static object ToObject(Type type, string json)
		{
			JsonReader reader = new JsonReader(json);
			return ReadValue(type, reader);
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, JsonReader reader)
		{
			return ReadValue(factory, reader);
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, string json)
		{
			JsonReader reader = new JsonReader(json);
			return ReadValue(factory, reader);
		}

		public static void RegisterExporter<T>(ExporterFunc<T> exporter)
		{
			ExporterFunc value = delegate(object obj, JsonWriter writer)
			{
				exporter((T)obj, writer);
			};
			custom_exporters_table[typeof(T)] = value;
		}

		public static void RegisterImporter<TJson, TValue>(ImporterFunc<TJson, TValue> importer)
		{
			ImporterFunc importer2 = (object input) => importer((TJson)input);
			RegisterImporter(custom_importers_table, typeof(TJson), typeof(TValue), importer2);
		}

		public static void RegisterFactory<T>(FactoryFunc<T> factory)
		{
			FactoryFunc value = () => factory();
			custom_factory_table[typeof(T)] = value;
		}

		public static void UnregisterExporters()
		{
			custom_exporters_table.Clear();
		}

		public static void UnregisterImporters()
		{
			custom_importers_table.Clear();
		}
	}
}
