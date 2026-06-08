using System.Text;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class ArrayPredictionContext : PredictionContext
	{
		public readonly PredictionContext[] parents;

		public readonly int[] returnStates;

		public override bool IsEmpty => returnStates[0] == PredictionContext.EMPTY_RETURN_STATE;

		public override int Size => returnStates.Length;

		public ArrayPredictionContext(SingletonPredictionContext a)
			: this(new PredictionContext[1] { a.parent }, new int[1] { a.returnState })
		{
		}

		public ArrayPredictionContext(PredictionContext[] parents, int[] returnStates)
			: base(PredictionContext.CalculateHashCode(parents, returnStates))
		{
			this.parents = parents;
			this.returnStates = returnStates;
		}

		public override PredictionContext GetParent(int index)
		{
			return parents[index];
		}

		public override int GetReturnState(int index)
		{
			return returnStates[index];
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (!(o is ArrayPredictionContext))
			{
				return false;
			}
			if (GetHashCode() != o.GetHashCode())
			{
				return false;
			}
			ArrayPredictionContext arrayPredictionContext = (ArrayPredictionContext)o;
			if (Arrays.Equals(returnStates, arrayPredictionContext.returnStates))
			{
				return Arrays.Equals(parents, arrayPredictionContext.parents);
			}
			return false;
		}

		public override string ToString()
		{
			if (IsEmpty)
			{
				return "[]";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			for (int i = 0; i < returnStates.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				if (returnStates[i] == PredictionContext.EMPTY_RETURN_STATE)
				{
					stringBuilder.Append("$");
					continue;
				}
				stringBuilder.Append(returnStates[i]);
				if (parents[i] != null)
				{
					stringBuilder.Append(' ');
					stringBuilder.Append(parents[i].ToString());
				}
				else
				{
					stringBuilder.Append("null");
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
