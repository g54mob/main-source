using System;
using GUPS.EasyPerformanceMonitor.Observer;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	public interface IGraphRenderer : IRenderer, IObserver<IProvidedData>, IDisposable
	{
		Image Target { get; }

		Shader GraphShader { get; }

		bool IsLine { get; }

		bool IsSmooth { get; }

		bool HasAntiAliasing { get; }

		int GraphValues { get; }

		void RefreshGraph();
	}
}
