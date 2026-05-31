using System;

namespace CTS
{
	public interface IVisible : IObject
	{
		bool IsVisible { get; }

		Action WasSeen { get; set; }
	}
}
