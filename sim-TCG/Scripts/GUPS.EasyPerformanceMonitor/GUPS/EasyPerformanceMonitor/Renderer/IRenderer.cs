using System;
using System.Collections.Generic;
using GUPS.EasyPerformanceMonitor.Observer;
using GUPS.EasyPerformanceMonitor.Provider;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	public interface IRenderer : IObserver<IProvidedData>, IDisposable
	{
		List<IProvider> Provider { get; }
	}
}
