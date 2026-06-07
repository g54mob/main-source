using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class TutorialsMenuController : AUIController
	{
		private ATutorialsMenuProvider provider;

		[NullCheck]
		public PauseMenuController parentController;

		[Header("UI Elements")]
		[NullCheck]
		public ToggleDV de2;

		[NullCheck]
		public ToggleDV de6;

		[NullCheck]
		public ToggleDV dh4;

		[NullCheck]
		public ToggleDV dm3;

		[NullCheck]
		public ToggleDV s282a;

		[NullCheck]
		public ToggleDV s060;

		[NullCheck]
		public ToggleDV microshunter;

		[NullCheck]
		public ToggleDV dm1u;

		[NullCheck]
		public ButtonDV runCouplingTut;

		[NullCheck]
		public ButtonDV runLocoTut;

		[NullCheck]
		public ButtonDV abortButton;

		private ATutorialsMenuProvider.Data data;

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		private PopupManager _popupManager;

		private PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		public void SetProvider(ATutorialsMenuProvider provider)
		{
			this.provider = provider;
			_ = (bool)this.provider;
		}

		protected override void Awake()
		{
			base.Awake();
			de2.onValueChanged.AddListener(OnCheckboxToggled);
			de6.onValueChanged.AddListener(OnCheckboxToggled);
			dh4.onValueChanged.AddListener(OnCheckboxToggled);
			dm3.onValueChanged.AddListener(OnCheckboxToggled);
			s282a.onValueChanged.AddListener(OnCheckboxToggled);
			s060.onValueChanged.AddListener(OnCheckboxToggled);
			microshunter.onValueChanged.AddListener(OnCheckboxToggled);
			dm1u.onValueChanged.AddListener(OnCheckboxToggled);
			runCouplingTut.Clicked += OnRunCouplingTutClicked;
			runLocoTut.Clicked += OnRunLocoTutClicked;
			abortButton.Clicked += OnAbortClicked;
		}

		private void OnEnable()
		{
			RefreshData();
		}

		private void RefreshData()
		{
			if (reentrancyCheck_RefreshData)
			{
				Debug.LogError("Reentrancy check fail for RefreshData!", this);
			}
			reentrancyCheck_RefreshData = true;
			if (provider != null)
			{
				data = provider.GetData();
			}
			RefreshInterface();
			reentrancyCheck_RefreshData = false;
		}

		private void RefreshInterface()
		{
			if (reentrancyCheck_RefreshInterface)
			{
				Debug.LogError("Reentrancy check fail for RefreshInterface!", this);
			}
			reentrancyCheck_RefreshInterface = true;
			de2.SetIsOnWithoutNotify(!data.de2Passed);
			de6.SetIsOnWithoutNotify(!data.de6Passed);
			dh4.SetIsOnWithoutNotify(!data.dh4Passed);
			dm3.SetIsOnWithoutNotify(!data.dm3Passed);
			s282a.SetIsOnWithoutNotify(!data.s282aPassed);
			s060.SetIsOnWithoutNotify(!data.s060Passed);
			microshunter.SetIsOnWithoutNotify(!data.microshunterPassed);
			dm1u.SetIsOnWithoutNotify(!data.dm1uPassed);
			runCouplingTut.ToggleInteractable(!data.isQuickTutorialRunning && !provider.IsMetaTutorialHackActive());
			runLocoTut.ToggleInteractable(provider.IsMetaTutorialHackActive() || (!data.isQuickTutorialRunning && data.isPlayerOnLocoThatSupportsQuickTutorial));
			abortButton.ToggleInteractable(data.isQuickTutorialRunning && !provider.IsMetaTutorialHackActive());
			reentrancyCheck_RefreshInterface = false;
		}

		private void OnCheckboxToggled(bool _)
		{
			data.de2Passed = !de2.isOn;
			data.de6Passed = !de6.isOn;
			data.dh4Passed = !dh4.isOn;
			data.dm3Passed = !dm3.isOn;
			data.s282aPassed = !s282a.isOn;
			data.s060Passed = !s060.isOn;
			data.microshunterPassed = !microshunter.isOn;
			data.dm1uPassed = !dm1u.isOn;
			provider.SetData(data);
		}

		private void OnRunCouplingTutClicked(IClickable _)
		{
			RequestClose();
			provider.RunCouplingTutorial();
		}

		private void OnRunLocoTutClicked(IClickable _)
		{
			RequestClose();
			provider.RunLocoTutorial();
		}

		private void OnAbortClicked(IClickable _)
		{
			RequestClose();
			provider.AbortCurrentQuickTutorial();
		}

		private void RequestClose()
		{
			if ((bool)parentController)
			{
				parentController.RequestClose();
			}
		}
	}
}
