using System;

namespace Gh.Tk
{
	public interface ITextChanged
	{
		event EventHandler TextChanged;

		void RaiseTextChangedEvent();
	}
}
