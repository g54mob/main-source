using System.Collections.Generic;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	internal class MetaType
	{
		private readonly MetaTypeElementCollection<MetaEvent> events = new MetaTypeElementCollection<MetaEvent>();

		private readonly MetaTypeElementCollection<MetaMethod> methods = new MetaTypeElementCollection<MetaMethod>();

		private readonly Dictionary<MethodInfo, MetaMethod> methodsIndex = new Dictionary<MethodInfo, MetaMethod>();

		private readonly MetaTypeElementCollection<MetaProperty> properties = new MetaTypeElementCollection<MetaProperty>();

		public IEnumerable<MetaEvent> Events => events;

		public IEnumerable<MetaMethod> Methods => methods;

		public IEnumerable<MetaProperty> Properties => properties;

		public void AddEvent(MetaEvent @event)
		{
			events.Add(@event);
		}

		public void AddMethod(MetaMethod method)
		{
			methods.Add(method);
			methodsIndex.Add(method.Method, method);
		}

		public void AddProperty(MetaProperty property)
		{
			properties.Add(property);
		}

		public MetaMethod FindMethod(MethodInfo method)
		{
			if (!methodsIndex.TryGetValue(method, out var value))
			{
				return null;
			}
			return value;
		}
	}
}
