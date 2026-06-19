using System;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchPanelGlobal : CollaborativeResearchPanel
	{
		public Action<ObjectiveDefinition> OnSuperBugObjectiveStarted;

		[SerializeField]
		private SuperBugProjectView _projectView;

		private SuperBugProjectManager _superBugManager;

		private Metagame _metagame;

		private CollaborativeResearchMenu _rootMenu;

		public void Initialise(CollaborativeResearchMenu rootMenu, Metagame metagame, CollaborativePortfolio portfolio, SuperBugProjectManager superBugManager)
		{
			Initialise(portfolio);
			_superBugManager = superBugManager;
			_rootMenu = rootMenu;
			_metagame = metagame;
			_projectView.Initialise(rootMenu, metagame, _superBugManager, portfolio);
		}

		protected override void OnEnable()
		{
			SuperBugProjectView projectView = _projectView;
			projectView.OnSuperBugObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Combine(projectView.OnSuperBugObjectiveStarted, new Action<ObjectiveDefinition>(OnObjectiveStarted));
		}

		protected override void OnDisable()
		{
			SuperBugProjectView projectView = _projectView;
			projectView.OnSuperBugObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Remove(projectView.OnSuperBugObjectiveStarted, new Action<ObjectiveDefinition>(OnObjectiveStarted));
		}

		public override void SetupForProject(Guid? projectId)
		{
			base.SetupForProject(projectId);
			_projectView.SetupForProject();
		}

		public override void Show()
		{
			base.Show();
			_projectView.Show();
			if (_metagame != null && !_metagame.CollaborativeMetagameData.HasSeenTutorial(CollaborativeMetagameData.TutorialType.GlobalProjectTutorial))
			{
				_rootMenu.TutorialBox.Show(CollaborativeMetagameData.TutorialType.GlobalProjectTutorial);
			}
		}

		public override void Hide()
		{
			base.Hide();
			_projectView.Hide();
		}

		public override void OnGetLatestCompleted()
		{
			_projectView.Refresh();
		}

		private void OnObjectiveStarted(ObjectiveDefinition definition)
		{
			OnSuperBugObjectiveStarted.InvokeSafe(definition);
		}
	}
}
