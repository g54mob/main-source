using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Tyd
{
	public static class TydConverter
	{
		public static T Deserialize<T>(TydNode node, bool useEmptyConstructor = false)
		{
			return (T)Deserialize(node, typeof(T), useEmptyConstructor);
		}

		public static object Deserialize(TydNode node, Type t, bool useEmptyConstructor = false)
		{
			TydString tydString = node as TydString;
			if (t == typeof(string))
			{
				return tydString.Value;
			}
			if (tydString != null && tydString.Value == null)
			{
				return null;
			}
			if (t.IsPrimitive)
			{
				return TypeDescriptor.GetConverter(t).ConvertFrom(tydString.Value);
			}
			if (t.IsArray)
			{
				TydList tydList = node as TydList;
				Type elementType = t.GetElementType();
				Array array = Array.CreateInstance(elementType, tydList.Count);
				for (int i = 0; i < tydList.Count; i++)
				{
					array.SetValue(Deserialize(tydList[i], elementType), i);
				}
				return array;
			}
			MemberInfo[] serializableMembers = FormatterServices.GetSerializableMembers(t);
			object[] array2 = new object[serializableMembers.Length];
			object obj = (useEmptyConstructor ? Activator.CreateInstance(t) : FormatterServices.GetUninitializedObject(t));
			TydTable tydTable = node as TydTable;
			for (int j = 0; j < serializableMembers.Length; j++)
			{
				FieldInfo fieldInfo = serializableMembers[j] as FieldInfo;
				if (!Attribute.IsDefined(fieldInfo, typeof(NonSerializedAttribute)))
				{
					TydNode child = tydTable.GetChild(fieldInfo.Name);
					if (child != null)
					{
						array2[j] = Deserialize(child, fieldInfo.FieldType);
					}
				}
			}
			FormatterServices.PopulateObjectMembers(obj, serializableMembers, array2);
			return obj;
		}

		public static TydNode Serialize(string name, object obj)
		{
			if (obj == null)
			{
				return new TydString(name, null);
			}
			Type type = obj.GetType();
			if (type.IsPrimitive || type == typeof(string))
			{
				return new TydString(name, obj.ToString());
			}
			if (type.IsArray)
			{
				TydList tydList = new TydList(name);
				Array array = obj as Array;
				for (int i = 0; i < array.Length; i++)
				{
					tydList.AddChild(Serialize(null, array.GetValue(i)));
				}
				return tydList;
			}
			TydTable tydTable = new TydTable(name);
			MemberInfo[] serializableMembers = FormatterServices.GetSerializableMembers(type);
			for (int j = 0; j < serializableMembers.Length; j++)
			{
				FieldInfo fieldInfo = serializableMembers[j] as FieldInfo;
				if (!Attribute.IsDefined(fieldInfo, typeof(NonSerializedAttribute)))
				{
					tydTable.AddChild(Serialize(fieldInfo.Name, fieldInfo.GetValue(obj)));
				}
			}
			return tydTable;
		}
	}
}
