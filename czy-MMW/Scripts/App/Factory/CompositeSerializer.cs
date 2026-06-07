using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Factory
{
	public class CompositeSerializer : ISerializer
	{
		private class Member
		{
			private readonly Func<object, object> _getDelegate;

			private readonly Action<object, object> _setDelegate;

			private readonly ISerializer _serializer;

			private readonly int _hashCode;

			public bool CanNestObjects => _serializer.CanNestObjects;

			public static bool IsPropertySerialized(PropertyInfo property)
			{
				return property.GetCustomAttribute<SerializeAttribute>()?.IsSerialized ?? false;
			}

			public static Member CreateProperty(Type declaringType, PropertyInfo property)
			{
				MethodInfo getMethod = property.GetGetMethod();
				MethodInfo methodInfo = (property.CanWrite ? property.GetSetMethod() : null);
				ISerializer serializer = null;
				SerializeAttribute customAttribute = property.GetCustomAttribute<SerializeAttribute>();
				if (customAttribute != null)
				{
					serializer = customAttribute.CustomSerializer;
				}
				Action<object, object> action = ((!(methodInfo != null)) ? ((Action<object, object>)delegate(object target, object param)
				{
					property.SetValue(target, param, BindingFlags.Instance | BindingFlags.NonPublic, null, null, CultureInfo.InvariantCulture);
				}) : Assembler.CreateSetDelegate(declaringType, methodInfo));
				if (getMethod == null || action == null)
				{
					return null;
				}
				if (serializer == null)
				{
					serializer = SerializerLibrary.GetSerializer(property.PropertyType);
					if (serializer == null)
					{
						return null;
					}
				}
				int hashCode = TypeUtilities.CalculateMD5(property.Name) ^ TypeUtilities.CalculateMD5(property.PropertyType.FullName);
				return new Member(serializer, Assembler.CreateGetDelegate(declaringType, getMethod), action, hashCode);
			}

			public static bool IsFieldSerialized(FieldInfo field)
			{
				if (field.IsDefined(typeof(CompilerGeneratedAttribute), inherit: true))
				{
					return false;
				}
				SerializeAttribute customAttribute = field.GetCustomAttribute<SerializeAttribute>();
				if (customAttribute != null)
				{
					if (!customAttribute.IsSerialized)
					{
						return false;
					}
				}
				else if (field.GetCustomAttribute<DependencyAttribute>() != null)
				{
					return false;
				}
				return true;
			}

			public static Member CreateField(FieldInfo field)
			{
				ISerializer serializer = null;
				SerializeAttribute customAttribute = field.GetCustomAttribute<SerializeAttribute>();
				if (customAttribute != null)
				{
					serializer = customAttribute.CustomSerializer;
				}
				if (serializer == null)
				{
					serializer = SerializerLibrary.GetSerializer(field.FieldType);
					if (serializer == null)
					{
						return null;
					}
				}
				Action<object, object> setDelegate = field.SetValue;
				if (field.IsInitOnly)
				{
					setDelegate = null;
				}
				int hashCode = TypeUtilities.CalculateMD5(field.Name) ^ TypeUtilities.CalculateMD5(field.FieldType.FullName);
				return new Member(serializer, field.GetValue, setDelegate, hashCode);
			}

			private Member(ISerializer serializer, Func<object, object> getDelegate, Action<object, object> setDelegate, int hashCode)
			{
				_serializer = serializer;
				_getDelegate = getDelegate;
				_setDelegate = setDelegate;
				_hashCode = hashCode;
			}

			public bool Serialize(object obj, ExportContext context)
			{
				return _serializer.Serialize(_getDelegate(obj), context);
			}

			public bool Deserialize(object obj, ImportContext context)
			{
				object arg = _serializer.Deserialize(_getDelegate(obj), context);
				if (_setDelegate != null)
				{
					_setDelegate(obj, arg);
				}
				return true;
			}

			public IEnumerable<object> GetNestedObjects(object obj)
			{
				foreach (object nestedObject in _serializer.GetNestedObjects(_getDelegate(obj)))
				{
					yield return nestedObject;
				}
			}

			public override int GetHashCode()
			{
				return _hashCode;
			}
		}

		private readonly List<Member> _members = new List<Member>();

		private readonly List<Member> _nestingMembers;

		private readonly int _hashCode;

		public bool CanNestObjects => _nestingMembers != null;

		public CompositeSerializer(Type type)
		{
			Type type2 = type;
			while (type2 != null)
			{
				FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (Member.IsFieldSerialized(fieldInfo))
					{
						Member member = Member.CreateField(fieldInfo);
						if (Diagnostics.Verify(member != null, "Unable to create serializer for field {0} on type {1}.", fieldInfo, type2))
						{
							_members.Add(member);
						}
					}
				}
				PropertyInfo[] properties = type2.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (Member.IsPropertySerialized(propertyInfo))
					{
						Member member2 = Member.CreateProperty(type, propertyInfo);
						if (Diagnostics.Verify(member2 != null, "Unable to create serializer for property {0} on type {1}.", propertyInfo, type2))
						{
							_members.Add(member2);
						}
					}
				}
				type2 = type2.BaseType;
			}
			foreach (Member member3 in _members)
			{
				if (member3.CanNestObjects)
				{
					if (_nestingMembers == null)
					{
						_nestingMembers = new List<Member>();
					}
					_nestingMembers.Add(member3);
				}
			}
			_hashCode = 1;
			foreach (Member member4 in _members)
			{
				_hashCode = 31 * _hashCode + member4.GetHashCode();
			}
		}

		public virtual bool Serialize(object obj, ExportContext context)
		{
			bool flag = true;
			foreach (Member member in _members)
			{
				flag = member.Serialize(obj, context) && flag;
			}
			return flag;
		}

		public virtual object Deserialize(object intoObject, ImportContext context)
		{
			bool flag = true;
			foreach (Member member in _members)
			{
				flag &= member.Deserialize(intoObject, context);
			}
			if (Diagnostics.Verify(flag))
			{
				return intoObject;
			}
			return null;
		}

		public IEnumerable<object> GetNestedObjects(object obj)
		{
			if (_nestingMembers == null)
			{
				yield break;
			}
			foreach (Member nestingMember in _nestingMembers)
			{
				foreach (object nestedObject in nestingMember.GetNestedObjects(obj))
				{
					yield return nestedObject;
				}
			}
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}
	}
}
