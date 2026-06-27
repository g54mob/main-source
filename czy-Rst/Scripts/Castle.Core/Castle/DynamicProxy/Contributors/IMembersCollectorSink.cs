using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Contributors
{
	internal interface IMembersCollectorSink
	{
		void Add(MetaEvent @event);

		void Add(MetaMethod method);

		void Add(MetaProperty property);
	}
}
