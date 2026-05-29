using System;
using GUPS.EasyPerformanceMonitor.Observer;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	public interface ITextRenderer : IRenderer, IObserver<IProvidedData>, IDisposable
	{
		bool Scale { get; }

		void RefreshText();
	}
}
