namespace Jobberwocky.MIConvexHull
{
	public class ConvexHullCreationResult<TVertex, TFace> where TVertex : IVertex where TFace : ConvexFace<TVertex, TFace>, new()
	{
		private readonly ConvexHull<TVertex, TFace> _003CResult_003Ek__BackingField;

		private readonly ConvexHullCreationResultOutcome _003COutcome_003Ek__BackingField;

		private readonly string _003CErrorMessage_003Ek__BackingField;

		public ConvexHull<TVertex, TFace> Result => _003CResult_003Ek__BackingField;

		public ConvexHullCreationResult(ConvexHull<TVertex, TFace> result, ConvexHullCreationResultOutcome outcome, string errorMessage = "")
		{
			_003CResult_003Ek__BackingField = result;
			_003COutcome_003Ek__BackingField = outcome;
			_003CErrorMessage_003Ek__BackingField = errorMessage;
		}
	}
}
