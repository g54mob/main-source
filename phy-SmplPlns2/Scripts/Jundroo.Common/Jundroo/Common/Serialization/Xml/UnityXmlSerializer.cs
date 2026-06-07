using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Jundroo.Common.Serialization.Xml.Attributes;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	public class UnityXmlSerializer
	{
		private delegate void FastSerializeDelegate(SerializableMemberInfo info, XElement element, XName xname, object obj);

		private class SerializableMemberInfo
		{
			public readonly FastSerializeDelegate FastSerialize;

			public readonly FieldInfo Field;

			public readonly int FieldOffset;

			public readonly XmlSerializationNullValueMode NullMode;

			public readonly XmlSerializationFlags Options;

			public SerializableMemberInfo(FieldInfo field, FastSerializeDelegate fastSerializeDelegate)
			{
				Field = field;
				NullMode = XmlSerializationNullValueMode.Default;
				Options = XmlSerializationFlags.Default;
				FastSerialize = fastSerializeDelegate;
				FieldOffset = UnsafeUtility.GetFieldOffset(field);
			}

			public SerializableMemberInfo(FieldInfo field, XmlSerializationNullValueMode nullMode, XmlSerializationFlags options, FastSerializeDelegate fastSerializeDelegate)
			{
				Field = field;
				NullMode = nullMode;
				Options = options;
				FastSerialize = fastSerializeDelegate;
				FieldOffset = UnsafeUtility.GetFieldOffset(field);
			}
		}

		private const string NullString = "__null__";

		private static readonly Dictionary<string, XName> _xnameLookup = new Dictionary<string, XName>();

		private static readonly Dictionary<string, XName> _xnameNoUnderscoreLookup = new Dictionary<string, XName>();

		private static readonly XName _xnameValue = XName.Get("value");

		private static Dictionary<Type, IUnityXmlAttributeSerializer> _defaultAttributeSerializers = new Dictionary<Type, IUnityXmlAttributeSerializer>
		{
			{
				typeof(bool),
				new BoolXmlSerializer()
			},
			{
				typeof(byte),
				new ByteXmlSerializer()
			},
			{
				typeof(char),
				new CharXmlSerializer()
			},
			{
				typeof(DateTimeOffset),
				new DateTimeOffsetXmlSerializer()
			},
			{
				typeof(DateTime),
				new DateTimeXmlSerializer()
			},
			{
				typeof(decimal),
				new DecimalXmlSerializer()
			},
			{
				typeof(double),
				new DoubleXmlSerializer()
			},
			{
				typeof(Guid),
				new GuidXmlSerializer()
			},
			{
				typeof(short),
				new Int16XmlSerializer()
			},
			{
				typeof(int),
				new Int32XmlSerializer()
			},
			{
				typeof(long),
				new Int64XmlSerializer()
			},
			{
				typeof(sbyte),
				new SByteXmlSerializer()
			},
			{
				typeof(float),
				new SingleXmlSerialier()
			},
			{
				typeof(string),
				new StringXmlSerializer()
			},
			{
				typeof(TimeSpan),
				new TimeSpanXmlSerializer()
			},
			{
				typeof(ushort),
				new UInt16XmlSerializer()
			},
			{
				typeof(uint),
				new UInt32XmlSerializer()
			},
			{
				typeof(ulong),
				new UInt64XmlSerializer()
			},
			{
				typeof(Bounds),
				new BoundsXmlSerializer()
			},
			{
				typeof(Color32),
				new Color32XmlSerializer()
			},
			{
				typeof(Color),
				new ColorXmlSerializer()
			},
			{
				typeof(GradientAlphaKey),
				new GradientAlphaKeyXmlSerializer()
			},
			{
				typeof(GradientColorKey),
				new GradientColorKeyXmlSerializer()
			},
			{
				typeof(Keyframe),
				new KeyframeXmlSerializer()
			},
			{
				typeof(LayerMask),
				new LayerMaskXmlSerializer()
			},
			{
				typeof(Matrix4x4),
				new Matrix4x4XmlSerializer()
			},
			{
				typeof(Quaternion),
				new QuaternionXmlSerializer()
			},
			{
				typeof(RectOffset),
				new RectOffsetXmlSerializer()
			},
			{
				typeof(Rect),
				new RectXmlSerializer()
			},
			{
				typeof(Vector2),
				new Vector2XmlSerializer()
			},
			{
				typeof(Vector3),
				new Vector3XmlSerializer()
			},
			{
				typeof(Vector4),
				new Vector4XmlSerializer()
			}
		};

		private static Dictionary<Type, IUnityXmlElementSerializer> _defaultElementSerializers = new Dictionary<Type, IUnityXmlElementSerializer>
		{
			{
				typeof(List<>),
				new ListXmlSerializer()
			},
			{
				typeof(Dictionary<, >),
				new DictionaryXmlSerializer()
			},
			{
				typeof(AnimationCurve),
				new AnimationCurveXmlSerializer()
			},
			{
				typeof(Gradient),
				new GradientXmlSerializer()
			}
		};

		private static Dictionary<Type, Dictionary<string, SerializableMemberInfo>> _memberCache = new Dictionary<Type, Dictionary<string, SerializableMemberInfo>>();

		private static Dictionary<Type, Dictionary<string, SerializableMemberInfo>> _memberCacheNoUnderscores = new Dictionary<Type, Dictionary<string, SerializableMemberInfo>>();

		private Dictionary<Type, IUnityXmlAttributeSerializer> _attributeSerializers;

		private UnityXmlSerializerContext _context;

		private Dictionary<Type, IUnityXmlElementSerializer> _elementSerializers;

		private List<string> _tempMemberNameList = new List<string>();

		public UnityXmlSerializer()
			: this(new UnityXmlSerializerContext())
		{
		}

		public UnityXmlSerializer(UnityXmlSerializerContext context)
		{
			_attributeSerializers = new Dictionary<Type, IUnityXmlAttributeSerializer>(_defaultAttributeSerializers);
			_elementSerializers = new Dictionary<Type, IUnityXmlElementSerializer>(_defaultElementSerializers);
			_context = context;
			_context.Serializer = this;
		}

		public T Deserialize<T>(XElement element)
		{
			return (T)Deserialize(element, typeof(T));
		}

		public void Deserialize<T>(XElement element, T obj)
		{
			Deserialize(element, typeof(T), obj);
		}

		public object Deserialize(XElement element, Type type)
		{
			if (type.IsArray)
			{
				return DeserializeArray(element, type, XmlSerializationFlags.Default);
			}
			if (type.IsEnum)
			{
				return Enum.Parse(type, (string)element.Attribute("value"));
			}
			Type type2 = (type.IsValueType ? (Nullable.GetUnderlyingType(type) ?? type) : type);
			if (TryGetAttributeSerializer(type2, out var attributeSerializer))
			{
				return attributeSerializer.ReadValue(element.Attribute("value"), type, _context);
			}
			if (TryGetElementSerializer(type2, out var elementSerializer))
			{
				return elementSerializer.ReadValue(element, type, _context);
			}
			if (type2.IsSerializable)
			{
				object obj = Activator.CreateInstance(type2);
				Deserialize(element, type2, obj, restoreMissingValuesAsNull: false, null);
				return obj;
			}
			throw new SerializationException($"Could not deserialize type '{type.FullName}'");
		}

		public void Deserialize(XElement element, Type type, object obj)
		{
			Deserialize(element, type, obj, restoreMissingValuesAsNull: false, null);
		}

		public void Deserialize(XElement element, Type type, object obj, bool restoreMissingValuesAsNull, string[] membersToDeserialize)
		{
			List<string> list = null;
			if (membersToDeserialize != null)
			{
				list = _tempMemberNameList;
				list.Clear();
				list.AddRange(membersToDeserialize);
			}
			XAttribute xAttribute = element.Attribute("__null__");
			if (xAttribute != null)
			{
				string[] array = xAttribute.Value.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					SerializableMemberInfo member = GetMember(type, array[i]);
					if (member == null)
					{
						continue;
					}
					_context.MemberSerializationOptions = member.Options;
					FieldInfo field = member.Field;
					if (list == null || list.Remove(field.Name))
					{
						if (field.FieldType == typeof(string) && member.Options.HasFlag(XmlSerializationFlags.NullAsEmptyString))
						{
							field.SetValue(obj, string.Empty);
						}
						else
						{
							field.SetValue(obj, null);
						}
					}
				}
			}
			foreach (XAttribute item in element.Attributes())
			{
				string localName = item.Name.LocalName;
				SerializableMemberInfo member2 = GetMember(type, localName);
				if (member2 == null)
				{
					continue;
				}
				_context.MemberSerializationOptions = member2.Options;
				FieldInfo field2 = member2.Field;
				if (list != null && !list.Remove(field2.Name))
				{
					continue;
				}
				if (item.Value == string.Empty)
				{
					if (member2.NullMode == XmlSerializationNullValueMode.EmptyString)
					{
						field2.SetValue(obj, (field2.FieldType == typeof(string)) ? string.Empty : null);
						continue;
					}
					if (member2.NullMode == XmlSerializationNullValueMode.EmptyStringAlt)
					{
						field2.SetValue(obj, null);
						continue;
					}
				}
				Type type2 = (field2.FieldType.IsValueType ? (Nullable.GetUnderlyingType(field2.FieldType) ?? field2.FieldType) : field2.FieldType);
				IUnityXmlAttributeSerializer attributeSerializer;
				if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(List<>))
				{
					Type type3 = type2.GetGenericArguments()[0];
					if (type3.IsEnum)
					{
						IList list2 = (IList)Activator.CreateInstance(type2);
						string[] array2 = item.Value.Split(',');
						foreach (string value in array2)
						{
							list2.Add(Enum.Parse(type3, value));
						}
						field2.SetValue(obj, list2);
						continue;
					}
					if ((member2.Options & XmlSerializationFlags.SingleAttribute) == XmlSerializationFlags.SingleAttribute && TryGetAttributeSerializer(type3, out attributeSerializer))
					{
						if (!attributeSerializer.SupportsCollections)
						{
							Debug.LogErrorFormat("Attribute Serializer '{0}' does not support collections", attributeSerializer.GetType().FullName);
							return;
						}
						object value2 = attributeSerializer.ReadValues(item, field2.FieldType, _context);
						field2.SetValue(obj, value2);
						continue;
					}
				}
				if (type2.IsEnum)
				{
					object value3 = Enum.Parse(type2, (string)item);
					field2.SetValue(obj, value3);
					continue;
				}
				if (type2.IsArray)
				{
					object value4 = DeserializeArray(item, type2, member2.Options);
					field2.SetValue(obj, value4);
					continue;
				}
				if (TryGetAttributeSerializer(type2, out attributeSerializer))
				{
					object value5 = attributeSerializer.ReadValue(item, field2.FieldType, _context);
					field2.SetValue(obj, value5);
					continue;
				}
				throw new SerializationException($"Could not deserialize field '{field2.Name}' on type '{type.FullName}'");
			}
			foreach (XElement item2 in element.Elements())
			{
				string localName2 = item2.Name.LocalName;
				SerializableMemberInfo member3 = GetMember(type, localName2);
				if (member3 == null)
				{
					continue;
				}
				_context.MemberSerializationOptions = member3.Options;
				FieldInfo field3 = member3.Field;
				if (list != null && !list.Remove(field3.Name))
				{
					continue;
				}
				Type type4 = (field3.FieldType.IsValueType ? (Nullable.GetUnderlyingType(field3.FieldType) ?? field3.FieldType) : field3.FieldType);
				if (type4.IsArray)
				{
					object value6 = DeserializeArray(item2, type4, member3.Options);
					field3.SetValue(obj, value6);
					continue;
				}
				if (TryGetElementSerializer(type4, out var elementSerializer))
				{
					object value7 = elementSerializer.ReadValue(item2, field3.FieldType, _context);
					field3.SetValue(obj, value7);
					continue;
				}
				if (type4.IsSerializable)
				{
					object obj2 = Activator.CreateInstance(type4);
					Deserialize(item2, type4, obj2);
					field3.SetValue(obj, obj2);
					continue;
				}
				throw new SerializationException($"Could not deserialize field '{field3.Name}' on type '{type.FullName}'");
			}
			if (!restoreMissingValuesAsNull || list == null)
			{
				return;
			}
			foreach (string item3 in list)
			{
				SerializableMemberInfo member4 = GetMember(type, item3);
				if (member4 != null)
				{
					_context.MemberSerializationOptions = member4.Options;
					FieldInfo field4 = member4.Field;
					if (field4.FieldType == typeof(string) && member4.Options.HasFlag(XmlSerializationFlags.NullAsEmptyString))
					{
						field4.SetValue(obj, string.Empty);
					}
					else
					{
						field4.SetValue(obj, null);
					}
				}
			}
			list.Clear();
		}

		public XElement Serialize<T>(T obj, params string[] membersToSerialize)
		{
			Type type = obj.GetType();
			XElement xElement = new XElement(type.Name, GetTypeAttribute(type));
			Serialize(xElement, null, type, XmlSerializationNullValueMode.Default, XmlSerializationFlags.Default, obj, membersToSerialize);
			return xElement;
		}

		public void Serialize<T>(XElement element, T obj, params string[] membersToSerialize)
		{
			Serialize(element, null, obj.GetType(), XmlSerializationNullValueMode.Default, XmlSerializationFlags.Default, obj, membersToSerialize);
		}

		public void Serialize(XElement element, Type type, object obj, params string[] membersToSerialize)
		{
			Serialize(element, null, type, XmlSerializationNullValueMode.Default, XmlSerializationFlags.Default, obj, membersToSerialize);
		}

		private unsafe static FastSerializeDelegate GetFastSerializeDelegate(FieldInfo field, XmlSerializationNullValueMode nullMode, XmlSerializationFlags options)
		{
			Type fieldType = field.FieldType;
			if (fieldType == typeof(float))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<float>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(double))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<double>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(int))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<int>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(uint))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<uint>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(long))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<long>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(ulong))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<ulong>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(short))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<short>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(ushort))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<ushort>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(sbyte))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<sbyte>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(byte))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<byte>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(char))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<char>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(bool))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<bool>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(Guid))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					element.Add(new XAttribute(xname, XmlConvert.ToString(Unsafe.AsRef<Guid>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer()))));
				};
			}
			if (fieldType == typeof(Vector2))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					ref Vector2 reference = ref Unsafe.AsRef<Vector2>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer());
					element.Add(new XAttribute(xname, XmlConvert.ToString(reference.x) + "," + XmlConvert.ToString(reference.y)));
				};
			}
			if (fieldType == typeof(Vector3))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					ref Vector3 reference = ref Unsafe.AsRef<Vector3>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer());
					element.Add(new XAttribute(xname, XmlConvert.ToString(reference.x) + "," + XmlConvert.ToString(reference.y) + "," + XmlConvert.ToString(reference.z)));
				};
			}
			if (fieldType == typeof(Vector4))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					ref Vector4 reference = ref Unsafe.AsRef<Vector4>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer());
					element.Add(new XAttribute(xname, XmlConvert.ToString(reference.x) + "," + XmlConvert.ToString(reference.y) + "," + XmlConvert.ToString(reference.z) + "," + XmlConvert.ToString(reference.w)));
				};
			}
			if (fieldType == typeof(Quaternion))
			{
				return delegate(SerializableMemberInfo info, XElement element, XName xname, object obj)
				{
					ref Quaternion reference = ref Unsafe.AsRef<Quaternion>((Unsafe.As<object, IntPtr>(ref obj) + info.FieldOffset).ToPointer());
					element.Add(new XAttribute(xname, XmlConvert.ToString(reference.x) + "," + XmlConvert.ToString(reference.y) + "," + XmlConvert.ToString(reference.z) + "," + XmlConvert.ToString(reference.w)));
				};
			}
			return null;
		}

		private static SerializableMemberInfo GetMember(Type type, string name, bool ignoreUnderscores)
		{
			Dictionary<string, SerializableMemberInfo> memberLookupTable = GetMemberLookupTable(type, ignoreUnderscores);
			if (ignoreUnderscores)
			{
				name = name.TrimStart('_');
			}
			memberLookupTable.TryGetValue(name, out var value);
			return value;
		}

		private static Dictionary<string, SerializableMemberInfo> GetMemberLookupTable(Type type, bool ignoreUnderscores)
		{
			Dictionary<string, SerializableMemberInfo> value = null;
			Dictionary<Type, Dictionary<string, SerializableMemberInfo>> dictionary = (ignoreUnderscores ? _memberCacheNoUnderscores : _memberCache);
			if (!dictionary.TryGetValue(type, out value))
			{
				value = new Dictionary<string, SerializableMemberInfo>();
				List<FieldInfo> list = type.GetFields(BindingFlags.Instance | BindingFlags.Public).ToList();
				GetPrivatesSerializeableFields(list, type);
				foreach (FieldInfo item in list)
				{
					if (!item.IsInitOnly && !Attribute.IsDefined(item, typeof(NonSerializedAttribute)))
					{
						object[] customAttributes = item.GetCustomAttributes(typeof(CustomSerializeFieldBase), inherit: false);
						if (customAttributes.Length > 1)
						{
							Debug.LogWarningFormat("More than 1 {0} attribute has been defined for field {1}.{2}", typeof(CustomSerializeFieldBase).Name, type.FullName, item.Name);
						}
						SerializableMemberInfo value2;
						if (customAttributes.Length != 0)
						{
							CustomSerializeFieldBase customSerializeFieldBase = (CustomSerializeFieldBase)customAttributes[0];
							FastSerializeDelegate fastSerializeDelegate = GetFastSerializeDelegate(item, customSerializeFieldBase.SerializationNullValueMode, customSerializeFieldBase.SerializationOptions);
							value2 = new SerializableMemberInfo(item, customSerializeFieldBase.SerializationNullValueMode, customSerializeFieldBase.SerializationOptions, fastSerializeDelegate);
						}
						else
						{
							FastSerializeDelegate fastSerializeDelegate2 = GetFastSerializeDelegate(item, XmlSerializationNullValueMode.Default, XmlSerializationFlags.Default);
							value2 = new SerializableMemberInfo(item, fastSerializeDelegate2);
						}
						value.Add(ignoreUnderscores ? item.Name.TrimStart('_') : item.Name, value2);
					}
				}
				dictionary[type] = value;
			}
			return value;
		}

		private static void GetPrivatesSerializeableFields(ICollection<FieldInfo> fields, Type type)
		{
			FieldInfo[] fields2 = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (FieldInfo field in fields2)
			{
				if ((Attribute.IsDefined(field, typeof(SerializeField)) || Attribute.IsDefined(field, typeof(CustomSerializeFieldBase))) && !fields.Any((FieldInfo x) => x.Name == field.Name))
				{
					fields.Add(field);
				}
			}
			if (type.BaseType != null)
			{
				GetPrivatesSerializeableFields(fields, type.BaseType);
			}
		}

		private object DeserializeArray(XAttribute attribute, Type type, XmlSerializationFlags options)
		{
			Type elementType = type.GetElementType();
			if (elementType.IsEnum)
			{
				string[] array = attribute.Value.Split(',');
				Array array2 = Array.CreateInstance(elementType, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					array2.SetValue(Enum.Parse(elementType, array[i]), i);
				}
				return array2;
			}
			if ((options & XmlSerializationFlags.SingleAttribute) != XmlSerializationFlags.SingleAttribute)
			{
				Debug.LogErrorFormat("Could not deserialize array stored in attribute '{0}' because the single attribute flag was not set.", attribute.Name.LocalName);
				return null;
			}
			if (!TryGetAttributeSerializer(elementType, out var attributeSerializer))
			{
				Debug.LogErrorFormat("Could not deserialize array stored in attribute '{0}' because no attribute serializer for type '{1}' could be found.", attribute.Name.LocalName, elementType);
				return null;
			}
			if (!attributeSerializer.SupportsCollections)
			{
				Debug.LogErrorFormat("Could not deserialize array stored in attribute '{0}' because no attribute serializer for type '{1}' does not support collections.", attribute.Name.LocalName, elementType);
				return null;
			}
			return attributeSerializer.ReadValues(attribute, type, _context);
		}

		private object DeserializeArray(XElement element, Type type, XmlSerializationFlags options)
		{
			Type elementType = type.GetElementType();
			int length = (int)element.Attribute("length");
			Array array = Array.CreateInstance(elementType, length);
			List<XElement> list = element.Elements().ToList();
			for (int i = 0; i < list.Count; i++)
			{
				array.SetValue(Deserialize(list[i], elementType), i);
			}
			return array;
		}

		private SerializableMemberInfo GetMember(Type type, string name)
		{
			return GetMember(type, name, _context.IgnoreUnderscorePrefix);
		}

		private XAttribute GetTypeAttribute(Type type)
		{
			if (!_context.SaveTypeInfo)
			{
				return null;
			}
			return new XAttribute("__type__", type.AssemblyQualifiedName);
		}

		private XName GetXName(string name)
		{
			XName value = null;
			if (name != null)
			{
				if (_context.IgnoreUnderscorePrefix)
				{
					if (!_xnameNoUnderscoreLookup.TryGetValue(name, out value))
					{
						value = (_xnameNoUnderscoreLookup[name] = XName.Get(name.TrimStart('_')));
					}
				}
				else if (!_xnameLookup.TryGetValue(name, out value))
				{
					value = (_xnameLookup[name] = XName.Get(name));
				}
			}
			return value;
		}

		private void Serialize(XElement element, string name, Type type, XmlSerializationNullValueMode nullMode, XmlSerializationFlags options, object obj, params string[] membersToSerialize)
		{
			XName xName = GetXName(name);
			if (type == typeof(string) && options.HasFlag(XmlSerializationFlags.EmptyStringAsNull) && (string)obj == string.Empty)
			{
				obj = null;
			}
			if (obj == null)
			{
				switch (nullMode)
				{
				case XmlSerializationNullValueMode.Default:
				{
					XAttribute xAttribute = element.Attribute("__null__");
					if (xAttribute == null)
					{
						xAttribute = new XAttribute("__null__", name);
						element.Add(xAttribute);
					}
					else
					{
						XAttribute xAttribute2 = xAttribute;
						xAttribute2.Value = xAttribute2.Value + "," + name;
					}
					break;
				}
				case XmlSerializationNullValueMode.EmptyString:
				case XmlSerializationNullValueMode.EmptyStringAlt:
					element.Add(new XAttribute(xName ?? _xnameValue, string.Empty));
					break;
				}
				return;
			}
			if (type.IsArray)
			{
				SerializeArray(element, xName, type, nullMode, options, obj);
				return;
			}
			if (type.IsEnum)
			{
				bool flag = (options & XmlSerializationFlags.EnumsAsValues) == XmlSerializationFlags.EnumsAsValues;
				element.Add(new XAttribute(xName ?? _xnameValue, ((Enum)obj).ToString(flag ? "D" : "G")));
				return;
			}
			Type type2 = (type.IsValueType ? (Nullable.GetUnderlyingType(type) ?? type) : type);
			IUnityXmlAttributeSerializer attributeSerializer;
			if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(List<>))
			{
				Type type3 = type2.GetGenericArguments()[0];
				if (type3.IsEnum)
				{
					SerializeEnumCollection(element, xName, options, (IEnumerable)obj);
					return;
				}
				if ((options & XmlSerializationFlags.SingleAttribute) == XmlSerializationFlags.SingleAttribute && TryGetAttributeSerializer(type3, out attributeSerializer))
				{
					if (!attributeSerializer.SupportsCollections)
					{
						Debug.LogErrorFormat("Attribute Serializer '{0}' does not support collections", attributeSerializer.GetType().FullName);
					}
					else
					{
						XAttribute xAttribute3 = new XAttribute(xName ?? _xnameValue, string.Empty);
						element.Add(xAttribute3);
						attributeSerializer.WriteValues(xAttribute3, obj, _context);
					}
					return;
				}
			}
			if (TryGetAttributeSerializer(type2, out attributeSerializer))
			{
				XAttribute xAttribute4 = new XAttribute(xName ?? _xnameValue, string.Empty);
				element.Add(xAttribute4);
				attributeSerializer.WriteValue(xAttribute4, obj, _context);
				return;
			}
			if (TryGetElementSerializer(type2, out var elementSerializer))
			{
				XElement xElement = element;
				if (xName != null)
				{
					xElement = new XElement(xName, GetTypeAttribute(type2));
					element.Add(xElement);
				}
				elementSerializer.WriteValue(xElement, obj, _context);
				return;
			}
			if (type2.IsSerializable)
			{
				XElement xElement2 = element;
				if (!string.IsNullOrEmpty(name))
				{
					xElement2 = new XElement(xName, GetTypeAttribute(type2));
					element.Add(xElement2);
				}
				SerializeFields(xElement2, type2, obj, membersToSerialize);
				return;
			}
			throw new SerializationException($"Type '{type2.FullName}' is not marked as serializable.");
		}

		private void SerializeArray(XElement element, XName xname, Type type, XmlSerializationNullValueMode nullMode, XmlSerializationFlags options, object obj)
		{
			Type elementType = type.GetElementType();
			if (elementType.IsEnum)
			{
				SerializeEnumCollection(element, xname, options, (Array)obj);
				return;
			}
			if ((options & XmlSerializationFlags.SingleAttribute) == XmlSerializationFlags.SingleAttribute)
			{
				if (TryGetAttributeSerializer(elementType, out var attributeSerializer))
				{
					if (attributeSerializer.SupportsCollections)
					{
						XAttribute xAttribute = new XAttribute(xname, string.Empty);
						element.Add(xAttribute);
						attributeSerializer.WriteValues(xAttribute, obj, _context);
						return;
					}
					Debug.LogErrorFormat("Could not serialize field '{0}' as a single attribute because the attribute serializer for type '{1}' does not support collections", xname?.LocalName ?? string.Empty, elementType.FullName);
				}
				else
				{
					Debug.LogErrorFormat("Could not serialize field '{0}' as a single attribute because there is no attribute serializer for type '{1}'", xname?.LocalName ?? string.Empty, elementType.FullName);
				}
			}
			Array array = (Array)obj;
			XElement xElement = element;
			if (xname != null)
			{
				xElement = new XElement(xname);
				element.Add(xElement);
			}
			xElement.Add(new XAttribute("length", array.Length));
			for (int i = 0; i < array.Length; i++)
			{
				XElement xElement2 = new XElement("Item");
				Serialize(xElement2, null, elementType, nullMode, options, array.GetValue(i));
				xElement.Add(xElement2);
			}
		}

		private void SerializeEnumCollection(XElement element, XName xname, XmlSerializationFlags options, IEnumerable collection)
		{
			string text = (((options & XmlSerializationFlags.EnumsAsValues) == XmlSerializationFlags.EnumsAsValues) ? "D" : "G");
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (Enum item in collection)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(item.ToString(text));
			}
			XAttribute content = new XAttribute(xname, stringBuilder.ToString());
			element.Add(content);
		}

		private void SerializeFields(XElement element, Type type, object obj, params string[] membersToSerialize)
		{
			foreach (SerializableMemberInfo value in GetMemberLookupTable(type, _context.IgnoreUnderscorePrefix).Values)
			{
				FieldInfo field = value.Field;
				if (membersToSerialize == null || membersToSerialize.Length == 0 || membersToSerialize.Contains(field.Name))
				{
					if (value.FastSerialize != null)
					{
						value.FastSerialize(value, element, GetXName(field.Name), obj);
					}
					else
					{
						Serialize(element, field.Name, field.FieldType, value.NullMode, value.Options, field.GetValue(obj));
					}
				}
			}
		}

		private bool TryGetAttributeSerializer(Type type, out IUnityXmlAttributeSerializer attributeSerializer)
		{
			if (_attributeSerializers.TryGetValue(type, out attributeSerializer))
			{
				return true;
			}
			if (type.IsGenericType && _attributeSerializers.TryGetValue(type.GetGenericTypeDefinition(), out attributeSerializer))
			{
				return true;
			}
			return false;
		}

		private bool TryGetElementSerializer(Type type, out IUnityXmlElementSerializer elementSerializer)
		{
			if (_elementSerializers.TryGetValue(type, out elementSerializer))
			{
				return true;
			}
			if (type.IsGenericType && _elementSerializers.TryGetValue(type.GetGenericTypeDefinition(), out elementSerializer))
			{
				return true;
			}
			return false;
		}
	}
}
