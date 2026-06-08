using Antlr4.Runtime.Atn;

namespace Antlr4.Runtime.Dfa
{
	public class PredPrediction
	{
		public SemanticContext pred;

		public int alt;

		public PredPrediction(SemanticContext pred, int alt)
		{
			this.alt = alt;
			this.pred = pred;
		}

		public override string ToString()
		{
			return "(" + pred?.ToString() + ", " + alt + ")";
		}
	}
}
