using System.Collections.Generic;

namespace Polarith.AI.Criteria
{
	public class Decision<TValue, TStructure> : IDecision<TValue, TStructure> where TStructure : new()
	{
		private readonly List<TValue> values = new List<TValue>();

		private int index;

		private TStructure structure = new TStructure();

		public IList<TValue> Values => values;

		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}

		public TStructure Structure
		{
			get
			{
				return structure;
			}
			set
			{
				structure = value;
			}
		}
	}
}
