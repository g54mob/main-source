using Loxodon.Framework.Binding.Binders;
using Loxodon.Framework.Binding.Converters;
using Loxodon.Framework.Binding.Paths;
using Loxodon.Framework.Binding.Proxy.Sources;
using Loxodon.Framework.Binding.Proxy.Sources.Expressions;
using Loxodon.Framework.Binding.Proxy.Sources.Object;
using Loxodon.Framework.Binding.Proxy.Sources.Text;
using Loxodon.Framework.Binding.Proxy.Targets;
using Loxodon.Framework.Services;

namespace Loxodon.Framework.Binding
{
	public class BindingServiceBundle : AbstractServiceBundle
	{
		public BindingServiceBundle(IServiceContainer container)
			: base(container)
		{
		}

		protected override void OnStart(IServiceContainer container)
		{
			PathParser pathParser = new PathParser();
			ExpressionPathFinder expressionPathFinder = new ExpressionPathFinder();
			ConverterRegistry target = new ConverterRegistry();
			ObjectSourceProxyFactory objectSourceProxyFactory = new ObjectSourceProxyFactory();
			objectSourceProxyFactory.Register(new UniversalNodeProxyFactory(), 0);
			SourceProxyFactory sourceProxyFactory = new SourceProxyFactory();
			sourceProxyFactory.Register(new LiteralSourceProxyFactory(), 0);
			sourceProxyFactory.Register(new ExpressionSourceProxyFactory(sourceProxyFactory, expressionPathFinder), 1);
			sourceProxyFactory.Register(objectSourceProxyFactory, 2);
			TargetProxyFactory targetProxyFactory = new TargetProxyFactory();
			targetProxyFactory.Register(new UniversalTargetProxyFactory(pathParser), 0);
			targetProxyFactory.Register(new UnityTargetProxyFactory(), 10);
			targetProxyFactory.Register(new VisualElementProxyFactory(), 30);
			BindingFactory bindingFactory = new BindingFactory(sourceProxyFactory, targetProxyFactory);
			StandardBinder target2 = new StandardBinder(bindingFactory);
			container.Register((IBinder)target2);
			container.Register((IBindingFactory)bindingFactory);
			container.Register((IConverterRegistry)target);
			container.Register((IExpressionPathFinder)expressionPathFinder);
			container.Register((IPathParser)pathParser);
			container.Register((INodeProxyFactory)objectSourceProxyFactory);
			container.Register((INodeProxyFactoryRegister)objectSourceProxyFactory);
			container.Register((ISourceProxyFactory)sourceProxyFactory);
			container.Register((ISourceProxyFactoryRegistry)sourceProxyFactory);
			container.Register((ITargetProxyFactory)targetProxyFactory);
			container.Register((ITargetProxyFactoryRegister)targetProxyFactory);
		}

		protected override void OnStop(IServiceContainer container)
		{
			container.Unregister<IBinder>();
			container.Unregister<IBindingFactory>();
			container.Unregister<IConverterRegistry>();
			container.Unregister<IExpressionPathFinder>();
			container.Unregister<IPathParser>();
			container.Unregister<INodeProxyFactory>();
			container.Unregister<INodeProxyFactoryRegister>();
			container.Unregister<ISourceProxyFactory>();
			container.Unregister<ISourceProxyFactoryRegistry>();
			container.Unregister<ITargetProxyFactory>();
			container.Unregister<ITargetProxyFactoryRegister>();
		}
	}
}
