using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	public abstract class ClassMap
	{
		private static readonly List<Type> enumerableConverters = new List<Type>
		{
			typeof(ArrayConverter),
			typeof(CollectionGenericConverter),
			typeof(EnumerableConverter),
			typeof(IDictionaryConverter),
			typeof(IDictionaryGenericConverter),
			typeof(IEnumerableConverter),
			typeof(IEnumerableGenericConverter)
		};

		public virtual Type ClassType { get; private set; }

		public virtual List<ParameterMap> ParameterMaps { get; } = new List<ParameterMap>();

		public virtual MemberMapCollection MemberMaps { get; } = new MemberMapCollection();

		public virtual MemberReferenceMapCollection ReferenceMaps { get; } = new MemberReferenceMapCollection();

		internal ClassMap(Type classType)
		{
			ClassType = classType;
		}

		public MemberMap Map(Type classType, MemberInfo member, bool useExistingMap = true)
		{
			if (useExistingMap)
			{
				MemberMap memberMap = MemberMaps.Find(member);
				if (memberMap != null)
				{
					return memberMap;
				}
			}
			MemberMap memberMap2 = MemberMap.CreateGeneric(classType, member);
			memberMap2.Data.Index = GetMaxIndex() + 1;
			MemberMaps.Add(memberMap2);
			return memberMap2;
		}

		public virtual MemberMap<object, object> Map()
		{
			MemberMap<object, object> memberMap = new MemberMap<object, object>(null);
			memberMap.Data.Index = GetMaxIndex() + 1;
			MemberMaps.Add(memberMap);
			return memberMap;
		}

		public virtual MemberReferenceMap References(Type classMapType, MemberInfo member, params object[] constructorArgs)
		{
			if (!typeof(ClassMap).IsAssignableFrom(classMapType))
			{
				throw new InvalidOperationException("Argument classMapType is not a CsvClassMap.");
			}
			MemberReferenceMap memberReferenceMap = ReferenceMaps.Find(member);
			if (memberReferenceMap != null)
			{
				return memberReferenceMap;
			}
			ClassMap classMap = (ClassMap)ObjectResolver.Current.Resolve(classMapType, constructorArgs);
			classMap.ReIndex(GetMaxIndex() + 1);
			MemberReferenceMap memberReferenceMap2 = new MemberReferenceMap(member, classMap);
			ReferenceMaps.Add(memberReferenceMap2);
			return memberReferenceMap2;
		}

		public virtual ParameterMap Parameter(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}
			GetConstructorArgs args = new GetConstructorArgs(ClassType);
			return Parameter(() => ConfigurationFunctions.GetConstructor(args), name);
		}

		public virtual ParameterMap Parameter(Func<ConstructorInfo> getConstructor, string name)
		{
			if (getConstructor == null)
			{
				throw new ArgumentNullException("getConstructor");
			}
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}
			ConstructorInfo constructorInfo = getConstructor();
			ParameterInfo parameterInfo = constructorInfo.GetParameters().SingleOrDefault((ParameterInfo p) => p.Name == name);
			if (parameterInfo == null)
			{
				throw new ConfigurationException("Constructor " + constructorInfo.GetDefinition() + " doesn't contain a paramter with name '" + name + "'.");
			}
			return Parameter(constructorInfo, parameterInfo);
		}

		public virtual ParameterMap Parameter(ConstructorInfo constructor, ParameterInfo parameter)
		{
			if (constructor == null)
			{
				throw new ArgumentNullException("constructor");
			}
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
			}
			if (!constructor.GetParameters().Contains(parameter))
			{
				throw new ConfigurationException("Constructor " + constructor.GetDefinition() + " doesn't contain parameter '" + parameter.GetDefinition() + "'.");
			}
			ParameterMap parameterMap = new ParameterMap(parameter);
			parameterMap.Data.Index = GetMaxIndex(isParameter: true) + 1;
			ParameterMaps.Add(parameterMap);
			return parameterMap;
		}

		public virtual void AutoMap(CultureInfo culture)
		{
			AutoMap(new CsvConfiguration(culture));
		}

		public virtual void AutoMap(CsvConfiguration configuration)
		{
			AutoMap(new CsvContext(configuration));
		}

		public virtual void AutoMap(CsvContext context)
		{
			Type genericType = GetGenericType();
			if (typeof(IEnumerable).IsAssignableFrom(genericType))
			{
				throw new ConfigurationException("Types that inherit IEnumerable cannot be auto mapped. Did you accidentally call GetRecord or WriteRecord which acts on a single record instead of calling GetRecords or WriteRecords which acts on a list of records?");
			}
			LinkedList<Type> mapParents = new LinkedList<Type>();
			ShouldUseConstructorParametersArgs args = new ShouldUseConstructorParametersArgs(genericType);
			if (context.Configuration.ShouldUseConstructorParameters(args))
			{
				AutoMapConstructorParameters(this, context, mapParents);
			}
			AutoMapMembers(this, context, mapParents);
		}

		public virtual int GetMaxIndex(bool isParameter = false)
		{
			if (isParameter)
			{
				return ParameterMaps.Select((ParameterMap parameterMap) => parameterMap.GetMaxIndex()).DefaultIfEmpty(-1).Max();
			}
			if (MemberMaps.Count == 0 && ReferenceMaps.Count == 0)
			{
				return -1;
			}
			List<int> list = new List<int>();
			if (MemberMaps.Count > 0)
			{
				list.Add(MemberMaps.Max((MemberMap pm) => pm.Data.Index));
			}
			if (ReferenceMaps.Count > 0)
			{
				list.AddRange(ReferenceMaps.Select((MemberReferenceMap referenceMap) => referenceMap.GetMaxIndex()));
			}
			return list.Max();
		}

		public virtual int ReIndex(int indexStart = 0)
		{
			foreach (ParameterMap parameterMap in ParameterMaps)
			{
				parameterMap.Data.Index = indexStart + parameterMap.Data.Index;
			}
			foreach (MemberMap memberMap in MemberMaps)
			{
				if (!memberMap.Data.IsIndexSet)
				{
					memberMap.Data.Index = indexStart + memberMap.Data.Index;
				}
			}
			foreach (MemberReferenceMap referenceMap in ReferenceMaps)
			{
				indexStart = referenceMap.Data.Mapping.ReIndex(indexStart);
			}
			return indexStart;
		}

		protected virtual void AutoMapMembers(ClassMap map, CsvContext context, LinkedList<Type> mapParents, int indexStart = 0)
		{
			Type genericType = map.GetGenericType();
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
			if (context.Configuration.IncludePrivateMembers)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			List<MemberInfo> list = new List<MemberInfo>();
			if ((context.Configuration.MemberTypes & MemberTypes.Properties) == MemberTypes.Properties)
			{
				List<PropertyInfo> list2 = new List<PropertyInfo>();
				foreach (PropertyInfo property in ReflectionHelper.GetUniqueProperties(genericType, bindingFlags))
				{
					if (!list2.Any((PropertyInfo p) => p.Name == property.Name))
					{
						list2.Add(ReflectionHelper.GetDeclaringProperty(genericType, property, bindingFlags));
					}
				}
				list.AddRange(list2);
			}
			if ((context.Configuration.MemberTypes & MemberTypes.Fields) == MemberTypes.Fields)
			{
				List<MemberInfo> list3 = new List<MemberInfo>();
				foreach (FieldInfo field in ReflectionHelper.GetUniqueFields(genericType, bindingFlags))
				{
					if (!list3.Any((MemberInfo p) => p.Name == field.Name) && !field.GetCustomAttributes(typeof(CompilerGeneratedAttribute), inherit: false).Any())
					{
						list3.Add(ReflectionHelper.GetDeclaringField(genericType, field, bindingFlags));
					}
				}
				list.AddRange(list3);
			}
			foreach (MemberInfo item in list)
			{
				if (item.GetCustomAttribute<IgnoreAttribute>() != null)
				{
					continue;
				}
				Type type = context.TypeConverterCache.GetConverter(item).GetType();
				if (context.Configuration.HasHeaderRecord && enumerableConverters.Contains(type))
				{
					continue;
				}
				TypeInfo typeInfo = item.MemberType().GetTypeInfo();
				if (type == typeof(DefaultTypeConverter))
				{
					if (context.Configuration.IgnoreReferences || CheckForCircularReference(item.MemberType(), mapParents))
					{
						continue;
					}
					mapParents.AddLast(genericType);
					Type type2 = typeof(DefaultClassMap<>).MakeGenericType(item.MemberType());
					ClassMap classMap = (ClassMap)ObjectResolver.Current.Resolve(type2);
					if (typeInfo.HasConstructor() && !typeInfo.HasParameterlessConstructor() && !typeInfo.IsUserDefinedStruct())
					{
						AutoMapConstructorParameters(classMap, context, mapParents, Math.Max(map.GetMaxIndex() + 1, indexStart));
					}
					AutoMapMembers(classMap, context, mapParents, Math.Max(map.GetMaxIndex() + 1, indexStart));
					mapParents.Drop(mapParents.Find(genericType));
					if (classMap.MemberMaps.Count > 0 || classMap.ReferenceMaps.Count > 0)
					{
						MemberReferenceMap memberReferenceMap = new MemberReferenceMap(item, classMap);
						if (context.Configuration.ReferenceHeaderPrefix != null)
						{
							ReferenceHeaderPrefixArgs args = new ReferenceHeaderPrefixArgs(item.MemberType(), item.Name);
							memberReferenceMap.Data.Prefix = context.Configuration.ReferenceHeaderPrefix(args);
						}
						ApplyAttributes(memberReferenceMap);
						map.ReferenceMaps.Add(memberReferenceMap);
					}
				}
				else
				{
					MemberMap memberMap = MemberMap.CreateGeneric(mapParents.First?.Value ?? map.ClassType, item);
					memberMap.Data.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions(), context.TypeConverterOptionsCache.GetOptions(item.MemberType()), memberMap.Data.TypeConverterOptions);
					memberMap.Data.Index = map.GetMaxIndex() + 1;
					ApplyAttributes(memberMap);
					map.MemberMaps.Add(memberMap);
				}
			}
			map.ReIndex(indexStart);
		}

		protected virtual void AutoMapConstructorParameters(ClassMap map, CsvContext context, LinkedList<Type> mapParents, int indexStart = 0)
		{
			Type genericType = map.GetGenericType();
			GetConstructorArgs args = new GetConstructorArgs(map.ClassType);
			ParameterInfo[] parameters = context.Configuration.GetConstructor(args).GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				ParameterMap parameterMap = new ParameterMap(parameterInfo);
				if (parameterInfo.GetCustomAttributes<IgnoreAttribute>(inherit: true).Any() || parameterInfo.GetCustomAttributes<ConstantAttribute>(inherit: true).Any())
				{
					ApplyAttributes(parameterMap);
					map.ParameterMaps.Add(parameterMap);
					continue;
				}
				Type type = context.TypeConverterCache.GetConverter(parameterInfo.ParameterType).GetType();
				TypeInfo typeInfo = parameterInfo.ParameterType.GetTypeInfo();
				if (type == typeof(DefaultTypeConverter) && (typeInfo.HasParameterlessConstructor() || typeInfo.IsUserDefinedStruct()))
				{
					if (context.Configuration.IgnoreReferences)
					{
						throw new InvalidOperationException("Configuration 'IgnoreReferences' can't be true when using types without a default constructor. Constructor parameters are used and all members including references must be used.");
					}
					if (CheckForCircularReference(parameterInfo.ParameterType, mapParents))
					{
						throw new InvalidOperationException("A circular reference was detected in constructor paramter '" + parameterInfo.Name + "'.Since all parameters must be supplied for a constructor, this parameter can't be skipped.");
					}
					mapParents.AddLast(genericType);
					Type type2 = typeof(DefaultClassMap<>).MakeGenericType(parameterInfo.ParameterType);
					ClassMap classMap = (ClassMap)ObjectResolver.Current.Resolve(type2);
					AutoMapMembers(classMap, context, mapParents, Math.Max(map.GetMaxIndex(isParameter: true) + 1, indexStart));
					mapParents.Drop(mapParents.Find(genericType));
					ParameterReferenceMap parameterReferenceMap = new ParameterReferenceMap(parameterInfo, classMap);
					if (context.Configuration.ReferenceHeaderPrefix != null)
					{
						ReferenceHeaderPrefixArgs args2 = new ReferenceHeaderPrefixArgs(typeInfo.MemberType(), typeInfo.Name);
						parameterReferenceMap.Data.Prefix = context.Configuration.ReferenceHeaderPrefix(args2);
					}
					ApplyAttributes(parameterReferenceMap);
					parameterMap.ReferenceMap = parameterReferenceMap;
				}
				else if (context.Configuration.ShouldUseConstructorParameters(new ShouldUseConstructorParametersArgs(parameterInfo.ParameterType)))
				{
					mapParents.AddLast(genericType);
					Type type3 = typeof(DefaultClassMap<>).MakeGenericType(parameterInfo.ParameterType);
					ClassMap classMap2 = (ClassMap)ObjectResolver.Current.Resolve(type3);
					AutoMapConstructorParameters(classMap2, context, mapParents, Math.Max(map.GetMaxIndex(isParameter: true) + 1, indexStart));
					mapParents.Drop(mapParents.Find(genericType));
					parameterMap.ConstructorTypeMap = classMap2;
				}
				else
				{
					parameterMap.Data.TypeConverterOptions = TypeConverterOptions.Merge(new TypeConverterOptions(), context.TypeConverterOptionsCache.GetOptions(parameterInfo.ParameterType), parameterMap.Data.TypeConverterOptions);
					parameterMap.Data.Index = map.GetMaxIndex(isParameter: true) + 1;
					ApplyAttributes(parameterMap);
				}
				map.ParameterMaps.Add(parameterMap);
			}
			map.ReIndex(indexStart);
		}

		protected virtual bool CheckForCircularReference(Type type, LinkedList<Type> mapParents)
		{
			if (mapParents.Count == 0)
			{
				return false;
			}
			LinkedListNode<Type> linkedListNode = mapParents.Last;
			do
			{
				if (linkedListNode.Value == type)
				{
					return true;
				}
				linkedListNode = linkedListNode.Previous;
			}
			while (linkedListNode != null);
			return false;
		}

		protected virtual Type GetGenericType()
		{
			return GetType().GetTypeInfo().BaseType.GetGenericArguments()[0];
		}

		protected virtual void ApplyAttributes(ParameterMap parameterMap)
		{
			foreach (IParameterMapper item in parameterMap.Data.Parameter.GetCustomAttributes().OfType<IParameterMapper>())
			{
				item.ApplyTo(parameterMap);
			}
		}

		protected virtual void ApplyAttributes(ParameterReferenceMap referenceMap)
		{
			foreach (IParameterReferenceMapper item in referenceMap.Data.Parameter.GetCustomAttributes().OfType<IParameterReferenceMapper>())
			{
				item.ApplyTo(referenceMap);
			}
		}

		protected virtual void ApplyAttributes(MemberMap memberMap)
		{
			foreach (IMemberMapper item in memberMap.Data.Member.GetCustomAttributes().OfType<IMemberMapper>())
			{
				item.ApplyTo(memberMap);
			}
		}

		protected virtual void ApplyAttributes(MemberReferenceMap referenceMap)
		{
			foreach (IMemberReferenceMapper item in referenceMap.Data.Member.GetCustomAttributes().OfType<IMemberReferenceMapper>())
			{
				item.ApplyTo(referenceMap);
			}
		}
	}
	public abstract class ClassMap<TClass> : ClassMap
	{
		public ClassMap()
			: base(typeof(TClass))
		{
		}

		public virtual MemberMap<TClass, TMember> Map<TMember>(Expression<Func<TClass, TMember>> expression, bool useExistingMap = true)
		{
			Stack<MemberInfo> members = ReflectionHelper.GetMembers(expression);
			if (members.Count == 0)
			{
				throw new InvalidOperationException("No members were found in expression '{expression}'.");
			}
			ClassMap classMap = this;
			MemberInfo memberInfo;
			if (members.Count > 1)
			{
				while (members.Count > 1)
				{
					memberInfo = members.Pop();
					PropertyInfo propertyInfo = memberInfo as PropertyInfo;
					FieldInfo fieldInfo = memberInfo as FieldInfo;
					Type classMapType;
					if (propertyInfo != null)
					{
						classMapType = typeof(DefaultClassMap<>).MakeGenericType(propertyInfo.PropertyType);
					}
					else
					{
						if (!(fieldInfo != null))
						{
							throw new InvalidOperationException("The given expression was not a property or a field.");
						}
						classMapType = typeof(DefaultClassMap<>).MakeGenericType(fieldInfo.FieldType);
					}
					classMap = classMap.References(classMapType, memberInfo).Data.Mapping;
				}
			}
			memberInfo = members.Pop();
			return (MemberMap<TClass, TMember>)classMap.Map(typeof(TClass), memberInfo, useExistingMap);
		}

		public virtual MemberReferenceMap References<TClassMap>(Expression<Func<TClass, object>> expression, params object[] constructorArgs) where TClassMap : ClassMap
		{
			MemberInfo member = ReflectionHelper.GetMember(expression);
			return References(typeof(TClassMap), member, constructorArgs);
		}
	}
}
