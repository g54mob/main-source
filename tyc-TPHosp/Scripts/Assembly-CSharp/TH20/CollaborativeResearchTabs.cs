using System;
using System.Collections;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeResearchTabs : MonoBehaviour
	{
		[SerializeField]
		private CollaborativeResearchTabButton[] _tabButtons;

		[SerializeField]
		private GameObject _invitesTab;

		[SerializeField]
		private Image _inviteButtonBackground;

		[SerializeField]
		private DynamicButton _invitesButton;

		[SerializeField]
		private UnseenNotificationsIcon _invitesNotifications;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private Sprite _invitesBackground;

		[SerializeField]
		private Sprite _invitesBackgroundDisabled;

		public Action<Guid?> OnTabSelected;

		public Action<int> OnSuperBugTabSelected;

		public Action<Guid?> OnTabAbandonSelected;

		public Action OnInvitesTabSelected;

		private CollaborativePortfolio _portfolio;

		private SuperBugProjectManager _superBugManager;

		private CollaborativeResearchMenu _rootMenu;

		private int _previousInboxAmount;

		private Guid? SelectedProjectId => _rootMenu.SelectedProjectId;

		private int? SelectedSuperBugId => _rootMenu.SelectedSuperBugId;

		private void OnEnable()
		{
			_invitesButton.onPrimaryDown.AddListener(OnInvitesPressed);
		}

		private void OnDisable()
		{
			_invitesButton.onPrimaryDown.RemoveListener(OnInvitesPressed);
		}

		public void Initialise(CollaborativePortfolio portfolio, SuperBugProjectManager superBugManager, CollaborativeResearchMenu rootMenu)
		{
			_portfolio = portfolio;
			_superBugManager = superBugManager;
			_rootMenu = rootMenu;
			CollaborativeResearchTabButton[] tabButtons = _tabButtons;
			foreach (CollaborativeResearchTabButton obj in tabButtons)
			{
				obj.Initialise(rootMenu, portfolio, superBugManager);
				obj.OnSelected = (Action<Guid?>)Delegate.Combine(obj.OnSelected, new Action<Guid?>(OnTabButtonSelected));
				obj.OnAbandonSelected = (Action<Guid?>)Delegate.Combine(obj.OnAbandonSelected, new Action<Guid?>(OnTabAbandonButtonSelected));
				obj.OnSuperBugSelected = (Action<int>)Delegate.Combine(obj.OnSuperBugSelected, new Action<int>(OnTabSuperBugSelected));
			}
		}

		private void OnDestroy()
		{
			if (_portfolio != null)
			{
				CollaborativeResearchTabButton[] tabButtons = _tabButtons;
				foreach (CollaborativeResearchTabButton obj in tabButtons)
				{
					obj.OnSelected = (Action<Guid?>)Delegate.Remove(obj.OnSelected, new Action<Guid?>(OnTabButtonSelected));
					obj.OnAbandonSelected = (Action<Guid?>)Delegate.Remove(obj.OnAbandonSelected, new Action<Guid?>(OnTabAbandonButtonSelected));
					obj.OnSuperBugSelected = (Action<int>)Delegate.Remove(obj.OnSuperBugSelected, new Action<int>(OnTabSuperBugSelected));
				}
			}
		}

		public void Refresh()
		{
			int? num = null;
			int num2 = 0;
			int num3 = 0;
			if (_superBugManager.DownloadedProjectDefinition != null)
			{
				_tabButtons[num2].SetupWithSuperBug(_superBugManager.DownloadedProjectDefinition);
				num2++;
			}
			bool flag = _portfolio.ProjectsInvitedTo.Count > 0;
			_inviteButtonBackground.overrideSprite = (flag ? _invitesBackground : _invitesBackgroundDisabled);
			_invitesButton.enabled = flag;
			GameObjectUtils.SetActive(_invitesTab, isActive: false);
			for (int i = 0; i < _portfolio.ActiveProjectSlots.Count; i++)
			{
				CollaborativeProject collaborativeProject = _portfolio.ActiveProjectSlots[i];
				if (collaborativeProject != null)
				{
					_tabButtons[num2].SetupWithProject(collaborativeProject);
					num2++;
					num3++;
				}
			}
			if (num3 < CollaborativePortfolioDataController.MaxCollaborativeProjects)
			{
				_tabButtons[num2].SetupWithNew();
				num = num2;
				num2++;
			}
			for (int j = num2; j < _tabButtons.Length; j++)
			{
				_tabButtons[j].SetupAsHidden();
			}
			CollaborativeResearchTabButton[] tabButtons = _tabButtons;
			foreach (CollaborativeResearchTabButton collaborativeResearchTabButton in tabButtons)
			{
				bool selectState = (collaborativeResearchTabButton.ProjectId.HasValue && SelectedProjectId.HasValue && collaborativeResearchTabButton.ProjectId == SelectedProjectId.Value) || (collaborativeResearchTabButton.SuperBugDefinition != null && collaborativeResearchTabButton.SuperBugDefinition.SuperBugID == SelectedSuperBugId);
				collaborativeResearchTabButton.SetSelectState(selectState);
			}
			if (!SelectedSuperBugId.HasValue && !SelectedProjectId.HasValue && num.HasValue)
			{
				if (_rootMenu.ShowInvites)
				{
					GameObjectUtils.SetActive(_invitesTab, isActive: true);
				}
				else
				{
					_tabButtons[num.Value].SetSelectState(isSelected: true);
				}
			}
			_invitesNotifications.UnseenNotifications = _portfolio.ProjectsInvitedTo.Count;
			if (_previousInboxAmount < _portfolio.ProjectsInvitedTo.Count)
			{
				_previousInboxAmount = _portfolio.ProjectsInvitedTo.Count;
				StartCoroutine(AnimateInboxButton());
			}
		}

		private IEnumerator AnimateInboxButton()
		{
			_animator.SetBool("Ping", value: true);
			yield return null;
			_animator.SetBool("Ping", value: false);
		}

		private void OnTabButtonSelected(Guid? projectId)
		{
			OnTabSelected.InvokeSafe(projectId);
			CollaborativeResearchTabButton[] tabButtons = _tabButtons;
			for (int i = 0; i < tabButtons.Length; i++)
			{
				tabButtons[i].RefreshAlert();
			}
		}

		private void OnTabAbandonButtonSelected(Guid? projectId)
		{
			OnTabAbandonSelected.InvokeSafe(projectId);
			CollaborativeResearchTabButton[] tabButtons = _tabButtons;
			for (int i = 0; i < tabButtons.Length; i++)
			{
				tabButtons[i].RefreshAlert();
			}
		}

		private void OnTabSuperBugSelected(int superBugId)
		{
			OnSuperBugTabSelected.InvokeSafe(superBugId);
			CollaborativeResearchTabButton[] tabButtons = _tabButtons;
			for (int i = 0; i < tabButtons.Length; i++)
			{
				tabButtons[i].RefreshAlert();
			}
		}

		private void OnInvitesPressed()
		{
			OnInvitesTabSelected.InvokeSafe();
		}

		public void CheckOperationLockStatus()
		{
			for (int i = 0; i < _tabButtons.Length; i++)
			{
				_tabButtons[i].CheckOperationLockStatus(_portfolio.AsyncOperationHandler);
			}
		}
	}
}
