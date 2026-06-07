namespace Obi
{
	public class BurstPinConstraints : BurstConstraintsImpl<BurstPinConstraintsBatch>
	{
		public BurstPinConstraints(BurstSolverImpl solver)
			: base(solver, Oni.ConstraintType.Pin)
		{
		}

		public override IConstraintsBatchImpl CreateConstraintsBatch()
		{
			BurstPinConstraintsBatch burstPinConstraintsBatch = new BurstPinConstraintsBatch(this);
			batches.Add(burstPinConstraintsBatch);
			return burstPinConstraintsBatch;
		}

		public override void RemoveBatch(IConstraintsBatchImpl batch)
		{
			batches.Remove(batch as BurstPinConstraintsBatch);
			batch.Destroy();
		}
	}
}
