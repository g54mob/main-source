using System;

namespace M4.Session
{
	public interface IRun
	{
		Guid Id { get; }

		void Update();
	}
}
