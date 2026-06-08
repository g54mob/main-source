using System.Collections.Generic;

namespace Castle.DynamicProxy.Generators
{
	public class MetaType
	{
		private readonly ICollection<MetaEvent> events = new TypeElementCollection<MetaEvent>();

		private readonly ICollection<MetaMethod> methods = new TypeElementCollection<MetaMethod>();

		private readonly ICollection<MetaProperty> properties = new TypeElementCollection<MetaProperty>();

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
		}

		public void AddProperty(MetaProperty property)
		{
			properties.Add(property);
		}
	}
}
