using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper.Configuration
{
	public abstract class ClassMap
	{
		private static readonly List<Type> enumerableConverters;

		public virtual Type ClassType { get; private set; }

		public virtual List<ParameterMap> ParameterMaps { get; }

		public virtual MemberMapCollection MemberMaps { get; }

		public virtual MemberReferenceMapCollection ReferenceMaps { get; }

		internal ClassMap(Type classType)
		{
		}

		public MemberMap Map(Type classType, MemberInfo member, bool useExistingMap = true)
		{
			return null;
		}

		public virtual MemberMap<object, object> Map()
		{
			return null;
		}

		public virtual MemberReferenceMap References(Type classMapType, MemberInfo member, params object[] constructorArgs)
		{
			return null;
		}

		public virtual void AutoMap()
		{
		}

		public virtual void AutoMap(Configuration configuration)
		{
		}

		public virtual int GetMaxIndex()
		{
			return 0;
		}

		public virtual int ReIndex(int indexStart = 0)
		{
			return 0;
		}

		protected virtual void AutoMapMembers(ClassMap map, Configuration configuration, LinkedList<Type> mapParents, int indexStart = 0)
		{
		}

		protected virtual void AutoMapConstructorParameters(ClassMap map, Configuration configuration, LinkedList<Type> mapParents, int indexStart = 0)
		{
		}

		protected virtual bool CheckForCircularReference(Type type, LinkedList<Type> mapParents)
		{
			return false;
		}

		protected virtual Type GetGenericType()
		{
			return null;
		}

		protected virtual void ApplyAttributes(MemberMap memberMap)
		{
		}

		protected virtual void ApplyAttributes(MemberReferenceMap referenceMap)
		{
		}
	}
	public abstract class ClassMap<TClass> : ClassMap
	{
		public ClassMap()
			: base(null)
		{
		}

		public virtual MemberMap<TClass, TMember> Map<TMember>(Expression<Func<TClass, TMember>> expression, bool useExistingMap = true)
		{
			return null;
		}

		public virtual MemberReferenceMap References<TClassMap>(Expression<Func<TClass, object>> expression, params object[] constructorArgs) where TClassMap : ClassMap
		{
			return null;
		}
	}
}
