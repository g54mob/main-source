using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Pathfinding.Util;
using Pathfinding.WindowsStore;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class TinyJsonDeserializer
	{
		private TextReader reader;

		private string fullTextDebug;

		private GameObject contextRoot;

		private static readonly NumberFormatInfo numberFormat = NumberFormatInfo.InvariantInfo;

		private StringBuilder builder = new StringBuilder();

		public static object Deserialize(string text, Type type, object populate = null, GameObject contextRoot = null)
		{
			return new TinyJsonDeserializer
			{
				reader = new StringReader(text),
				fullTextDebug = text,
				contextRoot = contextRoot
			}.Deserialize(type, populate);
		}

		private object Deserialize(Type tp, object populate = null)
		{
			Type typeInfo = WindowsStoreCompatibility.GetTypeInfo(tp);
			if (typeInfo.IsEnum)
			{
				return Enum.Parse(tp, EatField());
			}
			if (TryEat('n'))
			{
				Eat("ull");
				TryEat(',');
				return null;
			}
			if (object.Equals(tp, typeof(float)))
			{
				return float.Parse(EatField(), numberFormat);
			}
			if (object.Equals(tp, typeof(int)))
			{
				return int.Parse(EatField(), numberFormat);
			}
			if (object.Equals(tp, typeof(uint)))
			{
				return uint.Parse(EatField(), numberFormat);
			}
			if (object.Equals(tp, typeof(bool)))
			{
				return bool.Parse(EatField());
			}
			if (object.Equals(tp, typeof(string)))
			{
				return EatField();
			}
			if (object.Equals(tp, typeof(Version)))
			{
				return new Version(EatField());
			}
			if (object.Equals(tp, typeof(Vector2)))
			{
				Eat("{");
				Vector2 vector = default(Vector2);
				EatField();
				vector.x = float.Parse(EatField(), numberFormat);
				EatField();
				vector.y = float.Parse(EatField(), numberFormat);
				Eat("}");
				return vector;
			}
			if (object.Equals(tp, typeof(Vector3)))
			{
				Eat("{");
				Vector3 vector2 = default(Vector3);
				EatField();
				vector2.x = float.Parse(EatField(), numberFormat);
				EatField();
				vector2.y = float.Parse(EatField(), numberFormat);
				EatField();
				vector2.z = float.Parse(EatField(), numberFormat);
				Eat("}");
				return vector2;
			}
			if (object.Equals(tp, typeof(Pathfinding.Util.Guid)))
			{
				Eat("{");
				EatField();
				Pathfinding.Util.Guid guid = Pathfinding.Util.Guid.Parse(EatField());
				Eat("}");
				return guid;
			}
			if (object.Equals(tp, typeof(LayerMask)))
			{
				Eat("{");
				EatField();
				LayerMask layerMask = int.Parse(EatField());
				Eat("}");
				return layerMask;
			}
			if (tp.IsGenericType && object.Equals(tp.GetGenericTypeDefinition(), typeof(List<>)))
			{
				IList list = (IList)Activator.CreateInstance(tp);
				Type tp2 = tp.GetGenericArguments()[0];
				Eat("[");
				while (!TryEat(']'))
				{
					list.Add(Deserialize(tp2));
					TryEat(',');
				}
				return list;
			}
			if (typeInfo.IsArray)
			{
				List<object> list2 = new List<object>();
				Eat("[");
				while (!TryEat(']'))
				{
					list2.Add(Deserialize(tp.GetElementType()));
					TryEat(',');
				}
				Array array = Array.CreateInstance(tp.GetElementType(), list2.Count);
				list2.ToArray().CopyTo(array, 0);
				return array;
			}
			if (typeof(UnityEngine.Object).IsAssignableFrom(tp))
			{
				return DeserializeUnityObject();
			}
			Eat("{");
			if (typeInfo.GetCustomAttributes(typeof(JsonDynamicTypeAttribute), inherit: true).Length != 0)
			{
				string text = EatField();
				if (text != "@type")
				{
					throw new Exception("Expected field '@type' but found '" + text + "'\n\nWhen trying to deserialize: " + fullTextDebug);
				}
				string text2 = EatField();
				JsonDynamicTypeAliasAttribute[] obj = typeInfo.GetCustomAttributes(typeof(JsonDynamicTypeAliasAttribute), inherit: true) as JsonDynamicTypeAliasAttribute[];
				string text3 = text2.Split(',')[0];
				Type type = null;
				JsonDynamicTypeAliasAttribute[] array2 = obj;
				foreach (JsonDynamicTypeAliasAttribute jsonDynamicTypeAliasAttribute in array2)
				{
					if (jsonDynamicTypeAliasAttribute.alias == text3)
					{
						type = jsonDynamicTypeAliasAttribute.type;
					}
				}
				if (type == null)
				{
					type = Type.GetType(text2);
				}
				tp = type ?? throw new Exception("Could not find a type with the name '" + text2 + "'\n\nWhen trying to deserialize: " + fullTextDebug);
				typeInfo = WindowsStoreCompatibility.GetTypeInfo(tp);
			}
			object obj2 = populate ?? Activator.CreateInstance(tp);
			while (!TryEat('}'))
			{
				string name = EatField();
				Type type2 = tp;
				FieldInfo fieldInfo = null;
				while (fieldInfo == null && type2 != null)
				{
					fieldInfo = type2.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					type2 = type2.BaseType;
				}
				if (fieldInfo == null)
				{
					PropertyInfo propertyInfo = null;
					type2 = tp;
					while (propertyInfo == null && type2 != null)
					{
						propertyInfo = type2.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						type2 = type2.BaseType;
					}
					if (propertyInfo == null)
					{
						SkipFieldData();
					}
					else
					{
						propertyInfo.SetValue(obj2, Deserialize(propertyInfo.PropertyType));
					}
				}
				else
				{
					fieldInfo.SetValue(obj2, Deserialize(fieldInfo.FieldType));
				}
				TryEat(',');
			}
			return obj2;
		}

		private UnityEngine.Object DeserializeUnityObject()
		{
			Eat("{");
			UnityEngine.Object result = DeserializeUnityObjectInner();
			Eat("}");
			return result;
		}

		private UnityEngine.Object DeserializeUnityObjectInner()
		{
			string text = EatField();
			if (text == "InstanceID")
			{
				EatField();
				text = EatField();
			}
			if (text != "Name")
			{
				throw new Exception("Expected 'Name' field");
			}
			string text2 = EatField();
			if (text2 == null)
			{
				return null;
			}
			if (EatField() != "Type")
			{
				throw new Exception("Expected 'Type' field");
			}
			string text3 = EatField();
			if (text3.IndexOf(',') != -1)
			{
				text3 = text3.Substring(0, text3.IndexOf(','));
			}
			Type type = WindowsStoreCompatibility.GetTypeInfo(typeof(AstarPath)).Assembly.GetType(text3);
			type = type ?? WindowsStoreCompatibility.GetTypeInfo(typeof(Transform)).Assembly.GetType(text3);
			if (object.Equals(type, null))
			{
				Debug.LogError("Could not find type '" + text3 + "'. Cannot deserialize Unity reference");
				return null;
			}
			EatWhitespace();
			if ((ushort)reader.Peek() == 34)
			{
				if (EatField() != "GUID")
				{
					throw new Exception("Expected 'GUID' field");
				}
				string text4 = EatField();
				UnityReferenceHelper[] componentsInChildren;
				if (contextRoot != null)
				{
					componentsInChildren = contextRoot.GetComponentsInChildren<UnityReferenceHelper>(includeInactive: true);
					foreach (UnityReferenceHelper unityReferenceHelper in componentsInChildren)
					{
						if (unityReferenceHelper.GetGUID() == text4)
						{
							if (object.Equals(type, typeof(GameObject)))
							{
								return unityReferenceHelper.gameObject;
							}
							return unityReferenceHelper.GetComponent(type);
						}
					}
				}
				componentsInChildren = UnityCompatibility.FindObjectsByTypeUnsortedWithInactive<UnityReferenceHelper>();
				foreach (UnityReferenceHelper unityReferenceHelper2 in componentsInChildren)
				{
					if (unityReferenceHelper2.GetGUID() == text4)
					{
						if (object.Equals(type, typeof(GameObject)))
						{
							return unityReferenceHelper2.gameObject;
						}
						return unityReferenceHelper2.GetComponent(type);
					}
				}
			}
			if (!string.IsNullOrEmpty(text2))
			{
				UnityEngine.Object[] array = Resources.LoadAll(text2, type);
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].name == text2 || array.Length == 1)
					{
						return array[j];
					}
				}
			}
			return null;
		}

		private void EatWhitespace()
		{
			while (char.IsWhiteSpace((char)reader.Peek()))
			{
				reader.Read();
			}
		}

		private void Eat(string s)
		{
			EatWhitespace();
			for (int i = 0; i < s.Length; i++)
			{
				char c = (char)reader.Read();
				if (c != s[i])
				{
					throw new Exception("Expected '" + s[i] + "' found '" + c + "'\n\n..." + reader.ReadLine() + "\n\nWhen trying to deserialize: " + fullTextDebug);
				}
			}
		}

		private string EatUntil(string c, bool inString)
		{
			builder.Length = 0;
			bool flag = false;
			while (true)
			{
				int num = reader.Peek();
				if (!flag && (ushort)num == 34)
				{
					inString = !inString;
				}
				char c2 = (char)num;
				if (num == -1)
				{
					throw new Exception("Unexpected EOF\n\nWhen trying to deserialize: " + fullTextDebug);
				}
				if (!flag && c2 == '\\')
				{
					flag = true;
					reader.Read();
					continue;
				}
				if (!inString && c.IndexOf(c2) != -1)
				{
					break;
				}
				builder.Append(c2);
				reader.Read();
				flag = false;
			}
			return builder.ToString();
		}

		private bool TryEat(char c)
		{
			EatWhitespace();
			if ((ushort)reader.Peek() == c)
			{
				reader.Read();
				return true;
			}
			return false;
		}

		private string EatField()
		{
			string result = EatUntil("\",}]", TryEat('"'));
			TryEat('"');
			TryEat(':');
			TryEat(',');
			return result;
		}

		private void SkipFieldData()
		{
			int num = 0;
			while (true)
			{
				EatUntil(",{}[]", inString: false);
				switch ((char)(ushort)reader.Peek())
				{
				case '[':
				case '{':
					num++;
					break;
				case ']':
				case '}':
					num--;
					if (num < 0)
					{
						return;
					}
					break;
				case ',':
					if (num == 0)
					{
						reader.Read();
						return;
					}
					break;
				default:
					throw new Exception("Should not reach this part");
				}
				reader.Read();
			}
		}
	}
}
