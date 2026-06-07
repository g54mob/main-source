namespace ModApi.Ioc
{
	public interface IIocContainer
	{
		void Register<T>(T instance);

		void Register<T>(T instance, IContext context);

		void RegisterContext(IContext context);

		T Resolve<T>(IContext context, bool suppressWarnings = false);

		T Resolve<T>(bool suppressWarnings = false);

		void UnRegister<T>();

		void UnregisterContext(IContext context);
	}
}
