using System;
using System.Windows.Forms;

namespace IdSharp.Utils
{
	public interface IBindableControl
	{
		Control Control { get; }

		object Value { get; set; }

		string Name { get; }

		bool Enabled { get; set; }

		event EventHandler Validated;
	}
}
