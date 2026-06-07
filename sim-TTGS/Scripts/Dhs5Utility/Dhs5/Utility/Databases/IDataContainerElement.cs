using System;

namespace Dhs5.Utility.Databases
{
	public interface IDataContainerElement
	{
		int UID { get; }

		string name { get; set; }

		new Type GetType();
	}
}
