using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[Preserve]
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class SerializedObject : IEnumerable, IEnumerable<SerializedObject.Field>, IAddValue<object>, IAddKeyValue<string, object>, IExportToXml, IExportToJson
	{
		[CustomObfuscation]
		public enum ObjectType
		{
			[CustomObfuscation]
			Object = 0,
			[CustomObfuscation]
			List = 1
		}

		[Flags]
		[CustomObfuscation]
		public enum FieldOptions
		{
			[CustomObfuscation]
			None = 0,
			[CustomObfuscation]
			ExculdeFromXml = 1
		}

		private struct Entry
		{
			public Type type;

			public object value;

			public FieldOptions options;

			public Entry(Type type, object value, FieldOptions options)
			{
				this.type = null;
				this.value = null;
				this.options = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		public struct Field
		{
			public string name;

			public object value;

			public Type type;

			public FieldOptions options;

			public Field(string name, object value, Type type, FieldOptions options)
			{
				this.name = null;
				this.value = null;
				this.type = null;
				this.options = default(FieldOptions);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		public class XmlInfo
		{
			public abstract class XmlAttribute
			{
			}

			public class XmlStringAttribute : XmlAttribute
			{
				public string prefix;

				public string localName;

				public string ns;

				public string value;

				public override string ToString()
				{
					return null;
				}
			}

			private List<XmlAttribute> tQnygpeOrZFMVzzBXAeMUbYAMIc;

			public List<XmlAttribute> attributes => null;

			public override string ToString()
			{
				return null;
			}
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, Entry> iHWfZKxYOWmGDbHEFecrCgvIBgZ;

			private Field SvDJmbKfwTjjfajTMZMARNttaRfc;

			private IEnumerator<KeyValuePair<string, Entry>> tHrbznpgyCaZrLEPHilYiVzqLmvG;

			public Field Current => default(Field);

			object IEnumerator.Current => null;

			internal Enumerator(object dictionary)
			{
				iHWfZKxYOWmGDbHEFecrCgvIBgZ = null;
				SvDJmbKfwTjjfajTMZMARNttaRfc = default(Field);
				tHrbznpgyCaZrLEPHilYiVzqLmvG = null;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
			}
		}

		private class XmlDocument
		{
			public class Element
			{
				public readonly string name;

				public readonly Element parent;

				public string content;

				public Dictionary<string, string> attributes;

				public List<Element> children;

				public int childCount => 0;

				public int attributeCount => 0;

				public Element(string name, Element parent)
				{
				}

				public void AddChild(Element element)
				{
				}

				public void AddAttribute(string key, string value)
				{
				}

				public bool ContainsChild(string name)
				{
					return false;
				}

				public Element FindChild(string name)
				{
					return null;
				}

				public object GetSerializedObject()
				{
					return null;
				}

				public override string ToString()
				{
					return null;
				}

				private string ToString(string s, int indent)
				{
					return null;
				}
			}

			private readonly Element _root;

			public Element root => null;

			public bool isValid => false;

			public XmlDocument(string xml)
			{
			}

			private void ReadAll(XmlReader reader)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		private readonly IndexedDictionary<string, Entry> DRTZZplcOrJkvpeigufVjZxVgJh;

		private XmlInfo FKfOrfJMDSjkaRxFRmkxhoNgWrp;

		private Type JafvOZeUKqlluyTklnnzmjcQYBv;

		private ObjectType KbEKgKZacvYXdYlqBCBqsCVUBr;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> XUeEcFLMtYzwmcjtTLBxqzGdDYK;

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> jxFGcqFWwTbCEFsfrtxlDWqBHvRm;

		[CompilerGenerated]
		private static Func<FieldInfo, bool> GUtEutEEzltmqOpNYrKXdcztHioU;

		[CompilerGenerated]
		private static Func<FieldInfo, string> eeshfSnjdakpwyldchITaKDVJgk;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> PMFgKODWxLTyBmECZLlgueLpCWy;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> nuYGPCFnTpnRxsxtFFfaweJivfP;

		private bool allowDuplicateKeys => false;

		public ObjectType objectType
		{
			get
			{
				return default(ObjectType);
			}
			set
			{
			}
		}

		public Type type => null;

		public XmlInfo xmlInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int count => 0;

		public Field Item => default(Field);

		bool IExportToXml.writesOwnElementTag => false;

		[CustomObfuscation]
		private SerializedObject()
		{
		}

		private SerializedObject(int capacity)
		{
		}

		public SerializedObject(Type type, ObjectType objectType)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
		{
		}

		public SerializedObject(Type type, IDictionary<string, object> dictionary, ObjectType objectType)
		{
		}

		public void Add<T>(string fieldName, T value, FieldOptions options = FieldOptions.None)
		{
		}

		public void Add(Type type, string fieldName, object value, FieldOptions options = FieldOptions.None)
		{
		}

		public void Add(string fieldName, object value)
		{
		}

		public bool Remove(string fieldName)
		{
			return false;
		}

		public bool Contains(string fieldName)
		{
			return false;
		}

		public Type GetDataType(string fieldName)
		{
			return null;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			return false;
		}

		public Field GetEntry(string fieldName)
		{
			return default(Field);
		}

		public object GetOriginalValue(string fieldName)
		{
			return null;
		}

		public object GetOriginalValue(int index)
		{
			return null;
		}

		public T GetOriginalValue<T>(string fieldName)
		{
			return default(T);
		}

		public T GetOriginalValue<T>(int index)
		{
			return default(T);
		}

		public bool TryGetDeserializedValue<T>(string fieldName, out T value)
		{
			value = default(T);
			return false;
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			value = default(T);
			return false;
		}

		public bool TryGetDeserializedValueByRef<T>(string fieldName, ref T value)
		{
			return false;
		}

		public bool TryGetDeserializedValueByRef<T>(int index, ref T value)
		{
			return false;
		}

		public string ToXmlString(bool writeDocumentTag)
		{
			return null;
		}

		public string ToJsonString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		private void WriteXml(XmlWriter writer)
		{
		}

		private void WriteXml_Value(XmlWriter writer)
		{
		}

		void IExportToXml.WriteXml(XmlWriter writer)
		{
		}

		void IExportToJson.WriteJson(StringBuilder stringBuilder, Action<StringBuilder, object> appendValueDelegate)
		{
		}

		void IAddValue<object>.Add(object value)
		{
		}

		void IAddKeyValue<string, object>.Add(string key, object value)
		{
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private static bool TryConvertOrCreateObject<T>(object obj, out T result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			result = default(T);
			return false;
		}

		private static bool TryConvertOrCreateObject(Type targetType, object obj, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			result = null;
			return false;
		}

		private static bool TryCreateObject(Type type, SerializedObject serializedObject, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			result = null;
			return false;
		}

		public static SerializedObject FromJson(Type type, string jsonString)
		{
			return null;
		}

		public static SerializedObject FromXml(Type type, string xmlString)
		{
			return null;
		}
	}
}
