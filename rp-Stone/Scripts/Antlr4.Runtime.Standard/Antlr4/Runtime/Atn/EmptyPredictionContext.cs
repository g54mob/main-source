namespace Antlr4.Runtime.Atn
{
	public sealed class EmptyPredictionContext : SingletonPredictionContext
	{
		public override int Size => 1;

		public override bool IsEmpty => true;

		internal EmptyPredictionContext()
			: base(null, PredictionContext.EMPTY_RETURN_STATE)
		{
		}

		public override PredictionContext GetParent(int index)
		{
			return null;
		}

		public override int GetReturnState(int index)
		{
			return returnState;
		}

		public override bool Equals(object o)
		{
			return this == o;
		}

		public override string ToString()
		{
			return "$";
		}

		public override string[] ToStrings(IRecognizer recognizer, int currentState)
		{
			return new string[1] { "[]" };
		}

		public override string[] ToStrings(IRecognizer recognizer, PredictionContext stop, int currentState)
		{
			return new string[1] { "[]" };
		}
	}
}
