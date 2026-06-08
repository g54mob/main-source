using System;

namespace Kitchen.Modules
{
	public interface IActivateModule
	{
		event Action OnActivate;
	}
}
