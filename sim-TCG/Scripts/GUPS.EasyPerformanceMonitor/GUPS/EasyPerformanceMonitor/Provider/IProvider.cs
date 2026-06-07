using System;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Observer;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Obfuscation(Exclude = true)]
	public interface IProvider : IObservable<IProvidedData>, IDisposable
	{
		string Name { get; }

		bool IsSupported { get; }

		bool IsActive { get; }

		Type ProvidedDataType { get; }
	}
}
