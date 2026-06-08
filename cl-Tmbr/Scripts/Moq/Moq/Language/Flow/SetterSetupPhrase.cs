using System;

namespace Moq.Language.Flow
{
	internal class SetterSetupPhrase<T, TProperty> : VoidSetupPhrase<T>, ISetupSetter<T, TProperty>, ICallbackSetter<TProperty>, IFluentInterface, ICallbackResult, ICallBase, ICallBaseResult, IThrows, IThrowsResult, IOccurrence, IVerifies, IRaise<T> where T : class
	{
		public SetterSetupPhrase(MethodCall setup)
			: base(setup)
		{
		}

		public ICallbackResult Callback(Action<TProperty> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		Type IFluentInterface.GetType()
		{
			return GetType();
		}
	}
}
