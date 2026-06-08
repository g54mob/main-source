using System;
using System.Collections.Generic;
using System.Reflection;

namespace MoonSharp.Interpreter.Interop
{
	public class PropertyTableAssigner<T> : IPropertyTableAssigner
	{
		private PropertyTableAssigner m_InternalAssigner;

		public PropertyTableAssigner(params string[] expectedMissingProperties)
		{
		}

		public void AddExpectedMissingProperty(string name)
		{
		}

		public void AssignObject(T obj, Table data)
		{
		}

		public PropertyTableAssigner GetTypeUnsafeAssigner()
		{
			return null;
		}

		public void SetSubassignerForType(Type propertyType, IPropertyTableAssigner assigner)
		{
		}

		public void SetSubassigner<SubassignerType>(PropertyTableAssigner<SubassignerType> assigner)
		{
		}

		void IPropertyTableAssigner.AssignObjectUnchecked(object o, Table data)
		{
		}
	}
	public class PropertyTableAssigner : IPropertyTableAssigner
	{
		private Type m_Type;

		private Dictionary<string, PropertyInfo> m_PropertyMap;

		private Dictionary<Type, IPropertyTableAssigner> m_SubAssigners;

		public PropertyTableAssigner(Type type, params string[] expectedMissingProperties)
		{
		}

		public void AddExpectedMissingProperty(string name)
		{
		}

		private bool TryAssignProperty(object obj, string name, DynValue value)
		{
			return false;
		}

		private void AssignProperty(object obj, string name, DynValue value)
		{
		}

		public void AssignObject(object obj, Table data)
		{
		}

		public void SetSubassignerForType(Type propertyType, IPropertyTableAssigner assigner)
		{
		}

		void IPropertyTableAssigner.AssignObjectUnchecked(object obj, Table data)
		{
		}
	}
}
