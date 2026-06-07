using System;
using System.Threading;

namespace MathNet.Numerics.Providers
{
	public class ProviderProbe<T> where T : class
	{
		private readonly bool _disabled;

		private readonly Lazy<IProviderCreator<T>> _creator;

		public ProviderProbe(string typeName, bool disabled = false)
		{
			_disabled = disabled;
			_creator = new Lazy<IProviderCreator<T>>(delegate
			{
				Type type = Type.GetType(typeName);
				return ((object)type != null) ? (Activator.CreateInstance(type) as IProviderCreator<T>) : null;
			}, LazyThreadSafetyMode.ExecutionAndPublication);
		}

		public T Create()
		{
			if (_disabled)
			{
				throw new NotSupportedException("Specific Native Provider disabled by an application switch");
			}
			if (AppSwitches.DisableNativeProviders)
			{
				throw new NotSupportedException("Native Providers are disabled by an application switch");
			}
			if (AppSwitches.DisableNativeProviderProbing)
			{
				throw new NotSupportedException("Native Provider Probing is disabled by an application switch");
			}
			return (_creator.Value ?? throw new NotSupportedException("Native Provider Probing failed to resolve creator")).CreateProvider();
		}

		public T TryCreate()
		{
			if (_disabled || AppSwitches.DisableNativeProviderProbing || AppSwitches.DisableNativeProviders)
			{
				return null;
			}
			try
			{
				IProviderCreator<T> value = _creator.Value;
				return (value != null) ? value.CreateProvider() : null;
			}
			catch
			{
				return null;
			}
		}
	}
}
