using System;

public abstract class InitializerContext<T> : StatelessInitializerContext
{
	protected T Target;

	public static TCtx GetContext<TCtx>(T target) where TCtx : InitializerContext<T>, IInitializerContext
	{
		if (!IInitializerContext.Cache.TryGetValue(typeof(TCtx), out var value))
		{
			IInitializerContext initializerContext = (IInitializerContext.Cache[typeof(TCtx)] = Activator.CreateInstance<TCtx>());
			value = initializerContext;
		}
		TCtx obj = (TCtx)value;
		obj.Target = target;
		return obj;
	}
}
