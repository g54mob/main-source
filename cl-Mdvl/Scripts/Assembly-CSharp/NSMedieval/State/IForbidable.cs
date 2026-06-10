using System;

namespace NSMedieval.State
{
	public interface IForbidable : IGameDisposable, IDisposable
	{
		bool IsForbidden { get; set; }

		event Action<IForbidable> ForbidChangeEvent;

		event Action<IForbidable> ForbidStateWillChangeEvent;
	}
}
