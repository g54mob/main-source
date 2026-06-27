using System;

namespace Restory.EventSystems.ExitEvents
{
	public interface IExitablePanel
	{
		bool IsVisible { get; }

		event Action OnIsVisibleChanged;

		void OnExitEvent();
	}
}
