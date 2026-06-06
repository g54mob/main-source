using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace PajamaLlama.Flotsam.Persistence
{
	public sealed class BinaryFormatterBinder : SerializationBinder
	{
		private static readonly Type TYPE_ICollection = typeof(ICollection);

		private static readonly Type TYPE_IDictionary = typeof(IDictionary);

		private readonly Dictionary<string, Type> _bindableTypes = new Dictionary<string, Type>();

		private readonly List<string> _bindableAssemblies = new List<string>();

		public BinaryFormatterBinder(params Type[] types)
		{
			PopulateBindableUnityEngineTypes();
			foreach (Type type in types)
			{
				PopulateBindableTypes(type);
			}
		}

		public override Type BindToType(string assemblyName, string typeName)
		{
			if (_bindableAssemblies.Contains(assemblyName) && _bindableTypes.TryGetValue(typeName, out var value))
			{
				return value;
			}
			throw new NotSupportedException("Unable to bind type '" + typeName + "' from assembly '" + assemblyName + "'");
		}

		public void LogBindableTypes()
		{
			string text = "";
			string text2 = "";
			foreach (string bindableAssembly in _bindableAssemblies)
			{
				text = text + bindableAssembly + "\r\n";
			}
			foreach (string key in _bindableTypes.Keys)
			{
				text2 = text2 + key + "\r\n";
			}
			Debug.Log("BindableAssemblies:\r\n" + text);
			Debug.Log("BindableTypes:\r\n" + text2);
		}

		private void PopulateBindableUnityEngineTypes()
		{
			AddBindableType(typeof(Vector2));
			AddBindableType(typeof(Vector3));
			AddBindableType(typeof(Quaternion));
			AddBindableType(typeof(Rect));
		}

		private void PopulateBindableTypes(Type type)
		{
			if (!type.IsSerializable && !type.IsInterface && !type.IsAbstract)
			{
				return;
			}
			if (type.IsArray)
			{
				PopulateBindableTypes(type.GetElementType());
			}
			else
			{
				if (!AddBindableType(type))
				{
					return;
				}
				if (type.IsGenericType && TYPE_ICollection.IsAssignableFrom(type))
				{
					Type[] genericArguments = type.GetGenericArguments();
					Type[] array = genericArguments;
					foreach (Type type2 in array)
					{
						PopulateBindableTypes(type2);
					}
					if (TYPE_IDictionary.IsAssignableFrom(type))
					{
						object obj = Activator.CreateInstance(type);
						Type type3 = type.GetProperty("Comparer").GetValue(obj).GetType();
						AddBindableType(type3);
						AddBindableType(typeof(KeyValuePair<, >).MakeGenericType(genericArguments));
					}
					return;
				}
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (!fieldInfo.IsNotSerialized)
					{
						PopulateBindableTypes(fieldInfo.FieldType);
					}
				}
				if (!type.Assembly.FullName.Contains("Assembly-CSharp"))
				{
					return;
				}
				foreach (Type item in (IEnumerable<Type>)(from t in type.Assembly.GetTypes()
					where t != type && type.IsAssignableFrom(t)
					select t).ToArray())
				{
					PopulateBindableTypes(item);
				}
			}
		}

		private bool AddBindableType(Type type)
		{
			if (_bindableTypes.TryAdd(type.FullName, type))
			{
				_bindableAssemblies.AddUnique(type.Assembly.FullName);
				return true;
			}
			return false;
		}
	}
}
