using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MessagePack.Internal
{
	internal class ObjectSerializationInfo
	{
		public class EmittableMember
		{
			public bool IsProperty => PropertyInfo != null;

			public bool IsField => FieldInfo != null;

			public bool IsWritable { get; set; }

			public bool IsReadable { get; set; }

			public int IntKey { get; set; }

			public string StringKey { get; set; }

			public Type Type
			{
				get
				{
					if (!IsField)
					{
						return PropertyInfo.PropertyType;
					}
					return FieldInfo.FieldType;
				}
			}

			public FieldInfo FieldInfo { get; set; }

			public PropertyInfo PropertyInfo { get; set; }

			public string Name
			{
				get
				{
					if (!IsProperty)
					{
						return FieldInfo.Name;
					}
					return PropertyInfo.Name;
				}
			}

			public bool IsValueType => (IsProperty ? ((MemberInfo)PropertyInfo) : ((MemberInfo)FieldInfo)).DeclaringType.GetTypeInfo().IsValueType;

			public MessagePackFormatterAttribute GetMessagePackFormatterAttribtue()
			{
				if (IsProperty)
				{
					return PropertyInfo.GetCustomAttribute<MessagePackFormatterAttribute>(inherit: true);
				}
				return FieldInfo.GetCustomAttribute<MessagePackFormatterAttribute>(inherit: true);
			}

			public void EmitLoadValue(ILGenerator il)
			{
				if (IsProperty)
				{
					il.EmitCall(PropertyInfo.GetGetMethod(nonPublic: true));
				}
				else
				{
					il.Emit(OpCodes.Ldfld, FieldInfo);
				}
			}

			public void EmitStoreValue(ILGenerator il)
			{
				if (IsProperty)
				{
					il.EmitCall(PropertyInfo.GetSetMethod(nonPublic: true));
				}
				else
				{
					il.Emit(OpCodes.Stfld, FieldInfo);
				}
			}
		}

		public Type Type { get; set; }

		public bool IsIntKey { get; set; }

		public bool IsStringKey => !IsIntKey;

		public bool IsClass { get; set; }

		public bool IsStruct => !IsClass;

		public ConstructorInfo BestmatchConstructor { get; set; }

		public EmittableMember[] ConstructorParameters { get; set; }

		public EmittableMember[] Members { get; set; }

		private ObjectSerializationInfo()
		{
		}

		public static ObjectSerializationInfo CreateOrNull(Type type, bool forceStringKey, bool contractless, bool allowPrivate)
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			bool flag = typeInfo.IsClass || typeInfo.IsInterface || typeInfo.IsAbstract;
			MessagePackObjectAttribute customAttribute = typeInfo.GetCustomAttribute<MessagePackObjectAttribute>();
			DataContractAttribute customAttribute2 = typeInfo.GetCustomAttribute<DataContractAttribute>();
			if (customAttribute == null && customAttribute2 == null && !forceStringKey && !contractless)
			{
				return null;
			}
			bool flag2 = true;
			Dictionary<int, EmittableMember> dictionary = new Dictionary<int, EmittableMember>();
			Dictionary<string, EmittableMember> dictionary2 = new Dictionary<string, EmittableMember>();
			if (forceStringKey || contractless || (customAttribute != null && customAttribute.KeyAsPropertyName))
			{
				flag2 = !forceStringKey && (customAttribute == null || !customAttribute.KeyAsPropertyName);
				int num = 0;
				foreach (PropertyInfo runtimeProperty in type.GetRuntimeProperties())
				{
					if (runtimeProperty.GetCustomAttribute<IgnoreMemberAttribute>(inherit: true) != null || runtimeProperty.GetCustomAttribute<IgnoreDataMemberAttribute>(inherit: true) != null || runtimeProperty.IsIndexer())
					{
						continue;
					}
					MethodInfo getMethod = runtimeProperty.GetGetMethod(nonPublic: true);
					MethodInfo setMethod = runtimeProperty.GetSetMethod(nonPublic: true);
					EmittableMember emittableMember = new EmittableMember
					{
						PropertyInfo = runtimeProperty,
						IsReadable = (getMethod != null && (allowPrivate || getMethod.IsPublic) && !getMethod.IsStatic),
						IsWritable = (setMethod != null && (allowPrivate || setMethod.IsPublic) && !setMethod.IsStatic),
						StringKey = runtimeProperty.Name
					};
					if (emittableMember.IsReadable || emittableMember.IsWritable)
					{
						emittableMember.IntKey = num++;
						if (flag2)
						{
							dictionary.Add(emittableMember.IntKey, emittableMember);
						}
						else
						{
							dictionary2.Add(emittableMember.StringKey, emittableMember);
						}
					}
				}
				foreach (FieldInfo runtimeField in type.GetRuntimeFields())
				{
					if (runtimeField.GetCustomAttribute<IgnoreMemberAttribute>(inherit: true) != null || runtimeField.GetCustomAttribute<IgnoreDataMemberAttribute>(inherit: true) != null || runtimeField.GetCustomAttribute<CompilerGeneratedAttribute>(inherit: true) != null || runtimeField.IsStatic)
					{
						continue;
					}
					EmittableMember emittableMember2 = new EmittableMember
					{
						FieldInfo = runtimeField,
						IsReadable = (allowPrivate || runtimeField.IsPublic),
						IsWritable = (allowPrivate || (runtimeField.IsPublic && !runtimeField.IsInitOnly)),
						StringKey = runtimeField.Name
					};
					if (emittableMember2.IsReadable || emittableMember2.IsWritable)
					{
						emittableMember2.IntKey = num++;
						if (flag2)
						{
							dictionary.Add(emittableMember2.IntKey, emittableMember2);
						}
						else
						{
							dictionary2.Add(emittableMember2.StringKey, emittableMember2);
						}
					}
				}
			}
			else
			{
				bool flag3 = true;
				int num2 = 0;
				foreach (PropertyInfo runtimeProperty2 in type.GetRuntimeProperties())
				{
					if (runtimeProperty2.GetCustomAttribute<IgnoreMemberAttribute>(inherit: true) != null || runtimeProperty2.GetCustomAttribute<IgnoreDataMemberAttribute>(inherit: true) != null || runtimeProperty2.IsIndexer())
					{
						continue;
					}
					MethodInfo getMethod2 = runtimeProperty2.GetGetMethod(nonPublic: true);
					MethodInfo setMethod2 = runtimeProperty2.GetSetMethod(nonPublic: true);
					EmittableMember emittableMember3 = new EmittableMember
					{
						PropertyInfo = runtimeProperty2,
						IsReadable = (getMethod2 != null && (allowPrivate || getMethod2.IsPublic) && !getMethod2.IsStatic),
						IsWritable = (setMethod2 != null && (allowPrivate || setMethod2.IsPublic) && !setMethod2.IsStatic)
					};
					if (!emittableMember3.IsReadable && !emittableMember3.IsWritable)
					{
						continue;
					}
					KeyAttribute keyAttribute;
					if (customAttribute != null)
					{
						keyAttribute = runtimeProperty2.GetCustomAttribute<KeyAttribute>(inherit: true);
						if (keyAttribute == null)
						{
							throw new MessagePackDynamicObjectResolverException("all public members must mark KeyAttribute or IgnoreMemberAttribute. type: " + type.FullName + " member:" + runtimeProperty2.Name);
						}
						if (!keyAttribute.IntKey.HasValue && keyAttribute.StringKey == null)
						{
							throw new MessagePackDynamicObjectResolverException("both IntKey and StringKey are null. type: " + type.FullName + " member:" + runtimeProperty2.Name);
						}
					}
					else
					{
						DataMemberAttribute customAttribute3 = runtimeProperty2.GetCustomAttribute<DataMemberAttribute>(inherit: true);
						if (customAttribute3 == null)
						{
							throw new MessagePackDynamicObjectResolverException("all public members must mark DataMemberAttribute or IgnoreMemberAttribute. type: " + type.FullName + " member:" + runtimeProperty2.Name);
						}
						keyAttribute = ((customAttribute3.Order != -1) ? new KeyAttribute(customAttribute3.Order) : ((customAttribute3.Name == null) ? new KeyAttribute(runtimeProperty2.Name) : new KeyAttribute(customAttribute3.Name)));
					}
					if (flag3)
					{
						flag3 = false;
						flag2 = keyAttribute.IntKey.HasValue;
					}
					else if ((flag2 && !keyAttribute.IntKey.HasValue) || (!flag2 && keyAttribute.StringKey == null))
					{
						throw new MessagePackDynamicObjectResolverException("all members key type must be same. type: " + type.FullName + " member:" + runtimeProperty2.Name);
					}
					if (flag2)
					{
						emittableMember3.IntKey = keyAttribute.IntKey.Value;
						if (dictionary.ContainsKey(emittableMember3.IntKey))
						{
							throw new MessagePackDynamicObjectResolverException("key is duplicated, all members key must be unique. type: " + type.FullName + " member:" + runtimeProperty2.Name);
						}
						dictionary.Add(emittableMember3.IntKey, emittableMember3);
						continue;
					}
					emittableMember3.StringKey = keyAttribute.StringKey;
					if (dictionary2.ContainsKey(emittableMember3.StringKey))
					{
						throw new MessagePackDynamicObjectResolverException("key is duplicated, all members key must be unique. type: " + type.FullName + " member:" + runtimeProperty2.Name);
					}
					emittableMember3.IntKey = num2++;
					dictionary2.Add(emittableMember3.StringKey, emittableMember3);
				}
				foreach (FieldInfo runtimeField2 in type.GetRuntimeFields())
				{
					if (runtimeField2.GetCustomAttribute<IgnoreMemberAttribute>(inherit: true) != null || runtimeField2.GetCustomAttribute<IgnoreDataMemberAttribute>(inherit: true) != null || runtimeField2.GetCustomAttribute<CompilerGeneratedAttribute>(inherit: true) != null || runtimeField2.IsStatic)
					{
						continue;
					}
					EmittableMember emittableMember4 = new EmittableMember
					{
						FieldInfo = runtimeField2,
						IsReadable = (allowPrivate || runtimeField2.IsPublic),
						IsWritable = (allowPrivate || (runtimeField2.IsPublic && !runtimeField2.IsInitOnly))
					};
					if (!emittableMember4.IsReadable && !emittableMember4.IsWritable)
					{
						continue;
					}
					KeyAttribute keyAttribute2;
					if (customAttribute != null)
					{
						keyAttribute2 = runtimeField2.GetCustomAttribute<KeyAttribute>(inherit: true);
						if (keyAttribute2 == null)
						{
							throw new MessagePackDynamicObjectResolverException("all public members must mark KeyAttribute or IgnoreMemberAttribute. type: " + type.FullName + " member:" + runtimeField2.Name);
						}
						if (!keyAttribute2.IntKey.HasValue && keyAttribute2.StringKey == null)
						{
							throw new MessagePackDynamicObjectResolverException("both IntKey and StringKey are null. type: " + type.FullName + " member:" + runtimeField2.Name);
						}
					}
					else
					{
						DataMemberAttribute customAttribute4 = runtimeField2.GetCustomAttribute<DataMemberAttribute>(inherit: true);
						if (customAttribute4 == null)
						{
							throw new MessagePackDynamicObjectResolverException("all public members must mark DataMemberAttribute or IgnoreMemberAttribute. type: " + type.FullName + " member:" + runtimeField2.Name);
						}
						keyAttribute2 = ((customAttribute4.Order != -1) ? new KeyAttribute(customAttribute4.Order) : ((customAttribute4.Name == null) ? new KeyAttribute(runtimeField2.Name) : new KeyAttribute(customAttribute4.Name)));
					}
					if (flag3)
					{
						flag3 = false;
						flag2 = keyAttribute2.IntKey.HasValue;
					}
					else if ((flag2 && !keyAttribute2.IntKey.HasValue) || (!flag2 && keyAttribute2.StringKey == null))
					{
						throw new MessagePackDynamicObjectResolverException("all members key type must be same. type: " + type.FullName + " member:" + runtimeField2.Name);
					}
					if (flag2)
					{
						emittableMember4.IntKey = keyAttribute2.IntKey.Value;
						if (dictionary.ContainsKey(emittableMember4.IntKey))
						{
							throw new MessagePackDynamicObjectResolverException("key is duplicated, all members key must be unique. type: " + type.FullName + " member:" + runtimeField2.Name);
						}
						dictionary.Add(emittableMember4.IntKey, emittableMember4);
						continue;
					}
					emittableMember4.StringKey = keyAttribute2.StringKey;
					if (dictionary2.ContainsKey(emittableMember4.StringKey))
					{
						throw new MessagePackDynamicObjectResolverException("key is duplicated, all members key must be unique. type: " + type.FullName + " member:" + runtimeField2.Name);
					}
					emittableMember4.IntKey = num2++;
					dictionary2.Add(emittableMember4.StringKey, emittableMember4);
				}
			}
			IEnumerator<ConstructorInfo> enumerator3 = null;
			ConstructorInfo ctor = typeInfo.DeclaredConstructors.Where((ConstructorInfo x) => x.IsPublic).SingleOrDefault((ConstructorInfo x) => x.GetCustomAttribute<SerializationConstructorAttribute>(inherit: false) != null);
			if (ctor == null)
			{
				enumerator3 = (from x in typeInfo.DeclaredConstructors
					where x.IsPublic
					orderby x.GetParameters().Length
					select x).GetEnumerator();
				if (enumerator3.MoveNext())
				{
					ctor = enumerator3.Current;
				}
			}
			if (ctor == null && flag)
			{
				throw new MessagePackDynamicObjectResolverException("can't find public constructor. type:" + type.FullName);
			}
			List<EmittableMember> list = new List<EmittableMember>();
			if (ctor != null)
			{
				ILookup<string, KeyValuePair<string, EmittableMember>> lookup = dictionary2.ToLookup((KeyValuePair<string, EmittableMember> x) => x.Key, (KeyValuePair<string, EmittableMember> x) => x, StringComparer.OrdinalIgnoreCase);
				do
				{
					list.Clear();
					int num3 = 0;
					ParameterInfo[] parameters = ctor.GetParameters();
					foreach (ParameterInfo parameterInfo in parameters)
					{
						EmittableMember value;
						if (flag2)
						{
							if (!dictionary.TryGetValue(num3, out value))
							{
								if (enumerator3 != null)
								{
									ctor = null;
									continue;
								}
								throw new MessagePackDynamicObjectResolverException("can't find matched constructor parameter, index not found. type:" + type.FullName + " parameterIndex:" + num3);
							}
							if (!(parameterInfo.ParameterType == value.Type) || !value.IsReadable)
							{
								if (enumerator3 != null)
								{
									ctor = null;
									continue;
								}
								throw new MessagePackDynamicObjectResolverException("can't find matched constructor parameter, parameterType mismatch. type:" + type.FullName + " parameterIndex:" + num3 + " paramterType:" + parameterInfo.ParameterType.Name);
							}
							list.Add(value);
						}
						else
						{
							IEnumerable<KeyValuePair<string, EmittableMember>> source = lookup[parameterInfo.Name];
							switch (source.Count())
							{
							default:
								if (enumerator3 != null)
								{
									ctor = null;
									continue;
								}
								throw new MessagePackDynamicObjectResolverException("duplicate matched constructor parameter name:" + type.FullName + " parameterName:" + parameterInfo.Name + " paramterType:" + parameterInfo.ParameterType.Name);
							case 1:
								break;
							case 0:
								if (enumerator3 != null)
								{
									ctor = null;
									continue;
								}
								throw new MessagePackDynamicObjectResolverException("can't find matched constructor parameter, index not found. type:" + type.FullName + " parameterName:" + parameterInfo.Name);
							}
							value = source.First().Value;
							if (!(parameterInfo.ParameterType == value.Type) || !value.IsReadable)
							{
								if (enumerator3 != null)
								{
									ctor = null;
									continue;
								}
								throw new MessagePackDynamicObjectResolverException("can't find matched constructor parameter, parameterType mismatch. type:" + type.FullName + " parameterName:" + parameterInfo.Name + " paramterType:" + parameterInfo.ParameterType.Name);
							}
							list.Add(value);
						}
						num3++;
					}
				}
				while (TryGetNextConstructor(enumerator3, ref ctor));
				if (ctor == null)
				{
					throw new MessagePackDynamicObjectResolverException("can't find matched constructor. type:" + type.FullName);
				}
			}
			return new ObjectSerializationInfo
			{
				Type = type,
				IsClass = flag,
				BestmatchConstructor = ctor,
				ConstructorParameters = list.ToArray(),
				IsIntKey = flag2,
				Members = (flag2 ? dictionary.Values.ToArray() : dictionary2.Values.ToArray())
			};
		}

		private static bool TryGetNextConstructor(IEnumerator<ConstructorInfo> ctorEnumerator, ref ConstructorInfo ctor)
		{
			if (ctorEnumerator == null || ctor != null)
			{
				return false;
			}
			if (ctorEnumerator.MoveNext())
			{
				ctor = ctorEnumerator.Current;
				return true;
			}
			ctor = null;
			return false;
		}
	}
}
