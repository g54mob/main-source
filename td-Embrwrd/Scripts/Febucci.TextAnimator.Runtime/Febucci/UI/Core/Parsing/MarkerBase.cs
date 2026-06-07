using System;

namespace Febucci.UI.Core.Parsing
{
	public abstract class MarkerBase : IComparable<MarkerBase>
	{
		public readonly string name;

		public readonly int index;

		internal readonly int internalOrder;

		public string[] parameters;

		public MarkerBase(string name, int index, int internalOrder, string[] parameters)
		{
		}

		public int CompareTo(MarkerBase other)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
