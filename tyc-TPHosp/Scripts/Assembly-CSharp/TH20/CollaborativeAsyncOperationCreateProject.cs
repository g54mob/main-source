using System;

namespace TH20
{
	public class CollaborativeAsyncOperationCreateProject : CollaborativeAsyncOperation
	{
		private readonly CollaborativeProjectDefinition _projectDefinition;

		private Guid? _createdProjectId;

		public Guid? CreatedProjectId => _createdProjectId;

		public CollaborativeAsyncOperationCreateProject(CollaborativePortfolio portfolio, CollaborativeProjectDefinition projectDefinition)
			: base(portfolio)
		{
			_projectDefinition = projectDefinition;
		}

		public override void Enter()
		{
			if (Portfolio.ActiveProjectSlots.Count >= CollaborativePortfolioDataController.MaxCollaborativeProjects)
			{
				Handler.EndOperation(this);
				return;
			}
			_createdProjectId = Portfolio.CreateCollaborativeProjectInternal(_projectDefinition);
			Handler.EndOperation(this);
		}
	}
}
