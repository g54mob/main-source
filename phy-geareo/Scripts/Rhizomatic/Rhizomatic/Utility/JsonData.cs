using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Rhizomatic.Utility
{
	public class JsonData
	{
		public abstract class Member
		{
			public abstract string GetName();

			public abstract Type GetMemberType();

			public abstract JsonDataAttribute GetAttribute();

			public abstract object GetValue(object target);

			public abstract void SetValue(object target, object value);

			public string DoGetKey()
			{
				return null;
			}

			public object DoGetValue(object target)
			{
				return null;
			}

			public void DoSetValue(object target, JToken raw)
			{
			}
		}

		public class FieldMember : Member
		{
			private FieldInfo fieldInfo;

			public FieldMember(FieldInfo fieldInfo)
			{
			}

			public override string GetName()
			{
				return null;
			}

			public override Type GetMemberType()
			{
				return null;
			}

			public override JsonDataAttribute GetAttribute()
			{
				return null;
			}

			public override object GetValue(object target)
			{
				return null;
			}

			public override void SetValue(object target, object value)
			{
			}
		}

		public class PropertyMember : Member
		{
			private PropertyInfo propertyInfo;

			public PropertyMember(PropertyInfo propertyInfo)
			{
			}

			public override string GetName()
			{
				return null;
			}

			public override Type GetMemberType()
			{
				return null;
			}

			public override JsonDataAttribute GetAttribute()
			{
				return null;
			}

			public override object GetValue(object target)
			{
				return null;
			}

			public override void SetValue(object target, object value)
			{
			}
		}

		private static Dictionary<Type, Member[]> dataLoaderMembers;

		public JObject json { get; }

		public JsonData()
		{
		}

		public JsonData(JObject json)
		{
		}

		public void Write(string key, object data)
		{
		}

		public T Read<T>(string key)
		{
			return default(T);
		}

		public T Read<T>(string key, T defaultValue)
		{
			return default(T);
		}

		public bool Has(string key)
		{
			return false;
		}

		public static Member[] GetDataLoaderMembers(Type type)
		{
			return null;
		}

		public JsonData Save(object target)
		{
			return null;
		}

		public static string SaveJson(object target)
		{
			return null;
		}

		public static JsonData Save(object target, JsonData data)
		{
			return null;
		}

		public void Load(object target)
		{
		}

		public static void Load(object target, string json)
		{
		}

		public static void Load(object target, JObject obj)
		{
		}

		public static void Load(object target, JsonData data)
		{
		}

		private static List<Member> GetPrivateMembersWithAttribute(Type type, Type attributeType)
		{
			return null;
		}
	}
}
