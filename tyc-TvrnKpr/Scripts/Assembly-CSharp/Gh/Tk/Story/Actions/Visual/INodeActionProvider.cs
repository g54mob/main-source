using System;
using System.Collections.Generic;

namespace Gh.Tk.Story.Actions.Visual
{
	public interface INodeActionProvider
	{
		List<(string, Action)> GetActions();
	}
}
