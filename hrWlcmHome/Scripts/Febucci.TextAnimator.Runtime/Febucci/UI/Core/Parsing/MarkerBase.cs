using System;
using System.Text;

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
			this.name = name;
			this.index = index;
			this.internalOrder = internalOrder;
			this.parameters = parameters;
		}

		public int CompareTo(MarkerBase other)
		{
			return internalOrder.CompareTo(other.internalOrder);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(name);
			stringBuilder.Append(" internal order:");
			stringBuilder.Append(internalOrder);
			stringBuilder.Append(" index:");
			stringBuilder.Append(index);
			stringBuilder.Append('\n');
			for (int i = 0; i < parameters.Length; i++)
			{
				stringBuilder.Append(parameters[i]);
				stringBuilder.Append('\n');
			}
			return stringBuilder.ToString();
		}
	}
}
