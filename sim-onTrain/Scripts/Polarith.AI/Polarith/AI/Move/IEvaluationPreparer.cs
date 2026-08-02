namespace Polarith.AI.Move
{
	public interface IEvaluationPreparer
	{
		bool Enabled { get; set; }

		void PrepareEvaluation();
	}
}
