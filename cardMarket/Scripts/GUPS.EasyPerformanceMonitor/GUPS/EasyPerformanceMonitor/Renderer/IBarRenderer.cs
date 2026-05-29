using System;
using GUPS.EasyPerformanceMonitor.Observer;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	public interface IBarRenderer : IRenderer, IObserver<IProvidedData>, IDisposable
	{
		void RefreshBar();
	}
}
