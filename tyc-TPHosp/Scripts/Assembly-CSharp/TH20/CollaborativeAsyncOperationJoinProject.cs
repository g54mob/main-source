using System;
using System.Linq;

namespace TH20
{
	public class CollaborativeAsyncOperationJoinProject : CollaborativeAsyncOperation
	{
		private readonly Guid _projectId;

		public Guid? ProjectId => _projectId;

		public CollaborativeAsyncOperationJoinProject(CollaborativePortfolio portfolio, Guid projectId)
			: base(portfolio)
		{
			_projectId = projectId;
		}

		public override void Enter()
		{
			if (!Portfolio.ProjectsInvitedTo.Any((CollaborativeProjectData projectData) => projectData.ProjectID == _projectId))
			{
				Handler.EndOperation(this);
				return;
			}
			for (int num = 0; num < Portfolio.ActiveProjectSlots.Count; num++)
			{
				if (Portfolio.ActiveProjectSlots[num].ProjectID == _projectId)
				{
					Handler.EndOperation(this);
					return;
				}
			}
			Portfolio.JoinCollaborativeProjectInternal(_projectId);
			Handler.EndOperation(this);
		}
	}
}
