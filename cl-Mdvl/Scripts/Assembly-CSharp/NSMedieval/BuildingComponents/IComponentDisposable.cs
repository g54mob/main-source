using System;

namespace NSMedieval.BuildingComponents
{
	public interface IComponentDisposable : IDisposable
	{
		bool HasDisposed { get; }

		event Action<IComponentDisposable> OnDisposedComponentEvent;
	}
}
