using System;
using System.Collections.Generic;

namespace TH20
{
	public class CollaborativeAsyncOperationHandler : MustCallDestroy
	{
		private readonly CollaborativePortfolio _portfolio;

		private readonly List<CollaborativeAsyncOperation> _operations = new List<CollaborativeAsyncOperation>();

		private CollaborativeAsyncOperation _currentOperation;

		private bool _updateWhenFinished;

		public Action<CollaborativeAsyncOperation> OnAsyncOperationStarted;

		public Action<CollaborativeAsyncOperation> OnAsyncOperationFinished;

		public CollaborativeAsyncOperationHandler(CollaborativePortfolio portfolio)
		{
			_portfolio = portfolio;
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_currentOperation != null)
			{
				_currentOperation.Destroy();
				_currentOperation = null;
			}
		}

		public void Update()
		{
			if (_currentOperation != null)
			{
				_currentOperation.Update();
			}
		}

		public void EnqueueOperation(CollaborativeAsyncOperation operation)
		{
			operation.Handler = this;
			if (operation.ForceOperationToFront)
			{
				_operations.Insert(0, operation);
			}
			else
			{
				_operations.Add(operation);
			}
			if (_currentOperation == null)
			{
				HandleNext();
			}
		}

		public void EndOperation(CollaborativeAsyncOperation operation)
		{
			HandleNext();
			if (_updateWhenFinished && _currentOperation == null)
			{
				_updateWhenFinished = false;
				_portfolio.PortfolioDataController?.ForceUploadData();
			}
		}

		private void HandleNext()
		{
			if (_currentOperation != null)
			{
				CollaborativeAsyncOperation currentOperation = _currentOperation;
				_currentOperation.Exit();
				_currentOperation = null;
				OnAsyncOperationFinished.InvokeSafe(currentOperation);
				currentOperation.Destroy();
			}
			if (_operations.Count > 0)
			{
				_currentOperation = _operations[0];
				_operations.RemoveAt(0);
				if (_currentOperation != null)
				{
					_updateWhenFinished |= _currentOperation.UploadOnceFinished;
					OnAsyncOperationStarted.InvokeSafe(_currentOperation);
					_currentOperation.Enter();
				}
			}
		}

		public bool ContainsOperationType<T>()
		{
			if (_currentOperation != null && _currentOperation is T)
			{
				return true;
			}
			for (int i = 0; i < _operations.Count; i++)
			{
				if (_operations[i] is T)
				{
					return true;
				}
			}
			return false;
		}

		public CollaborativeAsyncOperation FindNextOperationRelatingToProject(Guid projectId)
		{
			if (DoesOperationRelateToProject(_currentOperation, projectId))
			{
				return _currentOperation;
			}
			for (int i = 0; i < _operations.Count; i++)
			{
				CollaborativeAsyncOperation collaborativeAsyncOperation = _operations[i];
				if (DoesOperationRelateToProject(collaborativeAsyncOperation, projectId))
				{
					return collaborativeAsyncOperation;
				}
			}
			return null;
		}

		private bool DoesOperationRelateToProject(CollaborativeAsyncOperation operation, Guid projectId)
		{
			if (operation == null)
			{
				return false;
			}
			if (operation is CollaborativeAsyncOperationAbandonProject { ProjectId: var projectId2 })
			{
				Guid guid = projectId;
				if (!projectId2.HasValue)
				{
					return false;
				}
				if (!projectId2.HasValue)
				{
					return true;
				}
				return projectId2.GetValueOrDefault() == guid;
			}
			if (operation is CollaborativeAsyncOperationJoinProject { ProjectId: var projectId3 })
			{
				Guid guid = projectId;
				if (!projectId3.HasValue)
				{
					return false;
				}
				if (!projectId3.HasValue)
				{
					return true;
				}
				return projectId3.GetValueOrDefault() == guid;
			}
			return false;
		}
	}
}
