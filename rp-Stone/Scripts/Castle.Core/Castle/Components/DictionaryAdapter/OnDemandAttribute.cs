using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false)]
	public class OnDemandAttribute : DictionaryBehaviorAttribute, IDictionaryPropertyGetter, IDictionaryBehavior
	{
		public Type Type { get; private set; }

		public object Value { get; private set; }

		public OnDemandAttribute()
		{
		}

		public OnDemandAttribute(Type type)
		{
			if (type.GetConstructor(Type.EmptyTypes) == null)
			{
				throw new ArgumentException("On-demand values must have a parameterless constructor");
			}
			Type = type;
		}

		public OnDemandAttribute(object value)
		{
			Value = value;
		}

		public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			if (storedValue == null && !ifExists)
			{
				IValueInitializer initializer = null;
				if (Value != null)
				{
					storedValue = Value;
				}
				else
				{
					Type type = Type ?? GetInferredType(dictionaryAdapter, property, out initializer);
					if (IsAcceptedType(type))
					{
						if (type.GetTypeInfo().IsInterface)
						{
							if (!property.IsDynamicProperty && storedValue == null)
							{
								storedValue = dictionaryAdapter.Create(property.PropertyType);
							}
						}
						else if (type.GetTypeInfo().IsArray)
						{
							storedValue = Array.CreateInstance(type.GetElementType(), 0);
						}
						else if (storedValue == null)
						{
							object[] parameters = null;
							ConstructorInfo constructorInfo = null;
							if (property.IsDynamicProperty)
							{
								constructorInfo = (from ctor in type.GetConstructors()
									let parms = ctor.GetParameters()
									where parms.Length == 1 && parms[0].ParameterType.IsAssignableFrom(dictionaryAdapter.Meta.Type)
									select ctor).FirstOrDefault();
								if (constructorInfo != null)
								{
									object[] array = new IDictionaryAdapter[1] { dictionaryAdapter };
									parameters = array;
								}
							}
							if (constructorInfo == null)
							{
								constructorInfo = type.GetConstructor(Type.EmptyTypes);
							}
							if (constructorInfo != null)
							{
								storedValue = constructorInfo.Invoke(parameters);
							}
						}
					}
				}
				if (storedValue != null)
				{
					using (dictionaryAdapter.SuppressNotificationsBlock())
					{
						if (storedValue is ISupportInitialize)
						{
							((ISupportInitialize)storedValue).BeginInit();
							((ISupportInitialize)storedValue).EndInit();
						}
						initializer?.Initialize(dictionaryAdapter, storedValue);
						property.SetPropertyValue(dictionaryAdapter, property.PropertyName, ref storedValue, dictionaryAdapter.This.Descriptor);
					}
				}
			}
			return storedValue;
		}

		private static bool IsAcceptedType(Type type)
		{
			if (type != null && type != typeof(string) && !type.GetTypeInfo().IsPrimitive)
			{
				return !type.GetTypeInfo().IsEnum;
			}
			return false;
		}

		private static Type GetInferredType(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property, out IValueInitializer initializer)
		{
			Type type = null;
			initializer = null;
			type = property.PropertyType;
			if (!typeof(IEnumerable).IsAssignableFrom(type))
			{
				return type;
			}
			Type type2 = null;
			if (type.GetTypeInfo().IsGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				Type genericArg = type.GetGenericArguments()[0];
				bool flag = genericTypeDefinition == typeof(System.ComponentModel.BindingList<>);
				if (flag || genericTypeDefinition == typeof(List<>))
				{
					if (dictionaryAdapter.CanEdit)
					{
						type2 = (flag ? typeof(EditableBindingList<>) : typeof(EditableList<>));
					}
					if (flag && genericArg.GetTypeInfo().IsInterface)
					{
						Func<object> func = () => dictionaryAdapter.Create(genericArg);
						initializer = (IValueInitializer)Activator.CreateInstance(typeof(BindingListInitializer<>).MakeGenericType(genericArg), null, func, null, null, null);
					}
				}
				else if (genericTypeDefinition == typeof(IList<>) || genericTypeDefinition == typeof(ICollection<>))
				{
					type2 = (dictionaryAdapter.CanEdit ? typeof(EditableList<>) : typeof(List<>));
				}
				if (type2 != null)
				{
					return type2.MakeGenericType(genericArg);
				}
			}
			else if (type == typeof(IList) || type == typeof(ICollection))
			{
				if (!dictionaryAdapter.CanEdit)
				{
					return typeof(List<object>);
				}
				return typeof(EditableList);
			}
			return type;
		}
	}
}
