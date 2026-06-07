using System;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Observer;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Obfuscation(Exclude = true)]
	public interface IPerformanceProvider : IProvider, IObservable<IProvidedData>, IDisposable
	{
		bool IsScaleAble { get; }

		int ScaleFactor { get; }

		string[] ScaleSuffixes { get; }

		string Unit { get; }
	}
}
