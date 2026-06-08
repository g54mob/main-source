using Antlr4.Runtime.Misc;

namespace Antlr4.Runtime.Atn
{
	public class SingletonPredictionContext : PredictionContext
	{
		[NotNull]
		public readonly PredictionContext parent;

		public readonly int returnState;

		public override int Size => 1;

		public override bool IsEmpty => false;

		public static PredictionContext Create(PredictionContext parent, int returnState)
		{
			if (returnState == PredictionContext.EMPTY_RETURN_STATE && parent == null)
			{
				return PredictionContext.EMPTY;
			}
			return new SingletonPredictionContext(parent, returnState);
		}

		internal SingletonPredictionContext(PredictionContext parent, int returnState)
			: base(PredictionContext.CalculateHashCode(parent, returnState))
		{
			this.parent = parent;
			this.returnState = returnState;
		}

		public override PredictionContext GetParent(int index)
		{
			return parent;
		}

		public override int GetReturnState(int index)
		{
			return returnState;
		}

		public override bool Equals(object o)
		{
			if (o == this)
			{
				return true;
			}
			if (!(o is SingletonPredictionContext))
			{
				return false;
			}
			if (GetHashCode() != o.GetHashCode())
			{
				return false;
			}
			SingletonPredictionContext singletonPredictionContext = (SingletonPredictionContext)o;
			if (returnState == singletonPredictionContext.returnState)
			{
				if (parent != null)
				{
					return parent.Equals(singletonPredictionContext.parent);
				}
				return false;
			}
			return false;
		}

		public override string ToString()
		{
			string text = ((parent != null) ? parent.ToString() : "");
			if (text.Length == 0)
			{
				if (returnState == PredictionContext.EMPTY_RETURN_STATE)
				{
					return "$";
				}
				return returnState.ToString();
			}
			return returnState + " " + text;
		}
	}
}
