using System;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchPanelProject : CollaborativeResearchPanel
	{
		private enum State
		{
			ProjectView = 0,
			Kicked = 1,
			Completed = 2
		}

		public Action<Guid?> OnCollectRewardPressed;

		public Action<Guid?> OnAbandonKickedPressed;

		public Action<ObjectiveDefinition> OnResearchObjectiveStarted;

		[SerializeField]
		private CollaborativeProjectView _projectView;

		[SerializeField]
		private CollaborativeResearchPanelKicked _panelKicked;

		[SerializeField]
		private CollaborativeResearchPanelCompleted _panelCompleted;

		private State _state;

		private Metagame _metagame;

		private CollaborativeResearchMenu _rootMenu;

		public void Initialise(CollaborativeResearchMenu rootMenu, Metagame metagame, CollaborativePortfolio portfolio, InputManager inputManager, OnlineMetadataManager metadataManager)
		{
			Initialise(portfolio);
			_rootMenu = rootMenu;
			_metagame = metagame;
			_panelKicked.Initialise(portfolio);
			_panelCompleted.Initialise(portfolio);
			_projectView.Initialise(metagame, rootMenu, Portfolio, inputManager, metadataManager);
		}

		protected override void OnEnable()
		{
			CollaborativeProjectView projectView = _projectView;
			projectView.OnCompletedProject = (Action<CollaborativeProject>)Delegate.Combine(projectView.OnCompletedProject, new Action<CollaborativeProject>(OnProjectCompleted));
			CollaborativeProjectView projectView2 = _projectView;
			projectView2.OnResearchObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Combine(projectView2.OnResearchObjectiveStarted, new Action<ObjectiveDefinition>(OnResearchNodeStarted));
			CollaborativeResearchPanelKicked panelKicked = _panelKicked;
			panelKicked.OnAbandonProject = (Action<Guid?>)Delegate.Combine(panelKicked.OnAbandonProject, new Action<Guid?>(OnAbandonKickedProject));
			CollaborativeResearchPanelCompleted panelCompleted = _panelCompleted;
			panelCompleted.OnCollectRewardPressed = (Action<Guid?>)Delegate.Combine(panelCompleted.OnCollectRewardPressed, new Action<Guid?>(OnCollectReward));
		}

		protected override void OnDisable()
		{
			CollaborativeProjectView projectView = _projectView;
			projectView.OnCompletedProject = (Action<CollaborativeProject>)Delegate.Remove(projectView.OnCompletedProject, new Action<CollaborativeProject>(OnProjectCompleted));
			CollaborativeProjectView projectView2 = _projectView;
			projectView2.OnResearchObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Remove(projectView2.OnResearchObjectiveStarted, new Action<ObjectiveDefinition>(OnResearchNodeStarted));
			CollaborativeResearchPanelKicked panelKicked = _panelKicked;
			panelKicked.OnAbandonProject = (Action<Guid?>)Delegate.Remove(panelKicked.OnAbandonProject, new Action<Guid?>(OnAbandonKickedProject));
			CollaborativeResearchPanelCompleted panelCompleted = _panelCompleted;
			panelCompleted.OnCollectRewardPressed = (Action<Guid?>)Delegate.Remove(panelCompleted.OnCollectRewardPressed, new Action<Guid?>(OnCollectReward));
		}

		public override void SetupForProject(Guid? projectId)
		{
			base.SetupForProject(projectId);
			_panelKicked.SetupForProject(projectId);
			_panelCompleted.SetupForProject(projectId);
			_projectView.SetupForProject(projectId);
		}

		public override void Show()
		{
			base.Show();
			Refresh();
			if (_metagame != null && !_metagame.CollaborativeMetagameData.HasSeenTutorial(CollaborativeMetagameData.TutorialType.CollaborativeProjectTutorial))
			{
				_rootMenu.TutorialBox.Show(CollaborativeMetagameData.TutorialType.CollaborativeProjectTutorial);
			}
		}

		public override void OnGetLatestCompleted()
		{
			Refresh();
		}

		private void Refresh()
		{
			CollaborativeProject project = Portfolio.GetProject(ProjectId.Value);
			if (project == null)
			{
				return;
			}
			if (project.IsProjectCompleted())
			{
				switch (_state)
				{
				case State.Completed:
					_panelCompleted.Show();
					break;
				case State.Kicked:
					_panelKicked.Hide();
					_panelCompleted.Show();
					break;
				case State.ProjectView:
					_projectView.Hide();
					_panelCompleted.Show();
					break;
				}
				_state = State.Completed;
			}
			else if (project.HasPlayerBeenKicked())
			{
				switch (_state)
				{
				case State.Completed:
					_panelCompleted.Hide();
					_panelKicked.Show();
					break;
				case State.Kicked:
					_panelKicked.Show();
					break;
				case State.ProjectView:
					_projectView.Hide();
					_panelKicked.Show();
					break;
				}
				_state = State.Kicked;
			}
			else
			{
				switch (_state)
				{
				case State.Completed:
					_panelCompleted.Hide();
					_projectView.Show();
					break;
				case State.Kicked:
					_panelKicked.Hide();
					_projectView.Show();
					break;
				case State.ProjectView:
					_projectView.Show();
					break;
				}
				_state = State.ProjectView;
			}
		}

		private void OnProjectCompleted(CollaborativeProject project)
		{
			Refresh();
		}

		private void OnAbandonKickedProject(Guid? projectId)
		{
			OnAbandonKickedPressed.InvokeSafe(projectId);
		}

		private void OnCollectReward(Guid? projectId)
		{
			OnCollectRewardPressed.InvokeSafe(projectId);
		}

		private void OnResearchNodeStarted(ObjectiveDefinition definition)
		{
			OnResearchObjectiveStarted.InvokeSafe(definition);
		}
	}
}
