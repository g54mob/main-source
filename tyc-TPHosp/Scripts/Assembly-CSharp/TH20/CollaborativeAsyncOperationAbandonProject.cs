using System;

namespace TH20
{
	public class CollaborativeAsyncOperationAbandonProject : CollaborativeAsyncOperation
	{
		private readonly Guid _projectId;

		public Guid? ProjectId => _projectId;

		public CollaborativeAsyncOperationAbandonProject(CollaborativePortfolio portfolio, Guid projectId)
			: base(portfolio)
		{
			_projectId = projectId;
		}

		public override void Enter()
		{
			Portfolio.AbandonCollaborativeProjectInternal(_projectId);
			Handler.EndOperation(this);
		}
	}
}
