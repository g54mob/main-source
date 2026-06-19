using System;

namespace Loxodon.Framework.Commands
{
	public interface IActiveAware
	{
		bool IsActive { get; set; }

		event EventHandler IsActiveChanged;
	}
}
