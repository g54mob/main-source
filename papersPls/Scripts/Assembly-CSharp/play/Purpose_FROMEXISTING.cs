using data;

namespace play
{
	public sealed class Purpose_FROMEXISTING : Purpose
	{
		public readonly FactSet storyStateFacts;

		public Purpose_FROMEXISTING(FactSet storyStateFacts)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}
